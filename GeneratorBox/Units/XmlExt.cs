namespace GeneratorBox
{
    using System;
    using System.Xml;
    using System.Xml.Linq;

    public class XmlExt
    {
        public static void SetReadonlyField<T>(ref T force, Func<T, object> func, double toDouble)
        {
            throw new NotImplementedException();
        }

        public static string ReadAttributeOrElementOrDefault(XElement xElement, string value)
        {
            throw new NotImplementedException();
        }

        public static void WriteAttribute(XmlWriter writer, string value, double newtons)
        {
            throw new NotImplementedException();
        }
    }
}