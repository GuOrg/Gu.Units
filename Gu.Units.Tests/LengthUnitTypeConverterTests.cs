namespace Gu.Units.Tests
{
    using System.ComponentModel.Design.Serialization;
    using NUnit.Framework;

    public class LengthUnitTypeConverterTests
    {
        [Test]
        public void StringRoundtrip()
        {
            var unit = LengthUnit.Millimetres;
            var converter = new LengthUnitTypeConverter();

            Assert.AreEqual(true, converter.CanConvertTo(typeof(string)));
            Assert.AreEqual(true, converter.CanConvertTo(null, typeof(string)));
            var convertTo = converter.ConvertTo(unit, typeof(string));
            Assert.AreEqual("mm", convertTo);

            Assert.AreEqual(true, converter.CanConvertFrom(typeof(string)));
            Assert.AreEqual(true, converter.CanConvertFrom(null, typeof(string)));

            var convertFrom = converter.ConvertFrom(convertTo);
            Assert.AreEqual(unit, convertFrom);
        }

        [Test]
        public void InstanceDescriptorRoundtrip()
        {
            var unit = LengthUnit.Millimetres;
            var converter = new LengthUnitTypeConverter();

            Assert.AreEqual(true, converter.CanConvertTo(typeof(InstanceDescriptor)));
            Assert.AreEqual(true, converter.CanConvertTo(null, typeof(InstanceDescriptor)));
            var convertTo = converter.ConvertTo(unit, typeof(InstanceDescriptor));

            Assert.AreEqual(true, converter.CanConvertFrom(typeof(InstanceDescriptor)));
            Assert.AreEqual(true, converter.CanConvertFrom(null, typeof(InstanceDescriptor)));

            var convertFrom = converter.ConvertFrom(convertTo);
            Assert.AreEqual(unit, convertFrom);
        }
    }
}
