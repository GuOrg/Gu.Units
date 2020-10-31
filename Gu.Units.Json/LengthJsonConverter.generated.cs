#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Length"/>.
    /// </summary>
    [Serializable]
    public class LengthJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthUnit.Metres"/>
        /// </summary>
        public static readonly LengthJsonConverter Default = new LengthJsonConverter(LengthUnit.Metres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthUnit.Metres"/>
        /// </summary>
        public static readonly LengthJsonConverter Metres = new LengthJsonConverter(LengthUnit.Metres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthUnit.Inches"/>
        /// </summary>
        public static readonly LengthJsonConverter Inches = new LengthJsonConverter(LengthUnit.Inches);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthUnit.Miles"/>
        /// </summary>
        public static readonly LengthJsonConverter Miles = new LengthJsonConverter(LengthUnit.Miles);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthUnit.Yards"/>
        /// </summary>
        public static readonly LengthJsonConverter Yards = new LengthJsonConverter(LengthUnit.Yards);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthUnit.NauticalMiles"/>
        /// </summary>
        public static readonly LengthJsonConverter NauticalMiles = new LengthJsonConverter(LengthUnit.NauticalMiles);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthUnit.Feet"/>
        /// </summary>
        public static readonly LengthJsonConverter Feet = new LengthJsonConverter(LengthUnit.Feet);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthUnit.Nanometres"/>
        /// </summary>
        public static readonly LengthJsonConverter Nanometres = new LengthJsonConverter(LengthUnit.Nanometres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthUnit.Micrometres"/>
        /// </summary>
        public static readonly LengthJsonConverter Micrometres = new LengthJsonConverter(LengthUnit.Micrometres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthUnit.Millimetres"/>
        /// </summary>
        public static readonly LengthJsonConverter Millimetres = new LengthJsonConverter(LengthUnit.Millimetres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthUnit.Centimetres"/>
        /// </summary>
        public static readonly LengthJsonConverter Centimetres = new LengthJsonConverter(LengthUnit.Centimetres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthUnit.Decimetres"/>
        /// </summary>
        public static readonly LengthJsonConverter Decimetres = new LengthJsonConverter(LengthUnit.Decimetres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthUnit.Kilometres"/>
        /// </summary>
        public static readonly LengthJsonConverter Kilometres = new LengthJsonConverter(LengthUnit.Kilometres);

        private readonly LengthUnit unit;

        private LengthJsonConverter(LengthUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var length = (Length)value;
            serializer.Serialize(writer, length.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Length);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value;
            return Length.Parse(stringValue, serializer.Culture);
        }
    }
}
