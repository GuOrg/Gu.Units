namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Force"/>.
    /// </summary>
    // [TypeConverter(typeof(ForceTypeConverter))]
    [Serializable]
    public partial struct Force : IQuantity<ForceUnit>, IComparable<Force>, IEquatable<Force>
    {
        public static readonly Force Zero = new Force();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.ForceUnit.Newtons"/>.
        /// </summary>
        internal readonly double newtons;

        private Force(double newtons)
        {
            this.newtons = newtons;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.ForceUnit"/>.</param>
        public Force(double value, ForceUnit unit)
        {
            this.newtons = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.ForceUnit.Newtons"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.newtons;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.ForceUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public ForceUnit SiUnit => ForceUnit.Newtons;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => ForceUnit.Newtons;

        /// <summary>
        /// The quantity in newtons".
        /// </summary>
        public double Newtons
        {
            get
            {
                return this.newtons;
            }
        }

        /// <summary>
        /// The quantity in nanonewtons
        /// </summary>
        public double Nanonewtons
        {
            get
            {
                return ForceUnit.Nanonewtons.FromSiUnit(this.newtons);
            }
        }

        /// <summary>
        /// The quantity in micronewtons
        /// </summary>
        public double Micronewtons
        {
            get
            {
                return ForceUnit.Micronewtons.FromSiUnit(this.newtons);
            }
        }

        /// <summary>
        /// The quantity in millinewtons
        /// </summary>
        public double Millinewtons
        {
            get
            {
                return ForceUnit.Millinewtons.FromSiUnit(this.newtons);
            }
        }

        /// <summary>
        /// The quantity in kilonewtons
        /// </summary>
        public double Kilonewtons
        {
            get
            {
                return ForceUnit.Kilonewtons.FromSiUnit(this.newtons);
            }
        }

        /// <summary>
        /// The quantity in meganewtons
        /// </summary>
        public double Meganewtons
        {
            get
            {
                return ForceUnit.Meganewtons.FromSiUnit(this.newtons);
            }
        }

        /// <summary>
        /// The quantity in giganewtons
        /// </summary>
        public double Giganewtons
        {
            get
            {
                return ForceUnit.Giganewtons.FromSiUnit(this.newtons);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Force"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="Gu.Units.Force"/></param>
        /// <returns></returns>
		public static Force Parse(string s)
        {
            return QuantityParser.Parse<ForceUnit, Force>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static Force Parse(string s, IFormatProvider provider)
        {
            return QuantityParser.Parse<ForceUnit, Force>(s, From, NumberStyles.Float, provider);
        }

        public static Force Parse(string s, NumberStyles styles)
        {
            return QuantityParser.Parse<ForceUnit, Force>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static Force Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<ForceUnit, Force>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out Force value)
        {
            return QuantityParser.TryParse<ForceUnit, Force>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out Force value)
        {
            return QuantityParser.TryParse<ForceUnit, Force>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out Force value)
        {
            return QuantityParser.TryParse<ForceUnit, Force>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out Force value)
        {
            return QuantityParser.TryParse<ForceUnit, Force>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Force"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Force"/></returns>
        public static Force ReadFrom(XmlReader reader)
        {
            var v = new Force();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Force From(double value, ForceUnit unit)
        {
            return new Force(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="newtons">The value in <see cref="Gu.Units.ForceUnit.Newtons"/></param>
        public static Force FromNewtons(double newtons)
        {
            return new Force(newtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="nanonewtons">The value in nN</param>
        public static Force FromNanonewtons(double nanonewtons)
        {
            return From(nanonewtons, ForceUnit.Nanonewtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="micronewtons">The value in µN</param>
        public static Force FromMicronewtons(double micronewtons)
        {
            return From(micronewtons, ForceUnit.Micronewtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="millinewtons">The value in mN</param>
        public static Force FromMillinewtons(double millinewtons)
        {
            return From(millinewtons, ForceUnit.Millinewtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="kilonewtons">The value in kN</param>
        public static Force FromKilonewtons(double kilonewtons)
        {
            return From(kilonewtons, ForceUnit.Kilonewtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="meganewtons">The value in MN</param>
        public static Force FromMeganewtons(double meganewtons)
        {
            return From(meganewtons, ForceUnit.Meganewtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="giganewtons">The value in GN</param>
        public static Force FromGiganewtons(double giganewtons)
        {
            return From(giganewtons, ForceUnit.Giganewtons);
        }

        public static Mass operator /(Force left, Acceleration right)
        {
            return Mass.FromKilograms(left.newtons / right.metresPerSecondSquared);
        }

        public static Pressure operator /(Force left, Area right)
        {
            return Pressure.FromPascals(left.newtons / right.squareMetres);
        }

        public static Energy operator *(Force left, Length right)
        {
            return Energy.FromJoules(left.newtons * right.metres);
        }

        public static Power operator *(Force left, Speed right)
        {
            return Power.FromWatts(left.newtons * right.metresPerSecond);
        }

        public static Acceleration operator /(Force left, Mass right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.newtons / right.kilograms);
        }

        public static Stiffness operator /(Force left, Length right)
        {
            return Stiffness.FromNewtonsPerMetre(left.newtons / right.metres);
        }

        public static ForcePerUnitless operator /(Force left, Unitless right)
        {
            return ForcePerUnitless.FromNewtonsPerUnitless(left.newtons / right.scalar);
        }

        public static double operator /(Force left, Force right)
        {
            return left.newtons / right.newtons;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Force"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Force"/>.</param>
        public static bool operator ==(Force left, Force right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Force"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Force"/>.</param>
        public static bool operator !=(Force left, Force right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Force"/> is less than another specified <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Force"/>.</param>
        public static bool operator <(Force left, Force right)
        {
            return left.newtons < right.newtons;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Force"/> is greater than another specified <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Force"/>.</param>
        public static bool operator >(Force left, Force right)
        {
            return left.newtons > right.newtons;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Force"/> is less than or equal to another specified <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Force"/>.</param>
        public static bool operator <=(Force left, Force right)
        {
            return left.newtons <= right.newtons;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Force"/> is greater than or equal to another specified <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Force"/>.</param>
        public static bool operator >=(Force left, Force right)
        {
            return left.newtons >= right.newtons;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Force"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Force"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Force"/> with <paramref name="left"/> and returns the result.</returns>
        public static Force operator *(double left, Force right)
        {
            return new Force(left * right.newtons);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Force"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Force"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Force"/> with <paramref name="right"/> and returns the result.</returns>
        public static Force operator *(Force left, double right)
        {
            return new Force(left.newtons * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Force"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Force"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Force"/> with <paramref name="right"/> and returns the result.</returns>
        public static Force operator /(Force left, double right)
        {
            return new Force(left.newtons / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Force"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Force"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Force"/>.</param>
        public static Force operator +(Force left, Force right)
        {
            return new Force(left.newtons + right.newtons);
        }

        /// <summary>
        /// Subtracts an Force from another Force and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Force"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Force"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Force"/> (the subtrahend).</param>
        public static Force operator -(Force left, Force right)
        {
            return new Force(left.newtons - right.newtons);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Force"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Force"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="force">An instance of <see cref="Gu.Units.Force"/></param>
        public static Force operator -(Force force)
        {
            return new Force(-1 * force.newtons);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="force"/>.
        /// </returns>
        /// <param name="force">An instance of <see cref="Gu.Units.Force"/></param>
        public static Force operator +(Force force)
        {
            return force;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(ForceUnit unit)
        {
            return unit.FromSiUnit(this.newtons);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Force"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Force"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N\"</param>
        /// <returns>The string representation of the <see cref="Force"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N\"</param>
        /// <returns>The string representation of the <see cref="Force"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex N</param>
        /// <returns>The string representation of the <see cref="Force"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex N</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Force"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(ForceUnit unit)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(ForceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(ForceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(ForceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, ForceUnit unit)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, ForceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, ForceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, ForceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<ForceUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Force"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Force"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Force"/> object to compare to this instance.</param>
        public int CompareTo(Force quantity)
        {
            return this.newtons.CompareTo(quantity.newtons);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Force"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Force as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Force"/> object to compare with this instance.</param>
        public bool Equals(Force other)
        {
            return this.newtons.Equals(other.newtons);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Force"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Force as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Force"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Force other, Force tolerance)
        {
            Ensure.GreaterThan(tolerance.newtons, 0, nameof(tolerance));
            return Math.Abs(this.newtons - other.newtons) < tolerance.newtons;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Force && this.Equals((Force)obj);
        }

        public override int GetHashCode()
        {
            return this.newtons.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "newtons", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.newtons);
        }
    }
}