namespace Gu.Units.Generator
{
    using System;
    using System.CodeDom.Compiler;

    public static class StringExt
    {
        private static readonly CodeDomProvider CodeDomProvider = CodeDomProvider.CreateProvider("C#");

        public static string ToParameterName(this string text)
        {
            var parameter = Char.ToLower(text[0]) + text.Substring(1);
            if (CodeDomProvider.IsValidIdentifier(parameter))
            {
                return parameter;
            }

            return "@" + parameter;
        }
    }
}
