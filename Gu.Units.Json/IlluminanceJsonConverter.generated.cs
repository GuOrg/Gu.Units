namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Illuminance"/>.
    /// </summary>
    [Serializable]
    public class IlluminanceJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="IlluminanceUnit.Lux"/>
        /// </summary>
        public static readonly IlluminanceJsonConverter Default = new IlluminanceJsonConverter(IlluminanceUnit.Lux);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="IlluminanceUnit.Lux"/>
        /// </summary>
        public static readonly IlluminanceJsonConverter Lux = new IlluminanceJsonConverter(IlluminanceUnit.Lux);

        private readonly IlluminanceUnit unit;

        private IlluminanceJsonConverter(IlluminanceUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var illuminance = (Illuminance)value;
            serializer.Serialize(writer, illuminance.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Illuminance);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Illuminance.Parse(stringValue, serializer.Culture);
        }
    }
}