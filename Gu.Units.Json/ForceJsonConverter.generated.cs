namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Force"/>.
    /// </summary>
    [Serializable]
    public class ForceJsonConverter : JsonConverter
    {
        public static readonly ForceJsonConverter Default = new ForceJsonConverter(ForceUnit.Newtons);
        public static readonly ForceJsonConverter Newtons = new ForceJsonConverter(ForceUnit.Newtons);
        public static readonly ForceJsonConverter Nanonewtons = new ForceJsonConverter(ForceUnit.Nanonewtons);
        public static readonly ForceJsonConverter Micronewtons = new ForceJsonConverter(ForceUnit.Micronewtons);
        public static readonly ForceJsonConverter Millinewtons = new ForceJsonConverter(ForceUnit.Millinewtons);
        public static readonly ForceJsonConverter Kilonewtons = new ForceJsonConverter(ForceUnit.Kilonewtons);
        public static readonly ForceJsonConverter Meganewtons = new ForceJsonConverter(ForceUnit.Meganewtons);
        public static readonly ForceJsonConverter Giganewtons = new ForceJsonConverter(ForceUnit.Giganewtons);

        private readonly ForceUnit unit;

        private ForceJsonConverter(ForceUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var force = (Force)value;
            serializer.Serialize(writer, force.ToString(this.unit, writer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Force);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Force.Parse(stringValue, reader.Culture);
        }
    }
}