namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Speed"/>.
    /// </summary>
    [Serializable]
    public class SpeedJsonConverter : JsonConverter
    {
        public static readonly SpeedJsonConverter Default = new SpeedJsonConverter(SpeedUnit.MetresPerSecond);
        public static readonly SpeedJsonConverter MetresPerSecond = new SpeedJsonConverter(SpeedUnit.MetresPerSecond);
        public static readonly SpeedJsonConverter MillimetresPerSecond = new SpeedJsonConverter(SpeedUnit.MillimetresPerSecond);
        public static readonly SpeedJsonConverter CentimetresPerSecond = new SpeedJsonConverter(SpeedUnit.CentimetresPerSecond);
        public static readonly SpeedJsonConverter KilometresPerHour = new SpeedJsonConverter(SpeedUnit.KilometresPerHour);
        public static readonly SpeedJsonConverter CentimetresPerMinute = new SpeedJsonConverter(SpeedUnit.CentimetresPerMinute);
        public static readonly SpeedJsonConverter MetresPerMinute = new SpeedJsonConverter(SpeedUnit.MetresPerMinute);
        public static readonly SpeedJsonConverter MetresPerHour = new SpeedJsonConverter(SpeedUnit.MetresPerHour);
        public static readonly SpeedJsonConverter MillimetresPerHour = new SpeedJsonConverter(SpeedUnit.MillimetresPerHour);
        public static readonly SpeedJsonConverter CentimetresPerHour = new SpeedJsonConverter(SpeedUnit.CentimetresPerHour);
        public static readonly SpeedJsonConverter MillimetresPerMinute = new SpeedJsonConverter(SpeedUnit.MillimetresPerMinute);

        private readonly SpeedUnit unit;

        private SpeedJsonConverter(SpeedUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var speed = (Speed)value;
            serializer.Serialize(writer, speed.ToString(this.unit, writer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Speed);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Speed.Parse(stringValue, reader.Culture);
        }
    }
}