// ReSharper disable RedundantStringInterpolation
namespace Gu.Units.Generator.CodeGen
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class UnitWpfProxyGenerator
    {
        public static string Code(Unit unit)
        {
            return new StringBuilder()
                .AppendLine($"namespace Gu.Units.Wpf.Proxies")
                .AppendLine($"{{")
                .AppendLine($"    /// <summary>")
                .AppendLine($"    /// Proxy class for accessing units from xaml.")
                .AppendLine($"    /// </summary>")
                .AppendLine($"    public static class {unit.ClassName}")
                .AppendLine($"    {{")
                .AllConversions(unit)
                .AppendLine($"    }}")
                .AppendLine($"}}")
                .ToString();
        }

        private static StringBuilder AllConversions(this StringBuilder builder, Unit unit)
        {
            var units = new List<string> { { unit.Name } };
            units.AddRange(unit.AllConversions.Select(x => x.Name));
            foreach (var current in units)
            {
                builder
                .AppendLine($"        /// <summary>")
                .AppendLine($"        /// Gets the <see cref=\"Gu.Units.{unit.ClassName}.{current}\"/> unit.")
                .AppendLine($"        /// </summary>")
                .AppendLine($"        public static Gu.Units.{unit.ClassName} {current} => Gu.Units.{unit.ClassName}.{current};");

                if (current != units.Last())
                {
                    builder.AppendLine();
                }
            }

            return builder;
        }
    }
}
