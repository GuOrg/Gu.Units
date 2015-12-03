namespace Gu.Units.Tests.Internals.Parsing
{
    using System.Globalization;
    using NUnit.Framework;

    public class CompositeFormatParserTests
    {
        private const string Superscripts = "⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";
        private const char MultiplyDot = '⋅';

        [TestCase("", "{0}\u00A0m", "1.2\u00A0m")]
        [TestCase(null, "{0}\u00A0m", "1.2\u00A0m")]
        [TestCase("E mm", "{0:E} mm", "1.200000E+003 mm")]
        [TestCase("ecm", "{0:e}cm", "1.200000e+002cm")]
        [TestCase("E5m", "{0:E5}m", "1.20000E+000m")]
        [TestCase("e5 m", "{0:e5} m", "1.20000e+000 m")]
        [TestCase("Fcm", "{0:F}cm", "120.00cm")]
        [TestCase(" f mm ", " {0:f} mm ", " 1200.00 mm ")]
        [TestCase("F5km", "{0:F5}km", "0.00120km")]
        [TestCase("f5 m", "{0:f5} m", "1.20000 m")]
        [TestCase("Gcm", "{0:G}cm", "120cm")]
        [TestCase("g cm", "{0:g} cm", "120 cm")]
        [TestCase("G5m", "{0:G5}m", "1.2m")]
        [TestCase("g5 m", "{0:g5} m", "1.2 m")]
        [TestCase("Nm", "{0:N}m", "1.20m")]
        [TestCase("n m", "{0:n} m", "1.20 m")]
        [TestCase("N5m", "{0:N5}m", "1.20000m")]
        [TestCase("n5 m", "{0:n5} m", "1.20000 m")]
        [TestCase("Rm", "{0:R}m", "1.2m")]
        [TestCase("r m", "{0:r} m", "1.2 m")]
        [TestCase("0m", "{0:0}m", "1m")]
        [TestCase("0.00 m", "{0:0.00} m", "1.20 m")]
        [TestCase("#m", "{0:#}m", "1m")]
        [TestCase("#.# m", "{0:#.#} m", "1.2 m")]
        [TestCase("#.0#m", "{0:#.0#}m", "1.2m")]
        [TestCase("#0.00# m", "{0:#0.00#} m", "1.20 m")]
        public void TryParseSuccess(string format, string expectedFormat, string expectedFormatted)
        {
            QuantityFormat<LengthUnit> actual;
            var success = CompositeFormatParser.TryParse(format, out actual);

            Assert.AreEqual(true, success);
            Assert.AreEqual(expectedFormat, actual.CompositeFormat);

            var length = Length.FromMetres(1.2);
            var actualFormatted = length.ToString(format, CultureInfo.InvariantCulture);
            Assert.AreEqual(expectedFormatted, actualFormatted);
        }

        [Explicit(Reminder.ToDo)]
        [TestCase("1\u00A0200,00 mm⋅s⁻¹", "#_##0.00 mm⋅s⁻¹", "meh")]
        [TestCase("F3 N/mm^2", "{0:F3} N/m^2", "MPa")]
        [TestCase("F3 N⋅mm⁻²", "{0:F3} N⋅m⁻²", "MPa")]
        [TestCase("E Pa", "{0:E} Pa", "Pa")]
        public void TryParsePressure(string format, string expectedFormat, string expectedSymbol)
        {
            QuantityFormat<PressureUnit> actual;
            var success = CompositeFormatParser.TryParse(format, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(expectedFormat, actual.CompositeFormat);
            Assert.AreEqual(expectedSymbol, actual.Unit.Symbol);
        }

        [TestCase("E", "E\u00A0{unit: null}")]
        [TestCase("mm", "{value: null}\u00A0mm")]
        public void TryParseError(string text, string expectedError)
        {
            QuantityFormat<LengthUnit> actual;
            var success = CompositeFormatParser.TryParse(text, out actual);
            Assert.AreEqual(false, success);
            Assert.AreEqual(expectedError, actual.ErrorText);
        }
    }
}
