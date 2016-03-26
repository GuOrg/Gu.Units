namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

	/// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Mass"/>.
    /// </summary>
    [Serializable]
	public class MassJsonConverter : JsonConverter
	{
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MassUnit.Kilograms"/>
        /// </summary>
        public static readonly MassJsonConverter Default = new MassJsonConverter(MassUnit.Kilograms);
       
	    /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MassUnit.Kilograms"/>
        /// </summary>
        public static readonly MassJsonConverter Kilograms = new MassJsonConverter(MassUnit.Kilograms);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MassUnit.Grams"/>
        /// </summary>
        public static readonly MassJsonConverter Grams = new MassJsonConverter(MassUnit.Grams);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MassUnit.Milligrams"/>
        /// </summary>
        public static readonly MassJsonConverter Milligrams = new MassJsonConverter(MassUnit.Milligrams);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MassUnit.Micrograms"/>
        /// </summary>
        public static readonly MassJsonConverter Micrograms = new MassJsonConverter(MassUnit.Micrograms);

        private readonly MassUnit unit;

        private MassJsonConverter(MassUnit unit)
        {
            this.unit = unit;
        }

		/// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var mass = (Mass)value;
            serializer.Serialize(writer, mass.ToString(this.unit, serializer.Culture));
        }

		/// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Mass);
        }

		/// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Mass.Parse(stringValue, serializer.Culture);
        }
    }
}