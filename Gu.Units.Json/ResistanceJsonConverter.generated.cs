namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

	/// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Resistance"/>.
    /// </summary>
    [Serializable]
	public class ResistanceJsonConverter : JsonConverter
	{
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ResistanceUnit.Ohm"/>
        /// </summary>
        public static readonly ResistanceJsonConverter Default = new ResistanceJsonConverter(ResistanceUnit.Ohm);
       
	    /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ResistanceUnit.Ohm"/>
        /// </summary>
        public static readonly ResistanceJsonConverter Ohm = new ResistanceJsonConverter(ResistanceUnit.Ohm);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ResistanceUnit.Microohm"/>
        /// </summary>
        public static readonly ResistanceJsonConverter Microohm = new ResistanceJsonConverter(ResistanceUnit.Microohm);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ResistanceUnit.Milliohm"/>
        /// </summary>
        public static readonly ResistanceJsonConverter Milliohm = new ResistanceJsonConverter(ResistanceUnit.Milliohm);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ResistanceUnit.Kiloohm"/>
        /// </summary>
        public static readonly ResistanceJsonConverter Kiloohm = new ResistanceJsonConverter(ResistanceUnit.Kiloohm);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ResistanceUnit.Megaohm"/>
        /// </summary>
        public static readonly ResistanceJsonConverter Megaohm = new ResistanceJsonConverter(ResistanceUnit.Megaohm);

        private readonly ResistanceUnit unit;

        private ResistanceJsonConverter(ResistanceUnit unit)
        {
            this.unit = unit;
        }

		/// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var resistance = (Resistance)value;
            serializer.Serialize(writer, resistance.ToString(this.unit, serializer.Culture));
        }

		/// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Resistance);
        }

		/// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Resistance.Parse(stringValue, serializer.Culture);
        }
    }
}