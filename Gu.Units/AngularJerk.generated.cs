namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.AngularJerk"/>.
    /// </summary>
    // [TypeConverter(typeof(AngularJerkTypeConverter))]
    [Serializable]
    public partial struct AngularJerk : IQuantity<AngularJerkUnit>, IComparable<AngularJerk>, IEquatable<AngularJerk>
    {
        public static readonly AngularJerk Zero = new AngularJerk();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AngularJerkUnit.RadiansPerSecondCubed"/>.
        /// </summary>
        internal readonly double radiansPerSecondCubed;

        private AngularJerk(double radiansPerSecondCubed)
        {
            this.radiansPerSecondCubed = radiansPerSecondCubed;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.AngularJerkUnit"/>.</param>
        public AngularJerk(double value, AngularJerkUnit unit)
        {
            this.radiansPerSecondCubed = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AngularJerkUnit.RadiansPerSecondCubed"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.radiansPerSecondCubed;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.AngularJerkUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public AngularJerkUnit SiUnit => AngularJerkUnit.RadiansPerSecondCubed;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => AngularJerkUnit.RadiansPerSecondCubed;

        /// <summary>
        /// The quantity in radiansPerSecondCubed".
        /// </summary>
        public double RadiansPerSecondCubed
        {
            get
            {
                return this.radiansPerSecondCubed;
            }
        }

        /// <summary>
        /// The quantity in DegreesPerSecondCubed
        /// </summary>
        public double DegreesPerSecondCubed => this.radiansPerSecondCubed / 0.0174532925199433;

        /// <summary>
        /// The quantity in RadiansPerHourCubed
        /// </summary>
        public double RadiansPerHourCubed => 46656000000 * this.radiansPerSecondCubed;

        /// <summary>
        /// The quantity in DegreesPerHourCubed
        /// </summary>
        public double DegreesPerHourCubed => this.radiansPerSecondCubed / 3.74084630485753E-13;

        /// <summary>
        /// The quantity in RadiansPerMinuteCubed
        /// </summary>
        public double RadiansPerMinuteCubed => 216000 * this.radiansPerSecondCubed;

        /// <summary>
        /// The quantity in DegreesPerMinuteCubed
        /// </summary>
        public double DegreesPerMinuteCubed => this.radiansPerSecondCubed / 8.08022801849227E-08;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AngularJerk"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="Gu.Units.AngularJerk"/></param>
        /// <returns></returns>
		public static AngularJerk Parse(string s)
        {
            return QuantityParser.Parse<AngularJerkUnit, AngularJerk>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static AngularJerk Parse(string s, IFormatProvider provider)
        {
            return QuantityParser.Parse<AngularJerkUnit, AngularJerk>(s, From, NumberStyles.Float, provider);
        }

        public static AngularJerk Parse(string s, NumberStyles styles)
        {
            return QuantityParser.Parse<AngularJerkUnit, AngularJerk>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static AngularJerk Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<AngularJerkUnit, AngularJerk>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out AngularJerk value)
        {
            return QuantityParser.TryParse<AngularJerkUnit, AngularJerk>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out AngularJerk value)
        {
            return QuantityParser.TryParse<AngularJerkUnit, AngularJerk>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out AngularJerk value)
        {
            return QuantityParser.TryParse<AngularJerkUnit, AngularJerk>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out AngularJerk value)
        {
            return QuantityParser.TryParse<AngularJerkUnit, AngularJerk>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.AngularJerk"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.AngularJerk"/></returns>
        public static AngularJerk ReadFrom(XmlReader reader)
        {
            var v = new AngularJerk();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static AngularJerk From(double value, AngularJerkUnit unit)
        {
            return new AngularJerk(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="radiansPerSecondCubed">The value in <see cref="Gu.Units.AngularJerkUnit.RadiansPerSecondCubed"/></param>
        public static AngularJerk FromRadiansPerSecondCubed(double radiansPerSecondCubed)
        {
            return new AngularJerk(radiansPerSecondCubed);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="degreesPerSecondCubed">The value in °⋅s⁻³</param>
        public static AngularJerk FromDegreesPerSecondCubed(double degreesPerSecondCubed)
        {
            return new AngularJerk(0.0174532925199433 * degreesPerSecondCubed);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="radiansPerHourCubed">The value in rad⋅h⁻³</param>
        public static AngularJerk FromRadiansPerHourCubed(double radiansPerHourCubed)
        {
            return new AngularJerk(radiansPerHourCubed / 46656000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="degreesPerHourCubed">The value in °⋅h⁻³</param>
        public static AngularJerk FromDegreesPerHourCubed(double degreesPerHourCubed)
        {
            return new AngularJerk(3.74084630485753E-13 * degreesPerHourCubed);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="radiansPerMinuteCubed">The value in rad⋅min⁻³</param>
        public static AngularJerk FromRadiansPerMinuteCubed(double radiansPerMinuteCubed)
        {
            return new AngularJerk(radiansPerMinuteCubed / 216000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="degreesPerMinuteCubed">The value in °⋅min⁻³</param>
        public static AngularJerk FromDegreesPerMinuteCubed(double degreesPerMinuteCubed)
        {
            return new AngularJerk(8.08022801849227E-08 * degreesPerMinuteCubed);
        }

        public static AngularAcceleration operator *(AngularJerk left, Time right)
        {
            return AngularAcceleration.FromRadiansPerSecondSquared(left.radiansPerSecondCubed * right.seconds);
        }

        public static AngularAcceleration operator /(AngularJerk left, Frequency right)
        {
            return AngularAcceleration.FromRadiansPerSecondSquared(left.radiansPerSecondCubed / right.hertz);
        }

        public static Frequency operator /(AngularJerk left, AngularAcceleration right)
        {
            return Frequency.FromHertz(left.radiansPerSecondCubed / right.radiansPerSecondSquared);
        }

        public static double operator /(AngularJerk left, AngularJerk right)
        {
            return left.radiansPerSecondCubed / right.radiansPerSecondCubed;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularJerk"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        public static bool operator ==(AngularJerk left, AngularJerk right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AngularJerk"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        public static bool operator !=(AngularJerk left, AngularJerk right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AngularJerk"/> is less than another specified <see cref="Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        public static bool operator <(AngularJerk left, AngularJerk right)
        {
            return left.radiansPerSecondCubed < right.radiansPerSecondCubed;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AngularJerk"/> is greater than another specified <see cref="Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        public static bool operator >(AngularJerk left, AngularJerk right)
        {
            return left.radiansPerSecondCubed > right.radiansPerSecondCubed;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AngularJerk"/> is less than or equal to another specified <see cref="Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        public static bool operator <=(AngularJerk left, AngularJerk right)
        {
            return left.radiansPerSecondCubed <= right.radiansPerSecondCubed;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AngularJerk"/> is greater than or equal to another specified <see cref="Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        public static bool operator >=(AngularJerk left, AngularJerk right)
        {
            return left.radiansPerSecondCubed >= right.radiansPerSecondCubed;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AngularJerk"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularJerk"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.AngularJerk"/> with <paramref name="left"/> and returns the result.</returns>
        public static AngularJerk operator *(double left, AngularJerk right)
        {
            return new AngularJerk(left * right.radiansPerSecondCubed);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AngularJerk"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularJerk"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.AngularJerk"/> with <paramref name="right"/> and returns the result.</returns>
        public static AngularJerk operator *(AngularJerk left, double right)
        {
            return new AngularJerk(left.radiansPerSecondCubed * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.AngularJerk"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularJerk"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.AngularJerk"/> with <paramref name="right"/> and returns the result.</returns>
        public static AngularJerk operator /(AngularJerk left, double right)
        {
            return new AngularJerk(left.radiansPerSecondCubed / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.AngularJerk"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AngularJerk"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularJerk"/>.</param>
        public static AngularJerk operator +(AngularJerk left, AngularJerk right)
        {
            return new AngularJerk(left.radiansPerSecondCubed + right.radiansPerSecondCubed);
        }

        /// <summary>
        /// Subtracts an AngularJerk from another AngularJerk and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AngularJerk"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AngularJerk"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AngularJerk"/> (the subtrahend).</param>
        public static AngularJerk operator -(AngularJerk left, AngularJerk right)
        {
            return new AngularJerk(left.radiansPerSecondCubed - right.radiansPerSecondCubed);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.AngularJerk"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AngularJerk"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="angularJerk">An instance of <see cref="Gu.Units.AngularJerk"/></param>
        public static AngularJerk operator -(AngularJerk angularJerk)
        {
            return new AngularJerk(-1 * angularJerk.radiansPerSecondCubed);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="angularJerk"/>.
        /// </returns>
        /// <param name="angularJerk">An instance of <see cref="Gu.Units.AngularJerk"/></param>
        public static AngularJerk operator +(AngularJerk angularJerk)
        {
            return angularJerk;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(AngularJerkUnit unit)
        {
            return unit.FromSiUnit(this.radiansPerSecondCubed);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="AngularJerk"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="AngularJerk"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 rad/s³\"</param>
        /// <returns>The string representation of the <see cref="AngularJerk"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 rad/s³\"</param>
        /// <returns>The string representation of the <see cref="AngularJerk"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex rad/s³</param>
        /// <returns>The string representation of the <see cref="AngularJerk"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex rad/s³</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="AngularJerk"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AngularJerkUnit unit)
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(AngularJerkUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(AngularJerkUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AngularJerkUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AngularJerkUnit unit)
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AngularJerkUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AngularJerkUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AngularJerkUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AngularJerkUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<AngularJerkUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.AngularJerk"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.AngularJerk"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.AngularJerk"/> object to compare to this instance.</param>
        public int CompareTo(AngularJerk quantity)
        {
            return this.radiansPerSecondCubed.CompareTo(quantity.radiansPerSecondCubed);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AngularJerk"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularJerk as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.AngularJerk"/> object to compare with this instance.</param>
        public bool Equals(AngularJerk other)
        {
            return this.radiansPerSecondCubed.Equals(other.radiansPerSecondCubed);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AngularJerk"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularJerk as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.AngularJerk"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(AngularJerk other, AngularJerk tolerance)
        {
            Ensure.GreaterThan(tolerance.radiansPerSecondCubed, 0, nameof(tolerance));
            return Math.Abs(this.radiansPerSecondCubed - other.radiansPerSecondCubed) < tolerance.radiansPerSecondCubed;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngularJerk && this.Equals((AngularJerk)obj);
        }

        public override int GetHashCode()
        {
            return this.radiansPerSecondCubed.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "radiansPerSecondCubed", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.radiansPerSecondCubed);
        }
    }
}