namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Globalization;

    /// <devdoc>
    /// <para>Provides a type converter to convert <see cref='Gu.Units.MagneticFluxUnit'/>
    /// objects to and from various
    /// other representations.</para>
    /// </devdoc>
    public class MagneticFluxUnitTypeConverter : TypeConverter
    {
        /// <devdoc>
        ///    <para>Gets a value indicating whether this converter can
        ///       convert an object in the given source type to a <see cref='Gu.Units.MagneticFluxUnit'/> object using the
        ///       specified context.</para>
        /// </devdoc>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        /// <devdoc>
        ///    <para>Gets a value indicating whether this converter can
        ///       convert an object to the given destination type using the context.</para>
        /// </devdoc>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }

        /// <devdoc>
        /// <para>Converts the given object to a <see cref='Gu.Units.MagneticFluxUnit'/>
        /// object.</para>
        /// </devdoc>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var text = value as string;
            if (text != null)
            {
                MagneticFluxUnit result;
                if (MagneticFluxUnit.TryParse(text, out result))
                {
                    return result;
                }

                var message = $"Could not convert the string '{text}' to an instance of MagneticFluxUnit)";
                throw new NotSupportedException(message);
            }

            return base.ConvertFrom(context, culture, value);
        }

        /// <devdoc>
        ///      Converts the given object to another type.  The most common types to convert
        ///      are to and from a string object.  The default implementation will make a call
        ///      to ToString on the object if the object is valid and if the destination
        ///      type is string.  If this cannot convert to the <paramref name="destinationType"/> type, this will
        ///      throw a NotSupportedException.
        /// </devdoc>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is MagneticFluxUnit && destinationType != null)
            {
                var unit = (MagneticFluxUnit)value;
                if (destinationType == typeof(string))
                {
                    return unit.ToString();
                }
                else if (destinationType == typeof(InstanceDescriptor))
                {
                    var parseMethod = typeof(MagneticFluxUnit).GetMethod(nameof(MagneticFluxUnit.Parse), new Type[] { typeof(string) });
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