namespace Gu.Units.Analyzers
{
    using System.Composition;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CodeFixes;

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ToLengthCodeFixProvider))]
    [Shared]
    public class ToLengthCodeFixProvider : ToUnitCodeFixProvider
    {
        public ToLengthCodeFixProvider()
            : base("Length", "FromMillimetres")
        {
        }
    }
}
