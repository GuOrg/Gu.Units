namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Inductance"/>.
    /// </summary>
    [Serializable]
    public class InductanceJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="InductanceUnit.Henrys"/>
        /// </summary>
        public static readonly InductanceJsonConverter Default = new InductanceJsonConverter(InductanceUnit.Henrys);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="InductanceUnit.Henrys"/>
        /// </summary>
        public static readonly InductanceJsonConverter Henrys = new InductanceJsonConverter(InductanceUnit.Henrys);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="InductanceUnit.Nanohenrys"/>
        /// </summary>
        public static readonly InductanceJsonConverter Nanohenrys = new InductanceJsonConverter(InductanceUnit.Nanohenrys);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="InductanceUnit.Microhenrys"/>
        /// </summary>
        public static readonly InductanceJsonConverter Microhenrys = new InductanceJsonConverter(InductanceUnit.Microhenrys);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="InductanceUnit.Millihenrys"/>
        /// </summary>
        public static readonly InductanceJsonConverter Millihenrys = new InductanceJsonConverter(InductanceUnit.Millihenrys);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="InductanceUnit.Kilohenrys"/>
        /// </summary>
        public static readonly InductanceJsonConverter Kilohenrys = new InductanceJsonConverter(InductanceUnit.Kilohenrys);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="InductanceUnit.Megahenrys"/>
        /// </summary>
        public static readonly InductanceJsonConverter Megahenrys = new InductanceJsonConverter(InductanceUnit.Megahenrys);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="InductanceUnit.Gigahenrys"/>
        /// </summary>
        public static readonly InductanceJsonConverter Gigahenrys = new InductanceJsonConverter(InductanceUnit.Gigahenrys);

        private readonly InductanceUnit unit;

        private InductanceJsonConverter(InductanceUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var inductance = (Inductance)value;
            serializer.Serialize(writer, inductance.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Inductance);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Inductance.Parse(stringValue, serializer.Culture);
        }
    }
}