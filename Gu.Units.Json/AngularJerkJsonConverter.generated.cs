#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.AngularJerk"/>.
    /// </summary>
    [Serializable]
    public class AngularJerkJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularJerkUnit.RadiansPerSecondCubed"/>
        /// </summary>
        public static readonly AngularJerkJsonConverter Default = new AngularJerkJsonConverter(AngularJerkUnit.RadiansPerSecondCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularJerkUnit.RadiansPerSecondCubed"/>
        /// </summary>
        public static readonly AngularJerkJsonConverter RadiansPerSecondCubed = new AngularJerkJsonConverter(AngularJerkUnit.RadiansPerSecondCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularJerkUnit.DegreesPerSecondCubed"/>
        /// </summary>
        public static readonly AngularJerkJsonConverter DegreesPerSecondCubed = new AngularJerkJsonConverter(AngularJerkUnit.DegreesPerSecondCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularJerkUnit.RadiansPerHourCubed"/>
        /// </summary>
        public static readonly AngularJerkJsonConverter RadiansPerHourCubed = new AngularJerkJsonConverter(AngularJerkUnit.RadiansPerHourCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularJerkUnit.DegreesPerHourCubed"/>
        /// </summary>
        public static readonly AngularJerkJsonConverter DegreesPerHourCubed = new AngularJerkJsonConverter(AngularJerkUnit.DegreesPerHourCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularJerkUnit.RadiansPerMinuteCubed"/>
        /// </summary>
        public static readonly AngularJerkJsonConverter RadiansPerMinuteCubed = new AngularJerkJsonConverter(AngularJerkUnit.RadiansPerMinuteCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="AngularJerkUnit.DegreesPerMinuteCubed"/>
        /// </summary>
        public static readonly AngularJerkJsonConverter DegreesPerMinuteCubed = new AngularJerkJsonConverter(AngularJerkUnit.DegreesPerMinuteCubed);

        private readonly AngularJerkUnit unit;

        private AngularJerkJsonConverter(AngularJerkUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var angularJerk = (AngularJerk)value;
            serializer.Serialize(writer, angularJerk.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AngularJerk);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value;
            return AngularJerk.Parse(stringValue, serializer.Culture);
        }
    }
}
