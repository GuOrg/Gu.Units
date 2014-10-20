namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Frequency"/>.
    /// </summary>
    [Serializable]
    public partial struct Frequency : IComparable<Frequency>, IEquatable<Frequency>, IFormattable, IXmlSerializable, IQuantity<TimeUnit, INeg1>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Hertz"/>.
        /// </summary>
        public readonly double Hertz;

        private Frequency(double hertz)
        {
            Hertz = hertz;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Hertz"/>.</param>
        public Frequency(double value, FrequencyUnit unit)
        {
            Hertz = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Hertz
        /// </summary>
        public double SiValue
        {
            get
            {
                return Hertz;
            }
        }

        /// <summary>
        /// The quantity in millihertz
        /// </summary>
        public double Millihertz
        {
            get
            {
                return FrequencyUnit.Millihertz.FromSiUnit(Hertz);
            }
        }

        /// <summary>
        /// The quantity in kilohertz
        /// </summary>
        public double Kilohertz
        {
            get
            {
                return FrequencyUnit.Kilohertz.FromSiUnit(Hertz);
            }
        }

        /// <summary>
        /// The quantity in megahertz
        /// </summary>
        public double Megahertz
        {
            get
            {
                return FrequencyUnit.Megahertz.FromSiUnit(Hertz);
            }
        }

        /// <summary>
        /// The quantity in gigahertz
        /// </summary>
        public double Gigahertz
        {
            get
            {
                return FrequencyUnit.Gigahertz.FromSiUnit(Hertz);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Frequency"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Frequency"/></param>
        /// <returns></returns>
        public static Frequency Parse(string s)
        {
            return Parser.Parse<FrequencyUnit, Frequency>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Frequency"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Frequency"/></returns>
        public static Frequency ReadFrom(XmlReader reader)
        {
            var v = new Frequency();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Frequency From(double value, FrequencyUnit unit)
        {
            return new Frequency(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="hertz">The value in <see cref="T:Gu.Units.Hertz"/></param>
        public static Frequency FromHertz(double hertz)
        {
            return new Frequency(hertz);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="millihertz">The value in mHz</param>
        public static Frequency FromMillihertz(double millihertz)
        {
            return From(millihertz, FrequencyUnit.Millihertz);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="kilohertz">The value in kHz</param>
        public static Frequency FromKilohertz(double kilohertz)
        {
            return From(kilohertz, FrequencyUnit.Kilohertz);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="megahertz">The value in MHz</param>
        public static Frequency FromMegahertz(double megahertz)
        {
            return From(megahertz, FrequencyUnit.Megahertz);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="gigahertz">The value in GHz</param>
        public static Frequency FromGigahertz(double gigahertz)
        {
            return From(gigahertz, FrequencyUnit.Gigahertz);
        }

        public static Current operator *(Frequency left, ElectricCharge right)
        {
            return Current.FromAmperes(left.Hertz * right.Coulombs);
        }

        public static Power operator *(Frequency left, Energy right)
        {
            return Power.FromWatts(left.Hertz * right.Joules);
        }

        public static Speed operator *(Frequency left, Length right)
        {
            return Speed.FromMetresPerSecond(left.Hertz * right.Metres);
        }

        public static AngularSpeed operator *(Frequency left, Angle right)
        {
            return AngularSpeed.FromRadiansPerSecond(left.Hertz * right.Radians);
        }

        public static Acceleration operator *(Frequency left, Speed right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.Hertz * right.MetresPerSecond);
        }

        public static VolumetricFlow operator *(Frequency left, Volume right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.Hertz * right.CubicMetres);
        }


        public static double operator /(Frequency left, Frequency right)
        {
            return left.Hertz / right.Hertz;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Frequency"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator ==(Frequency left, Frequency right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Frequency"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator !=(Frequency left, Frequency right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Frequency"/> is less than another specified <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator <(Frequency left, Frequency right)
        {
            return left.Hertz < right.Hertz;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Frequency"/> is greater than another specified <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator >(Frequency left, Frequency right)
        {
            return left.Hertz > right.Hertz;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Frequency"/> is less than or equal to another specified <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator <=(Frequency left, Frequency right)
        {
            return left.Hertz <= right.Hertz;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Frequency"/> is greater than or equal to another specified <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator >=(Frequency left, Frequency right)
        {
            return left.Hertz >= right.Hertz;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Frequency"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="left"/> and returns the result.</returns>
        public static Frequency operator *(double left, Frequency right)
        {
            return new Frequency(left * right.Hertz);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.</returns>
        public static Frequency operator *(Frequency left, double right)
        {
            return new Frequency(left.Hertz * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.</returns>
        public static Frequency operator /(Frequency left, double right)
        {
            return new Frequency(left.Hertz / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Frequency"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Frequency"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Frequency operator +(Frequency left, Frequency right)
        {
            return new Frequency(left.Hertz + right.Hertz);
        }

        /// <summary>
        /// Subtracts an Frequency from another Frequency and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Frequency"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Frequency"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.Frequency"/> (the subtrahend).</param>
        public static Frequency operator -(Frequency left, Frequency right)
        {
            return new Frequency(left.Hertz - right.Hertz);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Frequency"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Frequency"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Frequency">A <see cref="T:Gu.Units.Frequency"/></param>
        public static Frequency operator -(Frequency Frequency)
        {
            return new Frequency(-1 * Frequency.Hertz);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="Frequency"/>.
        /// </returns>
        /// <param name="Frequency">A <see cref="T:Gu.Units.Frequency"/></param>
        public static Frequency operator +(Frequency Frequency)
        {
            return Frequency;
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
            return this.ToString(format, formatProvider, FrequencyUnit.Hertz);
        }

        public string ToString(string format, IFormatProvider formatProvider, FrequencyUnit unit)
        {
            var quantity = unit.FromSiUnit(this.Hertz);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Frequency"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Frequency"/> object.
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.Frequency"/> object to compare to this instance.</param>
        public int CompareTo(Frequency quantity)
        {
            return this.Hertz.CompareTo(quantity.Hertz);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Frequency"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Frequency as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Frequency"/> object to compare with this instance.</param>
        public bool Equals(Frequency other)
        {
            return this.Hertz.Equals(other.Hertz);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Frequency"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Frequency as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Frequency"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Frequency other, double tolerance)
        {
            return Math.Abs(this.Hertz - other.Hertz) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Frequency && this.Equals((Frequency)obj);
        }

        public override int GetHashCode()
        {
            return this.Hertz.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "Hertz", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.Hertz);
        }
    }
}
