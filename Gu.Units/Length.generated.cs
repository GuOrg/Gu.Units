namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Length"/>.
    /// </summary>
    // [TypeConverter(typeof(LengthTypeConverter))]
    [Serializable]
    public partial struct Length : IQuantity<LengthUnit>, IComparable<Length>, IEquatable<Length>
    {
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
        public double SiValue
        {
            get
            {
                return this.metres;
            }
        }

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
        public double Metres
        {
            get
            {
                return this.metres;
            }
        }

        /// <summary>
        /// The quantity in nanometres
        /// </summary>
        public double Nanometres
        {
            get
            {
                return LengthUnit.Nanometres.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in micrometres
        /// </summary>
        public double Micrometres
        {
            get
            {
                return LengthUnit.Micrometres.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in millimetres
        /// </summary>
        public double Millimetres
        {
            get
            {
                return LengthUnit.Millimetres.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in centimetres
        /// </summary>
        public double Centimetres
        {
            get
            {
                return LengthUnit.Centimetres.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in decimetres
        /// </summary>
        public double Decimetres
        {
            get
            {
                return LengthUnit.Decimetres.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in kilometres
        /// </summary>
        public double Kilometres
        {
            get
            {
                return LengthUnit.Kilometres.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in inches
        /// </summary>
        public double Inches
        {
            get
            {
                return LengthUnit.Inches.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in mile
        /// </summary>
        public double Mile
        {
            get
            {
                return LengthUnit.Mile.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in yard
        /// </summary>
        public double Yard
        {
            get
            {
                return LengthUnit.Yard.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in nauticalMile
        /// </summary>
        public double NauticalMile
        {
            get
            {
                return LengthUnit.NauticalMile.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <returns></returns>
		public static Length Parse(string s)
        {
            return QuantityParser.Parse<LengthUnit, Length>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static Length Parse(string s, IFormatProvider provider)
        {
            return QuantityParser.Parse<LengthUnit, Length>(s, From, NumberStyles.Float, provider);
        }

        public static Length Parse(string s, NumberStyles styles)
        {
            return QuantityParser.Parse<LengthUnit, Length>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static Length Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<LengthUnit, Length>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out Length value)
        {
            return QuantityParser.TryParse<LengthUnit, Length>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out Length value)
        {
            return QuantityParser.TryParse<LengthUnit, Length>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out Length value)
        {
            return QuantityParser.TryParse<LengthUnit, Length>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out Length value)
        {
            return QuantityParser.TryParse<LengthUnit, Length>(s, From, styles, provider, out value);
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
        /// <param name="nanometres">The value in nm</param>
        public static Length FromNanometres(double nanometres)
        {
            return From(nanometres, LengthUnit.Nanometres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="micrometres">The value in µm</param>
        public static Length FromMicrometres(double micrometres)
        {
            return From(micrometres, LengthUnit.Micrometres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="millimetres">The value in mm</param>
        public static Length FromMillimetres(double millimetres)
        {
            return From(millimetres, LengthUnit.Millimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="centimetres">The value in cm</param>
        public static Length FromCentimetres(double centimetres)
        {
            return From(centimetres, LengthUnit.Centimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="decimetres">The value in dm</param>
        public static Length FromDecimetres(double decimetres)
        {
            return From(decimetres, LengthUnit.Decimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="kilometres">The value in km</param>
        public static Length FromKilometres(double kilometres)
        {
            return From(kilometres, LengthUnit.Kilometres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="inches">The value in in</param>
        public static Length FromInches(double inches)
        {
            return From(inches, LengthUnit.Inches);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="mile">The value in mi</param>
        public static Length FromMile(double mile)
        {
            return From(mile, LengthUnit.Mile);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="yard">The value in yd</param>
        public static Length FromYard(double yard)
        {
            return From(yard, LengthUnit.Yard);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="nauticalMile">The value in nmi</param>
        public static Length FromNauticalMile(double nauticalMile)
        {
            return From(nauticalMile, LengthUnit.NauticalMile);
        }

        public static Time operator /(Length left, Speed right)
        {
            return Time.FromSeconds(left.metres / right.metresPerSecond);
        }

        public static Unitless operator /(Length left, LengthPerUnitless right)
        {
            return Unitless.FromScalar(left.metres / right.metresPerUnitless);
        }

        public static Area operator *(Length left, Length right)
        {
            return Area.FromSquareMetres(left.metres * right.metres);
        }

        public static Volume operator *(Length left, Area right)
        {
            return Volume.FromCubicMetres(left.metres * right.squareMetres);
        }

        public static Energy operator *(Length left, Force right)
        {
            return Energy.FromJoules(left.metres * right.newtons);
        }

        public static Speed operator /(Length left, Time right)
        {
            return Speed.FromMetresPerSecond(left.metres / right.seconds);
        }

        public static SpecificEnergy operator *(Length left, Acceleration right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.metres * right.metresPerSecondSquared);
        }

        public static Flexibility operator /(Length left, Force right)
        {
            return Flexibility.FromMetresPerNewton(left.metres / right.newtons);
        }

        public static LengthPerUnitless operator /(Length left, Unitless right)
        {
            return LengthPerUnitless.FromMetresPerUnitless(left.metres / right.scalar);
        }

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

        public string ToString(LengthUnit unit)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(LengthUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(LengthUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(LengthUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, LengthUnit unit)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, LengthUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, LengthUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

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
        /// Compares this instance to a specified <see cref="Gu.Units.Length"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Length"/> object.
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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Length && this.Equals((Length)obj);
        }

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