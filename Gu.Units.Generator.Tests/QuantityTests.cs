﻿namespace Gu.Units.Generator.Tests
{
    using System.Xml;

    using NUnit.Framework;

    public class QuantityTests
    {
        private const string Namespace ="Gu.Units";
        private SiUnit _metres;
        private SiUnit _seconds;
        private Quantity _length;
        private Quantity _time;

        [SetUp]
        public void SetUp()
        {
            _metres = new SiUnit(Namespace, "Metres", "m");
            _seconds = new SiUnit(Namespace, "Seconds", "s");
            _length = new Quantity(Namespace, "Length", _metres);
            _time = new Quantity(Namespace, "Time", _seconds);
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
    }
}
