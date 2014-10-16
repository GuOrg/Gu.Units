namespace Gu.Units.Tests
{
    using System;
    using NUnit.Framework;

    public class ConverterTests
    {
        [Test]
        public void CheckUnitTypeProvider()
        {
            Assert.IsNotEmpty(UnitTypeProvider.UnitTypes);
        }

        [TestCaseSource(typeof(UnitTypeProvider))]
        public void Roundtrip(IUnit unit)
        {
            double[] values = { 0, 100 };
            foreach (var value in values)
            {
                var si = unit.ToSiUnit(value);
                var d = unit.FromSiUnit(si);
                Assert.AreEqual(value, d);
            }
        }

        [TestCase(0)]
        [TestCase(100)]
        public void RoundtripDummy(double value)
        {
            var dummyUnit = new DummyUnit();
            var si = UnitConverter.ConvertFrom(value, dummyUnit);
            var d = UnitConverter.ConvertTo(si, dummyUnit);
            Assert.AreEqual(value, d);
        }
    }
}
