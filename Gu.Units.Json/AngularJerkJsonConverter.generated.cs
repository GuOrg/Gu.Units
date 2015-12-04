namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.AngularJerk"/>.
    /// </summary>
    [Serializable]
    public class AngularJerkJsonConverter : JsonConverter
    {
        public static readonly AngularJerkJsonConverter Default = new AngularJerkJsonConverter(AngularJerkUnit.RadiansPerSecondCubed);
        public static readonly AngularJerkJsonConverter RadiansPerSecondCubed = new AngularJerkJsonConverter(AngularJerkUnit.RadiansPerSecondCubed);
        public static readonly AngularJerkJsonConverter DegreesPerSecondCubed = new AngularJerkJsonConverter(AngularJerkUnit.DegreesPerSecondCubed);
        public static readonly AngularJerkJsonConverter RadiansPerHourCubed = new AngularJerkJsonConverter(AngularJerkUnit.RadiansPerHourCubed);
        public static readonly AngularJerkJsonConverter DegreesPerHourCubed = new AngularJerkJsonConverter(AngularJerkUnit.DegreesPerHourCubed);
        public static readonly AngularJerkJsonConverter RadiansPerMinuteCubed = new AngularJerkJsonConverter(AngularJerkUnit.RadiansPerMinuteCubed);
        public static readonly AngularJerkJsonConverter DegreesPerMinuteCubed = new AngularJerkJsonConverter(AngularJerkUnit.DegreesPerMinuteCubed);

        private readonly AngularJerkUnit unit;

        private AngularJerkJsonConverter(AngularJerkUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var angularJerk = (AngularJerk)value;
            serializer.Serialize(writer, angularJerk.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AngularJerk);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return AngularJerk.Parse(stringValue, serializer.Culture);
        }
    }
}