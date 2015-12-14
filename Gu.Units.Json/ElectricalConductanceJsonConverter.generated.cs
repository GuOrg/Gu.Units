namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.ElectricalConductance"/>.
    /// </summary>
    [Serializable]
    public class ElectricalConductanceJsonConverter : JsonConverter
    {
        public static readonly ElectricalConductanceJsonConverter Default = new ElectricalConductanceJsonConverter(ElectricalConductanceUnit.Siemens);
        public static readonly ElectricalConductanceJsonConverter Siemens = new ElectricalConductanceJsonConverter(ElectricalConductanceUnit.Siemens);

        private readonly ElectricalConductanceUnit unit;

        private ElectricalConductanceJsonConverter(ElectricalConductanceUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var electricalConductance = (ElectricalConductance)value;
            serializer.Serialize(writer, electricalConductance.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ElectricalConductance);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return ElectricalConductance.Parse(stringValue, serializer.Culture);
        }
    }
}