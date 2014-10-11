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
        public void Roundtrip(Type unitType)
        {
            double[] values = { 0, 100 };
            var unit = (IUnit)Activator.CreateInstance(unitType);
            foreach (var value in values)
            {
                Console.WriteLine(unitType.Name);
                var si = UnitConverter.ConvertFrom(value, unit);
                var d = UnitConverter.ConvertTo(si, unit);
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
