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

        public UnitMetaData(string unitValueType, string ns, string className, double conversionFactor, string unitName)
            : base(className)
        {
            UnitValueType = new TypeMetaData(unitValueType);
            Namespace = ns;
            UnitName = unitName;
            ConversionFactor = conversionFactor.ToString(CultureInfo.InvariantCulture);
        }

        public TypeMetaData UnitValueType { get; set; }

        public string Namespace { get; set; }

        public string UnitName { get; set; }
       
        public string ConversionFactor { get; set; }
    }
}