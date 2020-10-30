namespace Gu.Units.Tests.Internals.Caching
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    // ⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹
    public static class UnitFormatCacheTests
    {
        private static readonly SymbolFormat[] TestCases = Enum.GetValues(typeof(SymbolFormat)).Cast<SymbolFormat>().ToArray();

        [TestCaseSource(nameof(TestCases))]
        public static void GetOrCreateSymbolFormatLength(SymbolFormat symbolFormat)
        {
            var format = UnitFormatCache<LengthUnit>.GetOrCreate(LengthUnit.Millimetres, symbolFormat);
            Assert.AreEqual(null, format.PrePadding);
            Assert.AreEqual("mm", format.Format);
            Assert.AreEqual(null, format.PostPadding);
        }

        [TestCase(SymbolFormat.Default, "mm/s")]
        [TestCase(SymbolFormat.SignedHatPowers, "mm*s^-1")]
        [TestCase(SymbolFormat.FractionHatPowers, "mm/s")]
        [TestCase(SymbolFormat.SignedSuperScript, "mm⋅s⁻¹")]
        [TestCase(SymbolFormat.FractionSuperScript, "mm/s")]
        public static void GetOrCreateSymbolFormatSpeed(SymbolFormat symbolFormat, string expected)
        {
            var format = UnitFormatCache<SpeedUnit>.GetOrCreate(SpeedUnit.MillimetresPerSecond, symbolFormat);
            Assert.AreEqual(null, format.PrePadding);
            Assert.AreEqual(expected, format.Format);
            Assert.AreEqual(null, format.PostPadding);
        }

        [TestCase(SymbolFormat.Default, "Hz")]
        [TestCase(SymbolFormat.SignedHatPowers, "Hz")]
        [TestCase(SymbolFormat.FractionHatPowers, "Hz")]
        [TestCase(SymbolFormat.SignedSuperScript, "Hz")]
        [TestCase(SymbolFormat.FractionSuperScript, "Hz")]
        public static void GetOrCreateSymbolFormatFrequency(SymbolFormat symbolFormat, string expected)
        {
            var format = UnitFormatCache<FrequencyUnit>.GetOrCreate(FrequencyUnit.Hertz, symbolFormat);
            Assert.AreEqual(null, format.PrePadding);
            Assert.AreEqual(expected, format.Format);
            Assert.AreEqual(null, format.PostPadding);
        }
    }
}
