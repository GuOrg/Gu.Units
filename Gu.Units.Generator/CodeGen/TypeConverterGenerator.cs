﻿// ReSharper disable RedundantStringInterpolation
namespace Gu.Units.Generator.CodeGen
{
    using System.Text;

    public static class TypeConverterGenerator
    {
        public static string Code(Quantity quantity)
        {
            return new StringBuilder()
                .AppendLine($"namespace Gu.Units")
                .AppendLine($"{{")
                .AppendLine($"    using System;")
                .AppendLine($"    using System.ComponentModel;")
                .AppendLine($"    using System.ComponentModel.Design.Serialization;")
                .AppendLine($"    using System.Globalization;")
                .AppendLine($"    using System.Reflection;")
                .AppendLine()
                .AppendLine($"    /// <summary>")
                .AppendLine($"    /// Provides a unified way of converting types of values to other types, as well as for accessing standard values and subproperties.")
                .AppendLine($"    /// </summary>")
                .AppendLine($"    /// <devdoc>")
                .AppendLine($"    /// <para>Provides a type converter to convert <see cref='Gu.Units.{quantity.Name}'/>")
                .AppendLine($"    /// objects to and from various")
                .AppendLine($"    /// other representations.</para>")
                .AppendLine($"    /// </devdoc>")
                .AppendLine($"    public class {quantity.Name}TypeConverter : TypeConverter")
                .AppendLine($"    {{")
                .AppendLine($"        /// <inheritdoc />")
                .AppendLine($"        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)")
                .AppendLine($"        {{")
                .AppendLine($"            if (sourceType == typeof(string))")
                .AppendLine($"            {{")
                .AppendLine($"                return true;")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            return base.CanConvertFrom(context, sourceType);")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <inheritdoc />")
                .AppendLine($"        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)")
                .AppendLine($"        {{")
                .AppendLine($"            if (destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string))")
                .AppendLine($"            {{")
                .AppendLine($"                return true;")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            return base.CanConvertTo(context, destinationType);")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <inheritdoc />")
                .AppendLine($"        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)")
                .AppendLine($"        {{")
                .AppendLine($"            var text = value as string;")
                .AppendLine($"            if (text != null)")
                .AppendLine($"            {{")
                .AppendLine($"                return {quantity.Name}.Parse(text, culture);")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            return base.ConvertFrom(context, culture, value);")
                .AppendLine($"        }}")
                .AppendLine()
                .AppendLine($"        /// <inheritdoc />")
                .AppendLine($"        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)")
                .AppendLine($"        {{")
                .AppendLine($"            if (value is {quantity.Name} && destinationType != null)")
                .AppendLine($"            {{")
                .AppendLine($"                var {quantity.ParameterName} = ({quantity.Name})value;")
                .AppendLine($"                if (destinationType == typeof(string))")
                .AppendLine($"                {{")
                .AppendLine($"                    return {quantity.ParameterName}.ToString(culture);")
                .AppendLine($"                }}")
                .AppendLine($"                else if (destinationType == typeof(InstanceDescriptor))")
                .AppendLine($"                {{")
                .AppendLine($"                    var factoryMethod = typeof({quantity.Name}).GetMethod(nameof({quantity.Name}.From{quantity.Unit.Name}), BindingFlags.Public | BindingFlags.Static, null, new Type[] {{ typeof(double) }}, null);")
                .AppendLine($"                    if (factoryMethod != null)")
                .AppendLine($"                    {{")
                .AppendLine($"                        var args = new object[] {{ {quantity.ParameterName}.{quantity.Unit.ParameterName} }};")
                .AppendLine($"                        return new InstanceDescriptor(factoryMethod, args);")
                .AppendLine($"                    }}")
                .AppendLine($"                }}")
                .AppendLine($"            }}")
                .AppendLine()
                .AppendLine($"            return base.ConvertTo(context, culture, value, destinationType);")
                .AppendLine($"        }}")
                .AppendLine($"    }}")
                .AppendLine($"}}")
                .ToString();
        }
    }
}
