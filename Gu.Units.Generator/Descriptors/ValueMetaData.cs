namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Serializable]
    public class ValueMetaData : MarshalByRefObject
    {
        private ValueMetaData()
        {
            Units = new List<UnitMetaData>();
        }
        public ValueMetaData(UnitMetaData siUnit, string ns, string className, params UnitMetaData[] units)
            : this()
        {
            Namespace = ns;
            ClassName = new TypeMetaData(className);
            SiUnit = siUnit;
            Units = units.ToList();
        }

        public static ValueMetaData Empty
        {
            get
            {
                return new ValueMetaData(UnitMetaData.Empty, "", "");
            }
        }

        public UnitMetaData SiUnit { get; set; }

        public string Namespace { get; set; }

        public TypeMetaData ClassName { get; set; }

        public List<UnitMetaData> Units { get; set; }

        public override string ToString()
        {
            return string.Format("SiUnit: {0}, Namespace: {1}, ClassName: {2}, Units: {3}", this.SiUnit, this.Namespace, this.ClassName,string.Join(Environment.NewLine, this.Units.Select(x=>x.ToString())));
        }
    }
}
