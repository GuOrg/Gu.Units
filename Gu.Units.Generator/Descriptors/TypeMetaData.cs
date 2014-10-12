namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using WpfStuff;

    [TypeConverter(typeof(TypeMetaDataConverter))]
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

        public string ParameterName
        {
            get
            {
                if (string.IsNullOrEmpty(ClassName))
                {
                    return "### ERROR string.IsNullOrEmpty(TypeMetaData.Type)";
                }
                return Char.ToLower(ClassName[0]) + ClassName.Substring(1);
            }
        }

        public override string ToString()
        {
            return ClassName;
        }
    }
}