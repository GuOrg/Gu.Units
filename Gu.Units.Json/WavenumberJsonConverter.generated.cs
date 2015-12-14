namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Wavenumber"/>.
    /// </summary>
    [Serializable]
    public class WavenumberJsonConverter : JsonConverter
    {
        public static readonly WavenumberJsonConverter Default = new WavenumberJsonConverter(WavenumberUnit.ReciprocalMetres);
        public static readonly WavenumberJsonConverter ReciprocalMetres = new WavenumberJsonConverter(WavenumberUnit.ReciprocalMetres);

        private readonly WavenumberUnit unit;

        private WavenumberJsonConverter(WavenumberUnit unit)
        {
            this.unit = unit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var wavenumber = (Wavenumber)value;
            serializer.Serialize(writer, wavenumber.ToString(this.unit, serializer.Culture));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Wavenumber);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Wavenumber.Parse(stringValue, serializer.Culture);
        }
    }
}