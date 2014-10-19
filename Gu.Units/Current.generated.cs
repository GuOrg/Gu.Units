namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Current"/>.
    /// </summary>
    [Serializable]
    public partial struct Current : IComparable<Current>, IEquatable<Current>, IFormattable, IXmlSerializable, IQuantity<CurrentUnit, I1>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Amperes"/>.
        /// </summary>
        public readonly double Amperes;

        private Current(double amperes)
        {
            Amperes = amperes;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Current"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Amperes"/>.</param>
        public Current(double value, CurrentUnit unit)
        {
            Amperes = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Amperes
        /// </summary>
        public double SiValue
        {
            get
            {
                return Amperes;
            }
        }

        /// <summary>
        /// The quantity in milliamperes
        /// </summary>
        public double Milliamperes
        {
            get
            {
                return CurrentUnit.Milliamperes.FromSiUnit(Amperes);
            }
        }

        /// <summary>
        /// The quantity in kiloamperes
        /// </summary>
        public double Kiloamperes
        {
            get
            {
                return CurrentUnit.Kiloamperes.FromSiUnit(Amperes);
            }
        }

        /// <summary>
        /// The quantity in megaamperes
        /// </summary>
        public double Megaamperes
        {
            get
            {
                return CurrentUnit.Megaamperes.FromSiUnit(Amperes);
            }
        }

        /// <summary>
        /// The quantity in microamperes
        /// </summary>
        public double Microamperes
        {
            get
            {
                return CurrentUnit.Microamperes.FromSiUnit(Amperes);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Current"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Current"/></param>
        /// <returns></returns>
        public static Current Parse(string s)
        {
            return Parser.Parse<CurrentUnit, Current>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Current"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Current"/></returns>
        public static Current ReadFrom(XmlReader reader)
        {
            var v = new Current();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Current"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Current From(double value, CurrentUnit unit)
        {
            return new Current(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Current"/>.
        /// </summary>
        /// <param name="amperes">The value in <see cref="T:Gu.Units.Amperes"/></param>
        public static Current FromAmperes(double amperes)
        {
            return new Current(amperes);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Current"/>.
        /// </summary>
        /// <param name="milliamperes">The value in mA</param>
        public static Current FromMilliamperes(double milliamperes)
        {
            return From(milliamperes, CurrentUnit.Milliamperes);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Current"/>.
        /// </summary>
        /// <param name="kiloamperes">The value in kA</param>
        public static Current FromKiloamperes(double kiloamperes)
        {
            return From(kiloamperes, CurrentUnit.Kiloamperes);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Current"/>.
        /// </summary>
        /// <param name="megaamperes">The value in MA</param>
        public static Current FromMegaamperes(double megaamperes)
        {
            return From(megaamperes, CurrentUnit.Megaamperes);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Current"/>.
        /// </summary>
        /// <param name="microamperes">The value in µA</param>
        public static Current FromMicroamperes(double microamperes)
        {
            return From(microamperes, CurrentUnit.Microamperes);
        }

        public static Frequency operator /(Current left, ElectricCharge right)
        {
            return Frequency.FromHertz(left.Amperes / right.Coulombs);
        }

        public static ElectricCharge operator *(Current left, Time right)
        {
            return ElectricCharge.FromCoulombs(left.Amperes * right.Seconds);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Current"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Current"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Current"/>.</param>
        public static bool operator ==(Current left, Current right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Current"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Current"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Current"/>.</param>
        public static bool operator !=(Current left, Current right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Current"/> is less than another specified <see cref="T:Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Current"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Current"/>.</param>
        public static bool operator <(Current left, Current right)
        {
            return left.Amperes < right.Amperes;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Current"/> is greater than another specified <see cref="T:Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Current"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Current"/>.</param>
        public static bool operator >(Current left, Current right)
        {
            return left.Amperes > right.Amperes;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Current"/> is less than or equal to another specified <see cref="T:Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Current"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Current"/>.</param>
        public static bool operator <=(Current left, Current right)
        {
            return left.Amperes <= right.Amperes;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Current"/> is greater than or equal to another specified <see cref="T:Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Current"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Current"/>.</param>
        public static bool operator >=(Current left, Current right)
        {
            return left.Amperes >= right.Amperes;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Current"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Current"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Current"/> with <paramref name="left"/> and returns the result.</returns>
        public static Current operator *(double left, Current right)
        {
            return new Current(left * right.Amperes);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Current"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Current"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Current"/> with <paramref name="right"/> and returns the result.</returns>
        public static Current operator *(Current left, double right)
        {
            return new Current(left.Amperes * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Current"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Current"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Current"/> with <paramref name="right"/> and returns the result.</returns>
        public static Current operator /(Current left, double right)
        {
            return new Current(left.Amperes / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Current"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Current"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Current"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Current operator +(Current left, Current right)
        {
            return new Current(left.Amperes + right.Amperes);
        }

        /// <summary>
        /// Subtracts an Current from another Current and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Current"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Current"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.Current"/> (the subtrahend).</param>
        public static Current operator -(Current left, Current right)
        {
            return new Current(left.Amperes - right.Amperes);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Current"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Current"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Current">A <see cref="T:Gu.Units.Current"/></param>
        public static Current operator -(Current Current)
        {
            return new Current(-1 * Current.Amperes);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="Current"/>.
        /// </returns>
        /// <param name="Current">A <see cref="T:Gu.Units.Current"/></param>
        public static Current operator +(Current Current)
        {
            return Current;
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
            return this.ToString(format, formatProvider, CurrentUnit.Amperes);
        }

        public string ToString(string format, IFormatProvider formatProvider, CurrentUnit unit)
        {
            var quantity = unit.FromSiUnit(this.Amperes);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Current"/> object and returns an integer that indicates whether this <see cref="instance"/> is shorter than, equal to, or longer than the <see cref="T:MathNet.Spatial.Units.Current"/> object.
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.Current"/> object to compare to this instance.</param>
        public int CompareTo(Current quantity)
        {
            return this.Amperes.CompareTo(quantity.Amperes);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Current"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Current as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Current"/> object to compare with this instance.</param>
        public bool Equals(Current other)
        {
            return this.Amperes.Equals(other.Amperes);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Current"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Current as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Current"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Current other, double tolerance)
        {
            return Math.Abs(this.Amperes - other.Amperes) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Current && this.Equals((Current)obj);
        }

        public override int GetHashCode()
        {
            return this.Amperes.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, x => x.Amperes, reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.Amperes);
        }
    }
}
