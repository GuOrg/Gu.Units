namespace Gu.Units.Tests.Internals.Parsing
{
    using System.Globalization;

    public class ErrorCase<T> : SuccessCase<T>, IErrorCase
    {
        public ErrorCase(string text, int start, T expected, int expectedEnd, string expectedMessage)
            : base(text, start, expected, expectedEnd)
        {
            this.ExpectedMessage = expectedMessage;
        }

        public ErrorCase(string text, CultureInfo cultureInfo, int start, T expected, int expectedEnd, string expectedMessage)
            : base(text, cultureInfo, start, expected, expectedEnd)
        {
            this.ExpectedMessage = expectedMessage;
        }

        object IErrorCase.Expected => this.Expected;

        public string ExpectedMessage { get; }
    }
}
