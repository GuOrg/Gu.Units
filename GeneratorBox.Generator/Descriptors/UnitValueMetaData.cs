using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorBox.Generator
{
    [Serializable]
    public class UnitValueMetaData : MarshalByRefObject
    {
        private UnitValueMetaData()
        {
            Units = new List<TypeMetaData>();
        }
        public UnitValueMetaData(string baseType, string ns, string className, params string[] units)
            : this()
        {
            BaseType = new TypeMetaData(baseType);
            Namespace = ns;
            ClassName = new TypeMetaData(className);
            Units = units.Select(x => new TypeMetaData(x)).ToArray();
        }
        public TypeMetaData BaseType { get; set; }

        public string Namespace { get; set; }

        public TypeMetaData ClassName { get; set; }

        public IList<TypeMetaData> Units { get; set; }
    }
}
