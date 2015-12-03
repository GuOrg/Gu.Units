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
        public static readonly AngularAccelerationJsonConverter Default = new AngularAccelerationJsonConverter(AngularAccelerationUnit.RadiansPerSecondSquared);
        public static readonly AngularAccelerationJsonConverter RadiansPerSecondSquared = new AngularAccelerationJsonConverter(AngularAccelerationUnit.RadiansPerSecondSquared);
        public static readonly AngularAccelerationJsonConverter DegreesPerSquareSecond = new AngularAccelerationJsonConverter(AngularAccelerationUnit.DegreesPerSquareSecond);
        public static readonly AngularAccelerationJsonConverter RadiansPerSquareHour = new AngularAccelerationJsonConverter(AngularAccelerationUnit.RadiansPerSquareHour);
        public static readonly AngularAccelerationJsonConverter DegreesPerSquareHour = new AngularAccelerationJsonConverter(AngularAccelerationUnit.DegreesPerSquareHour);
        public static readonly AngularAccelerationJsonConverter DegreesPerSquareMinute = new AngularAccelerationJsonConverter(AngularAccelerationUnit.DegreesPerSquareMinute);
        public static readonly AngularAccelerationJsonConverter RadiansPerSquareMinute = new AngularAccelerationJsonConverter(AngularAccelerationUnit.RadiansPerSquareMinute);

        private readonly AngularAccelerationUnit unit;

        private AngularAccelerationJsonConverter(AngularAccelerationUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var angularAcceleration = (AngularAcceleration)value;
            serializer.Serialize(writer, angularAcceleration.ToString(this.unit, writer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AngularAcceleration);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return AngularAcceleration.Parse(stringValue, reader.Culture);
        }
    }
}