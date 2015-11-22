namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Length"/>.
    /// </summary>
    [Serializable]
    public partial struct Length : IComparable<Length>, IEquatable<Length>, IFormattable, IXmlSerializable, IQuantity<LengthUnit, I1>, IQuantity<LengthUnit>
    {
        public static readonly Length Zero = new Length();

        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Metres"/>.
        /// </summary>
        internal readonly double metres;

        private Length(double metres)
        {
            this.metres = metres;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Metres"/>.</param>
        public Length(double value, LengthUnit unit)
        {
            this.metres = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Metres
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.metres;
            }
        }

        /// <summary>
        /// The quantity in metres".
        /// </summary>
        public double Metres
        {
            get
            {
                return this.metres;
            }
        }

        /// <summary>
        /// The quantity in nanometres
        /// </summary>
        public double Nanometres
        {
            get
            {
                return LengthUnit.Nanometres.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in micrometres
        /// </summary>
        public double Micrometres
        {
            get
            {
                return LengthUnit.Micrometres.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in millimetres
        /// </summary>
        public double Millimetres
        {
            get
            {
                return LengthUnit.Millimetres.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in centimetres
        /// </summary>
        public double Centimetres
        {
            get
            {
                return LengthUnit.Centimetres.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in decimetres
        /// </summary>
        public double Decimetres
        {
            get
            {
                return LengthUnit.Decimetres.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in kilometres
        /// </summary>
        public double Kilometres
        {
            get
            {
                return LengthUnit.Kilometres.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in inches
        /// </summary>
        public double Inches
        {
            get
            {
                return LengthUnit.Inches.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in mile
        /// </summary>
        public double Mile
        {
            get
            {
                return LengthUnit.Mile.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in yard
        /// </summary>
        public double Yard
        {
            get
            {
                return LengthUnit.Yard.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// The quantity in nauticalMile
        /// </summary>
        public double NauticalMile
        {
            get
            {
                return LengthUnit.NauticalMile.FromSiUnit(this.metres);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Length"/></param>
        /// <returns></returns>
		public static Length Parse(string s)
        {
            return Parser.Parse<LengthUnit, Length>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static Length Parse(string s, IFormatProvider provider)
        {
            return Parser.Parse<LengthUnit, Length>(s, From, NumberStyles.Float, provider);
        }

        public static Length Parse(string s, NumberStyles styles)
        {
            return Parser.Parse<LengthUnit, Length>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static Length Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return Parser.Parse<LengthUnit, Length>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out Length value)
        {
            return Parser.TryParse<LengthUnit, Length>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, IFormatProvider provider, out Length value)
        {
            return Parser.TryParse<LengthUnit, Length>(s, From, NumberStyles.Float, provider, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out Length value)
        {
            return Parser.TryParse<LengthUnit, Length>(s, From, styles, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out Length value)
        {
            return Parser.TryParse<LengthUnit, Length>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Length"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Length"/></returns>
        public static Length ReadFrom(XmlReader reader)
        {
            var v = new Length();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Length From(double value, LengthUnit unit)
        {
            return new Length(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="metres">The value in <see cref="T:Gu.Units.Metres"/></param>
        public static Length FromMetres(double metres)
        {
            return new Length(metres);
        }


        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="nanometres">The value in nm</param>
        public static Length FromNanometres(double nanometres)
        {
            return From(nanometres, LengthUnit.Nanometres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="micrometres">The value in µm</param>
        public static Length FromMicrometres(double micrometres)
        {
            return From(micrometres, LengthUnit.Micrometres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="millimetres">The value in mm</param>
        public static Length FromMillimetres(double millimetres)
        {
            return From(millimetres, LengthUnit.Millimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="centimetres">The value in cm</param>
        public static Length FromCentimetres(double centimetres)
        {
            return From(centimetres, LengthUnit.Centimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="decimetres">The value in dm</param>
        public static Length FromDecimetres(double decimetres)
        {
            return From(decimetres, LengthUnit.Decimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="kilometres">The value in km</param>
        public static Length FromKilometres(double kilometres)
        {
            return From(kilometres, LengthUnit.Kilometres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="inches">The value in in</param>
        public static Length FromInches(double inches)
        {
            return From(inches, LengthUnit.Inches);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="mile">The value in mi</param>
        public static Length FromMile(double mile)
        {
            return From(mile, LengthUnit.Mile);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="yard">The value in yd</param>
        public static Length FromYard(double yard)
        {
            return From(yard, LengthUnit.Yard);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <param name="nauticalMile">The value in nmi</param>
        public static Length FromNauticalMile(double nauticalMile)
        {
            return From(nauticalMile, LengthUnit.NauticalMile);
        }

        public static Time operator /(Length left, Speed right)
        {
            return Time.FromSeconds(left.metres / right.metresPerSecond);
        }

        public static Area operator *(Length left, Length right)
        {
            return Area.FromSquareMetres(left.metres * right.metres);
        }

        public static Volume operator *(Length left, Area right)
        {
            return Volume.FromCubicMetres(left.metres * right.squareMetres);
        }

        public static Energy operator *(Length left, Force right)
        {
            return Energy.FromJoules(left.metres * right.newtons);
        }

        public static Speed operator /(Length left, Time right)
        {
            return Speed.FromMetresPerSecond(left.metres / right.seconds);
        }

        public static SpecificEnergy operator *(Length left, Acceleration right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.metres * right.metresPerSecondSquared);
        }

        public static Flexibility operator /(Length left, Force right)
        {
            return Flexibility.FromMetresPerNewton(left.metres / right.newtons);
        }

        public static double operator /(Length left, Length right)
        {
            return left.metres / right.metres;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Length"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator ==(Length left, Length right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Length"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator !=(Length left, Length right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Length"/> is less than another specified <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator <(Length left, Length right)
        {
            return left.metres < right.metres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Length"/> is greater than another specified <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator >(Length left, Length right)
        {
            return left.metres > right.metres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Length"/> is less than or equal to another specified <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator <=(Length left, Length right)
        {
            return left.metres <= right.metres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Length"/> is greater than or equal to another specified <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        public static bool operator >=(Length left, Length right)
        {
            return left.metres >= right.metres;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Length"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="left"/> and returns the result.</returns>
        public static Length operator *(double left, Length right)
        {
            return new Length(left * right.metres);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="right"/> and returns the result.</returns>
        public static Length operator *(Length left, double right)
        {
            return new Length(left.metres * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Length"/> with <paramref name="right"/> and returns the result.</returns>
        public static Length operator /(Length left, double right)
        {
            return new Length(left.metres / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Length"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Length"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Length"/>.</param>
        public static Length operator +(Length left, Length right)
        {
            return new Length(left.metres + right.metres);
        }

        /// <summary>
        /// Subtracts an Length from another Length and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Length"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Length"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Length"/> (the subtrahend).</param>
        public static Length operator -(Length left, Length right)
        {
            return new Length(left.metres - right.metres);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Length"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Length"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="length">An instance of <see cref="T:Gu.Units.Length"/></param>
        public static Length operator -(Length length)
        {
            return new Length(-1 * length.metres);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="length"/>.
        /// </returns>
        /// <param name="length">An instance of <see cref="T:Gu.Units.Length"/></param>
        public static Length operator +(Length length)
        {
            return length;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(LengthUnit unit)
        {
            return unit.FromSiUnit(this.metres);
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
            return this.ToString(format, formatProvider, LengthUnit.Metres);
        }

        public string ToString(LengthUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, LengthUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, LengthUnit unit)
        {
            var quantity = unit.FromSiUnit(this.metres);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Length"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Length"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.Length"/> object to compare to this instance.</param>
        public int CompareTo(Length quantity)
        {
            return this.metres.CompareTo(quantity.metres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Length"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Length as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Length"/> object to compare with this instance.</param>
        public bool Equals(Length other)
        {
            return this.metres.Equals(other.metres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Length"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Length as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Length"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Length other, double tolerance)
        {
            return Math.Abs(this.metres - other.metres) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Length && this.Equals((Length)obj);
        }

        public override int GetHashCode()
        {
            return this.metres.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "metres", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.metres);
        }
    }
}