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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularSpeedUnit.RadiansPerSecond"/>
        /// </summary>
        public static readonly AngularSpeedJsonConverter Default = new AngularSpeedJsonConverter(AngularSpeedUnit.RadiansPerSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularSpeedUnit.RadiansPerSecond"/>
        /// </summary>
        public static readonly AngularSpeedJsonConverter RadiansPerSecond = new AngularSpeedJsonConverter(AngularSpeedUnit.RadiansPerSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularSpeedUnit.RevolutionsPerMinute"/>
        /// </summary>
        public static readonly AngularSpeedJsonConverter RevolutionsPerMinute = new AngularSpeedJsonConverter(AngularSpeedUnit.RevolutionsPerMinute);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularSpeedUnit.DegreesPerSecond"/>
        /// </summary>
        public static readonly AngularSpeedJsonConverter DegreesPerSecond = new AngularSpeedJsonConverter(AngularSpeedUnit.DegreesPerSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularSpeedUnit.DegreesPerMinute"/>
        /// </summary>
        public static readonly AngularSpeedJsonConverter DegreesPerMinute = new AngularSpeedJsonConverter(AngularSpeedUnit.DegreesPerMinute);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularSpeedUnit.RadiansPerMinute"/>
        /// </summary>
        public static readonly AngularSpeedJsonConverter RadiansPerMinute = new AngularSpeedJsonConverter(AngularSpeedUnit.RadiansPerMinute);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularSpeedUnit.DegreesPerHour"/>
        /// </summary>
        public static readonly AngularSpeedJsonConverter DegreesPerHour = new AngularSpeedJsonConverter(AngularSpeedUnit.DegreesPerHour);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularSpeedUnit.RadiansPerHour"/>
        /// </summary>
        public static readonly AngularSpeedJsonConverter RadiansPerHour = new AngularSpeedJsonConverter(AngularSpeedUnit.RadiansPerHour);

        private readonly AngularSpeedUnit unit;

        private AngularSpeedJsonConverter(AngularSpeedUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var angularSpeed = (AngularSpeed)value;
            serializer.Serialize(writer, angularSpeed.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AngularSpeed);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return AngularSpeed.Parse(stringValue, serializer.Culture);
        }
    }
}