namespace Gu.Units.Generator
{
    using System.Xml.Serialization;

    /// <summary>
    /// http://www.periodni.com/international_system_of_units.html
    /// </summary>
    public class SiUnit : UnitBase
    {
        public SiUnit()
            : base(null, null)
        {
        }

        public SiUnit(string name, string symbol)
            : base(name, symbol)
        {
        }

        [XmlIgnore]
        public override string UiName => this.Symbol;

        public override string ToString()
        {
            return $"{this.UiName} ({(this.Quantity == null ? "null" : this.Quantity.ClassName)})";
        }
    }
}
