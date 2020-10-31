#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.SolidAngle"/>.
    /// </summary>
    [Serializable]
    public class SolidAngleJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SolidAngleUnit.Steradians"/>
        /// </summary>
        public static readonly SolidAngleJsonConverter Default = new SolidAngleJsonConverter(SolidAngleUnit.Steradians);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SolidAngleUnit.Steradians"/>
        /// </summary>
        public static readonly SolidAngleJsonConverter Steradians = new SolidAngleJsonConverter(SolidAngleUnit.Steradians);

        private readonly SolidAngleUnit unit;

        private SolidAngleJsonConverter(SolidAngleUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var solidAngle = (SolidAngle)value!;
            serializer.Serialize(writer, solidAngle.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SolidAngle);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return SolidAngle.Parse(stringValue, serializer.Culture);
        }
    }
}
