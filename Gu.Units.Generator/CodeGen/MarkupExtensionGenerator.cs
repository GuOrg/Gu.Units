// ReSharper disable RedundantStringInterpolation
namespace Gu.Units.Generator.CodeGen
{
    using System.Collections.Generic;
    using System.Text;

    public static class MarkupExtensionGenerator
    {
        public static string Code(Quantity quantity)
        {
            return new StringBuilder()
                .AppendLine($"namespace Gu.Units.Wpf")
                .AppendLine($"{{")
                .AppendLine($"    using System;")
                .AppendLine($"    using System.Windows.Markup;")
                .AppendLine()
                .AppendLine($"    /// <summary>")
                .AppendLine($"    /// An <see cref=\"MarkupExtension\"/> for quantities of type <see cref=\"{quantity.Name}\"/> in XAML.")
                .AppendLine($"    /// </summary>")
                .AppendLine($"    [MarkupExtensionReturnType(typeof({quantity.Name}))]")
                .AppendLine($"    public class {quantity.Name}Extension : MarkupExtension")
                .AppendLine($"    {{")
                .AppendLine($"        /// <summary>")
                .AppendLine($"        /// Initializes a new instance of the <see cref=\"Gu.Units.Wpf.{quantity.Name}Extension\"/> class.")
                .AppendLine($"        /// </summary>")
                .AppendLine($"        /// <param name=\"value\"><see cref=\"Gu.Units.{quantity.Name}\"/>.</param>")
                .AppendLine($"        public {quantity.Name}Extension({quantity.Name} value)")
                .AppendLine($"        {{")
                .AppendLine($"            this.Value = value;")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <summary>")
                .AppendLine($"        /// Gets the <see cref=\"{quantity.Name}\"/> value")
                .AppendLine($"        /// </summary>")
                .AppendLine($"        public {quantity.Name} Value {{ get; private set; }}")
                .AppendLine()
                .AppendLine($"        /// <inheritdoc />")
                .AppendLine($"        public override object ProvideValue(IServiceProvider serviceProvider)")
                .AppendLine($"        {{")
                .AppendLine($"            return this.Value;")
                .AppendLine($"        }}")
                .AppendLine($"    }}")
                .AppendLine($"}}")
                .ToString();
        }
    }
}
