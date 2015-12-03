namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class IntReaderTests
    {
        [TestCaseSource(nameof(HappyPaths))]
        public void ParseSuccess(SuccessData<int> data)
        {
            int pos = data.Start;
            var actual = IntReader.ReadInt32(data.Text, ref pos);
            Assert.AreEqual(actual, data.Expected);
            Assert.AreEqual(pos, data.ExpectedEnd);
        }

        [TestCaseSource(nameof(Errors))]
        public void ParseError(ErrorData<int> data)
        {
            int pos = data.Start;
            Assert.Throws<FormatException>(() => IntReader.ReadInt32(data.Text, ref pos));
            Assert.AreEqual(pos, data.ExpectedEnd);
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void TryParseSuccess(SuccessData<int> data)
        {
            int pos = data.Start;
            int actual;
            var success = IntReader.TryReadInt32(data.Text, ref pos, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(data.Expected, actual);
            Assert.AreEqual(data.ExpectedEnd, pos);
        }

        [TestCaseSource(nameof(Errors))]
        public void TryParseError(ErrorData<int> data)
        {
            int pos = data.Start;
            int actual;
            var success = IntReader.TryReadInt32(data.Text, ref pos, out actual);
            Assert.AreEqual(false, success);
            Assert.AreEqual(data.Expected, actual);
            Assert.AreEqual(data.ExpectedEnd, pos);
        }

        private static readonly IReadOnlyList<SuccessData<int>> HappyPaths = new[]
        {
            SuccessData.Create("1", 0, 1, 1),
            SuccessData.Create("01", 0, 1, 2),
            SuccessData.Create("12", 0, 12, 2),
            SuccessData.Create(" 12", 1, 12, 3),
            SuccessData.Create(" 12 ", 1, 12, 3),
            SuccessData.Create("-1", 0, -1, 2),
            SuccessData.Create("-12", 0, -12, 3),
            SuccessData.Create("12345", 0, 12345, 5),
            SuccessData.Create("67890", 0, 67890, 5),
            SuccessData.Create(int.MaxValue.ToString(), 0, int.MaxValue, int.MaxValue.ToString().Length),
            SuccessData.Create(" " + int.MaxValue, 1, int.MaxValue, int.MaxValue.ToString().Length + 1),
            SuccessData.Create(" " + int.MaxValue + " ", 1, int.MaxValue, int.MaxValue.ToString().Length + 1),
            SuccessData.Create(" " + int.MaxValue + "9", 1, int.MaxValue, int.MaxValue.ToString().Length + 1),
            SuccessData.Create(int.MinValue.ToString(), 0, int.MinValue, int.MinValue.ToString().Length),
            SuccessData.Create(" " + int.MinValue, 1, int.MinValue, int.MinValue.ToString().Length + 1),
            SuccessData.Create(" " + int.MinValue + " ", 1, int.MinValue, int.MinValue.ToString().Length + 1),
            SuccessData.Create(" " + int.MinValue + "9", 1, int.MinValue, int.MinValue.ToString().Length + 1),
        };

        private static readonly IReadOnlyList<SuccessData<int>> Errors = new[]
        {
            ErrorData.Create<int>("abc",  0), 
            ErrorData.Create<int>("abc",  1), 
            ErrorData.Create<int>("abc",  2), 
            ErrorData.Create<int>(((long)int.MinValue-1).ToString(),  0), // less than int.min
            ErrorData.Create<int>(((long)int.MaxValue+1).ToString(),  0), // greater than int.max
        };
    }
}
