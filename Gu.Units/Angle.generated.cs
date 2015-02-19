namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Angle"/>.
    /// </summary>
    [Serializable]
    public partial struct Angle : IComparable<Angle>, IEquatable<Angle>, IFormattable, IXmlSerializable, IQuantity<AngleUnit, I1>, IQuantity<AngleUnit>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Radians"/>.
        /// </summary>
        internal readonly double radians;

        private Angle(double radians)
        {
            this.radians = radians;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Angle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Radians"/>.</param>
        public Angle(double value, AngleUnit unit)
        {
            this.radians = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Radians
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.radians;
            }
        }

        /// <summary>
        /// The quantity in radians".
        /// </summary>
        public double Radians
        {
            get
            {
                return this.radians;
            }
        }

        /// <summary>
        /// The quantity in degrees
        /// </summary>
        public double Degrees
        {
            get
            {
                return AngleUnit.Degrees.FromSiUnit(this.radians);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Angle"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Angle"/></param>
        /// <returns></returns>
        public static Angle Parse(string s)
        {
            return Parser.Parse<AngleUnit, Angle>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Angle"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Angle"/></returns>
        public static Angle ReadFrom(XmlReader reader)
        {
            var v = new Angle();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Angle"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Angle From(double value, AngleUnit unit)
        {
            return new Angle(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Angle"/>.
        /// </summary>
        /// <param name="radians">The value in <see cref="T:Gu.Units.Radians"/></param>
        public static Angle FromRadians(double radians)
        {
            return new Angle(radians);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Angle"/>.
        /// </summary>
        /// <param name="degrees">The value in °</param>
        public static Angle FromDegrees(double degrees)
        {
            return From(degrees, AngleUnit.Degrees);
        }

        public static Time operator /(Angle left, AngularSpeed right)
        {
            return Time.FromSeconds(left.radians / right.radiansPerSecond);
        }

        public static AngularSpeed operator /(Angle left, Time right)
        {
            return AngularSpeed.FromRadiansPerSecond(left.radians / right.seconds);
        }

        public static double operator /(Angle left, Angle right)
        {
            return left.radians / right.radians;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Angle"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        public static bool operator ==(Angle left, Angle right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Angle"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        public static bool operator !=(Angle left, Angle right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Angle"/> is less than another specified <see cref="T:Gu.Units.Angle"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        public static bool operator <(Angle left, Angle right)
        {
            return left.radians < right.radians;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Angle"/> is greater than another specified <see cref="T:Gu.Units.Angle"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        public static bool operator >(Angle left, Angle right)
        {
            return left.radians > right.radians;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Angle"/> is less than or equal to another specified <see cref="T:Gu.Units.Angle"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        public static bool operator <=(Angle left, Angle right)
        {
            return left.radians <= right.radians;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Angle"/> is greater than or equal to another specified <see cref="T:Gu.Units.Angle"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        public static bool operator >=(Angle left, Angle right)
        {
            return left.radians >= right.radians;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Angle"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Angle"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Angle"/> with <paramref name="left"/> and returns the result.</returns>
        public static Angle operator *(double left, Angle right)
        {
            return new Angle(left * right.radians);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Angle"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Angle"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Angle"/> with <paramref name="right"/> and returns the result.</returns>
        public static Angle operator *(Angle left, double right)
        {
            return new Angle(left.radians * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Angle"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Angle"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Angle"/> with <paramref name="right"/> and returns the result.</returns>
        public static Angle operator /(Angle left, double right)
        {
            return new Angle(left.radians / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Angle"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Angle"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Angle"/>.</param>
        public static Angle operator +(Angle left, Angle right)
        {
            return new Angle(left.radians + right.radians);
        }

        /// <summary>
        /// Subtracts an Angle from another Angle and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Angle"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Angle"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Angle"/> (the subtrahend).</param>
        public static Angle operator -(Angle left, Angle right)
        {
            return new Angle(left.radians - right.radians);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Angle"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Angle"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="angle">An instance of <see cref="T:Gu.Units.Angle"/></param>
        public static Angle operator -(Angle angle)
        {
            return new Angle(-1 * angle.radians);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Angle"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="angle"/>.
        /// </returns>
        /// <param name="angle">An instance of <see cref="T:Gu.Units.Angle"/></param>
        public static Angle operator +(Angle angle)
        {
            return angle;
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
            return this.ToString(format, formatProvider, AngleUnit.Radians);
        }

        public string ToString(AngleUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, AngleUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, AngleUnit unit)
        {
            var quantity = unit.FromSiUnit(this.radians);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Angle"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Angle"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.Angle"/> object to compare to this instance.</param>
        public int CompareTo(Angle quantity)
        {
            return this.radians.CompareTo(quantity.radians);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Angle"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Angle as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Angle"/> object to compare with this instance.</param>
        public bool Equals(Angle other)
        {
            return this.radians.Equals(other.radians);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Angle"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Angle as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Angle"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Angle other, double tolerance)
        {
            return Math.Abs(this.radians - other.radians) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Angle && this.Equals((Angle)obj);
        }

        public override int GetHashCode()
        {
            return this.radians.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "radians", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.radians);
        }
    }
}