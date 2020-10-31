namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Acceleration"/>.
    /// </summary>
    [Serializable]
    public class AccelerationJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AccelerationUnit.MetresPerSecondSquared"/>
        /// </summary>
        public static readonly AccelerationJsonConverter Default = new AccelerationJsonConverter(AccelerationUnit.MetresPerSecondSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AccelerationUnit.MetresPerSecondSquared"/>
        /// </summary>
        public static readonly AccelerationJsonConverter MetresPerSecondSquared = new AccelerationJsonConverter(AccelerationUnit.MetresPerSecondSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AccelerationUnit.CentimetresPerSecondSquared"/>
        /// </summary>
        public static readonly AccelerationJsonConverter CentimetresPerSecondSquared = new AccelerationJsonConverter(AccelerationUnit.CentimetresPerSecondSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AccelerationUnit.MillimetresPerSecondSquared"/>
        /// </summary>
        public static readonly AccelerationJsonConverter MillimetresPerSecondSquared = new AccelerationJsonConverter(AccelerationUnit.MillimetresPerSecondSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AccelerationUnit.MillimetresPerHourSquared"/>
        /// </summary>
        public static readonly AccelerationJsonConverter MillimetresPerHourSquared = new AccelerationJsonConverter(AccelerationUnit.MillimetresPerHourSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AccelerationUnit.CentimetresPerHourSquared"/>
        /// </summary>
        public static readonly AccelerationJsonConverter CentimetresPerHourSquared = new AccelerationJsonConverter(AccelerationUnit.CentimetresPerHourSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AccelerationUnit.MetresPerHourSquared"/>
        /// </summary>
        public static readonly AccelerationJsonConverter MetresPerHourSquared = new AccelerationJsonConverter(AccelerationUnit.MetresPerHourSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AccelerationUnit.MetresPerMinuteSquared"/>
        /// </summary>
        public static readonly AccelerationJsonConverter MetresPerMinuteSquared = new AccelerationJsonConverter(AccelerationUnit.MetresPerMinuteSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AccelerationUnit.MillimetresPerMinuteSquared"/>
        /// </summary>
        public static readonly AccelerationJsonConverter MillimetresPerMinuteSquared = new AccelerationJsonConverter(AccelerationUnit.MillimetresPerMinuteSquared);

        private readonly AccelerationUnit unit;

        private AccelerationJsonConverter(AccelerationUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var acceleration = (Acceleration)value;
            serializer.Serialize(writer, acceleration.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Acceleration);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Acceleration.Parse(stringValue, serializer.Culture);
        }
    }
}
