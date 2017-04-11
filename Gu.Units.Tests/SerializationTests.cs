namespace Gu.Units.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using NUnit.Framework;

    public class SerializationTests
    {
        public static readonly List<Type> QuantityTypes = typeof(Length).Assembly.GetTypes()
            .Where(x => x.IsValueType && typeof(IQuantity).IsAssignableFrom(x))
            .ToList();

        [TestCaseSource(nameof(QuantityTypes))]
        public void XmlSerializer(Type quantityType)
        {
            var ctor = quantityType.GetConstructor(
                        BindingFlags.NonPublic | BindingFlags.Instance,
                        null,
                        new[] { typeof(double) },
                        null);
            var quantity = ctor.Invoke(new object[] { 1.2 });
            var serializer = new XmlSerializer(quantityType);
            var stringBuilder = new StringBuilder();
            string xml;
            using (var writer = new StringWriter(stringBuilder))
            {
                serializer.Serialize(writer, quantity);
                xml = stringBuilder.ToString();
                Console.Write(xml);
                var expected = $"<?xml version=\"1.0\" encoding=\"utf-16\"?>" + Environment.NewLine +
                               $"<{quantity.GetType().Name} Value=\"1.2\" />";
                Assert.AreEqual(expected, xml);
            }

            using (var reader = new StringReader(xml))
            {
                var deserialized = serializer.Deserialize(reader);
                Assert.AreEqual(deserialized, quantity);
            }
        }

        [TestCaseSource(nameof(QuantityTypes))]
        public void DataContractSerializer(Type quantityType)
        {
            var ctor = quantityType.GetConstructor(
                        BindingFlags.NonPublic | BindingFlags.Instance,
                        null,
                        new[] { typeof(double) },
                        null);
            var quantity = ctor.Invoke(new object[] { 1.2 });
            var serializer = new DataContractSerializer(quantityType);
            var stringBuilder = new StringBuilder();
            string xml;
            using (var writer = XmlWriter.Create(stringBuilder))
            {
                serializer.WriteObject(writer, quantity);
                writer.Flush();
                xml = stringBuilder.ToString();
                Console.Write(xml);
                var expected = $"<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                               $"<{quantity.GetType().Name} Value=\"1.2\" xmlns=\"http://schemas.datacontract.org/2004/07/Gu.Units\" />";
                Assert.AreEqual(expected, xml);
            }

            using (var reader = XmlReader.Create(new StringReader(xml)))
            {
                var deserialized = serializer.ReadObject(reader);
                Assert.AreEqual(deserialized, quantity);
            }
        }

        [TestCaseSource(nameof(QuantityTypes))]
        public void BinaryFormatter(Type quantityType)
        {
            var ctor = quantityType.GetConstructor(
                        BindingFlags.NonPublic | BindingFlags.Instance,
                        null,
                        new[] { typeof(double) },
                        null);
            var quantity = ctor.Invoke(new object[] { 1.2 });
            var binaryFormatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                binaryFormatter.Serialize(stream, quantity);
                stream.Position = 0;
                var deserialized = binaryFormatter.Deserialize(stream);
                Assert.AreEqual(deserialized, quantity);
            }
        }
    }
}
