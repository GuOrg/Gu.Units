// ReSharper disable RedundantStringInterpolation
namespace Gu.Units.Generator.CodeGen
{
    using System.Text;

    public static class JsonConverterGenerator
    {
        public static string Code(Quantity quantity)
        {
            return new StringBuilder()
                .AppendLine("#nullable enable")
                .AppendLine($"namespace Gu.Units.Json")
                .AppendLine($"{{")
                .AppendLine($"    using System;")
                .AppendLine($"    using Newtonsoft.Json;")
                .AppendLine()
                .AppendLine($"    /// <summary>")
                .AppendLine($"    /// <see cref=\"Newtonsoft.Json.JsonConverter\" /> for the quantity <see cref=\"Gu.Units.{quantity.Name}\"/>.")
                .AppendLine($"    /// </summary>")
                .AppendLine($"    [Serializable]")
                .AppendLine($"    public class {quantity.Name}JsonConverter : JsonConverter")
                .AppendLine($"    {{")
                .AppendLine($"        /// <summary>")
                .AppendLine($"        /// A <see cref=\"JsonConverter\"/> that writes values in <see cref=\"{quantity.UnitName}.{quantity.Unit.Name}\"/>")
                .AppendLine($"        /// </summary>")
                .AppendLine($"        public static readonly {quantity.Name}JsonConverter Default = new {quantity.Name}JsonConverter({quantity.UnitName}.{quantity.Unit.Name});")
                .AppendLine()
                .AppendLine($"        /// <summary>")
                .AppendLine($"        /// A <see cref=\"JsonConverter\"/> that writes values in <see cref=\"{quantity.UnitName}.{quantity.Unit.Name}\"/>")
                .AppendLine($"        /// </summary>")
                .AppendLine($"        public static readonly {quantity.Name}JsonConverter {quantity.Unit.Name} = new {quantity.Name}JsonConverter({quantity.UnitName}.{quantity.Unit.Name});")
                .AppendLine()
                .AllConversions(quantity)
                .AppendLine($"        private readonly {quantity.UnitName} unit;")
                .AppendLine()
                .AppendLine($"        private {quantity.Name}JsonConverter({quantity.UnitName} unit)")
                .AppendLine($"        {{")
                .AppendLine($"            this.unit = unit;")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <inheritdoc />")
                .AppendLine($"        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)")
                .AppendLine($"        {{")
                .AppendLine($"            var {quantity.ParameterName} = ({quantity.Name})value;")
                .AppendLine($"            serializer.Serialize(writer, {quantity.ParameterName}.ToString(this.unit, serializer.Culture));")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <inheritdoc />")
                .AppendLine($"        public override bool CanConvert(Type objectType)")
                .AppendLine($"        {{")
                .AppendLine($"            return objectType == typeof({quantity.Name});")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <inheritdoc />")
                .AppendLine($"        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)")
                .AppendLine($"        {{")
                .AppendLine($"            var stringValue = (string)reader.Value;")
                .AppendLine($"            return {quantity.Name}.Parse(stringValue, serializer.Culture);")
                .AppendLine($"        }}")
                .AppendLine($"    }}")
                .AppendLine($"}}")
                .ToString();
        }

        private static StringBuilder AllConversions(this StringBuilder builder, Quantity quantity)
        {
            foreach (var conversion in quantity.Unit.AllConversions)
            {
                builder
                .AppendLine($"        /// <summary>")
                .AppendLine($"        /// A <see cref=\"JsonConverter\"/> that writes values in <see cref=\"{quantity.UnitName}.{conversion.Name}\"/>")
                .AppendLine($"        /// </summary>")
                .AppendLine($"        public static readonly {quantity.Name}JsonConverter {conversion.Name} = new {quantity.Name}JsonConverter({quantity.UnitName}.{conversion.Name});")
                .AppendLine();
            }

            return builder;
        }
    }
}