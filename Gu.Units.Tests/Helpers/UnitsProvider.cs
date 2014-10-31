namespace Gu.Units.Tests
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class UnitsProvider : IEnumerable<IUnit>
    {
        public static readonly List<IUnit> UnitTypes = typeof(Length).Assembly.GetTypes()
                                                                    .Where(x => x.IsValueType && typeof(IUnit).IsAssignableFrom(x))
                                                                    .SelectMany(t => t.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static)
                                                                                    .Where(f => typeof(IUnit).IsAssignableFrom(f.FieldType))
                                                                                    .Select(f => (IUnit)f.GetValue(null)))
                                                                    .ToList();

        public IEnumerator<IUnit> GetEnumerator()
        {
            return UnitTypes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}