namespace Gu.Units.Tests.Internals.Parsing.Sources
{
    using System;
    using System.Globalization;

    public static class ParseExt
    {
        public static object Parse(this ISuccessData data, string text)
        {
            var parseMethod = data.Type.GetMethod(
                nameof(Length.Parse),
                new[] { typeof(string) });
            return parseMethod.Invoke(null, new object[] { text });
        }

        public static object Parse(this ISuccessData data, string text,
            CultureInfo cultureInfo)
        {
            var name = nameof(Length.Parse);
            var parseMethod = data.Type.GetMethod(
                name,
                new[] { typeof(string), typeof(IFormatProvider) });
            return parseMethod.Invoke(null, new object[] { text, cultureInfo });
        }

        public static bool TryParse(this ISuccessData data, string text,
            out object actual)
        {
            var tryParseMethod = data.Type.GetMethod(
                nameof(Length.TryParse),
                new[] { typeof(string), data.Type.MakeByRefType() });
            actual = null;
            var parameters = new[] { text, actual };
            var success = (bool)tryParseMethod.Invoke(null, parameters);
            actual = parameters[1];
            return success;
        }

        public static bool TryParse(this ISuccessData data, string text,
            CultureInfo cultureInfo,
            out object actual)
        {
            var parseMethod = data.Type.GetMethod(
                nameof(Length.TryParse),
                new[] { typeof(string), typeof(IFormatProvider), data.Type.MakeByRefType() });
            actual = null;
            var parameters = new object[] { text, cultureInfo, actual };
            var success = (bool)parseMethod.Invoke(null, parameters);
            actual = parameters[2];
            return success;
        }

    }
}
