namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Xml.Serialization;

    using Gu.Units.Generator.WpfStuff;
    /// <summary>
    /// http://en.wikipedia.org/wiki/SI_derived_unit
    /// </summary>
    [Serializable]
    public class DerivedUnit : UnitBase
    {
        private readonly UnitParts _parts;

        public DerivedUnit()
            : base(null, null)
        {
            _parts = new UnitParts(this);
        }

        public DerivedUnit(string name, string symbol, params UnitAndPower[] parts)
            : base(name, symbol)
        {
            _parts = new UnitParts(this);
            if (parts.Length == 0)
            {
                throw new ArgumentException("No units", "units");
            }
            if (parts.Length != parts.Select(x => x.Unit.ClassName).Distinct().Count())
            {
                throw new ArgumentException("Units must be distinct", "units");
            }
            var unitAndPowers = parts.OrderBy(x => x.UnitName).ThenBy(x => x.Power).ToList();
            foreach (var unitAndPower in unitAndPowers)
            {
                _parts.Add(unitAndPower);
            }
        }

        public UnitParts Parts
        {
            get
            {
                return _parts;
            }
            set // Needed for the converter to work
            {
                _parts.Clear();
                _parts.InvokeAddRange(value);
            }
        }

        [XmlIgnore]
        public override string UiName
        {
            get
            {
                return Parts.Expression;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}  ({1}) ({2})", Symbol, this.UiName, this.Quantity == null ? "null" : this.Quantity.ClassName);
        }
    }
}