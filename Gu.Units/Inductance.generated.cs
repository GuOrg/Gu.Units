namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Inductance"/>.
    /// </summary>
    [Serializable]
    public partial struct Inductance : IComparable<Inductance>, IEquatable<Inductance>, IFormattable, IXmlSerializable, IQuantity<MassUnit, I1, LengthUnit, I2, TimeUnit, INeg2, CurrentUnit, INeg2>, IQuantity<InductanceUnit>
    {
        public static readonly Inductance Zero = new Inductance();

        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Henrys"/>.
        /// </summary>
        internal readonly double henrys;

        private Inductance(double henrys)
        {
            this.henrys = henrys;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Inductance"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Henrys"/>.</param>
        public Inductance(double value, InductanceUnit unit)
        {
            this.henrys = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Henrys
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.henrys;
            }
        }

        /// <summary>
        /// The quantity in henrys".
        /// </summary>
        public double Henrys
        {
            get
            {
                return this.henrys;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Inductance"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Inductance"/></param>
        /// <returns></returns>
		public static Inductance Parse(string s)
        {
            return Parser.Parse<InductanceUnit, Inductance>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static Inductance Parse(string s, IFormatProvider provider)
        {
            return Parser.Parse<InductanceUnit, Inductance>(s, From, NumberStyles.Float, provider);
        }

        public static Inductance Parse(string s, NumberStyles styles)
        {
            return Parser.Parse<InductanceUnit, Inductance>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static Inductance Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return Parser.Parse<InductanceUnit, Inductance>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out Inductance value)
        {
            return Parser.TryParse<InductanceUnit, Inductance>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out Inductance value)
        {
            return Parser.TryParse<InductanceUnit, Inductance>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out Inductance value)
        {
            return Parser.TryParse<InductanceUnit, Inductance>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out Inductance value)
        {
            return Parser.TryParse<InductanceUnit, Inductance>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Inductance"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Inductance"/></returns>
        public static Inductance ReadFrom(XmlReader reader)
        {
            var v = new Inductance();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Inductance"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Inductance From(double value, InductanceUnit unit)
        {
            return new Inductance(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Inductance"/>.
        /// </summary>
        /// <param name="henrys">The value in <see cref="T:Gu.Units.Henrys"/></param>
        public static Inductance FromHenrys(double henrys)
        {
            return new Inductance(henrys);
        }


        public static Resistance operator /(Inductance left, Time right)
        {
            return Resistance.FromOhm(left.henrys / right.seconds);
        }

        public static double operator /(Inductance left, Inductance right)
        {
            return left.henrys / right.henrys;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Inductance"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        public static bool operator ==(Inductance left, Inductance right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Inductance"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        public static bool operator !=(Inductance left, Inductance right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Inductance"/> is less than another specified <see cref="T:Gu.Units.Inductance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        public static bool operator <(Inductance left, Inductance right)
        {
            return left.henrys < right.henrys;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Inductance"/> is greater than another specified <see cref="T:Gu.Units.Inductance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        public static bool operator >(Inductance left, Inductance right)
        {
            return left.henrys > right.henrys;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Inductance"/> is less than or equal to another specified <see cref="T:Gu.Units.Inductance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        public static bool operator <=(Inductance left, Inductance right)
        {
            return left.henrys <= right.henrys;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Inductance"/> is greater than or equal to another specified <see cref="T:Gu.Units.Inductance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        public static bool operator >=(Inductance left, Inductance right)
        {
            return left.henrys >= right.henrys;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Inductance"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Inductance"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Inductance"/> with <paramref name="left"/> and returns the result.</returns>
        public static Inductance operator *(double left, Inductance right)
        {
            return new Inductance(left * right.henrys);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Inductance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Inductance"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Inductance"/> with <paramref name="right"/> and returns the result.</returns>
        public static Inductance operator *(Inductance left, double right)
        {
            return new Inductance(left.henrys * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Inductance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Inductance"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Inductance"/> with <paramref name="right"/> and returns the result.</returns>
        public static Inductance operator /(Inductance left, double right)
        {
            return new Inductance(left.henrys / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Inductance"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Inductance"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Inductance"/>.</param>
        public static Inductance operator +(Inductance left, Inductance right)
        {
            return new Inductance(left.henrys + right.henrys);
        }

        /// <summary>
        /// Subtracts an Inductance from another Inductance and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Inductance"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Inductance"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Inductance"/> (the subtrahend).</param>
        public static Inductance operator -(Inductance left, Inductance right)
        {
            return new Inductance(left.henrys - right.henrys);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Inductance"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Inductance"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="inductance">An instance of <see cref="T:Gu.Units.Inductance"/></param>
        public static Inductance operator -(Inductance inductance)
        {
            return new Inductance(-1 * inductance.henrys);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Inductance"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="inductance"/>.
        /// </returns>
        /// <param name="inductance">An instance of <see cref="T:Gu.Units.Inductance"/></param>
        public static Inductance operator +(Inductance inductance)
        {
            return inductance;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(InductanceUnit unit)
        {
            return unit.FromSiUnit(this.henrys);
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
            return this.ToString(format, formatProvider, InductanceUnit.Henrys);
        }

        public string ToString(InductanceUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, InductanceUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, InductanceUnit unit)
        {
            var quantity = unit.FromSiUnit(this.henrys);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Inductance"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Inductance"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.Inductance"/> object to compare to this instance.</param>
        public int CompareTo(Inductance quantity)
        {
            return this.henrys.CompareTo(quantity.henrys);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Inductance"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Inductance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Inductance"/> object to compare with this instance.</param>
        public bool Equals(Inductance other)
        {
            return this.henrys.Equals(other.henrys);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Inductance"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Inductance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Inductance"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Inductance other, double tolerance)
        {
            return Math.Abs(this.henrys - other.henrys) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Inductance && this.Equals((Inductance)obj);
        }

        public override int GetHashCode()
        {
            return this.henrys.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "henrys", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.henrys);
        }
    }
}