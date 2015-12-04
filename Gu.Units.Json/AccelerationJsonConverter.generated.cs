namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Acceleration"/>.
    /// </summary>
    [Serializable]
    public class AccelerationJsonConverter : JsonConverter
    {
        public static readonly AccelerationJsonConverter Default = new AccelerationJsonConverter(AccelerationUnit.MetresPerSecondSquared);
        public static readonly AccelerationJsonConverter MetresPerSecondSquared = new AccelerationJsonConverter(AccelerationUnit.MetresPerSecondSquared);
        public static readonly AccelerationJsonConverter MillimetresPerSecondSquared = new AccelerationJsonConverter(AccelerationUnit.MillimetresPerSecondSquared);
        public static readonly AccelerationJsonConverter CentimetresPerSecondSquared = new AccelerationJsonConverter(AccelerationUnit.CentimetresPerSecondSquared);

        private readonly AccelerationUnit unit;

        private AccelerationJsonConverter(AccelerationUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var acceleration = (Acceleration)value;
            serializer.Serialize(writer, acceleration.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Acceleration);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Acceleration.Parse(stringValue, serializer.Culture);
        }
    }
}