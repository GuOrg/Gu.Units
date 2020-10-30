namespace Gu.Units.Generator
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// http://www.periodni.com/international_system_of_units.html.
    /// </summary>
    [DebuggerDisplay("{Name} {Symbol} {QuantityName}")]
    [Serializable]
    public class BaseUnit : Unit
    {
        public BaseUnit(string name, string symbol, string quantityName)
            : base(name, symbol, quantityName)
        {
            this.Parts = new UnitParts(new[] { UnitAndPower.Create(this) });
        }

        public override UnitParts Parts { get; }
    }
}
