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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AreaUnit.SquareMetres"/>
        /// </summary>
        public static readonly AreaJsonConverter Default = new AreaJsonConverter(AreaUnit.SquareMetres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AreaUnit.SquareMetres"/>
        /// </summary>
        public static readonly AreaJsonConverter SquareMetres = new AreaJsonConverter(AreaUnit.SquareMetres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AreaUnit.Hectare"/>
        /// </summary>
        public static readonly AreaJsonConverter Hectare = new AreaJsonConverter(AreaUnit.Hectare);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AreaUnit.SquareMillimetres"/>
        /// </summary>
        public static readonly AreaJsonConverter SquareMillimetres = new AreaJsonConverter(AreaUnit.SquareMillimetres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AreaUnit.SquareCentimetres"/>
        /// </summary>
        public static readonly AreaJsonConverter SquareCentimetres = new AreaJsonConverter(AreaUnit.SquareCentimetres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AreaUnit.SquareDecimetres"/>
        /// </summary>
        public static readonly AreaJsonConverter SquareDecimetres = new AreaJsonConverter(AreaUnit.SquareDecimetres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AreaUnit.SquareKilometres"/>
        /// </summary>
        public static readonly AreaJsonConverter SquareKilometres = new AreaJsonConverter(AreaUnit.SquareKilometres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AreaUnit.SquareMile"/>
        /// </summary>
        public static readonly AreaJsonConverter SquareMile = new AreaJsonConverter(AreaUnit.SquareMile);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AreaUnit.SquareYard"/>
        /// </summary>
        public static readonly AreaJsonConverter SquareYard = new AreaJsonConverter(AreaUnit.SquareYard);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AreaUnit.SquareInches"/>
        /// </summary>
        public static readonly AreaJsonConverter SquareInches = new AreaJsonConverter(AreaUnit.SquareInches);

        private readonly AreaUnit unit;

        private AreaJsonConverter(AreaUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var area = (Area)value;
            serializer.Serialize(writer, area.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Area);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Area.Parse(stringValue, serializer.Culture);
        }
    }
}