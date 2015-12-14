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
        public static readonly StiffnessJsonConverter NewtonsPerNanometre = new StiffnessJsonConverter(StiffnessUnit.NewtonsPerNanometre);
        public static readonly StiffnessJsonConverter NewtonsPerMicrometre = new StiffnessJsonConverter(StiffnessUnit.NewtonsPerMicrometre);
        public static readonly StiffnessJsonConverter NewtonsPerMillimetre = new StiffnessJsonConverter(StiffnessUnit.NewtonsPerMillimetre);
        public static readonly StiffnessJsonConverter KilonewtonsPerNanometre = new StiffnessJsonConverter(StiffnessUnit.KilonewtonsPerNanometre);
        public static readonly StiffnessJsonConverter KilonewtonsPerMicrometre = new StiffnessJsonConverter(StiffnessUnit.KilonewtonsPerMicrometre);
        public static readonly StiffnessJsonConverter KilonewtonsPerMillimetre = new StiffnessJsonConverter(StiffnessUnit.KilonewtonsPerMillimetre);
        public static readonly StiffnessJsonConverter MeganewtonsPerNanometre = new StiffnessJsonConverter(StiffnessUnit.MeganewtonsPerNanometre);
        public static readonly StiffnessJsonConverter MeganewtonsPerMicrometre = new StiffnessJsonConverter(StiffnessUnit.MeganewtonsPerMicrometre);
        public static readonly StiffnessJsonConverter MeganewtonsPerMillimetre = new StiffnessJsonConverter(StiffnessUnit.MeganewtonsPerMillimetre);
        public static readonly StiffnessJsonConverter GiganewtonsPerMicrometre = new StiffnessJsonConverter(StiffnessUnit.GiganewtonsPerMicrometre);
        public static readonly StiffnessJsonConverter GiganewtonsPerMillimetre = new StiffnessJsonConverter(StiffnessUnit.GiganewtonsPerMillimetre);

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