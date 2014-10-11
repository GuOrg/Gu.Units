namespace Gu.Units.Tests
{
    using NUnit.Framework;

    public class UnitParserTests
    {
        [TestCase("1m", 1)]
        [TestCase("-1m", -1)]
        [TestCase("1.2m", 1.2)]
        [TestCase("1,2m", 1.2)]
        [TestCase("-1m", -1)]
        [TestCase("1e3m", 1e3)]
        [TestCase("-1e3m", -1e3)]
        [TestCase("1e+3m", 1e+3)]
        [TestCase("1E+3m", 1E+3)]
        [TestCase("-1e-3m", -1e-3)]
        [TestCase(" 1m", 1)]
        [TestCase("1m ", 1)]
        [TestCase("1 m", 1)]
        [TestCase(" 1 m", 1)]
        [TestCase("1 m ", 1)]
        [TestCase(" 1 m ", 1)]
        [TestCase(" 1   m   ", 1)]
        [TestCase("1m ", 1)]
        [TestCase("1mm", 1e-3)]
        [TestCase("1cm", 1e-2)]
        public void ParseLength(string s, double expected)
        {
            var length = UnitParser.Parse<ILengthUnit, Length>(s, Length.From);
            Assert.AreEqual(expected, length.Meters);
        }

        [TestCase("1m", 1)]
        public void ParseMeters(string s, double expected)
        {
            var length = UnitParser.Parse<ILengthUnit, Length>(s, Length.From);
            Assert.AreEqual(expected, length.Meters);
        }

        [TestCase("1cm", 1)]
        public void ParseCentimeters(string s, double expected)
        {
            var length = UnitParser.Parse<ILengthUnit, Length>(s, Length.From);
            Assert.AreEqual(expected, length.Centimeters);
        }

        [TestCase("1mm", 1)]
        public void ParseMillimeters(string s, double expected)
        {
            var length = UnitParser.Parse<ILengthUnit, Length>(s, Length.From);
            Assert.AreEqual(expected, length.Millimeters);
        }

        [TestCase("1h", 1)]
        public void ParseHours(string s, double expected)
        {
            var time = UnitParser.Parse<ITimeUnit, Time>(s, Time.From);
            Assert.AreEqual(expected, time.Hours);
        }

        [TestCase("1s", 1)]
        public void ParseSeconds(string s, double expected)
        {
            var time = UnitParser.Parse<ITimeUnit, Time>(s, Time.From);
            Assert.AreEqual(expected, time.Seconds);
        }

        [TestCase("1ms", 1)]
        public void ParseMilliseconds(string s, double expected)
        {
            var time = UnitParser.Parse<ITimeUnit, Time>(s, Time.From);
            Assert.AreEqual(expected, time.MilliSeconds);
        }

        [TestCase("1kN", 1)]
        public void ParseKilonewtons(string s, double expected)
        {
            var force = UnitParser.Parse<IForceUnit, Force>(s, Force.From);
            Assert.AreEqual(expected, force.KiloNewtons);
        }

        [TestCase("1N", 1)]
        public void ParseNewtons(string s, double expected)
        {
            var force = UnitParser.Parse<IForceUnit, Force>(s, Force.From);
            Assert.AreEqual(expected, force.Newtons);
        }
    }
}
