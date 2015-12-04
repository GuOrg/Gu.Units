namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Density"/>.
    /// </summary>
    [Serializable]
    public class DensityJsonConverter : JsonConverter
    {
        public static readonly DensityJsonConverter Default = new DensityJsonConverter(DensityUnit.KilogramsPerCubicMetre);
        public static readonly DensityJsonConverter KilogramsPerCubicMetre = new DensityJsonConverter(DensityUnit.KilogramsPerCubicMetre);
        public static readonly DensityJsonConverter GramsPerCubicMillimetre = new DensityJsonConverter(DensityUnit.GramsPerCubicMillimetre);
        public static readonly DensityJsonConverter GramsPerCubicCentimetre = new DensityJsonConverter(DensityUnit.GramsPerCubicCentimetre);

        private readonly DensityUnit unit;

        private DensityJsonConverter(DensityUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var density = (Density)value;
            serializer.Serialize(writer, density.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Density);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Density.Parse(stringValue, serializer.Culture);
        }
    }
}