#nullable enable
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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CurrentUnit.Amperes"/>
        /// </summary>
        public static readonly CurrentJsonConverter Default = new CurrentJsonConverter(CurrentUnit.Amperes);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CurrentUnit.Amperes"/>
        /// </summary>
        public static readonly CurrentJsonConverter Amperes = new CurrentJsonConverter(CurrentUnit.Amperes);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CurrentUnit.Milliamperes"/>
        /// </summary>
        public static readonly CurrentJsonConverter Milliamperes = new CurrentJsonConverter(CurrentUnit.Milliamperes);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CurrentUnit.Kiloamperes"/>
        /// </summary>
        public static readonly CurrentJsonConverter Kiloamperes = new CurrentJsonConverter(CurrentUnit.Kiloamperes);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CurrentUnit.Megaamperes"/>
        /// </summary>
        public static readonly CurrentJsonConverter Megaamperes = new CurrentJsonConverter(CurrentUnit.Megaamperes);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CurrentUnit.Microamperes"/>
        /// </summary>
        public static readonly CurrentJsonConverter Microamperes = new CurrentJsonConverter(CurrentUnit.Microamperes);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CurrentUnit.Nanoamperes"/>
        /// </summary>
        public static readonly CurrentJsonConverter Nanoamperes = new CurrentJsonConverter(CurrentUnit.Nanoamperes);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="CurrentUnit.Gigaamperes"/>
        /// </summary>
        public static readonly CurrentJsonConverter Gigaamperes = new CurrentJsonConverter(CurrentUnit.Gigaamperes);

        private readonly CurrentUnit unit;

        private CurrentJsonConverter(CurrentUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var current = (Current)value!;
            serializer.Serialize(writer, current.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Current);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return Current.Parse(stringValue, serializer.Culture);
        }
    }
}
