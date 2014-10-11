
namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// An Length
    /// </summary>
    [Serializable]
    public partial struct Length : IComparable<Length>, IEquatable<Length>, IFormattable, IXmlSerializable, IUnitValue
    {
        /// <summary>
        /// The value in <see cref="T:Gu.Units.Meters"/>.
        /// </summary>
        public readonly double Meters;

        private Length(double meters)
        {
            Meters = meters;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="meters"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Meters"/>.</param>
        public Length(double meters, Meters unit)
        {
            Meters = meters;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public Length(double value, Millimeters unit)
        {
            Meters = UnitConverter.ConvertFrom(value, unit);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public Length(double value, Centimeters unit)
        {
            Meters = UnitConverter.ConvertFrom(value, unit);
        }

        /// <summary>
        /// The value in millimeters
        /// </summary>
        public double Millimeters
        {
            get
            {
                return UnitConverter.ConvertTo(Meters, LengthUnit.Millimeters);
            }
        }

        /// <summary>
        /// The value in centimeters
        /// </summary>
        public double Centimeters
        {
            get
            {
                return UnitConverter.ConvertTo(Meters, LengthUnit.Centimeters);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Length"/></param>
        /// <returns></returns>
        public static Length Parse(string s)
        {
            return UnitParser.Parse<ILengthUnit, Length>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Length"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Length"/></returns>
        public static Length ReadFrom(XmlReader reader)
        {
            var v = new Length();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Length From<T>(double value, T unit) where T : ILengthUnit
        {
            return new Length(UnitConverter.ConvertFrom(value, unit));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="value"></param>
        public static Length FromMeters(double value)
        {
            return new Length(value);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="value"></param>
        public static Length FromMillimeters(double value)
        {
            return new Length(UnitConverter.ConvertFrom(value, LengthUnit.Millimeters));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="value"></param>
        public static Length FromCentimeters(double value)
        {
            return new Length(UnitConverter.ConvertFrom(value, LengthUnit.Centimeters));
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Length"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the values of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator ==(Length left, Length right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Length"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the values of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator !=(Length left, Length right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Length"/> is less than another specified <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the value of <paramref name="left"/> is less than the value of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator <(Length left, Length right)
        {
            return left.Meters < right.Meters;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Length"/> is greater than another specified <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the value of <paramref name="left"/> is greater than the value of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator >(Length left, Length right)
        {
            return left.Meters > right.Meters;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Length"/> is less than or equal to another specified <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the value of <paramref name="left"/> is less than or equal to the value of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator <=(Length left, Length right)
        {
            return left.Meters <= right.Meters;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Length"/> is greater than or equal to another specified <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the value of <paramref name="left"/> is greater than or equal to the value of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator >=(Length left, Length right)
        {
            return left.Meters >= right.Meters;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Length"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="left"/> and returns the result.</returns>
        public static Length operator *(double left, Length right)
        {
            return new Length(left * right.Meters);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="right"/> and returns the result.</returns>
        public static Length operator *(Length left, double right)
        {
            return new Length(left.Meters * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="right"/> and returns the result.</returns>
        public static Length operator /(Length left, double right)
        {
            return new Length(left.Meters / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Length"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Length"/> whose value is the sum of the values of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Length operator +(Length left, Length right)
        {
            return new Length(left.Meters + right.Meters);
        }

        /// <summary>
        /// Subtracts an Length from another Length and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Length"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Length"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.Length"/> (the subtrahend).</param>
        public static Length operator -(Length left, Length right)
        {
            return new Length(left.Meters - right.Meters);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Length"/> whose value is the negated value of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Length"/> with the same numeric value as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Length">A <see cref="T:Gu.Units.Length"/></param>
        public static Length operator -(Length Length)
        {
            return new Length(-1 * Length.Meters);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="Length"/>.
        /// </returns>
        /// <param name="Length">A <see cref="T:Gu.Units.Length"/></param>
        public static Length operator +(Length Length)
        {
            return Length;
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
            return this.ToString(format, formatProvider, LengthUnit.Meters);
        }

        public string ToString<T>(string format, IFormatProvider formatProvider, T unit) where T : ILengthUnit
        {
            var value = UnitConverter.ConvertTo(this.Meters, unit);
            return string.Format("{0}{1}", value.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Length"/> object and returns an integer that indicates whether this <see cref="instance"/> is shorter than, equal to, or longer than the <see cref="T:MathNet.Spatial.Units.Length"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative values of this instance and <paramref name="value"/>.
        /// 
        ///                     Value
        /// 
        ///                     Description
        /// 
        ///                     A negative integer
        /// 
        ///                     This instance is smaller than <paramref name="value"/>.
        /// 
        ///                     Zero
        /// 
        ///                     This instance is equal to <paramref name="value"/>.
        /// 
        ///                     A positive integer
        /// 
        ///                     This instance is larger than <paramref name="value"/>.
        /// 
        /// </returns>
        /// <param name="value">A <see cref="T:MathNet.Spatial.Units.Length"/> object to compare to this instance.</param>
        public int CompareTo(Length value)
        {
            return this.Meters.CompareTo(value.Meters);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Length"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Length as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Length"/> object to compare with this instance.</param>
        public bool Equals(Length other)
        {
            return this.Meters.Equals(other.Meters);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Length"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Length as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Length"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Length other, double tolerance)
        {
            return Math.Abs(this.Meters - other.Meters) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Length && this.Equals((Length)obj);
        }

        public override int GetHashCode()
        {
            return this.Meters.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, x => x.Meters, XmlConvert.ToDouble(XmlExt.ReadAttributeOrElementOrDefault(e, "Value")));
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.Meters);
        }
    }
}
