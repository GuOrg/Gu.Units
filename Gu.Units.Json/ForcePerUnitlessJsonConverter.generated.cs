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
        public static readonly ForcePerUnitlessJsonConverter Default = new ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit.NewtonsPerUnitless);
        public static readonly ForcePerUnitlessJsonConverter NewtonsPerUnitless = new ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit.NewtonsPerUnitless);
        public static readonly ForcePerUnitlessJsonConverter NewtonsPerPercent = new ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit.NewtonsPerPercent);
        public static readonly ForcePerUnitlessJsonConverter KilonewtonsPerPercent = new ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit.KilonewtonsPerPercent);
        public static readonly ForcePerUnitlessJsonConverter MeganewtonsPerPercent = new ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit.MeganewtonsPerPercent);
        public static readonly ForcePerUnitlessJsonConverter GiganewtonsPerPercent = new ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit.GiganewtonsPerPercent);

        private readonly ForcePerUnitlessUnit unit;

        private ForcePerUnitlessJsonConverter(ForcePerUnitlessUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var forcePerUnitless = (ForcePerUnitless)value;
            serializer.Serialize(writer, forcePerUnitless.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ForcePerUnitless);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return ForcePerUnitless.Parse(stringValue, serializer.Culture);
        }
    }
}