namespace Gu.Units.Generator.Tests
{
    using NUnit.Framework;

    public class QuantityTests
    {
        private SiUnit _metres;
        private SiUnit _seconds;
        [SetUp]
        public void SetUp()
        {
            _metres = new SiUnit("", "Metres", "m") { QuantityName = "Length" };
            _seconds = new SiUnit("", "Seconds", "s");
        }

        [TestCase("Length", "Metres", "IQuantity<Metres, I1>")]
        public void BaseQuantityInterface(string quantityName, string unitName, string expected)
        {
            var quantity = new Quantity("Length", quantityName, _metres);
            var @interface = quantity.Interface;
            Assert.AreEqual(expected, @interface);
        }

        [TestCase(2, "IQuantity<Metres, I2>")]
        [TestCase(3, "IQuantity<Metres, I3>")]
        [TestCase(-2, "IQuantity<Metres, INeg2>")]
        public void PowerQuantityInterface(int power, string expected)
        {
            var unitAndPower = new UnitAndPower(_metres, power);
            var derivedUnit = new DerivedUnit("", "", "", unitAndPower);
            var quantity = new Quantity("", "", derivedUnit);
            var @interface = quantity.Interface;
            Assert.AreEqual(expected, @interface);
        }

        [TestCase(1, -1, "IQuantity<Metres, I1, Seconds, INeg1>")]
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
    }
}
