
namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity Length
    /// </summary>
    [Serializable]
    public partial struct Length : IComparable<Length>, IEquatable<Length>, IFormattable, IXmlSerializable, IQuantity<LengthUnit, I1>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Metres"/>.
        /// </summary>
        public readonly double Metres;

        private Length(double metres)
        {
            Metres = metres;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Metres"/>.</param>
        public Length(double value, LengthUnit unit)
        {
            Metres = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Metres
        /// </summary>
        public double SiValue
        {
            get
            {
                return Metres;
            }
        }


        /// <summary>
        /// The quantity in nanometres
        /// </summary>
        public double Nanometres
        {
            get
            {
                return LengthUnit.Nanometres.FromSiUnit(Metres);
            }
        }

        /// <summary>
        /// The quantity in micrometres
        /// </summary>
        public double Micrometres
        {
            get
            {
                return LengthUnit.Micrometres.FromSiUnit(Metres);
            }
        }

        /// <summary>
        /// The quantity in millimetres
        /// </summary>
        public double Millimetres
        {
            get
            {
                return LengthUnit.Millimetres.FromSiUnit(Metres);
            }
        }

        /// <summary>
        /// The quantity in centimetres
        /// </summary>
        public double Centimetres
        {
            get
            {
                return LengthUnit.Centimetres.FromSiUnit(Metres);
            }
        }

        /// <summary>
        /// The quantity in decimetres
        /// </summary>
        public double Decimetres
        {
            get
            {
                return LengthUnit.Decimetres.FromSiUnit(Metres);
            }
        }

        /// <summary>
        /// The quantity in kilometres
        /// </summary>
        public double Kilometres
        {
            get
            {
                return LengthUnit.Kilometres.FromSiUnit(Metres);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Length"/></param>
        /// <returns></returns>
        public static Length Parse(string s)
        {
            return Parser.Parse<LengthUnit, Length>(s, From);
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
        /// <param name="quantity"></param>
        /// <param name="unit"></param>
        public static Length From(double value, LengthUnit unit)
        {
            return new Length(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Length FromMetres(double value)
        {
            return new Length(value);
        }


        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Length FromNanometres(double value)
        {
            return From(value, LengthUnit.Nanometres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Length FromMicrometres(double value)
        {
            return From(value, LengthUnit.Micrometres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Length FromMillimetres(double value)
        {
            return From(value, LengthUnit.Millimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Length FromCentimetres(double value)
        {
            return From(value, LengthUnit.Centimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Length FromDecimetres(double value)
        {
            return From(value, LengthUnit.Decimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Length FromKilometres(double value)
        {
            return From(value, LengthUnit.Kilometres);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Length"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
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
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
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
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator <(Length left, Length right)
        {
            return left.Metres < right.Metres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Length"/> is greater than another specified <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator >(Length left, Length right)
        {
            return left.Metres > right.Metres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Length"/> is less than or equal to another specified <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator <=(Length left, Length right)
        {
            return left.Metres <= right.Metres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Length"/> is greater than or equal to another specified <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator >=(Length left, Length right)
        {
            return left.Metres >= right.Metres;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Length"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="left"/> and returns the result.</returns>
        public static Length operator *(double left, Length right)
        {
            return new Length(left * right.Metres);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="right"/> and returns the result.</returns>
        public static Length operator *(Length left, double right)
        {
            return new Length(left.Metres * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="right"/> and returns the result.</returns>
        public static Length operator /(Length left, double right)
        {
            return new Length(left.Metres / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Length"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Length"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Length operator +(Length left, Length right)
        {
            return new Length(left.Metres + right.Metres);
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
            return new Length(left.Metres - right.Metres);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Length"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Length"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Length">A <see cref="T:Gu.Units.Length"/></param>
        public static Length operator -(Length Length)
        {
            return new Length(-1 * Length.Metres);
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
            return this.ToString(format, formatProvider, LengthUnit.Metres);
        }

        public string ToString(string format, IFormatProvider formatProvider, LengthUnit unit)
        {
            var quantity = unit.FromSiUnit(this.Metres);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Length"/> object and returns an integer that indicates whether this <see cref="instance"/> is shorter than, equal to, or longer than the <see cref="T:MathNet.Spatial.Units.Length"/> object.
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.Length"/> object to compare to this instance.</param>
        public int CompareTo(Length quantity)
        {
            return this.Metres.CompareTo(quantity.Metres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Length"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Length as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Length"/> object to compare with this instance.</param>
        public bool Equals(Length other)
        {
            return this.Metres.Equals(other.Metres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Length"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Length as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Length"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Length other, double tolerance)
        {
            return Math.Abs(this.Metres - other.Metres) < tolerance;
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
            return this.Metres.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, x => x.Metres, XmlConvert.ToDouble(XmlExt.ReadAttributeOrElementOrDefault(e, "Value")));
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.Metres);
        }
    }
}
