#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Angle"/>.
    /// </summary>
    [Serializable]
    public class AngleJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngleUnit.Radians"/>
        /// </summary>
        public static readonly AngleJsonConverter Default = new AngleJsonConverter(AngleUnit.Radians);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngleUnit.Radians"/>
        /// </summary>
        public static readonly AngleJsonConverter Radians = new AngleJsonConverter(AngleUnit.Radians);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngleUnit.Degrees"/>
        /// </summary>
        public static readonly AngleJsonConverter Degrees = new AngleJsonConverter(AngleUnit.Degrees);

        private readonly AngleUnit unit;

        private AngleJsonConverter(AngleUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var angle = (Angle)value!;
            serializer.Serialize(writer, angle.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Angle);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return Angle.Parse(stringValue, serializer.Culture);
        }
    }
}
