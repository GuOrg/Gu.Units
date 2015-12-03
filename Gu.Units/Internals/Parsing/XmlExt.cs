namespace Gu.Units
{
    using System.Reflection;
    using System.Xml;

    internal static class XmlExt
    {
        internal static void SetReadonlyField<T>(ref T self, string fieldName, XmlReader reader, string attributeName)
            where T : IQuantity
        {
            reader.MoveToContent();
            var d = XmlConvert.ToDouble(reader.GetAttribute(attributeName));
            reader.ReadStartElement();
            SetReadonlyField(ref self, fieldName, d);
        }

        private static void SetReadonlyField<T>(ref T self, string fieldName, double value)
            where T : IQuantity
        {
            var fieldInfo = self.GetType()
                                .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            object boxed = self;
            fieldInfo.SetValue(boxed, value);
            self = (T)boxed;
        }

        internal static void WriteAttribute(XmlWriter writer, string name, double value)
        {
            writer.WriteStartAttribute(name);
            writer.WriteValue(value);
            writer.WriteEndAttribute();
        }
    }
}