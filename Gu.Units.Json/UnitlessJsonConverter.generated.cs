#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Unitless"/>.
    /// </summary>
    [Serializable]
    public class UnitlessJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="UnitlessUnit.Scalar"/>
        /// </summary>
        public static readonly UnitlessJsonConverter Default = new UnitlessJsonConverter(UnitlessUnit.Scalar);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="UnitlessUnit.Scalar"/>
        /// </summary>
        public static readonly UnitlessJsonConverter Scalar = new UnitlessJsonConverter(UnitlessUnit.Scalar);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="UnitlessUnit.Promilles"/>
        /// </summary>
        public static readonly UnitlessJsonConverter Promilles = new UnitlessJsonConverter(UnitlessUnit.Promilles);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="UnitlessUnit.PartsPerMillion"/>
        /// </summary>
        public static readonly UnitlessJsonConverter PartsPerMillion = new UnitlessJsonConverter(UnitlessUnit.PartsPerMillion);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="UnitlessUnit.Percents"/>
        /// </summary>
        public static readonly UnitlessJsonConverter Percents = new UnitlessJsonConverter(UnitlessUnit.Percents);

        private readonly UnitlessUnit unit;

        private UnitlessJsonConverter(UnitlessUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var unitless = (Unitless)value;
            serializer.Serialize(writer, unitless.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Unitless);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value;
            return Unitless.Parse(stringValue, serializer.Culture);
        }
    }
}
