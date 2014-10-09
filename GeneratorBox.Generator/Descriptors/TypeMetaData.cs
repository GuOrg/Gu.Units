namespace GeneratorBox.Generator
{
    using System;

    public class TypeMetaData : MarshalByRefObject
    {
        protected TypeMetaData()
        {
            
        }
        
        public TypeMetaData(string className)
        {
            ClassName = className;
        }
        
        public string ClassName { get; set; }
        
        public string ParameterName { get { return Char.ToLower(ClassName[0]) + ClassName.Substring(1); } }
        
        public override string ToString()
        {
            return ClassName;
        }
    }
}