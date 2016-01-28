namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.AnglePerUnitless"/>.
    /// </summary>
    // [TypeConverter(typeof(AnglePerUnitlessTypeConverter))]
    [Serializable]
    public partial struct AnglePerUnitless : IQuantity<AnglePerUnitlessUnit>, IComparable<AnglePerUnitless>, IEquatable<AnglePerUnitless>
    {
        public static readonly AnglePerUnitless Zero = new AnglePerUnitless();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AnglePerUnitlessUnit.RadiansPerUnitless"/>.
        /// </summary>
        internal readonly double radiansPerUnitless;

        private AnglePerUnitless(double radiansPerUnitless)
        {
            this.radiansPerUnitless = radiansPerUnitless;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.AnglePerUnitless"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.AnglePerUnitlessUnit"/>.</param>
        public AnglePerUnitless(double value, AnglePerUnitlessUnit unit)
        {
            this.radiansPerUnitless = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AnglePerUnitlessUnit.RadiansPerUnitless"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.radiansPerUnitless;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.AnglePerUnitlessUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public AnglePerUnitlessUnit SiUnit => AnglePerUnitlessUnit.RadiansPerUnitless;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => AnglePerUnitlessUnit.RadiansPerUnitless;

        /// <summary>
        /// The quantity in radiansPerUnitless".
        /// </summary>
        public double RadiansPerUnitless
        {
            get
            {
                return this.radiansPerUnitless;
            }
        }

        /// <summary>
        /// The quantity in DegreesPerPercent
        /// </summary>
        public double DegreesPerPercent => this.radiansPerUnitless / 1.74532925199433;

        /// <summary>
        /// The quantity in RadiansPerPercent
        /// </summary>
        public double RadiansPerPercent => this.radiansPerUnitless / 100;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AnglePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AnglePerUnitless"/></param>
        /// <returns></returns>
		public static AnglePerUnitless Parse(string text)
        {
            return QuantityParser.Parse<AnglePerUnitlessUnit, AnglePerUnitless>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AnglePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AnglePerUnitless"/></param>
        /// <returns></returns>
        public static AnglePerUnitless Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<AnglePerUnitlessUnit, AnglePerUnitless>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AnglePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AnglePerUnitless"/></param>
        /// <returns></returns>
        public static AnglePerUnitless Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<AnglePerUnitlessUnit, AnglePerUnitless>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AnglePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AnglePerUnitless"/></param>
        /// <returns></returns>
        public static AnglePerUnitless Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<AnglePerUnitlessUnit, AnglePerUnitless>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AnglePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AnglePerUnitless"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out AnglePerUnitless result)
        {
            return QuantityParser.TryParse<AnglePerUnitlessUnit, AnglePerUnitless>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AnglePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AnglePerUnitless"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out AnglePerUnitless result)
        {
            return QuantityParser.TryParse<AnglePerUnitlessUnit, AnglePerUnitless>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AnglePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AnglePerUnitless"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out AnglePerUnitless result)
        {
            return QuantityParser.TryParse<AnglePerUnitlessUnit, AnglePerUnitless>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AnglePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AnglePerUnitless"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out AnglePerUnitless result)
        {
            return QuantityParser.TryParse<AnglePerUnitlessUnit, AnglePerUnitless>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.AnglePerUnitless"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.AnglePerUnitless"/></returns>
        public static AnglePerUnitless ReadFrom(XmlReader reader)
        {
            var v = new AnglePerUnitless();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AnglePerUnitless"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static AnglePerUnitless From(double value, AnglePerUnitlessUnit unit)
        {
            return new AnglePerUnitless(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AnglePerUnitless"/>.
        /// </summary>
        /// <param name="radiansPerUnitless">The value in <see cref="Gu.Units.AnglePerUnitlessUnit.RadiansPerUnitless"/></param>
        public static AnglePerUnitless FromRadiansPerUnitless(double radiansPerUnitless)
        {
            return new AnglePerUnitless(radiansPerUnitless);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AnglePerUnitless"/>.
        /// </summary>
        /// <param name="degreesPerPercent">The value in °/%</param>
        public static AnglePerUnitless FromDegreesPerPercent(double degreesPerPercent)
        {
            return new AnglePerUnitless(1.74532925199433 * degreesPerPercent);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AnglePerUnitless"/>.
        /// </summary>
        /// <param name="radiansPerPercent">The value in rad/%</param>
        public static AnglePerUnitless FromRadiansPerPercent(double radiansPerPercent)
        {
            return new AnglePerUnitless(100 * radiansPerPercent);
        }

        public static Angle operator *(AnglePerUnitless left, Unitless right)
        {
            return Angle.FromRadians(left.radiansPerUnitless * right.scalar);
        }

        public static double operator /(AnglePerUnitless left, AnglePerUnitless right)
        {
            return left.radiansPerUnitless / right.radiansPerUnitless;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AnglePerUnitless"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        public static bool operator ==(AnglePerUnitless left, AnglePerUnitless right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AnglePerUnitless"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        public static bool operator !=(AnglePerUnitless left, AnglePerUnitless right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AnglePerUnitless"/> is less than another specified <see cref="Gu.Units.AnglePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        public static bool operator <(AnglePerUnitless left, AnglePerUnitless right)
        {
            return left.radiansPerUnitless < right.radiansPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AnglePerUnitless"/> is greater than another specified <see cref="Gu.Units.AnglePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        public static bool operator >(AnglePerUnitless left, AnglePerUnitless right)
        {
            return left.radiansPerUnitless > right.radiansPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AnglePerUnitless"/> is less than or equal to another specified <see cref="Gu.Units.AnglePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        public static bool operator <=(AnglePerUnitless left, AnglePerUnitless right)
        {
            return left.radiansPerUnitless <= right.radiansPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AnglePerUnitless"/> is greater than or equal to another specified <see cref="Gu.Units.AnglePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        public static bool operator >=(AnglePerUnitless left, AnglePerUnitless right)
        {
            return left.radiansPerUnitless >= right.radiansPerUnitless;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AnglePerUnitless"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.AnglePerUnitless"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.AnglePerUnitless"/> with <paramref name="left"/> and returns the result.</returns>
        public static AnglePerUnitless operator *(double left, AnglePerUnitless right)
        {
            return new AnglePerUnitless(left * right.radiansPerUnitless);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AnglePerUnitless"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.AnglePerUnitless"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.AnglePerUnitless"/> with <paramref name="right"/> and returns the result.</returns>
        public static AnglePerUnitless operator *(AnglePerUnitless left, double right)
        {
            return new AnglePerUnitless(left.radiansPerUnitless * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.AnglePerUnitless"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.AnglePerUnitless"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.AnglePerUnitless"/> with <paramref name="right"/> and returns the result.</returns>
        public static AnglePerUnitless operator /(AnglePerUnitless left, double right)
        {
            return new AnglePerUnitless(left.radiansPerUnitless / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.AnglePerUnitless"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AnglePerUnitless"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AnglePerUnitless"/>.</param>
        public static AnglePerUnitless operator +(AnglePerUnitless left, AnglePerUnitless right)
        {
            return new AnglePerUnitless(left.radiansPerUnitless + right.radiansPerUnitless);
        }

        /// <summary>
        /// Subtracts an AnglePerUnitless from another AnglePerUnitless and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AnglePerUnitless"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AnglePerUnitless"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AnglePerUnitless"/> (the subtrahend).</param>
        public static AnglePerUnitless operator -(AnglePerUnitless left, AnglePerUnitless right)
        {
            return new AnglePerUnitless(left.radiansPerUnitless - right.radiansPerUnitless);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.AnglePerUnitless"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AnglePerUnitless"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="anglePerUnitless">An instance of <see cref="Gu.Units.AnglePerUnitless"/></param>
        public static AnglePerUnitless operator -(AnglePerUnitless anglePerUnitless)
        {
            return new AnglePerUnitless(-1 * anglePerUnitless.radiansPerUnitless);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.AnglePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="anglePerUnitless"/>.
        /// </returns>
        /// <param name="anglePerUnitless">An instance of <see cref="Gu.Units.AnglePerUnitless"/></param>
        public static AnglePerUnitless operator +(AnglePerUnitless anglePerUnitless)
        {
            return anglePerUnitless;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(AnglePerUnitlessUnit unit)
        {
            return unit.FromSiUnit(this.radiansPerUnitless);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="AnglePerUnitless"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="AnglePerUnitless"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 rad/ul\"</param>
        /// <returns>The string representation of the <see cref="AnglePerUnitless"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 rad/ul\"</param>
        /// <returns>The string representation of the <see cref="AnglePerUnitless"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex rad/ul</param>
        /// <returns>The string representation of the <see cref="AnglePerUnitless"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex rad/ul</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="AnglePerUnitless"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AnglePerUnitlessUnit unit)
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(AnglePerUnitlessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(AnglePerUnitlessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AnglePerUnitlessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AnglePerUnitlessUnit unit)
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AnglePerUnitlessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AnglePerUnitlessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AnglePerUnitlessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AnglePerUnitlessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<AnglePerUnitlessUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.AnglePerUnitless"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.AnglePerUnitless"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.AnglePerUnitless"/> object to compare to this instance.</param>
        public int CompareTo(AnglePerUnitless quantity)
        {
            return this.radiansPerUnitless.CompareTo(quantity.radiansPerUnitless);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AnglePerUnitless"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AnglePerUnitless as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.AnglePerUnitless"/> object to compare with this instance.</param>
        public bool Equals(AnglePerUnitless other)
        {
            return this.radiansPerUnitless.Equals(other.radiansPerUnitless);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AnglePerUnitless"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AnglePerUnitless as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.AnglePerUnitless"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(AnglePerUnitless other, AnglePerUnitless tolerance)
        {
            Ensure.GreaterThan(tolerance.radiansPerUnitless, 0, nameof(tolerance));
            return Math.Abs(this.radiansPerUnitless - other.radiansPerUnitless) < tolerance.radiansPerUnitless;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AnglePerUnitless && this.Equals((AnglePerUnitless)obj);
        }

        public override int GetHashCode()
        {
            return this.radiansPerUnitless.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "radiansPerUnitless", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.radiansPerUnitless);
        }
    }
}