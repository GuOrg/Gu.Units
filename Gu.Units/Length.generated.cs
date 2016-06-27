namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Length"/>.
    /// </summary>
    //[TypeConverter(typeof(LengthTypeConverter))]
    [Serializable]
    public partial struct Length : IQuantity<LengthUnit>, IComparable<Length>, IEquatable<Length>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.LengthUnit.Metres"/>
        /// </summary>
		public static readonly Length Zero = new Length();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.LengthUnit.Metres"/>.
        /// </summary>
        internal readonly double metres;

        private Length(double metres)
        {
            this.metres = metres;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.LengthUnit"/>.</param>
        public Length(double value, LengthUnit unit)
        {
            this.metres = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.LengthUnit.Metres"/>
        /// </summary>
        public double SiValue => this.metres;

        /// <summary>
        /// The <see cref="Gu.Units.LengthUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public LengthUnit SiUnit => LengthUnit.Metres;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => LengthUnit.Metres;

        /// <summary>
        /// The quantity in metres".
        /// </summary>
        public double Metres => this.metres;

        /// <summary>
        /// The quantity in Millimetres
        /// </summary>
        public double Millimetres => 1000 * this.metres;

        /// <summary>
        /// The quantity in Centimetres
        /// </summary>
        public double Centimetres => 100 * this.metres;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <returns>The <see cref="Gu.Units.Length"/> parsed from <paramref name="text"/></returns>
		public static Length Parse(string text)
        {
            return QuantityParser.Parse<LengthUnit, Length>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Length"/> parsed from <paramref name="text"/></returns>
        public static Length Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<LengthUnit, Length>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Length"/> parsed from <paramref name="text"/></returns>
        public static Length Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<LengthUnit, Length>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Length"/> parsed from <paramref name="text"/></returns>
        public static Length Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<LengthUnit, Length>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="result">The parsed <see cref="Length"/></param>
        /// <returns>True if an instance of <see cref="Length"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Length result)
        {
            return QuantityParser.TryParse<LengthUnit, Length>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Length"/></param>
        /// <returns>True if an instance of <see cref="Length"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, IFormatProvider provider, out Length result)
        {
            return QuantityParser.TryParse<LengthUnit, Length>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Length"/></param>
        /// <returns>True if an instance of <see cref="Length"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, NumberStyles styles, out Length result)
        {
            return QuantityParser.TryParse<LengthUnit, Length>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Length"/></param>
        /// <returns>True if an instance of <see cref="Length"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Length result)
        {
            return QuantityParser.TryParse<LengthUnit, Length>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Length"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Length"/></returns>
        public static Length ReadFrom(XmlReader reader)
        {
            var v = new Length();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Length From(double value, LengthUnit unit)
        {
            return new Length(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="metres">The value in <see cref="Gu.Units.LengthUnit.Metres"/></param>
        public static Length FromMetres(double metres)
        {
            return new Length(metres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="millimetres">The value in mm</param>
        public static Length FromMillimetres(double millimetres)
        {
            return new Length(millimetres / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="centimetres">The value in cm</param>
        public static Length FromCentimetres(double centimetres)
        {
            return new Length(centimetres / 100);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Length left, Length right)
        {
            return left.metres / right.metres;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Length"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Length"/>.</param>
        public static bool operator ==(Length left, Length right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Length"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Length"/>.</param>
        public static bool operator !=(Length left, Length right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Length"/> is less than another specified <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Length"/>.</param>
        public static bool operator <(Length left, Length right)
        {
            return left.metres < right.metres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Length"/> is greater than another specified <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Length"/>.</param>
        public static bool operator >(Length left, Length right)
        {
            return left.metres > right.metres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Length"/> is less than or equal to another specified <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Length"/>.</param>
        public static bool operator <=(Length left, Length right)
        {
            return left.metres <= right.metres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Length"/> is greater than or equal to another specified <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Length"/>.</param>
        public static bool operator >=(Length left, Length right)
        {
            return left.metres >= right.metres;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Length"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Length"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Length"/> with <paramref name="left"/> and returns the result.</returns>
        public static Length operator *(double left, Length right)
        {
            return new Length(left * right.metres);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Length"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Length"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Length"/> with <paramref name="right"/> and returns the result.</returns>
        public static Length operator *(Length left, double right)
        {
            return new Length(left.metres * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Length"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Length"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Length"/> with <paramref name="right"/> and returns the result.</returns>
        public static Length operator /(Length left, double right)
        {
            return new Length(left.metres / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Length"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Length"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Length"/>.</param>
        public static Length operator +(Length left, Length right)
        {
            return new Length(left.metres + right.metres);
        }

        /// <summary>
        /// Subtracts an Length from another Length and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Length"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Length"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Length"/> (the subtrahend).</param>
        public static Length operator -(Length left, Length right)
        {
            return new Length(left.metres - right.metres);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Length"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Length"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="length">An instance of <see cref="Gu.Units.Length"/></param>
        public static Length operator -(Length length)
        {
            return new Length(-1 * length.metres);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="length"/>.
        /// </returns>
        /// <param name="length">An instance of <see cref="Gu.Units.Length"/></param>
        public static Length operator +(Length length)
        {
            return length;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(LengthUnit unit)
        {
            return unit.FromSiUnit(this.metres);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m\"</param>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m\"</param>
		/// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Length"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m</param>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(LengthUnit unit)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(LengthUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(LengthUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(LengthUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, LengthUnit unit)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
		public string ToString(string valueFormat, LengthUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, LengthUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>/// 
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, LengthUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<LengthUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Length"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Length"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Length"/> object to compare to this instance.</param>
        public int CompareTo(Length quantity)
        {
            return this.metres.CompareTo(quantity.metres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Length"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Length as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Length"/> object to compare with this instance.</param>
        public bool Equals(Length other)
        {
            return this.metres.Equals(other.metres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Length"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Length as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Length"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Length other, Length tolerance)
        {
            Ensure.GreaterThan(tolerance.metres, 0, nameof(tolerance));
            return Math.Abs(this.metres - other.metres) < tolerance.metres;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Length"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Length"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Length && this.Equals((Length)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.metres.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "metres", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.metres);
        }
    }
}