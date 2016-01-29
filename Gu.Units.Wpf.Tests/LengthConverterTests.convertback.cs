namespace Gu.Units.Wpf.Tests
{
    using System.Globalization;
    using NUnit.Framework;

    [TestFixture]
    public partial class ConverterTests
    {
        public class ConvertBack
        {
            [TestCase("1.2")]
            [TestCase(1.2)]
            public void WithExplicitUnitScalarOnly(object value)
            {
                var converter = new LengthConverter
                {
                    Unit = LengthUnit.Centimetres,
                    UnitInput = UnitInput.ScalarOnly
                };

                var actual = converter.ConvertBack(value, typeof(Length), null, CultureInfo.InvariantCulture);
                var expected = Length.FromCentimetres(1.2);
                Assert.AreEqual(expected, actual);
            }

            [TestCase("1.2", UnitInput.ScalarOnly, true,"1.2 cm")]
            [TestCase("1.2 mm", UnitInput.ScalarOnly, false, "#1.2 mm#")]
            [TestCase("1.2", UnitInput.SymbolAllowed, true, "1.2 cm")]
            [TestCase("12 mm", UnitInput.SymbolAllowed, true, "1.2 cm")]
            [TestCase("1.2", UnitInput.SymbolRequired, false, "1.2")]
            [TestCase("12 mm", UnitInput.SymbolRequired, true, "1.2 cm")]
            public void WithSymbolSettings(string value, UnitInput unitInput, bool expectSuccess, string expected)
            {
                var converter = new LengthConverter
                {
                    Unit = LengthUnit.Centimetres,
                    UnitInput = unitInput
                };

                var actual = converter.ConvertBack(value, typeof(Length), null, CultureInfo.InvariantCulture);
                if (expectSuccess)
                {
                    var expectedValue = Length.Parse(expected, CultureInfo.InvariantCulture);
                    Assert.AreEqual(expectedValue, actual);
                }
                else
                {
                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}
