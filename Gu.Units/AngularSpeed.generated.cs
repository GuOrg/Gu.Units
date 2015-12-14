namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.AngularSpeed"/>.
    /// </summary>
    // [TypeConverter(typeof(AngularSpeedTypeConverter))]
    [Serializable]
    public partial struct AngularSpeed : IQuantity<AngularSpeedUnit>, IComparable<AngularSpeed>, IEquatable<AngularSpeed>
    {
        public static readonly AngularSpeed Zero = new AngularSpeed();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AngularSpeedUnit.RadiansPerSecond"/>.
        /// </summary>
        internal readonly double radiansPerSecond;

        private AngularSpeed(double radiansPerSecond)
        {
            this.radiansPerSecond = radiansPerSecond;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.AngularSpeedUnit"/>.</param>
        public AngularSpeed(double value, AngularSpeedUnit unit)
        {
            this.radiansPerSecond = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AngularSpeedUnit.RadiansPerSecond"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.radiansPerSecond;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.AngularSpeedUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public AngularSpeedUnit SiUnit => AngularSpeedUnit.RadiansPerSecond;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => AngularSpeedUnit.RadiansPerSecond;

        /// <summary>
        /// The quantity in radiansPerSecond".
        /// </summary>
        public double RadiansPerSecond
        {
            get
            {
                return this.radiansPerSecond;
            }
        }

        /// <summary>
        /// The quantity in RevolutionsPerMinute
        /// </summary>
        public double RevolutionsPerMinute => this.radiansPerSecond / 0.10471975511966;

        /// <summary>
        /// The quantity in DegreesPerSecond
        /// </summary>
        public double DegreesPerSecond => this.radiansPerSecond / 0.0174532925199433;

        /// <summary>
        /// The quantity in DegreesPerMinute
        /// </summary>
        public double DegreesPerMinute => this.radiansPerSecond / 0.000290888208665722;

        /// <summary>
        /// The quantity in RadiansPerMinute
        /// </summary>
        public double RadiansPerMinute => 60 * this.radiansPerSecond;

        /// <summary>
        /// The quantity in DegreesPerHour
        /// </summary>
        public double DegreesPerHour => this.radiansPerSecond / 4.84813681109536E-06;

        /// <summary>
        /// The quantity in RadiansPerHour
        /// </summary>
        public double RadiansPerHour => 3600 * this.radiansPerSecond;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularSpeed"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="Gu.Units.AngularSpeed"/></param>
        /// <returns></returns>
		public static AngularSpeed Parse(string s)
        {
            return QuantityParser.Parse<AngularSpeedUnit, AngularSpeed>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static AngularSpeed Parse(string s, IFormatProvider provider)
        {
            return QuantityParser.Parse<AngularSpeedUnit, AngularSpeed>(s, From, NumberStyles.Float, provider);
        }

        public static AngularSpeed Parse(string s, NumberStyles styles)
        {
            return QuantityParser.Parse<AngularSpeedUnit, AngularSpeed>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static AngularSpeed Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<AngularSpeedUnit, AngularSpeed>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out AngularSpeed value)
        {
            return QuantityParser.TryParse<AngularSpeedUnit, AngularSpeed>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out AngularSpeed value)
        {
            return QuantityParser.TryParse<AngularSpeedUnit, AngularSpeed>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out AngularSpeed value)
        {
            return QuantityParser.TryParse<AngularSpeedUnit, AngularSpeed>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out AngularSpeed value)
        {
            return QuantityParser.TryParse<AngularSpeedUnit, AngularSpeed>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.AngularSpeed"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.AngularSpeed"/></returns>
        public static AngularSpeed ReadFrom(XmlReader reader)
        {
            var v = new AngularSpeed();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static AngularSpeed From(double value, AngularSpeedUnit unit)
        {
            return new AngularSpeed(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <param name="radiansPerSecond">The value in <see cref="Gu.Units.AngularSpeedUnit.RadiansPerSecond"/></param>
        public static AngularSpeed FromRadiansPerSecond(double radiansPerSecond)
        {
            return new AngularSpeed(radiansPerSecond);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <param name="revolutionsPerMinute">The value in rpm</param>
        public static AngularSpeed FromRevolutionsPerMinute(double revolutionsPerMinute)
        {
            return new AngularSpeed(0.10471975511966 * revolutionsPerMinute);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <param name="degreesPerSecond">The value in °⋅s⁻¹</param>
        public static AngularSpeed FromDegreesPerSecond(double degreesPerSecond)
        {
            return new AngularSpeed(0.0174532925199433 * degreesPerSecond);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <param name="degreesPerMinute">The value in min⁻¹⋅°</param>
        public static AngularSpeed FromDegreesPerMinute(double degreesPerMinute)
        {
            return new AngularSpeed(0.000290888208665722 * degreesPerMinute);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <param name="radiansPerMinute">The value in min⁻¹⋅rad</param>
        public static AngularSpeed FromRadiansPerMinute(double radiansPerMinute)
        {
            return new AngularSpeed(radiansPerMinute / 60);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <param name="degreesPerHour">The value in h⁻¹⋅°</param>
        public static AngularSpeed FromDegreesPerHour(double degreesPerHour)
        {
            return new AngularSpeed(4.84813681109536E-06 * degreesPerHour);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <param name="radiansPerHour">The value in h⁻¹⋅rad</param>
        public static AngularSpeed FromRadiansPerHour(double radiansPerHour)
        {
            return new AngularSpeed(radiansPerHour / 3600);
        }

        public static Angle operator *(AngularSpeed left, Time right)
        {
            return Angle.FromRadians(left.radiansPerSecond * right.seconds);
        }

        public static AngularAcceleration operator /(AngularSpeed left, Time right)
        {
            return AngularAcceleration.FromRadiansPerSecondSquared(left.radiansPerSecond / right.seconds);
        }

        public static Frequency operator /(AngularSpeed left, Angle right)
        {
            return Frequency.FromHertz(left.radiansPerSecond / right.radians);
        }

        public static AngularAcceleration operator *(AngularSpeed left, Frequency right)
        {
            return AngularAcceleration.FromRadiansPerSecondSquared(left.radiansPerSecond * right.hertz);
        }

        public static Angle operator /(AngularSpeed left, Frequency right)
        {
            return Angle.FromRadians(left.radiansPerSecond / right.hertz);
        }

        public static Power operator *(AngularSpeed left, Torque right)
        {
            return Power.FromWatts(left.radiansPerSecond * right.newtonMetres);
        }

        public static Time operator /(AngularSpeed left, AngularAcceleration right)
        {
            return Time.FromSeconds(left.radiansPerSecond / right.radiansPerSecondSquared);
        }

        public static double operator /(AngularSpeed left, AngularSpeed right)
        {
            return left.radiansPerSecond / right.radiansPerSecond;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularSpeed"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        public static bool operator ==(AngularSpeed left, AngularSpeed right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularSpeed"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        public static bool operator !=(AngularSpeed left, AngularSpeed right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AngularSpeed"/> is less than another specified <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        public static bool operator <(AngularSpeed left, AngularSpeed right)
        {
            return left.radiansPerSecond < right.radiansPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AngularSpeed"/> is greater than another specified <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        public static bool operator >(AngularSpeed left, AngularSpeed right)
        {
            return left.radiansPerSecond > right.radiansPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AngularSpeed"/> is less than or equal to another specified <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        public static bool operator <=(AngularSpeed left, AngularSpeed right)
        {
            return left.radiansPerSecond <= right.radiansPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AngularSpeed"/> is greater than or equal to another specified <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        public static bool operator >=(AngularSpeed left, AngularSpeed right)
        {
            return left.radiansPerSecond >= right.radiansPerSecond;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AngularSpeed"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularSpeed"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.AngularSpeed"/> with <paramref name="left"/> and returns the result.</returns>
        public static AngularSpeed operator *(double left, AngularSpeed right)
        {
            return new AngularSpeed(left * right.radiansPerSecond);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AngularSpeed"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularSpeed"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.AngularSpeed"/> with <paramref name="right"/> and returns the result.</returns>
        public static AngularSpeed operator *(AngularSpeed left, double right)
        {
            return new AngularSpeed(left.radiansPerSecond * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.AngularSpeed"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularSpeed"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.AngularSpeed"/> with <paramref name="right"/> and returns the result.</returns>
        public static AngularSpeed operator /(AngularSpeed left, double right)
        {
            return new AngularSpeed(left.radiansPerSecond / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.AngularSpeed"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AngularSpeed"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularSpeed"/>.</param>
        public static AngularSpeed operator +(AngularSpeed left, AngularSpeed right)
        {
            return new AngularSpeed(left.radiansPerSecond + right.radiansPerSecond);
        }

        /// <summary>
        /// Subtracts an AngularSpeed from another AngularSpeed and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AngularSpeed"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularSpeed"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularSpeed"/> (the subtrahend).</param>
        public static AngularSpeed operator -(AngularSpeed left, AngularSpeed right)
        {
            return new AngularSpeed(left.radiansPerSecond - right.radiansPerSecond);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.AngularSpeed"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AngularSpeed"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="angularSpeed">An instance of <see cref="Gu.Units.AngularSpeed"/></param>
        public static AngularSpeed operator -(AngularSpeed angularSpeed)
        {
            return new AngularSpeed(-1 * angularSpeed.radiansPerSecond);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="angularSpeed"/>.
        /// </returns>
        /// <param name="angularSpeed">An instance of <see cref="Gu.Units.AngularSpeed"/></param>
        public static AngularSpeed operator +(AngularSpeed angularSpeed)
        {
            return angularSpeed;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(AngularSpeedUnit unit)
        {
            return unit.FromSiUnit(this.radiansPerSecond);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="AngularSpeed"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="AngularSpeed"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 rad/s\"</param>
        /// <returns>The string representation of the <see cref="AngularSpeed"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 rad/s\"</param>
        /// <returns>The string representation of the <see cref="AngularSpeed"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex rad/s</param>
        /// <returns>The string representation of the <see cref="AngularSpeed"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex rad/s</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="AngularSpeed"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AngularSpeedUnit unit)
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(AngularSpeedUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(AngularSpeedUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AngularSpeedUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AngularSpeedUnit unit)
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AngularSpeedUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AngularSpeedUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AngularSpeedUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularSpeedUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<AngularSpeedUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.AngularSpeed"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.AngularSpeed"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantitys of this instance and <paramref name="quantity"/>.
        /// 
        ///                     Value
        /// 
        ///                     Description
        /// 
        ///                     A negative integer
        /// 
        ///                     This instance is smaller than <paramref name="quantity"/>.
        /// 
        ///                     Zero
        /// 
        ///                     This instance is equal to <paramref name="quantity"/>.
        /// 
        ///                     A positive integer
        /// 
        ///                     This instance is larger than <paramref name="quantity"/>.
        /// 
        /// </returns>
        /// <param name="quantity">An instance of <see cref="Gu.Units.AngularSpeed"/> object to compare to this instance.</param>
        public int CompareTo(AngularSpeed quantity)
        {
            return this.radiansPerSecond.CompareTo(quantity.radiansPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AngularSpeed"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularSpeed as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.AngularSpeed"/> object to compare with this instance.</param>
        public bool Equals(AngularSpeed other)
        {
            return this.radiansPerSecond.Equals(other.radiansPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AngularSpeed"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularSpeed as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.AngularSpeed"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(AngularSpeed other, AngularSpeed tolerance)
        {
            Ensure.GreaterThan(tolerance.radiansPerSecond, 0, nameof(tolerance));
            return Math.Abs(this.radiansPerSecond - other.radiansPerSecond) < tolerance.radiansPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngularSpeed && this.Equals((AngularSpeed)obj);
        }

        public override int GetHashCode()
        {
            return this.radiansPerSecond.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "radiansPerSecond", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.radiansPerSecond);
        }
    }
}