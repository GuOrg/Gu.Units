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
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="StiffnessUnit.NewtonsPerMetre"/>
        /// </summary>
        public static readonly StiffnessJsonConverter Default = new StiffnessJsonConverter(StiffnessUnit.NewtonsPerMetre);
       
	    /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="StiffnessUnit.NewtonsPerMetre"/>
        /// </summary>
        public static readonly StiffnessJsonConverter NewtonsPerMetre = new StiffnessJsonConverter(StiffnessUnit.NewtonsPerMetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="StiffnessUnit.NewtonsPerNanometre"/>
        /// </summary>
        public static readonly StiffnessJsonConverter NewtonsPerNanometre = new StiffnessJsonConverter(StiffnessUnit.NewtonsPerNanometre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="StiffnessUnit.NewtonsPerMicrometre"/>
        /// </summary>
        public static readonly StiffnessJsonConverter NewtonsPerMicrometre = new StiffnessJsonConverter(StiffnessUnit.NewtonsPerMicrometre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="StiffnessUnit.NewtonsPerMillimetre"/>
        /// </summary>
        public static readonly StiffnessJsonConverter NewtonsPerMillimetre = new StiffnessJsonConverter(StiffnessUnit.NewtonsPerMillimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="StiffnessUnit.KilonewtonsPerNanometre"/>
        /// </summary>
        public static readonly StiffnessJsonConverter KilonewtonsPerNanometre = new StiffnessJsonConverter(StiffnessUnit.KilonewtonsPerNanometre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="StiffnessUnit.KilonewtonsPerMicrometre"/>
        /// </summary>
        public static readonly StiffnessJsonConverter KilonewtonsPerMicrometre = new StiffnessJsonConverter(StiffnessUnit.KilonewtonsPerMicrometre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="StiffnessUnit.KilonewtonsPerMillimetre"/>
        /// </summary>
        public static readonly StiffnessJsonConverter KilonewtonsPerMillimetre = new StiffnessJsonConverter(StiffnessUnit.KilonewtonsPerMillimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="StiffnessUnit.MeganewtonsPerNanometre"/>
        /// </summary>
        public static readonly StiffnessJsonConverter MeganewtonsPerNanometre = new StiffnessJsonConverter(StiffnessUnit.MeganewtonsPerNanometre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="StiffnessUnit.MeganewtonsPerMicrometre"/>
        /// </summary>
        public static readonly StiffnessJsonConverter MeganewtonsPerMicrometre = new StiffnessJsonConverter(StiffnessUnit.MeganewtonsPerMicrometre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="StiffnessUnit.MeganewtonsPerMillimetre"/>
        /// </summary>
        public static readonly StiffnessJsonConverter MeganewtonsPerMillimetre = new StiffnessJsonConverter(StiffnessUnit.MeganewtonsPerMillimetre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="StiffnessUnit.GiganewtonsPerMicrometre"/>
        /// </summary>
        public static readonly StiffnessJsonConverter GiganewtonsPerMicrometre = new StiffnessJsonConverter(StiffnessUnit.GiganewtonsPerMicrometre);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="StiffnessUnit.GiganewtonsPerMillimetre"/>
        /// </summary>
        public static readonly StiffnessJsonConverter GiganewtonsPerMillimetre = new StiffnessJsonConverter(StiffnessUnit.GiganewtonsPerMillimetre);

        private readonly StiffnessUnit unit;

        private StiffnessJsonConverter(StiffnessUnit unit)
        {
            this.unit = unit;
        }

		/// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var stiffness = (Stiffness)value;
            serializer.Serialize(writer, stiffness.ToString(this.unit, serializer.Culture));
        }

		/// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Stiffness);
        }

		/// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;
            return Stiffness.Parse(stringValue, serializer.Culture);
        }
    }
}