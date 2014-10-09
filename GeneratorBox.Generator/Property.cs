namespace GeneratorBox.Generator
{
    using System;

    [Serializable]
    public class Property : MarshalByRefObject
    {
        public string ReturnType { get; set; }
        public string PropertyName { get; set; }
    }
}