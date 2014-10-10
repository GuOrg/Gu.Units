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
        }

        public UnitMetaData(string valueType, string ns, string className, double conversionFactor, string unitName)
            : base(className)
        {
            ValueType = new TypeMetaData(valueType);
            Namespace = ns;
            UnitName = unitName;
            ConversionFactor = conversionFactor.ToString(CultureInfo.InvariantCulture);
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
    }
}