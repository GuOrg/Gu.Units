﻿namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Globalization;
    using System.Reflection;

    /// <devdoc>
    /// <para>Provides a type converter to convert <see cref='Gu.Units.LengthPerUnitless'/>
    /// objects to and from various
    /// other representations.</para>
    /// </devdoc>
    public class LengthPerUnitlessTypeConverter : TypeConverter
    {
        /// <devdoc>
        ///    <para>Gets a value indicating whether this converter can
        ///       convert an object in the given source type to a <see cref='Gu.Units.LengthPerUnitless'/> object using the
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
        /// <para>Converts the given object to a <see cref='Gu.Units.LengthPerUnitless'/>
        /// object.</para>
        /// </devdoc>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var text = value as string;
            if (text != null)
            {
                return LengthPerUnitless.Parse(text, culture);
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
            if (value is LengthPerUnitless && destinationType != null)
            {
                var lengthPerUnitless = (LengthPerUnitless)value;
                if (destinationType == typeof(string))
                {
                    return lengthPerUnitless.ToString(culture);
                }
                else if (destinationType == typeof(InstanceDescriptor))
                {
                    var ctor = typeof(LengthPerUnitless).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(double) }, null);
                    if (ctor != null)
                    {
                        var args = new object[] { lengthPerUnitless.metresPerUnitless };
                        return new InstanceDescriptor(ctor, args);
                    }
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}