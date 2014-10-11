
namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// An Mass
    /// </summary>
    [Serializable]
    public partial struct Mass : IComparable<Mass>, IEquatable<Mass>, IFormattable, IXmlSerializable, IUnitValue
    {
        /// <summary>
        /// The value in <see cref="T:Gu.Units.Kilograms"/>.
        /// </summary>
        public readonly double Kilograms;

        private Mass(double kilograms)
        {
            Kilograms = kilograms;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="kilograms"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Kilograms"/>.</param>
        public Mass(double kilograms, Kilograms unit)
        {
            Kilograms = kilograms;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public Mass(double value, Grams unit)
        {
            Kilograms = UnitConverter.ConvertFrom(value, unit);
        }

        /// <summary>
        /// The value in grams
        /// </summary>
        public double Grams
        {
            get
            {
                return UnitConverter.ConvertTo(Kilograms, MassUnit.Grams);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Mass"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Mass"/></param>
        /// <returns></returns>
        public static Mass Parse(string s)
        {
            return Parser.Parse<IMassUnit, Mass>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Mass"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Mass"/></returns>
        public static Mass ReadFrom(XmlReader reader)
        {
            var v = new Mass();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Mass From<T>(double value, T unit) where T : IMassUnit
        {
            return new Mass(UnitConverter.ConvertFrom(value, unit));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="value"></param>
        public static Mass FromKilograms(double value)
        {
            return new Mass(value);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="value"></param>
        public static Mass FromGrams(double value)
        {
            return new Mass(UnitConverter.ConvertFrom(value, MassUnit.Grams));
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Mass"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the values of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Mass"/>.</param>
        public static bool operator ==(Mass left, Mass right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Mass"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the values of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Mass"/>.</param>
        public static bool operator !=(Mass left, Mass right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Mass"/> is less than another specified <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// true if the value of <paramref name="left"/> is less than the value of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Mass"/>.</param>
        public static bool operator <(Mass left, Mass right)
        {
            return left.Kilograms < right.Kilograms;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Mass"/> is greater than another specified <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// true if the value of <paramref name="left"/> is greater than the value of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Mass"/>.</param>
        public static bool operator >(Mass left, Mass right)
        {
            return left.Kilograms > right.Kilograms;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Mass"/> is less than or equal to another specified <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// true if the value of <paramref name="left"/> is less than or equal to the value of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Mass"/>.</param>
        public static bool operator <=(Mass left, Mass right)
        {
            return left.Kilograms <= right.Kilograms;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Mass"/> is greater than or equal to another specified <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// true if the value of <paramref name="left"/> is greater than or equal to the value of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Mass"/>.</param>
        public static bool operator >=(Mass left, Mass right)
        {
            return left.Kilograms >= right.Kilograms;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Mass"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Mass"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Mass"/> with <paramref name="left"/> and returns the result.</returns>
        public static Mass operator *(double left, Mass right)
        {
            return new Mass(left * right.Kilograms);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Mass"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Mass"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Mass"/> with <paramref name="right"/> and returns the result.</returns>
        public static Mass operator *(Mass left, double right)
        {
            return new Mass(left.Kilograms * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Mass"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Mass"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Mass"/> with <paramref name="right"/> and returns the result.</returns>
        public static Mass operator /(Mass left, double right)
        {
            return new Mass(left.Kilograms / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Mass"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Mass"/> whose value is the sum of the values of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Mass operator +(Mass left, Mass right)
        {
            return new Mass(left.Kilograms + right.Kilograms);
        }

        /// <summary>
        /// Subtracts an Mass from another Mass and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Mass"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Mass"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.Mass"/> (the subtrahend).</param>
        public static Mass operator -(Mass left, Mass right)
        {
            return new Mass(left.Kilograms - right.Kilograms);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Mass"/> whose value is the negated value of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Mass"/> with the same numeric value as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Mass">A <see cref="T:Gu.Units.Mass"/></param>
        public static Mass operator -(Mass Mass)
        {
            return new Mass(-1 * Mass.Kilograms);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="Mass"/>.
        /// </returns>
        /// <param name="Mass">A <see cref="T:Gu.Units.Mass"/></param>
        public static Mass operator +(Mass Mass)
        {
            return Mass;
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
            return this.ToString(format, formatProvider, MassUnit.Kilograms);
        }

        public string ToString<T>(string format, IFormatProvider formatProvider, T unit) where T : IMassUnit
        {
            var value = UnitConverter.ConvertTo(this.Kilograms, unit);
            return string.Format("{0}{1}", value.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Mass"/> object and returns an integer that indicates whether this <see cref="instance"/> is shorter than, equal to, or longer than the <see cref="T:MathNet.Spatial.Units.Mass"/> object.
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
        /// <param name="value">A <see cref="T:MathNet.Spatial.Units.Mass"/> object to compare to this instance.</param>
        public int CompareTo(Mass value)
        {
            return this.Kilograms.CompareTo(value.Kilograms);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Mass"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Mass as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Mass"/> object to compare with this instance.</param>
        public bool Equals(Mass other)
        {
            return this.Kilograms.Equals(other.Kilograms);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Mass"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Mass as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Mass"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Mass other, double tolerance)
        {
            return Math.Abs(this.Kilograms - other.Kilograms) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Mass && this.Equals((Mass)obj);
        }

        public override int GetHashCode()
        {
            return this.Kilograms.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, x => x.Kilograms, XmlConvert.ToDouble(XmlExt.ReadAttributeOrElementOrDefault(e, "Value")));
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.Kilograms);
        }
    }
}
