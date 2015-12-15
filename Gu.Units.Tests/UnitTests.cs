namespace Gu.Units.Tests
{
    using System.Globalization;
    using System.Reflection;
    using System.Threading;
    using Gu.Units.Tests.Sources;
    using Internals.Parsing;
    using NUnit.Framework;

    public class UnitTests
    {
        [TestCaseSource(typeof(UnitsProvider))]
        public void Roundtrip(IUnit unit)
        {
            var s = unit.ToString();
            var parseMethod = unit.GetType().GetMethod("Parse", BindingFlags.Static | BindingFlags.Public);
            var roundtripped = (IUnit)parseMethod.Invoke(null, new object[] { s });
            Assert.AreEqual(unit, roundtripped);
        }

        [Test]
        public void LengthUnitTosStringFormatted()
        {
            var actual = LengthUnit.Metres.ToString();
            Assert.AreEqual("m", actual);

            actual = LengthUnit.Metres.ToString("m");
            Assert.AreEqual("m", actual);
        }

        [Test]
        public void MetresPerSecondToString()
        {
            Assert.AreEqual("m/s", SpeedUnit.MetresPerSecond.ToString());
            Assert.AreEqual("m/s", SpeedUnit.MetresPerSecond.ToString("m/s"));
            Assert.AreEqual("m*s^-1", SpeedUnit.MetresPerSecond.ToString("m*s^-1"));
            Assert.AreEqual("m⋅s⁻¹", SpeedUnit.MetresPerSecond.ToString("m⋅s⁻¹"));
            Assert.AreEqual("m¹⋅s⁻¹", SpeedUnit.MetresPerSecond.ToString("m¹⋅s⁻¹"));
            Assert.AreEqual("m¹/s¹", SpeedUnit.MetresPerSecond.ToString("m¹/s¹"));
            Assert.AreEqual("m/s", SpeedUnit.MetresPerSecond.ToString(SymbolFormat.Default));
            Assert.AreEqual("m/s", SpeedUnit.MetresPerSecond.ToString(SymbolFormat.FractionHatPowers));
            Assert.AreEqual("m*s^-1", SpeedUnit.MetresPerSecond.ToString(SymbolFormat.SignedHatPowers));
            Assert.AreEqual("m/s", SpeedUnit.MetresPerSecond.ToString(SymbolFormat.FractionSuperScript));
            Assert.AreEqual("m⋅s⁻¹", SpeedUnit.MetresPerSecond.ToString(SymbolFormat.SignedSuperScript));
        }

        [Test]
        public void PressureUnitToString()
        {
            Assert.AreEqual("Pa", PressureUnit.Pascals.ToString());
            Assert.AreEqual("Pa", PressureUnit.Pascals.ToString("Pa"));
            Assert.AreEqual("N/mm²", PressureUnit.Pascals.ToString("N/mm²"));
            Assert.AreEqual("N/mm^2", PressureUnit.Pascals.ToString("N/mm^2"));
            Assert.AreEqual("N*mm^-2", PressureUnit.Pascals.ToString("N*mm^-2"));
            Assert.AreEqual("N⋅mm⁻²", PressureUnit.Pascals.ToString("N⋅mm⁻²"));
            Assert.AreEqual("bar", PressureUnit.Bars.ToString());
        }
    }
}
