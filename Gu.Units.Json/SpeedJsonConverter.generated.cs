#nullable enable
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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpeedUnit.MetresPerSecond"/>
        /// </summary>
        public static readonly SpeedJsonConverter Default = new SpeedJsonConverter(SpeedUnit.MetresPerSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpeedUnit.MetresPerSecond"/>
        /// </summary>
        public static readonly SpeedJsonConverter MetresPerSecond = new SpeedJsonConverter(SpeedUnit.MetresPerSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpeedUnit.KilometresPerHour"/>
        /// </summary>
        public static readonly SpeedJsonConverter KilometresPerHour = new SpeedJsonConverter(SpeedUnit.KilometresPerHour);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpeedUnit.CentimetresPerMinute"/>
        /// </summary>
        public static readonly SpeedJsonConverter CentimetresPerMinute = new SpeedJsonConverter(SpeedUnit.CentimetresPerMinute);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpeedUnit.MetresPerMinute"/>
        /// </summary>
        public static readonly SpeedJsonConverter MetresPerMinute = new SpeedJsonConverter(SpeedUnit.MetresPerMinute);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpeedUnit.MetresPerHour"/>
        /// </summary>
        public static readonly SpeedJsonConverter MetresPerHour = new SpeedJsonConverter(SpeedUnit.MetresPerHour);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpeedUnit.MillimetresPerHour"/>
        /// </summary>
        public static readonly SpeedJsonConverter MillimetresPerHour = new SpeedJsonConverter(SpeedUnit.MillimetresPerHour);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpeedUnit.CentimetresPerHour"/>
        /// </summary>
        public static readonly SpeedJsonConverter CentimetresPerHour = new SpeedJsonConverter(SpeedUnit.CentimetresPerHour);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpeedUnit.MillimetresPerMinute"/>
        /// </summary>
        public static readonly SpeedJsonConverter MillimetresPerMinute = new SpeedJsonConverter(SpeedUnit.MillimetresPerMinute);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpeedUnit.MillimetresPerSecond"/>
        /// </summary>
        public static readonly SpeedJsonConverter MillimetresPerSecond = new SpeedJsonConverter(SpeedUnit.MillimetresPerSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="SpeedUnit.CentimetresPerSecond"/>
        /// </summary>
        public static readonly SpeedJsonConverter CentimetresPerSecond = new SpeedJsonConverter(SpeedUnit.CentimetresPerSecond);

        private readonly SpeedUnit unit;

        private SpeedJsonConverter(SpeedUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var speed = (Speed)value!;
            serializer.Serialize(writer, speed.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Speed);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return Speed.Parse(stringValue, serializer.Culture);
        }
    }
}
