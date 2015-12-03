namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.AngularSpeed"/>.
    /// </summary>
    [Serializable]
    public class AngularSpeedJsonConverter : JsonConverter
    {
        public static readonly AngularSpeedJsonConverter Default = new AngularSpeedJsonConverter(AngularSpeedUnit.RadiansPerSecond);
        public static readonly AngularSpeedJsonConverter RadiansPerSecond = new AngularSpeedJsonConverter(AngularSpeedUnit.RadiansPerSecond);
        public static readonly AngularSpeedJsonConverter RevolutionsPerMinute = new AngularSpeedJsonConverter(AngularSpeedUnit.RevolutionsPerMinute);
        public static readonly AngularSpeedJsonConverter DegreesPerSecond = new AngularSpeedJsonConverter(AngularSpeedUnit.DegreesPerSecond);
        public static readonly AngularSpeedJsonConverter DegreesPerMinute = new AngularSpeedJsonConverter(AngularSpeedUnit.DegreesPerMinute);
        public static readonly AngularSpeedJsonConverter RadiansPerMinute = new AngularSpeedJsonConverter(AngularSpeedUnit.RadiansPerMinute);
        public static readonly AngularSpeedJsonConverter DegreesPerHour = new AngularSpeedJsonConverter(AngularSpeedUnit.DegreesPerHour);
        public static readonly AngularSpeedJsonConverter RadiansPerHour = new AngularSpeedJsonConverter(AngularSpeedUnit.RadiansPerHour);

        private readonly AngularSpeedUnit unit;

        private AngularSpeedJsonConverter(AngularSpeedUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var angularSpeed = (AngularSpeed)value;
            serializer.Serialize(writer, angularSpeed.ToString(this.unit, writer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AngularSpeed);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return AngularSpeed.Parse(stringValue, reader.Culture);
        }
    }
}