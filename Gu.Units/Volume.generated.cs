namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Volume"/>.
    /// </summary>
    [Serializable]
    public partial struct Volume : IComparable<Volume>, IEquatable<Volume>, IFormattable, IXmlSerializable, IQuantity<LengthUnit, I3>, IQuantity<VolumeUnit>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.CubicMetres"/>.
        /// </summary>
        internal readonly double cubicMetres;

        private Volume(double cubicMetres)
        {
            this.cubicMetres = cubicMetres;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.CubicMetres"/>.</param>
        public Volume(double value, VolumeUnit unit)
        {
            this.cubicMetres = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in CubicMetres
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.cubicMetres;
            }
        }

        /// <summary>
        /// The quantity in cubicMetres".
        /// </summary>
        public double CubicMetres
        {
            get
            {
                return this.cubicMetres;
            }
        }

        /// <summary>
        /// The quantity in litres
        /// </summary>
        public double Litres
        {
            get
            {
                return VolumeUnit.Litres.FromSiUnit(this.cubicMetres);
            }
        }

        /// <summary>
        /// The quantity in cubicCentimetres
        /// </summary>
        public double CubicCentimetres
        {
            get
            {
                return VolumeUnit.CubicCentimetres.FromSiUnit(this.cubicMetres);
            }
        }

        /// <summary>
        /// The quantity in cubicMillimetres
        /// </summary>
        public double CubicMillimetres
        {
            get
            {
                return VolumeUnit.CubicMillimetres.FromSiUnit(this.cubicMetres);
            }
        }

        /// <summary>
        /// The quantity in cubicInches
        /// </summary>
        public double CubicInches
        {
            get
            {
                return VolumeUnit.CubicInches.FromSiUnit(this.cubicMetres);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Volume"/></param>
        /// <returns></returns>
        public static Volume Parse(string s)
        {
            return Parser.Parse<VolumeUnit, Volume>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Volume"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Volume"/></returns>
        public static Volume ReadFrom(XmlReader reader)
        {
            var v = new Volume();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Volume From(double value, VolumeUnit unit)
        {
            return new Volume(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicMetres">The value in <see cref="T:Gu.Units.CubicMetres"/></param>
        public static Volume FromCubicMetres(double cubicMetres)
        {
            return new Volume(cubicMetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="litres">The value in L</param>
        public static Volume FromLitres(double litres)
        {
            return From(litres, VolumeUnit.Litres);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicCentimetres">The value in cm³</param>
        public static Volume FromCubicCentimetres(double cubicCentimetres)
        {
            return From(cubicCentimetres, VolumeUnit.CubicCentimetres);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicMillimetres">The value in mm³</param>
        public static Volume FromCubicMillimetres(double cubicMillimetres)
        {
            return From(cubicMillimetres, VolumeUnit.CubicMillimetres);
        }
        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicInches">The value in in³</param>
        public static Volume FromCubicInches(double cubicInches)
        {
            return From(cubicInches, VolumeUnit.CubicInches);
        }

        public static Mass operator *(Volume left, Density right)
        {
            return Mass.FromKilograms(left.cubicMetres * right.kilogramsPerCubicMetre);
        }

        public static Length operator /(Volume left, Area right)
        {
            return Length.FromMetres(left.cubicMetres / right.squareMetres);
        }

        public static Area operator /(Volume left, Length right)
        {
            return Area.FromSquareMetres(left.cubicMetres / right.metres);
        }

        public static VolumetricFlow operator /(Volume left, Time right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.cubicMetres / right.seconds);
        }

        public static double operator /(Volume left, Volume right)
        {
            return left.cubicMetres / right.cubicMetres;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Volume"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        public static bool operator ==(Volume left, Volume right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Volume"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        public static bool operator !=(Volume left, Volume right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Volume"/> is less than another specified <see cref="T:Gu.Units.Volume"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        public static bool operator <(Volume left, Volume right)
        {
            return left.cubicMetres < right.cubicMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Volume"/> is greater than another specified <see cref="T:Gu.Units.Volume"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        public static bool operator >(Volume left, Volume right)
        {
            return left.cubicMetres > right.cubicMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Volume"/> is less than or equal to another specified <see cref="T:Gu.Units.Volume"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        public static bool operator <=(Volume left, Volume right)
        {
            return left.cubicMetres <= right.cubicMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Volume"/> is greater than or equal to another specified <see cref="T:Gu.Units.Volume"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        public static bool operator >=(Volume left, Volume right)
        {
            return left.cubicMetres >= right.cubicMetres;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Volume"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Volume"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Volume"/> with <paramref name="left"/> and returns the result.</returns>
        public static Volume operator *(double left, Volume right)
        {
            return new Volume(left * right.cubicMetres);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Volume"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Volume"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Volume"/> with <paramref name="right"/> and returns the result.</returns>
        public static Volume operator *(Volume left, double right)
        {
            return new Volume(left.cubicMetres * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Volume"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Volume"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Volume"/> with <paramref name="right"/> and returns the result.</returns>
        public static Volume operator /(Volume left, double right)
        {
            return new Volume(left.cubicMetres / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Volume"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Volume"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Volume"/>.</param>
        public static Volume operator +(Volume left, Volume right)
        {
            return new Volume(left.cubicMetres + right.cubicMetres);
        }

        /// <summary>
        /// Subtracts an Volume from another Volume and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Volume"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Volume"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Volume"/> (the subtrahend).</param>
        public static Volume operator -(Volume left, Volume right)
        {
            return new Volume(left.cubicMetres - right.cubicMetres);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Volume"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Volume"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="volume">An instance of <see cref="T:Gu.Units.Volume"/></param>
        public static Volume operator -(Volume volume)
        {
            return new Volume(-1 * volume.cubicMetres);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Volume"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="volume"/>.
        /// </returns>
        /// <param name="volume">An instance of <see cref="T:Gu.Units.Volume"/></param>
        public static Volume operator +(Volume volume)
        {
            return volume;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(VolumeUnit unit)
        {
            return unit.FromSiUnit(this.cubicMetres);
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
            return this.ToString(format, formatProvider, VolumeUnit.CubicMetres);
        }

        public string ToString(VolumeUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, VolumeUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, VolumeUnit unit)
        {
            var quantity = unit.FromSiUnit(this.cubicMetres);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Volume"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.Volume"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.Volume"/> object to compare to this instance.</param>
        public int CompareTo(Volume quantity)
        {
            return this.cubicMetres.CompareTo(quantity.cubicMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Volume"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Volume as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Volume"/> object to compare with this instance.</param>
        public bool Equals(Volume other)
        {
            return this.cubicMetres.Equals(other.cubicMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Volume"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Volume as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.Volume"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Volume other, double tolerance)
        {
            return Math.Abs(this.cubicMetres - other.cubicMetres) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Volume && this.Equals((Volume)obj);
        }

        public override int GetHashCode()
        {
            return this.cubicMetres.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "cubicMetres", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.cubicMetres);
        }
    }
}