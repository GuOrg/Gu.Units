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
            Units = new List<TemplateType>();
        }
        public UnitValueMetaData(string baseType, string ns, string className, params string[] units)
            : this()
        {
            BaseType = new TemplateType(baseType);
            Namespace = ns;
            ClassName = new TemplateType(className);
            Units = units.Select(x => new TemplateType(x)).ToArray();
        }
        public TemplateType BaseType { get; set; }

        public string Namespace { get; set; }

        public TemplateType ClassName { get; set; }

        public IList<TemplateType> Units { get; set; }
    }
}
