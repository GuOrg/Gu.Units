namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.AngularVelocity"/>.
    /// </summary>
    [Serializable]
    public partial struct AngularVelocity : IComparable<AngularVelocity>, IEquatable<AngularVelocity>, IFormattable, IXmlSerializable, IQuantity<AngleUnit, I1, TimeUnit, INeg1>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.RadiansPerSecond"/>.
        /// </summary>
        public readonly double RadiansPerSecond;

        private AngularVelocity(double radiansPerSecond)
        {
            RadiansPerSecond = radiansPerSecond;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.AngularVelocity"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.RadiansPerSecond"/>.</param>
        public AngularVelocity(double value, AngularVelocityUnit unit)
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
        /// Creates an instance of <see cref="T:Gu.Units.AngularVelocity"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.AngularVelocity"/></param>
        /// <returns></returns>
        public static AngularVelocity Parse(string s)
        {
            return Parser.Parse<AngularVelocityUnit, AngularVelocity>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.AngularVelocity"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.AngularVelocity"/></returns>
        public static AngularVelocity ReadFrom(XmlReader reader)
        {
            var v = new AngularVelocity();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.AngularVelocity"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static AngularVelocity From(double value, AngularVelocityUnit unit)
        {
            return new AngularVelocity(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.AngularVelocity"/>.
        /// </summary>
        /// <param name="radiansPerSecond">The value in <see cref="T:Gu.Units.RadiansPerSecond"/></param>
        public static AngularVelocity FromRadiansPerSecond(double radiansPerSecond)
        {
            return new AngularVelocity(radiansPerSecond);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.AngularVelocity"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.AngularVelocity"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.AngularVelocity"/>.</param>
        public static bool operator ==(AngularVelocity left, AngularVelocity right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.AngularVelocity"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.AngularVelocity"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.AngularVelocity"/>.</param>
        public static bool operator !=(AngularVelocity left, AngularVelocity right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.AngularVelocity"/> is less than another specified <see cref="T:Gu.Units.AngularVelocity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.AngularVelocity"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.AngularVelocity"/>.</param>
        public static bool operator <(AngularVelocity left, AngularVelocity right)
        {
            return left.RadiansPerSecond < right.RadiansPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.AngularVelocity"/> is greater than another specified <see cref="T:Gu.Units.AngularVelocity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.AngularVelocity"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.AngularVelocity"/>.</param>
        public static bool operator >(AngularVelocity left, AngularVelocity right)
        {
            return left.RadiansPerSecond > right.RadiansPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.AngularVelocity"/> is less than or equal to another specified <see cref="T:Gu.Units.AngularVelocity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.AngularVelocity"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.AngularVelocity"/>.</param>
        public static bool operator <=(AngularVelocity left, AngularVelocity right)
        {
            return left.RadiansPerSecond <= right.RadiansPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.AngularVelocity"/> is greater than or equal to another specified <see cref="T:Gu.Units.AngularVelocity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.AngularVelocity"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.AngularVelocity"/>.</param>
        public static bool operator >=(AngularVelocity left, AngularVelocity right)
        {
            return left.RadiansPerSecond >= right.RadiansPerSecond;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.AngularVelocity"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.AngularVelocity"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.AngularVelocity"/> with <paramref name="left"/> and returns the result.</returns>
        public static AngularVelocity operator *(double left, AngularVelocity right)
        {
            return new AngularVelocity(left * right.RadiansPerSecond);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.AngularVelocity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularVelocity"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.AngularVelocity"/> with <paramref name="right"/> and returns the result.</returns>
        public static AngularVelocity operator *(AngularVelocity left, double right)
        {
            return new AngularVelocity(left.RadiansPerSecond * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.AngularVelocity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularVelocity"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.AngularVelocity"/> with <paramref name="right"/> and returns the result.</returns>
        public static AngularVelocity operator /(AngularVelocity left, double right)
        {
            return new AngularVelocity(left.RadiansPerSecond / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.AngularVelocity"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.AngularVelocity"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.AngularVelocity"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static AngularVelocity operator +(AngularVelocity left, AngularVelocity right)
        {
            return new AngularVelocity(left.RadiansPerSecond + right.RadiansPerSecond);
        }

        /// <summary>
        /// Subtracts an AngularVelocity from another AngularVelocity and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.AngularVelocity"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.AngularVelocity"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.AngularVelocity"/> (the subtrahend).</param>
        public static AngularVelocity operator -(AngularVelocity left, AngularVelocity right)
        {
            return new AngularVelocity(left.RadiansPerSecond - right.RadiansPerSecond);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.AngularVelocity"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.AngularVelocity"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="AngularVelocity">A <see cref="T:Gu.Units.AngularVelocity"/></param>
        public static AngularVelocity operator -(AngularVelocity AngularVelocity)
        {
            return new AngularVelocity(-1 * AngularVelocity.RadiansPerSecond);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.AngularVelocity"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="AngularVelocity"/>.
        /// </returns>
        /// <param name="AngularVelocity">A <see cref="T:Gu.Units.AngularVelocity"/></param>
        public static AngularVelocity operator +(AngularVelocity AngularVelocity)
        {
            return AngularVelocity;
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
            return this.ToString(format, formatProvider, AngularVelocityUnit.RadiansPerSecond);
        }

        public string ToString(string format, IFormatProvider formatProvider, AngularVelocityUnit unit)
        {
            var quantity = unit.FromSiUnit(this.RadiansPerSecond);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.AngularVelocity"/> object and returns an integer that indicates whether this <see cref="instance"/> is shorter than, equal to, or longer than the <see cref="T:MathNet.Spatial.Units.AngularVelocity"/> object.
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.AngularVelocity"/> object to compare to this instance.</param>
        public int CompareTo(AngularVelocity quantity)
        {
            return this.RadiansPerSecond.CompareTo(quantity.RadiansPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.AngularVelocity"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularVelocity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.AngularVelocity"/> object to compare with this instance.</param>
        public bool Equals(AngularVelocity other)
        {
            return this.RadiansPerSecond.Equals(other.RadiansPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.AngularVelocity"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularVelocity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.AngularVelocity"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(AngularVelocity other, double tolerance)
        {
            return Math.Abs(this.RadiansPerSecond - other.RadiansPerSecond) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngularVelocity && this.Equals((AngularVelocity)obj);
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
            reader.MoveToContent();
            var e = (XElement)XNode.ReadFrom(reader);

            // Hacking set readonly fields here, can't think of a cleaner workaround
            XmlExt.SetReadonlyField(ref this, x => x.RadiansPerSecond, XmlConvert.ToDouble(XmlExt.ReadAttributeOrElementOrDefault(e, "Value")));
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
