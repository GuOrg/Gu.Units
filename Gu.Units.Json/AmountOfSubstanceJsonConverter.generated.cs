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
        public static readonly AmountOfSubstanceJsonConverter Default = new AmountOfSubstanceJsonConverter(AmountOfSubstanceUnit.Moles);
        public static readonly AmountOfSubstanceJsonConverter Moles = new AmountOfSubstanceJsonConverter(AmountOfSubstanceUnit.Moles);

        private readonly AmountOfSubstanceUnit unit;

        private AmountOfSubstanceJsonConverter(AmountOfSubstanceUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var amountOfSubstance = (AmountOfSubstance)value;
            serializer.Serialize(writer, amountOfSubstance.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AmountOfSubstance);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return AmountOfSubstance.Parse(stringValue, serializer.Culture);
        }
    }
}