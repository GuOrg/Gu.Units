// ReSharper disable RedundantStringInterpolation
namespace Gu.Units.Generator.CodeGen
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Enumerable
    {
        public static string Code(Settings settings)
        {
            var readOnlyList = settings.Quantities.OrderBy(x => x.Name).ToArray();
            return new StringBuilder()
                   .AppendLine($"namespace Gu.Units")
                   .AppendLine("{")
                   .AppendLine("    using System;")
                   .AppendLine("    using System.Collections.Generic;")
                   .AppendLine()
                   .AppendLine("    /// <summary>")
                   .AppendLine("    /// Provides common linq operations for quantity types")
                   .AppendLine("    /// </summary>")
                   .AppendLine("    public static partial class EnumerableUnits")
                   .AppendLine("    {")
                   .Sum(readOnlyList)
                   .SumNullable(readOnlyList)
                   .Min(readOnlyList)
                   .MinNullable(readOnlyList)
                   .Max(readOnlyList)
                   .MaxNullable(readOnlyList)
                   .Average(readOnlyList)
                   .AverageNullable(readOnlyList)
                   .AppendLine("    }")
                   .AppendLine("}")
                   .ToString();
        }

        private static StringBuilder Sum(this StringBuilder builder, IEnumerable<Quantity> quantities)
        {
            foreach (var quantity in quantities)
            {
                builder
                    .AppendLine($"        /// <summary>")
                    .AppendLine($"        /// Calculates the sum <see cref=\"{quantity.Name}\"/> of the values in <paramref name=\"source\"/>")
                    .AppendLine($"        /// </summary>")
                    .AppendLine($"        /// <param name=\"source\"><see cref=\"IEnumerable{{{quantity.Name}}}\"/></param>")
                    .AppendLine($"        /// <returns>The sum</returns>")
                    .AppendLine($"        public static {quantity.Name} Sum(this IEnumerable<{quantity.Name}> source)")
                    .AppendLine($"        {{")
                    .AppendLine($"            if (source == null)")
                    .AppendLine($"            {{")
                    .AppendLine($"                throw new ArgumentNullException(\"source\");")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            double sum = 0;")
                    .AppendLine($"            checked")
                    .AppendLine($"            {{")
                    .AppendLine($"                foreach (var v in source)")
                    .AppendLine($"                {{")
                    .AppendLine($"                    sum += v.{quantity.Unit.ParameterName};")
                    .AppendLine($"                }}")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            return {quantity.Name}.From{quantity.Unit.Name}(sum);")
                    .AppendLine($"        }}")
                    .AppendLine();
            }

            return builder;
        }

        private static StringBuilder SumNullable(this StringBuilder builder, IEnumerable<Quantity> quantities)
        {
            foreach (var quantity in quantities)
            {
                builder
                    .AppendLine($"        /// <summary>")
                    .AppendLine($"        /// Calculates the sum <see cref=\"Nullable{{{quantity.Name}}}\"/> of the values in <paramref name=\"source\"/>")
                    .AppendLine($"        /// </summary>")
                    .AppendLine($"        /// <param name=\"source\"><see cref=\"IEnumerable{{{quantity.Name}}}\"/></param>")
                    .AppendLine($"        /// <returns>The sum</returns>")
                    .AppendLine($"        public static {quantity.Name}? Sum(this IEnumerable<{quantity.Name}?> source)")
                    .AppendLine($"        {{")
                    .AppendLine($"            if (source == null)")
                    .AppendLine($"            {{")
                    .AppendLine($"                throw new ArgumentNullException(\"source\");")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            double sum = 0;")
                    .AppendLine($"            checked")
                    .AppendLine($"            {{")
                    .AppendLine($"                foreach (var v in source)")
                    .AppendLine($"                {{")
                    .AppendLine($"                    if (v != null)")
                    .AppendLine($"                    {{")
                    .AppendLine($"                        sum += v.Value.{quantity.Unit.ParameterName};")
                    .AppendLine($"                    }}")
                    .AppendLine($"                }}")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            return {quantity.Name}.From{quantity.Unit.Name}(sum);")
                    .AppendLine($"        }}")
                    .AppendLine();
            }

            return builder;
        }

        private static StringBuilder Min(this StringBuilder builder, IEnumerable<Quantity> quantities)
        {
            foreach (var quantity in quantities)
            {
                builder
                    .AppendLine($"        /// <summary>")
                    .AppendLine($"        /// Calculates the min <see cref=\"{quantity.Name}\"/> of the values in <paramref name=\"source\"/>")
                    .AppendLine($"        /// </summary>")
                    .AppendLine($"        /// <param name=\"source\"><see cref=\"IEnumerable{{{quantity.Name}}}\"/></param>")
                    .AppendLine($"        /// <returns>The min</returns>")
                    .AppendLine($"        public static {quantity.Name} Min(this IEnumerable<{quantity.Name}> source)")
                    .AppendLine($"        {{")
                    .AppendLine($"            if (source == null)")
                    .AppendLine($"            {{")
                    .AppendLine($"                throw new ArgumentNullException(\"source\");")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            var value = default({quantity.Name});")
                    .AppendLine($"            bool hasValue = false;")
                    .AppendLine($"            foreach (var x in source)")
                    .AppendLine($"            {{")
                    .AppendLine($"                if (double.IsNaN(x.{quantity.Unit.ParameterName}))")
                    .AppendLine($"                {{")
                    .AppendLine($"                    return x;")
                    .AppendLine($"                }}")
                    .AppendLine()
                    .AppendLine($"                if (hasValue)")
                    .AppendLine($"                {{")
                    .AppendLine($"                    if (x.{quantity.Unit.ParameterName} < value.{quantity.Unit.ParameterName})")
                    .AppendLine($"                    {{")
                    .AppendLine($"                        value = x;")
                    .AppendLine($"                    }}")
                    .AppendLine($"                }}")
                    .AppendLine($"                else")
                    .AppendLine($"                {{")
                    .AppendLine($"                    value = x;")
                    .AppendLine($"                    hasValue = true;")
                    .AppendLine($"                }}")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            if (hasValue)")
                    .AppendLine($"            {{")
                    .AppendLine($"                return value;")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            throw new ArgumentException(\"No elements\", \"source\");")
                    .AppendLine($"        }}")
                    .AppendLine();
            }

            return builder;
        }

        private static StringBuilder MinNullable(this StringBuilder builder, IEnumerable<Quantity> quantities)
        {
            foreach (var quantity in quantities)
            {
                builder
                    .AppendLine($"        /// <summary>")
                    .AppendLine($"        /// Calculates the min <see cref=\"Nullable{{{quantity.Name}}}\"/> of the values in <paramref name=\"source\"/>")
                    .AppendLine($"        /// </summary>")
                    .AppendLine($"        /// <param name=\"source\"><see cref=\"IEnumerable{{{quantity.Name}}}\"/></param>")
                    .AppendLine($"        /// <returns>The min</returns>")
                    .AppendLine($"        public static {quantity.Name}? Min(this IEnumerable<{quantity.Name}?> source)")
                    .AppendLine($"        {{")
                    .AppendLine($"            if (source == null)")
                    .AppendLine($"            {{")
                    .AppendLine($"                throw new ArgumentNullException(\"source\");")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            {quantity.Name}? value = null;")
                    .AppendLine($"            foreach (var x in source)")
                    .AppendLine($"            {{")
                    .AppendLine($"                if (x == null)")
                    .AppendLine($"                {{")
                    .AppendLine($"                    continue;")
                    .AppendLine($"                }}")
                    .AppendLine()
                    .AppendLine($"                if (double.IsNaN(x.Value.{quantity.Unit.ParameterName}))")
                    .AppendLine($"                {{")
                    .AppendLine($"                    return x;")
                    .AppendLine($"                }}")
                    .AppendLine()
                    .AppendLine($"                if (value == null || x.Value.{quantity.Unit.ParameterName} < value.Value.{quantity.Unit.ParameterName})")
                    .AppendLine($"                {{")
                    .AppendLine($"                    value = x;")
                    .AppendLine($"                }}")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            return value;")
                    .AppendLine($"        }}")
                    .AppendLine();
            }

            return builder;
        }

        private static StringBuilder Max(this StringBuilder builder, IEnumerable<Quantity> quantities)
        {
            foreach (var quantity in quantities)
            {
                builder
                    .AppendLine($"        /// <summary>")
                    .AppendLine($"        /// Calculates the max <see cref=\"{quantity.Name}\"/> of the values in <paramref name=\"source\"/>")
                    .AppendLine($"        /// </summary>")
                    .AppendLine($"        /// <param name=\"source\"><see cref=\"IEnumerable{{{quantity.Name}}}\"/></param>")
                    .AppendLine($"        /// <returns>The max</returns>")
                    .AppendLine($"        public static {quantity.Name} Max(this IEnumerable<{quantity.Name}> source)")
                    .AppendLine($"        {{")
                    .AppendLine($"            if (source == null)")
                    .AppendLine($"            {{")
                    .AppendLine($"                throw new ArgumentNullException(\"source\");")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            {quantity.Name} value = default({quantity.Name});")
                    .AppendLine($"            bool hasValue = false;")
                    .AppendLine($"            foreach ({quantity.Name} x in source)")
                    .AppendLine($"            {{")
                    .AppendLine($"                if (double.IsNaN(x.{quantity.Unit.ParameterName}))")
                    .AppendLine($"                {{")
                    .AppendLine($"                    return x;")
                    .AppendLine($"                }}")
                    .AppendLine()
                    .AppendLine($"                if (hasValue)")
                    .AppendLine($"                {{")
                    .AppendLine($"                    if (x.{quantity.Unit.ParameterName} > value.{quantity.Unit.ParameterName})")
                    .AppendLine($"                    {{")
                    .AppendLine($"                        value = x;")
                    .AppendLine($"                    }}")
                    .AppendLine($"                }}")
                    .AppendLine($"                else")
                    .AppendLine($"                {{")
                    .AppendLine($"                    value = x;")
                    .AppendLine($"                    hasValue = true;")
                    .AppendLine($"                }}")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            if (hasValue)")
                    .AppendLine($"            {{")
                    .AppendLine($"                return value;")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            throw new ArgumentException(\"No elements\", \"source\");")
                    .AppendLine($"        }}")
                    .AppendLine();
            }

            return builder;
        }

        private static StringBuilder MaxNullable(this StringBuilder builder, IEnumerable<Quantity> quantities)
        {
            foreach (var quantity in quantities)
            {
                builder
                    .AppendLine($"        /// <summary>")
                    .AppendLine($"        /// Calculates the max <see cref=\"Nullable{{{quantity.Name}}}\"/> of the values in <paramref name=\"source\"/>")
                    .AppendLine($"        /// </summary>")
                    .AppendLine($"        /// <param name=\"source\"><see cref=\"IEnumerable{{{quantity.Name}}}\"/></param>")
                    .AppendLine($"        /// <returns>The max</returns>")
                    .AppendLine($"        public static {quantity.Name}? Max(this IEnumerable<{quantity.Name}?> source)")
                    .AppendLine($"        {{")
                    .AppendLine($"            if (source == null)")
                    .AppendLine($"            {{")
                    .AppendLine($"                throw new ArgumentNullException(\"source\");")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            {quantity.Name}? value = null;")
                    .AppendLine($"            foreach (var x in source)")
                    .AppendLine($"            {{")
                    .AppendLine($"                if (x == null)")
                    .AppendLine($"                {{")
                    .AppendLine($"                    continue;")
                    .AppendLine($"                }}")
                    .AppendLine()
                    .AppendLine($"                if (double.IsNaN(x.Value.{quantity.Unit.ParameterName}))")
                    .AppendLine($"                {{")
                    .AppendLine($"                    return x;")
                    .AppendLine($"                }}")
                    .AppendLine()
                    .AppendLine($"                if (value == null || x.Value.{quantity.Unit.ParameterName} > value.Value.{quantity.Unit.ParameterName})")
                    .AppendLine($"                {{")
                    .AppendLine($"                    value = x;")
                    .AppendLine($"                }}")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            return value;")
                    .AppendLine($"        }}")
                    .AppendLine();
            }

            return builder;
        }

        private static StringBuilder Average(this StringBuilder builder, IEnumerable<Quantity> quantities)
        {
            foreach (var quantity in quantities)
            {
                builder
                    .AppendLine($"        /// <summary>")
                    .AppendLine($"        /// Calculates the average <see cref=\"{quantity.Name}\"/> for the values in <paramref name=\"source\"/>")
                    .AppendLine($"        /// </summary>")
                    .AppendLine($"        /// <param name=\"source\"><see cref=\"IEnumerable{{{quantity.Name}}}\"/></param>")
                    .AppendLine($"        /// <returns>The average</returns>")
                    .AppendLine($"        public static {quantity.Name} Average(this IEnumerable<{quantity.Name}> source)")
                    .AppendLine($"        {{")
                    .AppendLine($"            if (source == null)")
                    .AppendLine($"            {{")
                    .AppendLine($"                throw new ArgumentNullException(\"source\");")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            double sum = 0;")
                    .AppendLine($"            long count = 0;")
                    .AppendLine($"            checked")
                    .AppendLine($"            {{")
                    .AppendLine($"                foreach (var v in source)")
                    .AppendLine($"                {{")
                    .AppendLine($"                    sum += v.{quantity.Unit.ParameterName};")
                    .AppendLine($"                    count++;")
                    .AppendLine($"                }}")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            if (count > 0)")
                    .AppendLine($"            {{")
                    .AppendLine($"                return {quantity.Name}.From{quantity.Unit.Name}(sum / count);")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            throw new ArgumentException(\"No elements\", \"source\");")
                    .AppendLine($"        }}")
                    .AppendLine();
            }

            return builder;
        }

        private static StringBuilder AverageNullable(this StringBuilder builder, IEnumerable<Quantity> quantities)
        {
            foreach (var quantity in quantities)
            {
                builder
                    .AppendLine($"        /// <summary>")
                    .AppendLine($"        /// Calculates the average <see cref=\"Nullable{{{quantity.Name}}}\"/> for the values in <paramref name=\"source\"/>")
                    .AppendLine($"        /// </summary>")
                    .AppendLine($"        /// <param name=\"source\"><see cref=\"IEnumerable{{{quantity.Name}}}\"/></param>")
                    .AppendLine($"        /// <returns>The average</returns>")
                    .AppendLine($"        public static {quantity.Name}? Average(this IEnumerable<{quantity.Name}?> source)")
                    .AppendLine($"        {{")
                    .AppendLine($"            if (source == null)")
                    .AppendLine($"            {{")
                    .AppendLine($"                throw new ArgumentNullException(\"source\");")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            double sum = 0;")
                    .AppendLine($"            long count = 0;")
                    .AppendLine($"            checked")
                    .AppendLine($"            {{")
                    .AppendLine($"                foreach (var v in source)")
                    .AppendLine($"                {{")
                    .AppendLine($"                    if (v != null)")
                    .AppendLine($"                    {{")
                    .AppendLine($"                        sum += v.Value.{quantity.Unit.ParameterName};")
                    .AppendLine($"                        count++;")
                    .AppendLine($"                    }}")
                    .AppendLine($"                }}")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            if (count > 0)")
                    .AppendLine($"            {{")
                    .AppendLine($"                return {quantity.Name}.From{quantity.Unit.Name}(sum / count);")
                    .AppendLine($"            }}")
                    .AppendLine()
                    .AppendLine($"            return null;")
                    .AppendLine($"        }}")
                    .AppendLine($"<#      if (quantity != quantities[quantities.Count -1])")
                    .AppendLine($"        {{#>")
                    .AppendLine();

                if (quantity != quantities.Last())
                {
                    builder.AppendLine();
                }
            }

            return builder;
        }
    }
}
