namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using NUnit.Framework;

    public class IntReaderTests
    {
        private static readonly IReadOnlyList<SuccessCase<int>> HappyPaths = new[]
        {
            SuccessCase.Create("1", 0, 1, 1),
            SuccessCase.Create("01", 0, 1, 2),
            SuccessCase.Create("12", 0, 12, 2),
            SuccessCase.Create(" 12", 1, 12, 3),
            SuccessCase.Create(" 12 ", 1, 12, 3),
            SuccessCase.Create("-1", 0, -1, 2),
            SuccessCase.Create("-12", 0, -12, 3),
            SuccessCase.Create("12345", 0, 12345, 5),
            SuccessCase.Create("67890", 0, 67890, 5),
            SuccessCase.Create(int.MaxValue.ToString(CultureInfo.InvariantCulture), 0, int.MaxValue, int.MaxValue.ToString(CultureInfo.InvariantCulture).Length),
            SuccessCase.Create(" " + int.MaxValue, 1, int.MaxValue, int.MaxValue.ToString(CultureInfo.InvariantCulture).Length + 1),
            SuccessCase.Create(" " + int.MaxValue + " ", 1, int.MaxValue, int.MaxValue.ToString(CultureInfo.InvariantCulture).Length + 1),
            SuccessCase.Create(" " + int.MaxValue + "9", 1, int.MaxValue, int.MaxValue.ToString(CultureInfo.InvariantCulture).Length + 1),
            SuccessCase.Create(int.MinValue.ToString(CultureInfo.InvariantCulture), 0, int.MinValue, int.MinValue.ToString(CultureInfo.InvariantCulture).Length),
            SuccessCase.Create(" " + int.MinValue, 1, int.MinValue, int.MinValue.ToString(CultureInfo.InvariantCulture).Length + 1),
            SuccessCase.Create(" " + int.MinValue + " ", 1, int.MinValue, int.MinValue.ToString(CultureInfo.InvariantCulture).Length + 1),
            SuccessCase.Create(" " + int.MinValue + "9", 1, int.MinValue, int.MinValue.ToString(CultureInfo.InvariantCulture).Length + 1),
        };

        private static readonly IReadOnlyList<SuccessCase<int>> Errors = new[]
        {
            ErrorCase.Create<int>("abc",  0),
            ErrorCase.Create<int>("abc",  1),
            ErrorCase.Create<int>("abc",  2),
            ErrorCase.Create<int>(((long)int.MinValue - 1).ToString(CultureInfo.InvariantCulture),  0), // less than int.min
            ErrorCase.Create<int>(((long)int.MaxValue + 1).ToString(CultureInfo.InvariantCulture),  0), // greater than int.max
        };

        [TestCaseSource(nameof(HappyPaths))]
        public void ParseSuccess(SuccessCase<int> data)
        {
            var pos = data.Start;
            var actual = IntReader.ReadInt32(data.Text, ref pos);
            Assert.AreEqual(actual, data.Expected);
            Assert.AreEqual(pos, data.ExpectedEnd);
        }

        [TestCaseSource(nameof(Errors))]
        public void ParseError(ErrorCase<int> @case)
        {
            var pos = @case.Start;
            Assert.Throws<FormatException>(() => IntReader.ReadInt32(@case.Text, ref pos));
            Assert.AreEqual(pos, @case.ExpectedEnd);
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void TryParseSuccess(SuccessCase<int> data)
        {
            var pos = data.Start;
            Assert.AreEqual(true, IntReader.TryReadInt32(data.Text, ref pos, out var actual));
            Assert.AreEqual(data.Expected, actual);
            Assert.AreEqual(data.ExpectedEnd, pos);
        }

        [TestCaseSource(nameof(Errors))]
        public void TryParseError(ErrorCase<int> @case)
        {
            var pos = @case.Start;
            Assert.AreEqual(false, IntReader.TryReadInt32(@case.Text, ref pos, out var actual));
            Assert.AreEqual(@case.Expected, actual);
            Assert.AreEqual(@case.ExpectedEnd, pos);
        }
    }
}
