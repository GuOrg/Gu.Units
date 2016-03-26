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
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularAccelerationUnit.DegreesPerSquareSecond"/>
        /// </summary>
        public static readonly AngularAccelerationJsonConverter DegreesPerSquareSecond = new AngularAccelerationJsonConverter(AngularAccelerationUnit.DegreesPerSquareSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularAccelerationUnit.RadiansPerSquareHour"/>
        /// </summary>
        public static readonly AngularAccelerationJsonConverter RadiansPerSquareHour = new AngularAccelerationJsonConverter(AngularAccelerationUnit.RadiansPerSquareHour);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularAccelerationUnit.DegreesPerSquareHour"/>
        /// </summary>
        public static readonly AngularAccelerationJsonConverter DegreesPerSquareHour = new AngularAccelerationJsonConverter(AngularAccelerationUnit.DegreesPerSquareHour);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularAccelerationUnit.DegreesPerSquareMinute"/>
        /// </summary>
        public static readonly AngularAccelerationJsonConverter DegreesPerSquareMinute = new AngularAccelerationJsonConverter(AngularAccelerationUnit.DegreesPerSquareMinute);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularAccelerationUnit.RadiansPerSquareMinute"/>
        /// </summary>
        public static readonly AngularAccelerationJsonConverter RadiansPerSquareMinute = new AngularAccelerationJsonConverter(AngularAccelerationUnit.RadiansPerSquareMinute);

        private readonly AngularAccelerationUnit unit;

        private AngularAccelerationJsonConverter(AngularAccelerationUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var angularAcceleration = (AngularAcceleration)value;
            serializer.Serialize(writer, angularAcceleration.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AngularAcceleration);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return AngularAcceleration.Parse(stringValue, serializer.Culture);
        }
    }
}