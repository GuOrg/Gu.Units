namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Voltage"/>.
    /// </summary>
    [Serializable]
    public class VoltageJsonConverter : JsonConverter
    {
        public static readonly VoltageJsonConverter Default = new VoltageJsonConverter(VoltageUnit.Volts);
        public static readonly VoltageJsonConverter Volts = new VoltageJsonConverter(VoltageUnit.Volts);
        public static readonly VoltageJsonConverter Millivolts = new VoltageJsonConverter(VoltageUnit.Millivolts);
        public static readonly VoltageJsonConverter Kilovolts = new VoltageJsonConverter(VoltageUnit.Kilovolts);
        public static readonly VoltageJsonConverter Megavolts = new VoltageJsonConverter(VoltageUnit.Megavolts);
        public static readonly VoltageJsonConverter Microvolts = new VoltageJsonConverter(VoltageUnit.Microvolts);

        private readonly VoltageUnit unit;

        private VoltageJsonConverter(VoltageUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var voltage = (Voltage)value;
            serializer.Serialize(writer, voltage.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Voltage);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Voltage.Parse(stringValue, serializer.Culture);
        }
    }
}