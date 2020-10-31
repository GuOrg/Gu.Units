#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Pressure"/>.
    /// </summary>
    [Serializable]
    public class PressureJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PressureUnit.Pascals"/>
        /// </summary>
        public static readonly PressureJsonConverter Default = new PressureJsonConverter(PressureUnit.Pascals);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PressureUnit.Pascals"/>
        /// </summary>
        public static readonly PressureJsonConverter Pascals = new PressureJsonConverter(PressureUnit.Pascals);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PressureUnit.Bars"/>
        /// </summary>
        public static readonly PressureJsonConverter Bars = new PressureJsonConverter(PressureUnit.Bars);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PressureUnit.Millibars"/>
        /// </summary>
        public static readonly PressureJsonConverter Millibars = new PressureJsonConverter(PressureUnit.Millibars);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PressureUnit.Nanopascals"/>
        /// </summary>
        public static readonly PressureJsonConverter Nanopascals = new PressureJsonConverter(PressureUnit.Nanopascals);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PressureUnit.Micropascals"/>
        /// </summary>
        public static readonly PressureJsonConverter Micropascals = new PressureJsonConverter(PressureUnit.Micropascals);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PressureUnit.Millipascals"/>
        /// </summary>
        public static readonly PressureJsonConverter Millipascals = new PressureJsonConverter(PressureUnit.Millipascals);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PressureUnit.Kilopascals"/>
        /// </summary>
        public static readonly PressureJsonConverter Kilopascals = new PressureJsonConverter(PressureUnit.Kilopascals);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PressureUnit.Megapascals"/>
        /// </summary>
        public static readonly PressureJsonConverter Megapascals = new PressureJsonConverter(PressureUnit.Megapascals);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PressureUnit.Gigapascals"/>
        /// </summary>
        public static readonly PressureJsonConverter Gigapascals = new PressureJsonConverter(PressureUnit.Gigapascals);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PressureUnit.NewtonsPerSquareMillimetre"/>
        /// </summary>
        public static readonly PressureJsonConverter NewtonsPerSquareMillimetre = new PressureJsonConverter(PressureUnit.NewtonsPerSquareMillimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PressureUnit.KilonewtonsPerSquareMillimetre"/>
        /// </summary>
        public static readonly PressureJsonConverter KilonewtonsPerSquareMillimetre = new PressureJsonConverter(PressureUnit.KilonewtonsPerSquareMillimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="PressureUnit.NewtonsPerSquareMetre"/>
        /// </summary>
        public static readonly PressureJsonConverter NewtonsPerSquareMetre = new PressureJsonConverter(PressureUnit.NewtonsPerSquareMetre);

        private readonly PressureUnit unit;

        private PressureJsonConverter(PressureUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var pressure = (Pressure)value!;
            serializer.Serialize(writer, pressure.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Pressure);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return Pressure.Parse(stringValue, serializer.Culture);
        }
    }
}
