namespace Gu.Units.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Sources;

    [TestFixture]
    public class ConversionTests
    {
        [Test]
        public void CentimetresMetres()
        {
            const double Centimetres = 1.2;
            var cms = new[]
                          {
                              Length.FromCentimetres(Centimetres),
                              new Length(Centimetres, LengthUnit.Centimetres),
                          };
            foreach (var cm in cms)
            {
                Assert.AreEqual(0.012, cm.Metres);
                var metres = Length.FromMetres(cm.Metres);
                Assert.AreEqual(Centimetres, metres.Centimetres);
            }
        }

        [Test]
        public void CentimetresMillimetres()
        {
            const double Centimetres = 1.2;
            var cms = new[]
                          {
                              Length.FromCentimetres(Centimetres),
                              new Length(Centimetres, LengthUnit.Centimetres),
                          };
            foreach (var cm in cms)
            {
                Assert.AreEqual(12, cm.Millimetres);
                var millimetres = Length.FromMillimetres(cm.Millimetres);
                Assert.AreEqual(Centimetres, millimetres.Centimetres);
            }
        }

        [TestCaseSource(typeof(ConversionProvider))]
        public void UnitConvert(ConversionProvider.IConversion<IQuantity> conversion)
        {
            Assert.AreEqual(conversion.FromQuantity, conversion.ToQuantity);
        }

        [TestCaseSource(nameof(QuantityConversions))]
        public void QtyConvert(ConversionProvider.IConversion<IQuantity> conversion)
        {
            Assert.AreEqual(conversion.FromQuantity, conversion.ToQuantity);
        }

        [Test]
        public void TemperatureConversions()
        {
            var t1 = Temperature.FromKelvin(1.2);
            var t2 = Temperature.FromCelsius(1.2 - 273.15);
            Assert.IsTrue(t1.Equals(t2, Temperature.FromKelvin(1E-6)));
            Assert.Inconclusive("Does not roundtrip cleanly");
        }

        private readonly IReadOnlyList<ConversionProvider.IConversion<IQuantity>> QuantityConversions = new[]
        {
            new ConversionProvider.Conversion<IQuantity>(Length.FromMillimetres(1.2), Length.FromMetres(0.0012)),
            new ConversionProvider.Conversion<IQuantity>(Length.FromCentimetres(-1.2), Length.FromMetres(-0.012)),
            new ConversionProvider.Conversion<IQuantity>(Length.FromKilometres(1.2), Length.FromMetres(1200)),
            new ConversionProvider.Conversion<IQuantity>(Angle.FromRadians(-1.2), Angle.FromDegrees(-1.2*180/Math.PI)),
            new ConversionProvider.Conversion<IQuantity>(Angle.FromRadians(1.2*Math.PI/180), Angle.FromDegrees(1.2)),
            new ConversionProvider.Conversion<IQuantity>(Volume.FromLitres(1.2), Volume.FromCubicMetres(0.0012)),
            new ConversionProvider.Conversion<IQuantity>(Volume.FromMillilitres(1.2), Volume.FromCubicMetres(0.0000012)),
            //new ConversionProvider.Conversion<IQuantity>(Temperature.FromKelvin(1.2), Temperature.FromCelsius(1.2 -273.15)),
            new ConversionProvider.Conversion<IQuantity>(Pressure.FromBars(1.2), Pressure.FromMegapascals(0.12)),
            new ConversionProvider.Conversion<IQuantity>(Pressure.FromNewtonsPerSquareMillimetre(1.2), Pressure.FromMegapascals(1.2)),
        };
    }
}
