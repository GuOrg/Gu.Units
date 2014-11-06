namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Acceleration"/>.
    /// </summary>
    [Serializable]
    public partial struct Acceleration : IComparable<Acceleration>, IEquatable<Acceleration>, IFormattable, IXmlSerializable, IQuantity<LengthUnit, I1, TimeUnit, INeg2>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.MetresPerSecondSquared"/>.
        /// </summary>
        public readonly double MetresPerSecondSquared;

        private Acceleration(double metresPerSecondSquared)
        {
            MetresPerSecondSquared = metresPerSecondSquared;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Acceleration"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.MetresPerSecondSquared"/>.</param>
        public Acceleration(double value, AccelerationUnit unit)
        {
            MetresPerSecondSquared = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in MetresPerSecondSquared
        /// </summary>
        public double SiValue
        {
            get
            {
                return MetresPerSecondSquared;
            }
        }

        /// <summary>
        /// The quantity in millimetresPerSecondSquared
        /// </summary>
        public double MillimetresPerSecondSquared
        {
            get
            {
                return AccelerationUnit.MillimetresPerSecondSquared.FromSiUnit(MetresPerSecondSquared);
            }
        }

        /// <summary>
        /// The quantity in centimetresPerSecondSquared
        /// </summary>
        public double CentimetresPerSecondSquared
        {
            get
            {
                return AccelerationUnit.CentimetresPerSecondSquared.FromSiUnit(MetresPerSecondSquared);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Acceleration"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Acceleration"/></param>
        /// <returns></returns>
        public static Acceleration Parse(string s)
        {
            return Parser.Parse<AccelerationUnit, Acceleration>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Acceleration"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Acceleration"/></returns>
        public static Acceleration ReadFrom(XmlReader reader)
        {
            var v = new Acceleration();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Acceleration"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Acceleration From(double value, AccelerationUnit unit)
        {
            return new Acceleration(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Acceleration"/>.
        /// </summary>
        /// <param name="metresPerSecondSquared">The value in <see cref="T:Gu.Units.MetresPerSecondSquared"/></param>
        public static Acceleration FromMetresPerSecondSquared(double metresPerSecondSquared)
        {
            return new Acceleration(metresPerSecondSquared);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Acceleration"/>.
        /// </summary>
        /// <param name="millimetresPerSecondSquared">The value in mm / s^2</param>
        public static Acceleration FromMillimetresPerSecondSquared(double millimetresPerSecondSquared)
        {
            return From(millimetresPerSecondSquared, AccelerationUnit.MillimetresPerSecondSquared);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Acceleration"/>.
        /// </summary>
        /// <param name="centimetresPerSecondSquared">The value in cm / s^2</param>
        public static Acceleration FromCentimetresPerSecondSquared(double centimetresPerSecondSquared)
        {
            return From(centimetresPerSecondSquared, AccelerationUnit.CentimetresPerSecondSquared);
        }

        public static Force operator *(Acceleration left, Mass right)
        {
            return Force.FromNewtons(left.MetresPerSecondSquared * right.Kilograms);
        }

        public static Speed operator *(Acceleration left, Time right)
        {
            return Speed.FromMetresPerSecond(left.MetresPerSecondSquared * right.Seconds);
        }

        public static Frequency operator /(Acceleration left, Speed right)
        {
            return Frequency.FromHertz(left.MetresPerSecondSquared / right.MetresPerSecond);
        }

        public static SpecificEnergy operator *(Acceleration left, Length right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.MetresPerSecondSquared * right.Metres);
        }

        public static double operator /(Acceleration left, Acceleration right)
        {
            return left.MetresPerSecondSquared / right.MetresPerSecondSquared;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Acceleration"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Acceleration"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Acceleration"/>.</param>
        public static bool operator ==(Acceleration left, Acceleration right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Acceleration"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Acceleration"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Acceleration"/>.</param>
        public static bool operator !=(Acceleration left, Acceleration right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Acceleration"/> is less than another specified <see cref="T:Gu.Units.Acceleration"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Acceleration"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Acceleration"/>.</param>
        public static bool operator <(Acceleration left, Acceleration right)
        {
            return left.MetresPerSecondSquared < right.MetresPerSecondSquared;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Acceleration"/> is greater than another specified <see cref="T:Gu.Units.Acceleration"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Acceleration"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Acceleration"/>.</param>
        public static bool operator >(Acceleration left, Acceleration right)
        {
            return left.MetresPerSecondSquared > right.MetresPerSecondSquared;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Acceleration"/> is less than or equal to another specified <see cref="T:Gu.Units.Acceleration"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Acceleration"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Acceleration"/>.</param>
        public static bool operator <=(Acceleration left, Acceleration right)
        {
            return left.MetresPerSecondSquared <= right.MetresPerSecondSquared;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Acceleration"/> is greater than or equal to another specified <see cref="T:Gu.Units.Acceleration"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Acceleration"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Acceleration"/>.</param>
        public static bool operator >=(Acceleration left, Acceleration right)
        {
            return left.MetresPerSecondSquared >= right.MetresPerSecondSquared;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Acceleration"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Acceleration"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Acceleration"/> with <paramref name="left"/> and returns the result.</returns>
        public static Acceleration operator *(double left, Acceleration right)
        {
            return new Acceleration(left * right.MetresPerSecondSquared);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Acceleration"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Acceleration"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Acceleration"/> with <paramref name="right"/> and returns the result.</returns>
        public static Acceleration operator *(Acceleration left, double right)
        {
            return new Acceleration(left.MetresPerSecondSquared * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Acceleration"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Acceleration"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Acceleration"/> with <paramref name="right"/> and returns the result.</returns>
        public static Acceleration operator /(Acceleration left, double right)
        {
            return new Acceleration(left.MetresPerSecondSquared / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Acceleration"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Acceleration"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Acceleration"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Acceleration operator +(Acceleration left, Acceleration right)
        {
            return new Acceleration(left.MetresPerSecondSquared + right.MetresPerSecondSquared);
        }

        /// <summary>
        /// Subtracts an Acceleration from another Acceleration and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Acceleration"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Acceleration"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.Acceleration"/> (the subtrahend).</param>
        public static Acceleration operator -(Acceleration left, Acceleration right)
        {
            return new Acceleration(left.MetresPerSecondSquared - right.MetresPerSecondSquared);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Acceleration"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Acceleration"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Acceleration">A <see cref="T:Gu.Units.Acceleration"/></param>
        public static Acceleration operator -(Acceleration Acceleration)
        {
            return new Acceleration(-1 * Acceleration.MetresPerSecondSquared);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Acceleration"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="Acceleration"/>.
        /// </returns>
        /// <param name="Acceleration">A <see cref="T:Gu.Units.Acceleration"/></param>
        public static Acceleration operator +(Acceleration Acceleration)
        {
            return Acceleration;
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
            return this.ToString(format, formatProvider, AccelerationUnit.MetresPerSecondSquared);
        }

        public string ToString(string format, IFormatProvider formatProvider, AccelerationUnit unit)
        {
            var quantity = unit.FromSiUnit(this.MetresPerSecondSquared);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Acceleration"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Acceleration"/> object.
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.Acceleration"/> object to compare to this instance.</param>
        public int CompareTo(Acceleration quantity)
        {
            return this.MetresPerSecondSquared.CompareTo(quantity.MetresPerSecondSquared);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Acceleration"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Acceleration as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Acceleration"/> object to compare with this instance.</param>
        public bool Equals(Acceleration other)
        {
            return this.MetresPerSecondSquared.Equals(other.MetresPerSecondSquared);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Acceleration"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Acceleration as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Acceleration"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Acceleration other, double tolerance)
        {
            return Math.Abs(this.MetresPerSecondSquared - other.MetresPerSecondSquared) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Acceleration && this.Equals((Acceleration)obj);
        }

        public override int GetHashCode()
        {
            return this.MetresPerSecondSquared.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "MetresPerSecondSquared", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.MetresPerSecondSquared);
        }
    }
}
