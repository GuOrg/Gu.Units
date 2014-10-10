namespace Gu.Units.Tests
{
    using NUnit.Framework;

    public class UnitParserTests
    {
        [TestCase("1m", 1)]
        [TestCase("-1m", -1)]
        [TestCase("1e3m", 1e3)]
        [TestCase("1e+3m", 1e+3)]
        [TestCase("-1e+3m", -1e+3)]
        [TestCase("1e-3m", 1e-3)]
        [TestCase("-1e-3m", -1e-3)]
        [TestCase(" 1m", 1)]
        [TestCase("1m ", 1)]
        [TestCase("1 m", 1)]
        [TestCase("1 m ", 1)]
        [TestCase("1    m", 1)]
        [TestCase("1m ", 1)]
        public void ParseLength(string s, double expected)
        {
            var length = UnitParser.Parse<ILengthUnit, Length>(s, Length.From);
            Assert.AreEqual(expected, length.Meters);
        }

        [TestCase("1s", 1)]
        public void ParseTime(string s, double expected)
        {
            var time = UnitParser.Parse<ITimeUnit, Time>(s, Time.From);
            Assert.AreEqual(expected, time.Seconds);
        }
    }
}
