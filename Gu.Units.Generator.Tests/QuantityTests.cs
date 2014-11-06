namespace Gu.Units.Generator.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    public class QuantityTests
    {
        private IUnit _metres;
        private IUnit _seconds;
        private MockSettings _settings;
        [SetUp]
        public void SetUp()
        {
            _settings = new MockSettings();
            _metres = _settings.Metres;
            _seconds = _settings.Seconds;
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
            var derivedUnit = new DerivedUnit("sdf", "ssf", unitAndPower) { QuantityName = "Qty" };
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
                new Quantity(new DerivedUnit("", "", unitAndPower1, unitAndPower2)),
                new Quantity(new DerivedUnit("", "", unitAndPower2, unitAndPower1))
            };
            foreach (var quantity in quantities)
            {
                var @interface = quantity.Interface;
                Assert.AreEqual(expected, @interface);
            }
        }

        [Test]
        public void LengthOverloads()
        {
            var actual = _settings.Length.OperatorOverloads.ToArray();
            var expected = new[]
                               {
                                   new OperatorOverload(_settings.Length, _settings.Time, _settings),
                                   new OperatorOverload(_settings.Length, _settings.Speed, _settings),
                                   new OperatorOverload(_settings.Length, _settings.Energy, _settings),
                                   new OperatorOverload(_settings.Length, _settings.Area, _settings),
                                   new OperatorOverload(_settings.Length, _settings.Volume, _settings)
                               };
            CollectionAssert.AreEqual(expected.Select(x => x.ToString()), actual.Select(x => x.ToString()));
        }

        [Test]
        public void TimeOverloads()
        {
            var actual = _settings.Time.OperatorOverloads.ToArray();
            var expected = new[]
                               {
                                   new OperatorOverload(_settings.Time, _settings.Length, _settings),
                                   new OperatorOverload(_settings.Time, _settings.ElectricCharge, _settings),
                               };
            CollectionAssert.AreEqual(expected.Select(x => x.ToString()), actual.Select(x => x.ToString()));
        }

        [Test]
        public void Inversions()
        {
            var actual = _settings.Time.Inverse;
            Assert.AreEqual(_settings.Frequency.ToString(), actual.ToString());
            Assert.IsNull(_settings.Length.Inverse);
        }
    }
}
