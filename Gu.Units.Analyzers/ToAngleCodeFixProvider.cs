namespace Gu.Units.Analyzers
{
    using System.Composition;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CodeFixes;

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ToAngleCodeFixProvider)), Shared]
    public class ToAngleCodeFixProvider : ToUnitCodeFixProvider
    {
        public ToAngleCodeFixProvider()
            : base("Angle", "FromDegrees")
        {
        }
    }
}
