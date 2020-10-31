namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.MagneticFlux"/>.
    /// </summary>
    [Serializable]
    public class MagneticFluxJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MagneticFluxUnit.Webers"/>
        /// </summary>
        public static readonly MagneticFluxJsonConverter Default = new MagneticFluxJsonConverter(MagneticFluxUnit.Webers);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MagneticFluxUnit.Webers"/>
        /// </summary>
        public static readonly MagneticFluxJsonConverter Webers = new MagneticFluxJsonConverter(MagneticFluxUnit.Webers);

        private readonly MagneticFluxUnit unit;

        private MagneticFluxJsonConverter(MagneticFluxUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var magneticFlux = (MagneticFlux)value;
            serializer.Serialize(writer, magneticFlux.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MagneticFlux);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return MagneticFlux.Parse(stringValue, serializer.Culture);
        }
    }
}
