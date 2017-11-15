namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.ElectricalConductance"/>.
    /// </summary>
    [Serializable]
    public class ElectricalConductanceJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ElectricalConductanceUnit.Siemens"/>
        /// </summary>
        public static readonly ElectricalConductanceJsonConverter Default = new ElectricalConductanceJsonConverter(ElectricalConductanceUnit.Siemens);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ElectricalConductanceUnit.Siemens"/>
        /// </summary>
        public static readonly ElectricalConductanceJsonConverter Siemens = new ElectricalConductanceJsonConverter(ElectricalConductanceUnit.Siemens);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ElectricalConductanceUnit.Nanosiemens"/>
        /// </summary>
        public static readonly ElectricalConductanceJsonConverter Nanosiemens = new ElectricalConductanceJsonConverter(ElectricalConductanceUnit.Nanosiemens);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ElectricalConductanceUnit.Microsiemens"/>
        /// </summary>
        public static readonly ElectricalConductanceJsonConverter Microsiemens = new ElectricalConductanceJsonConverter(ElectricalConductanceUnit.Microsiemens);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ElectricalConductanceUnit.Millisiemens"/>
        /// </summary>
        public static readonly ElectricalConductanceJsonConverter Millisiemens = new ElectricalConductanceJsonConverter(ElectricalConductanceUnit.Millisiemens);

        private readonly ElectricalConductanceUnit unit;

        private ElectricalConductanceJsonConverter(ElectricalConductanceUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var electricalConductance = (ElectricalConductance)value;
            serializer.Serialize(writer, electricalConductance.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ElectricalConductance);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return ElectricalConductance.Parse(stringValue, serializer.Culture);
        }
    }
}