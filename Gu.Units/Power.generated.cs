namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Power"/>.
    /// </summary>
    [Serializable]
    public partial struct Power : IComparable<Power>, IEquatable<Power>, IFormattable, IXmlSerializable, IQuantity<MassUnit, I1, LengthUnit, I2, TimeUnit, INeg3>, IQuantity<PowerUnit>
    {
        public static readonly Power Zero = new Power();

        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Watts"/>.
        /// </summary>
        internal readonly double watts;

        private Power(double watts)
        {
            this.watts = watts;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Watts"/>.</param>
        public Power(double value, PowerUnit unit)
        {
            this.watts = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Watts
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.watts;
            }
        }

        /// <summary>
        /// The quantity in watts".
        /// </summary>
        public double Watts
        {
            get
            {
                return this.watts;
            }
        }

        /// <summary>
        /// The quantity in nanowatts
        /// </summary>
        public double Nanowatts
        {
            get
            {
                return PowerUnit.Nanowatts.FromSiUnit(this.watts);
            }
        }

        /// <summary>
        /// The quantity in microwatts
        /// </summary>
        public double Microwatts
        {
            get
            {
                return PowerUnit.Microwatts.FromSiUnit(this.watts);
            }
        }

        /// <summary>
        /// The quantity in milliwatts
        /// </summary>
        public double Milliwatts
        {
            get
            {
                return PowerUnit.Milliwatts.FromSiUnit(this.watts);
            }
        }

        /// <summary>
        /// The quantity in kilowatts
        /// </summary>
        public double Kilowatts
        {
            get
            {
                return PowerUnit.Kilowatts.FromSiUnit(this.watts);
            }
        }

        /// <summary>
        /// The quantity in megawatts
        /// </summary>
        public double Megawatts
        {
            get
            {
                return PowerUnit.Megawatts.FromSiUnit(this.watts);
            }
        }

        /// <summary>
        /// The quantity in gigawatts
        /// </summary>
        public double Gigawatts
        {
            get
            {
                return PowerUnit.Gigawatts.FromSiUnit(this.watts);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Power"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Power"/></param>
        /// <returns></returns>
		public static Power Parse(string s)
        {
            return Parser.Parse<PowerUnit, Power>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static Power Parse(string s, IFormatProvider provider)
        {
            return Parser.Parse<PowerUnit, Power>(s, From, NumberStyles.Float, provider);
        }

        public static Power Parse(string s, NumberStyles styles)
        {
            return Parser.Parse<PowerUnit, Power>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static Power Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return Parser.Parse<PowerUnit, Power>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out Power value)
        {
            return Parser.TryParse<PowerUnit, Power>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out Power value)
        {
            return Parser.TryParse<PowerUnit, Power>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out Power value)
        {
            return Parser.TryParse<PowerUnit, Power>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out Power value)
        {
            return Parser.TryParse<PowerUnit, Power>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Power"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Power"/></returns>
        public static Power ReadFrom(XmlReader reader)
        {
            var v = new Power();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Power From(double value, PowerUnit unit)
        {
            return new Power(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <param name="watts">The value in <see cref="T:Gu.Units.Watts"/></param>
        public static Power FromWatts(double watts)
        {
            return new Power(watts);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <param name="nanowatts">The value in nW</param>
        public static Power FromNanowatts(double nanowatts)
        {
            return From(nanowatts, PowerUnit.Nanowatts);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <param name="microwatts">The value in µW</param>
        public static Power FromMicrowatts(double microwatts)
        {
            return From(microwatts, PowerUnit.Microwatts);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <param name="milliwatts">The value in mW</param>
        public static Power FromMilliwatts(double milliwatts)
        {
            return From(milliwatts, PowerUnit.Milliwatts);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <param name="kilowatts">The value in kW</param>
        public static Power FromKilowatts(double kilowatts)
        {
            return From(kilowatts, PowerUnit.Kilowatts);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <param name="megawatts">The value in MW</param>
        public static Power FromMegawatts(double megawatts)
        {
            return From(megawatts, PowerUnit.Megawatts);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <param name="gigawatts">The value in GW</param>
        public static Power FromGigawatts(double gigawatts)
        {
            return From(gigawatts, PowerUnit.Gigawatts);
        }

        public static Force operator /(Power left, Speed right)
        {
            return Force.FromNewtons(left.watts / right.metresPerSecond);
        }

        public static Energy operator *(Power left, Time right)
        {
            return Energy.FromJoules(left.watts * right.seconds);
        }

        public static Speed operator /(Power left, Force right)
        {
            return Speed.FromMetresPerSecond(left.watts / right.newtons);
        }

        public static Frequency operator /(Power left, Energy right)
        {
            return Frequency.FromHertz(left.watts / right.joules);
        }

        public static Torque operator /(Power left, AngularSpeed right)
        {
            return Torque.FromNewtonMetres(left.watts / right.radiansPerSecond);
        }

        public static Voltage operator /(Power left, Current right)
        {
            return Voltage.FromVolts(left.watts / right.amperes);
        }

        public static double operator /(Power left, Power right)
        {
            return left.watts / right.watts;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Power"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        public static bool operator ==(Power left, Power right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Power"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        public static bool operator !=(Power left, Power right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Power"/> is less than another specified <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        public static bool operator <(Power left, Power right)
        {
            return left.watts < right.watts;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Power"/> is greater than another specified <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        public static bool operator >(Power left, Power right)
        {
            return left.watts > right.watts;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Power"/> is less than or equal to another specified <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        public static bool operator <=(Power left, Power right)
        {
            return left.watts <= right.watts;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Power"/> is greater than or equal to another specified <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        public static bool operator >=(Power left, Power right)
        {
            return left.watts >= right.watts;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Power"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Power"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Power"/> with <paramref name="left"/> and returns the result.</returns>
        public static Power operator *(double left, Power right)
        {
            return new Power(left * right.watts);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Power"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Power"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Power"/> with <paramref name="right"/> and returns the result.</returns>
        public static Power operator *(Power left, double right)
        {
            return new Power(left.watts * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Power"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Power"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Power"/> with <paramref name="right"/> and returns the result.</returns>
        public static Power operator /(Power left, double right)
        {
            return new Power(left.watts / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Power"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Power"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Power"/>.</param>
        public static Power operator +(Power left, Power right)
        {
            return new Power(left.watts + right.watts);
        }

        /// <summary>
        /// Subtracts an Power from another Power and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Power"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Power"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Power"/> (the subtrahend).</param>
        public static Power operator -(Power left, Power right)
        {
            return new Power(left.watts - right.watts);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Power"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Power"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="power">An instance of <see cref="T:Gu.Units.Power"/></param>
        public static Power operator -(Power power)
        {
            return new Power(-1 * power.watts);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Power"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="power"/>.
        /// </returns>
        /// <param name="power">An instance of <see cref="T:Gu.Units.Power"/></param>
        public static Power operator +(Power power)
        {
            return power;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(PowerUnit unit)
        {
            return unit.FromSiUnit(this.watts);
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
            return this.ToString(format, formatProvider, PowerUnit.Watts);
        }

        public string ToString(PowerUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, PowerUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, PowerUnit unit)
        {
            var quantity = unit.FromSiUnit(this.watts);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Power"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Power"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.Power"/> object to compare to this instance.</param>
        public int CompareTo(Power quantity)
        {
            return this.watts.CompareTo(quantity.watts);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Power"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Power as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Power"/> object to compare with this instance.</param>
        public bool Equals(Power other)
        {
            return this.watts.Equals(other.watts);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Power"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Power as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Power"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Power other, double tolerance)
        {
            return Math.Abs(this.watts - other.watts) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Power && this.Equals((Power)obj);
        }

        public override int GetHashCode()
        {
            return this.watts.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "watts", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.watts);
        }
    }
}