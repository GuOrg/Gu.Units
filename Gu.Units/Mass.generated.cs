namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Mass"/>.
    /// </summary>
    [Serializable]
    public partial struct Mass : IComparable<Mass>, IEquatable<Mass>, IFormattable, IXmlSerializable, IQuantity<MassUnit, I1>, IQuantity<MassUnit>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Kilograms"/>.
        /// </summary>
        internal readonly double kilograms;

        private Mass(double kilograms)
        {
            this.kilograms = kilograms;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Kilograms"/>.</param>
        public Mass(double value, MassUnit unit)
        {
            this.kilograms = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Kilograms
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.kilograms;
            }
        }

        /// <summary>
        /// The quantity in kilograms".
        /// </summary>
        public double Kilograms
        {
            get
            {
                return this.kilograms;
            }
        }

        /// <summary>
        /// The quantity in grams
        /// </summary>
        public double Grams
        {
            get
            {
                return MassUnit.Grams.FromSiUnit(this.kilograms);
            }
        }

        /// <summary>
        /// The quantity in milligrams
        /// </summary>
        public double Milligrams
        {
            get
            {
                return MassUnit.Milligrams.FromSiUnit(this.kilograms);
            }
        }

        /// <summary>
        /// The quantity in micrograms
        /// </summary>
        public double Micrograms
        {
            get
            {
                return MassUnit.Micrograms.FromSiUnit(this.kilograms);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Mass"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Mass"/></param>
        /// <returns></returns>
        public static Mass Parse(string s)
        {
            return Parser.Parse<MassUnit, Mass>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static Mass Parse(string s, IFormatProvider provider)
        {
            return Parser.Parse<MassUnit, Mass>(s, From, NumberStyles.Float, provider);
        }

        public static Mass Parse(string s, NumberStyles styles)
        {
            return Parser.Parse<MassUnit, Mass>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static Mass Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return Parser.Parse<MassUnit, Mass>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out Mass value)
        {
            return Parser.TryParse<MassUnit, Mass>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }


        public static bool TryParse(string s, IFormatProvider provider, out Mass value)
        {
            return Parser.TryParse<MassUnit, Mass>(s, From, NumberStyles.Float, provider, out  value);
        }

        public static bool TryParse(string s, NumberStyles styles, out Mass value)
        {
            return Parser.TryParse<MassUnit, Mass>(s, From, styles, CultureInfo.CurrentCulture, out  value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out Mass value)
        {
            return Parser.TryParse<MassUnit, Mass>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Mass"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Mass"/></returns>
        public static Mass ReadFrom(XmlReader reader)
        {
            var v = new Mass();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Mass From(double value, MassUnit unit)
        {
            return new Mass(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="kilograms">The value in <see cref="T:Gu.Units.Kilograms"/></param>
        public static Mass FromKilograms(double kilograms)
        {
            return new Mass(kilograms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="grams">The value in g</param>
        public static Mass FromGrams(double grams)
        {
            return From(grams, MassUnit.Grams);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="milligrams">The value in mg</param>
        public static Mass FromMilligrams(double milligrams)
        {
            return From(milligrams, MassUnit.Milligrams);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <param name="micrograms">The value in µg</param>
        public static Mass FromMicrograms(double micrograms)
        {
            return From(micrograms, MassUnit.Micrograms);
        }

        public static Volume operator /(Mass left, Density right)
        {
            return Volume.FromCubicMetres(left.kilograms / right.kilogramsPerCubicMetre);
        }

        public static Force operator *(Mass left, Acceleration right)
        {
            return Force.FromNewtons(left.kilograms * right.metresPerSecondSquared);
        }

        public static Density operator /(Mass left, Volume right)
        {
            return Density.FromKilogramsPerCubicMetre(left.kilograms / right.cubicMetres);
        }

        public static double operator /(Mass left, Mass right)
        {
            return left.kilograms / right.kilograms;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Mass"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        public static bool operator ==(Mass left, Mass right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Mass"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        public static bool operator !=(Mass left, Mass right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Mass"/> is less than another specified <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        public static bool operator <(Mass left, Mass right)
        {
            return left.kilograms < right.kilograms;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Mass"/> is greater than another specified <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        public static bool operator >(Mass left, Mass right)
        {
            return left.kilograms > right.kilograms;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Mass"/> is less than or equal to another specified <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        public static bool operator <=(Mass left, Mass right)
        {
            return left.kilograms <= right.kilograms;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Mass"/> is greater than or equal to another specified <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        public static bool operator >=(Mass left, Mass right)
        {
            return left.kilograms >= right.kilograms;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Mass"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Mass"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Mass"/> with <paramref name="left"/> and returns the result.</returns>
        public static Mass operator *(double left, Mass right)
        {
            return new Mass(left * right.kilograms);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Mass"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Mass"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Mass"/> with <paramref name="right"/> and returns the result.</returns>
        public static Mass operator *(Mass left, double right)
        {
            return new Mass(left.kilograms * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Mass"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Mass"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Mass"/> with <paramref name="right"/> and returns the result.</returns>
        public static Mass operator /(Mass left, double right)
        {
            return new Mass(left.kilograms / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Mass"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Mass"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Mass"/>.</param>
        public static Mass operator +(Mass left, Mass right)
        {
            return new Mass(left.kilograms + right.kilograms);
        }

        /// <summary>
        /// Subtracts an Mass from another Mass and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Mass"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Mass"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Mass"/> (the subtrahend).</param>
        public static Mass operator -(Mass left, Mass right)
        {
            return new Mass(left.kilograms - right.kilograms);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Mass"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Mass"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="mass">An instance of <see cref="T:Gu.Units.Mass"/></param>
        public static Mass operator -(Mass mass)
        {
            return new Mass(-1 * mass.kilograms);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Mass"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="mass"/>.
        /// </returns>
        /// <param name="mass">An instance of <see cref="T:Gu.Units.Mass"/></param>
        public static Mass operator +(Mass mass)
        {
            return mass;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(MassUnit unit)
        {
            return unit.FromSiUnit(this.kilograms);
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
            return this.ToString(format, formatProvider, MassUnit.Kilograms);
        }

        public string ToString(MassUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, MassUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, MassUnit unit)
        {
            var quantity = unit.FromSiUnit(this.kilograms);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Mass"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Mass"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.Mass"/> object to compare to this instance.</param>
        public int CompareTo(Mass quantity)
        {
            return this.kilograms.CompareTo(quantity.kilograms);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Mass"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Mass as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Mass"/> object to compare with this instance.</param>
        public bool Equals(Mass other)
        {
            return this.kilograms.Equals(other.kilograms);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Mass"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Mass as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Mass"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Mass other, double tolerance)
        {
            return Math.Abs(this.kilograms - other.kilograms) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Mass && this.Equals((Mass)obj);
        }

        public override int GetHashCode()
        {
            return this.kilograms.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "kilograms", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.kilograms);
        }
    }
}