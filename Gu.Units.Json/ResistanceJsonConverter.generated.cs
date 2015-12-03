namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Resistance"/>.
    /// </summary>
    [Serializable]
    public class ResistanceJsonConverter : JsonConverter
    {
        public static readonly ResistanceJsonConverter Default = new ResistanceJsonConverter(ResistanceUnit.Ohm);
        public static readonly ResistanceJsonConverter Ohm = new ResistanceJsonConverter(ResistanceUnit.Ohm);
        public static readonly ResistanceJsonConverter Microohm = new ResistanceJsonConverter(ResistanceUnit.Microohm);
        public static readonly ResistanceJsonConverter Milliohm = new ResistanceJsonConverter(ResistanceUnit.Milliohm);
        public static readonly ResistanceJsonConverter Kiloohm = new ResistanceJsonConverter(ResistanceUnit.Kiloohm);
        public static readonly ResistanceJsonConverter Megaohm = new ResistanceJsonConverter(ResistanceUnit.Megaohm);

        private readonly ResistanceUnit unit;

        private ResistanceJsonConverter(ResistanceUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var resistance = (Resistance)value;
            serializer.Serialize(writer, resistance.ToString(this.unit, writer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Resistance);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Resistance.Parse(stringValue, reader.Culture);
        }
    }
}