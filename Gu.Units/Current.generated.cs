namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Current"/>.
    /// </summary>
    // [TypeConverter(typeof(CurrentTypeConverter))]
    [Serializable]
    public partial struct Current : IQuantity<CurrentUnit>, IComparable<Current>, IEquatable<Current>
    {
        public static readonly Current Zero = new Current();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.CurrentUnit.Amperes"/>.
        /// </summary>
        internal readonly double amperes;

        private Current(double amperes)
        {
            this.amperes = amperes;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.CurrentUnit"/>.</param>
        public Current(double value, CurrentUnit unit)
        {
            this.amperes = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.CurrentUnit.Amperes"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.amperes;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.CurrentUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public CurrentUnit SiUnit => CurrentUnit.Amperes;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => CurrentUnit.Amperes;

        /// <summary>
        /// The quantity in amperes".
        /// </summary>
        public double Amperes
        {
            get
            {
                return this.amperes;
            }
        }

        /// <summary>
        /// The quantity in Milliamperes
        /// </summary>
        public double Milliamperes => 1000 * this.amperes;

        /// <summary>
        /// The quantity in Kiloamperes
        /// </summary>
        public double Kiloamperes => this.amperes / 1000;

        /// <summary>
        /// The quantity in Megaamperes
        /// </summary>
        public double Megaamperes => this.amperes / 1000000;

        /// <summary>
        /// The quantity in Microamperes
        /// </summary>
        public double Microamperes => 1000000 * this.amperes;

        /// <summary>
        /// The quantity in Nanoamperes
        /// </summary>
        public double Nanoamperes => 1000000000 * this.amperes;

        /// <summary>
        /// The quantity in Gigaamperes
        /// </summary>
        public double Gigaamperes => this.amperes / 1000000000;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Current"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="Gu.Units.Current"/></param>
        /// <returns></returns>
		public static Current Parse(string s)
        {
            return QuantityParser.Parse<CurrentUnit, Current>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static Current Parse(string s, IFormatProvider provider)
        {
            return QuantityParser.Parse<CurrentUnit, Current>(s, From, NumberStyles.Float, provider);
        }

        public static Current Parse(string s, NumberStyles styles)
        {
            return QuantityParser.Parse<CurrentUnit, Current>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static Current Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<CurrentUnit, Current>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out Current value)
        {
            return QuantityParser.TryParse<CurrentUnit, Current>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out Current value)
        {
            return QuantityParser.TryParse<CurrentUnit, Current>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out Current value)
        {
            return QuantityParser.TryParse<CurrentUnit, Current>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out Current value)
        {
            return QuantityParser.TryParse<CurrentUnit, Current>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Current"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Current"/></returns>
        public static Current ReadFrom(XmlReader reader)
        {
            var v = new Current();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Current From(double value, CurrentUnit unit)
        {
            return new Current(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="amperes">The value in <see cref="Gu.Units.CurrentUnit.Amperes"/></param>
        public static Current FromAmperes(double amperes)
        {
            return new Current(amperes);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="milliamperes">The value in mA</param>
        public static Current FromMilliamperes(double milliamperes)
        {
            return new Current(milliamperes / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="kiloamperes">The value in kA</param>
        public static Current FromKiloamperes(double kiloamperes)
        {
            return new Current(1000 * kiloamperes);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="megaamperes">The value in MA</param>
        public static Current FromMegaamperes(double megaamperes)
        {
            return new Current(1000000 * megaamperes);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="microamperes">The value in µA</param>
        public static Current FromMicroamperes(double microamperes)
        {
            return new Current(microamperes / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="nanoamperes">The value in nA</param>
        public static Current FromNanoamperes(double nanoamperes)
        {
            return new Current(nanoamperes / 1000000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="gigaamperes">The value in GA</param>
        public static Current FromGigaamperes(double gigaamperes)
        {
            return new Current(1000000000 * gigaamperes);
        }

        public static ElectricCharge operator *(Current left, Time right)
        {
            return ElectricCharge.FromCoulombs(left.amperes * right.seconds);
        }

        public static ElectricCharge operator /(Current left, Frequency right)
        {
            return ElectricCharge.FromCoulombs(left.amperes / right.hertz);
        }

        public static Power operator *(Current left, Voltage right)
        {
            return Power.FromWatts(left.amperes * right.volts);
        }

        public static ElectricalConductance operator /(Current left, Voltage right)
        {
            return ElectricalConductance.FromSiemens(left.amperes / right.volts);
        }

        public static Voltage operator *(Current left, Resistance right)
        {
            return Voltage.FromVolts(left.amperes * right.ohm);
        }

        public static Frequency operator /(Current left, ElectricCharge right)
        {
            return Frequency.FromHertz(left.amperes / right.coulombs);
        }

        public static MagneticFlux operator *(Current left, Inductance right)
        {
            return MagneticFlux.FromWebers(left.amperes * right.henrys);
        }

        public static Energy operator *(Current left, MagneticFlux right)
        {
            return Energy.FromJoules(left.amperes * right.webers);
        }

        public static Voltage operator /(Current left, ElectricalConductance right)
        {
            return Voltage.FromVolts(left.amperes / right.siemens);
        }

        public static Stiffness operator *(Current left, MagneticFieldStrength right)
        {
            return Stiffness.FromNewtonsPerMetre(left.amperes * right.teslas);
        }

        public static double operator /(Current left, Current right)
        {
            return left.amperes / right.amperes;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Current"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Current"/>.</param>
        public static bool operator ==(Current left, Current right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Current"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Current"/>.</param>
        public static bool operator !=(Current left, Current right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Current"/> is less than another specified <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Current"/>.</param>
        public static bool operator <(Current left, Current right)
        {
            return left.amperes < right.amperes;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Current"/> is greater than another specified <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Current"/>.</param>
        public static bool operator >(Current left, Current right)
        {
            return left.amperes > right.amperes;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Current"/> is less than or equal to another specified <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Current"/>.</param>
        public static bool operator <=(Current left, Current right)
        {
            return left.amperes <= right.amperes;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Current"/> is greater than or equal to another specified <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Current"/>.</param>
        public static bool operator >=(Current left, Current right)
        {
            return left.amperes >= right.amperes;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Current"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Current"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Current"/> with <paramref name="left"/> and returns the result.</returns>
        public static Current operator *(double left, Current right)
        {
            return new Current(left * right.amperes);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Current"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Current"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Current"/> with <paramref name="right"/> and returns the result.</returns>
        public static Current operator *(Current left, double right)
        {
            return new Current(left.amperes * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Current"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Current"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Current"/> with <paramref name="right"/> and returns the result.</returns>
        public static Current operator /(Current left, double right)
        {
            return new Current(left.amperes / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Current"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Current"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Current"/>.</param>
        public static Current operator +(Current left, Current right)
        {
            return new Current(left.amperes + right.amperes);
        }

        /// <summary>
        /// Subtracts an Current from another Current and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Current"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Current"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Current"/> (the subtrahend).</param>
        public static Current operator -(Current left, Current right)
        {
            return new Current(left.amperes - right.amperes);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Current"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Current"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="current">An instance of <see cref="Gu.Units.Current"/></param>
        public static Current operator -(Current current)
        {
            return new Current(-1 * current.amperes);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="current"/>.
        /// </returns>
        /// <param name="current">An instance of <see cref="Gu.Units.Current"/></param>
        public static Current operator +(Current current)
        {
            return current;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(CurrentUnit unit)
        {
            return unit.FromSiUnit(this.amperes);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Current"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Current"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 A\"</param>
        /// <returns>The string representation of the <see cref="Current"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 A\"</param>
        /// <returns>The string representation of the <see cref="Current"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex A</param>
        /// <returns>The string representation of the <see cref="Current"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex A</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Current"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(CurrentUnit unit)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(CurrentUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(CurrentUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(CurrentUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, CurrentUnit unit)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, CurrentUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, CurrentUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, CurrentUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<CurrentUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Current"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Current"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Current"/> object to compare to this instance.</param>
        public int CompareTo(Current quantity)
        {
            return this.amperes.CompareTo(quantity.amperes);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Current"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Current as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Current"/> object to compare with this instance.</param>
        public bool Equals(Current other)
        {
            return this.amperes.Equals(other.amperes);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Current"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Current as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Current"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Current other, Current tolerance)
        {
            Ensure.GreaterThan(tolerance.amperes, 0, nameof(tolerance));
            return Math.Abs(this.amperes - other.amperes) < tolerance.amperes;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Current && this.Equals((Current)obj);
        }

        public override int GetHashCode()
        {
            return this.amperes.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "amperes", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.amperes);
        }
    }
}