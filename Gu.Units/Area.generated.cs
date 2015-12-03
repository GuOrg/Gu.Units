namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Area"/>.
    /// </summary>
    // [TypeConverter(typeof(AreaTypeConverter))]
    [Serializable]
    public partial struct Area : IQuantity<AreaUnit>, IComparable<Area>, IEquatable<Area>
    {
        public static readonly Area Zero = new Area();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AreaUnit.SquareMetres"/>.
        /// </summary>
        internal readonly double squareMetres;

        private Area(double squareMetres)
        {
            this.squareMetres = squareMetres;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.AreaUnit"/>.</param>
        public Area(double value, AreaUnit unit)
        {
            this.squareMetres = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AreaUnit.SquareMetres"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.squareMetres;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.AreaUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public AreaUnit SiUnit => AreaUnit.SquareMetres;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => AreaUnit.SquareMetres;

        /// <summary>
        /// The quantity in squareMetres".
        /// </summary>
        public double SquareMetres
        {
            get
            {
                return this.squareMetres;
            }
        }

        /// <summary>
        /// The quantity in squareMillimetres
        /// </summary>
        public double SquareMillimetres
        {
            get
            {
                return AreaUnit.SquareMillimetres.FromSiUnit(this.squareMetres);
            }
        }

        /// <summary>
        /// The quantity in squareCentimetres
        /// </summary>
        public double SquareCentimetres
        {
            get
            {
                return AreaUnit.SquareCentimetres.FromSiUnit(this.squareMetres);
            }
        }

        /// <summary>
        /// The quantity in squareDecimetres
        /// </summary>
        public double SquareDecimetres
        {
            get
            {
                return AreaUnit.SquareDecimetres.FromSiUnit(this.squareMetres);
            }
        }

        /// <summary>
        /// The quantity in squareKilometres
        /// </summary>
        public double SquareKilometres
        {
            get
            {
                return AreaUnit.SquareKilometres.FromSiUnit(this.squareMetres);
            }
        }

        /// <summary>
        /// The quantity in squareInches
        /// </summary>
        public double SquareInches
        {
            get
            {
                return AreaUnit.SquareInches.FromSiUnit(this.squareMetres);
            }
        }

        /// <summary>
        /// The quantity in hectare
        /// </summary>
        public double Hectare
        {
            get
            {
                return AreaUnit.Hectare.FromSiUnit(this.squareMetres);
            }
        }

        /// <summary>
        /// The quantity in squareMile
        /// </summary>
        public double SquareMile
        {
            get
            {
                return AreaUnit.SquareMile.FromSiUnit(this.squareMetres);
            }
        }

        /// <summary>
        /// The quantity in squareYard
        /// </summary>
        public double SquareYard
        {
            get
            {
                return AreaUnit.SquareYard.FromSiUnit(this.squareMetres);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Area"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="Gu.Units.Area"/></param>
        /// <returns></returns>
		public static Area Parse(string s)
        {
            return QuantityParser.Parse<AreaUnit, Area>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static Area Parse(string s, IFormatProvider provider)
        {
            return QuantityParser.Parse<AreaUnit, Area>(s, From, NumberStyles.Float, provider);
        }

        public static Area Parse(string s, NumberStyles styles)
        {
            return QuantityParser.Parse<AreaUnit, Area>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static Area Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<AreaUnit, Area>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out Area value)
        {
            return QuantityParser.TryParse<AreaUnit, Area>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out Area value)
        {
            return QuantityParser.TryParse<AreaUnit, Area>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out Area value)
        {
            return QuantityParser.TryParse<AreaUnit, Area>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out Area value)
        {
            return QuantityParser.TryParse<AreaUnit, Area>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Area"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Area"/></returns>
        public static Area ReadFrom(XmlReader reader)
        {
            var v = new Area();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Area From(double value, AreaUnit unit)
        {
            return new Area(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareMetres">The value in <see cref="Gu.Units.AreaUnit.SquareMetres"/></param>
        public static Area FromSquareMetres(double squareMetres)
        {
            return new Area(squareMetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareMillimetres">The value in mm²</param>
        public static Area FromSquareMillimetres(double squareMillimetres)
        {
            return From(squareMillimetres, AreaUnit.SquareMillimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareCentimetres">The value in cm²</param>
        public static Area FromSquareCentimetres(double squareCentimetres)
        {
            return From(squareCentimetres, AreaUnit.SquareCentimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareDecimetres">The value in dm²</param>
        public static Area FromSquareDecimetres(double squareDecimetres)
        {
            return From(squareDecimetres, AreaUnit.SquareDecimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareKilometres">The value in km²</param>
        public static Area FromSquareKilometres(double squareKilometres)
        {
            return From(squareKilometres, AreaUnit.SquareKilometres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareInches">The value in in²</param>
        public static Area FromSquareInches(double squareInches)
        {
            return From(squareInches, AreaUnit.SquareInches);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="hectare">The value in ha</param>
        public static Area FromHectare(double hectare)
        {
            return From(hectare, AreaUnit.Hectare);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareMile">The value in mi²</param>
        public static Area FromSquareMile(double squareMile)
        {
            return From(squareMile, AreaUnit.SquareMile);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareYard">The value in yd²</param>
        public static Area FromSquareYard(double squareYard)
        {
            return From(squareYard, AreaUnit.SquareYard);
        }

        public static Length operator /(Area left, Length right)
        {
            return Length.FromMetres(left.squareMetres / right.metres);
        }

        public static Volume operator *(Area left, Length right)
        {
            return Volume.FromCubicMetres(left.squareMetres * right.metres);
        }

        public static VolumetricFlow operator *(Area left, Speed right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.squareMetres * right.metresPerSecond);
        }

        public static Flexibility operator /(Area left, Energy right)
        {
            return Flexibility.FromMetresPerNewton(left.squareMetres / right.joules);
        }

        public static double operator /(Area left, Area right)
        {
            return left.squareMetres / right.squareMetres;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Area"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Area"/>.</param>
        public static bool operator ==(Area left, Area right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Area"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Area"/>.</param>
        public static bool operator !=(Area left, Area right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Area"/> is less than another specified <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Area"/>.</param>
        public static bool operator <(Area left, Area right)
        {
            return left.squareMetres < right.squareMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Area"/> is greater than another specified <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Area"/>.</param>
        public static bool operator >(Area left, Area right)
        {
            return left.squareMetres > right.squareMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Area"/> is less than or equal to another specified <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Area"/>.</param>
        public static bool operator <=(Area left, Area right)
        {
            return left.squareMetres <= right.squareMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Area"/> is greater than or equal to another specified <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Area"/>.</param>
        public static bool operator >=(Area left, Area right)
        {
            return left.squareMetres >= right.squareMetres;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Area"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Area"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Area"/> with <paramref name="left"/> and returns the result.</returns>
        public static Area operator *(double left, Area right)
        {
            return new Area(left * right.squareMetres);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Area"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Area"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Area"/> with <paramref name="right"/> and returns the result.</returns>
        public static Area operator *(Area left, double right)
        {
            return new Area(left.squareMetres * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Area"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Area"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Area"/> with <paramref name="right"/> and returns the result.</returns>
        public static Area operator /(Area left, double right)
        {
            return new Area(left.squareMetres / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Area"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Area"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Area"/>.</param>
        public static Area operator +(Area left, Area right)
        {
            return new Area(left.squareMetres + right.squareMetres);
        }

        /// <summary>
        /// Subtracts an Area from another Area and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Area"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Area"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Area"/> (the subtrahend).</param>
        public static Area operator -(Area left, Area right)
        {
            return new Area(left.squareMetres - right.squareMetres);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Area"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Area"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="area">An instance of <see cref="Gu.Units.Area"/></param>
        public static Area operator -(Area area)
        {
            return new Area(-1 * area.squareMetres);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="area"/>.
        /// </returns>
        /// <param name="area">An instance of <see cref="Gu.Units.Area"/></param>
        public static Area operator +(Area area)
        {
            return area;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(AreaUnit unit)
        {
            return unit.FromSiUnit(this.squareMetres);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Area"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Area"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m²\"</param>
        /// <returns>The string representation of the <see cref="Area"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m²\"</param>
        /// <returns>The string representation of the <see cref="Area"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m²</param>
        /// <returns>The string representation of the <see cref="Area"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m²</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Area"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AreaUnit unit)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(AreaUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(AreaUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AreaUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AreaUnit unit)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AreaUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AreaUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AreaUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<AreaUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Area"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Area"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Area"/> object to compare to this instance.</param>
        public int CompareTo(Area quantity)
        {
            return this.squareMetres.CompareTo(quantity.squareMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Area"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Area as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Area"/> object to compare with this instance.</param>
        public bool Equals(Area other)
        {
            return this.squareMetres.Equals(other.squareMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Area"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Area as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Area"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Area other, Area tolerance)
        {
            Ensure.GreaterThan(tolerance.squareMetres, 0, nameof(tolerance));
            return Math.Abs(this.squareMetres - other.squareMetres) < tolerance.squareMetres;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Area && this.Equals((Area)obj);
        }

        public override int GetHashCode()
        {
            return this.squareMetres.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "squareMetres", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.squareMetres);
        }
    }
}