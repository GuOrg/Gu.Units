namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Capacitance"/>.
    /// </summary>
    [Serializable]
    public partial struct Capacitance : IComparable<Capacitance>, IEquatable<Capacitance>, IFormattable, IXmlSerializable, IQuantity<TimeUnit, I4, CurrentUnit, I2, MassUnit, INeg1, LengthUnit, INeg2>, IQuantity<CapacitanceUnit>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Farads"/>.
        /// </summary>
        internal readonly double farads;

        private Capacitance(double farads)
        {
            this.farads = farads;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Capacitance"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Farads"/>.</param>
        public Capacitance(double value, CapacitanceUnit unit)
        {
            this.farads = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Farads
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.farads;
            }
        }

        /// <summary>
        /// The quantity in farads".
        /// </summary>
        public double Farads
        {
            get
            {
                return this.farads;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Capacitance"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Capacitance"/></param>
        /// <returns></returns>
        public static Capacitance Parse(string s)
        {
            return Parser.Parse<CapacitanceUnit, Capacitance>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Capacitance"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Capacitance"/></returns>
        public static Capacitance ReadFrom(XmlReader reader)
        {
            var v = new Capacitance();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Capacitance"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Capacitance From(double value, CapacitanceUnit unit)
        {
            return new Capacitance(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Capacitance"/>.
        /// </summary>
        /// <param name="farads">The value in <see cref="T:Gu.Units.Farads"/></param>
        public static Capacitance FromFarads(double farads)
        {
            return new Capacitance(farads);
        }


        public static double operator /(Capacitance left, Capacitance right)
        {
            return left.farads / right.farads;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Capacitance"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        public static bool operator ==(Capacitance left, Capacitance right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Capacitance"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        public static bool operator !=(Capacitance left, Capacitance right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Capacitance"/> is less than another specified <see cref="T:Gu.Units.Capacitance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        public static bool operator <(Capacitance left, Capacitance right)
        {
            return left.farads < right.farads;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Capacitance"/> is greater than another specified <see cref="T:Gu.Units.Capacitance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        public static bool operator >(Capacitance left, Capacitance right)
        {
            return left.farads > right.farads;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Capacitance"/> is less than or equal to another specified <see cref="T:Gu.Units.Capacitance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        public static bool operator <=(Capacitance left, Capacitance right)
        {
            return left.farads <= right.farads;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Capacitance"/> is greater than or equal to another specified <see cref="T:Gu.Units.Capacitance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        public static bool operator >=(Capacitance left, Capacitance right)
        {
            return left.farads >= right.farads;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Capacitance"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Capacitance"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Capacitance"/> with <paramref name="left"/> and returns the result.</returns>
        public static Capacitance operator *(double left, Capacitance right)
        {
            return new Capacitance(left * right.farads);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Capacitance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Capacitance"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Capacitance"/> with <paramref name="right"/> and returns the result.</returns>
        public static Capacitance operator *(Capacitance left, double right)
        {
            return new Capacitance(left.farads * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Capacitance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Capacitance"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Capacitance"/> with <paramref name="right"/> and returns the result.</returns>
        public static Capacitance operator /(Capacitance left, double right)
        {
            return new Capacitance(left.farads / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Capacitance"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Capacitance"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Capacitance"/>.</param>
        public static Capacitance operator +(Capacitance left, Capacitance right)
        {
            return new Capacitance(left.farads + right.farads);
        }

        /// <summary>
        /// Subtracts an Capacitance from another Capacitance and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Capacitance"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Capacitance"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Capacitance"/> (the subtrahend).</param>
        public static Capacitance operator -(Capacitance left, Capacitance right)
        {
            return new Capacitance(left.farads - right.farads);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Capacitance"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Capacitance"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="capacitance">An instance of <see cref="T:Gu.Units.Capacitance"/></param>
        public static Capacitance operator -(Capacitance capacitance)
        {
            return new Capacitance(-1 * capacitance.farads);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Capacitance"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="capacitance"/>.
        /// </returns>
        /// <param name="capacitance">An instance of <see cref="T:Gu.Units.Capacitance"/></param>
        public static Capacitance operator +(Capacitance capacitance)
        {
            return capacitance;
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
            return this.ToString(format, formatProvider, CapacitanceUnit.Farads);
        }

        public string ToString(CapacitanceUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, CapacitanceUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, CapacitanceUnit unit)
        {
            var quantity = unit.FromSiUnit(this.farads);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Capacitance"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Capacitance"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.Capacitance"/> object to compare to this instance.</param>
        public int CompareTo(Capacitance quantity)
        {
            return this.farads.CompareTo(quantity.farads);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Capacitance"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Capacitance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Capacitance"/> object to compare with this instance.</param>
        public bool Equals(Capacitance other)
        {
            return this.farads.Equals(other.farads);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Capacitance"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Capacitance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Capacitance"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Capacitance other, double tolerance)
        {
            return Math.Abs(this.farads - other.farads) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Capacitance && this.Equals((Capacitance)obj);
        }

        public override int GetHashCode()
        {
            return this.farads.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "farads", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.farads);
        }
    }
}