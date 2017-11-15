namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Conductivity"/>.
    /// </summary>
    [Serializable]
    public class ConductivityJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.SiemensPerMetre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter Default = new ConductivityJsonConverter(ConductivityUnit.SiemensPerMetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.SiemensPerMetre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter SiemensPerMetre = new ConductivityJsonConverter(ConductivityUnit.SiemensPerMetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.SiemensPerCentimetre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter SiemensPerCentimetre = new ConductivityJsonConverter(ConductivityUnit.SiemensPerCentimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.SiemensPerMillimetre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter SiemensPerMillimetre = new ConductivityJsonConverter(ConductivityUnit.SiemensPerMillimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.NanosiemensPerMetre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter NanosiemensPerMetre = new ConductivityJsonConverter(ConductivityUnit.NanosiemensPerMetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.NanosiemensPerMicrometre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter NanosiemensPerMicrometre = new ConductivityJsonConverter(ConductivityUnit.NanosiemensPerMicrometre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.NanosiemensPerMillimetre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter NanosiemensPerMillimetre = new ConductivityJsonConverter(ConductivityUnit.NanosiemensPerMillimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.NanosiemensPerCentimetre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter NanosiemensPerCentimetre = new ConductivityJsonConverter(ConductivityUnit.NanosiemensPerCentimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.MicrosiemensPerMetre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter MicrosiemensPerMetre = new ConductivityJsonConverter(ConductivityUnit.MicrosiemensPerMetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.MicrosiemensPerMillimetre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter MicrosiemensPerMillimetre = new ConductivityJsonConverter(ConductivityUnit.MicrosiemensPerMillimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.MicrosiemensPerCentimetre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter MicrosiemensPerCentimetre = new ConductivityJsonConverter(ConductivityUnit.MicrosiemensPerCentimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.MillisiemensPerMetre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter MillisiemensPerMetre = new ConductivityJsonConverter(ConductivityUnit.MillisiemensPerMetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.MillisiemensPerMillimetre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter MillisiemensPerMillimetre = new ConductivityJsonConverter(ConductivityUnit.MillisiemensPerMillimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ConductivityUnit.MillisiemensPerCentimetre"/>
        /// </summary>
        public static readonly ConductivityJsonConverter MillisiemensPerCentimetre = new ConductivityJsonConverter(ConductivityUnit.MillisiemensPerCentimetre);

        private readonly ConductivityUnit unit;

        private ConductivityJsonConverter(ConductivityUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var conductivity = (Conductivity)value;
            serializer.Serialize(writer, conductivity.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Conductivity);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Conductivity.Parse(stringValue, serializer.Culture);
        }
    }
}