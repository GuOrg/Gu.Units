#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Temperature"/>.
    /// </summary>
    [Serializable]
    public class TemperatureJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TemperatureUnit.Kelvin"/>
        /// </summary>
        public static readonly TemperatureJsonConverter Default = new TemperatureJsonConverter(TemperatureUnit.Kelvin);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TemperatureUnit.Kelvin"/>
        /// </summary>
        public static readonly TemperatureJsonConverter Kelvin = new TemperatureJsonConverter(TemperatureUnit.Kelvin);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TemperatureUnit.Celsius"/>
        /// </summary>
        public static readonly TemperatureJsonConverter Celsius = new TemperatureJsonConverter(TemperatureUnit.Celsius);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TemperatureUnit.Fahrenheit"/>
        /// </summary>
        public static readonly TemperatureJsonConverter Fahrenheit = new TemperatureJsonConverter(TemperatureUnit.Fahrenheit);

        private readonly TemperatureUnit unit;

        private TemperatureJsonConverter(TemperatureUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var temperature = (Temperature)value;
            serializer.Serialize(writer, temperature.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Temperature);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value;
            return Temperature.Parse(stringValue, serializer.Culture);
        }
    }
}
