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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpecificEnergyUnit.JoulesPerKilogram"/>
        /// </summary>
        public static readonly SpecificEnergyJsonConverter Default = new SpecificEnergyJsonConverter(SpecificEnergyUnit.JoulesPerKilogram);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpecificEnergyUnit.JoulesPerKilogram"/>
        /// </summary>
        public static readonly SpecificEnergyJsonConverter JoulesPerKilogram = new SpecificEnergyJsonConverter(SpecificEnergyUnit.JoulesPerKilogram);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpecificEnergyUnit.KilojoulesPerKilogram"/>
        /// </summary>
        public static readonly SpecificEnergyJsonConverter KilojoulesPerKilogram = new SpecificEnergyJsonConverter(SpecificEnergyUnit.KilojoulesPerKilogram);

        private readonly SpecificEnergyUnit unit;

        private SpecificEnergyJsonConverter(SpecificEnergyUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var specificEnergy = (SpecificEnergy)value;
            serializer.Serialize(writer, specificEnergy.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SpecificEnergy);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return SpecificEnergy.Parse(stringValue, serializer.Culture);
        }
    }
}