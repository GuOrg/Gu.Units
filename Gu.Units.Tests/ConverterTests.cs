using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gu.Units.Tests
{
    using NUnit.Framework;

    public class ConverterTests
    {
        [TestCase(1.2)]
        public void Roundtrip(double value)
        {
            var dummyUnit = new DummyUnit();
            var si = UnitConverter.ConvertFrom(value, dummyUnit);
            var d = UnitConverter.ConvertTo(si, dummyUnit);
            Assert.AreEqual(value, d);
            var unitTypes = typeof(Meters).Assembly.GetTypes()
                           .Where(x => x.IsValueType && typeof(IUnit).IsAssignableFrom(x))
                           .ToArray();
            Assert.IsNotEmpty(unitTypes);
            foreach (var unitType in unitTypes)
            {
                Console.WriteLine(unitType.Name);
                si = UnitConverter.ConvertFrom(value, dummyUnit);
                d = UnitConverter.ConvertTo(si, dummyUnit);
                Assert.AreEqual(value, d);
            }
        }
    }

    public class DummyUnit : IUnit
    {
        public string Symbol { get; private set; }
        public double ToSiUnit(double value)
        {
            return 10 * value;
        }
    }
}
