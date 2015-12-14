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
        public static readonly InductanceJsonConverter Nanohenrys = new InductanceJsonConverter(InductanceUnit.Nanohenrys);
        public static readonly InductanceJsonConverter Microhenrys = new InductanceJsonConverter(InductanceUnit.Microhenrys);
        public static readonly InductanceJsonConverter Millihenrys = new InductanceJsonConverter(InductanceUnit.Millihenrys);
        public static readonly InductanceJsonConverter Kilohenrys = new InductanceJsonConverter(InductanceUnit.Kilohenrys);
        public static readonly InductanceJsonConverter Megahenrys = new InductanceJsonConverter(InductanceUnit.Megahenrys);
        public static readonly InductanceJsonConverter Gigahenrys = new InductanceJsonConverter(InductanceUnit.Gigahenrys);

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