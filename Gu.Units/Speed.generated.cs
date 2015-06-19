namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Speed"/>.
    /// </summary>
    [Serializable]
    public partial struct Speed : IComparable<Speed>, IEquatable<Speed>, IFormattable, IXmlSerializable, IQuantity<LengthUnit, I1, TimeUnit, INeg1>, IQuantity<SpeedUnit>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.MetresPerSecond"/>.
        /// </summary>
        internal readonly double metresPerSecond;

        private Speed(double metresPerSecond)
        {
            this.metresPerSecond = metresPerSecond;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.MetresPerSecond"/>.</param>
        public Speed(double value, SpeedUnit unit)
        {
            this.metresPerSecond = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in MetresPerSecond
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.metresPerSecond;
            }
        }

        /// <summary>
        /// The quantity in metresPerSecond".
        /// </summary>
        public double MetresPerSecond
        {
            get
            {
                return this.metresPerSecond;
            }
        }

        /// <summary>
        /// The quantity in millimetresPerSecond
        /// </summary>
        public double MillimetresPerSecond
        {
            get
            {
                return SpeedUnit.MillimetresPerSecond.FromSiUnit(this.metresPerSecond);
            }
        }

        /// <summary>
        /// The quantity in centimetresPerSecond
        /// </summary>
        public double CentimetresPerSecond
        {
            get
            {
                return SpeedUnit.CentimetresPerSecond.FromSiUnit(this.metresPerSecond);
            }
        }

        /// <summary>
        /// The quantity in kilometresPerHour
        /// </summary>
        public double KilometresPerHour
        {
            get
            {
                return SpeedUnit.KilometresPerHour.FromSiUnit(this.metresPerSecond);
            }
        }

        /// <summary>
        /// The quantity in centimetresPerMinute
        /// </summary>
        public double CentimetresPerMinute
        {
            get
            {
                return SpeedUnit.CentimetresPerMinute.FromSiUnit(this.metresPerSecond);
            }
        }

        /// <summary>
        /// The quantity in metresPerMinute
        /// </summary>
        public double MetresPerMinute
        {
            get
            {
                return SpeedUnit.MetresPerMinute.FromSiUnit(this.metresPerSecond);
            }
        }

        /// <summary>
        /// The quantity in metresPerHour
        /// </summary>
        public double MetresPerHour
        {
            get
            {
                return SpeedUnit.MetresPerHour.FromSiUnit(this.metresPerSecond);
            }
        }

        /// <summary>
        /// The quantity in millimetresPerHour
        /// </summary>
        public double MillimetresPerHour
        {
            get
            {
                return SpeedUnit.MillimetresPerHour.FromSiUnit(this.metresPerSecond);
            }
        }

        /// <summary>
        /// The quantity in centimetresPerHour
        /// </summary>
        public double CentimetresPerHour
        {
            get
            {
                return SpeedUnit.CentimetresPerHour.FromSiUnit(this.metresPerSecond);
            }
        }

        /// <summary>
        /// The quantity in millimetresPerMinute
        /// </summary>
        public double MillimetresPerMinute
        {
            get
            {
                return SpeedUnit.MillimetresPerMinute.FromSiUnit(this.metresPerSecond);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Speed"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Speed"/></param>
        /// <returns></returns>
        public static Speed Parse(string s)
        {
            return Parser.Parse<SpeedUnit, Speed>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static Speed Parse(string s, NumberStyles styles)
        {
            return Parser.Parse<SpeedUnit, Speed>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static Speed Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return Parser.Parse<SpeedUnit, Speed>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out Speed value)
        {
            return Parser.TryParse<SpeedUnit, Speed>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out Speed value)
        {
            return Parser.TryParse<SpeedUnit, Speed>(s, From, styles, CultureInfo.CurrentCulture, out  value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out Speed value)
        {
            return Parser.TryParse<SpeedUnit, Speed>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Speed"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Speed"/></returns>
        public static Speed ReadFrom(XmlReader reader)
        {
            var v = new Speed();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Speed From(double value, SpeedUnit unit)
        {
            return new Speed(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <param name="metresPerSecond">The value in <see cref="T:Gu.Units.MetresPerSecond"/></param>
        public static Speed FromMetresPerSecond(double metresPerSecond)
        {
            return new Speed(metresPerSecond);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <param name="millimetresPerSecond">The value in mm/s</param>
        public static Speed FromMillimetresPerSecond(double millimetresPerSecond)
        {
            return From(millimetresPerSecond, SpeedUnit.MillimetresPerSecond);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <param name="centimetresPerSecond">The value in cm/s</param>
        public static Speed FromCentimetresPerSecond(double centimetresPerSecond)
        {
            return From(centimetresPerSecond, SpeedUnit.CentimetresPerSecond);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <param name="kilometresPerHour">The value in km/h</param>
        public static Speed FromKilometresPerHour(double kilometresPerHour)
        {
            return From(kilometresPerHour, SpeedUnit.KilometresPerHour);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <param name="centimetresPerMinute">The value in cm/min</param>
        public static Speed FromCentimetresPerMinute(double centimetresPerMinute)
        {
            return From(centimetresPerMinute, SpeedUnit.CentimetresPerMinute);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <param name="metresPerMinute">The value in m/min</param>
        public static Speed FromMetresPerMinute(double metresPerMinute)
        {
            return From(metresPerMinute, SpeedUnit.MetresPerMinute);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <param name="metresPerHour">The value in m/h</param>
        public static Speed FromMetresPerHour(double metresPerHour)
        {
            return From(metresPerHour, SpeedUnit.MetresPerHour);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <param name="millimetresPerHour">The value in mm/h</param>
        public static Speed FromMillimetresPerHour(double millimetresPerHour)
        {
            return From(millimetresPerHour, SpeedUnit.MillimetresPerHour);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <param name="centimetresPerHour">The value in cm/h</param>
        public static Speed FromCentimetresPerHour(double centimetresPerHour)
        {
            return From(centimetresPerHour, SpeedUnit.CentimetresPerHour);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <param name="millimetresPerMinute">The value in mm/min</param>
        public static Speed FromMillimetresPerMinute(double millimetresPerMinute)
        {
            return From(millimetresPerMinute, SpeedUnit.MillimetresPerMinute);
        }

        public static Length operator *(Speed left, Time right)
        {
            return Length.FromMetres(left.metresPerSecond * right.seconds);
        }

        public static Time operator /(Speed left, Acceleration right)
        {
            return Time.FromSeconds(left.metresPerSecond / right.metresPerSecondSquared);
        }

        public static Power operator *(Speed left, Force right)
        {
            return Power.FromWatts(left.metresPerSecond * right.newtons);
        }

        public static Frequency operator /(Speed left, Length right)
        {
            return Frequency.FromHertz(left.metresPerSecond / right.metres);
        }

        public static Acceleration operator /(Speed left, Time right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.metresPerSecond / right.seconds);
        }

        public static VolumetricFlow operator *(Speed left, Area right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.metresPerSecond * right.squareMetres);
        }

        public static SpecificEnergy operator *(Speed left, Speed right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.metresPerSecond * right.metresPerSecond);
        }

        public static double operator /(Speed left, Speed right)
        {
            return left.metresPerSecond / right.metresPerSecond;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Speed"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        public static bool operator ==(Speed left, Speed right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Speed"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        public static bool operator !=(Speed left, Speed right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Speed"/> is less than another specified <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        public static bool operator <(Speed left, Speed right)
        {
            return left.metresPerSecond < right.metresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Speed"/> is greater than another specified <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        public static bool operator >(Speed left, Speed right)
        {
            return left.metresPerSecond > right.metresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Speed"/> is less than or equal to another specified <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        public static bool operator <=(Speed left, Speed right)
        {
            return left.metresPerSecond <= right.metresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Speed"/> is greater than or equal to another specified <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        public static bool operator >=(Speed left, Speed right)
        {
            return left.metresPerSecond >= right.metresPerSecond;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Speed"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Speed"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Speed"/> with <paramref name="left"/> and returns the result.</returns>
        public static Speed operator *(double left, Speed right)
        {
            return new Speed(left * right.metresPerSecond);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Speed"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Speed"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Speed"/> with <paramref name="right"/> and returns the result.</returns>
        public static Speed operator *(Speed left, double right)
        {
            return new Speed(left.metresPerSecond * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Speed"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Speed"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Speed"/> with <paramref name="right"/> and returns the result.</returns>
        public static Speed operator /(Speed left, double right)
        {
            return new Speed(left.metresPerSecond / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Speed"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Speed"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Speed"/>.</param>
        public static Speed operator +(Speed left, Speed right)
        {
            return new Speed(left.metresPerSecond + right.metresPerSecond);
        }

        /// <summary>
        /// Subtracts an Speed from another Speed and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Speed"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Speed"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Speed"/> (the subtrahend).</param>
        public static Speed operator -(Speed left, Speed right)
        {
            return new Speed(left.metresPerSecond - right.metresPerSecond);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Speed"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Speed"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="speed">An instance of <see cref="T:Gu.Units.Speed"/></param>
        public static Speed operator -(Speed speed)
        {
            return new Speed(-1 * speed.metresPerSecond);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Speed"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="speed"/>.
        /// </returns>
        /// <param name="speed">An instance of <see cref="T:Gu.Units.Speed"/></param>
        public static Speed operator +(Speed speed)
        {
            return speed;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(SpeedUnit unit)
        {
            return unit.FromSiUnit(this.metresPerSecond);
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
            return this.ToString(format, formatProvider, SpeedUnit.MetresPerSecond);
        }

        public string ToString(SpeedUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, SpeedUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, SpeedUnit unit)
        {
            var quantity = unit.FromSiUnit(this.metresPerSecond);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Speed"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Speed"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.Speed"/> object to compare to this instance.</param>
        public int CompareTo(Speed quantity)
        {
            return this.metresPerSecond.CompareTo(quantity.metresPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Speed"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Speed as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Speed"/> object to compare with this instance.</param>
        public bool Equals(Speed other)
        {
            return this.metresPerSecond.Equals(other.metresPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Speed"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Speed as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Speed"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Speed other, double tolerance)
        {
            return Math.Abs(this.metresPerSecond - other.metresPerSecond) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Speed && this.Equals((Speed)obj);
        }

        public override int GetHashCode()
        {
            return this.metresPerSecond.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "metresPerSecond", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.metresPerSecond);
        }
    }
}