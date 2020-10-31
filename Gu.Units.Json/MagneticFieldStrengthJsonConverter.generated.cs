#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.MagneticFieldStrength"/>.
    /// </summary>
    [Serializable]
    public class MagneticFieldStrengthJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MagneticFieldStrengthUnit.Teslas"/>
        /// </summary>
        public static readonly MagneticFieldStrengthJsonConverter Default = new MagneticFieldStrengthJsonConverter(MagneticFieldStrengthUnit.Teslas);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MagneticFieldStrengthUnit.Teslas"/>
        /// </summary>
        public static readonly MagneticFieldStrengthJsonConverter Teslas = new MagneticFieldStrengthJsonConverter(MagneticFieldStrengthUnit.Teslas);

        private readonly MagneticFieldStrengthUnit unit;

        private MagneticFieldStrengthJsonConverter(MagneticFieldStrengthUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var magneticFieldStrength = (MagneticFieldStrength)value!;
            serializer.Serialize(writer, magneticFieldStrength.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MagneticFieldStrength);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return MagneticFieldStrength.Parse(stringValue, serializer.Culture);
        }
    }
}
