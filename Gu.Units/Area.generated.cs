namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Area"/>.
    /// </summary>
    [Serializable]
    public partial struct Area : IComparable<Area>, IEquatable<Area>, IFormattable, IXmlSerializable, IQuantity<LengthUnit, I2>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.SquareMetres"/>.
        /// </summary>
        public readonly double SquareMetres;

        private Area(double squareMetres)
        {
            SquareMetres = squareMetres;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.SquareMetres"/>.</param>
        public Area(double value, AreaUnit unit)
        {
            SquareMetres = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in SquareMetres
        /// </summary>
        public double SiValue
        {
            get
            {
                return SquareMetres;
            }
        }

        /// <summary>
        /// The quantity in squareMillimetres
        /// </summary>
        public double SquareMillimetres
        {
            get
            {
                return AreaUnit.SquareMillimetres.FromSiUnit(SquareMetres);
            }
        }

        /// <summary>
        /// The quantity in squareCentimetres
        /// </summary>
        public double SquareCentimetres
        {
            get
            {
                return AreaUnit.SquareCentimetres.FromSiUnit(SquareMetres);
            }
        }

        /// <summary>
        /// The quantity in squareDecimetres
        /// </summary>
        public double SquareDecimetres
        {
            get
            {
                return AreaUnit.SquareDecimetres.FromSiUnit(SquareMetres);
            }
        }

        /// <summary>
        /// The quantity in squareKilometres
        /// </summary>
        public double SquareKilometres
        {
            get
            {
                return AreaUnit.SquareKilometres.FromSiUnit(SquareMetres);
            }
        }

        /// <summary>
        /// The quantity in squareInches
        /// </summary>
        public double SquareInches
        {
            get
            {
                return AreaUnit.SquareInches.FromSiUnit(SquareMetres);
            }
        }

        /// <summary>
        /// The quantity in hectare
        /// </summary>
        public double Hectare
        {
            get
            {
                return AreaUnit.Hectare.FromSiUnit(SquareMetres);
            }
        }

        /// <summary>
        /// The quantity in squareMile
        /// </summary>
        public double SquareMile
        {
            get
            {
                return AreaUnit.SquareMile.FromSiUnit(SquareMetres);
            }
        }

        /// <summary>
        /// The quantity in squareYard
        /// </summary>
        public double SquareYard
        {
            get
            {
                return AreaUnit.SquareYard.FromSiUnit(SquareMetres);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Area"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Area"/></param>
        /// <returns></returns>
        public static Area Parse(string s)
        {
            return Parser.Parse<AreaUnit, Area>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Area"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Area"/></returns>
        public static Area ReadFrom(XmlReader reader)
        {
            var v = new Area();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Area From(double value, AreaUnit unit)
        {
            return new Area(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareMetres">The value in <see cref="T:Gu.Units.SquareMetres"/></param>
        public static Area FromSquareMetres(double squareMetres)
        {
            return new Area(squareMetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareMillimetres">The value in mm²</param>
        public static Area FromSquareMillimetres(double squareMillimetres)
        {
            return From(squareMillimetres, AreaUnit.SquareMillimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareCentimetres">The value in cm²</param>
        public static Area FromSquareCentimetres(double squareCentimetres)
        {
            return From(squareCentimetres, AreaUnit.SquareCentimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareDecimetres">The value in dm²</param>
        public static Area FromSquareDecimetres(double squareDecimetres)
        {
            return From(squareDecimetres, AreaUnit.SquareDecimetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareKilometres">The value in km²</param>
        public static Area FromSquareKilometres(double squareKilometres)
        {
            return From(squareKilometres, AreaUnit.SquareKilometres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareInches">The value in in²</param>
        public static Area FromSquareInches(double squareInches)
        {
            return From(squareInches, AreaUnit.SquareInches);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <param name="hectare">The value in ha</param>
        public static Area FromHectare(double hectare)
        {
            return From(hectare, AreaUnit.Hectare);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareMile">The value in mi²</param>
        public static Area FromSquareMile(double squareMile)
        {
            return From(squareMile, AreaUnit.SquareMile);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareYard">The value in yd²</param>
        public static Area FromSquareYard(double squareYard)
        {
            return From(squareYard, AreaUnit.SquareYard);
        }

        public static Length operator /(Area left, Length right)
        {
            return Length.FromMetres(left.SquareMetres / right.Metres);
        }

        public static Volume operator *(Area left, Length right)
        {
            return Volume.FromCubicMetres(left.SquareMetres * right.Metres);
        }

        public static VolumetricFlow operator *(Area left, Speed right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.SquareMetres * right.MetresPerSecond);
        }


        public static double operator /(Area left, Area right)
        {
            return left.SquareMetres / right.SquareMetres;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Area"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Area"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Area"/>.</param>
        public static bool operator ==(Area left, Area right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Area"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Area"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Area"/>.</param>
        public static bool operator !=(Area left, Area right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Area"/> is less than another specified <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Area"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Area"/>.</param>
        public static bool operator <(Area left, Area right)
        {
            return left.SquareMetres < right.SquareMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Area"/> is greater than another specified <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Area"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Area"/>.</param>
        public static bool operator >(Area left, Area right)
        {
            return left.SquareMetres > right.SquareMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Area"/> is less than or equal to another specified <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Area"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Area"/>.</param>
        public static bool operator <=(Area left, Area right)
        {
            return left.SquareMetres <= right.SquareMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Area"/> is greater than or equal to another specified <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Area"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Area"/>.</param>
        public static bool operator >=(Area left, Area right)
        {
            return left.SquareMetres >= right.SquareMetres;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Area"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Area"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Area"/> with <paramref name="left"/> and returns the result.</returns>
        public static Area operator *(double left, Area right)
        {
            return new Area(left * right.SquareMetres);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Area"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Area"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Area"/> with <paramref name="right"/> and returns the result.</returns>
        public static Area operator *(Area left, double right)
        {
            return new Area(left.SquareMetres * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Area"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Area"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Area"/> with <paramref name="right"/> and returns the result.</returns>
        public static Area operator /(Area left, double right)
        {
            return new Area(left.SquareMetres / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Area"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Area"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Area"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Area operator +(Area left, Area right)
        {
            return new Area(left.SquareMetres + right.SquareMetres);
        }

        /// <summary>
        /// Subtracts an Area from another Area and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Area"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Area"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.Area"/> (the subtrahend).</param>
        public static Area operator -(Area left, Area right)
        {
            return new Area(left.SquareMetres - right.SquareMetres);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Area"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Area"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Area">A <see cref="T:Gu.Units.Area"/></param>
        public static Area operator -(Area Area)
        {
            return new Area(-1 * Area.SquareMetres);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="Area"/>.
        /// </returns>
        /// <param name="Area">A <see cref="T:Gu.Units.Area"/></param>
        public static Area operator +(Area Area)
        {
            return Area;
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
            return this.ToString(format, formatProvider, AreaUnit.SquareMetres);
        }

        public string ToString(string format, IFormatProvider formatProvider, AreaUnit unit)
        {
            var quantity = unit.FromSiUnit(this.SquareMetres);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Area"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Area"/> object.
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.Area"/> object to compare to this instance.</param>
        public int CompareTo(Area quantity)
        {
            return this.SquareMetres.CompareTo(quantity.SquareMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Area"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Area as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Area"/> object to compare with this instance.</param>
        public bool Equals(Area other)
        {
            return this.SquareMetres.Equals(other.SquareMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Area"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Area as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Area"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Area other, double tolerance)
        {
            return Math.Abs(this.SquareMetres - other.SquareMetres) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Area && this.Equals((Area)obj);
        }

        public override int GetHashCode()
        {
            return this.SquareMetres.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "SquareMetres", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.SquareMetres);
        }
    }
}
