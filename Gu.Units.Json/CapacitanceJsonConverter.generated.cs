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
        public static readonly CapacitanceJsonConverter Nanofarads = new CapacitanceJsonConverter(CapacitanceUnit.Nanofarads);
        public static readonly CapacitanceJsonConverter Microfarads = new CapacitanceJsonConverter(CapacitanceUnit.Microfarads);
        public static readonly CapacitanceJsonConverter Millifarads = new CapacitanceJsonConverter(CapacitanceUnit.Millifarads);
        public static readonly CapacitanceJsonConverter Kilofarads = new CapacitanceJsonConverter(CapacitanceUnit.Kilofarads);
        public static readonly CapacitanceJsonConverter Megafarads = new CapacitanceJsonConverter(CapacitanceUnit.Megafarads);
        public static readonly CapacitanceJsonConverter Gigafarads = new CapacitanceJsonConverter(CapacitanceUnit.Gigafarads);

        private readonly CapacitanceUnit unit;

        private CapacitanceJsonConverter(CapacitanceUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var capacitance = (Capacitance)value;
            serializer.Serialize(writer, capacitance.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Capacitance);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Capacitance.Parse(stringValue, serializer.Culture);
        }
    }
}