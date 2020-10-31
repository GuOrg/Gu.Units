namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Frequency"/>.
    /// </summary>
    [Serializable]
    public class FrequencyJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="FrequencyUnit.Hertz"/>
        /// </summary>
        public static readonly FrequencyJsonConverter Default = new FrequencyJsonConverter(FrequencyUnit.Hertz);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="FrequencyUnit.Hertz"/>
        /// </summary>
        public static readonly FrequencyJsonConverter Hertz = new FrequencyJsonConverter(FrequencyUnit.Hertz);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="FrequencyUnit.Millihertz"/>
        /// </summary>
        public static readonly FrequencyJsonConverter Millihertz = new FrequencyJsonConverter(FrequencyUnit.Millihertz);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="FrequencyUnit.Kilohertz"/>
        /// </summary>
        public static readonly FrequencyJsonConverter Kilohertz = new FrequencyJsonConverter(FrequencyUnit.Kilohertz);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="FrequencyUnit.Megahertz"/>
        /// </summary>
        public static readonly FrequencyJsonConverter Megahertz = new FrequencyJsonConverter(FrequencyUnit.Megahertz);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="FrequencyUnit.Gigahertz"/>
        /// </summary>
        public static readonly FrequencyJsonConverter Gigahertz = new FrequencyJsonConverter(FrequencyUnit.Gigahertz);

        private readonly FrequencyUnit unit;

        private FrequencyJsonConverter(FrequencyUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var frequency = (Frequency)value;
            serializer.Serialize(writer, frequency.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Frequency);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Frequency.Parse(stringValue, serializer.Culture);
        }
    }
}
