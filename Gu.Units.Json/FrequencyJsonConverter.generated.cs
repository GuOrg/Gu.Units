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
        public static readonly FrequencyJsonConverter Default = new FrequencyJsonConverter(FrequencyUnit.Hertz);
        public static readonly FrequencyJsonConverter Hertz = new FrequencyJsonConverter(FrequencyUnit.Hertz);
        public static readonly FrequencyJsonConverter Millihertz = new FrequencyJsonConverter(FrequencyUnit.Millihertz);
        public static readonly FrequencyJsonConverter Kilohertz = new FrequencyJsonConverter(FrequencyUnit.Kilohertz);
        public static readonly FrequencyJsonConverter Megahertz = new FrequencyJsonConverter(FrequencyUnit.Megahertz);
        public static readonly FrequencyJsonConverter Gigahertz = new FrequencyJsonConverter(FrequencyUnit.Gigahertz);

        private readonly FrequencyUnit unit;

        private FrequencyJsonConverter(FrequencyUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var frequency = (Frequency)value;
            serializer.Serialize(writer, frequency.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Frequency);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Frequency.Parse(stringValue, serializer.Culture);
        }
    }
}