namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Unitless"/>.
    /// </summary>
    [Serializable]
    public class UnitlessJsonConverter : JsonConverter
    {
        public static readonly UnitlessJsonConverter Default = new UnitlessJsonConverter(UnitlessUnit.Scalar);
        public static readonly UnitlessJsonConverter Scalar = new UnitlessJsonConverter(UnitlessUnit.Scalar);
        public static readonly UnitlessJsonConverter PartsPerMillion = new UnitlessJsonConverter(UnitlessUnit.PartsPerMillion);
        public static readonly UnitlessJsonConverter Promilles = new UnitlessJsonConverter(UnitlessUnit.Promilles);
        public static readonly UnitlessJsonConverter Percents = new UnitlessJsonConverter(UnitlessUnit.Percents);

        private readonly UnitlessUnit unit;

        private UnitlessJsonConverter(UnitlessUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var unitless = (Unitless)value;
            serializer.Serialize(writer, unitless.ToString(this.unit, writer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Unitless);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Unitless.Parse(stringValue, reader.Culture);
        }
    }
}