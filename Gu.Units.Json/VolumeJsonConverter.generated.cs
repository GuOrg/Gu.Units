namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Volume"/>.
    /// </summary>
    [Serializable]
    public class VolumeJsonConverter : JsonConverter
    {
        public static readonly VolumeJsonConverter Default = new VolumeJsonConverter(VolumeUnit.CubicMetres);
        public static readonly VolumeJsonConverter CubicMetres = new VolumeJsonConverter(VolumeUnit.CubicMetres);
        public static readonly VolumeJsonConverter Litres = new VolumeJsonConverter(VolumeUnit.Litres);
        public static readonly VolumeJsonConverter CubicCentimetres = new VolumeJsonConverter(VolumeUnit.CubicCentimetres);
        public static readonly VolumeJsonConverter CubicMillimetres = new VolumeJsonConverter(VolumeUnit.CubicMillimetres);
        public static readonly VolumeJsonConverter CubicInches = new VolumeJsonConverter(VolumeUnit.CubicInches);

        private readonly VolumeUnit unit;

        private VolumeJsonConverter(VolumeUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var volume = (Volume)value;
            serializer.Serialize(writer, volume.ToString(this.unit, writer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Volume);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Volume.Parse(stringValue, reader.Culture);
        }
    }
}