namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.ElectricalConductance"/>.
    /// </summary>
    [TypeConverter(typeof(ElectricalConductanceTypeConverter))]
    [Serializable]
    public partial struct ElectricalConductance : IQuantity<ElectricalConductanceUnit>, IComparable<ElectricalConductance>, IEquatable<ElectricalConductance>
    {
        public static readonly ElectricalConductance Zero = new ElectricalConductance();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.ElectricalConductanceUnit.Siemens"/>.
        /// </summary>
        internal readonly double siemens;

        private ElectricalConductance(double siemens)
        {
            this.siemens = siemens;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.ElectricalConductance"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.ElectricalConductanceUnit"/>.</param>
        public ElectricalConductance(double value, ElectricalConductanceUnit unit)
        {
            this.siemens = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.ElectricalConductanceUnit.Siemens"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.siemens;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.ElectricalConductanceUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public ElectricalConductanceUnit SiUnit => ElectricalConductanceUnit.Siemens;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => ElectricalConductanceUnit.Siemens;

        /// <summary>
        /// The quantity in siemens".
        /// </summary>
        public double Siemens
        {
            get
            {
                return this.siemens;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricalConductance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricalConductance"/></param>
        /// <returns></returns>
		public static ElectricalConductance Parse(string text)
        {
            return QuantityParser.Parse<ElectricalConductanceUnit, ElectricalConductance>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricalConductance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricalConductance"/></param>
        /// <returns></returns>
        public static ElectricalConductance Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<ElectricalConductanceUnit, ElectricalConductance>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricalConductance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricalConductance"/></param>
        /// <returns></returns>
        public static ElectricalConductance Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<ElectricalConductanceUnit, ElectricalConductance>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricalConductance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricalConductance"/></param>
        /// <returns></returns>
        public static ElectricalConductance Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<ElectricalConductanceUnit, ElectricalConductance>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricalConductance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricalConductance"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out ElectricalConductance result)
        {
            return QuantityParser.TryParse<ElectricalConductanceUnit, ElectricalConductance>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricalConductance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricalConductance"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out ElectricalConductance result)
        {
            return QuantityParser.TryParse<ElectricalConductanceUnit, ElectricalConductance>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricalConductance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricalConductance"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out ElectricalConductance result)
        {
            return QuantityParser.TryParse<ElectricalConductanceUnit, ElectricalConductance>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricalConductance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricalConductance"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out ElectricalConductance result)
        {
            return QuantityParser.TryParse<ElectricalConductanceUnit, ElectricalConductance>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.ElectricalConductance"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.ElectricalConductance"/></returns>
        public static ElectricalConductance ReadFrom(XmlReader reader)
        {
            var v = new ElectricalConductance();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ElectricalConductance"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static ElectricalConductance From(double value, ElectricalConductanceUnit unit)
        {
            return new ElectricalConductance(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ElectricalConductance"/>.
        /// </summary>
        /// <param name="siemens">The value in <see cref="Gu.Units.ElectricalConductanceUnit.Siemens"/></param>
        public static ElectricalConductance FromSiemens(double siemens)
        {
            return new ElectricalConductance(siemens);
        }

        public static Capacitance operator *(ElectricalConductance left, Time right)
        {
            return Capacitance.FromFarads(left.siemens * right.seconds);
        }

        public static Capacitance operator /(ElectricalConductance left, Frequency right)
        {
            return Capacitance.FromFarads(left.siemens / right.hertz);
        }

        public static Current operator *(ElectricalConductance left, Voltage right)
        {
            return Current.FromAmperes(left.siemens * right.volts);
        }

        public static Time operator *(ElectricalConductance left, Inductance right)
        {
            return Time.FromSeconds(left.siemens * right.henrys);
        }

        public static Frequency operator /(ElectricalConductance left, Capacitance right)
        {
            return Frequency.FromHertz(left.siemens / right.farads);
        }

        public static ElectricCharge operator *(ElectricalConductance left, MagneticFlux right)
        {
            return ElectricCharge.FromCoulombs(left.siemens * right.webers);
        }

        public static Resistance operator /(double left, ElectricalConductance right)
        {
            return Resistance.FromOhm(left / right.siemens);
        }

        public static double operator /(ElectricalConductance left, ElectricalConductance right)
        {
            return left.siemens / right.siemens;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ElectricalConductance"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        public static bool operator ==(ElectricalConductance left, ElectricalConductance right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ElectricalConductance"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        public static bool operator !=(ElectricalConductance left, ElectricalConductance right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ElectricalConductance"/> is less than another specified <see cref="Gu.Units.ElectricalConductance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        public static bool operator <(ElectricalConductance left, ElectricalConductance right)
        {
            return left.siemens < right.siemens;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ElectricalConductance"/> is greater than another specified <see cref="Gu.Units.ElectricalConductance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        public static bool operator >(ElectricalConductance left, ElectricalConductance right)
        {
            return left.siemens > right.siemens;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ElectricalConductance"/> is less than or equal to another specified <see cref="Gu.Units.ElectricalConductance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        public static bool operator <=(ElectricalConductance left, ElectricalConductance right)
        {
            return left.siemens <= right.siemens;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ElectricalConductance"/> is greater than or equal to another specified <see cref="Gu.Units.ElectricalConductance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        public static bool operator >=(ElectricalConductance left, ElectricalConductance right)
        {
            return left.siemens >= right.siemens;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.ElectricalConductance"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricalConductance"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.ElectricalConductance"/> with <paramref name="left"/> and returns the result.</returns>
        public static ElectricalConductance operator *(double left, ElectricalConductance right)
        {
            return new ElectricalConductance(left * right.siemens);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.ElectricalConductance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricalConductance"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.ElectricalConductance"/> with <paramref name="right"/> and returns the result.</returns>
        public static ElectricalConductance operator *(ElectricalConductance left, double right)
        {
            return new ElectricalConductance(left.siemens * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.ElectricalConductance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricalConductance"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.ElectricalConductance"/> with <paramref name="right"/> and returns the result.</returns>
        public static ElectricalConductance operator /(ElectricalConductance left, double right)
        {
            return new ElectricalConductance(left.siemens / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.ElectricalConductance"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.ElectricalConductance"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricalConductance"/>.</param>
        public static ElectricalConductance operator +(ElectricalConductance left, ElectricalConductance right)
        {
            return new ElectricalConductance(left.siemens + right.siemens);
        }

        /// <summary>
        /// Subtracts an ElectricalConductance from another ElectricalConductance and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.ElectricalConductance"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricalConductance"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricalConductance"/> (the subtrahend).</param>
        public static ElectricalConductance operator -(ElectricalConductance left, ElectricalConductance right)
        {
            return new ElectricalConductance(left.siemens - right.siemens);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.ElectricalConductance"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.ElectricalConductance"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="electricalConductance">An instance of <see cref="Gu.Units.ElectricalConductance"/></param>
        public static ElectricalConductance operator -(ElectricalConductance electricalConductance)
        {
            return new ElectricalConductance(-1 * electricalConductance.siemens);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.ElectricalConductance"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="electricalConductance"/>.
        /// </returns>
        /// <param name="electricalConductance">An instance of <see cref="Gu.Units.ElectricalConductance"/></param>
        public static ElectricalConductance operator +(ElectricalConductance electricalConductance)
        {
            return electricalConductance;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(ElectricalConductanceUnit unit)
        {
            return unit.FromSiUnit(this.siemens);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="ElectricalConductance"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="ElectricalConductance"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 S\"</param>
        /// <returns>The string representation of the <see cref="ElectricalConductance"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 S\"</param>
        /// <returns>The string representation of the <see cref="ElectricalConductance"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex S</param>
        /// <returns>The string representation of the <see cref="ElectricalConductance"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex S</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="ElectricalConductance"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(ElectricalConductanceUnit unit)
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(ElectricalConductanceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(ElectricalConductanceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(ElectricalConductanceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, ElectricalConductanceUnit unit)
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, ElectricalConductanceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, ElectricalConductanceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, ElectricalConductanceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ElectricalConductanceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<ElectricalConductanceUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.ElectricalConductance"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.ElectricalConductance"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.ElectricalConductance"/> object to compare to this instance.</param>
        public int CompareTo(ElectricalConductance quantity)
        {
            return this.siemens.CompareTo(quantity.siemens);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.ElectricalConductance"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same ElectricalConductance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.ElectricalConductance"/> object to compare with this instance.</param>
        public bool Equals(ElectricalConductance other)
        {
            return this.siemens.Equals(other.siemens);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.ElectricalConductance"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same ElectricalConductance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.ElectricalConductance"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(ElectricalConductance other, ElectricalConductance tolerance)
        {
            Ensure.GreaterThan(tolerance.siemens, 0, nameof(tolerance));
            return Math.Abs(this.siemens - other.siemens) < tolerance.siemens;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ElectricalConductance && this.Equals((ElectricalConductance)obj);
        }

        public override int GetHashCode()
        {
            return this.siemens.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "siemens", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.siemens);
        }
    }
}