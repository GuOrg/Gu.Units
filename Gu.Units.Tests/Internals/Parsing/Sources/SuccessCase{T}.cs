namespace Gu.Units.Tests.Internals.Parsing
{
    using System.Globalization;

    public class SuccessCase<T> : TestCase<T>, ISuccessData
    {
        public SuccessCase(
            string text,
            int start,
            T expected,
            int expectedEnd)
            : base(text, start, expected, expectedEnd)
        {
        }

        public SuccessCase(
            string text,
            CultureInfo cultureInfo,
            int start,
            T expected,
            int expectedEnd)
            : base(text, cultureInfo, start, expected, expectedEnd)
        {
        }

        object ISuccessData.Expected => this.Expected;
    }
}
