namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Flexibility"/>.
    /// </summary>
    [Serializable]
    public partial struct Flexibility : IComparable<Flexibility>, IEquatable<Flexibility>, IFormattable, IXmlSerializable, IQuantity<MassUnit, INeg1, TimeUnit, I2>, IQuantity<FlexibilityUnit>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.MetresPerNewton"/>.
        /// </summary>
        internal readonly double metresPerNewton;

        private Flexibility(double metresPerNewton)
        {
            this.metresPerNewton = metresPerNewton;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.MetresPerNewton"/>.</param>
        public Flexibility(double value, FlexibilityUnit unit)
        {
            this.metresPerNewton = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in MetresPerNewton
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.metresPerNewton;
            }
        }

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
        /// The quantity in millimetresPerNewton
        /// </summary>
        public double MillimetresPerNewton
        {
            get
            {
                return FlexibilityUnit.MillimetresPerNewton.FromSiUnit(this.metresPerNewton);
            }
        }

        /// <summary>
        /// The quantity in millimetresPerKilonewton
        /// </summary>
        public double MillimetresPerKilonewton
        {
            get
            {
                return FlexibilityUnit.MillimetresPerKilonewton.FromSiUnit(this.metresPerNewton);
            }
        }

        /// <summary>
        /// The quantity in micrometresPerKilonewton
        /// </summary>
        public double MicrometresPerKilonewton
        {
            get
            {
                return FlexibilityUnit.MicrometresPerKilonewton.FromSiUnit(this.metresPerNewton);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Flexibility"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Flexibility"/></param>
        /// <returns></returns>
        public static Flexibility Parse(string s)
        {
            return Parser.Parse<FlexibilityUnit, Flexibility>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static Flexibility Parse(string s, NumberStyles styles)
        {
            return Parser.Parse<FlexibilityUnit, Flexibility>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static Flexibility Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return Parser.Parse<FlexibilityUnit, Flexibility>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out Flexibility value)
        {
            return Parser.TryParse<FlexibilityUnit, Flexibility>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out Flexibility value)
        {
            return Parser.TryParse<FlexibilityUnit, Flexibility>(s, From, styles, CultureInfo.CurrentCulture, out  value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out Flexibility value)
        {
            return Parser.TryParse<FlexibilityUnit, Flexibility>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Flexibility"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Flexibility"/></returns>
        public static Flexibility ReadFrom(XmlReader reader)
        {
            var v = new Flexibility();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Flexibility From(double value, FlexibilityUnit unit)
        {
            return new Flexibility(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <param name="metresPerNewton">The value in <see cref="T:Gu.Units.MetresPerNewton"/></param>
        public static Flexibility FromMetresPerNewton(double metresPerNewton)
        {
            return new Flexibility(metresPerNewton);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <param name="millimetresPerNewton">The value in mm/N</param>
        public static Flexibility FromMillimetresPerNewton(double millimetresPerNewton)
        {
            return From(millimetresPerNewton, FlexibilityUnit.MillimetresPerNewton);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <param name="millimetresPerKilonewton">The value in mm/kN</param>
        public static Flexibility FromMillimetresPerKilonewton(double millimetresPerKilonewton)
        {
            return From(millimetresPerKilonewton, FlexibilityUnit.MillimetresPerKilonewton);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <param name="micrometresPerKilonewton">The value in µm/kN</param>
        public static Flexibility FromMicrometresPerKilonewton(double micrometresPerKilonewton)
        {
            return From(micrometresPerKilonewton, FlexibilityUnit.MicrometresPerKilonewton);
        }

        public static Length operator *(Flexibility left, Force right)
        {
            return Length.FromMetres(left.metresPerNewton * right.newtons);
        }

        public static Area operator *(Flexibility left, Energy right)
        {
            return Area.FromSquareMetres(left.metresPerNewton * right.joules);
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
        /// Indicates whether two <see cref="T:Gu.Units.Flexibility"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        public static bool operator ==(Flexibility left, Flexibility right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Flexibility"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        public static bool operator !=(Flexibility left, Flexibility right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Flexibility"/> is less than another specified <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        public static bool operator <(Flexibility left, Flexibility right)
        {
            return left.metresPerNewton < right.metresPerNewton;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Flexibility"/> is greater than another specified <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        public static bool operator >(Flexibility left, Flexibility right)
        {
            return left.metresPerNewton > right.metresPerNewton;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Flexibility"/> is less than or equal to another specified <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        public static bool operator <=(Flexibility left, Flexibility right)
        {
            return left.metresPerNewton <= right.metresPerNewton;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Flexibility"/> is greater than or equal to another specified <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        public static bool operator >=(Flexibility left, Flexibility right)
        {
            return left.metresPerNewton >= right.metresPerNewton;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Flexibility"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Flexibility"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Flexibility"/> with <paramref name="left"/> and returns the result.</returns>
        public static Flexibility operator *(double left, Flexibility right)
        {
            return new Flexibility(left * right.metresPerNewton);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Flexibility"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Flexibility"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Flexibility"/> with <paramref name="right"/> and returns the result.</returns>
        public static Flexibility operator *(Flexibility left, double right)
        {
            return new Flexibility(left.metresPerNewton * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Flexibility"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Flexibility"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Flexibility"/> with <paramref name="right"/> and returns the result.</returns>
        public static Flexibility operator /(Flexibility left, double right)
        {
            return new Flexibility(left.metresPerNewton / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Flexibility"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Flexibility"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Flexibility"/>.</param>
        public static Flexibility operator +(Flexibility left, Flexibility right)
        {
            return new Flexibility(left.metresPerNewton + right.metresPerNewton);
        }

        /// <summary>
        /// Subtracts an Flexibility from another Flexibility and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Flexibility"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Flexibility"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Flexibility"/> (the subtrahend).</param>
        public static Flexibility operator -(Flexibility left, Flexibility right)
        {
            return new Flexibility(left.metresPerNewton - right.metresPerNewton);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Flexibility"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Flexibility"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="flexibility">An instance of <see cref="T:Gu.Units.Flexibility"/></param>
        public static Flexibility operator -(Flexibility flexibility)
        {
            return new Flexibility(-1 * flexibility.metresPerNewton);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="flexibility"/>.
        /// </returns>
        /// <param name="flexibility">An instance of <see cref="T:Gu.Units.Flexibility"/></param>
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

        public override string ToString()
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo);
        }

        public string ToString(string format)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo);
        }

        public string ToString(IFormatProvider provider)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.GetInstance(provider));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return this.ToString(format, formatProvider, FlexibilityUnit.MetresPerNewton);
        }

        public string ToString(FlexibilityUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, FlexibilityUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, FlexibilityUnit unit)
        {
            var quantity = unit.FromSiUnit(this.metresPerNewton);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Flexibility"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Flexibility"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.Flexibility"/> object to compare to this instance.</param>
        public int CompareTo(Flexibility quantity)
        {
            return this.metresPerNewton.CompareTo(quantity.metresPerNewton);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Flexibility"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Flexibility as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Flexibility"/> object to compare with this instance.</param>
        public bool Equals(Flexibility other)
        {
            return this.metresPerNewton.Equals(other.metresPerNewton);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Flexibility"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Flexibility as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Flexibility"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Flexibility other, double tolerance)
        {
            return Math.Abs(this.metresPerNewton - other.metresPerNewton) < tolerance;
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
        /// if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the
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
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            // Hacking set readonly fields here, can't think of a cleaner workaround
            XmlExt.SetReadonlyField(ref this, "metresPerNewton", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.metresPerNewton);
        }
    }
}