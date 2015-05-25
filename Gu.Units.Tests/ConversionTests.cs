namespace Gu.Units.Tests
{
    using System;
    using System.Globalization;

    using Gu.Units.Tests.Helpers;

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

        [TestCaseSource(typeof(UnitsProvider))]
        public void Roundtrip2(IUnit unit)
        {
            double[] values = { 0, 1.2 };
            foreach (var value in values)
            {
                dynamic u = (dynamic)unit;
                var qty = u.CreateQuantity(value); // Hacking it with dynamic here
                Assert.IsInstanceOf<IQuantity>(qty);
                
                var d = qty.GetValue(u);
                Assert.AreEqual(value, d, 1E-9);

                d = u.GetScalarValue(qty);
                Assert.AreEqual(value, d, 1E-9);
            }
        }
    }
}
