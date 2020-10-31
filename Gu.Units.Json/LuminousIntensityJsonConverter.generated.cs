#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.LuminousIntensity"/>.
    /// </summary>
    [Serializable]
    public class LuminousIntensityJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LuminousIntensityUnit.Candelas"/>
        /// </summary>
        public static readonly LuminousIntensityJsonConverter Default = new LuminousIntensityJsonConverter(LuminousIntensityUnit.Candelas);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LuminousIntensityUnit.Candelas"/>
        /// </summary>
        public static readonly LuminousIntensityJsonConverter Candelas = new LuminousIntensityJsonConverter(LuminousIntensityUnit.Candelas);

        private readonly LuminousIntensityUnit unit;

        private LuminousIntensityJsonConverter(LuminousIntensityUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var luminousIntensity = (LuminousIntensity)value!;
            serializer.Serialize(writer, luminousIntensity.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(LuminousIntensity);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return LuminousIntensity.Parse(stringValue, serializer.Culture);
        }
    }
}
