namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.AngularJerk"/>.
    /// </summary>
    [Serializable]
    public partial struct AngularJerk : IComparable<AngularJerk>, IEquatable<AngularJerk>, IFormattable, IXmlSerializable, IQuantity<AngleUnit, I1, TimeUnit, INeg3>, IQuantity<AngularJerkUnit>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.RadiansPerSecondCubed"/>.
        /// </summary>
        internal readonly double radiansPerSecondCubed;

        private AngularJerk(double radiansPerSecondCubed)
        {
            this.radiansPerSecondCubed = radiansPerSecondCubed;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.RadiansPerSecondCubed"/>.</param>
        public AngularJerk(double value, AngularJerkUnit unit)
        {
            this.radiansPerSecondCubed = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in RadiansPerSecondCubed
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.radiansPerSecondCubed;
            }
        }

        /// <summary>
        /// The quantity in radiansPerSecondCubed".
        /// </summary>
        public double RadiansPerSecondCubed
        {
            get
            {
                return this.radiansPerSecondCubed;
            }
        }

        /// <summary>
        /// The quantity in degreesPerCubicSecond
        /// </summary>
        public double DegreesPerCubicSecond
        {
            get
            {
                return AngularJerkUnit.DegreesPerCubicSecond.FromSiUnit(this.radiansPerSecondCubed);
            }
        }

        /// <summary>
        /// The quantity in radiansPerCubicHour
        /// </summary>
        public double RadiansPerCubicHour
        {
            get
            {
                return AngularJerkUnit.RadiansPerCubicHour.FromSiUnit(this.radiansPerSecondCubed);
            }
        }

        /// <summary>
        /// The quantity in degreesPerCubicHour
        /// </summary>
        public double DegreesPerCubicHour
        {
            get
            {
                return AngularJerkUnit.DegreesPerCubicHour.FromSiUnit(this.radiansPerSecondCubed);
            }
        }

        /// <summary>
        /// The quantity in radiansPerCubicMinute
        /// </summary>
        public double RadiansPerCubicMinute
        {
            get
            {
                return AngularJerkUnit.RadiansPerCubicMinute.FromSiUnit(this.radiansPerSecondCubed);
            }
        }

        /// <summary>
        /// The quantity in degreesPerCubicMinute
        /// </summary>
        public double DegreesPerCubicMinute
        {
            get
            {
                return AngularJerkUnit.DegreesPerCubicMinute.FromSiUnit(this.radiansPerSecondCubed);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.AngularJerk"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.AngularJerk"/></param>
        /// <returns></returns>
        public static AngularJerk Parse(string s)
        {
            return Parser.Parse<AngularJerkUnit, AngularJerk>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.AngularJerk"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.AngularJerk"/></returns>
        public static AngularJerk ReadFrom(XmlReader reader)
        {
            var v = new AngularJerk();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static AngularJerk From(double value, AngularJerkUnit unit)
        {
            return new AngularJerk(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="radiansPerSecondCubed">The value in <see cref="T:Gu.Units.RadiansPerSecondCubed"/></param>
        public static AngularJerk FromRadiansPerSecondCubed(double radiansPerSecondCubed)
        {
            return new AngularJerk(radiansPerSecondCubed);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="degreesPerCubicSecond">The value in °⋅s⁻³</param>
        public static AngularJerk FromDegreesPerCubicSecond(double degreesPerCubicSecond)
        {
            return From(degreesPerCubicSecond, AngularJerkUnit.DegreesPerCubicSecond);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="radiansPerCubicHour">The value in h⁻³⋅rad</param>
        public static AngularJerk FromRadiansPerCubicHour(double radiansPerCubicHour)
        {
            return From(radiansPerCubicHour, AngularJerkUnit.RadiansPerCubicHour);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="degreesPerCubicHour">The value in h⁻³⋅°</param>
        public static AngularJerk FromDegreesPerCubicHour(double degreesPerCubicHour)
        {
            return From(degreesPerCubicHour, AngularJerkUnit.DegreesPerCubicHour);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="radiansPerCubicMinute">The value in min⁻³⋅rad</param>
        public static AngularJerk FromRadiansPerCubicMinute(double radiansPerCubicMinute)
        {
            return From(radiansPerCubicMinute, AngularJerkUnit.RadiansPerCubicMinute);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <param name="degreesPerCubicMinute">The value in min⁻³⋅°</param>
        public static AngularJerk FromDegreesPerCubicMinute(double degreesPerCubicMinute)
        {
            return From(degreesPerCubicMinute, AngularJerkUnit.DegreesPerCubicMinute);
        }

        public static Frequency operator /(AngularJerk left, AngularAcceleration right)
        {
            return Frequency.FromHertz(left.radiansPerSecondCubed / right.radiansPerSecondSquared);
        }

        public static AngularAcceleration operator *(AngularJerk left, Time right)
        {
            return AngularAcceleration.FromRadiansPerSecondSquared(left.radiansPerSecondCubed * right.seconds);
        }

        public static double operator /(AngularJerk left, AngularJerk right)
        {
            return left.radiansPerSecondCubed / right.radiansPerSecondCubed;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.AngularJerk"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        public static bool operator ==(AngularJerk left, AngularJerk right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.AngularJerk"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        public static bool operator !=(AngularJerk left, AngularJerk right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.AngularJerk"/> is less than another specified <see cref="T:Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        public static bool operator <(AngularJerk left, AngularJerk right)
        {
            return left.radiansPerSecondCubed < right.radiansPerSecondCubed;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.AngularJerk"/> is greater than another specified <see cref="T:Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        public static bool operator >(AngularJerk left, AngularJerk right)
        {
            return left.radiansPerSecondCubed > right.radiansPerSecondCubed;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.AngularJerk"/> is less than or equal to another specified <see cref="T:Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        public static bool operator <=(AngularJerk left, AngularJerk right)
        {
            return left.radiansPerSecondCubed <= right.radiansPerSecondCubed;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.AngularJerk"/> is greater than or equal to another specified <see cref="T:Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        public static bool operator >=(AngularJerk left, AngularJerk right)
        {
            return left.radiansPerSecondCubed >= right.radiansPerSecondCubed;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.AngularJerk"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.AngularJerk"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.AngularJerk"/> with <paramref name="left"/> and returns the result.</returns>
        public static AngularJerk operator *(double left, AngularJerk right)
        {
            return new AngularJerk(left * right.radiansPerSecondCubed);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.AngularJerk"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularJerk"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.AngularJerk"/> with <paramref name="right"/> and returns the result.</returns>
        public static AngularJerk operator *(AngularJerk left, double right)
        {
            return new AngularJerk(left.radiansPerSecondCubed * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.AngularJerk"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularJerk"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.AngularJerk"/> with <paramref name="right"/> and returns the result.</returns>
        public static AngularJerk operator /(AngularJerk left, double right)
        {
            return new AngularJerk(left.radiansPerSecondCubed / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.AngularJerk"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.AngularJerk"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.AngularJerk"/>.</param>
        public static AngularJerk operator +(AngularJerk left, AngularJerk right)
        {
            return new AngularJerk(left.radiansPerSecondCubed + right.radiansPerSecondCubed);
        }

        /// <summary>
        /// Subtracts an AngularJerk from another AngularJerk and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.AngularJerk"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.AngularJerk"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.AngularJerk"/> (the subtrahend).</param>
        public static AngularJerk operator -(AngularJerk left, AngularJerk right)
        {
            return new AngularJerk(left.radiansPerSecondCubed - right.radiansPerSecondCubed);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.AngularJerk"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.AngularJerk"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="angularJerk">An instance of <see cref="T:Gu.Units.AngularJerk"/></param>
        public static AngularJerk operator -(AngularJerk angularJerk)
        {
            return new AngularJerk(-1 * angularJerk.radiansPerSecondCubed);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.AngularJerk"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="angularJerk"/>.
        /// </returns>
        /// <param name="angularJerk">An instance of <see cref="T:Gu.Units.AngularJerk"/></param>
        public static AngularJerk operator +(AngularJerk angularJerk)
        {
            return angularJerk;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(AngularJerkUnit unit)
        {
            return unit.FromSiUnit(this.radiansPerSecondCubed);
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
            return this.ToString(format, formatProvider, AngularJerkUnit.RadiansPerSecondCubed);
        }

        public string ToString(AngularJerkUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, AngularJerkUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, AngularJerkUnit unit)
        {
            var quantity = unit.FromSiUnit(this.radiansPerSecondCubed);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.AngularJerk"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.AngularJerk"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.AngularJerk"/> object to compare to this instance.</param>
        public int CompareTo(AngularJerk quantity)
        {
            return this.radiansPerSecondCubed.CompareTo(quantity.radiansPerSecondCubed);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.AngularJerk"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularJerk as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.AngularJerk"/> object to compare with this instance.</param>
        public bool Equals(AngularJerk other)
        {
            return this.radiansPerSecondCubed.Equals(other.radiansPerSecondCubed);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.AngularJerk"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AngularJerk as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.AngularJerk"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(AngularJerk other, double tolerance)
        {
            return Math.Abs(this.radiansPerSecondCubed - other.radiansPerSecondCubed) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AngularJerk && this.Equals((AngularJerk)obj);
        }

        public override int GetHashCode()
        {
            return this.radiansPerSecondCubed.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "radiansPerSecondCubed", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.radiansPerSecondCubed);
        }
    }
}