namespace Gu.Units.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class QuantitiesProvider : IEnumerable<IQuantity>
    {
        public static readonly List<IQuantity> UnitTypes = new QuantityTypesProvider().Select(t => (IQuantity)Activator.CreateInstance(t))
                                                                                      .ToList();


        public IEnumerator<IQuantity> GetEnumerator()
        {
            return UnitTypes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}