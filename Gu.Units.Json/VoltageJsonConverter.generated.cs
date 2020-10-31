namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Voltage"/>.
    /// </summary>
    [Serializable]
    public class VoltageJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VoltageUnit.Volts"/>
        /// </summary>
        public static readonly VoltageJsonConverter Default = new VoltageJsonConverter(VoltageUnit.Volts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VoltageUnit.Volts"/>
        /// </summary>
        public static readonly VoltageJsonConverter Volts = new VoltageJsonConverter(VoltageUnit.Volts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VoltageUnit.Millivolts"/>
        /// </summary>
        public static readonly VoltageJsonConverter Millivolts = new VoltageJsonConverter(VoltageUnit.Millivolts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VoltageUnit.Kilovolts"/>
        /// </summary>
        public static readonly VoltageJsonConverter Kilovolts = new VoltageJsonConverter(VoltageUnit.Kilovolts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VoltageUnit.Megavolts"/>
        /// </summary>
        public static readonly VoltageJsonConverter Megavolts = new VoltageJsonConverter(VoltageUnit.Megavolts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VoltageUnit.Microvolts"/>
        /// </summary>
        public static readonly VoltageJsonConverter Microvolts = new VoltageJsonConverter(VoltageUnit.Microvolts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VoltageUnit.Nanovolts"/>
        /// </summary>
        public static readonly VoltageJsonConverter Nanovolts = new VoltageJsonConverter(VoltageUnit.Nanovolts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VoltageUnit.Gigavolts"/>
        /// </summary>
        public static readonly VoltageJsonConverter Gigavolts = new VoltageJsonConverter(VoltageUnit.Gigavolts);

        private readonly VoltageUnit unit;

        private VoltageJsonConverter(VoltageUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var voltage = (Voltage)value;
            serializer.Serialize(writer, voltage.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Voltage);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Voltage.Parse(stringValue, serializer.Culture);
        }
    }
}
