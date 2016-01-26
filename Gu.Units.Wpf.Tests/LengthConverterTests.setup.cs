namespace Gu.Units.Wpf.Tests
{
    using System;
    using System.Globalization;
    using NUnit.Framework;

    public partial class ConverterTests
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

            [TestCase(null, 1.234, null, UnitInput.ScalarOnly)]
            [TestCase(UnitInput.SymbolRequired, "1.2340\u00A0cm", UnitInput.SymbolRequired)]
            public void ValueFormatAndUnit(UnitInput? unitInput, object expectedValue, UnitInput expectedUnitInput)
            {
                Wpf.Is.DesignMode = true;
                var converter = new LengthConverter
                {
                    ValueFormat = "F4",
                    Unit = LengthUnit.Centimetres,
                    UnitInput = unitInput
                };

                Assert.AreEqual(expectedValue, converter.Convert(Length.FromMillimetres(12.34), typeof(string), null, CultureInfo.InvariantCulture));
                Assert.AreEqual(expectedUnitInput, converter.UnitInput);
                Assert.AreEqual(LengthUnit.Centimetres, converter.Unit);
            }

            [Test]
            public void ValueFormatUnitAndUnitFormat()
            {
                Assert.Fail();
                //var converter = new SpeedConverter
                //{
                //    ValueFormat = "F4",
                //    Unit = LengthUnit.Centimetres,
                //    SymbolFormat = SymbolFormat.FractionHatPowers
                //};

                //var convert = converter.Convert(Length.FromMillimetres(12.34), typeof(string), null, CultureInfo.InvariantCulture);
                //Assert.AreEqual("12.3 mm", convert);
                //Assert.AreEqual(LengthUnit.Millimetres, converter.Unit);
                //Assert.AreEqual(UnitInput.ScalarOnly, converter.UnitInput);
            }

            [TestCase("unknown format")]
            public void SettingStringFormatFailsIfBadFormat(string badFormat)
            {
                var converter = new LengthConverter { Unit = LengthUnit.Centimetres };
                Wpf.Is.DesignMode = true;
                var ex = Assert.Throws<FormatException>(() => converter.StringFormat = badFormat);
                var expected = $"Error parsing: '{badFormat}' for Gu.Units.LengthUnit";
                Assert.AreEqual(expected, ex.Message);

                Wpf.Is.DesignMode = false;
                converter.StringFormat = badFormat;
                var convert = converter.Convert(Length.Zero, typeof(string), null, null);
                Assert.AreEqual(expected, convert);
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

            [TestCase(true)]
            [TestCase(false)]
            public void SettingStringFormatWithUnitWhenUnitIsSet(bool designMode)
            {
                var converter = new LengthConverter
                {
                    Unit = LengthUnit.Centimetres
                };

                var expected = "Unit is set to 'cm' but StringFormat is 'F1 mm'";

                if (designMode)
                {
                    Gu.Units.Wpf.Is.DesignMode = true;
                    var ex = Assert.Throws<InvalidOperationException>(() => converter.StringFormat = "F1 mm");
                    Assert.AreEqual(expected, ex.Message);
                }
                else
                {
                    Gu.Units.Wpf.Is.DesignMode = false;
                    converter.StringFormat = "F1 mm";
                    var actual = converter.Convert(Length.FromMetres(1.2), typeof(string), null, CultureInfo.InvariantCulture);
                    Assert.AreEqual(expected, actual);
                }
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
                var expected = "Unit cannot be null.\r\n" +
                               "Must be specified Explicitly or in StringFormat or in Binding.StringFormat.";
                if (isDesignMode)
                {
                    var exception = Assert.Throws<InvalidOperationException>(() => converter.Convert(length, typeof(string), null, null));
                    Assert.AreEqual(expected, exception.Message);
                }
                else
                {
                    var actual = converter.Convert(length, typeof(string), null, null);
                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}
