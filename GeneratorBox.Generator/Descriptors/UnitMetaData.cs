namespace GeneratorBox.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Serializable]
    public class UnitMetaData : TypeMetaData
    {
        private UnitMetaData() 
            : base()
        {
        }

        public UnitMetaData(string unitValueType, string ns, string className)
            : base(className)
        {
            UnitValueType = new TypeMetaData(unitValueType);
            Namespace = ns;
        }

        public TypeMetaData UnitValueType { get; set; }

        public string Namespace { get; set; }

        public string UnitName { get; set; }
       
        public string ConversionFactor { get; set; }
    }
}