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
    public partial struct Flexibility : IComparable<Flexibility>, IEquatable<Flexibility>, IFormattable, IXmlSerializable, IQuantity<MassUnit, INeg1, TimeUnit, I2>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.MetresPerNewton"/>.
        /// </summary>
        public readonly double MetresPerNewton;

        private Flexibility(double metresPerNewton)
        {
            MetresPerNewton = metresPerNewton;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.MetresPerNewton"/>.</param>
        public Flexibility(double value, FlexibilityUnit unit)
        {
            MetresPerNewton = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in MetresPerNewton
        /// </summary>
        public double SiValue
        {
            get
            {
                return MetresPerNewton;
            }
        }

        /// <summary>
        /// The quantity in millimetresPerNewton
        /// </summary>
        public double MillimetresPerNewton
        {
            get
            {
                return FlexibilityUnit.MillimetresPerNewton.FromSiUnit(MetresPerNewton);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Flexibility"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Flexibility"/></param>
        /// <returns></returns>
        public static Flexibility Parse(string s)
        {
            return Parser.Parse<FlexibilityUnit, Flexibility>(s, From);
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

        public static Length operator *(Flexibility left, Force right)
        {
            return Length.FromMetres(left.MetresPerNewton * right.Newtons);
        }

        public static Area operator *(Flexibility left, Energy right)
        {
            return Area.FromSquareMetres(left.MetresPerNewton * right.Joules);
        }

        public static Stiffness operator /(double left, Flexibility right)
        {
            return Stiffness.FromNewtonsPerMetre(left / right.MetresPerNewton);
        }

        public static double operator /(Flexibility left, Flexibility right)
        {
            return left.MetresPerNewton / right.MetresPerNewton;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Flexibility"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Flexibility"/>.</param>
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
        /// <param name="left">A <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Flexibility"/>.</param>
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
        /// <param name="left">An <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Flexibility"/>.</param>
        public static bool operator <(Flexibility left, Flexibility right)
        {
            return left.MetresPerNewton < right.MetresPerNewton;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Flexibility"/> is greater than another specified <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Flexibility"/>.</param>
        public static bool operator >(Flexibility left, Flexibility right)
        {
            return left.MetresPerNewton > right.MetresPerNewton;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Flexibility"/> is less than or equal to another specified <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Flexibility"/>.</param>
        public static bool operator <=(Flexibility left, Flexibility right)
        {
            return left.MetresPerNewton <= right.MetresPerNewton;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Flexibility"/> is greater than or equal to another specified <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Flexibility"/>.</param>
        public static bool operator >=(Flexibility left, Flexibility right)
        {
            return left.MetresPerNewton >= right.MetresPerNewton;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Flexibility"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Flexibility"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Flexibility"/> with <paramref name="left"/> and returns the result.</returns>
        public static Flexibility operator *(double left, Flexibility right)
        {
            return new Flexibility(left * right.MetresPerNewton);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Flexibility"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Flexibility"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Flexibility"/> with <paramref name="right"/> and returns the result.</returns>
        public static Flexibility operator *(Flexibility left, double right)
        {
            return new Flexibility(left.MetresPerNewton * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Flexibility"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Flexibility"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Flexibility"/> with <paramref name="right"/> and returns the result.</returns>
        public static Flexibility operator /(Flexibility left, double right)
        {
            return new Flexibility(left.MetresPerNewton / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Flexibility"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Flexibility"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Flexibility"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Flexibility operator +(Flexibility left, Flexibility right)
        {
            return new Flexibility(left.MetresPerNewton + right.MetresPerNewton);
        }

        /// <summary>
        /// Subtracts an Flexibility from another Flexibility and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Flexibility"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Flexibility"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.Flexibility"/> (the subtrahend).</param>
        public static Flexibility operator -(Flexibility left, Flexibility right)
        {
            return new Flexibility(left.MetresPerNewton - right.MetresPerNewton);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Flexibility"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Flexibility"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Flexibility">A <see cref="T:Gu.Units.Flexibility"/></param>
        public static Flexibility operator -(Flexibility Flexibility)
        {
            return new Flexibility(-1 * Flexibility.MetresPerNewton);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Flexibility"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="Flexibility"/>.
        /// </returns>
        /// <param name="Flexibility">A <see cref="T:Gu.Units.Flexibility"/></param>
        public static Flexibility operator +(Flexibility Flexibility)
        {
            return Flexibility;
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

        public string ToString(string format, IFormatProvider formatProvider, FlexibilityUnit unit)
        {
            var quantity = unit.FromSiUnit(this.MetresPerNewton);
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.Flexibility"/> object to compare to this instance.</param>
        public int CompareTo(Flexibility quantity)
        {
            return this.MetresPerNewton.CompareTo(quantity.MetresPerNewton);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Flexibility"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Flexibility as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Flexibility"/> object to compare with this instance.</param>
        public bool Equals(Flexibility other)
        {
            return this.MetresPerNewton.Equals(other.MetresPerNewton);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Flexibility"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Flexibility as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Flexibility"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Flexibility other, double tolerance)
        {
            return Math.Abs(this.MetresPerNewton - other.MetresPerNewton) < tolerance;
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
            return this.MetresPerNewton.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "MetresPerNewton", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.MetresPerNewton);
        }
    }
}
