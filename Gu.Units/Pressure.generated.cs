namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Pressure"/>.
    /// </summary>
    [Serializable]
    public partial struct Pressure : IComparable<Pressure>, IEquatable<Pressure>, IFormattable, IXmlSerializable, IQuantity<MassUnit, I1, LengthUnit, INeg1, TimeUnit, INeg2>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Pascals"/>.
        /// </summary>
        public readonly double Pascals;

        private Pressure(double pascals)
        {
            Pascals = pascals;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Pascals"/>.</param>
        public Pressure(double value, PressureUnit unit)
        {
            Pascals = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Pascals
        /// </summary>
        public double SiValue
        {
            get
            {
                return Pascals;
            }
        }

        /// <summary>
        /// The quantity in nanopascals
        /// </summary>
        public double Nanopascals
        {
            get
            {
                return PressureUnit.Nanopascals.FromSiUnit(Pascals);
            }
        }

        /// <summary>
        /// The quantity in micropascals
        /// </summary>
        public double Micropascals
        {
            get
            {
                return PressureUnit.Micropascals.FromSiUnit(Pascals);
            }
        }

        /// <summary>
        /// The quantity in millipascals
        /// </summary>
        public double Millipascals
        {
            get
            {
                return PressureUnit.Millipascals.FromSiUnit(Pascals);
            }
        }

        /// <summary>
        /// The quantity in kilopascals
        /// </summary>
        public double Kilopascals
        {
            get
            {
                return PressureUnit.Kilopascals.FromSiUnit(Pascals);
            }
        }

        /// <summary>
        /// The quantity in megapascals
        /// </summary>
        public double Megapascals
        {
            get
            {
                return PressureUnit.Megapascals.FromSiUnit(Pascals);
            }
        }

        /// <summary>
        /// The quantity in gigapascals
        /// </summary>
        public double Gigapascals
        {
            get
            {
                return PressureUnit.Gigapascals.FromSiUnit(Pascals);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Pressure"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Pressure"/></param>
        /// <returns></returns>
        public static Pressure Parse(string s)
        {
            return Parser.Parse<PressureUnit, Pressure>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Pressure"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Pressure"/></returns>
        public static Pressure ReadFrom(XmlReader reader)
        {
            var v = new Pressure();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Pressure From(double value, PressureUnit unit)
        {
            return new Pressure(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="pascals">The value in <see cref="T:Gu.Units.Pascals"/></param>
        public static Pressure FromPascals(double pascals)
        {
            return new Pressure(pascals);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="nanopascals">The value in nPa</param>
        public static Pressure FromNanopascals(double nanopascals)
        {
            return From(nanopascals, PressureUnit.Nanopascals);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="micropascals">The value in µPa</param>
        public static Pressure FromMicropascals(double micropascals)
        {
            return From(micropascals, PressureUnit.Micropascals);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="millipascals">The value in mPa</param>
        public static Pressure FromMillipascals(double millipascals)
        {
            return From(millipascals, PressureUnit.Millipascals);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="kilopascals">The value in kPa</param>
        public static Pressure FromKilopascals(double kilopascals)
        {
            return From(kilopascals, PressureUnit.Kilopascals);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="megapascals">The value in MPa</param>
        public static Pressure FromMegapascals(double megapascals)
        {
            return From(megapascals, PressureUnit.Megapascals);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="gigapascals">The value in GPa</param>
        public static Pressure FromGigapascals(double gigapascals)
        {
            return From(gigapascals, PressureUnit.Gigapascals);
        }

        public static Force operator *(Pressure left, Area right)
        {
            return Force.FromNewtons(left.Pascals * right.SquareMetres);
        }

        public static Energy operator *(Pressure left, Volume right)
        {
            return Energy.FromJoules(left.Pascals * right.CubicMetres);
        }

        public static Stiffness operator *(Pressure left, Length right)
        {
            return Stiffness.FromNewtonsPerMetre(left.Pascals * right.Metres);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Pressure"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Pressure"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Pressure"/>.</param>
        public static bool operator ==(Pressure left, Pressure right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Pressure"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Pressure"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Pressure"/>.</param>
        public static bool operator !=(Pressure left, Pressure right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Pressure"/> is less than another specified <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Pressure"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Pressure"/>.</param>
        public static bool operator <(Pressure left, Pressure right)
        {
            return left.Pascals < right.Pascals;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Pressure"/> is greater than another specified <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Pressure"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Pressure"/>.</param>
        public static bool operator >(Pressure left, Pressure right)
        {
            return left.Pascals > right.Pascals;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Pressure"/> is less than or equal to another specified <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Pressure"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Pressure"/>.</param>
        public static bool operator <=(Pressure left, Pressure right)
        {
            return left.Pascals <= right.Pascals;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Pressure"/> is greater than or equal to another specified <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Pressure"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Pressure"/>.</param>
        public static bool operator >=(Pressure left, Pressure right)
        {
            return left.Pascals >= right.Pascals;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Pressure"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Pressure"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Pressure"/> with <paramref name="left"/> and returns the result.</returns>
        public static Pressure operator *(double left, Pressure right)
        {
            return new Pressure(left * right.Pascals);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Pressure"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Pressure"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Pressure"/> with <paramref name="right"/> and returns the result.</returns>
        public static Pressure operator *(Pressure left, double right)
        {
            return new Pressure(left.Pascals * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Pressure"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Pressure"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Pressure"/> with <paramref name="right"/> and returns the result.</returns>
        public static Pressure operator /(Pressure left, double right)
        {
            return new Pressure(left.Pascals / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Pressure"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Pressure"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Pressure"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Pressure operator +(Pressure left, Pressure right)
        {
            return new Pressure(left.Pascals + right.Pascals);
        }

        /// <summary>
        /// Subtracts an Pressure from another Pressure and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Pressure"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Pressure"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.Pressure"/> (the subtrahend).</param>
        public static Pressure operator -(Pressure left, Pressure right)
        {
            return new Pressure(left.Pascals - right.Pascals);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Pressure"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Pressure"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Pressure">A <see cref="T:Gu.Units.Pressure"/></param>
        public static Pressure operator -(Pressure Pressure)
        {
            return new Pressure(-1 * Pressure.Pascals);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Pressure"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="Pressure"/>.
        /// </returns>
        /// <param name="Pressure">A <see cref="T:Gu.Units.Pressure"/></param>
        public static Pressure operator +(Pressure Pressure)
        {
            return Pressure;
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
            return this.ToString(format, formatProvider, PressureUnit.Pascals);
        }

        public string ToString(string format, IFormatProvider formatProvider, PressureUnit unit)
        {
            var quantity = unit.FromSiUnit(this.Pascals);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Pressure"/> object and returns an integer that indicates whether this <see cref="instance"/> is shorter than, equal to, or longer than the <see cref="T:MathNet.Spatial.Units.Pressure"/> object.
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.Pressure"/> object to compare to this instance.</param>
        public int CompareTo(Pressure quantity)
        {
            return this.Pascals.CompareTo(quantity.Pascals);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Pressure"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Pressure as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Pressure"/> object to compare with this instance.</param>
        public bool Equals(Pressure other)
        {
            return this.Pascals.Equals(other.Pascals);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Pressure"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Pressure as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Pressure"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Pressure other, double tolerance)
        {
            return Math.Abs(this.Pascals - other.Pascals) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Pressure && this.Equals((Pressure)obj);
        }

        public override int GetHashCode()
        {
            return this.Pascals.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, x => x.Pascals, reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.Pascals);
        }
    }
}
