namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Angle"/>.
    /// </summary>
    [TypeConverter(typeof(AngleTypeConverter))]
    [Serializable]
    public partial struct Angle : IQuantity<AngleUnit>, IComparable<Angle>, IEquatable<Angle>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.AngleUnit.Radians"/>
        /// </summary>
        public static readonly Angle Zero = default(Angle);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.AngleUnit.Radians"/>.
        /// </summary>
        internal readonly double radians;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Angle"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.AngleUnit"/>.</param>
        public Angle(double value, AngleUnit unit)
        {
            this.radians = unit.ToSiUnit(value);
        }

        private Angle(double radians)
        {
            this.radians = radians;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.AngleUnit.Radians"/>
        /// </summary>
        public double SiValue => this.radians;

        /// <summary>
        /// Gets the <see cref="Gu.Units.AngleUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public AngleUnit SiUnit => AngleUnit.Radians;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => AngleUnit.Radians;

        /// <summary>
        /// Gets the quantity in radians".
        /// </summary>
        public double Radians => this.radians;

        /// <summary>
        /// Gets the quantity in Degrees
        /// </summary>
        public double Degrees => 57.295779513082323 * this.radians;

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularSpeed"/> that is the result from the division.</returns>
        public static AngularSpeed operator /(Angle left, Time right)
        {
            return AngularSpeed.FromRadiansPerSecond(left.radians / right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AnglePerUnitless"/> that is the result from the division.</returns>
        public static AnglePerUnitless operator /(Angle left, Unitless right)
        {
            return AnglePerUnitless.FromRadiansPerUnitless(left.radians / right.scalar);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the division.</returns>
        public static Time operator /(Angle left, AngularSpeed right)
        {
            return Time.FromSeconds(left.radians / right.radiansPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularSpeed"/> that is the result from the multiplication.</returns>
        public static AngularSpeed operator *(Angle left, Frequency right)
        {
            return AngularSpeed.FromRadiansPerSecond(left.radians * right.hertz);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(Angle left, Torque right)
        {
            return Energy.FromJoules(left.radians * right.newtonMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Unitless"/> that is the result from the division.</returns>
        public static Unitless operator /(Angle left, AnglePerUnitless right)
        {
            return Unitless.FromScalar(left.radians / right.radiansPerUnitless);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Angle left, Angle right)
        {
            return left.radians / right.radians;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Angle"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Angle"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Angle"/>.</param>
        public static bool operator ==(Angle left, Angle right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Angle"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Angle"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Angle"/>.</param>
        public static bool operator !=(Angle left, Angle right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Angle"/> is less than another specified <see cref="Gu.Units.Angle"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Angle"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Angle"/>.</param>
        public static bool operator <(Angle left, Angle right)
        {
            return left.radians < right.radians;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Angle"/> is greater than another specified <see cref="Gu.Units.Angle"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Angle"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Angle"/>.</param>
        public static bool operator >(Angle left, Angle right)
        {
            return left.radians > right.radians;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Angle"/> is less than or equal to another specified <see cref="Gu.Units.Angle"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Angle"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Angle"/>.</param>
        public static bool operator <=(Angle left, Angle right)
        {
            return left.radians <= right.radians;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Angle"/> is greater than or equal to another specified <see cref="Gu.Units.Angle"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Angle"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Angle"/>.</param>
        public static bool operator >=(Angle left, Angle right)
        {
            return left.radians >= right.radians;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Angle"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Angle"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Angle"/> and returns the result.</returns>
        public static Angle operator *(double left, Angle right)
        {
            return new Angle(left * right.radians);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Angle"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Angle"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Angle"/> with <paramref name="right"/> and returns the result.</returns>
        public static Angle operator *(Angle left, double right)
        {
            return new Angle(left.radians * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Angle"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Angle"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Angle"/> by <paramref name="right"/> and returns the result.</returns>
        public static Angle operator /(Angle left, double right)
        {
            return new Angle(left.radians / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Angle"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Angle"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Angle"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Angle"/>.</param>
        public static Angle operator +(Angle left, Angle right)
        {
            return new Angle(left.radians + right.radians);
        }

        /// <summary>
        /// Subtracts an Angle from another Angle and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Angle"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Angle"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Angle"/> (the subtrahend).</param>
        public static Angle operator -(Angle left, Angle right)
        {
            return new Angle(left.radians - right.radians);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Angle"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Angle"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="angle">An instance of <see cref="Gu.Units.Angle"/></param>
        public static Angle operator -(Angle angle)
        {
            return new Angle(-1 * angle.radians);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Angle"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="angle"/>.
        /// </returns>
        /// <param name="angle">An instance of <see cref="Gu.Units.Angle"/></param>
        public static Angle operator +(Angle angle)
        {
            return angle;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Angle"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Angle"/></param>
        /// <returns>The <see cref="Gu.Units.Angle"/> parsed from <paramref name="text"/></returns>
        public static Angle Parse(string text)
        {
            return QuantityParser.Parse<AngleUnit, Angle>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Angle"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Angle"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Angle"/> parsed from <paramref name="text"/></returns>
        public static Angle Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<AngleUnit, Angle>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Angle"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Angle"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Angle"/> parsed from <paramref name="text"/></returns>
        public static Angle Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<AngleUnit, Angle>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Angle"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Angle"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Angle"/> parsed from <paramref name="text"/></returns>
        public static Angle Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<AngleUnit, Angle>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Angle"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Angle"/></param>
        /// <param name="result">The parsed <see cref="Angle"/></param>
        /// <returns>True if an instance of <see cref="Angle"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Angle result)
        {
            return QuantityParser.TryParse<AngleUnit, Angle>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Angle"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Angle"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Angle"/></param>
        /// <returns>True if an instance of <see cref="Angle"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Angle result)
        {
            return QuantityParser.TryParse<AngleUnit, Angle>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Angle"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Angle"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Angle"/></param>
        /// <returns>True if an instance of <see cref="Angle"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Angle result)
        {
            return QuantityParser.TryParse<AngleUnit, Angle>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Angle"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Angle"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Angle"/></param>
        /// <returns>True if an instance of <see cref="Angle"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Angle result)
        {
            return QuantityParser.TryParse<AngleUnit, Angle>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Angle"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Angle"/></returns>
        public static Angle ReadFrom(XmlReader reader)
        {
            var v = default(Angle);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Angle"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Angle"/></returns>
        public static Angle From(double value, AngleUnit unit)
        {
            return new Angle(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Angle"/>.
        /// </summary>
        /// <param name="radians">The value in <see cref="Gu.Units.AngleUnit.Radians"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Angle"/></returns>
        public static Angle FromRadians(double radians)
        {
            return new Angle(radians);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Angle"/>.
        /// </summary>
        /// <param name="degrees">The value in \u00B0.</param>
        /// <returns>An instance of <see cref="Gu.Units.Angle"/></returns>
        public static Angle FromDegrees(double degrees)
        {
            return new Angle(degrees / 57.295779513082323);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(AngleUnit unit)
        {
            return unit.FromSiUnit(this.radians);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Angle"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Angle"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 rad\"</param>
        /// <returns>The string representation of the <see cref="Angle"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 rad\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Angle"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex rad</param>
        /// <returns>The string representation of the <see cref="Angle"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex rad</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the <see cref="Angle"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(AngleUnit unit)
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(AngleUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(AngleUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(AngleUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, AngleUnit unit)
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, AngleUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, AngleUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, AngleUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngleUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Angle"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Angle"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantitys of this instance and <paramref name="quantity"/>.
        /// Value
        /// Description
        /// A negative integer
        /// This instance is smaller than <paramref name="quantity"/>.
        /// Zero
        /// This instance is equal to <paramref name="quantity"/>.
        /// A positive integer
        /// This instance is larger than <paramref name="quantity"/>.
        /// </returns>
        /// <param name="quantity">An instance of <see cref="Gu.Units.Angle"/> object to compare to this instance.</param>
        public int CompareTo(Angle quantity)
        {
            return this.radians.CompareTo(quantity.radians);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Angle"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Angle as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Angle"/> object to compare with this instance.</param>
        public bool Equals(Angle other)
        {
            return this.radians.Equals(other.radians);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Angle"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Angle as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Angle"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Angle other, Angle tolerance)
        {
            Ensure.GreaterThan(tolerance.radians, 0, nameof(tolerance));
            return Math.Abs(this.radians - other.radians) < tolerance.radians;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Angle"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Angle"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Angle && this.Equals((Angle)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.radians.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "radians", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.radians);
        }

        internal string ToString(QuantityFormat<AngleUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}