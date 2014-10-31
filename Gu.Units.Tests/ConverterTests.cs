namespace Gu.Units.Tests
{
    using System;
    using NUnit.Framework;

    public class ConverterTests
    {
        [Test]
        public void CheckUnitTypeProvider()
        {
            Assert.IsNotEmpty(UnitsProvider.UnitTypes);
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
    }
}
