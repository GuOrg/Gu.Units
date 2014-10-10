namespace Gu.Units.Tests
{
    using NUnit.Framework;

    public class UnitParserTests
    {
        [Test]
        public void Parse()
        {
            var s = "1m";
            var length = UnitParser.Parse<ILengthUnit, Length>(s, Length.From);
            Assert.AreEqual(1, length.Meters);
        }
    }
}
