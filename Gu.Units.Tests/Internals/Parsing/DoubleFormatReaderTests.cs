namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Globalization;

    using NUnit.Framework;

    public static class DoubleFormatReaderTests
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
        public static void TryRead(string text, int pos, string expected, int expectedPos)
        {
            var actual = DoubleFormatCache.GetOrCreate(text, ref pos);
            Assert.AreEqual(expected, actual.Format);
            Assert.AreEqual(expectedPos, pos);
        }

        [TestCase("J", 0, null)]
        [TestCase("J5", 0, null)]
        [TestCase("abc", 0, "abc")]
        public static void TryReadError(string text, int pos, string expectedFormatted)
        {
            var actual = DoubleFormatCache.GetOrCreate(text, ref pos);
            Assert.AreEqual(text, actual.Format);
            Assert.AreEqual(0, pos);
            if (expectedFormatted is null)
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                Assert.Throws<FormatException>(() => 1.2.ToString(text, CultureInfo.InvariantCulture));
            }
            else
            {
                Assert.AreEqual(expectedFormatted, 1.2.ToString(text, CultureInfo.InvariantCulture));
            }
        }
    }
}