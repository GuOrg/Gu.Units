namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.LengthPerUnitless"/>.
    /// </summary>
    [Serializable]
    public class LengthPerUnitlessJsonConverter : JsonConverter
    {
        public static readonly LengthPerUnitlessJsonConverter Default = new LengthPerUnitlessJsonConverter(LengthPerUnitlessUnit.MetresPerUnitless);
        public static readonly LengthPerUnitlessJsonConverter MetresPerUnitless = new LengthPerUnitlessJsonConverter(LengthPerUnitlessUnit.MetresPerUnitless);
        public static readonly LengthPerUnitlessJsonConverter MillimetresPerPercent = new LengthPerUnitlessJsonConverter(LengthPerUnitlessUnit.MillimetresPerPercent);
        public static readonly LengthPerUnitlessJsonConverter MicrometresPerPercent = new LengthPerUnitlessJsonConverter(LengthPerUnitlessUnit.MicrometresPerPercent);
        public static readonly LengthPerUnitlessJsonConverter MetresPerPercent = new LengthPerUnitlessJsonConverter(LengthPerUnitlessUnit.MetresPerPercent);

        private readonly LengthPerUnitlessUnit unit;

        private LengthPerUnitlessJsonConverter(LengthPerUnitlessUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var lengthPerUnitless = (LengthPerUnitless)value;
            serializer.Serialize(writer, lengthPerUnitless.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(LengthPerUnitless);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return LengthPerUnitless.Parse(stringValue, serializer.Culture);
        }
    }
}