namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Current"/>.
    /// </summary>
    [Serializable]
    public class CurrentJsonConverter : JsonConverter
    {
        public static readonly CurrentJsonConverter Default = new CurrentJsonConverter(CurrentUnit.Amperes);
        public static readonly CurrentJsonConverter Amperes = new CurrentJsonConverter(CurrentUnit.Amperes);
        public static readonly CurrentJsonConverter Milliamperes = new CurrentJsonConverter(CurrentUnit.Milliamperes);
        public static readonly CurrentJsonConverter Kiloamperes = new CurrentJsonConverter(CurrentUnit.Kiloamperes);
        public static readonly CurrentJsonConverter Megaamperes = new CurrentJsonConverter(CurrentUnit.Megaamperes);
        public static readonly CurrentJsonConverter Microamperes = new CurrentJsonConverter(CurrentUnit.Microamperes);

        private readonly CurrentUnit unit;

        private CurrentJsonConverter(CurrentUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var current = (Current)value;
            serializer.Serialize(writer, current.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Current);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Current.Parse(stringValue, serializer.Culture);
        }
    }
}