namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Length"/>.
    /// </summary>
    [Serializable]
    public class LengthJsonConverter : JsonConverter
    {
        public static readonly LengthJsonConverter Default = new LengthJsonConverter(LengthUnit.Metres);
        public static readonly LengthJsonConverter Metres = new LengthJsonConverter(LengthUnit.Metres);
        public static readonly LengthJsonConverter Inches = new LengthJsonConverter(LengthUnit.Inches);
        public static readonly LengthJsonConverter Mile = new LengthJsonConverter(LengthUnit.Mile);
        public static readonly LengthJsonConverter Yard = new LengthJsonConverter(LengthUnit.Yard);
        public static readonly LengthJsonConverter NauticalMile = new LengthJsonConverter(LengthUnit.NauticalMile);
        public static readonly LengthJsonConverter Nanometres = new LengthJsonConverter(LengthUnit.Nanometres);
        public static readonly LengthJsonConverter Micrometres = new LengthJsonConverter(LengthUnit.Micrometres);
        public static readonly LengthJsonConverter Millimetres = new LengthJsonConverter(LengthUnit.Millimetres);
        public static readonly LengthJsonConverter Centimetres = new LengthJsonConverter(LengthUnit.Centimetres);
        public static readonly LengthJsonConverter Decimetres = new LengthJsonConverter(LengthUnit.Decimetres);
        public static readonly LengthJsonConverter Kilometres = new LengthJsonConverter(LengthUnit.Kilometres);

        private readonly LengthUnit unit;

        private LengthJsonConverter(LengthUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var length = (Length)value;
            serializer.Serialize(writer, length.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Length);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Length.Parse(stringValue, serializer.Culture);
        }
    }
}