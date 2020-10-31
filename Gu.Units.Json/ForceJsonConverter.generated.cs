#nullable enable
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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForceUnit.Newtons"/>
        /// </summary>
        public static readonly ForceJsonConverter Default = new ForceJsonConverter(ForceUnit.Newtons);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForceUnit.Newtons"/>
        /// </summary>
        public static readonly ForceJsonConverter Newtons = new ForceJsonConverter(ForceUnit.Newtons);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForceUnit.Nanonewtons"/>
        /// </summary>
        public static readonly ForceJsonConverter Nanonewtons = new ForceJsonConverter(ForceUnit.Nanonewtons);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForceUnit.Micronewtons"/>
        /// </summary>
        public static readonly ForceJsonConverter Micronewtons = new ForceJsonConverter(ForceUnit.Micronewtons);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForceUnit.Millinewtons"/>
        /// </summary>
        public static readonly ForceJsonConverter Millinewtons = new ForceJsonConverter(ForceUnit.Millinewtons);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForceUnit.Kilonewtons"/>
        /// </summary>
        public static readonly ForceJsonConverter Kilonewtons = new ForceJsonConverter(ForceUnit.Kilonewtons);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForceUnit.Meganewtons"/>
        /// </summary>
        public static readonly ForceJsonConverter Meganewtons = new ForceJsonConverter(ForceUnit.Meganewtons);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForceUnit.Giganewtons"/>
        /// </summary>
        public static readonly ForceJsonConverter Giganewtons = new ForceJsonConverter(ForceUnit.Giganewtons);

        private readonly ForceUnit unit;

        private ForceJsonConverter(ForceUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var force = (Force)value;
            serializer.Serialize(writer, force.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Force);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Force.Parse(stringValue, serializer.Culture);
        }
    }
}
