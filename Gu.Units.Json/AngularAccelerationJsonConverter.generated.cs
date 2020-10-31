#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.AngularAcceleration"/>.
    /// </summary>
    [Serializable]
    public class AngularAccelerationJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularAccelerationUnit.RadiansPerSecondSquared"/>
        /// </summary>
        public static readonly AngularAccelerationJsonConverter Default = new AngularAccelerationJsonConverter(AngularAccelerationUnit.RadiansPerSecondSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularAccelerationUnit.RadiansPerSecondSquared"/>
        /// </summary>
        public static readonly AngularAccelerationJsonConverter RadiansPerSecondSquared = new AngularAccelerationJsonConverter(AngularAccelerationUnit.RadiansPerSecondSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularAccelerationUnit.DegreesPerSecondSquared"/>
        /// </summary>
        public static readonly AngularAccelerationJsonConverter DegreesPerSecondSquared = new AngularAccelerationJsonConverter(AngularAccelerationUnit.DegreesPerSecondSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularAccelerationUnit.RadiansPerHourSquared"/>
        /// </summary>
        public static readonly AngularAccelerationJsonConverter RadiansPerHourSquared = new AngularAccelerationJsonConverter(AngularAccelerationUnit.RadiansPerHourSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularAccelerationUnit.DegreesPerHourSquared"/>
        /// </summary>
        public static readonly AngularAccelerationJsonConverter DegreesPerHourSquared = new AngularAccelerationJsonConverter(AngularAccelerationUnit.DegreesPerHourSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularAccelerationUnit.DegreesPerMinuteSquared"/>
        /// </summary>
        public static readonly AngularAccelerationJsonConverter DegreesPerMinuteSquared = new AngularAccelerationJsonConverter(AngularAccelerationUnit.DegreesPerMinuteSquared);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularAccelerationUnit.RadiansPerMinuteSquared"/>
        /// </summary>
        public static readonly AngularAccelerationJsonConverter RadiansPerMinuteSquared = new AngularAccelerationJsonConverter(AngularAccelerationUnit.RadiansPerMinuteSquared);

        private readonly AngularAccelerationUnit unit;

        private AngularAccelerationJsonConverter(AngularAccelerationUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var angularAcceleration = (AngularAcceleration)value!;
            serializer.Serialize(writer, angularAcceleration.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AngularAcceleration);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return AngularAcceleration.Parse(stringValue, serializer.Culture);
        }
    }
}
