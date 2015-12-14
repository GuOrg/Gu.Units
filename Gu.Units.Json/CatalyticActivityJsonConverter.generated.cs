namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.CatalyticActivity"/>.
    /// </summary>
    [Serializable]
    public class CatalyticActivityJsonConverter : JsonConverter
    {
        public static readonly CatalyticActivityJsonConverter Default = new CatalyticActivityJsonConverter(CatalyticActivityUnit.Katals);
        public static readonly CatalyticActivityJsonConverter Katals = new CatalyticActivityJsonConverter(CatalyticActivityUnit.Katals);

        private readonly CatalyticActivityUnit unit;

        private CatalyticActivityJsonConverter(CatalyticActivityUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var catalyticActivity = (CatalyticActivity)value;
            serializer.Serialize(writer, catalyticActivity.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CatalyticActivity);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return CatalyticActivity.Parse(stringValue, serializer.Culture);
        }
    }
}