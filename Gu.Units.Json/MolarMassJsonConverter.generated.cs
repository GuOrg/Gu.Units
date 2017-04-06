namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.MolarMass"/>.
    /// </summary>
    [Serializable]
    public class MolarMassJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MolarMassUnit.KilogramsPerMole"/>
        /// </summary>
        public static readonly MolarMassJsonConverter Default = new MolarMassJsonConverter(MolarMassUnit.KilogramsPerMole);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MolarMassUnit.KilogramsPerMole"/>
        /// </summary>
        public static readonly MolarMassJsonConverter KilogramsPerMole = new MolarMassJsonConverter(MolarMassUnit.KilogramsPerMole);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MolarMassUnit.GramsPerMole"/>
        /// </summary>
        public static readonly MolarMassJsonConverter GramsPerMole = new MolarMassJsonConverter(MolarMassUnit.GramsPerMole);

        private readonly MolarMassUnit unit;

        private MolarMassJsonConverter(MolarMassUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var molarMass = (MolarMass)value;
            serializer.Serialize(writer, molarMass.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MolarMass);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return MolarMass.Parse(stringValue, serializer.Culture);
        }
    }
}