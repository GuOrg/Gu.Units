#nullable enable
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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TimeUnit.Seconds"/>
        /// </summary>
        public static readonly TimeJsonConverter Default = new TimeJsonConverter(TimeUnit.Seconds);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TimeUnit.Seconds"/>
        /// </summary>
        public static readonly TimeJsonConverter Seconds = new TimeJsonConverter(TimeUnit.Seconds);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TimeUnit.Hours"/>
        /// </summary>
        public static readonly TimeJsonConverter Hours = new TimeJsonConverter(TimeUnit.Hours);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TimeUnit.Minutes"/>
        /// </summary>
        public static readonly TimeJsonConverter Minutes = new TimeJsonConverter(TimeUnit.Minutes);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TimeUnit.Days"/>
        /// </summary>
        public static readonly TimeJsonConverter Days = new TimeJsonConverter(TimeUnit.Days);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TimeUnit.Nanoseconds"/>
        /// </summary>
        public static readonly TimeJsonConverter Nanoseconds = new TimeJsonConverter(TimeUnit.Nanoseconds);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TimeUnit.Microseconds"/>
        /// </summary>
        public static readonly TimeJsonConverter Microseconds = new TimeJsonConverter(TimeUnit.Microseconds);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TimeUnit.Milliseconds"/>
        /// </summary>
        public static readonly TimeJsonConverter Milliseconds = new TimeJsonConverter(TimeUnit.Milliseconds);

        private readonly TimeUnit unit;

        private TimeJsonConverter(TimeUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var time = (Time)value!;
            serializer.Serialize(writer, time.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Time);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return Time.Parse(stringValue, serializer.Culture);
        }
    }
}
