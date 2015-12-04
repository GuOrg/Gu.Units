namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Stiffness"/>.
    /// </summary>
    [Serializable]
    public class StiffnessJsonConverter : JsonConverter
    {
        public static readonly StiffnessJsonConverter Default = new StiffnessJsonConverter(StiffnessUnit.NewtonsPerMetre);
        public static readonly StiffnessJsonConverter NewtonsPerMetre = new StiffnessJsonConverter(StiffnessUnit.NewtonsPerMetre);

        private readonly StiffnessUnit unit;

        private StiffnessJsonConverter(StiffnessUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var stiffness = (Stiffness)value;
            serializer.Serialize(writer, stiffness.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Stiffness);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Stiffness.Parse(stringValue, serializer.Culture);
        }
    }
}