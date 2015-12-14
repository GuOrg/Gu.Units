namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.SolidAngle"/>.
    /// </summary>
    [Serializable]
    public class SolidAngleJsonConverter : JsonConverter
    {
        public static readonly SolidAngleJsonConverter Default = new SolidAngleJsonConverter(SolidAngleUnit.Steradians);
        public static readonly SolidAngleJsonConverter Steradians = new SolidAngleJsonConverter(SolidAngleUnit.Steradians);

        private readonly SolidAngleUnit unit;

        private SolidAngleJsonConverter(SolidAngleUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var solidAngle = (SolidAngle)value;
            serializer.Serialize(writer, solidAngle.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SolidAngle);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return SolidAngle.Parse(stringValue, serializer.Culture);
        }
    }
}