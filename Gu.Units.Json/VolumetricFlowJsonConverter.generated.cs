#nullable enable
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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.CubicMetresPerSecond"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter Default = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CubicMetresPerSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.CubicMetresPerSecond"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter CubicMetresPerSecond = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CubicMetresPerSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.CubicMetresPerMinute"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter CubicMetresPerMinute = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CubicMetresPerMinute);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.CubicMetresPerHour"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter CubicMetresPerHour = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CubicMetresPerHour);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.LitresPerSecond"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter LitresPerSecond = new VolumetricFlowJsonConverter(VolumetricFlowUnit.LitresPerSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.LitresPerHour"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter LitresPerHour = new VolumetricFlowJsonConverter(VolumetricFlowUnit.LitresPerHour);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.LitresPerMinute"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter LitresPerMinute = new VolumetricFlowJsonConverter(VolumetricFlowUnit.LitresPerMinute);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.MillilitresPerSecond"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter MillilitresPerSecond = new VolumetricFlowJsonConverter(VolumetricFlowUnit.MillilitresPerSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.MillilitresPerHour"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter MillilitresPerHour = new VolumetricFlowJsonConverter(VolumetricFlowUnit.MillilitresPerHour);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.MillilitresPerMinute"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter MillilitresPerMinute = new VolumetricFlowJsonConverter(VolumetricFlowUnit.MillilitresPerMinute);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.CentilitresPerSecond"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter CentilitresPerSecond = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CentilitresPerSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.CentilitresPerHour"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter CentilitresPerHour = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CentilitresPerHour);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.CentilitresPerMinute"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter CentilitresPerMinute = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CentilitresPerMinute);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.CubicFeetPerHour"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter CubicFeetPerHour = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CubicFeetPerHour);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.CubicFeetPerSecond"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter CubicFeetPerSecond = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CubicFeetPerSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.CubicFeetPerMinute"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter CubicFeetPerMinute = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CubicFeetPerMinute);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="VolumetricFlowUnit.CubicFeetPerDay"/>
        /// </summary>
        public static readonly VolumetricFlowJsonConverter CubicFeetPerDay = new VolumetricFlowJsonConverter(VolumetricFlowUnit.CubicFeetPerDay);

        private readonly VolumetricFlowUnit unit;

        private VolumetricFlowJsonConverter(VolumetricFlowUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var volumetricFlow = (VolumetricFlow)value;
            serializer.Serialize(writer, volumetricFlow.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(VolumetricFlow);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value;
            return VolumetricFlow.Parse(stringValue, serializer.Culture);
        }
    }
}
