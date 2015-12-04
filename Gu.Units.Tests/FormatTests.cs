namespace Gu.Units.Tests
{
    using System.Globalization;
    using System.Threading;
    using Internals.Parsing;
    using NUnit.Framework;

    public class FormatTests
    {
        const string UnknownFormat = "unknown format";

        [Test]
        public void FormatAngle()
        {
            var angle = Angle.FromDegrees(1.2);
            using (Thread.CurrentThread.UsingTempCulture(CultureInfo.InvariantCulture))
            {
                Assert.AreEqual("0.020943951023932\u00A0rad", angle.ToString());
                Assert.AreEqual("1.200°", angle.ToString("F3°"));
                Assert.AreEqual("1.2°", angle.ToString(AngleUnit.Degrees));
                Assert.AreEqual(" 1.2 ° ", angle.ToString(" F1 ° "));
                Assert.AreEqual(" 0.02 rad ", angle.ToString(" F2 rad "));
                Assert.AreEqual("1.200°", angle.ToString("F3", AngleUnit.Degrees));
                Assert.AreEqual("0.02\u00A0rad", angle.ToString("F2", AngleUnit.Radians));
            }

            var sv = CultureInfo.GetCultureInfo("sv-SE");
            Assert.AreEqual("0,020943951023932\u00A0rad", angle.ToString(sv));
            Assert.AreEqual("1,200°", angle.ToString("F3°", sv));
            Assert.AreEqual("1,2°", angle.ToString(AngleUnit.Degrees, sv));
            Assert.AreEqual(" 1,2 ° ", angle.ToString(" F1 ° ", sv));
            Assert.AreEqual(" 0,02 rad", angle.ToString(" F2 rad", sv));
            Assert.AreEqual("1,200°", angle.ToString("F3", AngleUnit.Degrees, sv));
            Assert.AreEqual("0,02\u00A0rad", angle.ToString("F2", AngleUnit.Radians, sv));
        }

        [Test]
        public void FormatSpeed()
        {
            var speed = Speed.FromMetresPerSecond(1.2);
            using (Thread.CurrentThread.UsingTempCulture(CultureInfo.InvariantCulture))
            {
                Assert.AreEqual("1.2\u00A0m/s", speed.ToString());
                Assert.AreEqual("1.20 m/s", speed.ToString("F2 m/s"));
                Assert.AreEqual(UnknownFormat, 1.2.ToString(UnknownFormat)); // for comparison
                Assert.AreEqual(UnknownFormat, speed.ToString(UnknownFormat));
                Assert.AreEqual("F1\u00A0{unit: invalid}", speed.ToString("F1 invalid"));
                Assert.AreEqual("1.20 m⋅s⁻¹", speed.ToString("F2 m⋅s⁻¹"));
                Assert.AreEqual("1.2\u00A0m⋅s⁻¹", speed.ToString("f1", "m⋅s⁻¹"));
                Assert.AreEqual("1.2 m⋅s⁻¹", speed.ToString("f1 ", "m⋅s⁻¹"));
                Assert.AreEqual("1.2 m⋅s⁻¹", speed.ToString("f1", " m⋅s⁻¹"));
                Assert.AreEqual("1.2  m⋅s⁻¹", speed.ToString("f1 ", " m⋅s⁻¹"));
                Assert.AreEqual("{value: null} mm⋅s⁻¹", speed.ToString("mm⋅s⁻¹"));
                Assert.AreEqual("1200\u00A0s⁻¹⋅mm", speed.ToString("F0", "s⁻¹⋅mm"));
                Assert.AreEqual("1200\u00A0s⁻¹⋅mm¹", speed.ToString("F0", "s⁻¹⋅mm¹"));
                Assert.AreEqual("1.2\u00A0m*s^-1", speed.ToString("F1", "m*s^-1"));
                Assert.AreEqual("1.2\u00A0s^-1*m", speed.ToString("F1", "s^-1*m"));
                Assert.AreEqual("1.2\u00A0s^-1*m^1", speed.ToString("F1", "s^-1*m^1"));
                Assert.AreEqual("4.32\u00A0km/h", speed.ToString(SpeedUnit.KilometresPerHour));
                Assert.AreEqual("1.2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.Default));
                Assert.AreEqual("1.2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.FractionHatPowers));
                Assert.AreEqual("1.2\u00A0m*s^-1", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.SignedHatPowers));
                Assert.AreEqual("1.2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.FractionSuperScript));
                Assert.AreEqual("1.2\u00A0m⋅s⁻¹", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.SignedSuperScript));
                Assert.AreEqual("4.3\u00A0km/h", speed.ToString("F1", SpeedUnit.KilometresPerHour));
                Assert.AreEqual("1.2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.Default));
                Assert.AreEqual("1.2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.FractionHatPowers));
                Assert.AreEqual("1.2\u00A0m*s^-1", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.SignedHatPowers));
                Assert.AreEqual("1.2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.FractionSuperScript));
                Assert.AreEqual("1.2\u00A0m⋅s⁻¹", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.SignedSuperScript));
                Assert.AreEqual("1,200.00 mm⋅s⁻¹", speed.ToString("N mm⋅s⁻¹"));
            }

            var sv = CultureInfo.GetCultureInfo("sv-SE");

            Assert.AreEqual("1,2\u00A0m/s", speed.ToString(sv));
            Assert.AreEqual("1,20 m/s", speed.ToString("F2 m/s", sv));
            Assert.AreEqual(UnknownFormat, 1.2.ToString(UnknownFormat, sv)); // for comparison
            Assert.AreEqual(UnknownFormat, speed.ToString(UnknownFormat, sv));
            Assert.AreEqual("F1\u00A0{unit: invalid}", speed.ToString("F1 invalid", sv));
            Assert.AreEqual("1,20 m⋅s⁻¹", speed.ToString("F2 m⋅s⁻¹", sv));
            Assert.AreEqual("1,2\u00A0m⋅s⁻¹", speed.ToString("f1", "m⋅s⁻¹", sv));
            Assert.AreEqual("1,2 m⋅s⁻¹", speed.ToString("f1 ", "m⋅s⁻¹", sv));
            Assert.AreEqual("1,2 m⋅s⁻¹", speed.ToString("f1", " m⋅s⁻¹", sv));
            Assert.AreEqual("1,2  m⋅s⁻¹", speed.ToString("f1 ", " m⋅s⁻¹", sv));
            Assert.AreEqual("{value: null} mm⋅s⁻¹", speed.ToString("mm⋅s⁻¹", sv));
            Assert.AreEqual("1200\u00A0s⁻¹⋅mm", speed.ToString("F0", "s⁻¹⋅mm", sv));
            Assert.AreEqual("1200\u00A0s⁻¹⋅mm¹", speed.ToString("F0", "s⁻¹⋅mm¹", sv));
            Assert.AreEqual("1,2\u00A0m*s^-1", speed.ToString("F1", "m*s^-1", sv));
            Assert.AreEqual("1,2\u00A0s^-1*m", speed.ToString("F1", "s^-1*m", sv));
            Assert.AreEqual("1,2\u00A0s^-1*m^1", speed.ToString("F1", "s^-1*m^1", sv));
            Assert.AreEqual("4,32\u00A0km/h", speed.ToString(SpeedUnit.KilometresPerHour, sv));
            Assert.AreEqual("1,2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.Default, sv));
            Assert.AreEqual("1,2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.FractionHatPowers, sv));
            Assert.AreEqual("1,2\u00A0m*s^-1", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.SignedHatPowers, sv));
            Assert.AreEqual("1,2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.FractionSuperScript, sv));
            Assert.AreEqual("1,2\u00A0m⋅s⁻¹", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.SignedSuperScript, sv));
            Assert.AreEqual("4,3\u00A0km/h", speed.ToString("F1", SpeedUnit.KilometresPerHour, sv));
            Assert.AreEqual("1,2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.Default, sv));
            Assert.AreEqual("1,2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.FractionHatPowers, sv));
            Assert.AreEqual("1,2\u00A0m*s^-1", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.SignedHatPowers, sv));
            Assert.AreEqual("1,2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.FractionSuperScript, sv));
            Assert.AreEqual("1,2\u00A0m⋅s⁻¹", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.SignedSuperScript, sv));
            Assert.AreEqual("1\u00A0200,00 mm⋅s⁻¹", speed.ToString("N mm⋅s⁻¹", sv));
        }

        private const string Superscripts = "⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";
        private const char MultiplyDot = '⋅';
        [Test]
        public void FormatPressure()
        {
            var pressure = Pressure.FromMegapascals(1.2);
            using (Thread.CurrentThread.UsingTempCulture(CultureInfo.InvariantCulture))
            {
                Assert.AreEqual("1200000\u00A0Pa", pressure.ToString());
                Assert.AreEqual("12\u00A0bar", pressure.ToString(PressureUnit.Bars));
                Assert.AreEqual("1.2\u00A0N/mm²", pressure.ToString(PressureUnit.NewtonsPerSquareMillimetre, SymbolFormat.Default));
                Assert.AreEqual("1.2\u00A0N/mm^2", pressure.ToString(PressureUnit.NewtonsPerSquareMillimetre, SymbolFormat.FractionHatPowers));
                Assert.AreEqual("1.2\u00A0N*mm^-2", pressure.ToString(PressureUnit.NewtonsPerSquareMillimetre, SymbolFormat.SignedHatPowers));
                Assert.AreEqual("1.2\u00A0N/mm²", pressure.ToString(PressureUnit.NewtonsPerSquareMillimetre, SymbolFormat.FractionSuperScript));
                Assert.AreEqual("1.2\u00A0N⋅mm⁻²", pressure.ToString(PressureUnit.NewtonsPerSquareMillimetre, SymbolFormat.SignedSuperScript));
                Assert.AreEqual("1.20\u00A0N/mm²", pressure.ToString("F2", PressureUnit.NewtonsPerSquareMillimetre));
                Assert.AreEqual("1.20\u00A0N/mm²", pressure.ToString("F2", PressureUnit.NewtonsPerSquareMillimetre, SymbolFormat.Default));
                Assert.AreEqual("1.20\u00A0N/mm^2", pressure.ToString("F2", PressureUnit.NewtonsPerSquareMillimetre, SymbolFormat.FractionHatPowers));
                Assert.AreEqual("1.20\u00A0N*mm^-2", pressure.ToString("F2", PressureUnit.NewtonsPerSquareMillimetre, SymbolFormat.SignedHatPowers));
                Assert.AreEqual("1.20\u00A0N/mm²", pressure.ToString("F2", PressureUnit.NewtonsPerSquareMillimetre, SymbolFormat.FractionSuperScript));
                Assert.AreEqual("1.20\u00A0N⋅mm⁻²", pressure.ToString("F2", PressureUnit.NewtonsPerSquareMillimetre, SymbolFormat.SignedSuperScript));
                Assert.AreEqual("1.20 N/mm^2", pressure.ToString("F2 N/mm^2"));
                Assert.AreEqual("1.20 N⋅mm⁻²", pressure.ToString("F2 N⋅mm⁻²"));
                Assert.AreEqual("1.20 MPa", pressure.ToString("F2 MPa"));
                Assert.AreEqual("1.20E+006 Pa", pressure.ToString("E2 Pa"));
            }
        }
    }
}