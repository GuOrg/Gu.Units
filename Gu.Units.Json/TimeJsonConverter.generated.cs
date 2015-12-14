namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Time"/>.
    /// </summary>
    [Serializable]
    public class TimeJsonConverter : JsonConverter
    {
        public static readonly TimeJsonConverter Default = new TimeJsonConverter(TimeUnit.Seconds);
        public static readonly TimeJsonConverter Seconds = new TimeJsonConverter(TimeUnit.Seconds);
        public static readonly TimeJsonConverter Hours = new TimeJsonConverter(TimeUnit.Hours);
        public static readonly TimeJsonConverter Minutes = new TimeJsonConverter(TimeUnit.Minutes);
        public static readonly TimeJsonConverter Nanoseconds = new TimeJsonConverter(TimeUnit.Nanoseconds);
        public static readonly TimeJsonConverter Microseconds = new TimeJsonConverter(TimeUnit.Microseconds);
        public static readonly TimeJsonConverter Milliseconds = new TimeJsonConverter(TimeUnit.Milliseconds);

        private readonly TimeUnit unit;

        private TimeJsonConverter(TimeUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var time = (Time)value;
            serializer.Serialize(writer, time.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Time);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Time.Parse(stringValue, serializer.Culture);
        }
    }
}