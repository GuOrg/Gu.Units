namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.ForcePerUnitless"/>.
    /// </summary>
    // [TypeConverter(typeof(ForcePerUnitlessTypeConverter))]
    [Serializable]
    public partial struct ForcePerUnitless : IQuantity<ForcePerUnitlessUnit>, IComparable<ForcePerUnitless>, IEquatable<ForcePerUnitless>
    {
        public static readonly ForcePerUnitless Zero = new ForcePerUnitless();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.ForcePerUnitlessUnit.NewtonsPerUnitless"/>.
        /// </summary>
        internal readonly double newtonsPerUnitless;

        private ForcePerUnitless(double newtonsPerUnitless)
        {
            this.newtonsPerUnitless = newtonsPerUnitless;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.ForcePerUnitlessUnit"/>.</param>
        public ForcePerUnitless(double value, ForcePerUnitlessUnit unit)
        {
            this.newtonsPerUnitless = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.ForcePerUnitlessUnit.NewtonsPerUnitless"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.newtonsPerUnitless;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.ForcePerUnitlessUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public ForcePerUnitlessUnit SiUnit => ForcePerUnitlessUnit.NewtonsPerUnitless;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => ForcePerUnitlessUnit.NewtonsPerUnitless;

        /// <summary>
        /// The quantity in newtonsPerUnitless".
        /// </summary>
        public double NewtonsPerUnitless
        {
            get
            {
                return this.newtonsPerUnitless;
            }
        }

        /// <summary>
        /// The quantity in NewtonsPerPercent
        /// </summary>
        public double NewtonsPerPercent => this.newtonsPerUnitless / 100;

        /// <summary>
        /// The quantity in KilonewtonsPerPercent
        /// </summary>
        public double KilonewtonsPerPercent => this.newtonsPerUnitless / 100000;

        /// <summary>
        /// The quantity in MeganewtonsPerPercent
        /// </summary>
        public double MeganewtonsPerPercent => this.newtonsPerUnitless / 100000000;

        /// <summary>
        /// The quantity in GiganewtonsPerPercent
        /// </summary>
        public double GiganewtonsPerPercent => this.newtonsPerUnitless / 100000000000;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ForcePerUnitless"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <returns></returns>
		public static ForcePerUnitless Parse(string s)
        {
            return QuantityParser.Parse<ForcePerUnitlessUnit, ForcePerUnitless>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static ForcePerUnitless Parse(string s, IFormatProvider provider)
        {
            return QuantityParser.Parse<ForcePerUnitlessUnit, ForcePerUnitless>(s, From, NumberStyles.Float, provider);
        }

        public static ForcePerUnitless Parse(string s, NumberStyles styles)
        {
            return QuantityParser.Parse<ForcePerUnitlessUnit, ForcePerUnitless>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static ForcePerUnitless Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<ForcePerUnitlessUnit, ForcePerUnitless>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out ForcePerUnitless value)
        {
            return QuantityParser.TryParse<ForcePerUnitlessUnit, ForcePerUnitless>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out ForcePerUnitless value)
        {
            return QuantityParser.TryParse<ForcePerUnitlessUnit, ForcePerUnitless>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out ForcePerUnitless value)
        {
            return QuantityParser.TryParse<ForcePerUnitlessUnit, ForcePerUnitless>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out ForcePerUnitless value)
        {
            return QuantityParser.TryParse<ForcePerUnitlessUnit, ForcePerUnitless>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.ForcePerUnitless"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.ForcePerUnitless"/></returns>
        public static ForcePerUnitless ReadFrom(XmlReader reader)
        {
            var v = new ForcePerUnitless();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static ForcePerUnitless From(double value, ForcePerUnitlessUnit unit)
        {
            return new ForcePerUnitless(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <param name="newtonsPerUnitless">The value in <see cref="Gu.Units.ForcePerUnitlessUnit.NewtonsPerUnitless"/></param>
        public static ForcePerUnitless FromNewtonsPerUnitless(double newtonsPerUnitless)
        {
            return new ForcePerUnitless(newtonsPerUnitless);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <param name="newtonsPerPercent">The value in N/%</param>
        public static ForcePerUnitless FromNewtonsPerPercent(double newtonsPerPercent)
        {
            return new ForcePerUnitless(100 * newtonsPerPercent);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <param name="kilonewtonsPerPercent">The value in kN/%</param>
        public static ForcePerUnitless FromKilonewtonsPerPercent(double kilonewtonsPerPercent)
        {
            return new ForcePerUnitless(100000 * kilonewtonsPerPercent);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <param name="meganewtonsPerPercent">The value in MN/%</param>
        public static ForcePerUnitless FromMeganewtonsPerPercent(double meganewtonsPerPercent)
        {
            return new ForcePerUnitless(100000000 * meganewtonsPerPercent);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <param name="giganewtonsPerPercent">The value in GN/%</param>
        public static ForcePerUnitless FromGiganewtonsPerPercent(double giganewtonsPerPercent)
        {
            return new ForcePerUnitless(100000000000 * giganewtonsPerPercent);
        }

        public static Force operator *(ForcePerUnitless left, Unitless right)
        {
            return Force.FromNewtons(left.newtonsPerUnitless * right.scalar);
        }

        public static LengthPerUnitless operator /(ForcePerUnitless left, Stiffness right)
        {
            return LengthPerUnitless.FromMetresPerUnitless(left.newtonsPerUnitless / right.newtonsPerMetre);
        }

        public static LengthPerUnitless operator *(ForcePerUnitless left, Flexibility right)
        {
            return LengthPerUnitless.FromMetresPerUnitless(left.newtonsPerUnitless * right.metresPerNewton);
        }

        public static Stiffness operator /(ForcePerUnitless left, LengthPerUnitless right)
        {
            return Stiffness.FromNewtonsPerMetre(left.newtonsPerUnitless / right.metresPerUnitless);
        }

        public static double operator /(ForcePerUnitless left, ForcePerUnitless right)
        {
            return left.newtonsPerUnitless / right.newtonsPerUnitless;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ForcePerUnitless"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static bool operator ==(ForcePerUnitless left, ForcePerUnitless right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ForcePerUnitless"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static bool operator !=(ForcePerUnitless left, ForcePerUnitless right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ForcePerUnitless"/> is less than another specified <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static bool operator <(ForcePerUnitless left, ForcePerUnitless right)
        {
            return left.newtonsPerUnitless < right.newtonsPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ForcePerUnitless"/> is greater than another specified <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static bool operator >(ForcePerUnitless left, ForcePerUnitless right)
        {
            return left.newtonsPerUnitless > right.newtonsPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ForcePerUnitless"/> is less than or equal to another specified <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static bool operator <=(ForcePerUnitless left, ForcePerUnitless right)
        {
            return left.newtonsPerUnitless <= right.newtonsPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ForcePerUnitless"/> is greater than or equal to another specified <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static bool operator >=(ForcePerUnitless left, ForcePerUnitless right)
        {
            return left.newtonsPerUnitless >= right.newtonsPerUnitless;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.ForcePerUnitless"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.ForcePerUnitless"/> with <paramref name="left"/> and returns the result.</returns>
        public static ForcePerUnitless operator *(double left, ForcePerUnitless right)
        {
            return new ForcePerUnitless(left * right.newtonsPerUnitless);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.ForcePerUnitless"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.ForcePerUnitless"/> with <paramref name="right"/> and returns the result.</returns>
        public static ForcePerUnitless operator *(ForcePerUnitless left, double right)
        {
            return new ForcePerUnitless(left.newtonsPerUnitless * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.ForcePerUnitless"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.ForcePerUnitless"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.ForcePerUnitless"/> with <paramref name="right"/> and returns the result.</returns>
        public static ForcePerUnitless operator /(ForcePerUnitless left, double right)
        {
            return new ForcePerUnitless(left.newtonsPerUnitless / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.ForcePerUnitless"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.ForcePerUnitless"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ForcePerUnitless"/>.</param>
        public static ForcePerUnitless operator +(ForcePerUnitless left, ForcePerUnitless right)
        {
            return new ForcePerUnitless(left.newtonsPerUnitless + right.newtonsPerUnitless);
        }

        /// <summary>
        /// Subtracts an ForcePerUnitless from another ForcePerUnitless and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.ForcePerUnitless"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ForcePerUnitless"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ForcePerUnitless"/> (the subtrahend).</param>
        public static ForcePerUnitless operator -(ForcePerUnitless left, ForcePerUnitless right)
        {
            return new ForcePerUnitless(left.newtonsPerUnitless - right.newtonsPerUnitless);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.ForcePerUnitless"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.ForcePerUnitless"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="forcePerUnitless">An instance of <see cref="Gu.Units.ForcePerUnitless"/></param>
        public static ForcePerUnitless operator -(ForcePerUnitless forcePerUnitless)
        {
            return new ForcePerUnitless(-1 * forcePerUnitless.newtonsPerUnitless);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.ForcePerUnitless"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="forcePerUnitless"/>.
        /// </returns>
        /// <param name="forcePerUnitless">An instance of <see cref="Gu.Units.ForcePerUnitless"/></param>
        public static ForcePerUnitless operator +(ForcePerUnitless forcePerUnitless)
        {
            return forcePerUnitless;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(ForcePerUnitlessUnit unit)
        {
            return unit.FromSiUnit(this.newtonsPerUnitless);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="ForcePerUnitless"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="ForcePerUnitless"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N/ul\"</param>
        /// <returns>The string representation of the <see cref="ForcePerUnitless"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N/ul\"</param>
        /// <returns>The string representation of the <see cref="ForcePerUnitless"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex N/ul</param>
        /// <returns>The string representation of the <see cref="ForcePerUnitless"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex N/ul</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="ForcePerUnitless"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(ForcePerUnitlessUnit unit)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(ForcePerUnitlessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(ForcePerUnitlessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(ForcePerUnitlessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, ForcePerUnitlessUnit unit)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, ForcePerUnitlessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, ForcePerUnitlessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, ForcePerUnitlessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForcePerUnitlessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<ForcePerUnitlessUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.ForcePerUnitless"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.ForcePerUnitless"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.ForcePerUnitless"/> object to compare to this instance.</param>
        public int CompareTo(ForcePerUnitless quantity)
        {
            return this.newtonsPerUnitless.CompareTo(quantity.newtonsPerUnitless);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.ForcePerUnitless"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same ForcePerUnitless as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.ForcePerUnitless"/> object to compare with this instance.</param>
        public bool Equals(ForcePerUnitless other)
        {
            return this.newtonsPerUnitless.Equals(other.newtonsPerUnitless);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.ForcePerUnitless"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same ForcePerUnitless as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.ForcePerUnitless"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(ForcePerUnitless other, ForcePerUnitless tolerance)
        {
            Ensure.GreaterThan(tolerance.newtonsPerUnitless, 0, nameof(tolerance));
            return Math.Abs(this.newtonsPerUnitless - other.newtonsPerUnitless) < tolerance.newtonsPerUnitless;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ForcePerUnitless && this.Equals((ForcePerUnitless)obj);
        }

        public override int GetHashCode()
        {
            return this.newtonsPerUnitless.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "newtonsPerUnitless", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.newtonsPerUnitless);
        }
    }
}