namespace Gu.Units.Tests
{
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    public static class UnitRoundtripTests
    {
        public static readonly IUnit[] Units = typeof(Length).Assembly.GetTypes()
            .Where(x => x.IsValueType && typeof(IUnit).IsAssignableFrom(x))
            .SelectMany(t => t.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static)
                .Where(f => typeof(IUnit).IsAssignableFrom(f.FieldType))
                .Select(f => (IUnit)f.GetValue(null)))
            .ToArray();

        [TestCaseSource(nameof(Units))]
        public static void SiUnit(IUnit unit)
        {
            double[] values = { 0, 100 };
            foreach (var value in values)
            {
                var si = unit.ToSiUnit(value);
                var d = unit.FromSiUnit(si);
                Assert.AreEqual(value, d, 1E-9);
            }
        }

        [TestCaseSource(nameof(Units))]
        public static void Parse(IUnit unit)
        {
            var s = unit.ToString();
#pragma warning disable REFL003 // The member does not exist.
            var parseMethod = unit.GetType().GetMethod("Parse", BindingFlags.Static | BindingFlags.Public);
#pragma warning restore REFL003 // The member does not exist.
            var roundtripped = (IUnit)parseMethod.Invoke(null, new object[] { s });
            Assert.AreEqual(unit, roundtripped);
        }

        [TestCaseSource(nameof(Units))]
        public static void CreateQuantity(IUnit unit)
        {
            double[] values = { 0, 1.2 };
            foreach (var value in values)
            {
                dynamic u = unit;
                var qty = u.CreateQuantity(value); // Hacking it with dynamic here
                Assert.IsInstanceOf<IQuantity>(qty);

                var d = qty.GetValue(u);
                Assert.AreEqual(value, d, 1E-9);

                d = u.GetScalarValue(qty);
                Assert.AreEqual(value, d, 1E-9);
            }
        }
    }
}