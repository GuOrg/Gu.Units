namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.MassFlow"/>.
    /// </summary>
    [Serializable]
    public class MassFlowJsonConverter : JsonConverter
    {
        public static readonly MassFlowJsonConverter Default = new MassFlowJsonConverter(MassFlowUnit.KilogramsPerSecond);
        public static readonly MassFlowJsonConverter KilogramsPerSecond = new MassFlowJsonConverter(MassFlowUnit.KilogramsPerSecond);

        private readonly MassFlowUnit unit;

        private MassFlowJsonConverter(MassFlowUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var massFlow = (MassFlow)value;
            serializer.Serialize(writer, massFlow.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MassFlow);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return MassFlow.Parse(stringValue, serializer.Culture);
        }
    }
}