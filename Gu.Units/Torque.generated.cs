namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Torque"/>.
    /// </summary>
    [Serializable]
    public partial struct Torque : IComparable<Torque>, IEquatable<Torque>, IFormattable, IXmlSerializable, IQuantity<MassUnit, I1, LengthUnit, I2, TimeUnit, INeg2, AngleUnit, INeg1>, IQuantity<TorqueUnit>
    {
        public static readonly Torque Zero = new Torque();

        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.NewtonMetres"/>.
        /// </summary>
        internal readonly double newtonMetres;

        private Torque(double newtonMetres)
        {
            this.newtonMetres = newtonMetres;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Torque"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.NewtonMetres"/>.</param>
        public Torque(double value, TorqueUnit unit)
        {
            this.newtonMetres = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in NewtonMetres
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.newtonMetres;
            }
        }

        /// <summary>
        /// The quantity in newtonMetres".
        /// </summary>
        public double NewtonMetres
        {
            get
            {
                return this.newtonMetres;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Torque"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Torque"/></param>
        /// <returns></returns>
		public static Torque Parse(string s)
        {
            return Parser.Parse<TorqueUnit, Torque>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static Torque Parse(string s, IFormatProvider provider)
        {
            return Parser.Parse<TorqueUnit, Torque>(s, From, NumberStyles.Float, provider);
        }

        public static Torque Parse(string s, NumberStyles styles)
        {
            return Parser.Parse<TorqueUnit, Torque>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static Torque Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return Parser.Parse<TorqueUnit, Torque>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out Torque value)
        {
            return Parser.TryParse<TorqueUnit, Torque>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out Torque value)
        {
            return Parser.TryParse<TorqueUnit, Torque>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out Torque value)
        {
            return Parser.TryParse<TorqueUnit, Torque>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out Torque value)
        {
            return Parser.TryParse<TorqueUnit, Torque>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Torque"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Torque"/></returns>
        public static Torque ReadFrom(XmlReader reader)
        {
            var v = new Torque();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Torque"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Torque From(double value, TorqueUnit unit)
        {
            return new Torque(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Torque"/>.
        /// </summary>
        /// <param name="newtonMetres">The value in <see cref="T:Gu.Units.NewtonMetres"/></param>
        public static Torque FromNewtonMetres(double newtonMetres)
        {
            return new Torque(newtonMetres);
        }


        public static Energy operator *(Torque left, Angle right)
        {
            return Energy.FromJoules(left.newtonMetres * right.radians);
        }

        public static Power operator *(Torque left, AngularSpeed right)
        {
            return Power.FromWatts(left.newtonMetres * right.radiansPerSecond);
        }

        public static double operator /(Torque left, Torque right)
        {
            return left.newtonMetres / right.newtonMetres;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Torque"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        public static bool operator ==(Torque left, Torque right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Torque"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        public static bool operator !=(Torque left, Torque right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Torque"/> is less than another specified <see cref="T:Gu.Units.Torque"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        public static bool operator <(Torque left, Torque right)
        {
            return left.newtonMetres < right.newtonMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Torque"/> is greater than another specified <see cref="T:Gu.Units.Torque"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        public static bool operator >(Torque left, Torque right)
        {
            return left.newtonMetres > right.newtonMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Torque"/> is less than or equal to another specified <see cref="T:Gu.Units.Torque"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        public static bool operator <=(Torque left, Torque right)
        {
            return left.newtonMetres <= right.newtonMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Torque"/> is greater than or equal to another specified <see cref="T:Gu.Units.Torque"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        public static bool operator >=(Torque left, Torque right)
        {
            return left.newtonMetres >= right.newtonMetres;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Torque"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Torque"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Torque"/> with <paramref name="left"/> and returns the result.</returns>
        public static Torque operator *(double left, Torque right)
        {
            return new Torque(left * right.newtonMetres);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Torque"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Torque"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Torque"/> with <paramref name="right"/> and returns the result.</returns>
        public static Torque operator *(Torque left, double right)
        {
            return new Torque(left.newtonMetres * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Torque"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Torque"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Torque"/> with <paramref name="right"/> and returns the result.</returns>
        public static Torque operator /(Torque left, double right)
        {
            return new Torque(left.newtonMetres / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Torque"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Torque"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Torque"/>.</param>
        public static Torque operator +(Torque left, Torque right)
        {
            return new Torque(left.newtonMetres + right.newtonMetres);
        }

        /// <summary>
        /// Subtracts an Torque from another Torque and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Torque"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Torque"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Torque"/> (the subtrahend).</param>
        public static Torque operator -(Torque left, Torque right)
        {
            return new Torque(left.newtonMetres - right.newtonMetres);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Torque"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Torque"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="torque">An instance of <see cref="T:Gu.Units.Torque"/></param>
        public static Torque operator -(Torque torque)
        {
            return new Torque(-1 * torque.newtonMetres);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Torque"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="torque"/>.
        /// </returns>
        /// <param name="torque">An instance of <see cref="T:Gu.Units.Torque"/></param>
        public static Torque operator +(Torque torque)
        {
            return torque;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(TorqueUnit unit)
        {
            return unit.FromSiUnit(this.newtonMetres);
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
            return this.ToString(format, formatProvider, TorqueUnit.NewtonMetres);
        }

        public string ToString(TorqueUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, TorqueUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, TorqueUnit unit)
        {
            var quantity = unit.FromSiUnit(this.newtonMetres);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Torque"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Torque"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.Torque"/> object to compare to this instance.</param>
        public int CompareTo(Torque quantity)
        {
            return this.newtonMetres.CompareTo(quantity.newtonMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Torque"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Torque as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Torque"/> object to compare with this instance.</param>
        public bool Equals(Torque other)
        {
            return this.newtonMetres.Equals(other.newtonMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Torque"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Torque as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Torque"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Torque other, double tolerance)
        {
            return Math.Abs(this.newtonMetres - other.newtonMetres) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Torque && this.Equals((Torque)obj);
        }

        public override int GetHashCode()
        {
            return this.newtonMetres.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "newtonMetres", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.newtonMetres);
        }
    }
}