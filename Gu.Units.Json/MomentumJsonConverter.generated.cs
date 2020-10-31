namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Momentum"/>.
    /// </summary>
    [Serializable]
    public class MomentumJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MomentumUnit.NewtonSecond"/>
        /// </summary>
        public static readonly MomentumJsonConverter Default = new MomentumJsonConverter(MomentumUnit.NewtonSecond);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="MomentumUnit.NewtonSecond"/>
        /// </summary>
        public static readonly MomentumJsonConverter NewtonSecond = new MomentumJsonConverter(MomentumUnit.NewtonSecond);

        private readonly MomentumUnit unit;

        private MomentumJsonConverter(MomentumUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var momentum = (Momentum)value;
            serializer.Serialize(writer, momentum.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Momentum);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Momentum.Parse(stringValue, serializer.Culture);
        }
    }
}
