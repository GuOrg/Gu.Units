namespace GeneratorBox.Generator
{
    using System;

    [Serializable]
    public class Field : MarshalByRefObject
    {
        public string Readonly { get; set; }
        public string ReturnType { get; set; }
        public string Name { get; set; }
    }
}