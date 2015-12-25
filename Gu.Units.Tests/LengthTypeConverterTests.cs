namespace Gu.Units.Tests
{
    using System.ComponentModel.Design.Serialization;
    using System.Globalization;
    using NUnit.Framework;

    public class LengthTypeConverterTests
    {
        [Test]
        public void StringRoundtrip()
        {
            var length = Length.FromMillimetres(1.2);
            var converter = new LengthTypeConverter();

            Assert.AreEqual(true, converter.CanConvertTo(typeof(string)));
            Assert.AreEqual(true, converter.CanConvertTo(null, typeof(string)));
            var convertTo = converter.ConvertTo(null, CultureInfo.InvariantCulture, length, typeof(string));
            Assert.AreEqual("0.0012\u00A0m", convertTo);

            Assert.AreEqual(true, converter.CanConvertFrom(typeof(string)));
            Assert.AreEqual(true, converter.CanConvertFrom(null, typeof(string)));

            var convertFrom = converter.ConvertFrom(null, CultureInfo.InvariantCulture, convertTo);
            Assert.AreEqual(length, convertFrom);
        }

        [Test]
        public void InstanceDescriptorRoundtrip()
        {
            var length = Length.FromMillimetres(1.2);
            var converter = new LengthTypeConverter();

            Assert.AreEqual(true, converter.CanConvertTo(typeof(InstanceDescriptor)));
            Assert.AreEqual(true, converter.CanConvertTo(null, typeof(InstanceDescriptor)));
            var convertTo = converter.ConvertTo(length, typeof(InstanceDescriptor));

            Assert.AreEqual(true, converter.CanConvertFrom(typeof(InstanceDescriptor)));
            Assert.AreEqual(true, converter.CanConvertFrom(null, typeof(InstanceDescriptor)));

            var convertFrom = converter.ConvertFrom(convertTo);
            Assert.AreEqual(length, convertFrom);
        }
    }
}