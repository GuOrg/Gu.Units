namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Power"/>.
    /// </summary>
    [Serializable]
    public class PowerJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PowerUnit.Watts"/>
        /// </summary>
        public static readonly PowerJsonConverter Default = new PowerJsonConverter(PowerUnit.Watts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PowerUnit.Watts"/>
        /// </summary>
        public static readonly PowerJsonConverter Watts = new PowerJsonConverter(PowerUnit.Watts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PowerUnit.Nanowatts"/>
        /// </summary>
        public static readonly PowerJsonConverter Nanowatts = new PowerJsonConverter(PowerUnit.Nanowatts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PowerUnit.Microwatts"/>
        /// </summary>
        public static readonly PowerJsonConverter Microwatts = new PowerJsonConverter(PowerUnit.Microwatts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PowerUnit.Milliwatts"/>
        /// </summary>
        public static readonly PowerJsonConverter Milliwatts = new PowerJsonConverter(PowerUnit.Milliwatts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PowerUnit.Kilowatts"/>
        /// </summary>
        public static readonly PowerJsonConverter Kilowatts = new PowerJsonConverter(PowerUnit.Kilowatts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PowerUnit.Megawatts"/>
        /// </summary>
        public static readonly PowerJsonConverter Megawatts = new PowerJsonConverter(PowerUnit.Megawatts);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PowerUnit.Gigawatts"/>
        /// </summary>
        public static readonly PowerJsonConverter Gigawatts = new PowerJsonConverter(PowerUnit.Gigawatts);

        private readonly PowerUnit unit;

        private PowerJsonConverter(PowerUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var power = (Power)value;
            serializer.Serialize(writer, power.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Power);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Power.Parse(stringValue, serializer.Culture);
        }
    }
}