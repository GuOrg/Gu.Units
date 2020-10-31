#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.LengthPerUnitless"/>.
    /// </summary>
    [Serializable]
    public class LengthPerUnitlessJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthPerUnitlessUnit.MetresPerUnitless"/>
        /// </summary>
        public static readonly LengthPerUnitlessJsonConverter Default = new LengthPerUnitlessJsonConverter(LengthPerUnitlessUnit.MetresPerUnitless);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthPerUnitlessUnit.MetresPerUnitless"/>
        /// </summary>
        public static readonly LengthPerUnitlessJsonConverter MetresPerUnitless = new LengthPerUnitlessJsonConverter(LengthPerUnitlessUnit.MetresPerUnitless);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthPerUnitlessUnit.MillimetresPerPercent"/>
        /// </summary>
        public static readonly LengthPerUnitlessJsonConverter MillimetresPerPercent = new LengthPerUnitlessJsonConverter(LengthPerUnitlessUnit.MillimetresPerPercent);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthPerUnitlessUnit.MicrometresPerPercent"/>
        /// </summary>
        public static readonly LengthPerUnitlessJsonConverter MicrometresPerPercent = new LengthPerUnitlessJsonConverter(LengthPerUnitlessUnit.MicrometresPerPercent);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="LengthPerUnitlessUnit.MetresPerPercent"/>
        /// </summary>
        public static readonly LengthPerUnitlessJsonConverter MetresPerPercent = new LengthPerUnitlessJsonConverter(LengthPerUnitlessUnit.MetresPerPercent);

        private readonly LengthPerUnitlessUnit unit;

        private LengthPerUnitlessJsonConverter(LengthPerUnitlessUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var lengthPerUnitless = (LengthPerUnitless)value;
            serializer.Serialize(writer, lengthPerUnitless.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(LengthPerUnitless);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return LengthPerUnitless.Parse(stringValue, serializer.Culture);
        }
    }
}
