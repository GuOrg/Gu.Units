#nullable enable
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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DataUnit.Bits"/>
        /// </summary>
        public static readonly DataJsonConverter Default = new DataJsonConverter(DataUnit.Bits);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DataUnit.Bits"/>
        /// </summary>
        public static readonly DataJsonConverter Bits = new DataJsonConverter(DataUnit.Bits);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DataUnit.Byte"/>
        /// </summary>
        public static readonly DataJsonConverter Byte = new DataJsonConverter(DataUnit.Byte);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DataUnit.Kilobyte"/>
        /// </summary>
        public static readonly DataJsonConverter Kilobyte = new DataJsonConverter(DataUnit.Kilobyte);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DataUnit.Megabyte"/>
        /// </summary>
        public static readonly DataJsonConverter Megabyte = new DataJsonConverter(DataUnit.Megabyte);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DataUnit.Gigabyte"/>
        /// </summary>
        public static readonly DataJsonConverter Gigabyte = new DataJsonConverter(DataUnit.Gigabyte);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DataUnit.Terabyte"/>
        /// </summary>
        public static readonly DataJsonConverter Terabyte = new DataJsonConverter(DataUnit.Terabyte);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DataUnit.Megabits"/>
        /// </summary>
        public static readonly DataJsonConverter Megabits = new DataJsonConverter(DataUnit.Megabits);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DataUnit.Gigabits"/>
        /// </summary>
        public static readonly DataJsonConverter Gigabits = new DataJsonConverter(DataUnit.Gigabits);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="DataUnit.Kilobits"/>
        /// </summary>
        public static readonly DataJsonConverter Kilobits = new DataJsonConverter(DataUnit.Kilobits);

        private readonly DataUnit unit;

        private DataJsonConverter(DataUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var data = (Data)value!;
            serializer.Serialize(writer, data.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Data);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return Data.Parse(stringValue, serializer.Culture);
        }
    }
}
