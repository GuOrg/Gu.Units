namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Data"/>.
    /// </summary>
    // [TypeConverter(typeof(DataTypeConverter))]
    [Serializable]
    public partial struct Data : IQuantity<DataUnit>, IComparable<Data>, IEquatable<Data>
    {
        public static readonly Data Zero = new Data();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.DataUnit.Bits"/>.
        /// </summary>
        internal readonly double bits;

        private Data(double bits)
        {
            this.bits = bits;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.DataUnit"/>.</param>
        public Data(double value, DataUnit unit)
        {
            this.bits = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.DataUnit.Bits"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.bits;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.DataUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public DataUnit SiUnit => DataUnit.Bits;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => DataUnit.Bits;

        /// <summary>
        /// The quantity in bits".
        /// </summary>
        public double Bits
        {
            get
            {
                return this.bits;
            }
        }

        /// <summary>
        /// The quantity in Byte
        /// </summary>
        public double Byte => this.bits / 8;

        /// <summary>
        /// The quantity in Kilobyte
        /// </summary>
        public double Kilobyte => this.bits / 8000;

        /// <summary>
        /// The quantity in Megabyte
        /// </summary>
        public double Megabyte => this.bits / 8000000;

        /// <summary>
        /// The quantity in Gigabyte
        /// </summary>
        public double Gigabyte => this.bits / 8000000000;

        /// <summary>
        /// The quantity in Terabyte
        /// </summary>
        public double Terabyte => this.bits / 8000000000000;

        /// <summary>
        /// The quantity in Megabits
        /// </summary>
        public double Megabits => this.bits / 1000000;

        /// <summary>
        /// The quantity in Gigabits
        /// </summary>
        public double Gigabits => this.bits / 1000000000;

        /// <summary>
        /// The quantity in Kilobits
        /// </summary>
        public double Kilobits => this.bits / 1000;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Data"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Data"/></param>
        /// <returns></returns>
		public static Data Parse(string text)
        {
            return QuantityParser.Parse<DataUnit, Data>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Data"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Data"/></param>
        /// <returns></returns>
        public static Data Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<DataUnit, Data>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Data"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Data"/></param>
        /// <returns></returns>
        public static Data Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<DataUnit, Data>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Data"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Data"/></param>
        /// <returns></returns>
        public static Data Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<DataUnit, Data>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Data"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Data"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out Data result)
        {
            return QuantityParser.TryParse<DataUnit, Data>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Data"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Data"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out Data result)
        {
            return QuantityParser.TryParse<DataUnit, Data>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Data"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Data"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out Data result)
        {
            return QuantityParser.TryParse<DataUnit, Data>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Data"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Data"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Data result)
        {
            return QuantityParser.TryParse<DataUnit, Data>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Data"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Data"/></returns>
        public static Data ReadFrom(XmlReader reader)
        {
            var v = new Data();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Data From(double value, DataUnit unit)
        {
            return new Data(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <param name="bits">The value in <see cref="Gu.Units.DataUnit.Bits"/></param>
        public static Data FromBits(double bits)
        {
            return new Data(bits);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <param name="@byte">The value in B</param>
        public static Data FromByte(double @byte)
        {
            return new Data(8 * @byte);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <param name="kilobyte">The value in kB</param>
        public static Data FromKilobyte(double kilobyte)
        {
            return new Data(8000 * kilobyte);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <param name="megabyte">The value in MB</param>
        public static Data FromMegabyte(double megabyte)
        {
            return new Data(8000000 * megabyte);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <param name="gigabyte">The value in GB</param>
        public static Data FromGigabyte(double gigabyte)
        {
            return new Data(8000000000 * gigabyte);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <param name="terabyte">The value in TB</param>
        public static Data FromTerabyte(double terabyte)
        {
            return new Data(8000000000000 * terabyte);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <param name="megabits">The value in Mbit</param>
        public static Data FromMegabits(double megabits)
        {
            return new Data(1000000 * megabits);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <param name="gigabits">The value in Gbit</param>
        public static Data FromGigabits(double gigabits)
        {
            return new Data(1000000000 * gigabits);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <param name="kilobits">The value in kbit</param>
        public static Data FromKilobits(double kilobits)
        {
            return new Data(1000 * kilobits);
        }

        public static double operator /(Data left, Data right)
        {
            return left.bits / right.bits;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Data"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Data"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Data"/>.</param>
        public static bool operator ==(Data left, Data right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Data"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Data"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Data"/>.</param>
        public static bool operator !=(Data left, Data right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Data"/> is less than another specified <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Data"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Data"/>.</param>
        public static bool operator <(Data left, Data right)
        {
            return left.bits < right.bits;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Data"/> is greater than another specified <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Data"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Data"/>.</param>
        public static bool operator >(Data left, Data right)
        {
            return left.bits > right.bits;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Data"/> is less than or equal to another specified <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Data"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Data"/>.</param>
        public static bool operator <=(Data left, Data right)
        {
            return left.bits <= right.bits;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Data"/> is greater than or equal to another specified <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Data"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Data"/>.</param>
        public static bool operator >=(Data left, Data right)
        {
            return left.bits >= right.bits;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Data"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Data"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Data"/> with <paramref name="left"/> and returns the result.</returns>
        public static Data operator *(double left, Data right)
        {
            return new Data(left * right.bits);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Data"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Data"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Data"/> with <paramref name="right"/> and returns the result.</returns>
        public static Data operator *(Data left, double right)
        {
            return new Data(left.bits * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Data"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Data"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Data"/> with <paramref name="right"/> and returns the result.</returns>
        public static Data operator /(Data left, double right)
        {
            return new Data(left.bits / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Data"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Data"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Data"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Data"/>.</param>
        public static Data operator +(Data left, Data right)
        {
            return new Data(left.bits + right.bits);
        }

        /// <summary>
        /// Subtracts an Data from another Data and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Data"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Data"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Data"/> (the subtrahend).</param>
        public static Data operator -(Data left, Data right)
        {
            return new Data(left.bits - right.bits);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Data"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Data"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="data">An instance of <see cref="Gu.Units.Data"/></param>
        public static Data operator -(Data data)
        {
            return new Data(-1 * data.bits);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Data"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="data"/>.
        /// </returns>
        /// <param name="data">An instance of <see cref="Gu.Units.Data"/></param>
        public static Data operator +(Data data)
        {
            return data;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(DataUnit unit)
        {
            return unit.FromSiUnit(this.bits);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Data"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Data"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 bit\"</param>
        /// <returns>The string representation of the <see cref="Data"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 bit\"</param>
        /// <returns>The string representation of the <see cref="Data"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex bit</param>
        /// <returns>The string representation of the <see cref="Data"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex bit</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Data"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(DataUnit unit)
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(DataUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(DataUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(DataUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, DataUnit unit)
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, DataUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, DataUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, DataUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<DataUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<DataUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Data"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Data"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Data"/> object to compare to this instance.</param>
        public int CompareTo(Data quantity)
        {
            return this.bits.CompareTo(quantity.bits);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Data"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Data as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Data"/> object to compare with this instance.</param>
        public bool Equals(Data other)
        {
            return this.bits.Equals(other.bits);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Data"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Data as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Data"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Data other, Data tolerance)
        {
            Ensure.GreaterThan(tolerance.bits, 0, nameof(tolerance));
            return Math.Abs(this.bits - other.bits) < tolerance.bits;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Data && this.Equals((Data)obj);
        }

        public override int GetHashCode()
        {
            return this.bits.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "bits", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.bits);
        }
    }
}