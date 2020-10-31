#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.AmountOfSubstance"/>.
    /// </summary>
    [Serializable]
    public class AmountOfSubstanceJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AmountOfSubstanceUnit.Moles"/>
        /// </summary>
        public static readonly AmountOfSubstanceJsonConverter Default = new AmountOfSubstanceJsonConverter(AmountOfSubstanceUnit.Moles);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AmountOfSubstanceUnit.Moles"/>
        /// </summary>
        public static readonly AmountOfSubstanceJsonConverter Moles = new AmountOfSubstanceJsonConverter(AmountOfSubstanceUnit.Moles);

        private readonly AmountOfSubstanceUnit unit;

        private AmountOfSubstanceJsonConverter(AmountOfSubstanceUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var amountOfSubstance = (AmountOfSubstance)value!;
            serializer.Serialize(writer, amountOfSubstance.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AmountOfSubstance);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return AmountOfSubstance.Parse(stringValue, serializer.Culture);
        }
    }
}
