namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Resistance"/>.
    /// </summary>
    [Serializable]
    public partial struct Resistance : IComparable<Resistance>, IEquatable<Resistance>, IFormattable, IXmlSerializable, IQuantity<MassUnit, I1, LengthUnit, I2, TimeUnit, INeg3, CurrentUnit, INeg2>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Ohm"/>.
        /// </summary>
        internal readonly double ohm;

        private Resistance(double ohm)
        {
            this.ohm = ohm;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Resistance"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Ohm"/>.</param>
        public Resistance(double value, ResistanceUnit unit)
        {
            this.ohm = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Ohm
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.ohm;
            }
        }

        /// <summary>
        /// The quantity in ohm".
        /// </summary>
        public double Ohm
        {
            get
            {
                return this.ohm;
            }
        }

        /// <summary>
        /// The quantity in microohm
        /// </summary>
        public double Microohm
        {
            get
            {
                return ResistanceUnit.Microohm.FromSiUnit(this.ohm);
            }
        }

        /// <summary>
        /// The quantity in milliohm
        /// </summary>
        public double Milliohm
        {
            get
            {
                return ResistanceUnit.Milliohm.FromSiUnit(this.ohm);
            }
        }

        /// <summary>
        /// The quantity in kiloohm
        /// </summary>
        public double Kiloohm
        {
            get
            {
                return ResistanceUnit.Kiloohm.FromSiUnit(this.ohm);
            }
        }

        /// <summary>
        /// The quantity in megaohm
        /// </summary>
        public double Megaohm
        {
            get
            {
                return ResistanceUnit.Megaohm.FromSiUnit(this.ohm);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Resistance"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Resistance"/></param>
        /// <returns></returns>
        public static Resistance Parse(string s)
        {
            return Parser.Parse<ResistanceUnit, Resistance>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Resistance"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Resistance"/></returns>
        public static Resistance ReadFrom(XmlReader reader)
        {
            var v = new Resistance();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Resistance"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Resistance From(double value, ResistanceUnit unit)
        {
            return new Resistance(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Resistance"/>.
        /// </summary>
        /// <param name="ohm">The value in <see cref="T:Gu.Units.Ohm"/></param>
        public static Resistance FromOhm(double ohm)
        {
            return new Resistance(ohm);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Resistance"/>.
        /// </summary>
        /// <param name="microohm">The value in µΩ</param>
        public static Resistance FromMicroohm(double microohm)
        {
            return From(microohm, ResistanceUnit.Microohm);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Resistance"/>.
        /// </summary>
        /// <param name="milliohm">The value in mΩ</param>
        public static Resistance FromMilliohm(double milliohm)
        {
            return From(milliohm, ResistanceUnit.Milliohm);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Resistance"/>.
        /// </summary>
        /// <param name="kiloohm">The value in kΩ</param>
        public static Resistance FromKiloohm(double kiloohm)
        {
            return From(kiloohm, ResistanceUnit.Kiloohm);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Resistance"/>.
        /// </summary>
        /// <param name="megaohm">The value in MΩ</param>
        public static Resistance FromMegaohm(double megaohm)
        {
            return From(megaohm, ResistanceUnit.Megaohm);
        }

        public static Voltage operator *(Resistance left, Current right)
        {
            return Voltage.FromVolts(left.ohm * right.amperes);
        }

        public static Inductance operator *(Resistance left, Time right)
        {
            return Inductance.FromHenrys(left.ohm * right.seconds);
        }

        public static double operator /(Resistance left, Resistance right)
        {
            return left.ohm / right.ohm;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Resistance"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        public static bool operator ==(Resistance left, Resistance right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Resistance"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        public static bool operator !=(Resistance left, Resistance right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Resistance"/> is less than another specified <see cref="T:Gu.Units.Resistance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        public static bool operator <(Resistance left, Resistance right)
        {
            return left.ohm < right.ohm;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Resistance"/> is greater than another specified <see cref="T:Gu.Units.Resistance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        public static bool operator >(Resistance left, Resistance right)
        {
            return left.ohm > right.ohm;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Resistance"/> is less than or equal to another specified <see cref="T:Gu.Units.Resistance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        public static bool operator <=(Resistance left, Resistance right)
        {
            return left.ohm <= right.ohm;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Resistance"/> is greater than or equal to another specified <see cref="T:Gu.Units.Resistance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        public static bool operator >=(Resistance left, Resistance right)
        {
            return left.ohm >= right.ohm;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Resistance"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Resistance"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Resistance"/> with <paramref name="left"/> and returns the result.</returns>
        public static Resistance operator *(double left, Resistance right)
        {
            return new Resistance(left * right.ohm);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Resistance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Resistance"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Resistance"/> with <paramref name="right"/> and returns the result.</returns>
        public static Resistance operator *(Resistance left, double right)
        {
            return new Resistance(left.ohm * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Resistance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Resistance"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Resistance"/> with <paramref name="right"/> and returns the result.</returns>
        public static Resistance operator /(Resistance left, double right)
        {
            return new Resistance(left.ohm / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Resistance"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Resistance"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Resistance"/>.</param>
        public static Resistance operator +(Resistance left, Resistance right)
        {
            return new Resistance(left.ohm + right.ohm);
        }

        /// <summary>
        /// Subtracts an Resistance from another Resistance and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Resistance"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Resistance"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Resistance"/> (the subtrahend).</param>
        public static Resistance operator -(Resistance left, Resistance right)
        {
            return new Resistance(left.ohm - right.ohm);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Resistance"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Resistance"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="resistance">An instance of <see cref="T:Gu.Units.Resistance"/></param>
        public static Resistance operator -(Resistance resistance)
        {
            return new Resistance(-1 * resistance.ohm);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Resistance"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="resistance"/>.
        /// </returns>
        /// <param name="resistance">An instance of <see cref="T:Gu.Units.Resistance"/></param>
        public static Resistance operator +(Resistance resistance)
        {
            return resistance;
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
            return this.ToString(format, formatProvider, ResistanceUnit.Ohm);
        }

        public string ToString(string format, IFormatProvider formatProvider, ResistanceUnit unit)
        {
            var quantity = unit.FromSiUnit(this.ohm);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Resistance"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Resistance"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.Resistance"/> object to compare to this instance.</param>
        public int CompareTo(Resistance quantity)
        {
            return this.ohm.CompareTo(quantity.ohm);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Resistance"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Resistance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Resistance"/> object to compare with this instance.</param>
        public bool Equals(Resistance other)
        {
            return this.ohm.Equals(other.ohm);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Resistance"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Resistance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Resistance"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Resistance other, double tolerance)
        {
            return Math.Abs(this.ohm - other.ohm) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Resistance && this.Equals((Resistance)obj);
        }

        public override int GetHashCode()
        {
            return this.ohm.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "ohm", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.ohm);
        }
    }
}