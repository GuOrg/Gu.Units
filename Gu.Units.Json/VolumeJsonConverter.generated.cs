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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumeUnit.CubicMetres"/>
        /// </summary>
        public static readonly VolumeJsonConverter Default = new VolumeJsonConverter(VolumeUnit.CubicMetres);
       
	    /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumeUnit.CubicMetres"/>
        /// </summary>
        public static readonly VolumeJsonConverter CubicMetres = new VolumeJsonConverter(VolumeUnit.CubicMetres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumeUnit.Litres"/>
        /// </summary>
        public static readonly VolumeJsonConverter Litres = new VolumeJsonConverter(VolumeUnit.Litres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumeUnit.Millilitres"/>
        /// </summary>
        public static readonly VolumeJsonConverter Millilitres = new VolumeJsonConverter(VolumeUnit.Millilitres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumeUnit.Centilitres"/>
        /// </summary>
        public static readonly VolumeJsonConverter Centilitres = new VolumeJsonConverter(VolumeUnit.Centilitres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumeUnit.Decilitres"/>
        /// </summary>
        public static readonly VolumeJsonConverter Decilitres = new VolumeJsonConverter(VolumeUnit.Decilitres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumeUnit.CubicCentimetres"/>
        /// </summary>
        public static readonly VolumeJsonConverter CubicCentimetres = new VolumeJsonConverter(VolumeUnit.CubicCentimetres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumeUnit.CubicMillimetres"/>
        /// </summary>
        public static readonly VolumeJsonConverter CubicMillimetres = new VolumeJsonConverter(VolumeUnit.CubicMillimetres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumeUnit.CubicInches"/>
        /// </summary>
        public static readonly VolumeJsonConverter CubicInches = new VolumeJsonConverter(VolumeUnit.CubicInches);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumeUnit.CubicDecimetres"/>
        /// </summary>
        public static readonly VolumeJsonConverter CubicDecimetres = new VolumeJsonConverter(VolumeUnit.CubicDecimetres);

        private readonly VolumeUnit unit;

        private VolumeJsonConverter(VolumeUnit unit)
        {
            this.unit = unit;
        }

		/// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var volume = (Volume)value;
            serializer.Serialize(writer, volume.ToString(this.unit, serializer.Culture));
        }

		/// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Volume);
        }

		/// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Volume.Parse(stringValue, serializer.Culture);
        }
    }
}