namespace Gu.Units.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class QuantityTypesProvider : IEnumerable<Type>
    {
        public static readonly List<Type> UnitTypes = typeof(Length).Assembly.GetTypes()
                                                                    .Where(x => x.IsValueType && typeof(IQuantity).IsAssignableFrom(x))
                                                                    .ToList();

        public IEnumerator<Type> GetEnumerator()
        {
            return UnitTypes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}