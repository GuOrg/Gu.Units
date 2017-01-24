





namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.ForcePerUnitless"/>.
    /// </summary>
    [Serializable]
    public class ForcePerUnitlessJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForcePerUnitlessUnit.NewtonsPerUnitless"/>
        /// </summary>
        public static readonly ForcePerUnitlessJsonConverter Default = new ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit.NewtonsPerUnitless);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForcePerUnitlessUnit.NewtonsPerUnitless"/>
        /// </summary>
        public static readonly ForcePerUnitlessJsonConverter NewtonsPerUnitless = new ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit.NewtonsPerUnitless);


        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForcePerUnitlessUnit.NewtonsPerPercent"/>
        /// </summary>
        public static readonly ForcePerUnitlessJsonConverter NewtonsPerPercent = new ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit.NewtonsPerPercent);


        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForcePerUnitlessUnit.KilonewtonsPerPercent"/>
        /// </summary>
        public static readonly ForcePerUnitlessJsonConverter KilonewtonsPerPercent = new ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit.KilonewtonsPerPercent);


        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForcePerUnitlessUnit.MeganewtonsPerPercent"/>
        /// </summary>
        public static readonly ForcePerUnitlessJsonConverter MeganewtonsPerPercent = new ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit.MeganewtonsPerPercent);


        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ForcePerUnitlessUnit.GiganewtonsPerPercent"/>
        /// </summary>
        public static readonly ForcePerUnitlessJsonConverter GiganewtonsPerPercent = new ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit.GiganewtonsPerPercent);


        private readonly ForcePerUnitlessUnit unit;

        private ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var forcePerUnitless = (ForcePerUnitless)value;
            serializer.Serialize(writer, forcePerUnitless.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ForcePerUnitless);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return ForcePerUnitless.Parse(stringValue, serializer.Culture);
        }
    }
}