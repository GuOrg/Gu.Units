namespace Gu.Units.Tests
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using NUnit.Framework;

    public class SerializationTests
    {
        [Test]
        public void RoundtripXml()
        {
            var length = new Length(1.2, LengthUnit.Metres);
            var roundtrip = Roundtrip(length);
            Assert.AreEqual(length, roundtrip);
            var dummy = new Dummy(length);
            var roundtripDummy = Roundtrip(dummy);
            Assert.AreEqual(length, roundtripDummy.Length);
        }

        private T Roundtrip<T>(T value)
        {
            var serializer = new XmlSerializer(typeof(T));
            var builder = new StringBuilder();
            string xml;
            using (var writer = new StringWriter(builder))
            {
                serializer.Serialize(writer, value);
                xml = builder.ToString();
                //Assert.AreEqual(@"<Length Value=""1.2"" />",);
            }
            using (var reader = new StringReader(xml))
            {
                var deserialize = (T)serializer.Deserialize(reader);
                return deserialize;
            }
        }

        public class Dummy
        {
            private Dummy()
            {
            }

            public Dummy(Length length)
            {
                Length = length;
            }

            public Length Length { get; set; }
        }
    }
}
