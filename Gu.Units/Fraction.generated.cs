namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Fraction"/>.
    /// </summary>
    [Serializable]
    public partial struct Fraction : IComparable<Fraction>, IEquatable<Fraction>, IFormattable, IXmlSerializable, IQuantity<FractionUnit, I1>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Fractions"/>.
        /// </summary>
        public readonly double Fractions;

        private Fraction(double fractions)
        {
            Fractions = fractions;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Fraction"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Fractions"/>.</param>
        public Fraction(double value, FractionUnit unit)
        {
            Fractions = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Fractions
        /// </summary>
        public double SiValue
        {
            get
            {
                return Fractions;
            }
        }

        /// <summary>
        /// The quantity in partsPerMillion
        /// </summary>
        public double PartsPerMillion
        {
            get
            {
                return FractionUnit.PartsPerMillion.FromSiUnit(Fractions);
            }
        }

        /// <summary>
        /// The quantity in promilles
        /// </summary>
        public double Promilles
        {
            get
            {
                return FractionUnit.Promilles.FromSiUnit(Fractions);
            }
        }

        /// <summary>
        /// The quantity in percents
        /// </summary>
        public double Percents
        {
            get
            {
                return FractionUnit.Percents.FromSiUnit(Fractions);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Fraction"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Fraction"/></param>
        /// <returns></returns>
        public static Fraction Parse(string s)
        {
            return Parser.Parse<FractionUnit, Fraction>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Fraction"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Fraction"/></returns>
        public static Fraction ReadFrom(XmlReader reader)
        {
            var v = new Fraction();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Fraction"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Fraction From(double value, FractionUnit unit)
        {
            return new Fraction(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Fraction"/>.
        /// </summary>
        /// <param name="fractions">The value in <see cref="T:Gu.Units.Fractions"/></param>
        public static Fraction FromFractions(double fractions)
        {
            return new Fraction(fractions);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Fraction"/>.
        /// </summary>
        /// <param name="partsPerMillion">The value in ppm</param>
        public static Fraction FromPartsPerMillion(double partsPerMillion)
        {
            return From(partsPerMillion, FractionUnit.PartsPerMillion);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Fraction"/>.
        /// </summary>
        /// <param name="promilles">The value in ‰</param>
        public static Fraction FromPromilles(double promilles)
        {
            return From(promilles, FractionUnit.Promilles);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Fraction"/>.
        /// </summary>
        /// <param name="percents">The value in %</param>
        public static Fraction FromPercents(double percents)
        {
            return From(percents, FractionUnit.Percents);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Fraction"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Fraction"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Fraction"/>.</param>
        public static bool operator ==(Fraction left, Fraction right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Fraction"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Fraction"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Fraction"/>.</param>
        public static bool operator !=(Fraction left, Fraction right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Fraction"/> is less than another specified <see cref="T:Gu.Units.Fraction"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Fraction"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Fraction"/>.</param>
        public static bool operator <(Fraction left, Fraction right)
        {
            return left.Fractions < right.Fractions;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Fraction"/> is greater than another specified <see cref="T:Gu.Units.Fraction"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Fraction"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Fraction"/>.</param>
        public static bool operator >(Fraction left, Fraction right)
        {
            return left.Fractions > right.Fractions;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Fraction"/> is less than or equal to another specified <see cref="T:Gu.Units.Fraction"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Fraction"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Fraction"/>.</param>
        public static bool operator <=(Fraction left, Fraction right)
        {
            return left.Fractions <= right.Fractions;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Fraction"/> is greater than or equal to another specified <see cref="T:Gu.Units.Fraction"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Fraction"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Fraction"/>.</param>
        public static bool operator >=(Fraction left, Fraction right)
        {
            return left.Fractions >= right.Fractions;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Fraction"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Fraction"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Fraction"/> with <paramref name="left"/> and returns the result.</returns>
        public static Fraction operator *(double left, Fraction right)
        {
            return new Fraction(left * right.Fractions);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Fraction"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Fraction"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Fraction"/> with <paramref name="right"/> and returns the result.</returns>
        public static Fraction operator *(Fraction left, double right)
        {
            return new Fraction(left.Fractions * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Fraction"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Fraction"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Fraction"/> with <paramref name="right"/> and returns the result.</returns>
        public static Fraction operator /(Fraction left, double right)
        {
            return new Fraction(left.Fractions / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Fraction"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Fraction"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Fraction"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Fraction operator +(Fraction left, Fraction right)
        {
            return new Fraction(left.Fractions + right.Fractions);
        }

        /// <summary>
        /// Subtracts an Fraction from another Fraction and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Fraction"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Fraction"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.Fraction"/> (the subtrahend).</param>
        public static Fraction operator -(Fraction left, Fraction right)
        {
            return new Fraction(left.Fractions - right.Fractions);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Fraction"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Fraction"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Fraction">A <see cref="T:Gu.Units.Fraction"/></param>
        public static Fraction operator -(Fraction Fraction)
        {
            return new Fraction(-1 * Fraction.Fractions);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Fraction"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="Fraction"/>.
        /// </returns>
        /// <param name="Fraction">A <see cref="T:Gu.Units.Fraction"/></param>
        public static Fraction operator +(Fraction Fraction)
        {
            return Fraction;
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
            return this.ToString(format, formatProvider, FractionUnit.Fractions);
        }

        public string ToString(string format, IFormatProvider formatProvider, FractionUnit unit)
        {
            var quantity = unit.FromSiUnit(this.Fractions);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Fraction"/> object and returns an integer that indicates whether this <see cref="instance"/> is shorter than, equal to, or longer than the <see cref="T:MathNet.Spatial.Units.Fraction"/> object.
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.Fraction"/> object to compare to this instance.</param>
        public int CompareTo(Fraction quantity)
        {
            return this.Fractions.CompareTo(quantity.Fractions);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Fraction"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Fraction as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Fraction"/> object to compare with this instance.</param>
        public bool Equals(Fraction other)
        {
            return this.Fractions.Equals(other.Fractions);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Fraction"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Fraction as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Fraction"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Fraction other, double tolerance)
        {
            return Math.Abs(this.Fractions - other.Fractions) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Fraction && this.Equals((Fraction)obj);
        }

        public override int GetHashCode()
        {
            return this.Fractions.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "Fractions", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.Fractions);
        }
    }
}
