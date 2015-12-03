namespace Gu.Units.Tests.Internals.Parsing
{
    using System.Collections.Generic;
    using NUnit.Framework;

    public class DoubleFormatReaderTests
    {
        [TestCase(null, 0, null, 0)]
        [TestCase("", 0, null, 0)]
        [TestCase("E", 0, "E", 1)]
        [TestCase("e", 0, "e", 1)]
        [TestCase("E5", 0, "E5", 2)]
        [TestCase("E20", 0, "E20", 3)] // double
        [TestCase("e5", 0, "e5", 2)]
        [TestCase("F", 0, "F", 1)]
        [TestCase("f", 0, "f", 1)]
        [TestCase("F5", 0, "F5", 2)]
        [TestCase("f5", 0, "f5", 2)]
        [TestCase("G", 0, "G", 1)]
        [TestCase("g", 0, "g", 1)]
        [TestCase("G5", 0, "G5", 2)]
        [TestCase("g5", 0, "g5", 2)]
        [TestCase("N", 0, "N", 1)]
        [TestCase("n", 0, "n", 1)]
        [TestCase("N5", 0, "N5", 2)]
        [TestCase("n5", 0, "n5", 2)]
        [TestCase("R", 0, "R", 1)]
        [TestCase("r", 0, "r", 1)]
        [TestCase("0", 0, "0", 1)]
        [TestCase("0.00", 0, "0.00", 4)]
        [TestCase("#", 0, "#", 1)]
        [TestCase("#.#", 0, "#.#", 3)]
        [TestCase("#.0#", 0, "#.0#", 4)]
        [TestCase("#0.00#", 0, "#0.00#", 6)]
        public void TryRead(string text, int pos, string expected, int expectedPos)
        {
            PaddedFormat actual = DoubleFormatCache.GetOrCreate(text, ref pos);
            Assert.AreEqual(expected, actual.Format);
            Assert.AreEqual(expectedPos, pos);
        }

        [TestCase("J", 0, null)]
        [TestCase("J5", 0, null)]
        //[TestCase("E100", 0, "E101")]
        //[TestCase("E101", 0, "E111")]
        //[TestCase("E102", 0, "E112")]
        //[TestCase("E-1", 0, "E-1")]
        [TestCase("abc", 0, "abc")]
        public void TryReadError(string text, int pos, string expectedFormatted)
        {
            PaddedFormat actual = DoubleFormatCache.GetOrCreate(text, ref pos);
            Assert.AreEqual(text, actual.Format);
            Assert.AreEqual(0, pos);
            string formatted = null;
            try
            {
                formatted = 1.2.ToString(text);
            }
            catch
            {
            }

            Assert.AreEqual(expectedFormatted, formatted);
        }

        private static readonly IReadOnlyList<SuccessData<PaddedFormat>> HappyPaths = new[]
        {
            SuccessData.Create("e", 0, new PaddedFormat(null, "e", null), 1),
        };
    }
}