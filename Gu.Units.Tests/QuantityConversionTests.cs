namespace Gu.Units.Tests
{
    using System;
    using System.Globalization;
    using NUnit.Framework;

    [TestFixture]
    public class QuantityConversionTests
    {
        public static readonly TestCase[] TestCases =
        {
            new TestCase(Length.FromMillimetres(1.2), Length.FromMetres(0.0012)),
            new TestCase(Length.FromCentimetres(-1.2), Length.FromMetres(-0.012)),
            new TestCase(Length.FromKilometres(1.2), Length.FromMetres(1200)),
            new TestCase(Angle.FromRadians(-1.2), Angle.FromDegrees(-1.2 * 180 / Math.PI)),
            new TestCase(Angle.FromRadians(1.2 * Math.PI / 180), Angle.FromDegrees(1.2)),
            new TestCase(Volume.FromLitres(1.2), Volume.FromCubicMetres(0.0012)),
            new TestCase(Volume.FromMillilitres(1.2), Volume.FromCubicMetres(0.0000012)),
            ////new TestCase(Temperature.FromKelvin(1.2), Temperature.FromCelsius(1.2 -273.15)),
            new TestCase(Pressure.FromBars(1.2), Pressure.FromMegapascals(0.12)),
            new TestCase(Pressure.FromNewtonsPerSquareMillimetre(1.2), Pressure.FromMegapascals(1.2)),
            new TestCase("1.2 g", "0.0012 kg", s => Mass.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1.2 mg", "0.0000012 kg", s => Mass.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1.2cm", "0.012 m", s => Length.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1.2 cm", "12 mm", s => Length.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1.2 mm^2", "1.2E-6 m^2", s => Area.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("90°", "1.5707963267948966rad", s => Angle.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1°", "0.017453292519943295rad", s => Angle.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("0°C", "32°F", s => Temperature.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("100°C", "211.99999999999994°F", s => Temperature.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("100°F", "37.777777777777828°C", s => Temperature.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("0K", "-273.15°C", s => Temperature.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("0K", "-459.67°F", s => Temperature.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("100K", "-173.14999999999998°C", s => Temperature.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("100K", "-279.67°F", s => Temperature.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1ul", "100%", s => Unitless.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1%", "0.01ul", s => Unitless.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1%", "10‰", s => Unitless.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("100N", "0.1kN", s => Force.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1.2 Pa", "0.000012 bar", s => Pressure.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("0.12 MPa", "1.2 bar", s => Pressure.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1.2 Pa", "0.012 mbar", s => Pressure.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1.2 mm/s^2", "0.0012 m/s^2", s => Acceleration.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1.2 mm/s^2", "0.0012 m/s^2", s => Acceleration.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1.2 L", "0.0012 m^3", s => Volume.Parse(s, CultureInfo.InvariantCulture)),
            new TestCase("1.2 ml", "0.0000012 m^3", s => Volume.Parse(s, CultureInfo.InvariantCulture)),
        };

        [Test]
        public void CentimetresMetres()
        {
            var cms = new[]
                          {
                              Length.FromCentimetres(1.2),
                              new Length(1.2, LengthUnit.Centimetres),
                          };
            foreach (var cm in cms)
            {
                Assert.AreEqual(0.012, cm.Metres);
                var metres = Length.FromMetres(cm.Metres);
                Assert.AreEqual(1.2, metres.Centimetres);
            }
        }

        [Test]
        public void CentimetresMillimetres()
        {
            var cms = new[]
                          {
                              Length.FromCentimetres(1.2),
                              new Length(1.2, LengthUnit.Centimetres),
                          };
            foreach (var cm in cms)
            {
                Assert.AreEqual(12, cm.Millimetres);
                var millimetres = Length.FromMillimetres(cm.Millimetres);
                Assert.AreEqual(1.2, millimetres.Centimetres);
            }
        }

        [Test]
        public void TemperatureConversions()
        {
            var t1 = Temperature.FromKelvin(1.2);
            var t2 = Temperature.FromCelsius(1.2 - 273.15);
            Assert.IsTrue(t1.Equals(t2, Temperature.FromKelvin(1E-6)));
            Assert.Inconclusive("Does not roundtrip cleanly");
        }

        [TestCaseSource(nameof(TestCases))]
        public void AreEqual(TestCase conversion)
        {
            Assert.AreEqual(conversion.X, conversion.Y);
            //// random asserts below.
            Assert.AreEqual(conversion.Y, conversion.X);
            Assert.AreEqual(conversion.X, conversion.X);
            Assert.AreEqual(conversion.Y, conversion.Y);
        }

        public class TestCase
        {
            private readonly string text;

            public TestCase(string x, string y, Func<string, IQuantity> parse)
            {
                this.X = parse(x);
                this.Y = parse(y);
                this.text = $"{x} == {y}";
            }

            public TestCase(IQuantity x, IQuantity y)
            {
                this.X = x;
                this.Y = y;
                this.text = $"{x} == {y}";
            }

            public IQuantity X { get; }

            public IQuantity Y { get; }

            public override string ToString()
            {
                return this.text;
            }
        }
    }
}
