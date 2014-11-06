namespace Gu.Units.Tests
{
    using System;
    using System.Globalization;

    using NUnit.Framework;

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
                              Length.From(Centimetres, LengthUnit.cm)
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
                              Length.From(Centimetres, LengthUnit.cm)
                          };
            foreach (var cm in cms)
            {
                Assert.AreEqual(12, cm.Millimetres);
                var millimetres = Length.FromMillimetres(cm.Millimetres);
                Assert.AreEqual(Centimetres, millimetres.Centimetres);
            }
        }

        [TestCaseSource(typeof(ConversionProvider))]
        public void Convert(ConversionProvider.IConversion<IQuantity> conversion)
        {
            Assert.AreEqual(conversion.FromQuantity, conversion.ToQuantity);
        }

        [Test, Explicit]
        public void DegRadFactor()
        {
            var d = Math.PI / 180;
            Console.WriteLine(d.ToString(CultureInfo.InvariantCulture));
            Console.WriteLine(d.ToString("G17", CultureInfo.InvariantCulture));
            Console.WriteLine(d.ToString("R", CultureInfo.InvariantCulture));
            Console.WriteLine((90 * d).ToString("R", CultureInfo.InvariantCulture));
        }

        [TestCaseSource(typeof(UnitsProvider))]
        public void Roundtrip(IUnit unit)
        {
            double[] values = { 0, 100 };
            foreach (var value in values)
            {
                var si = unit.ToSiUnit(value);
                var d = unit.FromSiUnit(si);
                Assert.AreEqual(value, d, 1E-9);
            }
        }
    }
}
