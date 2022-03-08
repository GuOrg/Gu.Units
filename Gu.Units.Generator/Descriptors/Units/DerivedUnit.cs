namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// http://en.wikipedia.org/wiki/SI_derived_unit.
    /// </summary>
    [DebuggerDisplay("{Name} {Symbol} {QuantityName}")]
    public class DerivedUnit : Unit
    {
        public DerivedUnit(string name, string symbol, string quantityName, IReadOnlyList<UnitAndPower> parts)
            : base(name, symbol, quantityName)
        {
            if (parts is null)
            {
                throw new ArgumentNullException(nameof(parts));
            }

            if (parts.Count == 0)
            {
                throw new ArgumentException("Empty parts", nameof(parts));
            }

            if (parts.Select(x => x.UnitName).Distinct().Count() != parts.Count)
            {
                throw new ArgumentException($"Expected parts to be have only distinct entries", nameof(parts));
            }

            this.Parts = new UnitParts(parts);
        }

        public override UnitParts Parts { get; }
    }
}
