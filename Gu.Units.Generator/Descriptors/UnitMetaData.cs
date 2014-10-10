namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml.Serialization;

    [Serializable]
    public class UnitMetaData : TypeMetaData
    {
        private UnitMetaData()
            : base()
        {
            ValueType = new TypeMetaData("");
            Related = new List<UnitMetaData>();
        }

        public UnitMetaData(string valueType, string ns, string unitTypeName, double conversionFactor, string symbol)
            : this(valueType, ns,unitTypeName,conversionFactor == 0 ? "" : conversionFactor.ToString(CultureInfo.InvariantCulture), symbol)
        {
        }

        public UnitMetaData(string valueType, string ns, string unitTypeName, string conversionFactor, string symbol)
            : base(unitTypeName)
        {
            Related = new List<UnitMetaData>();
            ValueType = new TypeMetaData(valueType);
            Namespace = ns;
            Symbol = symbol;
            ConversionFactor = conversionFactor;
        }

        public static UnitMetaData Empty
        {
            get
            {
                return new UnitMetaData("", "", "", 0, "");
            }
        }

        public TypeMetaData ValueType { get; set; }

        public string Namespace { get; set; }

        public string Symbol { get; set; }

        public string ConversionFactor { get; set; }

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
        public List<UnitMetaData> Related { get; set; } 

        public override string ToString()
        {
            return string.Format("{0}, ValueType: {1}, Namespace: {2}, Symbol: {3}, ConversionFactor: {4}, IsEmpty: {5}", base.ToString(), this.ValueType, this.Namespace, this.Symbol, this.ConversionFactor, this.IsEmpty);
        }
    }
}