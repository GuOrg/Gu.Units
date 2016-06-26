namespace Gu.Units.Analyzers
{
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CodeActions;
    using Microsoft.CodeAnalysis.CodeFixes;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public abstract class ToUnitCodeFixProvider : CodeFixProvider
    {
        private static readonly Task FinishedTask = Task.FromResult(false);

        public sealed override ImmutableArray<string> FixableDiagnosticIds { get; } = ImmutableArray.Create("CS0029");

        protected abstract string TitleFormat { get; }

        protected abstract string Key { get; }

        protected abstract string Pattern { get; }

        protected abstract MemberAccessExpressionSyntax WrapSyntax { get; }

        public sealed override FixAllProvider GetFixAllProvider()
        {
            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/FixAllProvider.md for more information on Fix All Providers
            return WellKnownFixAllProviders.BatchFixer;
        }

        public sealed override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var diagnostic = context.Diagnostics[0];
            var message = diagnostic.GetMessage(null);
            if (!Regex.IsMatch(message, this.Pattern))
            {
                return FinishedTask;
            }

            return this.RegisterCodeFixesCoreAsync(context, diagnostic);
        }

        private async Task RegisterCodeFixesCoreAsync(CodeFixContext context, Diagnostic diagnostic)
        {
            var sourceText = await diagnostic.Location.SourceTree.GetTextAsync(context.CancellationToken);
            var text = sourceText.GetSubText(context.Span);
            var action = CodeAction.Create(
                string.Format(this.TitleFormat, text),
                c => this.ApplyFix(context, c),
                this.Key);
            context.RegisterCodeFix(
                action,
                diagnostic);
        }

        private  async Task<Document> ApplyFix(CodeFixContext context, CancellationToken cancellationToken)
        {
            var document = context.Document;
            var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);

            var diagnostic = context.Diagnostics.First();
            var position = diagnostic.Location.SourceSpan.Start;
            var scalarExpression = root.FindToken(position)
                .Parent
                .AncestorsAndSelf()
                .OfType<ExpressionSyntax>()
                .First();
            var replacement = this.WrapWithCallToMillimetres(scalarExpression);
            root = root.ReplaceNode(scalarExpression, replacement);
            return document.WithSyntaxRoot(root);
        }

        private  InvocationExpressionSyntax WrapWithCallToMillimetres(ExpressionSyntax expressionToWrap)
        {
            return SyntaxFactory.InvocationExpression(this.WrapSyntax,
                SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(new[] { SyntaxFactory.Argument(expressionToWrap) }))
                );
        }
    }
}