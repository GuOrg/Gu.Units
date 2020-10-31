#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.Jerk"/>.
    /// </summary>
    [Serializable]
    public class JerkJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="JerkUnit.MetresPerSecondCubed"/>
        /// </summary>
        public static readonly JerkJsonConverter Default = new JerkJsonConverter(JerkUnit.MetresPerSecondCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="JerkUnit.MetresPerSecondCubed"/>
        /// </summary>
        public static readonly JerkJsonConverter MetresPerSecondCubed = new JerkJsonConverter(JerkUnit.MetresPerSecondCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="JerkUnit.MillimetresPerSecondCubed"/>
        /// </summary>
        public static readonly JerkJsonConverter MillimetresPerSecondCubed = new JerkJsonConverter(JerkUnit.MillimetresPerSecondCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="JerkUnit.CentimetresPerSecondCubed"/>
        /// </summary>
        public static readonly JerkJsonConverter CentimetresPerSecondCubed = new JerkJsonConverter(JerkUnit.CentimetresPerSecondCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="JerkUnit.MillimetresPerHourCubed"/>
        /// </summary>
        public static readonly JerkJsonConverter MillimetresPerHourCubed = new JerkJsonConverter(JerkUnit.MillimetresPerHourCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="JerkUnit.MillimetresPerMinuteCubed"/>
        /// </summary>
        public static readonly JerkJsonConverter MillimetresPerMinuteCubed = new JerkJsonConverter(JerkUnit.MillimetresPerMinuteCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="JerkUnit.MetresPerHourCubed"/>
        /// </summary>
        public static readonly JerkJsonConverter MetresPerHourCubed = new JerkJsonConverter(JerkUnit.MetresPerHourCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="JerkUnit.MetresPerMinuteCubed"/>
        /// </summary>
        public static readonly JerkJsonConverter MetresPerMinuteCubed = new JerkJsonConverter(JerkUnit.MetresPerMinuteCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="JerkUnit.CentimetresPerHourCubed"/>
        /// </summary>
        public static readonly JerkJsonConverter CentimetresPerHourCubed = new JerkJsonConverter(JerkUnit.CentimetresPerHourCubed);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="JerkUnit.CentimetresPerMinuteCubed"/>
        /// </summary>
        public static readonly JerkJsonConverter CentimetresPerMinuteCubed = new JerkJsonConverter(JerkUnit.CentimetresPerMinuteCubed);

        private readonly JerkUnit unit;

        private JerkJsonConverter(JerkUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var jerk = (Jerk)value!;
            serializer.Serialize(writer, jerk.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Jerk);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return Jerk.Parse(stringValue, serializer.Culture);
        }
    }
}
