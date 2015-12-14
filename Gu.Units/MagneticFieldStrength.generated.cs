namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.MagneticFieldStrength"/>.
    /// </summary>
    // [TypeConverter(typeof(MagneticFieldStrengthTypeConverter))]
    [Serializable]
    public partial struct MagneticFieldStrength : IQuantity<MagneticFieldStrengthUnit>, IComparable<MagneticFieldStrength>, IEquatable<MagneticFieldStrength>
    {
        public static readonly MagneticFieldStrength Zero = new MagneticFieldStrength();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.MagneticFieldStrengthUnit.Teslas"/>.
        /// </summary>
        internal readonly double teslas;

        private MagneticFieldStrength(double teslas)
        {
            this.teslas = teslas;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.MagneticFieldStrength"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.MagneticFieldStrengthUnit"/>.</param>
        public MagneticFieldStrength(double value, MagneticFieldStrengthUnit unit)
        {
            this.teslas = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.MagneticFieldStrengthUnit.Teslas"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.teslas;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.MagneticFieldStrengthUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public MagneticFieldStrengthUnit SiUnit => MagneticFieldStrengthUnit.Teslas;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => MagneticFieldStrengthUnit.Teslas;

        /// <summary>
        /// The quantity in teslas".
        /// </summary>
        public double Teslas
        {
            get
            {
                return this.teslas;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MagneticFieldStrength"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="Gu.Units.MagneticFieldStrength"/></param>
        /// <returns></returns>
		public static MagneticFieldStrength Parse(string s)
        {
            return QuantityParser.Parse<MagneticFieldStrengthUnit, MagneticFieldStrength>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static MagneticFieldStrength Parse(string s, IFormatProvider provider)
        {
            return QuantityParser.Parse<MagneticFieldStrengthUnit, MagneticFieldStrength>(s, From, NumberStyles.Float, provider);
        }

        public static MagneticFieldStrength Parse(string s, NumberStyles styles)
        {
            return QuantityParser.Parse<MagneticFieldStrengthUnit, MagneticFieldStrength>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static MagneticFieldStrength Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<MagneticFieldStrengthUnit, MagneticFieldStrength>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out MagneticFieldStrength value)
        {
            return QuantityParser.TryParse<MagneticFieldStrengthUnit, MagneticFieldStrength>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out MagneticFieldStrength value)
        {
            return QuantityParser.TryParse<MagneticFieldStrengthUnit, MagneticFieldStrength>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out MagneticFieldStrength value)
        {
            return QuantityParser.TryParse<MagneticFieldStrengthUnit, MagneticFieldStrength>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out MagneticFieldStrength value)
        {
            return QuantityParser.TryParse<MagneticFieldStrengthUnit, MagneticFieldStrength>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.MagneticFieldStrength"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.MagneticFieldStrength"/></returns>
        public static MagneticFieldStrength ReadFrom(XmlReader reader)
        {
            var v = new MagneticFieldStrength();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.MagneticFieldStrength"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static MagneticFieldStrength From(double value, MagneticFieldStrengthUnit unit)
        {
            return new MagneticFieldStrength(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.MagneticFieldStrength"/>.
        /// </summary>
        /// <param name="teslas">The value in <see cref="Gu.Units.MagneticFieldStrengthUnit.Teslas"/></param>
        public static MagneticFieldStrength FromTeslas(double teslas)
        {
            return new MagneticFieldStrength(teslas);
        }

        public static Stiffness operator *(MagneticFieldStrength left, Current right)
        {
            return Stiffness.FromNewtonsPerMetre(left.teslas * right.amperes);
        }

        public static MagneticFlux operator *(MagneticFieldStrength left, Area right)
        {
            return MagneticFlux.FromWebers(left.teslas * right.squareMetres);
        }

        public static MassFlow operator *(MagneticFieldStrength left, ElectricCharge right)
        {
            return MassFlow.FromKilogramsPerSecond(left.teslas * right.coulombs);
        }

        public static Voltage operator *(MagneticFieldStrength left, KinematicViscosity right)
        {
            return Voltage.FromVolts(left.teslas * right.squareMetresPerSecond);
        }

        public static double operator /(MagneticFieldStrength left, MagneticFieldStrength right)
        {
            return left.teslas / right.teslas;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MagneticFieldStrength"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        public static bool operator ==(MagneticFieldStrength left, MagneticFieldStrength right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MagneticFieldStrength"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        public static bool operator !=(MagneticFieldStrength left, MagneticFieldStrength right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MagneticFieldStrength"/> is less than another specified <see cref="Gu.Units.MagneticFieldStrength"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        public static bool operator <(MagneticFieldStrength left, MagneticFieldStrength right)
        {
            return left.teslas < right.teslas;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MagneticFieldStrength"/> is greater than another specified <see cref="Gu.Units.MagneticFieldStrength"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        public static bool operator >(MagneticFieldStrength left, MagneticFieldStrength right)
        {
            return left.teslas > right.teslas;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MagneticFieldStrength"/> is less than or equal to another specified <see cref="Gu.Units.MagneticFieldStrength"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        public static bool operator <=(MagneticFieldStrength left, MagneticFieldStrength right)
        {
            return left.teslas <= right.teslas;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MagneticFieldStrength"/> is greater than or equal to another specified <see cref="Gu.Units.MagneticFieldStrength"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        public static bool operator >=(MagneticFieldStrength left, MagneticFieldStrength right)
        {
            return left.teslas >= right.teslas;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.MagneticFieldStrength"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.MagneticFieldStrength"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.MagneticFieldStrength"/> with <paramref name="left"/> and returns the result.</returns>
        public static MagneticFieldStrength operator *(double left, MagneticFieldStrength right)
        {
            return new MagneticFieldStrength(left * right.teslas);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.MagneticFieldStrength"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.MagneticFieldStrength"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.MagneticFieldStrength"/> with <paramref name="right"/> and returns the result.</returns>
        public static MagneticFieldStrength operator *(MagneticFieldStrength left, double right)
        {
            return new MagneticFieldStrength(left.teslas * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.MagneticFieldStrength"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.MagneticFieldStrength"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.MagneticFieldStrength"/> with <paramref name="right"/> and returns the result.</returns>
        public static MagneticFieldStrength operator /(MagneticFieldStrength left, double right)
        {
            return new MagneticFieldStrength(left.teslas / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.MagneticFieldStrength"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MagneticFieldStrength"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MagneticFieldStrength"/>.</param>
        public static MagneticFieldStrength operator +(MagneticFieldStrength left, MagneticFieldStrength right)
        {
            return new MagneticFieldStrength(left.teslas + right.teslas);
        }

        /// <summary>
        /// Subtracts an MagneticFieldStrength from another MagneticFieldStrength and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MagneticFieldStrength"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MagneticFieldStrength"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MagneticFieldStrength"/> (the subtrahend).</param>
        public static MagneticFieldStrength operator -(MagneticFieldStrength left, MagneticFieldStrength right)
        {
            return new MagneticFieldStrength(left.teslas - right.teslas);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.MagneticFieldStrength"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MagneticFieldStrength"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="magneticFieldStrength">An instance of <see cref="Gu.Units.MagneticFieldStrength"/></param>
        public static MagneticFieldStrength operator -(MagneticFieldStrength magneticFieldStrength)
        {
            return new MagneticFieldStrength(-1 * magneticFieldStrength.teslas);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.MagneticFieldStrength"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="magneticFieldStrength"/>.
        /// </returns>
        /// <param name="magneticFieldStrength">An instance of <see cref="Gu.Units.MagneticFieldStrength"/></param>
        public static MagneticFieldStrength operator +(MagneticFieldStrength magneticFieldStrength)
        {
            return magneticFieldStrength;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(MagneticFieldStrengthUnit unit)
        {
            return unit.FromSiUnit(this.teslas);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="MagneticFieldStrength"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="MagneticFieldStrength"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 T\"</param>
        /// <returns>The string representation of the <see cref="MagneticFieldStrength"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 T\"</param>
        /// <returns>The string representation of the <see cref="MagneticFieldStrength"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex T</param>
        /// <returns>The string representation of the <see cref="MagneticFieldStrength"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex T</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="MagneticFieldStrength"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(MagneticFieldStrengthUnit unit)
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(MagneticFieldStrengthUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(MagneticFieldStrengthUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(MagneticFieldStrengthUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, MagneticFieldStrengthUnit unit)
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, MagneticFieldStrengthUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, MagneticFieldStrengthUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, MagneticFieldStrengthUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MagneticFieldStrengthUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<MagneticFieldStrengthUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.MagneticFieldStrength"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.MagneticFieldStrength"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.MagneticFieldStrength"/> object to compare to this instance.</param>
        public int CompareTo(MagneticFieldStrength quantity)
        {
            return this.teslas.CompareTo(quantity.teslas);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MagneticFieldStrength"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MagneticFieldStrength as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.MagneticFieldStrength"/> object to compare with this instance.</param>
        public bool Equals(MagneticFieldStrength other)
        {
            return this.teslas.Equals(other.teslas);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MagneticFieldStrength"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MagneticFieldStrength as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.MagneticFieldStrength"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(MagneticFieldStrength other, MagneticFieldStrength tolerance)
        {
            Ensure.GreaterThan(tolerance.teslas, 0, nameof(tolerance));
            return Math.Abs(this.teslas - other.teslas) < tolerance.teslas;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is MagneticFieldStrength && this.Equals((MagneticFieldStrength)obj);
        }

        public override int GetHashCode()
        {
            return this.teslas.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "teslas", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.teslas);
        }
    }
}