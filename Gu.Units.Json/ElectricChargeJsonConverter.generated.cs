namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.ElectricCharge"/>.
    /// </summary>
    [Serializable]
    public class ElectricChargeJsonConverter : JsonConverter
    {
        public static readonly ElectricChargeJsonConverter Default = new ElectricChargeJsonConverter(ElectricChargeUnit.Coulombs);
        public static readonly ElectricChargeJsonConverter Coulombs = new ElectricChargeJsonConverter(ElectricChargeUnit.Coulombs);

        private readonly ElectricChargeUnit unit;

        private ElectricChargeJsonConverter(ElectricChargeUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var electricCharge = (ElectricCharge)value;
            serializer.Serialize(writer, electricCharge.ToString(this.unit, writer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ElectricCharge);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return ElectricCharge.Parse(stringValue, reader.Culture);
        }
    }
}