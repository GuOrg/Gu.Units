namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Flexibility"/>.
    /// </summary>
    // [TypeConverter(typeof(FlexibilityTypeConverter))]
    [Serializable]
    public partial struct Flexibility : IQuantity<FlexibilityUnit>, IComparable<Flexibility>, IEquatable<Flexibility>
    {
        public static readonly Flexibility Zero = new Flexibility();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.FlexibilityUnit.MetresPerNewton"/>.
        /// </summary>
        internal readonly double metresPerNewton;

        private Flexibility(double metresPerNewton)
        {
            this.metresPerNewton = metresPerNewton;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Flexibility"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.FlexibilityUnit"/>.</param>
        public Flexibility(double value, FlexibilityUnit unit)
        {
            this.metresPerNewton = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.FlexibilityUnit.MetresPerNewton"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.metresPerNewton;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.FlexibilityUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public FlexibilityUnit SiUnit => FlexibilityUnit.MetresPerNewton;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => FlexibilityUnit.MetresPerNewton;

        /// <summary>
        /// The quantity in metresPerNewton".
        /// </summary>
        public double MetresPerNewton
        {
            get
            {
                return this.metresPerNewton;
            }
        }

        /// <summary>
        /// The quantity in MillimetresPerNewton
        /// </summary>
        public double MillimetresPerNewton => 1000 * this.metresPerNewton;

        /// <summary>
        /// The quantity in MillimetresPerKilonewton
        /// </summary>
        public double MillimetresPerKilonewton => 1000000 * this.metresPerNewton;

        /// <summary>
        /// The quantity in MicrometresPerKilonewton
        /// </summary>
        public double MicrometresPerKilonewton => 1000000000 * this.metresPerNewton;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Flexibility"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Flexibility"/></param>
        /// <returns></returns>
		public static Flexibility Parse(string text)
        {
            return QuantityParser.Parse<FlexibilityUnit, Flexibility>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Flexibility"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Flexibility"/></param>
        /// <returns></returns>
        public static Flexibility Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<FlexibilityUnit, Flexibility>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Flexibility"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Flexibility"/></param>
        /// <returns></returns>
        public static Flexibility Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<FlexibilityUnit, Flexibility>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Flexibility"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Flexibility"/></param>
        /// <returns></returns>
        public static Flexibility Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<FlexibilityUnit, Flexibility>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Flexibility"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Flexibility"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out Flexibility result)
        {
            return QuantityParser.TryParse<FlexibilityUnit, Flexibility>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Flexibility"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Flexibility"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out Flexibility result)
        {
            return QuantityParser.TryParse<FlexibilityUnit, Flexibility>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Flexibility"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Flexibility"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out Flexibility result)
        {
            return QuantityParser.TryParse<FlexibilityUnit, Flexibility>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Flexibility"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Flexibility"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Flexibility result)
        {
            return QuantityParser.TryParse<FlexibilityUnit, Flexibility>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Flexibility"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Flexibility"/></returns>
        public static Flexibility ReadFrom(XmlReader reader)
        {
            var v = new Flexibility();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Flexibility"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Flexibility From(double value, FlexibilityUnit unit)
        {
            return new Flexibility(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Flexibility"/>.
        /// </summary>
        /// <param name="metresPerNewton">The value in <see cref="Gu.Units.FlexibilityUnit.MetresPerNewton"/></param>
        public static Flexibility FromMetresPerNewton(double metresPerNewton)
        {
            return new Flexibility(metresPerNewton);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Flexibility"/>.
        /// </summary>
        /// <param name="millimetresPerNewton">The value in mm/N</param>
        public static Flexibility FromMillimetresPerNewton(double millimetresPerNewton)
        {
            return new Flexibility(millimetresPerNewton / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Flexibility"/>.
        /// </summary>
        /// <param name="millimetresPerKilonewton">The value in mm/kN</param>
        public static Flexibility FromMillimetresPerKilonewton(double millimetresPerKilonewton)
        {
            return new Flexibility(millimetresPerKilonewton / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Flexibility"/>.
        /// </summary>
        /// <param name="micrometresPerKilonewton">The value in µm/kN</param>
        public static Flexibility FromMicrometresPerKilonewton(double micrometresPerKilonewton)
        {
            return new Flexibility(micrometresPerKilonewton / 1000000000);
        }

        public static Length operator *(Flexibility left, Force right)
        {
            return Length.FromMetres(left.metresPerNewton * right.newtons);
        }

        public static Wavenumber operator *(Flexibility left, Pressure right)
        {
            return Wavenumber.FromReciprocalMetres(left.metresPerNewton * right.pascals);
        }

        public static Area operator *(Flexibility left, Energy right)
        {
            return Area.FromSquareMetres(left.metresPerNewton * right.joules);
        }

        public static KinematicViscosity operator *(Flexibility left, Power right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.metresPerNewton * right.watts);
        }

        public static LengthPerUnitless operator *(Flexibility left, ForcePerUnitless right)
        {
            return LengthPerUnitless.FromMetresPerUnitless(left.metresPerNewton * right.newtonsPerUnitless);
        }

        public static Time operator *(Flexibility left, MassFlow right)
        {
            return Time.FromSeconds(left.metresPerNewton * right.kilogramsPerSecond);
        }

        public static Stiffness operator /(double left, Flexibility right)
        {
            return Stiffness.FromNewtonsPerMetre(left / right.metresPerNewton);
        }

        public static double operator /(Flexibility left, Flexibility right)
        {
            return left.metresPerNewton / right.metresPerNewton;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Flexibility"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        public static bool operator ==(Flexibility left, Flexibility right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Flexibility"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        public static bool operator !=(Flexibility left, Flexibility right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Flexibility"/> is less than another specified <see cref="Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        public static bool operator <(Flexibility left, Flexibility right)
        {
            return left.metresPerNewton < right.metresPerNewton;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Flexibility"/> is greater than another specified <see cref="Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        public static bool operator >(Flexibility left, Flexibility right)
        {
            return left.metresPerNewton > right.metresPerNewton;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Flexibility"/> is less than or equal to another specified <see cref="Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        public static bool operator <=(Flexibility left, Flexibility right)
        {
            return left.metresPerNewton <= right.metresPerNewton;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Flexibility"/> is greater than or equal to another specified <see cref="Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        public static bool operator >=(Flexibility left, Flexibility right)
        {
            return left.metresPerNewton >= right.metresPerNewton;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Flexibility"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Flexibility"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Flexibility"/> with <paramref name="left"/> and returns the result.</returns>
        public static Flexibility operator *(double left, Flexibility right)
        {
            return new Flexibility(left * right.metresPerNewton);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Flexibility"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Flexibility"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Flexibility"/> with <paramref name="right"/> and returns the result.</returns>
        public static Flexibility operator *(Flexibility left, double right)
        {
            return new Flexibility(left.metresPerNewton * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Flexibility"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Flexibility"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Flexibility"/> with <paramref name="right"/> and returns the result.</returns>
        public static Flexibility operator /(Flexibility left, double right)
        {
            return new Flexibility(left.metresPerNewton / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Flexibility"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Flexibility"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Flexibility"/>.</param>
        public static Flexibility operator +(Flexibility left, Flexibility right)
        {
            return new Flexibility(left.metresPerNewton + right.metresPerNewton);
        }

        /// <summary>
        /// Subtracts an Flexibility from another Flexibility and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Flexibility"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Flexibility"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Flexibility"/> (the subtrahend).</param>
        public static Flexibility operator -(Flexibility left, Flexibility right)
        {
            return new Flexibility(left.metresPerNewton - right.metresPerNewton);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Flexibility"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Flexibility"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="flexibility">An instance of <see cref="Gu.Units.Flexibility"/></param>
        public static Flexibility operator -(Flexibility flexibility)
        {
            return new Flexibility(-1 * flexibility.metresPerNewton);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="flexibility"/>.
        /// </returns>
        /// <param name="flexibility">An instance of <see cref="Gu.Units.Flexibility"/></param>
        public static Flexibility operator +(Flexibility flexibility)
        {
            return flexibility;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(FlexibilityUnit unit)
        {
            return unit.FromSiUnit(this.metresPerNewton);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Flexibility"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Flexibility"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m/N\"</param>
        /// <returns>The string representation of the <see cref="Flexibility"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m/N\"</param>
        /// <returns>The string representation of the <see cref="Flexibility"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m/N</param>
        /// <returns>The string representation of the <see cref="Flexibility"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m/N</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Flexibility"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(FlexibilityUnit unit)
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(FlexibilityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(FlexibilityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(FlexibilityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, FlexibilityUnit unit)
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, FlexibilityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, FlexibilityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, FlexibilityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<FlexibilityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<FlexibilityUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Flexibility"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Flexibility"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Flexibility"/> object to compare to this instance.</param>
        public int CompareTo(Flexibility quantity)
        {
            return this.metresPerNewton.CompareTo(quantity.metresPerNewton);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Flexibility"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Flexibility as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Flexibility"/> object to compare with this instance.</param>
        public bool Equals(Flexibility other)
        {
            return this.metresPerNewton.Equals(other.metresPerNewton);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Flexibility"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Flexibility as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Flexibility"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Flexibility other, Flexibility tolerance)
        {
            Ensure.GreaterThan(tolerance.metresPerNewton, 0, nameof(tolerance));
            return Math.Abs(this.metresPerNewton - other.metresPerNewton) < tolerance.metresPerNewton;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Flexibility && this.Equals((Flexibility)obj);
        }

        public override int GetHashCode()
        {
            return this.metresPerNewton.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "metresPerNewton", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.metresPerNewton);
        }
    }
}