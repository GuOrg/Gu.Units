namespace GeneratorBox.Generator
{
    using System;

    [Serializable]
    public class Field : MarshalByRefObject
    {
        private string _readonly;

        public string Readonly
        {
            get
            {
                return _readonly;
            }
            set
            {
                _readonly = value.EndsWith(" ") ? value : value + " ";
            }
        }

        public string ReturnType { get; set; }
        public string Name { get; set; }
    }
}