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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DensityUnit.KilogramsPerCubicMetre"/>
        /// </summary>
        public static readonly DensityJsonConverter Default = new DensityJsonConverter(DensityUnit.KilogramsPerCubicMetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DensityUnit.KilogramsPerCubicMetre"/>
        /// </summary>
        public static readonly DensityJsonConverter KilogramsPerCubicMetre = new DensityJsonConverter(DensityUnit.KilogramsPerCubicMetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DensityUnit.GramsPerCubicMillimetre"/>
        /// </summary>
        public static readonly DensityJsonConverter GramsPerCubicMillimetre = new DensityJsonConverter(DensityUnit.GramsPerCubicMillimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DensityUnit.GramsPerCubicCentimetre"/>
        /// </summary>
        public static readonly DensityJsonConverter GramsPerCubicCentimetre = new DensityJsonConverter(DensityUnit.GramsPerCubicCentimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DensityUnit.MilligramsPerCubicMillimetre"/>
        /// </summary>
        public static readonly DensityJsonConverter MilligramsPerCubicMillimetre = new DensityJsonConverter(DensityUnit.MilligramsPerCubicMillimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DensityUnit.GramsPerCubicMetre"/>
        /// </summary>
        public static readonly DensityJsonConverter GramsPerCubicMetre = new DensityJsonConverter(DensityUnit.GramsPerCubicMetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DensityUnit.MilligramsPerCubicMetre"/>
        /// </summary>
        public static readonly DensityJsonConverter MilligramsPerCubicMetre = new DensityJsonConverter(DensityUnit.MilligramsPerCubicMetre);

        private readonly DensityUnit unit;

        private DensityJsonConverter(DensityUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var density = (Density)value;
            serializer.Serialize(writer, density.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Density);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Density.Parse(stringValue, serializer.Culture);
        }
    }
}