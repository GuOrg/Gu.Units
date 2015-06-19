namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.LuminousIntensity"/>.
    /// </summary>
    [Serializable]
    public partial struct LuminousIntensity : IComparable<LuminousIntensity>, IEquatable<LuminousIntensity>, IFormattable, IXmlSerializable, IQuantity<LuminousIntensityUnit, I1>, IQuantity<LuminousIntensityUnit>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Candelas"/>.
        /// </summary>
        internal readonly double candelas;

        private LuminousIntensity(double candelas)
        {
            this.candelas = candelas;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.LuminousIntensity"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Candelas"/>.</param>
        public LuminousIntensity(double value, LuminousIntensityUnit unit)
        {
            this.candelas = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Candelas
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.candelas;
            }
        }

        /// <summary>
        /// The quantity in candelas".
        /// </summary>
        public double Candelas
        {
            get
            {
                return this.candelas;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.LuminousIntensity"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.LuminousIntensity"/></param>
        /// <returns></returns>
        public static LuminousIntensity Parse(string s)
        {
            return Parser.Parse<LuminousIntensityUnit, LuminousIntensity>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static LuminousIntensity Parse(string s, NumberStyles styles)
        {
            return Parser.Parse<LuminousIntensityUnit, LuminousIntensity>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static LuminousIntensity Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return Parser.Parse<LuminousIntensityUnit, LuminousIntensity>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out LuminousIntensity value)
        {
            return Parser.TryParse<LuminousIntensityUnit, LuminousIntensity>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out LuminousIntensity value)
        {
            return Parser.TryParse<LuminousIntensityUnit, LuminousIntensity>(s, From, styles, CultureInfo.CurrentCulture, out  value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out LuminousIntensity value)
        {
            return Parser.TryParse<LuminousIntensityUnit, LuminousIntensity>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.LuminousIntensity"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.LuminousIntensity"/></returns>
        public static LuminousIntensity ReadFrom(XmlReader reader)
        {
            var v = new LuminousIntensity();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.LuminousIntensity"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static LuminousIntensity From(double value, LuminousIntensityUnit unit)
        {
            return new LuminousIntensity(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.LuminousIntensity"/>.
        /// </summary>
        /// <param name="candelas">The value in <see cref="T:Gu.Units.Candelas"/></param>
        public static LuminousIntensity FromCandelas(double candelas)
        {
            return new LuminousIntensity(candelas);
        }


        public static double operator /(LuminousIntensity left, LuminousIntensity right)
        {
            return left.candelas / right.candelas;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.LuminousIntensity"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        public static bool operator ==(LuminousIntensity left, LuminousIntensity right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.LuminousIntensity"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        public static bool operator !=(LuminousIntensity left, LuminousIntensity right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.LuminousIntensity"/> is less than another specified <see cref="T:Gu.Units.LuminousIntensity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        public static bool operator <(LuminousIntensity left, LuminousIntensity right)
        {
            return left.candelas < right.candelas;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.LuminousIntensity"/> is greater than another specified <see cref="T:Gu.Units.LuminousIntensity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        public static bool operator >(LuminousIntensity left, LuminousIntensity right)
        {
            return left.candelas > right.candelas;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.LuminousIntensity"/> is less than or equal to another specified <see cref="T:Gu.Units.LuminousIntensity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        public static bool operator <=(LuminousIntensity left, LuminousIntensity right)
        {
            return left.candelas <= right.candelas;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.LuminousIntensity"/> is greater than or equal to another specified <see cref="T:Gu.Units.LuminousIntensity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        public static bool operator >=(LuminousIntensity left, LuminousIntensity right)
        {
            return left.candelas >= right.candelas;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.LuminousIntensity"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.LuminousIntensity"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.LuminousIntensity"/> with <paramref name="left"/> and returns the result.</returns>
        public static LuminousIntensity operator *(double left, LuminousIntensity right)
        {
            return new LuminousIntensity(left * right.candelas);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.LuminousIntensity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.LuminousIntensity"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.LuminousIntensity"/> with <paramref name="right"/> and returns the result.</returns>
        public static LuminousIntensity operator *(LuminousIntensity left, double right)
        {
            return new LuminousIntensity(left.candelas * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.LuminousIntensity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.LuminousIntensity"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.LuminousIntensity"/> with <paramref name="right"/> and returns the result.</returns>
        public static LuminousIntensity operator /(LuminousIntensity left, double right)
        {
            return new LuminousIntensity(left.candelas / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.LuminousIntensity"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.LuminousIntensity"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.LuminousIntensity"/>.</param>
        public static LuminousIntensity operator +(LuminousIntensity left, LuminousIntensity right)
        {
            return new LuminousIntensity(left.candelas + right.candelas);
        }

        /// <summary>
        /// Subtracts an LuminousIntensity from another LuminousIntensity and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.LuminousIntensity"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.LuminousIntensity"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.LuminousIntensity"/> (the subtrahend).</param>
        public static LuminousIntensity operator -(LuminousIntensity left, LuminousIntensity right)
        {
            return new LuminousIntensity(left.candelas - right.candelas);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.LuminousIntensity"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.LuminousIntensity"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="luminousIntensity">An instance of <see cref="T:Gu.Units.LuminousIntensity"/></param>
        public static LuminousIntensity operator -(LuminousIntensity luminousIntensity)
        {
            return new LuminousIntensity(-1 * luminousIntensity.candelas);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.LuminousIntensity"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="luminousIntensity"/>.
        /// </returns>
        /// <param name="luminousIntensity">An instance of <see cref="T:Gu.Units.LuminousIntensity"/></param>
        public static LuminousIntensity operator +(LuminousIntensity luminousIntensity)
        {
            return luminousIntensity;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(LuminousIntensityUnit unit)
        {
            return unit.FromSiUnit(this.candelas);
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
            return this.ToString(format, formatProvider, LuminousIntensityUnit.Candelas);
        }

        public string ToString(LuminousIntensityUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, LuminousIntensityUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, LuminousIntensityUnit unit)
        {
            var quantity = unit.FromSiUnit(this.candelas);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.LuminousIntensity"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.LuminousIntensity"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.LuminousIntensity"/> object to compare to this instance.</param>
        public int CompareTo(LuminousIntensity quantity)
        {
            return this.candelas.CompareTo(quantity.candelas);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.LuminousIntensity"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same LuminousIntensity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.LuminousIntensity"/> object to compare with this instance.</param>
        public bool Equals(LuminousIntensity other)
        {
            return this.candelas.Equals(other.candelas);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.LuminousIntensity"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same LuminousIntensity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.LuminousIntensity"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(LuminousIntensity other, double tolerance)
        {
            return Math.Abs(this.candelas - other.candelas) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is LuminousIntensity && this.Equals((LuminousIntensity)obj);
        }

        public override int GetHashCode()
        {
            return this.candelas.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "candelas", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.candelas);
        }
    }
}