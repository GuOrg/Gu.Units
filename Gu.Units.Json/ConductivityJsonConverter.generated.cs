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