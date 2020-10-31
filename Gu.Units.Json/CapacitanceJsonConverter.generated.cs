namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Capacitance"/>.
    /// </summary>
    [Serializable]
    public class CapacitanceJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CapacitanceUnit.Farads"/>
        /// </summary>
        public static readonly CapacitanceJsonConverter Default = new CapacitanceJsonConverter(CapacitanceUnit.Farads);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CapacitanceUnit.Farads"/>
        /// </summary>
        public static readonly CapacitanceJsonConverter Farads = new CapacitanceJsonConverter(CapacitanceUnit.Farads);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CapacitanceUnit.Nanofarads"/>
        /// </summary>
        public static readonly CapacitanceJsonConverter Nanofarads = new CapacitanceJsonConverter(CapacitanceUnit.Nanofarads);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CapacitanceUnit.Microfarads"/>
        /// </summary>
        public static readonly CapacitanceJsonConverter Microfarads = new CapacitanceJsonConverter(CapacitanceUnit.Microfarads);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CapacitanceUnit.Millifarads"/>
        /// </summary>
        public static readonly CapacitanceJsonConverter Millifarads = new CapacitanceJsonConverter(CapacitanceUnit.Millifarads);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CapacitanceUnit.Kilofarads"/>
        /// </summary>
        public static readonly CapacitanceJsonConverter Kilofarads = new CapacitanceJsonConverter(CapacitanceUnit.Kilofarads);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CapacitanceUnit.Megafarads"/>
        /// </summary>
        public static readonly CapacitanceJsonConverter Megafarads = new CapacitanceJsonConverter(CapacitanceUnit.Megafarads);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CapacitanceUnit.Gigafarads"/>
        /// </summary>
        public static readonly CapacitanceJsonConverter Gigafarads = new CapacitanceJsonConverter(CapacitanceUnit.Gigafarads);

        private readonly CapacitanceUnit unit;

        private CapacitanceJsonConverter(CapacitanceUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var capacitance = (Capacitance)value;
            serializer.Serialize(writer, capacitance.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Capacitance);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Capacitance.Parse(stringValue, serializer.Culture);
        }
    }
}
