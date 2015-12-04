namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Inductance"/>.
    /// </summary>
    [Serializable]
    public class InductanceJsonConverter : JsonConverter
    {
        public static readonly InductanceJsonConverter Default = new InductanceJsonConverter(InductanceUnit.Henrys);
        public static readonly InductanceJsonConverter Henrys = new InductanceJsonConverter(InductanceUnit.Henrys);

        private readonly InductanceUnit unit;

        private InductanceJsonConverter(InductanceUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var inductance = (Inductance)value;
            serializer.Serialize(writer, inductance.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Inductance);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Inductance.Parse(stringValue, serializer.Culture);
        }
    }
}