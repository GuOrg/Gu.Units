using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorBox.Generator
{
    [Serializable]
    public class UnitValue : MarshalByRefObject
    {
        private UnitValue()
        {
            Units = new List<TemplateType>();
        }
        public UnitValue(string baseType, string ns, string className, params string[] units)
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
