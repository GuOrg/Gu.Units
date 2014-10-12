namespace Gu.Units.Generator.Tests
{
    using System;
    using NUnit.Framework;

    public class QuantityTests
    {
        [TestCase("Length", "Metres", "IQuantity<IUnit1<I1<Metres>>>")]
        public void BaseQuantityInterface(string quantityName, string unitName, string expected)
        {
            var siUnit = new SiUnit { ClassName = unitName };
            var quantity = new Quantity("",quantityName , siUnit);
            var @interface = quantity.Interface;
            Assert.AreEqual(expected, @interface);
        }

        [TestCase("Length", "Metres", 2, "IQuantity<IUnit1<I2<Metres>>>")]
        [TestCase("Length", "Metres", 1, "IQuantity<IUnit1<I1<Metres>>>")]
        [TestCase("Length", "Metres", -2, "IQuantity<IUnit1<INeg2<Metres>>>")]
        public void ComposedQuantityInterface(string quantityName, string unitName, int power, string expected)
        {
            var siUnit = new SiUnit { ClassName = unitName };
            var unitAndPower = new UnitAndPower(siUnit, power);
            var quantity = new Quantity("", "Length", unitAndPower);
            var @interface = quantity.Interface;
            Assert.AreEqual(expected, @interface);
        }
    }
}
