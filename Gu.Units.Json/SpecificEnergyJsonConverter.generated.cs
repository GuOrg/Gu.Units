namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.SpecificEnergy"/>.
    /// </summary>
    [Serializable]
    public class SpecificEnergyJsonConverter : JsonConverter
    {
        public static readonly SpecificEnergyJsonConverter Default = new SpecificEnergyJsonConverter(SpecificEnergyUnit.JoulesPerKilogram);
        public static readonly SpecificEnergyJsonConverter JoulesPerKilogram = new SpecificEnergyJsonConverter(SpecificEnergyUnit.JoulesPerKilogram);

        private readonly SpecificEnergyUnit unit;

        private SpecificEnergyJsonConverter(SpecificEnergyUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var specificEnergy = (SpecificEnergy)value;
            serializer.Serialize(writer, specificEnergy.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SpecificEnergy);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return SpecificEnergy.Parse(stringValue, serializer.Culture);
        }
    }
}