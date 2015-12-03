namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using NUnit.Framework;

    public class ParseLengthTests
    {
        [TestCaseSource(nameof(HappyPaths))]
        public void ParseLengthSuccess(SuccessData<Length> data)
        {
            var numberStyles = NumberStyles.Float;

            var length = QuantityParser.Parse<LengthUnit, Length>(data.Text, Length.From, numberStyles, data.CultureInfo);
            Assert.AreEqual(data.Expected, length);

            length = Length.Parse(data.Text, numberStyles, data.CultureInfo);
            Assert.AreEqual(data.Expected, length);

            length = Length.Parse(data.Text, data.CultureInfo);
            Assert.AreEqual(data.Expected, length);

            using (Thread.CurrentThread.UsingTempCulture(data.CultureInfo))
            {
                length = Length.Parse(data.Text);
                Assert.AreEqual(data.Expected, length);
            }
        }

        [TestCaseSource(nameof(Errors))]
        public void ParseLengthThrows(ErrorData<Length> data)
        {
            var numberStyles = NumberStyles.Float;
            var ex = Assert.Throws<FormatException>(() => QuantityParser.Parse<LengthUnit, Length>(data.Text, Length.From, numberStyles, data.CultureInfo));
            Assert.AreEqual(data.ExpectedMessage, ex.Message);

            ex = Assert.Throws<FormatException>(() => Length.Parse(data.Text, numberStyles, data.CultureInfo));
            Assert.AreEqual(data.ExpectedMessage, ex.Message);

            ex = Assert.Throws<FormatException>(() => Length.Parse(data.Text, data.CultureInfo));
            Assert.AreEqual(data.ExpectedMessage, ex.Message);

            using (Thread.CurrentThread.UsingTempCulture(data.CultureInfo))
            {
                ex = Assert.Throws<FormatException>(() => Length.Parse(data.Text));
                Assert.AreEqual(data.ExpectedMessage, ex.Message);
            }
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void TryParseLengthSuccess(SuccessData<Length> data)
        {
            Length actual;
            var success = QuantityParser.TryParse<LengthUnit, Length>(
                data.Text,
                Length.From,
                NumberStyles.Float,
                data.CultureInfo,
                out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(data.Expected, actual);

            success = Length.TryParse(data.Text, NumberStyles.Float, data.CultureInfo, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(data.Expected, actual);

            success = Length.TryParse(data.Text, data.CultureInfo, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(data.Expected, actual);

            using (Thread.CurrentThread.UsingTempCulture(data.CultureInfo))
            {
                success = Length.TryParse(data.Text, out actual);
                Assert.AreEqual(true, success);
                Assert.AreEqual(data.Expected, actual);
            }
        }

        [TestCaseSource(nameof(Errors))]
        public void TryParseLengthFails(ErrorData<Length> data)
        {
            Length length;
            var success = QuantityParser.TryParse<LengthUnit, Length>(
                data.Text,
                Length.From,
                NumberStyles.Float,
                data.CultureInfo,
                out length);
            Assert.AreEqual(false, success);
            Assert.AreEqual(data.Expected, length);

            success = Length.TryParse(data.Text, NumberStyles.Float, data.CultureInfo, out length);
            Assert.AreEqual(false, success);
            Assert.AreEqual(data.Expected, length);

            success = Length.TryParse(data.Text, data.CultureInfo, out length);
            Assert.AreEqual(false, success);
            Assert.AreEqual(data.Expected, length);

            using (Thread.CurrentThread.UsingTempCulture(data.CultureInfo))
            {
                success = Length.TryParse(data.Text, out length);
                Assert.AreEqual(false, success);
                Assert.AreEqual(data.Expected, length);
            }
        }

        private const string Superscripts = "⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹"; // keeping this here for copy pasting
        private static readonly CultureInfo en = CultureInfo.GetCultureInfo("en-US");
        private static readonly CultureInfo sv = CultureInfo.GetCultureInfo("sv-SE");

        private static readonly IReadOnlyList<SuccessData<Length>> HappyPaths = new SuccessData<Length>[]
        {
            SuccessData.Create("1m", en, Length.FromMetres(1)),
            SuccessData.Create("1m", sv, Length.FromMetres(1)),
            SuccessData.Create("-1m", en, Length.FromMetres(-1)),
            SuccessData.Create("-1m", sv, Length.FromMetres(-1)),
            SuccessData.Create("1.2m", en,Length.FromMetres( 1.2)),
            SuccessData.Create(" 1.2m", en,Length.FromMetres( 1.2)),
            SuccessData.Create("1.2 m", en,Length.FromMetres( 1.2)),
            SuccessData.Create("1.2m ", en,Length.FromMetres( 1.2)),
            SuccessData.Create(" 1.2 m ", en,Length.FromMetres( 1.2)),
            SuccessData.Create("1,2m", sv,Length.FromMetres( 1.2)),
            SuccessData.Create("1e3m", en,Length.FromMetres( 1e3)),
            SuccessData.Create("1E3m",en,Length.FromMetres( 1e3)),
            SuccessData.Create("1e+3m",en,Length.FromMetres( 1e+3)),
            SuccessData.Create("1E+3m",en,Length.FromMetres( 1E+3)),
            SuccessData.Create("1.2e-3m", en,Length.FromMetres( 1.2e-3)),
            SuccessData.Create("1.2E-3m", en, Length.FromMetres(1.2e-3)),
            SuccessData.Create(" 1m",en, Length.FromMetres(1)),
            SuccessData.Create("1 m",en,Length.FromMetres( 1)),
            SuccessData.Create("1m ",en,Length.FromMetres( 1)),
            SuccessData.Create("1.2mm",en, Length.FromMillimetres(1.2)),
            SuccessData.Create("1.2cm",en,Length.FromCentimetres(1.2)),
        };

        private static readonly IReadOnlyList<ErrorData<Length>> Errors = new ErrorData<Length>[]
        {
            ErrorData.Create<Length>("1.2m", sv, "Could not parse the unit value from: 1.2m"),
            ErrorData.Create<Length>("1.2", en, "Could not parse the unit value from: 1.2"),
            ErrorData.Create<Length>("1,2m", en, "Could not parse the unit value from: 1,2m"),
        };
    }
}