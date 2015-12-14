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
        public static readonly VolumetricFlowJsonConverter CubicMetresPerMinute = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CubicMetresPerMinute);
        public static readonly VolumetricFlowJsonConverter CubicMetresPerHour = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CubicMetresPerHour);
        public static readonly VolumetricFlowJsonConverter LitresPerSecond = new VolumetricFlowJsonConverter(VolumetricFlowUnit.LitresPerSecond);
        public static readonly VolumetricFlowJsonConverter LitresPerHour = new VolumetricFlowJsonConverter(VolumetricFlowUnit.LitresPerHour);
        public static readonly VolumetricFlowJsonConverter LitresPerMinute = new VolumetricFlowJsonConverter(VolumetricFlowUnit.LitresPerMinute);
        public static readonly VolumetricFlowJsonConverter MillilitresPerSecond = new VolumetricFlowJsonConverter(VolumetricFlowUnit.MillilitresPerSecond);
        public static readonly VolumetricFlowJsonConverter MillilitresPerHour = new VolumetricFlowJsonConverter(VolumetricFlowUnit.MillilitresPerHour);
        public static readonly VolumetricFlowJsonConverter MillilitresPerMinute = new VolumetricFlowJsonConverter(VolumetricFlowUnit.MillilitresPerMinute);
        public static readonly VolumetricFlowJsonConverter CentilitresPerSecond = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CentilitresPerSecond);
        public static readonly VolumetricFlowJsonConverter CentilitresPerHour = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CentilitresPerHour);
        public static readonly VolumetricFlowJsonConverter CentilitresPerMinute = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CentilitresPerMinute);

        private readonly VolumetricFlowUnit unit;

        private VolumetricFlowJsonConverter(VolumetricFlowUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var volumetricFlow = (VolumetricFlow)value;
            serializer.Serialize(writer, volumetricFlow.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(VolumetricFlow);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return VolumetricFlow.Parse(stringValue, serializer.Culture);
        }
    }
}