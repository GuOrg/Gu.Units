namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.LengthPerUnitless"/>.
    /// </summary>
    // [TypeConverter(typeof(LengthPerUnitlessTypeConverter))]
    [Serializable]
    public partial struct LengthPerUnitless : IQuantity<LengthPerUnitlessUnit>, IComparable<LengthPerUnitless>, IEquatable<LengthPerUnitless>
    {
        public static readonly LengthPerUnitless Zero = new LengthPerUnitless();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.LengthPerUnitlessUnit.MetresPerUnitless"/>.
        /// </summary>
        internal readonly double metresPerUnitless;

        private LengthPerUnitless(double metresPerUnitless)
        {
            this.metresPerUnitless = metresPerUnitless;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.LengthPerUnitlessUnit"/>.</param>
        public LengthPerUnitless(double value, LengthPerUnitlessUnit unit)
        {
            this.metresPerUnitless = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.LengthPerUnitlessUnit.MetresPerUnitless"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.metresPerUnitless;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.LengthPerUnitlessUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public LengthPerUnitlessUnit SiUnit => LengthPerUnitlessUnit.MetresPerUnitless;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => LengthPerUnitlessUnit.MetresPerUnitless;

        /// <summary>
        /// The quantity in metresPerUnitless".
        /// </summary>
        public double MetresPerUnitless
        {
            get
            {
                return this.metresPerUnitless;
            }
        }

        /// <summary>
        /// The quantity in MillimetresPerPercent
        /// </summary>
        public double MillimetresPerPercent => 10 * this.metresPerUnitless;

        /// <summary>
        /// The quantity in MicrometresPerPercent
        /// </summary>
        public double MicrometresPerPercent => 10000 * this.metresPerUnitless;

        /// <summary>
        /// The quantity in MetresPerPercent
        /// </summary>
        public double MetresPerPercent => this.metresPerUnitless / 100;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <returns></returns>
		public static LengthPerUnitless Parse(string text)
        {
            return QuantityParser.Parse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <returns></returns>
        public static LengthPerUnitless Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <returns></returns>
        public static LengthPerUnitless Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <returns></returns>
        public static LengthPerUnitless Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out LengthPerUnitless result)
        {
            return QuantityParser.TryParse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out LengthPerUnitless result)
        {
            return QuantityParser.TryParse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out LengthPerUnitless result)
        {
            return QuantityParser.TryParse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthPerUnitless"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out LengthPerUnitless result)
        {
            return QuantityParser.TryParse<LengthPerUnitlessUnit, LengthPerUnitless>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.LengthPerUnitless"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.LengthPerUnitless"/></returns>
        public static LengthPerUnitless ReadFrom(XmlReader reader)
        {
            var v = new LengthPerUnitless();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static LengthPerUnitless From(double value, LengthPerUnitlessUnit unit)
        {
            return new LengthPerUnitless(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <param name="metresPerUnitless">The value in <see cref="Gu.Units.LengthPerUnitlessUnit.MetresPerUnitless"/></param>
        public static LengthPerUnitless FromMetresPerUnitless(double metresPerUnitless)
        {
            return new LengthPerUnitless(metresPerUnitless);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <param name="millimetresPerPercent">The value in mm/%</param>
        public static LengthPerUnitless FromMillimetresPerPercent(double millimetresPerPercent)
        {
            return new LengthPerUnitless(millimetresPerPercent / 10);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <param name="micrometresPerPercent">The value in µm/%</param>
        public static LengthPerUnitless FromMicrometresPerPercent(double micrometresPerPercent)
        {
            return new LengthPerUnitless(micrometresPerPercent / 10000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <param name="metresPerPercent">The value in m/%</param>
        public static LengthPerUnitless FromMetresPerPercent(double metresPerPercent)
        {
            return new LengthPerUnitless(100 * metresPerPercent);
        }

        public static Length operator *(LengthPerUnitless left, Unitless right)
        {
            return Length.FromMetres(left.metresPerUnitless * right.scalar);
        }

        public static ForcePerUnitless operator *(LengthPerUnitless left, Stiffness right)
        {
            return ForcePerUnitless.FromNewtonsPerUnitless(left.metresPerUnitless * right.newtonsPerMetre);
        }

        public static ForcePerUnitless operator /(LengthPerUnitless left, Flexibility right)
        {
            return ForcePerUnitless.FromNewtonsPerUnitless(left.metresPerUnitless / right.metresPerNewton);
        }

        public static Flexibility operator /(LengthPerUnitless left, ForcePerUnitless right)
        {
            return Flexibility.FromMetresPerNewton(left.metresPerUnitless / right.newtonsPerUnitless);
        }

        public static double operator /(LengthPerUnitless left, LengthPerUnitless right)
        {
            return left.metresPerUnitless / right.metresPerUnitless;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LengthPerUnitless"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static bool operator ==(LengthPerUnitless left, LengthPerUnitless right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LengthPerUnitless"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static bool operator !=(LengthPerUnitless left, LengthPerUnitless right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.LengthPerUnitless"/> is less than another specified <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static bool operator <(LengthPerUnitless left, LengthPerUnitless right)
        {
            return left.metresPerUnitless < right.metresPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.LengthPerUnitless"/> is greater than another specified <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static bool operator >(LengthPerUnitless left, LengthPerUnitless right)
        {
            return left.metresPerUnitless > right.metresPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.LengthPerUnitless"/> is less than or equal to another specified <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static bool operator <=(LengthPerUnitless left, LengthPerUnitless right)
        {
            return left.metresPerUnitless <= right.metresPerUnitless;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.LengthPerUnitless"/> is greater than or equal to another specified <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static bool operator >=(LengthPerUnitless left, LengthPerUnitless right)
        {
            return left.metresPerUnitless >= right.metresPerUnitless;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.LengthPerUnitless"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.LengthPerUnitless"/> with <paramref name="left"/> and returns the result.</returns>
        public static LengthPerUnitless operator *(double left, LengthPerUnitless right)
        {
            return new LengthPerUnitless(left * right.metresPerUnitless);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.LengthPerUnitless"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.LengthPerUnitless"/> with <paramref name="right"/> and returns the result.</returns>
        public static LengthPerUnitless operator *(LengthPerUnitless left, double right)
        {
            return new LengthPerUnitless(left.metresPerUnitless * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.LengthPerUnitless"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.LengthPerUnitless"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.LengthPerUnitless"/> with <paramref name="right"/> and returns the result.</returns>
        public static LengthPerUnitless operator /(LengthPerUnitless left, double right)
        {
            return new LengthPerUnitless(left.metresPerUnitless / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.LengthPerUnitless"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.LengthPerUnitless"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LengthPerUnitless"/>.</param>
        public static LengthPerUnitless operator +(LengthPerUnitless left, LengthPerUnitless right)
        {
            return new LengthPerUnitless(left.metresPerUnitless + right.metresPerUnitless);
        }

        /// <summary>
        /// Subtracts an LengthPerUnitless from another LengthPerUnitless and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.LengthPerUnitless"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LengthPerUnitless"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LengthPerUnitless"/> (the subtrahend).</param>
        public static LengthPerUnitless operator -(LengthPerUnitless left, LengthPerUnitless right)
        {
            return new LengthPerUnitless(left.metresPerUnitless - right.metresPerUnitless);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.LengthPerUnitless"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.LengthPerUnitless"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="lengthPerUnitless">An instance of <see cref="Gu.Units.LengthPerUnitless"/></param>
        public static LengthPerUnitless operator -(LengthPerUnitless lengthPerUnitless)
        {
            return new LengthPerUnitless(-1 * lengthPerUnitless.metresPerUnitless);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.LengthPerUnitless"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="lengthPerUnitless"/>.
        /// </returns>
        /// <param name="lengthPerUnitless">An instance of <see cref="Gu.Units.LengthPerUnitless"/></param>
        public static LengthPerUnitless operator +(LengthPerUnitless lengthPerUnitless)
        {
            return lengthPerUnitless;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(LengthPerUnitlessUnit unit)
        {
            return unit.FromSiUnit(this.metresPerUnitless);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="LengthPerUnitless"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="LengthPerUnitless"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m/ul\"</param>
        /// <returns>The string representation of the <see cref="LengthPerUnitless"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m/ul\"</param>
        /// <returns>The string representation of the <see cref="LengthPerUnitless"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m/ul</param>
        /// <returns>The string representation of the <see cref="LengthPerUnitless"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m/ul</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="LengthPerUnitless"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(LengthPerUnitlessUnit unit)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(LengthPerUnitlessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(LengthPerUnitlessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(LengthPerUnitlessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, LengthPerUnitlessUnit unit)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, LengthPerUnitlessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, LengthPerUnitlessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, LengthPerUnitlessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthPerUnitlessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<LengthPerUnitlessUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.LengthPerUnitless"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.LengthPerUnitless"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.LengthPerUnitless"/> object to compare to this instance.</param>
        public int CompareTo(LengthPerUnitless quantity)
        {
            return this.metresPerUnitless.CompareTo(quantity.metresPerUnitless);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.LengthPerUnitless"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same LengthPerUnitless as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.LengthPerUnitless"/> object to compare with this instance.</param>
        public bool Equals(LengthPerUnitless other)
        {
            return this.metresPerUnitless.Equals(other.metresPerUnitless);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.LengthPerUnitless"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same LengthPerUnitless as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.LengthPerUnitless"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(LengthPerUnitless other, LengthPerUnitless tolerance)
        {
            Ensure.GreaterThan(tolerance.metresPerUnitless, 0, nameof(tolerance));
            return Math.Abs(this.metresPerUnitless - other.metresPerUnitless) < tolerance.metresPerUnitless;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is LengthPerUnitless && this.Equals((LengthPerUnitless)obj);
        }

        public override int GetHashCode()
        {
            return this.metresPerUnitless.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "metresPerUnitless", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.metresPerUnitless);
        }
    }
}