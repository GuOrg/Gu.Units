namespace Gu.Units.Generator.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    public class QuantityTests
    {
        private Quantity[] _quantities;
        private IUnit _metres;
        private string Namespace;
        private IUnit _seconds;
        [SetUp]
        public void SetUp()
        {
            var settings = new MockSettings();
            _quantities = settings.Quantities;
            _metres = settings.Metres;
            _seconds = settings.Seconds;
            Namespace = settings.Namespace;
        }

        [TestCase("Length", "Metres", "IQuantity<LengthUnit, I1>")]
        public void BaseQuantityInterface(string quantityName, string unitName, string expected)
        {
            var quantity = new Quantity(Namespace, quantityName, _metres);
            var @interface = quantity.Interface;
            Assert.AreEqual(expected, @interface);
        }

        [TestCase(2, "IQuantity<LengthUnit, I2>")]
        [TestCase(3, "IQuantity<LengthUnit, I3>")]
        [TestCase(-2, "IQuantity<LengthUnit, INeg2>")]
        public void PowerQuantityInterface(int power, string expected)
        {
            var unitAndPower = new UnitAndPower(_metres, power);
            var derivedUnit = new DerivedUnit(Namespace, "sdf", "ssf", unitAndPower);
            var quantity = new Quantity(Namespace, "Qty", derivedUnit);
            var @interface = quantity.Interface;
            Assert.AreEqual(expected, @interface);
        }

        [TestCase(1, -1, "IQuantity<LengthUnit, I1, TimeUnit, INeg1>")]
        public void ComposedQuantityInterface(int p1, int p2, string expected)
        {
            var unitAndPower1 = new UnitAndPower(_metres, p1);
            var unitAndPower2 = new UnitAndPower(_seconds, p2);
            var quantities = new[]
            {
                new Quantity("", "", new DerivedUnit("", "", "", unitAndPower1, unitAndPower2)),
                new Quantity("", "", new DerivedUnit("", "", "", unitAndPower2, unitAndPower1))
            };
            foreach (var quantity in quantities)
            {
                var @interface = quantity.Interface;
                Assert.AreEqual(expected, @interface);
            }
        }

        [Test]
        public void FindOverloads()
        {
            foreach (var quantity in _quantities.Where(x => x.Unit is DerivedUnit))
            {
                var derivedUnit = quantity.Unit as DerivedUnit;
                var unitParts = derivedUnit.Parts;
                foreach (var up in unitParts)
                {
                    if (up.Power > 0)
                    {
                        var left = up.Unit.Quantity;
                        left.OperatorOverloads.Add(new OperatorOverload(left, quantity));
                        quantity.OperatorOverloads.Add(new OperatorOverload(quantity, left));
                    }
                }
            }
            Assert.Inconclusive();
        }
    }
}
