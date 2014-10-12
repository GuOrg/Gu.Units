namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml.Serialization;

    [Serializable]
    public class Unit : TypeMetaData
    {
        private Unit()
            : base()
        {
            Quantity = new TypeMetaData("");
            Related = new List<Unit>();
        }

        public Unit(string quantityType, string ns, string unitTypeName, double conversion, string symbol)
            : this(quantityType, ns,unitTypeName,conversion == 0 ? "" : conversion.ToString(CultureInfo.InvariantCulture), symbol)
        {
        }

        public Unit(string quantityType, string ns, string unitTypeName, string conversion, string symbol)
            : base(unitTypeName)
        {
            Related = new List<Unit>();
            Quantity = new TypeMetaData(quantityType);
            Namespace = ns;
            Symbol = symbol;
            Conversion = conversion;
        }

        public static Unit Empty
        {
            get
            {
                return new Unit("", "", "", 0, "");
            }
        }

        public TypeMetaData Quantity { get; set; }

        public string Namespace { get; set; }

        public string Symbol { get; set; }

        public string Conversion { get; set; }
       
        [XmlIgnore]
        public SiUnit SiUnit { get; set; }

        [XmlIgnore]
        public bool IsEmpty
        {
            get
            {
                if (!string.IsNullOrEmpty(Symbol))
                {
                    return false;
                }
                return true;
            }
        }

        [XmlIgnore]
        public List<Unit> Related { get; set; } 

        public override string ToString()
        {
            return string.Format("{0}, Quantity: {1}, Namespace: {2}, Symbol: {3}, Conversion: {4}, IsEmpty: {5}", base.ToString(), this.Quantity, this.Namespace, this.Symbol, this.Conversion, this.IsEmpty);
        }
    }
}