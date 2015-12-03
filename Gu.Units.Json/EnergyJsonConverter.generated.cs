namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Energy"/>.
    /// </summary>
    [Serializable]
    public class EnergyJsonConverter : JsonConverter
    {
        public static readonly EnergyJsonConverter Default = new EnergyJsonConverter(EnergyUnit.Joules);
        public static readonly EnergyJsonConverter Joules = new EnergyJsonConverter(EnergyUnit.Joules);
        public static readonly EnergyJsonConverter Nanojoules = new EnergyJsonConverter(EnergyUnit.Nanojoules);
        public static readonly EnergyJsonConverter Microjoules = new EnergyJsonConverter(EnergyUnit.Microjoules);
        public static readonly EnergyJsonConverter Millijoules = new EnergyJsonConverter(EnergyUnit.Millijoules);
        public static readonly EnergyJsonConverter Kilojoules = new EnergyJsonConverter(EnergyUnit.Kilojoules);
        public static readonly EnergyJsonConverter Megajoules = new EnergyJsonConverter(EnergyUnit.Megajoules);
        public static readonly EnergyJsonConverter Gigajoules = new EnergyJsonConverter(EnergyUnit.Gigajoules);
        public static readonly EnergyJsonConverter KilowattHours = new EnergyJsonConverter(EnergyUnit.KilowattHours);

        private readonly EnergyUnit unit;

        private EnergyJsonConverter(EnergyUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var energy = (Energy)value;
            serializer.Serialize(writer, energy.ToString(this.unit, writer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Energy);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Energy.Parse(stringValue, reader.Culture);
        }
    }
}