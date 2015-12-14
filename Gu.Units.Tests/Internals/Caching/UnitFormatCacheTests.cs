namespace Gu.Units.Tests.Internals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    public class UnitFormatCacheTests
    {
        private const string Unicodes = "⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";

        [TestCaseSource(nameof(SymbolFormatsSource))]
        public void GetOrCreateSymbolFormatLength(SymbolFormat symbolFormat)
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
        public void GetOrCreateSymbolFormatSpeed(SymbolFormat symbolFormat, string expected)
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
        public void GetOrCreateSymbolFormatFrequency(SymbolFormat symbolFormat, string expected)
        {
            var format = UnitFormatCache<FrequencyUnit>.GetOrCreate(FrequencyUnit.Hertz, symbolFormat);
            Assert.AreEqual(null, format.PrePadding);
            Assert.AreEqual(expected, format.Format);
            Assert.AreEqual(null, format.PostPadding);
        }

        private static IReadOnlyList<SymbolFormat> SymbolFormatsSource = Enum.GetValues(typeof(SymbolFormat)).Cast<SymbolFormat>().ToList();
    }
}
