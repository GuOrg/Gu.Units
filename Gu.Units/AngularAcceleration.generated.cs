namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.AngularAcceleration"/>.
    /// </summary>
    // [TypeConverter(typeof(AngularAccelerationTypeConverter))]
    [Serializable]
    public partial struct AngularAcceleration : IQuantity<AngularAccelerationUnit>, IComparable<AngularAcceleration>, IEquatable<AngularAcceleration>
    {
        public static readonly AngularAcceleration Zero = new AngularAcceleration();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AngularAccelerationUnit.RadiansPerSecondSquared"/>.
        /// </summary>
        internal readonly double radiansPerSecondSquared;

        private AngularAcceleration(double radiansPerSecondSquared)
        {
            this.radiansPerSecondSquared = radiansPerSecondSquared;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.AngularAccelerationUnit"/>.</param>
        public AngularAcceleration(double value, AngularAccelerationUnit unit)
        {
            this.radiansPerSecondSquared = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AngularAccelerationUnit.RadiansPerSecondSquared"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.radiansPerSecondSquared;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.AngularAccelerationUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public AngularAccelerationUnit SiUnit => AngularAccelerationUnit.RadiansPerSecondSquared;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => AngularAccelerationUnit.RadiansPerSecondSquared;

        /// <summary>
        /// The quantity in radiansPerSecondSquared".
        /// </summary>
        public double RadiansPerSecondSquared
        {
            get
            {
                return this.radiansPerSecondSquared;
            }
        }

        /// <summary>
        /// The quantity in degreesPerSquareSecond
        /// </summary>
        public double DegreesPerSquareSecond
        {
            get
            {
                return AngularAccelerationUnit.DegreesPerSquareSecond.FromSiUnit(this.radiansPerSecondSquared);
            }
        }

        /// <summary>
        /// The quantity in radiansPerSquareHour
        /// </summary>
        public double RadiansPerSquareHour
        {
            get
            {
                return AngularAccelerationUnit.RadiansPerSquareHour.FromSiUnit(this.radiansPerSecondSquared);
            }
        }

        /// <summary>
        /// The quantity in degreesPerSquareHour
        /// </summary>
        public double DegreesPerSquareHour
        {
            get
            {
                return AngularAccelerationUnit.DegreesPerSquareHour.FromSiUnit(this.radiansPerSecondSquared);
            }
        }

        /// <summary>
        /// The quantity in degreesPerSquareMinute
        /// </summary>
        public double DegreesPerSquareMinute
        {
            get
            {
                return AngularAccelerationUnit.DegreesPerSquareMinute.FromSiUnit(this.radiansPerSecondSquared);
            }
        }

        /// <summary>
        /// The quantity in radiansPerSquareMinute
        /// </summary>
        public double RadiansPerSquareMinute
        {
            get
            {
                return AngularAccelerationUnit.RadiansPerSquareMinute.FromSiUnit(this.radiansPerSecondSquared);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularAcceleration"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <returns></returns>
		public static AngularAcceleration Parse(string s)
        {
            return QuantityParser.Parse<AngularAccelerationUnit, AngularAcceleration>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static AngularAcceleration Parse(string s, IFormatProvider provider)
        {
            return QuantityParser.Parse<AngularAccelerationUnit, AngularAcceleration>(s, From, NumberStyles.Float, provider);
        }

        public static AngularAcceleration Parse(string s, NumberStyles styles)
        {
            return QuantityParser.Parse<AngularAccelerationUnit, AngularAcceleration>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static AngularAcceleration Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<AngularAccelerationUnit, AngularAcceleration>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out AngularAcceleration value)
        {
            return QuantityParser.TryParse<AngularAccelerationUnit, AngularAcceleration>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out AngularAcceleration value)
        {
            return QuantityParser.TryParse<AngularAccelerationUnit, AngularAcceleration>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out AngularAcceleration value)
        {
            return QuantityParser.TryParse<AngularAccelerationUnit, AngularAcceleration>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out AngularAcceleration value)
        {
            return QuantityParser.TryParse<AngularAccelerationUnit, AngularAcceleration>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.AngularAcceleration"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.AngularAcceleration"/></returns>
        public static AngularAcceleration ReadFrom(XmlReader reader)
        {
            var v = new AngularAcceleration();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static AngularAcceleration From(double value, AngularAccelerationUnit unit)
        {
            return new AngularAcceleration(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="radiansPerSecondSquared">The value in <see cref="Gu.Units.AngularAccelerationUnit.RadiansPerSecondSquared"/></param>
        public static AngularAcceleration FromRadiansPerSecondSquared(double radiansPerSecondSquared)
        {
            return new AngularAcceleration(radiansPerSecondSquared);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="degreesPerSquareSecond">The value in °⋅s⁻²</param>
        public static AngularAcceleration FromDegreesPerSquareSecond(double degreesPerSquareSecond)
        {
            return From(degreesPerSquareSecond, AngularAccelerationUnit.DegreesPerSquareSecond);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="radiansPerSquareHour">The value in h⁻²⋅rad</param>
        public static AngularAcceleration FromRadiansPerSquareHour(double radiansPerSquareHour)
        {
            return From(radiansPerSquareHour, AngularAccelerationUnit.RadiansPerSquareHour);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="degreesPerSquareHour">The value in h⁻²⋅°</param>
        public static AngularAcceleration FromDegreesPerSquareHour(double degreesPerSquareHour)
        {
            return From(degreesPerSquareHour, AngularAccelerationUnit.DegreesPerSquareHour);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="degreesPerSquareMinute">The value in min⁻²⋅°</param>
        public static AngularAcceleration FromDegreesPerSquareMinute(double degreesPerSquareMinute)
        {
            return From(degreesPerSquareMinute, AngularAccelerationUnit.DegreesPerSquareMinute);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularAcceleration"/>.
        /// </summary>
        /// <param name="radiansPerSquareMinute">The value in min⁻²⋅rad</param>
        public static AngularAcceleration FromRadiansPerSquareMinute(double radiansPerSquareMinute)
        {
            return From(radiansPerSquareMinute, AngularAccelerationUnit.RadiansPerSquareMinute);
        }

        public static Time operator /(AngularAcceleration left, AngularJerk right)
        {
            return Time.FromSeconds(left.radiansPerSecondSquared / right.radiansPerSecondCubed);
        }

        public static AngularSpeed operator *(AngularAcceleration left, Time right)
        {
            return AngularSpeed.FromRadiansPerSecond(left.radiansPerSecondSquared * right.seconds);
        }

        public static Frequency operator /(AngularAcceleration left, AngularSpeed right)
        {
            return Frequency.FromHertz(left.radiansPerSecondSquared / right.radiansPerSecond);
        }

        public static AngularJerk operator /(AngularAcceleration left, Time right)
        {
            return AngularJerk.FromRadiansPerSecondCubed(left.radiansPerSecondSquared / right.seconds);
        }

        public static double operator /(AngularAcceleration left, AngularAcceleration right)
        {
            return left.radiansPerSecondSquared / right.radiansPerSecondSquared;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularAcceleration"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        public static bool operator ==(AngularAcceleration left, AngularAcceleration right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularAcceleration"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
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
        /// <param name="left">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
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
        /// <param name="left">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
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
        /// <param name="left">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
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
        /// <param name="left">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        public static bool operator >=(AngularAcceleration left, AngularAcceleration right)
        {
            return left.radiansPerSecondSquared >= right.radiansPerSecondSquared;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AngularAcceleration"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.AngularAcceleration"/> with <paramref name="left"/> and returns the result.</returns>
        public static AngularAcceleration operator *(double left, AngularAcceleration right)
        {
            return new AngularAcceleration(left * right.radiansPerSecondSquared);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AngularAcceleration"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.AngularAcceleration"/> with <paramref name="right"/> and returns the result.</returns>
        public static AngularAcceleration operator *(AngularAcceleration left, double right)
        {
            return new AngularAcceleration(left.radiansPerSecondSquared * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.AngularAcceleration"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularAcceleration"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.AngularAcceleration"/> with <paramref name="right"/> and returns the result.</returns>
        public static AngularAcceleration operator /(AngularAcceleration left, double right)
        {
            return new AngularAcceleration(left.radiansPerSecondSquared / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.AngularAcceleration"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AngularAcceleration"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularAcceleration"/>.</param>
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
        /// <param name="left">An instance of <see cref="Gu.Units.AngularAcceleration"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularAcceleration"/> (the subtrahend).</param>
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
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
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
        /// <returns>The string representation of the <see cref="AngularAcceleration"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 rad/s²\"</param>
        /// <returns>The string representation of the <see cref="AngularAcceleration"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 rad/s²\"</param>
        /// <returns>The string representation of the <see cref="AngularAcceleration"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex rad/s²</param>
        /// <returns>The string representation of the <see cref="AngularAcceleration"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex rad/s²</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="AngularAcceleration"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AngularAccelerationUnit unit)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(AngularAccelerationUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(AngularAccelerationUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AngularAccelerationUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AngularAccelerationUnit unit)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AngularAccelerationUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AngularAccelerationUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AngularAccelerationUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularAccelerationUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<AngularAccelerationUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.AngularAcceleration"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.AngularAcceleration"/> object.
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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngularAcceleration && this.Equals((AngularAcceleration)obj);
        }

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
    }
}