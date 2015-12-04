namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Pressure"/>.
    /// </summary>
    [Serializable]
    public class PressureJsonConverter : JsonConverter
    {
        public static readonly PressureJsonConverter Default = new PressureJsonConverter(PressureUnit.Pascals);
        public static readonly PressureJsonConverter Pascals = new PressureJsonConverter(PressureUnit.Pascals);
        public static readonly PressureJsonConverter Nanopascals = new PressureJsonConverter(PressureUnit.Nanopascals);
        public static readonly PressureJsonConverter Micropascals = new PressureJsonConverter(PressureUnit.Micropascals);
        public static readonly PressureJsonConverter Millipascals = new PressureJsonConverter(PressureUnit.Millipascals);
        public static readonly PressureJsonConverter Kilopascals = new PressureJsonConverter(PressureUnit.Kilopascals);
        public static readonly PressureJsonConverter Megapascals = new PressureJsonConverter(PressureUnit.Megapascals);
        public static readonly PressureJsonConverter Gigapascals = new PressureJsonConverter(PressureUnit.Gigapascals);
        public static readonly PressureJsonConverter Bars = new PressureJsonConverter(PressureUnit.Bars);
        public static readonly PressureJsonConverter Millibars = new PressureJsonConverter(PressureUnit.Millibars);
        public static readonly PressureJsonConverter NewtonsPerSquareMillimetre = new PressureJsonConverter(PressureUnit.NewtonsPerSquareMillimetre);
        public static readonly PressureJsonConverter KilonewtonsPerSquareMillimetre = new PressureJsonConverter(PressureUnit.KilonewtonsPerSquareMillimetre);
        public static readonly PressureJsonConverter NewtonsPerSquareMetre = new PressureJsonConverter(PressureUnit.NewtonsPerSquareMetre);

        private readonly PressureUnit unit;

        private PressureJsonConverter(PressureUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var pressure = (Pressure)value;
            serializer.Serialize(writer, pressure.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Pressure);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Pressure.Parse(stringValue, serializer.Culture);
        }
    }
}