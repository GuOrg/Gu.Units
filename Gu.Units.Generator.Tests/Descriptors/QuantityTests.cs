namespace Gu.Units.Generator.Tests.Descriptors
{
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
            this._settings = new MockSettings();
            this._metres = this._settings.Metres;
            this._seconds = this._settings.Seconds;
        }

        [TestCase("Length", "IQuantity<LengthUnit, I1>")]
        public void BaseQuantityInterface(string quantityName, string expected)
        {
            var quantity = this._settings.Length;
            var @interface = quantity.Interface;
            Assert.AreEqual(expected, @interface);
        }

        [TestCase(2, "IQuantity<LengthUnit, I2>")]
        [TestCase(3, "IQuantity<LengthUnit, I3>")]
        [TestCase(-2, "IQuantity<LengthUnit, INeg2>")]
        public void PowerQuantityInterface(int power, string expected)
        {
            var unitAndPower = new UnitAndPower(this._metres, power);
            var derivedUnit = new DerivedUnit("sdf", "ssf", unitAndPower) { QuantityName = "Qty" };
            var quantity = new Quantity(derivedUnit);
            var @interface = quantity.Interface;
            Assert.AreEqual(expected, @interface);
        }

        [TestCase(1, -1, "IQuantity<LengthUnit, I1, TimeUnit, INeg1>")]
        public void ComposedQuantityInterface(int p1, int p2, string expected)
        {
            var unitAndPower1 = new UnitAndPower(this._metres, p1);
            var unitAndPower2 = new UnitAndPower(this._seconds, p2);
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
            var actual = this._settings.Length.OperatorOverloads.ToArray();
            var expected = new[]
                               {
                                   new OperatorOverload(this._settings.Length, this._settings.Time, this._settings),
                                   new OperatorOverload(this._settings.Length, this._settings.Speed, this._settings),
                                   new OperatorOverload(this._settings.Length, this._settings.Energy, this._settings),
                                   new OperatorOverload(this._settings.Length, this._settings.Area, this._settings),
                                   new OperatorOverload(this._settings.Length, this._settings.Volume, this._settings)
                               };
            CollectionAssert.AreEqual(expected.Select(x => x.ToString()), actual.Select(x => x.ToString()));
        }

        [Test]
        public void TimeOverloads()
        {
            var actual = this._settings.Time.OperatorOverloads.ToArray();
            var expected = new[]
                               {
                                   new OperatorOverload(this._settings.Time, this._settings.Length, this._settings),
                                   new OperatorOverload(this._settings.Time, this._settings.ElectricCharge, this._settings),
                               };
            CollectionAssert.AreEqual(expected.Select(x => x.ToString()), actual.Select(x => x.ToString()));
        }

        [Test]
        public void Inversions()
        {
            var actual = this._settings.Time.Inverse;
            Assert.AreEqual("1 / Time = Frequency", actual.ToString());
            Assert.IsNull(this._settings.Length.Inverse);
        }
    }
}
