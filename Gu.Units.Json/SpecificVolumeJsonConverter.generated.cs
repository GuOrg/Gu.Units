





namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.SpecificVolume"/>.
    /// </summary>
    [Serializable]
    public class SpecificVolumeJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpecificVolumeUnit.CubicMetresPerKilogram"/>
        /// </summary>
        public static readonly SpecificVolumeJsonConverter Default = new SpecificVolumeJsonConverter(SpecificVolumeUnit.CubicMetresPerKilogram);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpecificVolumeUnit.CubicMetresPerKilogram"/>
        /// </summary>
        public static readonly SpecificVolumeJsonConverter CubicMetresPerKilogram = new SpecificVolumeJsonConverter(SpecificVolumeUnit.CubicMetresPerKilogram);


        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpecificVolumeUnit.CubicMetresPerGram"/>
        /// </summary>
        public static readonly SpecificVolumeJsonConverter CubicMetresPerGram = new SpecificVolumeJsonConverter(SpecificVolumeUnit.CubicMetresPerGram);


        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpecificVolumeUnit.CubicCentimetresPerGram"/>
        /// </summary>
        public static readonly SpecificVolumeJsonConverter CubicCentimetresPerGram = new SpecificVolumeJsonConverter(SpecificVolumeUnit.CubicCentimetresPerGram);


        private readonly SpecificVolumeUnit unit;

        private SpecificVolumeJsonConverter(SpecificVolumeUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var specificVolume = (SpecificVolume)value;
            serializer.Serialize(writer, specificVolume.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SpecificVolume);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return SpecificVolume.Parse(stringValue, serializer.Culture);
        }
    }
}