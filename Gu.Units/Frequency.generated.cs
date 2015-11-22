namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Frequency"/>.
    /// </summary>
    [Serializable]
    public partial struct Frequency : IComparable<Frequency>, IEquatable<Frequency>, IFormattable, IXmlSerializable, IQuantity<TimeUnit, INeg1>, IQuantity<FrequencyUnit>
    {
        public static readonly Frequency Zero = new Frequency();

        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Hertz"/>.
        /// </summary>
        internal readonly double hertz;

        private Frequency(double hertz)
        {
            this.hertz = hertz;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Hertz"/>.</param>
        public Frequency(double value, FrequencyUnit unit)
        {
            this.hertz = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Hertz
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.hertz;
            }
        }

        /// <summary>
        /// The quantity in hertz".
        /// </summary>
        public double Hertz
        {
            get
            {
                return this.hertz;
            }
        }

        /// <summary>
        /// The quantity in millihertz
        /// </summary>
        public double Millihertz
        {
            get
            {
                return FrequencyUnit.Millihertz.FromSiUnit(this.hertz);
            }
        }

        /// <summary>
        /// The quantity in kilohertz
        /// </summary>
        public double Kilohertz
        {
            get
            {
                return FrequencyUnit.Kilohertz.FromSiUnit(this.hertz);
            }
        }

        /// <summary>
        /// The quantity in megahertz
        /// </summary>
        public double Megahertz
        {
            get
            {
                return FrequencyUnit.Megahertz.FromSiUnit(this.hertz);
            }
        }

        /// <summary>
        /// The quantity in gigahertz
        /// </summary>
        public double Gigahertz
        {
            get
            {
                return FrequencyUnit.Gigahertz.FromSiUnit(this.hertz);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Frequency"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Frequency"/></param>
        /// <returns></returns>
		public static Frequency Parse(string s)
        {
            return Parser.Parse<FrequencyUnit, Frequency>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static Frequency Parse(string s, IFormatProvider provider)
        {
            return Parser.Parse<FrequencyUnit, Frequency>(s, From, NumberStyles.Float, provider);
        }

        public static Frequency Parse(string s, NumberStyles styles)
        {
            return Parser.Parse<FrequencyUnit, Frequency>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static Frequency Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return Parser.Parse<FrequencyUnit, Frequency>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out Frequency value)
        {
            return Parser.TryParse<FrequencyUnit, Frequency>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out Frequency value)
        {
            return Parser.TryParse<FrequencyUnit, Frequency>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out Frequency value)
        {
            return Parser.TryParse<FrequencyUnit, Frequency>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out Frequency value)
        {
            return Parser.TryParse<FrequencyUnit, Frequency>(s, From, styles, provider, out value);
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
            return Current.FromAmperes(left.hertz * right.coulombs);
        }

        public static Power operator *(Frequency left, Energy right)
        {
            return Power.FromWatts(left.hertz * right.joules);
        }

        public static Speed operator *(Frequency left, Length right)
        {
            return Speed.FromMetresPerSecond(left.hertz * right.metres);
        }

        public static AngularSpeed operator *(Frequency left, Angle right)
        {
            return AngularSpeed.FromRadiansPerSecond(left.hertz * right.radians);
        }

        public static Acceleration operator *(Frequency left, Speed right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.hertz * right.metresPerSecond);
        }

        public static VolumetricFlow operator *(Frequency left, Volume right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.hertz * right.cubicMetres);
        }

        public static AngularAcceleration operator *(Frequency left, AngularSpeed right)
        {
            return AngularAcceleration.FromRadiansPerSecondSquared(left.hertz * right.radiansPerSecond);
        }

        public static AngularJerk operator *(Frequency left, AngularAcceleration right)
        {
            return AngularJerk.FromRadiansPerSecondCubed(left.hertz * right.radiansPerSecondSquared);
        }

        public static Jerk operator *(Frequency left, Acceleration right)
        {
            return Jerk.FromMetresPerSecondCubed(left.hertz * right.metresPerSecondSquared);
        }

        public static Time operator /(double left, Frequency right)
        {
            return Time.FromSeconds(left / right.hertz);
        }

        public static double operator /(Frequency left, Frequency right)
        {
            return left.hertz / right.hertz;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Frequency"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
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
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
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
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator <(Frequency left, Frequency right)
        {
            return left.hertz < right.hertz;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Frequency"/> is greater than another specified <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator >(Frequency left, Frequency right)
        {
            return left.hertz > right.hertz;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Frequency"/> is less than or equal to another specified <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator <=(Frequency left, Frequency right)
        {
            return left.hertz <= right.hertz;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Frequency"/> is greater than or equal to another specified <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
        public static bool operator >=(Frequency left, Frequency right)
        {
            return left.hertz >= right.hertz;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Frequency"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="left"/> and returns the result.</returns>
        public static Frequency operator *(double left, Frequency right)
        {
            return new Frequency(left * right.hertz);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.</returns>
        public static Frequency operator *(Frequency left, double right)
        {
            return new Frequency(left.hertz * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Frequency"/> with <paramref name="right"/> and returns the result.</returns>
        public static Frequency operator /(Frequency left, double right)
        {
            return new Frequency(left.hertz / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Frequency"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Frequency"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Frequency"/>.</param>
        public static Frequency operator +(Frequency left, Frequency right)
        {
            return new Frequency(left.hertz + right.hertz);
        }

        /// <summary>
        /// Subtracts an Frequency from another Frequency and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Frequency"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Frequency"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Frequency"/> (the subtrahend).</param>
        public static Frequency operator -(Frequency left, Frequency right)
        {
            return new Frequency(left.hertz - right.hertz);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Frequency"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Frequency"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="frequency">An instance of <see cref="T:Gu.Units.Frequency"/></param>
        public static Frequency operator -(Frequency frequency)
        {
            return new Frequency(-1 * frequency.hertz);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Frequency"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="frequency"/>.
        /// </returns>
        /// <param name="frequency">An instance of <see cref="T:Gu.Units.Frequency"/></param>
        public static Frequency operator +(Frequency frequency)
        {
            return frequency;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(FrequencyUnit unit)
        {
            return unit.FromSiUnit(this.hertz);
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

        public string ToString(FrequencyUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, FrequencyUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, FrequencyUnit unit)
        {
            var quantity = unit.FromSiUnit(this.hertz);
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.Frequency"/> object to compare to this instance.</param>
        public int CompareTo(Frequency quantity)
        {
            return this.hertz.CompareTo(quantity.hertz);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Frequency"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Frequency as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Frequency"/> object to compare with this instance.</param>
        public bool Equals(Frequency other)
        {
            return this.hertz.Equals(other.hertz);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Frequency"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Frequency as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Frequency"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Frequency other, double tolerance)
        {
            return Math.Abs(this.hertz - other.hertz) < tolerance;
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
            return this.hertz.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "hertz", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.hertz);
        }
    }
}