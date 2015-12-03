namespace Gu.Units.Tests.Internals.Parsing
{
    using System.Globalization;

    public class ErrorData<T> : SuccessData<T>, IErrorData
    {
        public ErrorData(string text,
            int start,
            T expected,
            int expectedEnd,
            string expectedMessage)
            : base(text, start, expected, expectedEnd)
        {
            ExpectedMessage = expectedMessage;
        }

        public ErrorData(string text,
            CultureInfo cultureInfo,
            int start,
            T expected,
            int expectedEnd,
            string expectedMessage)
            : base(text, cultureInfo, start, expected, expectedEnd)
        {
            ExpectedMessage = expectedMessage;
        }

        object IErrorData.Expected => Expected;

        public string ExpectedMessage { get; }
    }
}