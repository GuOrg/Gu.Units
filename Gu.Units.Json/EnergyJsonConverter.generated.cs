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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="EnergyUnit.Joules"/>
        /// </summary>
        public static readonly EnergyJsonConverter Default = new EnergyJsonConverter(EnergyUnit.Joules);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="EnergyUnit.Joules"/>
        /// </summary>
        public static readonly EnergyJsonConverter Joules = new EnergyJsonConverter(EnergyUnit.Joules);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="EnergyUnit.Nanojoules"/>
        /// </summary>
        public static readonly EnergyJsonConverter Nanojoules = new EnergyJsonConverter(EnergyUnit.Nanojoules);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="EnergyUnit.Microjoules"/>
        /// </summary>
        public static readonly EnergyJsonConverter Microjoules = new EnergyJsonConverter(EnergyUnit.Microjoules);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="EnergyUnit.Millijoules"/>
        /// </summary>
        public static readonly EnergyJsonConverter Millijoules = new EnergyJsonConverter(EnergyUnit.Millijoules);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="EnergyUnit.Kilojoules"/>
        /// </summary>
        public static readonly EnergyJsonConverter Kilojoules = new EnergyJsonConverter(EnergyUnit.Kilojoules);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="EnergyUnit.Megajoules"/>
        /// </summary>
        public static readonly EnergyJsonConverter Megajoules = new EnergyJsonConverter(EnergyUnit.Megajoules);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="EnergyUnit.Gigajoules"/>
        /// </summary>
        public static readonly EnergyJsonConverter Gigajoules = new EnergyJsonConverter(EnergyUnit.Gigajoules);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="EnergyUnit.KilowattHours"/>
        /// </summary>
        public static readonly EnergyJsonConverter KilowattHours = new EnergyJsonConverter(EnergyUnit.KilowattHours);

        private readonly EnergyUnit unit;

        private EnergyJsonConverter(EnergyUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var energy = (Energy)value;
            serializer.Serialize(writer, energy.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Energy);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Energy.Parse(stringValue, serializer.Culture);
        }
    }
}