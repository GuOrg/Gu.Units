namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity Time
    /// </summary>
    [Serializable]
    public partial struct Time : IComparable<Time>, IEquatable<Time>, IFormattable, IXmlSerializable, IQuantity<TimeUnit, I1>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Seconds"/>.
        /// </summary>
        public readonly double Seconds;

        private Time(double seconds)
        {
            Seconds = seconds;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Time"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Seconds"/>.</param>
        public Time(double value, TimeUnit unit)
        {
            Seconds = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Seconds
        /// </summary>
        public double SiValue
        {
            get
            {
                return Seconds;
            }
        }

        /// <summary>
        /// The quantity in nanoseconds
        /// </summary>
        public double Nanoseconds
        {
            get
            {
                return TimeUnit.Nanoseconds.FromSiUnit(Seconds);
            }
        }

        /// <summary>
        /// The quantity in microseconds
        /// </summary>
        public double Microseconds
        {
            get
            {
                return TimeUnit.Microseconds.FromSiUnit(Seconds);
            }
        }

        /// <summary>
        /// The quantity in milliseconds
        /// </summary>
        public double Milliseconds
        {
            get
            {
                return TimeUnit.Milliseconds.FromSiUnit(Seconds);
            }
        }

        /// <summary>
        /// The quantity in hours
        /// </summary>
        public double Hours
        {
            get
            {
                return TimeUnit.Hours.FromSiUnit(Seconds);
            }
        }

        /// <summary>
        /// The quantity in minutes
        /// </summary>
        public double Minutes
        {
            get
            {
                return TimeUnit.Minutes.FromSiUnit(Seconds);
            }
        }


        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Time"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Time"/></param>
        /// <returns></returns>
        public static Time Parse(string s)
        {
            return Parser.Parse<TimeUnit, Time>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Time"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Time"/></returns>
        public static Time ReadFrom(XmlReader reader)
        {
            var v = new Time();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Time"/>.
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="unit"></param>
        public static Time From(double value, TimeUnit unit)
        {
            return new Time(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Time"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Time FromSeconds(double value)
        {
            return new Time(value);
        }


        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Time"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Time FromNanoseconds(double value)
        {
            return From(value, TimeUnit.Nanoseconds);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Time"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Time FromMicroseconds(double value)
        {
            return From(value, TimeUnit.Microseconds);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Time"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Time FromMilliseconds(double value)
        {
            return From(value, TimeUnit.Milliseconds);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Time"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Time FromHours(double value)
        {
            return From(value, TimeUnit.Hours);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Time"/>.
        /// </summary>
        /// <param name="quantity"></param>
        public static Time FromMinutes(double value)
        {
            return From(value, TimeUnit.Minutes);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Time"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Time"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Time"/>.</param>
        public static bool operator ==(Time left, Time right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Time"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Time"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Time"/>.</param>
        public static bool operator !=(Time left, Time right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Time"/> is less than another specified <see cref="T:Gu.Units.Time"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Time"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Time"/>.</param>
        public static bool operator <(Time left, Time right)
        {
            return left.Seconds < right.Seconds;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Time"/> is greater than another specified <see cref="T:Gu.Units.Time"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Time"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Time"/>.</param>
        public static bool operator >(Time left, Time right)
        {
            return left.Seconds > right.Seconds;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Time"/> is less than or equal to another specified <see cref="T:Gu.Units.Time"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Time"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Time"/>.</param>
        public static bool operator <=(Time left, Time right)
        {
            return left.Seconds <= right.Seconds;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Time"/> is greater than or equal to another specified <see cref="T:Gu.Units.Time"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Time"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Time"/>.</param>
        public static bool operator >=(Time left, Time right)
        {
            return left.Seconds >= right.Seconds;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Time"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Time"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Time"/> with <paramref name="left"/> and returns the result.</returns>
        public static Time operator *(double left, Time right)
        {
            return new Time(left * right.Seconds);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Time"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Time"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Time"/> with <paramref name="right"/> and returns the result.</returns>
        public static Time operator *(Time left, double right)
        {
            return new Time(left.Seconds * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Time"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Time"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Time"/> with <paramref name="right"/> and returns the result.</returns>
        public static Time operator /(Time left, double right)
        {
            return new Time(left.Seconds / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Time"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Time"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Time"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Time operator +(Time left, Time right)
        {
            return new Time(left.Seconds + right.Seconds);
        }

        /// <summary>
        /// Subtracts an Time from another Time and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Time"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Time"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.Time"/> (the subtrahend).</param>
        public static Time operator -(Time left, Time right)
        {
            return new Time(left.Seconds - right.Seconds);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Time"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Time"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Time">A <see cref="T:Gu.Units.Time"/></param>
        public static Time operator -(Time Time)
        {
            return new Time(-1 * Time.Seconds);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Time"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="Time"/>.
        /// </returns>
        /// <param name="Time">A <see cref="T:Gu.Units.Time"/></param>
        public static Time operator +(Time Time)
        {
            return Time;
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
            return this.ToString(format, formatProvider, TimeUnit.Seconds);
        }

        public string ToString(string format, IFormatProvider formatProvider, TimeUnit unit)
        {
            var quantity = unit.FromSiUnit(this.Seconds);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Time"/> object and returns an integer that indicates whether this <see cref="instance"/> is shorter than, equal to, or longer than the <see cref="T:MathNet.Spatial.Units.Time"/> object.
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.Time"/> object to compare to this instance.</param>
        public int CompareTo(Time quantity)
        {
            return this.Seconds.CompareTo(quantity.Seconds);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Time"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Time as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Time"/> object to compare with this instance.</param>
        public bool Equals(Time other)
        {
            return this.Seconds.Equals(other.Seconds);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Time"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Time as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Time"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Time other, double tolerance)
        {
            return Math.Abs(this.Seconds - other.Seconds) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Time && this.Equals((Time)obj);
        }

        public override int GetHashCode()
        {
            return this.Seconds.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, x => x.Seconds, XmlConvert.ToDouble(XmlExt.ReadAttributeOrElementOrDefault(e, "Value")));
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.Seconds);
        }
    }
}
