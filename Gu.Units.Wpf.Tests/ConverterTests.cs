﻿namespace Gu.Units.Wpf.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using NUnit.Framework;

    [Apartment(ApartmentState.STA)]
    public static class ConverterTests
    {
        [TestCase("F1 mm")]
        [TestCase("{F1 mm}")]
        [TestCase("{0:F1 mm}")]
        public static void SettingStringFormatHappyPath(string stringFormat)
        {
            var converter = new LengthConverter
            {
                StringFormat = stringFormat,
            };

            var convert = converter.Convert(Length.FromMillimetres(12.34), typeof(string), null, CultureInfo.InvariantCulture);
            Assert.AreEqual("12.3 mm", convert);
            Assert.AreEqual(LengthUnit.Millimetres, converter.Unit);
            Assert.AreEqual(UnitInput.SymbolRequired, converter.UnitInput);
        }

        [TestCase(null, "1.2340", null)]
        [TestCase(UnitInput.SymbolRequired, "1.2340\u00A0cm", UnitInput.SymbolRequired)]
        public static void ValueFormatAndUnit(UnitInput? unitInput, object expectedValue, UnitInput? expectedUnitInput)
        {
            Wpf.Is.DesignMode = true;
            var converter = new LengthConverter
            {
                ValueFormat = "F4",
                Unit = LengthUnit.Centimetres,
                UnitInput = unitInput,
            };

            Assert.AreEqual(expectedValue, converter.Convert(Length.FromMillimetres(12.34), typeof(string), null, CultureInfo.InvariantCulture));
            Assert.AreEqual(expectedUnitInput, converter.UnitInput);
            Assert.AreEqual(LengthUnit.Centimetres, converter.Unit);
        }

        [Test]
        public static void ValueFormatUnitAndUnitFormat()
        {
            var converter = new SpeedConverter
            {
                ValueFormat = "F2",
                Unit = SpeedUnit.MillimetresPerSecond,
                SymbolFormat = SymbolFormat.SignedSuperScript,
            };

            var convert = converter.Convert(Speed.FromMetresPerMinute(12.34), typeof(string), null, CultureInfo.InvariantCulture);
            Assert.AreEqual("205.67\u00A0mm⋅s⁻¹", convert);
            Assert.AreEqual(SpeedUnit.MillimetresPerSecond, converter.Unit);
            Assert.AreEqual(UnitInput.SymbolRequired, converter.UnitInput);
        }

        [TestCase("unknown format")]
        public static void SettingStringFormatFailsIfBadFormat(string badFormat)
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
        public static void BindingStringFormatHappyPath(string stringFormat)
        {
            var converter = new LengthConverter();
            var providerMock = new ServiceProviderMock
            {
                BindingStringFormat = stringFormat,
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
        public static void SettingStringFormatWithUnitWhenUnitIsSet(bool designMode)
        {
            var converter = new LengthConverter
            {
                Unit = LengthUnit.Centimetres,
            };

            var expected = "Unit is set to 'cm' but StringFormat is 'F1 mm'";

            if (designMode)
            {
                Wpf.Is.DesignMode = true;
                var ex = Assert.Throws<InvalidOperationException>(() => converter.StringFormat = "F1 mm");
                Assert.AreEqual(expected, ex.Message);
            }
            else
            {
                Wpf.Is.DesignMode = false;
                converter.StringFormat = "F1 mm";
                var actual = converter.Convert(Length.FromMetres(1.2), typeof(string), null, CultureInfo.InvariantCulture);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestCase(true)]
        [TestCase(false)]
        public static void ThrowsInDesignModeIfMissingUnit(bool isDesignMode)
        {
            Wpf.Is.DesignMode = isDesignMode;
            var converter = new LengthConverter
            {
                UnitInput = UnitInput.ScalarOnly,
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
