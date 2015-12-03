namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.AnglePerUnitless"/>.
    /// </summary>
    [Serializable]
    public class AnglePerUnitlessJsonConverter : JsonConverter
    {
        public static readonly AnglePerUnitlessJsonConverter Default = new AnglePerUnitlessJsonConverter(AnglePerUnitlessUnit.RadiansPerUnitless);
        public static readonly AnglePerUnitlessJsonConverter RadiansPerUnitless = new AnglePerUnitlessJsonConverter(AnglePerUnitlessUnit.RadiansPerUnitless);
        public static readonly AnglePerUnitlessJsonConverter DegreesPerPercent = new AnglePerUnitlessJsonConverter(AnglePerUnitlessUnit.DegreesPerPercent);
        public static readonly AnglePerUnitlessJsonConverter RadiansPerPercent = new AnglePerUnitlessJsonConverter(AnglePerUnitlessUnit.RadiansPerPercent);

        private readonly AnglePerUnitlessUnit unit;

        private AnglePerUnitlessJsonConverter(AnglePerUnitlessUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var anglePerUnitless = (AnglePerUnitless)value;
            serializer.Serialize(writer, anglePerUnitless.ToString(this.unit, writer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AnglePerUnitless);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return AnglePerUnitless.Parse(stringValue, reader.Culture);
        }
    }
}