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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ResistanceUnit.Ohms"/>
        /// </summary>
        public static readonly ResistanceJsonConverter Default = new ResistanceJsonConverter(ResistanceUnit.Ohms);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ResistanceUnit.Ohms"/>
        /// </summary>
        public static readonly ResistanceJsonConverter Ohms = new ResistanceJsonConverter(ResistanceUnit.Ohms);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ResistanceUnit.Microohms"/>
        /// </summary>
        public static readonly ResistanceJsonConverter Microohms = new ResistanceJsonConverter(ResistanceUnit.Microohms);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ResistanceUnit.Milliohms"/>
        /// </summary>
        public static readonly ResistanceJsonConverter Milliohms = new ResistanceJsonConverter(ResistanceUnit.Milliohms);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ResistanceUnit.Kiloohms"/>
        /// </summary>
        public static readonly ResistanceJsonConverter Kiloohms = new ResistanceJsonConverter(ResistanceUnit.Kiloohms);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ResistanceUnit.Megaohms"/>
        /// </summary>
        public static readonly ResistanceJsonConverter Megaohms = new ResistanceJsonConverter(ResistanceUnit.Megaohms);

        private readonly ResistanceUnit unit;

        private ResistanceJsonConverter(ResistanceUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var resistance = (Resistance)value;
            serializer.Serialize(writer, resistance.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Resistance);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Resistance.Parse(stringValue, serializer.Culture);
        }
    }
}
