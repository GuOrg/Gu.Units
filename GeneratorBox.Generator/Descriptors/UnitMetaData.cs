namespace GeneratorBox.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    [Serializable]
    public class UnitMetaData : TypeMetaData
    {
        private UnitMetaData()
            : base()
        {
            ValueType = new TypeMetaData("");
        }

        public UnitMetaData(string valueType, string ns, string unitTypeName, double conversionFactor, string unitName)
            : base(unitTypeName)
        {
            ValueType = new TypeMetaData(valueType);
            Namespace = ns;
            UnitName = unitName;
            ConversionFactor = conversionFactor == 0 ? "" : conversionFactor.ToString(CultureInfo.InvariantCulture);
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

        public string UnitName { get; set; }

        public string ConversionFactor { get; set; }

        public bool IsEmpty
        {
            get
            {
                if (!string.IsNullOrEmpty(ValueType.ClassName))
                {
                    return false;
                }
                if (!string.IsNullOrEmpty(Namespace))
                {
                    return false;
                }
                if (!string.IsNullOrEmpty(UnitName))
                {
                    return false;
                }
                if (!string.IsNullOrEmpty(ConversionFactor))
                {
                    return false;
                }
                return true;
            }
        }
    }
}