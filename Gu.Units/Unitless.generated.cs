namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Unitless"/>.
    /// </summary>
    // [TypeConverter(typeof(UnitlessTypeConverter))]
    [Serializable]
    public partial struct Unitless : IQuantity<UnitlessUnit>, IComparable<Unitless>, IEquatable<Unitless>
    {
        public static readonly Unitless Zero = new Unitless();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.UnitlessUnit.Scalar"/>.
        /// </summary>
        internal readonly double scalar;

        private Unitless(double scalar)
        {
            this.scalar = scalar;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Unitless"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.UnitlessUnit"/>.</param>
        public Unitless(double value, UnitlessUnit unit)
        {
            this.scalar = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.UnitlessUnit.Scalar"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.scalar;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.UnitlessUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public UnitlessUnit SiUnit => UnitlessUnit.Scalar;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => UnitlessUnit.Scalar;

        /// <summary>
        /// The quantity in scalar".
        /// </summary>
        public double Scalar
        {
            get
            {
                return this.scalar;
            }
        }

        /// <summary>
        /// The quantity in Promilles
        /// </summary>
        public double Promilles => 1000 * this.scalar;

        /// <summary>
        /// The quantity in PartsPerMillion
        /// </summary>
        public double PartsPerMillion => 1000000 * this.scalar;

        /// <summary>
        /// The quantity in Percents
        /// </summary>
        public double Percents => 100 * this.scalar;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Unitless"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="Gu.Units.Unitless"/></param>
        /// <returns></returns>
		public static Unitless Parse(string s)
        {
            return QuantityParser.Parse<UnitlessUnit, Unitless>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static Unitless Parse(string s, IFormatProvider provider)
        {
            return QuantityParser.Parse<UnitlessUnit, Unitless>(s, From, NumberStyles.Float, provider);
        }

        public static Unitless Parse(string s, NumberStyles styles)
        {
            return QuantityParser.Parse<UnitlessUnit, Unitless>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static Unitless Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<UnitlessUnit, Unitless>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out Unitless value)
        {
            return QuantityParser.TryParse<UnitlessUnit, Unitless>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out Unitless value)
        {
            return QuantityParser.TryParse<UnitlessUnit, Unitless>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out Unitless value)
        {
            return QuantityParser.TryParse<UnitlessUnit, Unitless>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out Unitless value)
        {
            return QuantityParser.TryParse<UnitlessUnit, Unitless>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Unitless"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Unitless"/></returns>
        public static Unitless ReadFrom(XmlReader reader)
        {
            var v = new Unitless();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Unitless"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Unitless From(double value, UnitlessUnit unit)
        {
            return new Unitless(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Unitless"/>.
        /// </summary>
        /// <param name="scalar">The value in <see cref="Gu.Units.UnitlessUnit.Scalar"/></param>
        public static Unitless FromScalar(double scalar)
        {
            return new Unitless(scalar);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Unitless"/>.
        /// </summary>
        /// <param name="promilles">The value in ‰</param>
        public static Unitless FromPromilles(double promilles)
        {
            return new Unitless(promilles / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Unitless"/>.
        /// </summary>
        /// <param name="partsPerMillion">The value in ppm</param>
        public static Unitless FromPartsPerMillion(double partsPerMillion)
        {
            return new Unitless(partsPerMillion / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Unitless"/>.
        /// </summary>
        /// <param name="percents">The value in %</param>
        public static Unitless FromPercents(double percents)
        {
            return new Unitless(percents / 100);
        }

        public static Length operator *(Unitless left, LengthPerUnitless right)
        {
            return Length.FromMetres(left.scalar * right.metresPerUnitless);
        }

        public static Angle operator *(Unitless left, AnglePerUnitless right)
        {
            return Angle.FromRadians(left.scalar * right.radiansPerUnitless);
        }

        public static Force operator *(Unitless left, ForcePerUnitless right)
        {
            return Force.FromNewtons(left.scalar * right.newtonsPerUnitless);
        }

        public static double operator /(Unitless left, Unitless right)
        {
            return left.scalar / right.scalar;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Unitless"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        public static bool operator ==(Unitless left, Unitless right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Unitless"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        public static bool operator !=(Unitless left, Unitless right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Unitless"/> is less than another specified <see cref="Gu.Units.Unitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        public static bool operator <(Unitless left, Unitless right)
        {
            return left.scalar < right.scalar;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Unitless"/> is greater than another specified <see cref="Gu.Units.Unitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        public static bool operator >(Unitless left, Unitless right)
        {
            return left.scalar > right.scalar;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Unitless"/> is less than or equal to another specified <see cref="Gu.Units.Unitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        public static bool operator <=(Unitless left, Unitless right)
        {
            return left.scalar <= right.scalar;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Unitless"/> is greater than or equal to another specified <see cref="Gu.Units.Unitless"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        public static bool operator >=(Unitless left, Unitless right)
        {
            return left.scalar >= right.scalar;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Unitless"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Unitless"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Unitless"/> with <paramref name="left"/> and returns the result.</returns>
        public static Unitless operator *(double left, Unitless right)
        {
            return new Unitless(left * right.scalar);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Unitless"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Unitless"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Unitless"/> with <paramref name="right"/> and returns the result.</returns>
        public static Unitless operator *(Unitless left, double right)
        {
            return new Unitless(left.scalar * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Unitless"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Unitless"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Unitless"/> with <paramref name="right"/> and returns the result.</returns>
        public static Unitless operator /(Unitless left, double right)
        {
            return new Unitless(left.scalar / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Unitless"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Unitless"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Unitless"/>.</param>
        public static Unitless operator +(Unitless left, Unitless right)
        {
            return new Unitless(left.scalar + right.scalar);
        }

        /// <summary>
        /// Subtracts an Unitless from another Unitless and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Unitless"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Unitless"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Unitless"/> (the subtrahend).</param>
        public static Unitless operator -(Unitless left, Unitless right)
        {
            return new Unitless(left.scalar - right.scalar);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Unitless"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Unitless"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="unitless">An instance of <see cref="Gu.Units.Unitless"/></param>
        public static Unitless operator -(Unitless unitless)
        {
            return new Unitless(-1 * unitless.scalar);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Unitless"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="unitless"/>.
        /// </returns>
        /// <param name="unitless">An instance of <see cref="Gu.Units.Unitless"/></param>
        public static Unitless operator +(Unitless unitless)
        {
            return unitless;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(UnitlessUnit unit)
        {
            return unit.FromSiUnit(this.scalar);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Unitless"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Unitless"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 ul\"</param>
        /// <returns>The string representation of the <see cref="Unitless"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 ul\"</param>
        /// <returns>The string representation of the <see cref="Unitless"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex ul</param>
        /// <returns>The string representation of the <see cref="Unitless"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex ul</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Unitless"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(UnitlessUnit unit)
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(UnitlessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(UnitlessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(UnitlessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, UnitlessUnit unit)
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, UnitlessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, UnitlessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, UnitlessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<UnitlessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<UnitlessUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Unitless"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Unitless"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Unitless"/> object to compare to this instance.</param>
        public int CompareTo(Unitless quantity)
        {
            return this.scalar.CompareTo(quantity.scalar);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Unitless"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Unitless as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Unitless"/> object to compare with this instance.</param>
        public bool Equals(Unitless other)
        {
            return this.scalar.Equals(other.scalar);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Unitless"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Unitless as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Unitless"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Unitless other, Unitless tolerance)
        {
            Ensure.GreaterThan(tolerance.scalar, 0, nameof(tolerance));
            return Math.Abs(this.scalar - other.scalar) < tolerance.scalar;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Unitless && this.Equals((Unitless)obj);
        }

        public override int GetHashCode()
        {
            return this.scalar.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "scalar", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.scalar);
        }
    }
}