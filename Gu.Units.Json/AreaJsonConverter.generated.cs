namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Area"/>.
    /// </summary>
    [Serializable]
    public class AreaJsonConverter : JsonConverter
    {
        public static readonly AreaJsonConverter Default = new AreaJsonConverter(AreaUnit.SquareMetres);
        public static readonly AreaJsonConverter SquareMetres = new AreaJsonConverter(AreaUnit.SquareMetres);
        public static readonly AreaJsonConverter SquareMillimetres = new AreaJsonConverter(AreaUnit.SquareMillimetres);
        public static readonly AreaJsonConverter SquareCentimetres = new AreaJsonConverter(AreaUnit.SquareCentimetres);
        public static readonly AreaJsonConverter SquareDecimetres = new AreaJsonConverter(AreaUnit.SquareDecimetres);
        public static readonly AreaJsonConverter SquareKilometres = new AreaJsonConverter(AreaUnit.SquareKilometres);
        public static readonly AreaJsonConverter SquareInches = new AreaJsonConverter(AreaUnit.SquareInches);
        public static readonly AreaJsonConverter Hectare = new AreaJsonConverter(AreaUnit.Hectare);
        public static readonly AreaJsonConverter SquareMile = new AreaJsonConverter(AreaUnit.SquareMile);
        public static readonly AreaJsonConverter SquareYard = new AreaJsonConverter(AreaUnit.SquareYard);

        private readonly AreaUnit unit;

        private AreaJsonConverter(AreaUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var area = (Area)value;
            serializer.Serialize(writer, area.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Area);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Area.Parse(stringValue, serializer.Culture);
        }
    }
}