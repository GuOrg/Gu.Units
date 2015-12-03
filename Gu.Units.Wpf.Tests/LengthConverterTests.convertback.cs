namespace Gu.Units.Wpf.Tests
{
    using System.Globalization;
    using NUnit.Framework;

    [TestFixture]
    public partial class LengthConverterTests
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

            [TestCase("1.2", UnitInput.ScalarOnly, true)]
            [TestCase("1.2 mm", UnitInput.ScalarOnly, false)]
            [TestCase("1.2", UnitInput.SymbolAllowed, true)]
            [TestCase("12 mm", UnitInput.SymbolAllowed, true)]
            [TestCase("1.2", UnitInput.SymbolRequired, false)]
            [TestCase("12 mm", UnitInput.SymbolRequired, true)]
            public void WithSymbolSettings(string value, UnitInput unitInput, bool expectSuccess)
            {
                var converter = new LengthConverter
                {
                    Unit = LengthUnit.Centimetres,
                    UnitInput = unitInput
                };

                var actual = converter.ConvertBack(value, typeof(Length), null, CultureInfo.InvariantCulture);
                if (expectSuccess)
                {
                    var expected = Length.FromCentimetres(1.2);
                    Assert.AreEqual(expected, actual);
                }
                else
                {
                    Assert.AreEqual(value, actual);
                }
            }
        }
    }
}
