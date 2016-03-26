namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.AnglePerUnitless"/>.
    /// </summary>
    [Serializable]
    public class AnglePerUnitlessJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AnglePerUnitlessUnit.RadiansPerUnitless"/>
        /// </summary>
        public static readonly AnglePerUnitlessJsonConverter Default = new AnglePerUnitlessJsonConverter(AnglePerUnitlessUnit.RadiansPerUnitless);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AnglePerUnitlessUnit.RadiansPerUnitless"/>
        /// </summary>
        public static readonly AnglePerUnitlessJsonConverter RadiansPerUnitless = new AnglePerUnitlessJsonConverter(AnglePerUnitlessUnit.RadiansPerUnitless);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AnglePerUnitlessUnit.DegreesPerPercent"/>
        /// </summary>
        public static readonly AnglePerUnitlessJsonConverter DegreesPerPercent = new AnglePerUnitlessJsonConverter(AnglePerUnitlessUnit.DegreesPerPercent);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AnglePerUnitlessUnit.RadiansPerPercent"/>
        /// </summary>
        public static readonly AnglePerUnitlessJsonConverter RadiansPerPercent = new AnglePerUnitlessJsonConverter(AnglePerUnitlessUnit.RadiansPerPercent);

        private readonly AnglePerUnitlessUnit unit;

        private AnglePerUnitlessJsonConverter(AnglePerUnitlessUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var anglePerUnitless = (AnglePerUnitless)value;
            serializer.Serialize(writer, anglePerUnitless.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AnglePerUnitless);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return AnglePerUnitless.Parse(stringValue, serializer.Culture);
        }
    }
}