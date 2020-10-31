#nullable enable
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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="FlexibilityUnit.MetresPerNewton"/>
        /// </summary>
        public static readonly FlexibilityJsonConverter Default = new FlexibilityJsonConverter(FlexibilityUnit.MetresPerNewton);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="FlexibilityUnit.MetresPerNewton"/>
        /// </summary>
        public static readonly FlexibilityJsonConverter MetresPerNewton = new FlexibilityJsonConverter(FlexibilityUnit.MetresPerNewton);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="FlexibilityUnit.MillimetresPerNewton"/>
        /// </summary>
        public static readonly FlexibilityJsonConverter MillimetresPerNewton = new FlexibilityJsonConverter(FlexibilityUnit.MillimetresPerNewton);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="FlexibilityUnit.MillimetresPerKilonewton"/>
        /// </summary>
        public static readonly FlexibilityJsonConverter MillimetresPerKilonewton = new FlexibilityJsonConverter(FlexibilityUnit.MillimetresPerKilonewton);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="FlexibilityUnit.MicrometresPerKilonewton"/>
        /// </summary>
        public static readonly FlexibilityJsonConverter MicrometresPerKilonewton = new FlexibilityJsonConverter(FlexibilityUnit.MicrometresPerKilonewton);

        private readonly FlexibilityUnit unit;

        private FlexibilityJsonConverter(FlexibilityUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var flexibility = (Flexibility)value;
            serializer.Serialize(writer, flexibility.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Flexibility);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Flexibility.Parse(stringValue, serializer.Culture);
        }
    }
}
