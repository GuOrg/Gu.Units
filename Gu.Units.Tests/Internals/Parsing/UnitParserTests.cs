namespace Gu.Units.Tests.Internals.Parsing
{
    using NUnit.Framework;

    public class UnitParserTests
    {
        private const string Superscripts = "⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹"; // keeping this here for copy pasting

        [TestCase("m")]
        public void ParseMetres(string s)
        {
            var actual = LengthUnit.Parse(s);
            var expected = LengthUnit.Metres;
            Assert.AreEqual(expected, actual);

            actual = UnitParser<LengthUnit>.Parse(s);
            Assert.AreEqual(expected, actual);

            var success = LengthUnit.TryParse(s, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(expected, actual);

            success = UnitParser<LengthUnit>.TryParse(s, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("m^2")]
        [TestCase("m²")]
        [TestCase("m⁺²")]
        public void ParseSquareMetres(string s)
        {
            var actual = AreaUnit.Parse(s);
            var expected = AreaUnit.SquareMetres;
            Assert.AreEqual(expected, actual);

            actual = UnitParser<AreaUnit>.Parse(s);
            Assert.AreEqual(expected, actual);

            var success = AreaUnit.TryParse(s, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(expected, actual);

            success = UnitParser<AreaUnit>.TryParse(s, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("mm^2")]
        [TestCase("mm²")]
        [TestCase("mm⁺²")]
        public void ParseSquareMillimetres(string s)
        {
            var actual = AreaUnit.Parse(s);
            var squareMillimetres = AreaUnit.SquareMillimetres;
            Assert.AreEqual(squareMillimetres, actual);

            actual = UnitParser<AreaUnit>.Parse(s);
            Assert.AreEqual(squareMillimetres, actual);

            var success = AreaUnit.TryParse(s, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(squareMillimetres, actual);

            success = UnitParser<AreaUnit>.TryParse(s, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(squareMillimetres, actual);
        }
    }
}
