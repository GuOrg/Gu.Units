namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Globalization;

    /// <summary>
    /// Provides a unified way of converting types of values to other types, as well as for accessing standard values and subproperties.
    /// </summary>
    /// <devdoc>
    /// <para>Provides a type converter to convert <see cref='Gu.Units.TimeUnit'/>
    /// objects to and from various
    /// other representations.</para>
    /// </devdoc>
    public class TimeUnitTypeConverter : TypeConverter
    {
        /// <inheritdoc />
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        /// <inheritdoc />
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }

        /// <inheritdoc />
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var text = value as string;
            if (text != null)
            {
                TimeUnit result;
                if (TimeUnit.TryParse(text, out result))
                {
                    return result;
                }

                var message = $"Could not convert the string '{text}' to an instance of TimeUnit)";
                throw new NotSupportedException(message);
            }

            return base.ConvertFrom(context, culture, value);
        }

        /// <inheritdoc />
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is TimeUnit && destinationType != null)
            {
                var unit = (TimeUnit)value;
                if (destinationType == typeof(string))
                {
                    return unit.ToString();
                }
                else if (destinationType == typeof(InstanceDescriptor))
                {
                    var parseMethod = typeof(TimeUnit).GetMethod(nameof(TimeUnit.Parse), new Type[] { typeof(string) });
                    if (parseMethod != null)
                    {
                        var args = new object[] { unit.Symbol };
                        return new InstanceDescriptor(parseMethod, args);
                    }
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
