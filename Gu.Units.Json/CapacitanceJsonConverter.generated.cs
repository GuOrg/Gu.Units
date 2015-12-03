namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Capacitance"/>.
    /// </summary>
    [Serializable]
    public class CapacitanceJsonConverter : JsonConverter
    {
        public static readonly CapacitanceJsonConverter Default = new CapacitanceJsonConverter(CapacitanceUnit.Farads);
        public static readonly CapacitanceJsonConverter Farads = new CapacitanceJsonConverter(CapacitanceUnit.Farads);

        private readonly CapacitanceUnit unit;

        private CapacitanceJsonConverter(CapacitanceUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var capacitance = (Capacitance)value;
            serializer.Serialize(writer, capacitance.ToString(this.unit, writer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Capacitance);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Capacitance.Parse(stringValue, reader.Culture);
        }
    }
}