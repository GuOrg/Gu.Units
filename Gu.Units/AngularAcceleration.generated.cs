#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.AngularAcceleration"/>.
    /// </summary>
    [TypeConverter(typeof(AngularAccelerationTypeConverter))]
    [Serializable]
    public partial struct AngularAcceleration : IQuantity<AngularAccelerationUnit>, IComparable<AngularAcceleration>, IEquatable<AngularAcceleration>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.AngularAccelerationUnit.RadiansPerSecondSquared"/>
        /// </summary>
        public static readonly AngularAcceleration Zero = default(AngularAcceleration);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.AngularAccelerationUnit.RadiansPerSecondSquared"/>.
        /// </summary>
        internal readonly double radiansPerSecondSquared;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.AngularAcceleration"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.AngularAccelerationUnit"/>.</param>
        public AngularAcceleration(double value, AngularAccelerationUnit unit)
        {
            this.radiansPerSecondSquared = unit.ToSiUnit(value);
        }

        private AngularAcceleration(double radiansPerSecondSquared)
        {
            this.radiansPerSecondSquared = radiansPerSecondSquared;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.AngularAccelerationUnit.RadiansPerSecondSquared"/>
        /// </summary>
        public double SiValue => this.radiansPerSecondSquared;

        /// <summary>
        /// Gets the <see cref="Gu.Units.AngularAccelerationUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public AngularAccelerationUnit SiUnit => AngularAccelerationUnit.RadiansPerSecondSquared;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => AngularAccelerationUnit.RadiansPerSecondSquared;

        /// <summary>
        /// Gets the quantity in radiansPerSecondSquared".
        /// </summary>
        public double RadiansPerSecondSquared => this.radiansPerSecondSquared;

        /// <summary>
        /// Gets the quantity in DegreesPerSecondSquared
        /// </summary>
        public double DegreesPerSecondSquared => this.radiansPerSecondSquared / 0.0174532925199433;

        /// <summary>
        /// Gets the quantity in RadiansPerHourSquared
        /// </summary>
        public double RadiansPerHourSquared => 12960000 * this.radiansPerSecondSquared;

        /// <summary>
        /// Gets the quantity in DegreesPerHourSquared
        /// </summary>
        public double DegreesPerHourSquared => this.radiansPerSecondSquared / 1.34670466974871E-09;

        /// <summary>
        /// Gets the quantity in DegreesPerMinuteSquared
        /// </summary>
        public double DegreesPerMinuteSquared => this.radiansPerSecondSquared / 4.84813681109536E-06;

        /// <summary>
        /// Gets the quantity in RadiansPerMinuteSquared
        /// </summary>
        public double RadiansPerMinuteSquared => 3600 * this.radiansPerSecondSquared;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularSpeed"/> that is the result from the multiplication.</returns>
        public static AngularSpeed operator *(AngularAcceleration left, Time right)
        {
            return AngularSpeed.FromRadiansPerSecond(left.radiansPerSecondSquared * right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularJerk"/> that is the result from the division.</returns>
        public static AngularJerk operator /(AngularAcceleration left, Time right)
        {
            return AngularJerk.FromRadiansPerSecondCubed(left.radiansPerSecondSquared / right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Frequency"/> that is the result from the division.</returns>
        public static Frequency operator /(AngularAcceleration left, AngularSpeed right)
        {
            return Frequency.FromHertz(left.radiansPerSecondSquared / right.radiansPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularJerk"/> that is the result from the multiplication.</returns>
        public static AngularJerk operator *(AngularAcceleration left, Frequency right)
        {
            return AngularJerk.FromRadiansPerSecondCubed(left.radiansPerSecondSquared * right.hertz);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularSpeed"/> that is the result from the division.</returns>
        public static AngularSpeed operator /(AngularAcceleration left, Frequency right)
        {
            return AngularSpeed.FromRadiansPerSecond(left.radiansPerSecondSquared / right.hertz);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the division.</returns>
        public static Time operator /(AngularAcceleration left, AngularJerk right)
        {
            return Time.FromSeconds(left.radiansPerSecondSquared / right.radiansPerSecondCubed);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(AngularAcceleration left, AngularAcceleration right)
        {
            return left.radiansPerSecondSquared / right.radiansPerSecondSquared;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularAcceleration"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        public static bool operator ==(AngularAcceleration left, AngularAcceleration right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularAcceleration"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        public static bool operator !=(AngularAcceleration left, AngularAcceleration right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AngularAcceleration"/> is less than another specified <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        public static bool operator <(AngularAcceleration left, AngularAcceleration right)
        {
            return left.radiansPerSecondSquared < right.radiansPerSecondSquared;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AngularAcceleration"/> is greater than another specified <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        public static bool operator >(AngularAcceleration left, AngularAcceleration right)
        {
            return left.radiansPerSecondSquared > right.radiansPerSecondSquared;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AngularAcceleration"/> is less than or equal to another specified <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        public static bool operator <=(AngularAcceleration left, AngularAcceleration right)
        {
            return left.radiansPerSecondSquared <= right.radiansPerSecondSquared;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AngularAcceleration"/> is greater than or equal to another specified <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        public static bool operator >=(AngularAcceleration left, AngularAcceleration right)
        {
            return left.radiansPerSecondSquared >= right.radiansPerSecondSquared;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AngularAcceleration"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.AngularAcceleration"/> and returns the result.</returns>
        public static AngularAcceleration operator *(double left, AngularAcceleration right)
        {
            return new AngularAcceleration(left * right.radiansPerSecondSquared);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AngularAcceleration"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.AngularAcceleration"/> with <paramref name="right"/> and returns the result.</returns>
        public static AngularAcceleration operator *(AngularAcceleration left, double right)
        {
            return new AngularAcceleration(left.radiansPerSecondSquared * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.AngularAcceleration"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.AngularAcceleration"/> by <paramref name="right"/> and returns the result.</returns>
        public static AngularAcceleration operator /(AngularAcceleration left, double right)
        {
            return new AngularAcceleration(left.radiansPerSecondSquared / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.AngularAcceleration"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AngularAcceleration"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        public static AngularAcceleration operator +(AngularAcceleration left, AngularAcceleration right)
        {
            return new AngularAcceleration(left.radiansPerSecondSquared + right.radiansPerSecondSquared);
        }

        /// <summary>
        /// Subtracts an AngularAcceleration from another AngularAcceleration and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AngularAcceleration"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.AngularAcceleration"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.AngularAcceleration"/> (the subtrahend).</param>
        public static AngularAcceleration operator -(AngularAcceleration left, AngularAcceleration right)
        {
            return new AngularAcceleration(left.radiansPerSecondSquared - right.radiansPerSecondSquared);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.AngularAcceleration"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AngularAcceleration"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="angularAcceleration">An instance of <see cref="Gu.Units.AngularAcceleration"/></param>
        public static AngularAcceleration operator -(AngularAcceleration angularAcceleration)
        {
            return new AngularAcceleration(-1 * angularAcceleration.radiansPerSecondSquared);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="angularAcceleration"/>.
        /// </returns>
        /// <param name="angularAcceleration">An instance of <see cref="Gu.Units.AngularAcceleration"/></param>
        public static AngularAcceleration operator +(AngularAcceleration angularAcceleration)
        {
            return angularAcceleration;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularAcceleration"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <returns>The <see cref="Gu.Units.AngularAcceleration"/> parsed from <paramref name="text"/></returns>
        public static AngularAcceleration Parse(string text)
        {
            return QuantityParser.Parse<AngularAccelerationUnit, AngularAcceleration>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularAcceleration"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.AngularAcceleration"/> parsed from <paramref name="text"/></returns>
        public static AngularAcceleration Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<AngularAccelerationUnit, AngularAcceleration>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularAcceleration"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.AngularAcceleration"/> parsed from <paramref name="text"/></returns>
        public static AngularAcceleration Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<AngularAccelerationUnit, AngularAcceleration>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularAcceleration"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.AngularAcceleration"/> parsed from <paramref name="text"/></returns>
        public static AngularAcceleration Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<AngularAccelerationUnit, AngularAcceleration>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularAcceleration"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <param name="result">The parsed <see cref="AngularAcceleration"/></param>
        /// <returns>True if an instance of <see cref="AngularAcceleration"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out AngularAcceleration result)
        {
            return QuantityParser.TryParse<AngularAccelerationUnit, AngularAcceleration>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularAcceleration"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="AngularAcceleration"/></param>
        /// <returns>True if an instance of <see cref="AngularAcceleration"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out AngularAcceleration result)
        {
            return QuantityParser.TryParse<AngularAccelerationUnit, AngularAcceleration>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularAcceleration"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="AngularAcceleration"/></param>
        /// <returns>True if an instance of <see cref="AngularAcceleration"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out AngularAcceleration result)
        {
            return QuantityParser.TryParse<AngularAccelerationUnit, AngularAcceleration>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularAcceleration"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="AngularAcceleration"/></param>
        /// <returns>True if an instance of <see cref="AngularAcceleration"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out AngularAcceleration result)
        {
            return QuantityParser.TryParse<AngularAccelerationUnit, AngularAcceleration>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.AngularAcceleration"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.AngularAcceleration"/></returns>
        public static AngularAcceleration ReadFrom(XmlReader reader)
        {
            var v = default(AngularAcceleration);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.AngularAcceleration"/></returns>
        public static AngularAcceleration From(double value, AngularAccelerationUnit unit)
        {
            return new AngularAcceleration(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="radiansPerSecondSquared">The value in <see cref="Gu.Units.AngularAccelerationUnit.RadiansPerSecondSquared"/></param>
        /// <returns>An instance of <see cref="Gu.Units.AngularAcceleration"/></returns>
        public static AngularAcceleration FromRadiansPerSecondSquared(double radiansPerSecondSquared)
        {
            return new AngularAcceleration(radiansPerSecondSquared);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="degreesPerSecondSquared">The value in °⋅s⁻².</param>
        /// <returns>An instance of <see cref="Gu.Units.AngularAcceleration"/></returns>
        public static AngularAcceleration FromDegreesPerSecondSquared(double degreesPerSecondSquared)
        {
            return new AngularAcceleration(0.0174532925199433 * degreesPerSecondSquared);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="radiansPerHourSquared">The value in h⁻²⋅rad.</param>
        /// <returns>An instance of <see cref="Gu.Units.AngularAcceleration"/></returns>
        public static AngularAcceleration FromRadiansPerHourSquared(double radiansPerHourSquared)
        {
            return new AngularAcceleration(radiansPerHourSquared / 12960000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="degreesPerHourSquared">The value in h⁻²⋅°.</param>
        /// <returns>An instance of <see cref="Gu.Units.AngularAcceleration"/></returns>
        public static AngularAcceleration FromDegreesPerHourSquared(double degreesPerHourSquared)
        {
            return new AngularAcceleration(1.34670466974871E-09 * degreesPerHourSquared);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="degreesPerMinuteSquared">The value in min⁻²⋅°.</param>
        /// <returns>An instance of <see cref="Gu.Units.AngularAcceleration"/></returns>
        public static AngularAcceleration FromDegreesPerMinuteSquared(double degreesPerMinuteSquared)
        {
            return new AngularAcceleration(4.84813681109536E-06 * degreesPerMinuteSquared);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="radiansPerMinuteSquared">The value in min⁻²⋅rad.</param>
        /// <returns>An instance of <see cref="Gu.Units.AngularAcceleration"/></returns>
        public static AngularAcceleration FromRadiansPerMinuteSquared(double radiansPerMinuteSquared)
        {
            return new AngularAcceleration(radiansPerMinuteSquared / 3600);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(AngularAccelerationUnit unit)
        {
            return unit.FromSiUnit(this.radiansPerSecondSquared);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="AngularAcceleration"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="AngularAcceleration"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 rad/s²\"</param>
        /// <returns>The string representation of the <see cref="AngularAcceleration"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 rad/s²\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="AngularAcceleration"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex rad/s²</param>
        /// <returns>The string representation of the <see cref="AngularAcceleration"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex rad/s²</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="AngularAcceleration"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(AngularAccelerationUnit unit)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(AngularAccelerationUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(AngularAccelerationUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(AngularAccelerationUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, AngularAccelerationUnit unit)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, AngularAccelerationUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, AngularAccelerationUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, AngularAccelerationUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.AngularAcceleration"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.AngularAcceleration"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantities of this instance and <paramref name="quantity"/>.
        /// Value
        /// Description
        /// A negative integer
        /// This instance is smaller than <paramref name="quantity"/>.
        /// Zero
        /// This instance is equal to <paramref name="quantity"/>.
        /// A positive integer
        /// This instance is larger than <paramref name="quantity"/>.
        /// </returns>
        /// <param name="quantity">An instance of <see cref="Gu.Units.AngularAcceleration"/> object to compare to this instance.</param>
        public int CompareTo(AngularAcceleration quantity)
        {
            return this.radiansPerSecondSquared.CompareTo(quantity.radiansPerSecondSquared);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AngularAcceleration"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularAcceleration as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.AngularAcceleration"/> object to compare with this instance.</param>
        public bool Equals(AngularAcceleration other)
        {
            return this.radiansPerSecondSquared.Equals(other.radiansPerSecondSquared);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AngularAcceleration"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularAcceleration as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.AngularAcceleration"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(AngularAcceleration other, AngularAcceleration tolerance)
        {
            Ensure.GreaterThan(tolerance.radiansPerSecondSquared, 0, nameof(tolerance));
            return Math.Abs(this.radiansPerSecondSquared - other.radiansPerSecondSquared) < tolerance.radiansPerSecondSquared;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AngularAcceleration"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.AngularAcceleration"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngularAcceleration && this.Equals((AngularAcceleration)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.radiansPerSecondSquared.GetHashCode();
        }

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface,
        /// you should return null (Nothing in Visual Basic) from this method, and instead,
        /// if specifying a custom schema is required, apply the <see cref="System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the
        ///  <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/>
        /// method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            // Hacking set readonly fields here, can't think of a cleaner workaround
            XmlExt.SetReadonlyField(ref this, "radiansPerSecondSquared", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.radiansPerSecondSquared);
        }

        internal string ToString(QuantityFormat<AngularAccelerationUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
