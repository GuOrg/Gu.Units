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
        public static readonly LuminousIntensityJsonConverter Default = new LuminousIntensityJsonConverter(LuminousIntensityUnit.Candelas);
        public static readonly LuminousIntensityJsonConverter Candelas = new LuminousIntensityJsonConverter(LuminousIntensityUnit.Candelas);

        private readonly LuminousIntensityUnit unit;

        private LuminousIntensityJsonConverter(LuminousIntensityUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var luminousIntensity = (LuminousIntensity)value;
            serializer.Serialize(writer, luminousIntensity.ToString(this.unit, writer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(LuminousIntensity);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return LuminousIntensity.Parse(stringValue, reader.Culture);
        }
    }
}