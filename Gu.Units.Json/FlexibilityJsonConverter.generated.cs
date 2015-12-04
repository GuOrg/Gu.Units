namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Flexibility"/>.
    /// </summary>
    [Serializable]
    public class FlexibilityJsonConverter : JsonConverter
    {
        public static readonly FlexibilityJsonConverter Default = new FlexibilityJsonConverter(FlexibilityUnit.MetresPerNewton);
        public static readonly FlexibilityJsonConverter MetresPerNewton = new FlexibilityJsonConverter(FlexibilityUnit.MetresPerNewton);
        public static readonly FlexibilityJsonConverter MillimetresPerNewton = new FlexibilityJsonConverter(FlexibilityUnit.MillimetresPerNewton);
        public static readonly FlexibilityJsonConverter MillimetresPerKilonewton = new FlexibilityJsonConverter(FlexibilityUnit.MillimetresPerKilonewton);
        public static readonly FlexibilityJsonConverter MicrometresPerKilonewton = new FlexibilityJsonConverter(FlexibilityUnit.MicrometresPerKilonewton);

        private readonly FlexibilityUnit unit;

        private FlexibilityJsonConverter(FlexibilityUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var flexibility = (Flexibility)value;
            serializer.Serialize(writer, flexibility.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Flexibility);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Flexibility.Parse(stringValue, serializer.Culture);
        }
    }
}