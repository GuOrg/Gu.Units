namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.AngularSpeed"/>.
    /// </summary>
    [Serializable]
    public partial struct AngularSpeed : IComparable<AngularSpeed>, IEquatable<AngularSpeed>, IFormattable, IXmlSerializable, IQuantity<AngleUnit, I1, TimeUnit, INeg1>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.RadiansPerSecond"/>.
        /// </summary>
        public readonly double RadiansPerSecond;

        private AngularSpeed(double radiansPerSecond)
        {
            RadiansPerSecond = radiansPerSecond;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.RadiansPerSecond"/>.</param>
        public AngularSpeed(double value, AngularSpeedUnit unit)
        {
            RadiansPerSecond = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in RadiansPerSecond
        /// </summary>
        public double SiValue
        {
            get
            {
                return RadiansPerSecond;
            }
        }

        /// <summary>
        /// The quantity in revolutionsPerMinute
        /// </summary>
        public double RevolutionsPerMinute
        {
            get
            {
                return AngularSpeedUnit.RevolutionsPerMinute.FromSiUnit(RadiansPerSecond);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.AngularSpeed"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.AngularSpeed"/></param>
        /// <returns></returns>
        public static AngularSpeed Parse(string s)
        {
            return Parser.Parse<AngularSpeedUnit, AngularSpeed>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.AngularSpeed"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.AngularSpeed"/></returns>
        public static AngularSpeed ReadFrom(XmlReader reader)
        {
            var v = new AngularSpeed();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static AngularSpeed From(double value, AngularSpeedUnit unit)
        {
            return new AngularSpeed(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <param name="radiansPerSecond">The value in <see cref="T:Gu.Units.RadiansPerSecond"/></param>
        public static AngularSpeed FromRadiansPerSecond(double radiansPerSecond)
        {
            return new AngularSpeed(radiansPerSecond);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <param name="revolutionsPerMinute">The value in rpm</param>
        public static AngularSpeed FromRevolutionsPerMinute(double revolutionsPerMinute)
        {
            return From(revolutionsPerMinute, AngularSpeedUnit.RevolutionsPerMinute);
        }

        public static Angle operator *(AngularSpeed left, Time right)
        {
            return Angle.FromRadians(left.RadiansPerSecond * right.Seconds);
        }

        public static Frequency operator /(AngularSpeed left, Angle right)
        {
            return Frequency.FromHertz(left.RadiansPerSecond / right.Radians);
        }


        public static double operator /(AngularSpeed left, AngularSpeed right)
        {
            return left.RadiansPerSecond / right.RadiansPerSecond;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.AngularSpeed"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.AngularSpeed"/>.</param>
        public static bool operator ==(AngularSpeed left, AngularSpeed right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.AngularSpeed"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.AngularSpeed"/>.</param>
        public static bool operator !=(AngularSpeed left, AngularSpeed right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.AngularSpeed"/> is less than another specified <see cref="T:Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.AngularSpeed"/>.</param>
        public static bool operator <(AngularSpeed left, AngularSpeed right)
        {
            return left.RadiansPerSecond < right.RadiansPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.AngularSpeed"/> is greater than another specified <see cref="T:Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.AngularSpeed"/>.</param>
        public static bool operator >(AngularSpeed left, AngularSpeed right)
        {
            return left.RadiansPerSecond > right.RadiansPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.AngularSpeed"/> is less than or equal to another specified <see cref="T:Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.AngularSpeed"/>.</param>
        public static bool operator <=(AngularSpeed left, AngularSpeed right)
        {
            return left.RadiansPerSecond <= right.RadiansPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.AngularSpeed"/> is greater than or equal to another specified <see cref="T:Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.AngularSpeed"/>.</param>
        public static bool operator >=(AngularSpeed left, AngularSpeed right)
        {
            return left.RadiansPerSecond >= right.RadiansPerSecond;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.AngularSpeed"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.AngularSpeed"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.AngularSpeed"/> with <paramref name="left"/> and returns the result.</returns>
        public static AngularSpeed operator *(double left, AngularSpeed right)
        {
            return new AngularSpeed(left * right.RadiansPerSecond);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.AngularSpeed"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularSpeed"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.AngularSpeed"/> with <paramref name="right"/> and returns the result.</returns>
        public static AngularSpeed operator *(AngularSpeed left, double right)
        {
            return new AngularSpeed(left.RadiansPerSecond * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.AngularSpeed"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularSpeed"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.AngularSpeed"/> with <paramref name="right"/> and returns the result.</returns>
        public static AngularSpeed operator /(AngularSpeed left, double right)
        {
            return new AngularSpeed(left.RadiansPerSecond / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.AngularSpeed"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.AngularSpeed"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.AngularSpeed"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static AngularSpeed operator +(AngularSpeed left, AngularSpeed right)
        {
            return new AngularSpeed(left.RadiansPerSecond + right.RadiansPerSecond);
        }

        /// <summary>
        /// Subtracts an AngularSpeed from another AngularSpeed and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.AngularSpeed"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.AngularSpeed"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.AngularSpeed"/> (the subtrahend).</param>
        public static AngularSpeed operator -(AngularSpeed left, AngularSpeed right)
        {
            return new AngularSpeed(left.RadiansPerSecond - right.RadiansPerSecond);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.AngularSpeed"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.AngularSpeed"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="AngularSpeed">A <see cref="T:Gu.Units.AngularSpeed"/></param>
        public static AngularSpeed operator -(AngularSpeed AngularSpeed)
        {
            return new AngularSpeed(-1 * AngularSpeed.RadiansPerSecond);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.AngularSpeed"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="AngularSpeed"/>.
        /// </returns>
        /// <param name="AngularSpeed">A <see cref="T:Gu.Units.AngularSpeed"/></param>
        public static AngularSpeed operator +(AngularSpeed AngularSpeed)
        {
            return AngularSpeed;
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
            return this.ToString(format, formatProvider, AngularSpeedUnit.RadiansPerSecond);
        }

        public string ToString(string format, IFormatProvider formatProvider, AngularSpeedUnit unit)
        {
            var quantity = unit.FromSiUnit(this.RadiansPerSecond);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.AngularSpeed"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.AngularSpeed"/> object.
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.AngularSpeed"/> object to compare to this instance.</param>
        public int CompareTo(AngularSpeed quantity)
        {
            return this.RadiansPerSecond.CompareTo(quantity.RadiansPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.AngularSpeed"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularSpeed as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.AngularSpeed"/> object to compare with this instance.</param>
        public bool Equals(AngularSpeed other)
        {
            return this.RadiansPerSecond.Equals(other.RadiansPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.AngularSpeed"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularSpeed as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.AngularSpeed"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(AngularSpeed other, double tolerance)
        {
            return Math.Abs(this.RadiansPerSecond - other.RadiansPerSecond) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngularSpeed && this.Equals((AngularSpeed)obj);
        }

        public override int GetHashCode()
        {
            return this.RadiansPerSecond.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "RadiansPerSecond", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.RadiansPerSecond);
        }
    }
}
