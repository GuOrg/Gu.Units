





namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.MolarHeatCapacity"/>.
    /// </summary>
    [Serializable]
    public class MolarHeatCapacityJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MolarHeatCapacityUnit.JoulesPerKelvinMole"/>
        /// </summary>
        public static readonly MolarHeatCapacityJsonConverter Default = new MolarHeatCapacityJsonConverter(MolarHeatCapacityUnit.JoulesPerKelvinMole);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MolarHeatCapacityUnit.JoulesPerKelvinMole"/>
        /// </summary>
        public static readonly MolarHeatCapacityJsonConverter JoulesPerKelvinMole = new MolarHeatCapacityJsonConverter(MolarHeatCapacityUnit.JoulesPerKelvinMole);


        private readonly MolarHeatCapacityUnit unit;

        private MolarHeatCapacityJsonConverter(MolarHeatCapacityUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var molarHeatCapacity = (MolarHeatCapacity)value;
            serializer.Serialize(writer, molarHeatCapacity.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MolarHeatCapacity);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return MolarHeatCapacity.Parse(stringValue, serializer.Culture);
        }
    }
}