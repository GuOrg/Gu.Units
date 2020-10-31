#nullable enable
namespace Gu.Units.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// <see cref="Newtonsoft.Json.JsonConverter" /> for the quantity <see cref="Gu.Units.ElectricCharge"/>.
    /// </summary>
    [Serializable]
    public class ElectricChargeJsonConverter : JsonConverter
    {
        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ElectricChargeUnit.Coulombs"/>
        /// </summary>
        public static readonly ElectricChargeJsonConverter Default = new ElectricChargeJsonConverter(ElectricChargeUnit.Coulombs);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ElectricChargeUnit.Coulombs"/>
        /// </summary>
        public static readonly ElectricChargeJsonConverter Coulombs = new ElectricChargeJsonConverter(ElectricChargeUnit.Coulombs);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ElectricChargeUnit.Nanocoulombs"/>
        /// </summary>
        public static readonly ElectricChargeJsonConverter Nanocoulombs = new ElectricChargeJsonConverter(ElectricChargeUnit.Nanocoulombs);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ElectricChargeUnit.Microcoulombs"/>
        /// </summary>
        public static readonly ElectricChargeJsonConverter Microcoulombs = new ElectricChargeJsonConverter(ElectricChargeUnit.Microcoulombs);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ElectricChargeUnit.Millicoulombs"/>
        /// </summary>
        public static readonly ElectricChargeJsonConverter Millicoulombs = new ElectricChargeJsonConverter(ElectricChargeUnit.Millicoulombs);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ElectricChargeUnit.Kilocoulombs"/>
        /// </summary>
        public static readonly ElectricChargeJsonConverter Kilocoulombs = new ElectricChargeJsonConverter(ElectricChargeUnit.Kilocoulombs);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ElectricChargeUnit.Megacoulombs"/>
        /// </summary>
        public static readonly ElectricChargeJsonConverter Megacoulombs = new ElectricChargeJsonConverter(ElectricChargeUnit.Megacoulombs);

        /// <summary>
        /// A <see cref="JsonConverter"/> that writes values in <see cref="ElectricChargeUnit.Gigacoulombs"/>
        /// </summary>
        public static readonly ElectricChargeJsonConverter Gigacoulombs = new ElectricChargeJsonConverter(ElectricChargeUnit.Gigacoulombs);

        private readonly ElectricChargeUnit unit;

        private ElectricChargeJsonConverter(ElectricChargeUnit unit)
        {
            this.unit = unit;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var electricCharge = (ElectricCharge)value!;
            serializer.Serialize(writer, electricCharge.ToString(this.unit, serializer.Culture));
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ElectricCharge);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var stringValue = (string)reader.Value!;
            return ElectricCharge.Parse(stringValue, serializer.Culture);
        }
    }
}
