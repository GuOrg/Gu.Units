namespace GeneratorBox.Generator
{
    using System;

    public class TemplateType : MarshalByRefObject
    {
        private TemplateType()
        {
            
        }
        public TemplateType(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public string ParameterName { get { return Char.ToLower(Name[0]) + Name.Substring(1); } }
        public override string ToString()
        {
            return Name;
        }
    }
}