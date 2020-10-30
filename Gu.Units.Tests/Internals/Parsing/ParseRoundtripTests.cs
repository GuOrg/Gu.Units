namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using NUnit.Framework;

    public class ParseRoundtripTests
    {
        // ReSharper disable once UnusedMember.Local
        private const string Superscripts = "⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹"; // keeping this here for copy pasting
        private static readonly CultureInfo En = CultureInfo.GetCultureInfo("en-US");
        private static readonly CultureInfo Sv = CultureInfo.GetCultureInfo("sv-SE");

        private static readonly IReadOnlyList<ISuccessData> HappyPaths = new ISuccessData[]
                                                                             {
                                                                                 SuccessCase.Create("1.2m^2", En, Area.FromSquareMetres(1.2)),
                                                                                 SuccessCase.Create("1.2m²", En, Area.FromSquareMetres(1.2)),
                                                                                 SuccessCase.Create("1,2m²", Sv, Area.FromSquareMetres(1.2)),
                                                                                 SuccessCase.Create("1.2s", En, Time.FromSeconds(1.2)),
                                                                                 SuccessCase.Create("1.2h", En, Time.FromHours(1.2)),
                                                                                 SuccessCase.Create("1.2ms", En, Time.FromMilliseconds(1.2)),
                                                                                 SuccessCase.Create("1.2kg", En, Mass.FromKilograms(1.2)),
                                                                                 SuccessCase.Create("1.2g", En, Mass.FromGrams(1.2)),
                                                                                 SuccessCase.Create("1.2m³", En, Volume.FromCubicMetres(1.2)),
                                                                                 SuccessCase.Create("1.2m^3", En, Volume.FromCubicMetres(1.2)),
                                                                                 SuccessCase.Create("1.2m/s", En, Speed.FromMetresPerSecond(1.2)),
                                                                                 SuccessCase.Create("1.2m⋅s⁻¹", En, Speed.FromMetresPerSecond(1.2)),
                                                                                 SuccessCase.Create("1.2m*s⁻¹", En, Speed.FromMetresPerSecond(1.2)),
                                                                                 SuccessCase.Create("1.2m¹⋅s⁻¹", En, Speed.FromMetresPerSecond(1.2)),
                                                                                 SuccessCase.Create("1.2m^1⋅s⁻¹", En, Speed.FromMetresPerSecond(1.2)),
                                                                                 SuccessCase.Create("1.2m^1⋅s^-1", En, Speed.FromMetresPerSecond(1.2)),
                                                                                 SuccessCase.Create("1.2m^1/s^2", En, Acceleration.FromMetresPerSecondSquared(1.2)),
                                                                                 SuccessCase.Create("1.2m/s^2", En, Acceleration.FromMetresPerSecondSquared(1.2)),
                                                                                 SuccessCase.Create("1.2 m/s^2", En, Acceleration.FromMetresPerSecondSquared(1.2)),
                                                                                 SuccessCase.Create("1.2 m / s^2", En, Acceleration.FromMetresPerSecondSquared(1.2)),
                                                                                 SuccessCase.Create("1.2 m / s²", En, Acceleration.FromMetresPerSecondSquared(1.2)),
                                                                                 SuccessCase.Create("1.2 mm / s²", En, Acceleration.FromMillimetresPerSecondSquared(1.2)),
                                                                             };

        [TestCaseSource(nameof(HappyPaths))]
        public void ParseRoundtrip(ISuccessData data)
        {
            using (Thread.CurrentThread.UsingTempCulture(data.CultureInfo))
            {
                var actual = data.Parse(data.Text);
                Assert.AreEqual(data.Expected, actual);
                var toString = actual.ToString();
                var roundtripped = data.Parse(toString);
                Assert.AreEqual(data.Expected, roundtripped);
            }
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void ParseRoundtripWithCulture(ISuccessData data)
        {
            var actual = data.Parse(data.Text, data.CultureInfo);
            Assert.AreEqual(data.Expected, actual);
            var toString = ((IFormattable)actual).ToString(null, data.CultureInfo);
            var roundtripped = data.Parse(toString, data.CultureInfo);
            Assert.AreEqual(data.Expected, roundtripped);
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void TryParseRoundtrip(ISuccessData data)
        {
            using (Thread.CurrentThread.UsingTempCulture(data.CultureInfo))
            {
                var success = data.TryParse(data.Text, out var actual);
                Assert.AreEqual(true, success);
                Assert.AreEqual(data.Expected, actual);
                var toString = actual.ToString();
                success = data.TryParse(toString, out actual);
                Assert.AreEqual(true, success);
                Assert.AreEqual(data.Expected, actual);
            }
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void TryParseRoundtripWithCulture(ISuccessData data)
        {
            var success = data.TryParse(data.Text, data.CultureInfo, out var actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(data.Expected, actual);
            success = data.TryParse(data.Text, data.CultureInfo, out actual);
            Assert.AreEqual(data.Expected, actual);
            Assert.AreEqual(true, success);

            var toString = ((IFormattable)actual).ToString(null, data.CultureInfo);
            success = data.TryParse(toString, data.CultureInfo, out actual);
            Assert.AreEqual(data.Expected, actual);
            Assert.AreEqual(true, success);
        }
    }
}