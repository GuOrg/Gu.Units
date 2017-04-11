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
            var attribute = reader.GetAttribute(attributeName);
            if (attribute == null)
            {
                throw new XmlException($"Could not find attribute named: {attributeName}");
            }

            var d = XmlConvert.ToDouble(attribute);
            reader.ReadStartElement();
            SetReadonlyField(ref self, fieldName, d);
        }

        private static void SetReadonlyField<T>(ref T self, string fieldName, double value)
            where T : IQuantity
        {
            var fieldInfo = self.GetType()
                                .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo == null)
            {
                throw new XmlException($"Could not find field named: {fieldName}");
            }

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