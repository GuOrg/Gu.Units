namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.CatalyticActivity"/>.
    /// </summary>
    // [TypeConverter(typeof(CatalyticActivityTypeConverter))]
    [Serializable]
    public partial struct CatalyticActivity : IQuantity<CatalyticActivityUnit>, IComparable<CatalyticActivity>, IEquatable<CatalyticActivity>
    {
        public static readonly CatalyticActivity Zero = new CatalyticActivity();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.CatalyticActivityUnit.Katals"/>.
        /// </summary>
        internal readonly double katals;

        private CatalyticActivity(double katals)
        {
            this.katals = katals;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.CatalyticActivity"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.CatalyticActivityUnit"/>.</param>
        public CatalyticActivity(double value, CatalyticActivityUnit unit)
        {
            this.katals = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.CatalyticActivityUnit.Katals"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.katals;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.CatalyticActivityUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public CatalyticActivityUnit SiUnit => CatalyticActivityUnit.Katals;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => CatalyticActivityUnit.Katals;

        /// <summary>
        /// The quantity in katals".
        /// </summary>
        public double Katals
        {
            get
            {
                return this.katals;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.CatalyticActivity"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="Gu.Units.CatalyticActivity"/></param>
        /// <returns></returns>
		public static CatalyticActivity Parse(string s)
        {
            return QuantityParser.Parse<CatalyticActivityUnit, CatalyticActivity>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static CatalyticActivity Parse(string s, IFormatProvider provider)
        {
            return QuantityParser.Parse<CatalyticActivityUnit, CatalyticActivity>(s, From, NumberStyles.Float, provider);
        }

        public static CatalyticActivity Parse(string s, NumberStyles styles)
        {
            return QuantityParser.Parse<CatalyticActivityUnit, CatalyticActivity>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static CatalyticActivity Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<CatalyticActivityUnit, CatalyticActivity>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out CatalyticActivity value)
        {
            return QuantityParser.TryParse<CatalyticActivityUnit, CatalyticActivity>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out CatalyticActivity value)
        {
            return QuantityParser.TryParse<CatalyticActivityUnit, CatalyticActivity>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out CatalyticActivity value)
        {
            return QuantityParser.TryParse<CatalyticActivityUnit, CatalyticActivity>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out CatalyticActivity value)
        {
            return QuantityParser.TryParse<CatalyticActivityUnit, CatalyticActivity>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.CatalyticActivity"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.CatalyticActivity"/></returns>
        public static CatalyticActivity ReadFrom(XmlReader reader)
        {
            var v = new CatalyticActivity();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.CatalyticActivity"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static CatalyticActivity From(double value, CatalyticActivityUnit unit)
        {
            return new CatalyticActivity(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.CatalyticActivity"/>.
        /// </summary>
        /// <param name="katals">The value in <see cref="Gu.Units.CatalyticActivityUnit.Katals"/></param>
        public static CatalyticActivity FromKatals(double katals)
        {
            return new CatalyticActivity(katals);
        }

        public static AmountOfSubstance operator *(CatalyticActivity left, Time right)
        {
            return AmountOfSubstance.FromMoles(left.katals * right.seconds);
        }

        public static Frequency operator /(CatalyticActivity left, AmountOfSubstance right)
        {
            return Frequency.FromHertz(left.katals / right.moles);
        }

        public static AmountOfSubstance operator /(CatalyticActivity left, Frequency right)
        {
            return AmountOfSubstance.FromMoles(left.katals / right.hertz);
        }

        public static double operator /(CatalyticActivity left, CatalyticActivity right)
        {
            return left.katals / right.katals;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.CatalyticActivity"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        public static bool operator ==(CatalyticActivity left, CatalyticActivity right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.CatalyticActivity"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        public static bool operator !=(CatalyticActivity left, CatalyticActivity right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.CatalyticActivity"/> is less than another specified <see cref="Gu.Units.CatalyticActivity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        public static bool operator <(CatalyticActivity left, CatalyticActivity right)
        {
            return left.katals < right.katals;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.CatalyticActivity"/> is greater than another specified <see cref="Gu.Units.CatalyticActivity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        public static bool operator >(CatalyticActivity left, CatalyticActivity right)
        {
            return left.katals > right.katals;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.CatalyticActivity"/> is less than or equal to another specified <see cref="Gu.Units.CatalyticActivity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        public static bool operator <=(CatalyticActivity left, CatalyticActivity right)
        {
            return left.katals <= right.katals;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.CatalyticActivity"/> is greater than or equal to another specified <see cref="Gu.Units.CatalyticActivity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        public static bool operator >=(CatalyticActivity left, CatalyticActivity right)
        {
            return left.katals >= right.katals;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.CatalyticActivity"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.CatalyticActivity"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.CatalyticActivity"/> with <paramref name="left"/> and returns the result.</returns>
        public static CatalyticActivity operator *(double left, CatalyticActivity right)
        {
            return new CatalyticActivity(left * right.katals);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.CatalyticActivity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.CatalyticActivity"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.CatalyticActivity"/> with <paramref name="right"/> and returns the result.</returns>
        public static CatalyticActivity operator *(CatalyticActivity left, double right)
        {
            return new CatalyticActivity(left.katals * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.CatalyticActivity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.CatalyticActivity"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.CatalyticActivity"/> with <paramref name="right"/> and returns the result.</returns>
        public static CatalyticActivity operator /(CatalyticActivity left, double right)
        {
            return new CatalyticActivity(left.katals / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.CatalyticActivity"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.CatalyticActivity"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.CatalyticActivity"/>.</param>
        public static CatalyticActivity operator +(CatalyticActivity left, CatalyticActivity right)
        {
            return new CatalyticActivity(left.katals + right.katals);
        }

        /// <summary>
        /// Subtracts an CatalyticActivity from another CatalyticActivity and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.CatalyticActivity"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.CatalyticActivity"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.CatalyticActivity"/> (the subtrahend).</param>
        public static CatalyticActivity operator -(CatalyticActivity left, CatalyticActivity right)
        {
            return new CatalyticActivity(left.katals - right.katals);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.CatalyticActivity"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.CatalyticActivity"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="catalyticActivity">An instance of <see cref="Gu.Units.CatalyticActivity"/></param>
        public static CatalyticActivity operator -(CatalyticActivity catalyticActivity)
        {
            return new CatalyticActivity(-1 * catalyticActivity.katals);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.CatalyticActivity"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="catalyticActivity"/>.
        /// </returns>
        /// <param name="catalyticActivity">An instance of <see cref="Gu.Units.CatalyticActivity"/></param>
        public static CatalyticActivity operator +(CatalyticActivity catalyticActivity)
        {
            return catalyticActivity;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(CatalyticActivityUnit unit)
        {
            return unit.FromSiUnit(this.katals);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="CatalyticActivity"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="CatalyticActivity"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kat\"</param>
        /// <returns>The string representation of the <see cref="CatalyticActivity"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kat\"</param>
        /// <returns>The string representation of the <see cref="CatalyticActivity"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex kat</param>
        /// <returns>The string representation of the <see cref="CatalyticActivity"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex kat</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="CatalyticActivity"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(CatalyticActivityUnit unit)
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(CatalyticActivityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(CatalyticActivityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(CatalyticActivityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, CatalyticActivityUnit unit)
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, CatalyticActivityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, CatalyticActivityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, CatalyticActivityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CatalyticActivityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<CatalyticActivityUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.CatalyticActivity"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.CatalyticActivity"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.CatalyticActivity"/> object to compare to this instance.</param>
        public int CompareTo(CatalyticActivity quantity)
        {
            return this.katals.CompareTo(quantity.katals);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.CatalyticActivity"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same CatalyticActivity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.CatalyticActivity"/> object to compare with this instance.</param>
        public bool Equals(CatalyticActivity other)
        {
            return this.katals.Equals(other.katals);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.CatalyticActivity"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same CatalyticActivity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.CatalyticActivity"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(CatalyticActivity other, CatalyticActivity tolerance)
        {
            Ensure.GreaterThan(tolerance.katals, 0, nameof(tolerance));
            return Math.Abs(this.katals - other.katals) < tolerance.katals;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is CatalyticActivity && this.Equals((CatalyticActivity)obj);
        }

        public override int GetHashCode()
        {
            return this.katals.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "katals", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.katals);
        }
    }
}