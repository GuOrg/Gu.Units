namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Data"/>.
    /// </summary>
    [Serializable]
    public class DataJsonConverter : JsonConverter
    {
        public static readonly DataJsonConverter Default = new DataJsonConverter(DataUnit.Bits);
        public static readonly DataJsonConverter Bits = new DataJsonConverter(DataUnit.Bits);
        public static readonly DataJsonConverter Byte = new DataJsonConverter(DataUnit.Byte);
        public static readonly DataJsonConverter Kilobyte = new DataJsonConverter(DataUnit.Kilobyte);
        public static readonly DataJsonConverter Megabyte = new DataJsonConverter(DataUnit.Megabyte);
        public static readonly DataJsonConverter Gigabyte = new DataJsonConverter(DataUnit.Gigabyte);
        public static readonly DataJsonConverter Terabyte = new DataJsonConverter(DataUnit.Terabyte);
        public static readonly DataJsonConverter Megabits = new DataJsonConverter(DataUnit.Megabits);
        public static readonly DataJsonConverter Gigabits = new DataJsonConverter(DataUnit.Gigabits);
        public static readonly DataJsonConverter Kilobits = new DataJsonConverter(DataUnit.Kilobits);

        private readonly DataUnit unit;

        private DataJsonConverter(DataUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var data = (Data)value;
            serializer.Serialize(writer, data.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Data);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Data.Parse(stringValue, serializer.Culture);
        }
    }
}