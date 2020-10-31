#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Torque"/>.
    /// </summary>
    [Serializable]
    public class TorqueJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TorqueUnit.NewtonMetres"/>
        /// </summary>
        public static readonly TorqueJsonConverter Default = new TorqueJsonConverter(TorqueUnit.NewtonMetres);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="TorqueUnit.NewtonMetres"/>
        /// </summary>
        public static readonly TorqueJsonConverter NewtonMetres = new TorqueJsonConverter(TorqueUnit.NewtonMetres);

        private readonly TorqueUnit unit;

        private TorqueJsonConverter(TorqueUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var torque = (Torque)value!;
            serializer.Serialize(writer, torque.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Torque);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return Torque.Parse(stringValue, serializer.Culture);
        }
    }
}
