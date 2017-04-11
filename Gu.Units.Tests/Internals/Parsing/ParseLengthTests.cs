namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using NUnit.Framework;

    public class ParseLengthTests
    {
        // ReSharper disable once UnusedMember.Local
        private const string Superscripts = "⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹"; // keeping this here for copy pasting
        private static readonly CultureInfo En = CultureInfo.GetCultureInfo("en-US");
        private static readonly CultureInfo Sv = CultureInfo.GetCultureInfo("sv-SE");

        private static readonly IReadOnlyList<SuccessCase<Length>> HappyPaths = new[]
                                                                                    {
                                                                                        SuccessCase.Create("1m", En, Length.FromMetres(1)),
                                                                                        SuccessCase.Create("1m", Sv, Length.FromMetres(1)),
                                                                                        SuccessCase.Create("-1m", En, Length.FromMetres(-1)),
                                                                                        SuccessCase.Create("-1m", Sv, Length.FromMetres(-1)),
                                                                                        SuccessCase.Create("1.2m", En, Length.FromMetres(1.2)),
                                                                                        SuccessCase.Create(" 1.2m", En, Length.FromMetres(1.2)),
                                                                                        SuccessCase.Create("1.2 m", En, Length.FromMetres(1.2)),
                                                                                        SuccessCase.Create("1.2m ", En, Length.FromMetres(1.2)),
                                                                                        SuccessCase.Create(" 1.2 m ", En, Length.FromMetres(1.2)),
                                                                                        SuccessCase.Create("1,2m", Sv, Length.FromMetres(1.2)),
                                                                                        SuccessCase.Create("1e3m", En, Length.FromMetres(1e3)),
                                                                                        SuccessCase.Create("1E3m", En, Length.FromMetres(1e3)),
                                                                                        SuccessCase.Create("1e+3m", En, Length.FromMetres(1e+3)),
                                                                                        SuccessCase.Create("1E+3m", En, Length.FromMetres(1E+3)),
                                                                                        SuccessCase.Create("1.2e-3m", En, Length.FromMetres(1.2e-3)),
                                                                                        SuccessCase.Create("1.2E-3m", En, Length.FromMetres(1.2e-3)),
                                                                                        SuccessCase.Create(" 1m", En, Length.FromMetres(1)),
                                                                                        SuccessCase.Create("1 m", En, Length.FromMetres(1)),
                                                                                        SuccessCase.Create("1m ", En, Length.FromMetres(1)),
                                                                                        SuccessCase.Create("1.2mm", En, Length.FromMillimetres(1.2)),
                                                                                        SuccessCase.Create("1.2cm", En, Length.FromCentimetres(1.2)),
                                                                                    };

        private static readonly IReadOnlyList<ErrorCase<Length>> Errors = new[]
                                                                              {
                                                                                  ErrorCase.Create<Length>("1.2m", Sv, "Could not parse the unit value from: 1.2m"),
                                                                                  ErrorCase.Create<Length>("1.2", En, "Could not parse the unit value from: 1.2"),
                                                                                  ErrorCase.Create<Length>("1,2m", En, "Could not parse the unit value from: 1,2m"),
                                                                              };

        [TestCaseSource(nameof(HappyPaths))]
        public void ParseLengthSuccess(SuccessCase<Length> testCase)
        {
            var numberStyles = NumberStyles.Float;

            var length = QuantityParser.Parse<LengthUnit, Length>(testCase.Text, Length.From, numberStyles, testCase.CultureInfo);
            Assert.AreEqual(testCase.Expected, length);

            length = Length.Parse(testCase.Text, numberStyles, testCase.CultureInfo);
            Assert.AreEqual(testCase.Expected, length);

            length = Length.Parse(testCase.Text, testCase.CultureInfo);
            Assert.AreEqual(testCase.Expected, length);

            using (Thread.CurrentThread.UsingTempCulture(testCase.CultureInfo))
            {
                length = Length.Parse(testCase.Text);
                Assert.AreEqual(testCase.Expected, length);
            }
        }

        [TestCaseSource(nameof(Errors))]
        public void ParseLengthThrows(ErrorCase<Length> testCase)
        {
            var numberStyles = NumberStyles.Float;
            var ex = Assert.Throws<FormatException>(() => QuantityParser.Parse<LengthUnit, Length>(testCase.Text, Length.From, numberStyles, testCase.CultureInfo));
            Assert.AreEqual(testCase.ExpectedMessage, ex.Message);

            ex = Assert.Throws<FormatException>(() => Length.Parse(testCase.Text, numberStyles, testCase.CultureInfo));
            Assert.AreEqual(testCase.ExpectedMessage, ex.Message);

            ex = Assert.Throws<FormatException>(() => Length.Parse(testCase.Text, testCase.CultureInfo));
            Assert.AreEqual(testCase.ExpectedMessage, ex.Message);

            using (Thread.CurrentThread.UsingTempCulture(testCase.CultureInfo))
            {
                ex = Assert.Throws<FormatException>(() => Length.Parse(testCase.Text));
                Assert.AreEqual(testCase.ExpectedMessage, ex.Message);
            }
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void TryParseLengthSuccess(SuccessCase<Length> data)
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
        public void TryParseLengthFails(ErrorCase<Length> @case)
        {
            Length length;
            var success = QuantityParser.TryParse<LengthUnit, Length>(
                @case.Text,
                Length.From,
                NumberStyles.Float,
                @case.CultureInfo,
                out length);
            Assert.AreEqual(false, success);
            Assert.AreEqual(@case.Expected, length);

            success = Length.TryParse(@case.Text, NumberStyles.Float, @case.CultureInfo, out length);
            Assert.AreEqual(false, success);
            Assert.AreEqual(@case.Expected, length);

            success = Length.TryParse(@case.Text, @case.CultureInfo, out length);
            Assert.AreEqual(false, success);
            Assert.AreEqual(@case.Expected, length);

            using (Thread.CurrentThread.UsingTempCulture(@case.CultureInfo))
            {
                success = Length.TryParse(@case.Text, out length);
                Assert.AreEqual(false, success);
                Assert.AreEqual(@case.Expected, length);
            }
        }
    }
}