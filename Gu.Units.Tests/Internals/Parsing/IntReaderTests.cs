namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Collections.Generic;
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
                                                                                     SuccessCase.Create(int.MaxValue.ToString(), 0, int.MaxValue, int.MaxValue.ToString().Length),
                                                                                     SuccessCase.Create(" " + int.MaxValue, 1, int.MaxValue, int.MaxValue.ToString().Length + 1),
                                                                                     SuccessCase.Create(" " + int.MaxValue + " ", 1, int.MaxValue, int.MaxValue.ToString().Length + 1),
                                                                                     SuccessCase.Create(" " + int.MaxValue + "9", 1, int.MaxValue, int.MaxValue.ToString().Length + 1),
                                                                                     SuccessCase.Create(int.MinValue.ToString(), 0, int.MinValue, int.MinValue.ToString().Length),
                                                                                     SuccessCase.Create(" " + int.MinValue, 1, int.MinValue, int.MinValue.ToString().Length + 1),
                                                                                     SuccessCase.Create(" " + int.MinValue + " ", 1, int.MinValue, int.MinValue.ToString().Length + 1),
                                                                                     SuccessCase.Create(" " + int.MinValue + "9", 1, int.MinValue, int.MinValue.ToString().Length + 1),
                                                                                 };

        private static readonly IReadOnlyList<SuccessCase<int>> Errors = new[]
                                                                             {
                                                                                 ErrorCase.Create<int>("abc",  0),
                                                                                 ErrorCase.Create<int>("abc",  1),
                                                                                 ErrorCase.Create<int>("abc",  2),
                                                                                 ErrorCase.Create<int>(((long)int.MinValue - 1).ToString(),  0), // less than int.min
                                                                                 ErrorCase.Create<int>(((long)int.MaxValue + 1).ToString(),  0), // greater than int.max
                                                                             };

        [TestCaseSource(nameof(HappyPaths))]
        public void ParseSuccess(SuccessCase<int> data)
        {
            int pos = data.Start;
            var actual = IntReader.ReadInt32(data.Text, ref pos);
            Assert.AreEqual(actual, data.Expected);
            Assert.AreEqual(pos, data.ExpectedEnd);
        }

        [TestCaseSource(nameof(Errors))]
        public void ParseError(ErrorCase<int> @case)
        {
            int pos = @case.Start;
            Assert.Throws<FormatException>(() => IntReader.ReadInt32(@case.Text, ref pos));
            Assert.AreEqual(pos, @case.ExpectedEnd);
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void TryParseSuccess(SuccessCase<int> data)
        {
            int pos = data.Start;
            int actual;
            var success = IntReader.TryReadInt32(data.Text, ref pos, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(data.Expected, actual);
            Assert.AreEqual(data.ExpectedEnd, pos);
        }

        [TestCaseSource(nameof(Errors))]
        public void TryParseError(ErrorCase<int> @case)
        {
            int pos = @case.Start;
            int actual;
            var success = IntReader.TryReadInt32(@case.Text, ref pos, out actual);
            Assert.AreEqual(false, success);
            Assert.AreEqual(@case.Expected, actual);
            Assert.AreEqual(@case.ExpectedEnd, pos);
        }
    }
}
