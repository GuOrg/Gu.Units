namespace Gu.Units.Tests.Sources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuantitiesProvider : List<IQuantity>
    {
        public static readonly List<IQuantity> UnitTypes = new QuantityTypesProvider().Select(t => (IQuantity)Activator.CreateInstance(t))
                                                                                      .ToList();

        public QuantitiesProvider()
        {
            AddRange(UnitTypes);
        }
    }
}