namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// http://en.wikipedia.org/wiki/SI_derived_unit
    /// </summary>
    [DebuggerDisplay("{Name} {Symbol} {QuantityName}")]
    [Serializable]
    public class DerivedUnit : Unit
    {
        public DerivedUnit(string name, string symbol, string quantityName, IReadOnlyList<UnitAndPower> parts)
            : base(name, symbol, quantityName)
        {
            Ensure.NotNullOrEmpty(parts, nameof(parts));
            Ensure.Distinct(parts, x => x.UnitName, nameof(parts));
            Parts = new UnitParts(parts);
        }

        public override UnitParts Parts { get; }
    }
}