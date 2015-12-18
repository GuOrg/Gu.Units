namespace Gu.Units.Wpf.Tests
{
    using System;
    using System.Globalization;
    using NUnit.Framework;

    public partial class LengthConverterTests
    {
        [RequiresSTA]
        public class Convert
        {
            [TestCase(typeof(string), 1.2)]
            [TestCase(typeof(object), 1.2)]
            [TestCase(typeof(double), 1.2)]
            public void WithExplicitUnit(Type targetType, object expected)
            {
                var converter = new LengthConverter
                {
                    Unit = LengthUnit.Centimetres,
                };

                var length = Length.FromMillimetres(12);
                var actual = converter.Convert(length, targetType, null, null);
                Assert.AreEqual(expected, actual);
            }

            private const string Superscripts = "⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";
            private const char MultiplyDot = '⋅';

            [TestCase(typeof(string), SymbolFormat.SignedHatPowers, "1.2\u00A0m*s^-1")]
            [TestCase(typeof(object), SymbolFormat.FractionHatPowers, "1.2\u00A0m/s")]
            [TestCase(typeof(object), SymbolFormat.SignedSuperScript, "1.2\u00A0m⋅s⁻¹")]
            [TestCase(typeof(object), SymbolFormat.FractionSuperScript, "1.2\u00A0m/s")]
            public void WithUnitAndSymbolFormat(Type targetType, SymbolFormat format, object expected)
            {
                var converter = new SpeedConverter
                {
                    Unit = SpeedUnit.MetresPerSecond,
                    UnitInput = UnitInput.SymbolRequired,
                    SymbolFormat = format
                };

                var length = Speed.FromMetresPerSecond(1.2);
                var actual = converter.Convert(length, targetType, null, CultureInfo.InvariantCulture);
                Assert.AreEqual(expected, actual);
            }


            [TestCase(typeof(string), UnitInput.ScalarOnly, 1.2)]
            [TestCase(typeof(string), UnitInput.SymbolAllowed, 1.2)]
            [TestCase(typeof(string), UnitInput.SymbolRequired, "1.2\u00A0m/s")]
            public void WithUnitAndUnitInput(Type targetType, UnitInput inputOptions, object expected)
            {
                var converter = new SpeedConverter
                {
                    Unit = SpeedUnit.MetresPerSecond,
                    UnitInput = inputOptions
                };

                var length = Speed.FromMetresPerSecond(1.2);
                var actual = converter.Convert(length, targetType, null, CultureInfo.InvariantCulture);
                Assert.AreEqual(expected, actual);
            }

            [TestCase(typeof(string), "F1 m", "en-us", "1.2 m")]
            [TestCase(typeof(object), "F1 m", "en-us", "1.2 m")]
            [TestCase(typeof(double), "F1 m", "en-us", 1.234)]
            public void WithStringFormat(Type targetType, string stringFormat, string culture, object expected)
            {
                var converter = new LengthConverter
                {
                    StringFormat = stringFormat
                };

                var length = Length.FromMillimetres(1234);
                var actual = converter.Convert(length, targetType, null, CultureInfo.GetCultureInfo(culture));
                Assert.AreEqual(expected, actual);
            }

            [TestCase(typeof(string), "F1 m")]
            [TestCase(typeof(object), "F1 m")]
            public void WithBindingStringFormat(Type targetType, string stringFormat)
            {
                var converter = new LengthConverter();
                var providerMock = new ServiceProviderMock
                {
                    BindingStringFormat = stringFormat
                };

                converter.ProvideValue(providerMock.Object);
                var length = Length.FromMillimetres(1234);
                var actual = converter.Convert(length, targetType, null, null);
                Assert.AreEqual(length, actual);
            }

            [TestCase(typeof(string), 1.234)]
            [TestCase(typeof(double), 1.234)]
            public void WithBindingStringFormatNull(Type targetType, object expected)
            {
                var converter = new LengthConverter { Unit = LengthUnit.Metres };
                var providerMock = new ServiceProviderMock
                {
                    BindingStringFormat = null
                };

                converter.ProvideValue(providerMock.Object);
                var length = Length.FromMillimetres(1234);
                var actual = converter.Convert(length, targetType, null, CultureInfo.GetCultureInfo("sv-SE"));
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void WhenProvideValueTargetThrows()
            {
                var converter = new LengthConverter { Unit = LengthUnit.Metres };
                var providerMock = new ServiceProviderMock();
                providerMock.ProvideValueTargetMock.Setup(x => x.TargetObject).Throws<NullReferenceException>();

                converter.ProvideValue(providerMock.Object);
                var length = Length.FromMillimetres(1234);
                var actual = converter.Convert(length, typeof(string), null, null);
                Assert.AreEqual(1.234, actual);
            }

            [Test]
            public void WithBindingStringFormatAndExplicitStringFormat()
            {
                var converter = new LengthConverter
                {
                    StringFormat = "F1 mm"
                };

                var providerMock = new ServiceProviderMock
                {
                    BindingStringFormat = "F2 cm"
                };

                converter.ProvideValue(providerMock.Object);
                var length = Length.FromMillimetres(1234);
                Gu.Units.Wpf.Is.DesignMode = true;
                var ex = Assert.Throws<InvalidOperationException>(() => converter.Convert(length, typeof(string), null, null));
                var expected = "Both Binding.StringFormat and StringFormat are set.";
                Assert.AreEqual(expected, ex.Message);

                Gu.Units.Wpf.Is.DesignMode = false;
                var convert = converter.Convert(length, typeof(string), null, null);
                Assert.AreEqual(expected, convert);
            }

            [TestCase(typeof(string), "")]
            [TestCase(typeof(object), null)]
            [TestCase(typeof(double), null)]
            public void Null(Type targetType, object expected)
            {
                var converter = new LengthConverter
                {
                    Unit = LengthUnit.Centimetres,
                    UnitInput = UnitInput.ScalarOnly
                };

                var actual = converter.Convert(null, targetType, null, null);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
