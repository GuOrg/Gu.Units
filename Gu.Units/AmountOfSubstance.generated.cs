namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.AmountOfSubstance"/>.
    /// </summary>
    [TypeConverter(typeof(AmountOfSubstanceTypeConverter))]
    [Serializable]
    public partial struct AmountOfSubstance : IQuantity<AmountOfSubstanceUnit>, IComparable<AmountOfSubstance>, IEquatable<AmountOfSubstance>
    {
        public static readonly AmountOfSubstance Zero = new AmountOfSubstance();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AmountOfSubstanceUnit.Moles"/>.
        /// </summary>
        internal readonly double moles;

        private AmountOfSubstance(double moles)
        {
            this.moles = moles;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.AmountOfSubstance"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.AmountOfSubstanceUnit"/>.</param>
        public AmountOfSubstance(double value, AmountOfSubstanceUnit unit)
        {
            this.moles = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AmountOfSubstanceUnit.Moles"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.moles;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.AmountOfSubstanceUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public AmountOfSubstanceUnit SiUnit => AmountOfSubstanceUnit.Moles;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => AmountOfSubstanceUnit.Moles;

        /// <summary>
        /// The quantity in moles".
        /// </summary>
        public double Moles
        {
            get
            {
                return this.moles;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AmountOfSubstance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AmountOfSubstance"/></param>
        /// <returns></returns>
		public static AmountOfSubstance Parse(string text)
        {
            return QuantityParser.Parse<AmountOfSubstanceUnit, AmountOfSubstance>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AmountOfSubstance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AmountOfSubstance"/></param>
        /// <returns></returns>
        public static AmountOfSubstance Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<AmountOfSubstanceUnit, AmountOfSubstance>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AmountOfSubstance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AmountOfSubstance"/></param>
        /// <returns></returns>
        public static AmountOfSubstance Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<AmountOfSubstanceUnit, AmountOfSubstance>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AmountOfSubstance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AmountOfSubstance"/></param>
        /// <returns></returns>
        public static AmountOfSubstance Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<AmountOfSubstanceUnit, AmountOfSubstance>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AmountOfSubstance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AmountOfSubstance"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out AmountOfSubstance result)
        {
            return QuantityParser.TryParse<AmountOfSubstanceUnit, AmountOfSubstance>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AmountOfSubstance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AmountOfSubstance"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out AmountOfSubstance result)
        {
            return QuantityParser.TryParse<AmountOfSubstanceUnit, AmountOfSubstance>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AmountOfSubstance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AmountOfSubstance"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out AmountOfSubstance result)
        {
            return QuantityParser.TryParse<AmountOfSubstanceUnit, AmountOfSubstance>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AmountOfSubstance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AmountOfSubstance"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out AmountOfSubstance result)
        {
            return QuantityParser.TryParse<AmountOfSubstanceUnit, AmountOfSubstance>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.AmountOfSubstance"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.AmountOfSubstance"/></returns>
        public static AmountOfSubstance ReadFrom(XmlReader reader)
        {
            var v = new AmountOfSubstance();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AmountOfSubstance"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static AmountOfSubstance From(double value, AmountOfSubstanceUnit unit)
        {
            return new AmountOfSubstance(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AmountOfSubstance"/>.
        /// </summary>
        /// <param name="moles">The value in <see cref="Gu.Units.AmountOfSubstanceUnit.Moles"/></param>
        public static AmountOfSubstance FromMoles(double moles)
        {
            return new AmountOfSubstance(moles);
        }

        public static CatalyticActivity operator /(AmountOfSubstance left, Time right)
        {
            return CatalyticActivity.FromKatals(left.moles / right.seconds);
        }

        public static CatalyticActivity operator *(AmountOfSubstance left, Frequency right)
        {
            return CatalyticActivity.FromKatals(left.moles * right.hertz);
        }

        public static Time operator /(AmountOfSubstance left, CatalyticActivity right)
        {
            return Time.FromSeconds(left.moles / right.katals);
        }

        public static double operator /(AmountOfSubstance left, AmountOfSubstance right)
        {
            return left.moles / right.moles;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AmountOfSubstance"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        public static bool operator ==(AmountOfSubstance left, AmountOfSubstance right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AmountOfSubstance"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        public static bool operator !=(AmountOfSubstance left, AmountOfSubstance right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AmountOfSubstance"/> is less than another specified <see cref="Gu.Units.AmountOfSubstance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        public static bool operator <(AmountOfSubstance left, AmountOfSubstance right)
        {
            return left.moles < right.moles;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AmountOfSubstance"/> is greater than another specified <see cref="Gu.Units.AmountOfSubstance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        public static bool operator >(AmountOfSubstance left, AmountOfSubstance right)
        {
            return left.moles > right.moles;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AmountOfSubstance"/> is less than or equal to another specified <see cref="Gu.Units.AmountOfSubstance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        public static bool operator <=(AmountOfSubstance left, AmountOfSubstance right)
        {
            return left.moles <= right.moles;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AmountOfSubstance"/> is greater than or equal to another specified <see cref="Gu.Units.AmountOfSubstance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        public static bool operator >=(AmountOfSubstance left, AmountOfSubstance right)
        {
            return left.moles >= right.moles;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AmountOfSubstance"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.AmountOfSubstance"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.AmountOfSubstance"/> with <paramref name="left"/> and returns the result.</returns>
        public static AmountOfSubstance operator *(double left, AmountOfSubstance right)
        {
            return new AmountOfSubstance(left * right.moles);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AmountOfSubstance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.AmountOfSubstance"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.AmountOfSubstance"/> with <paramref name="right"/> and returns the result.</returns>
        public static AmountOfSubstance operator *(AmountOfSubstance left, double right)
        {
            return new AmountOfSubstance(left.moles * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.AmountOfSubstance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.AmountOfSubstance"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.AmountOfSubstance"/> with <paramref name="right"/> and returns the result.</returns>
        public static AmountOfSubstance operator /(AmountOfSubstance left, double right)
        {
            return new AmountOfSubstance(left.moles / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.AmountOfSubstance"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AmountOfSubstance"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AmountOfSubstance"/>.</param>
        public static AmountOfSubstance operator +(AmountOfSubstance left, AmountOfSubstance right)
        {
            return new AmountOfSubstance(left.moles + right.moles);
        }

        /// <summary>
        /// Subtracts an AmountOfSubstance from another AmountOfSubstance and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AmountOfSubstance"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AmountOfSubstance"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AmountOfSubstance"/> (the subtrahend).</param>
        public static AmountOfSubstance operator -(AmountOfSubstance left, AmountOfSubstance right)
        {
            return new AmountOfSubstance(left.moles - right.moles);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.AmountOfSubstance"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AmountOfSubstance"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="amountOfSubstance">An instance of <see cref="Gu.Units.AmountOfSubstance"/></param>
        public static AmountOfSubstance operator -(AmountOfSubstance amountOfSubstance)
        {
            return new AmountOfSubstance(-1 * amountOfSubstance.moles);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.AmountOfSubstance"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="amountOfSubstance"/>.
        /// </returns>
        /// <param name="amountOfSubstance">An instance of <see cref="Gu.Units.AmountOfSubstance"/></param>
        public static AmountOfSubstance operator +(AmountOfSubstance amountOfSubstance)
        {
            return amountOfSubstance;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(AmountOfSubstanceUnit unit)
        {
            return unit.FromSiUnit(this.moles);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="AmountOfSubstance"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="AmountOfSubstance"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 mol\"</param>
        /// <returns>The string representation of the <see cref="AmountOfSubstance"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 mol\"</param>
        /// <returns>The string representation of the <see cref="AmountOfSubstance"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex mol</param>
        /// <returns>The string representation of the <see cref="AmountOfSubstance"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex mol</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="AmountOfSubstance"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AmountOfSubstanceUnit unit)
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(AmountOfSubstanceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(AmountOfSubstanceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AmountOfSubstanceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AmountOfSubstanceUnit unit)
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AmountOfSubstanceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AmountOfSubstanceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AmountOfSubstanceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<AmountOfSubstanceUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.AmountOfSubstance"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.AmountOfSubstance"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.AmountOfSubstance"/> object to compare to this instance.</param>
        public int CompareTo(AmountOfSubstance quantity)
        {
            return this.moles.CompareTo(quantity.moles);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AmountOfSubstance"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AmountOfSubstance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.AmountOfSubstance"/> object to compare with this instance.</param>
        public bool Equals(AmountOfSubstance other)
        {
            return this.moles.Equals(other.moles);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AmountOfSubstance"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AmountOfSubstance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.AmountOfSubstance"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(AmountOfSubstance other, AmountOfSubstance tolerance)
        {
            Ensure.GreaterThan(tolerance.moles, 0, nameof(tolerance));
            return Math.Abs(this.moles - other.moles) < tolerance.moles;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AmountOfSubstance && this.Equals((AmountOfSubstance)obj);
        }

        public override int GetHashCode()
        {
            return this.moles.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "moles", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.moles);
        }
    }
}