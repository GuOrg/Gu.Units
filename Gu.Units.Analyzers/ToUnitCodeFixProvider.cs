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
    using Microsoft.CodeAnalysis.Simplification;

    public abstract class ToUnitCodeFixProvider : CodeFixProvider
    {
        private readonly string titleFormat;
        private readonly string key;

        private readonly string pattern;

        private readonly MemberAccessExpressionSyntax wrapSyntax;

        protected ToUnitCodeFixProvider(string typename, string memberName)
        {
            this.titleFormat = $"{typename}.{memberName}({{0}})";
            this.key = $"{typename}.{memberName}()";
            this.pattern = $@"Cannot implicitly convert type '(int|double)' to '(Gu.Units.{typename}|System.Nullable<Gu.Units.{typename}>|Gu.Units.{typename}\?)'";
            this.wrapSyntax = SyntaxFactory.MemberAccessExpression(
                                               SyntaxKind.SimpleMemberAccessExpression,
                                               SyntaxFactory.IdentifierName(typename),
                                               SyntaxFactory.IdentifierName(memberName))
                                           .WithAdditionalAnnotations(Simplifier.Annotation);
        }

        public sealed override ImmutableArray<string> FixableDiagnosticIds { get; } = ImmutableArray.Create("CS0029");

        public sealed override FixAllProvider GetFixAllProvider()
        {
            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/FixAllProvider.md for more information on Fix All Providers
            return WellKnownFixAllProviders.BatchFixer;
        }

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var syntaxRoot = await context.Document.GetSyntaxRootAsync(context.CancellationToken)
                                          .ConfigureAwait(false);

            foreach (var diagnostic in context.Diagnostics)
            {
                var message = diagnostic.GetMessage();
                if (!Regex.IsMatch(message, this.pattern))
                {
                    return;
                }

                var sourceText = await diagnostic.Location.SourceTree.GetTextAsync(context.CancellationToken);
                var text = sourceText.GetSubText(context.Span);
                var expression = syntaxRoot.FindNode(diagnostic.Location.SourceSpan)
                                           .FirstAncestorOrSelf<ExpressionSyntax>();
                if (expression != null)
                {
                    context.RegisterCodeFix(
                        CodeAction.Create(
                            string.Format(this.titleFormat, text),
                            _ => this.ApplyFix(context, syntaxRoot, expression),
                            this.key),
                        diagnostic);
                }
            }
        }

        private async Task<Document> ApplyFix(CodeFixContext context, SyntaxNode root, ExpressionSyntax expression)
        {
            var document = context.Document;
            var replacement = this.WrapWithCallToMillimetres(expression);
            root = root.ReplaceNode(expression, replacement);
            return document.WithSyntaxRoot(root);
        }

        private InvocationExpressionSyntax WrapWithCallToMillimetres(ExpressionSyntax expressionToWrap)
        {
            return SyntaxFactory.InvocationExpression(
                this.wrapSyntax,
                SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(new[] { SyntaxFactory.Argument(expressionToWrap) })));
        }
    }
}