namespace Gu.Units.Wpf.Tests
{
    using System;
    using System.Globalization;
    using NUnit.Framework;

    public partial class LengthConverterTests
    {
        [RequiresSTA]
        public class Setup
        {
            [TestCase("F1 mm")]
            [TestCase("{F1 mm}")]
            [TestCase("{0:F1 mm}")]
            public void SettingStringFormatHappyPath(string stringFormat)
            {
                var converter = new LengthConverter
                {
                    StringFormat = stringFormat
                };

                var convert = converter.Convert(Length.FromMillimetres(12.34), typeof(string), null, CultureInfo.InvariantCulture);
                Assert.AreEqual("12.3 mm", convert);
                Assert.AreEqual(LengthUnit.Millimetres, converter.Unit);
                Assert.AreEqual(UnitInput.SymbolRequired, converter.UnitInput);
            }

            [TestCase("unknown format")]
            public void SettingStringFormatFailsIfBadFormat(string stringFormat)
            {
                var converter = new LengthConverter { Unit = LengthUnit.Centimetres };
                Wpf.Is.DesignMode = true;
                var ex = Assert.Throws<ArgumentException>(() => converter.StringFormat = stringFormat);
                var expected = $"Error parsing: '{stringFormat}'";
                Assert.AreEqual(expected, ex.Message);

                Wpf.Is.DesignMode = false;

                var convert = converter.Convert(Length.Zero, typeof(string), null, null);
                Assert.AreEqual(stringFormat, convert);
            }

            [TestCase("F1 cm")]
            [TestCase("{F1 cm}")]
            [TestCase("{0:F1 cm}")]
            public void BindingStringFormatHappyPath(string stringFormat)
            {
                var converter = new LengthConverter();
                var providerMock = new ServiceProviderMock
                {
                    BindingStringFormat = stringFormat
                };

                converter.ProvideValue(providerMock.Object);
                var length = Length.FromMillimetres(12.3);
                var convert = converter.Convert(length, typeof(string), null, CultureInfo.InvariantCulture);
                Assert.AreEqual(length, convert);
                Assert.AreEqual(LengthUnit.Centimetres, converter.Unit);
                Assert.AreEqual(UnitInput.SymbolRequired, converter.UnitInput);
            }

            [Test]
            public void SettingStringFormatWithUnitWhenUnitIsSet()
            {
                var converter = new LengthConverter
                {
                    Unit = LengthUnit.Centimetres
                };

                Gu.Units.Wpf.Is.DesignMode = true;
                var ex = Assert.Throws<InvalidOperationException>(() => converter.StringFormat = "F1 mm");
                var expected = "Unit is set to 'cm' but StringFormat is 'F1 mm'";
                Assert.AreEqual(expected, ex.Message);

                Gu.Units.Wpf.Is.DesignMode = false;
                var actual = converter.Convert(Length.FromMetres(1.2), typeof(string), null, CultureInfo.InvariantCulture);
                Assert.AreEqual(expected, actual);
            }

            [TestCase(true)]
            [TestCase(false)]
            public void ThrowsInDesignModeIfMissingUnit(bool isDesignMode)
            {
                Gu.Units.Wpf.Is.DesignMode = isDesignMode;
                var converter = new LengthConverter
                {
                    UnitInput = UnitInput.ScalarOnly
                };

                var length = Length.FromMetres(1.2);
                Assert.AreEqual(null, converter.Unit);
                if (isDesignMode)
                {
                    Assert.Throws<ArgumentException>(() => converter.Convert(length, typeof(string), null, null));
                }
                else
                {
                    var actual = converter.Convert(length, typeof(string), null, null);
                    Assert.AreEqual("No unit set", actual);
                }
            }
        }
    }
}
