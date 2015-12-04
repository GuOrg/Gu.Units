namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Power"/>.
    /// </summary>
    [Serializable]
    public class PowerJsonConverter : JsonConverter
    {
        public static readonly PowerJsonConverter Default = new PowerJsonConverter(PowerUnit.Watts);
        public static readonly PowerJsonConverter Watts = new PowerJsonConverter(PowerUnit.Watts);
        public static readonly PowerJsonConverter Nanowatts = new PowerJsonConverter(PowerUnit.Nanowatts);
        public static readonly PowerJsonConverter Microwatts = new PowerJsonConverter(PowerUnit.Microwatts);
        public static readonly PowerJsonConverter Milliwatts = new PowerJsonConverter(PowerUnit.Milliwatts);
        public static readonly PowerJsonConverter Kilowatts = new PowerJsonConverter(PowerUnit.Kilowatts);
        public static readonly PowerJsonConverter Megawatts = new PowerJsonConverter(PowerUnit.Megawatts);
        public static readonly PowerJsonConverter Gigawatts = new PowerJsonConverter(PowerUnit.Gigawatts);

        private readonly PowerUnit unit;

        private PowerJsonConverter(PowerUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var power = (Power)value;
            serializer.Serialize(writer, power.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Power);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Power.Parse(stringValue, serializer.Culture);
        }
    }
}