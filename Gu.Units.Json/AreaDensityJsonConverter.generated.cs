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
        public static readonly AreaDensityJsonConverter Default = new AreaDensityJsonConverter(AreaDensityUnit.KilogramsPerSquareMetre);
        public static readonly AreaDensityJsonConverter KilogramsPerSquareMetre = new AreaDensityJsonConverter(AreaDensityUnit.KilogramsPerSquareMetre);

        private readonly AreaDensityUnit unit;

        private AreaDensityJsonConverter(AreaDensityUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var areaDensity = (AreaDensity)value;
            serializer.Serialize(writer, areaDensity.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AreaDensity);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return AreaDensity.Parse(stringValue, serializer.Culture);
        }
    }
}