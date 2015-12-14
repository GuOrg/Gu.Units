namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.LuminousFlux"/>.
    /// </summary>
    [Serializable]
    public class LuminousFluxJsonConverter : JsonConverter
    {
        public static readonly LuminousFluxJsonConverter Default = new LuminousFluxJsonConverter(LuminousFluxUnit.Lumens);
        public static readonly LuminousFluxJsonConverter Lumens = new LuminousFluxJsonConverter(LuminousFluxUnit.Lumens);

        private readonly LuminousFluxUnit unit;

        private LuminousFluxJsonConverter(LuminousFluxUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var luminousFlux = (LuminousFlux)value;
            serializer.Serialize(writer, luminousFlux.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(LuminousFlux);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return LuminousFlux.Parse(stringValue, serializer.Culture);
        }
    }
}