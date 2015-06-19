namespace Gu.Units.Tests.Sources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuantityTypesProvider : List<Type>
    {
        public static readonly List<Type> UnitTypes = typeof(Length).Assembly.GetTypes()
                                                                    .Where(x => x.IsValueType && typeof(IQuantity).IsAssignableFrom(x))
                                                                    .ToList();

        public QuantityTypesProvider()
        {
            AddRange(UnitTypes);
        }
    }
}