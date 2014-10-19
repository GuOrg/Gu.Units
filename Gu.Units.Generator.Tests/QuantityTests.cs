namespace Gu.Units.Generator.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    public class QuantityTests
    {
        private IUnit _metres;
        private string Namespace;
        private IUnit _seconds;
        private MockSettings _settings;
        [SetUp]
        public void SetUp()
        {
            _settings = new MockSettings();
            _metres = _settings.Metres;
            _seconds = _settings.Seconds;
            Namespace = _settings.Namespace;
        }

        [TestCase("Length", "IQuantity<LengthUnit, I1>")]
        public void BaseQuantityInterface(string quantityName, string expected)
        {
            var quantity = _settings.Length;
            var @interface = quantity.Interface;
            Assert.AreEqual(expected, @interface);
        }

        [TestCase(2, "IQuantity<LengthUnit, I2>")]
        [TestCase(3, "IQuantity<LengthUnit, I3>")]
        [TestCase(-2, "IQuantity<LengthUnit, INeg2>")]
        public void PowerQuantityInterface(int power, string expected)
        {
            var unitAndPower = new UnitAndPower(_metres, power);
            var derivedUnit = new DerivedUnit(Namespace, "sdf", "ssf", unitAndPower) { QuantityName = "Qty" };
            var quantity = new Quantity(derivedUnit);
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
                new Quantity(new DerivedUnit("", "", "", unitAndPower1, unitAndPower2)),
                new Quantity(new DerivedUnit("", "", "", unitAndPower2, unitAndPower1))
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
            var overloads = _settings.Length.OperatorOverloads;
            Assert.Inconclusive();
        }
    }
}
