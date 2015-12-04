namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Mass"/>.
    /// </summary>
    [Serializable]
    public class MassJsonConverter : JsonConverter
    {
        public static readonly MassJsonConverter Default = new MassJsonConverter(MassUnit.Kilograms);
        public static readonly MassJsonConverter Kilograms = new MassJsonConverter(MassUnit.Kilograms);
        public static readonly MassJsonConverter Grams = new MassJsonConverter(MassUnit.Grams);
        public static readonly MassJsonConverter Milligrams = new MassJsonConverter(MassUnit.Milligrams);
        public static readonly MassJsonConverter Micrograms = new MassJsonConverter(MassUnit.Micrograms);

        private readonly MassUnit unit;

        private MassJsonConverter(MassUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var mass = (Mass)value;
            serializer.Serialize(writer, mass.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Mass);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Mass.Parse(stringValue, serializer.Culture);
        }
    }
}