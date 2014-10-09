using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorBox.Generator
{
    [Serializable]
    public class UnitValueDescriptor : MarshalByRefObject
    {
        public UnitValueDescriptor()
        {
            Properties = new List<Property>();
        }

        public string Namespace { get; set; }
        
        public string ClassName { get; set; }
        
        public IList<Property> Properties { get; set; }
    }
}
