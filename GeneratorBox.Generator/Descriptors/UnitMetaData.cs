namespace GeneratorBox.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Serializable]
    public class UnitMetaData : MarshalByRefObject
    {
        private UnitMetaData()
        {
            Units = new List<TemplateType>();
        }
        public UnitMetaData(string baseType, string ns, string className, params string[] units)
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