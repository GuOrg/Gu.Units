namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Angle"/>.
    /// </summary>
    [Serializable]
    public class AngleJsonConverter : JsonConverter
    {
        public static readonly AngleJsonConverter Default = new AngleJsonConverter(AngleUnit.Radians);
        public static readonly AngleJsonConverter Radians = new AngleJsonConverter(AngleUnit.Radians);
        public static readonly AngleJsonConverter Degrees = new AngleJsonConverter(AngleUnit.Degrees);

        private readonly AngleUnit unit;

        private AngleJsonConverter(AngleUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var angle = (Angle)value;
            serializer.Serialize(writer, angle.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Angle);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Angle.Parse(stringValue, serializer.Culture);
        }
    }
}