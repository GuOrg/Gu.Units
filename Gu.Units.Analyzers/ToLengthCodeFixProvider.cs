namespace Gu.Units.Analyzers
{
    using System.Collections.Immutable;
    using System.Composition;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CodeActions;
    using Microsoft.CodeAnalysis.CodeFixes;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Simplification;

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ToLengthCodeFixProvider)), Shared]
    public class ToLengthCodeFixProvider : CodeFixProvider
    {
        private static readonly Task FinishedTask = Task.FromResult(false);
        private const string TitleFormat = "Length.FromMillimetres({0})";
        private const string Key = "Length.FromMillimetres()";

        public sealed override ImmutableArray<string> FixableDiagnosticIds { get; } = ImmutableArray.Create("CS0029");

        public sealed override FixAllProvider GetFixAllProvider()
        {
            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/FixAllProvider.md for more information on Fix All Providers
            return WellKnownFixAllProviders.BatchFixer;
        }

        public sealed override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var diagnostic = context.Diagnostics[0];
            var message = diagnostic.GetMessage(null);
            if (!Regex.IsMatch(message, "Cannot implicitly convert type '(int|double)' to 'Gu.Units.Length'"))
            {
                return FinishedTask;
            }

            return RegisterCodeFixesCoreAsync(context, diagnostic);
        }

        private static async Task RegisterCodeFixesCoreAsync(CodeFixContext context, Diagnostic diagnostic)
        {
            var sourceText = await diagnostic.Location.SourceTree.GetTextAsync(context.CancellationToken);
            var text = sourceText.GetSubText(context.Span);
            var action = CodeAction.Create(
                string.Format(TitleFormat, text),
                c => ApplyFix(context, c),
                Key);
            context.RegisterCodeFix(
                action,
                diagnostic);
        }

        private static async Task<Document> ApplyFix(CodeFixContext context, CancellationToken cancellationToken)
        {
            var document = context.Document;
            var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);

            // We need to get the LiteralExpressionSyntax that was found by the Analyser
            var diagnostic = context.Diagnostics.First();
            var position = diagnostic.Location.SourceSpan.Start;
            var scalarExpression = root.FindToken(position)
                .Parent
                .AncestorsAndSelf()
                .OfType<ExpressionSyntax>()
                .First();
            var replacement = WrapWithCallToMillimetres(scalarExpression);
            root = root.ReplaceNode(scalarExpression, replacement);
            return document.WithSyntaxRoot(root);
        }

        private static InvocationExpressionSyntax WrapWithCallToMillimetres(ExpressionSyntax expressionToWrap)
        {
            return SyntaxFactory.InvocationExpression(
                InvariantExpressionSyntax,
                SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(new[] { SyntaxFactory.Argument(expressionToWrap) }))
                );
        }

        private static readonly MemberAccessExpressionSyntax InvariantExpressionSyntax =
            SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    SyntaxFactory.IdentifierName("Length"),
                    SyntaxFactory.IdentifierName("FromMillimetres")
                )
                .WithAdditionalAnnotations(Simplifier.Annotation);
    }
}
