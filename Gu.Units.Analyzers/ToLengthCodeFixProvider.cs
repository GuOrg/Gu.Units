namespace Gu.Units.Analyzers
{
    using System.Composition;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CodeFixes;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Simplification;

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ToLengthCodeFixProvider)), Shared]
    public class ToLengthCodeFixProvider : ToUnitCodeFixProvider
    {
        protected override string TitleFormat { get; } = "Length.FromMillimetres({0})";

        protected override string Key { get; } = "Length.FromMillimetres()";

        protected override string Pattern { get; } = "Cannot implicitly convert type '(int|double)' to 'Gu.Units.Length'";

        protected override MemberAccessExpressionSyntax WrapSyntax { get; }=
            SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    SyntaxFactory.IdentifierName("Length"),
                    SyntaxFactory.IdentifierName("FromMillimetres")
                )
                .WithAdditionalAnnotations(Simplifier.Annotation);
    }
}
