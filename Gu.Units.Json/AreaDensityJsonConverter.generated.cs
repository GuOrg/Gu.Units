#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.AreaDensity"/>.
    /// </summary>
    [Serializable]
    public class AreaDensityJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AreaDensityUnit.KilogramsPerSquareMetre"/>
        /// </summary>
        public static readonly AreaDensityJsonConverter Default = new AreaDensityJsonConverter(AreaDensityUnit.KilogramsPerSquareMetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AreaDensityUnit.KilogramsPerSquareMetre"/>
        /// </summary>
        public static readonly AreaDensityJsonConverter KilogramsPerSquareMetre = new AreaDensityJsonConverter(AreaDensityUnit.KilogramsPerSquareMetre);

        private readonly AreaDensityUnit unit;

        private AreaDensityJsonConverter(AreaDensityUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var areaDensity = (AreaDensity)value;
            serializer.Serialize(writer, areaDensity.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AreaDensity);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return AreaDensity.Parse(stringValue, serializer.Culture);
        }
    }
}
