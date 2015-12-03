namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.VolumetricFlow"/>.
    /// </summary>
    [Serializable]
    public class VolumetricFlowJsonConverter : JsonConverter
    {
        public static readonly VolumetricFlowJsonConverter Default = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CubicMetresPerSecond);
        public static readonly VolumetricFlowJsonConverter CubicMetresPerSecond = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CubicMetresPerSecond);

        private readonly VolumetricFlowUnit unit;

        private VolumetricFlowJsonConverter(VolumetricFlowUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var volumetricFlow = (VolumetricFlow)value;
            serializer.Serialize(writer, volumetricFlow.ToString(this.unit, writer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(VolumetricFlow);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return VolumetricFlow.Parse(stringValue, reader.Culture);
        }
    }
}