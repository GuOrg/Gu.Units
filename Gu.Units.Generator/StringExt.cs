﻿namespace Gu.Units.Generator
{
    using System.CodeDom.Compiler;
    using System.Globalization;

    public static class StringExt
    {
        private static readonly CodeDomProvider CodeDomProvider = CodeDomProvider.CreateProvider("C#");

        public static string FirstCharLower(this string text)
        {
            return char.ToLower(text[0], CultureInfo.InvariantCulture) + text.Substring(1);
        }

        public static string ToParameterName(this string text)
        {
            var parameter = text.FirstCharLower();
            if (CodeDomProvider.IsValidIdentifier(parameter))
            {
                return parameter;
            }

            return "@" + parameter;
        }
    }
}
