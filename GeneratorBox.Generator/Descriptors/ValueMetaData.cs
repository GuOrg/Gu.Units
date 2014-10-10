using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorBox.Generator
{
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
    }
}
