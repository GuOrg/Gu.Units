namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Jerk"/>.
    /// </summary>
    [Serializable]
    public class JerkJsonConverter : JsonConverter
    {
        public static readonly JerkJsonConverter Default = new JerkJsonConverter(JerkUnit.MetresPerSecondCubed);
        public static readonly JerkJsonConverter MetresPerSecondCubed = new JerkJsonConverter(JerkUnit.MetresPerSecondCubed);
        public static readonly JerkJsonConverter MillimetresPerSecondCubed = new JerkJsonConverter(JerkUnit.MillimetresPerSecondCubed);
        public static readonly JerkJsonConverter MillimetresPerHourCubed = new JerkJsonConverter(JerkUnit.MillimetresPerHourCubed);
        public static readonly JerkJsonConverter MillimetresPerMinuteCubed = new JerkJsonConverter(JerkUnit.MillimetresPerMinuteCubed);
        public static readonly JerkJsonConverter MetresPerHourCubed = new JerkJsonConverter(JerkUnit.MetresPerHourCubed);
        public static readonly JerkJsonConverter MetresPerMinuteCubed = new JerkJsonConverter(JerkUnit.MetresPerMinuteCubed);
        public static readonly JerkJsonConverter NanometresPerHourCubed = new JerkJsonConverter(JerkUnit.NanometresPerHourCubed);
        public static readonly JerkJsonConverter NanometresPerMinuteCubed = new JerkJsonConverter(JerkUnit.NanometresPerMinuteCubed);
        public static readonly JerkJsonConverter CentimetresPerSecondCubed = new JerkJsonConverter(JerkUnit.CentimetresPerSecondCubed);
        public static readonly JerkJsonConverter CentimetresPerHourCubed = new JerkJsonConverter(JerkUnit.CentimetresPerHourCubed);
        public static readonly JerkJsonConverter CentimetresPerMinuteCubed = new JerkJsonConverter(JerkUnit.CentimetresPerMinuteCubed);

        private readonly JerkUnit unit;

        private JerkJsonConverter(JerkUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jerk = (Jerk)value;
            serializer.Serialize(writer, jerk.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Jerk);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Jerk.Parse(stringValue, serializer.Culture);
        }
    }
}