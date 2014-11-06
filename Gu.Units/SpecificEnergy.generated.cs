namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.SpecificEnergy"/>.
    /// </summary>
    [Serializable]
    public partial struct SpecificEnergy : IComparable<SpecificEnergy>, IEquatable<SpecificEnergy>, IFormattable, IXmlSerializable, IQuantity<LengthUnit, I2, TimeUnit, INeg2>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.JoulesPerKilogram"/>.
        /// </summary>
        public readonly double JoulesPerKilogram;

        private SpecificEnergy(double joulesPerKilogram)
        {
            JoulesPerKilogram = joulesPerKilogram;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.JoulesPerKilogram"/>.</param>
        public SpecificEnergy(double value, SpecificEnergyUnit unit)
        {
            JoulesPerKilogram = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in JoulesPerKilogram
        /// </summary>
        public double SiValue
        {
            get
            {
                return JoulesPerKilogram;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.SpecificEnergy"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.SpecificEnergy"/></param>
        /// <returns></returns>
        public static SpecificEnergy Parse(string s)
        {
            return Parser.Parse<SpecificEnergyUnit, SpecificEnergy>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.SpecificEnergy"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.SpecificEnergy"/></returns>
        public static SpecificEnergy ReadFrom(XmlReader reader)
        {
            var v = new SpecificEnergy();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static SpecificEnergy From(double value, SpecificEnergyUnit unit)
        {
            return new SpecificEnergy(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <param name="joulesPerKilogram">The value in <see cref="T:Gu.Units.JoulesPerKilogram"/></param>
        public static SpecificEnergy FromJoulesPerKilogram(double joulesPerKilogram)
        {
            return new SpecificEnergy(joulesPerKilogram);
        }


        public static Length operator /(SpecificEnergy left, Acceleration right)
        {
            return Length.FromMetres(left.JoulesPerKilogram / right.MetresPerSecondSquared);
        }

        public static Pressure operator *(SpecificEnergy left, Density right)
        {
            return Pressure.FromPascals(left.JoulesPerKilogram * right.KilogramsPerCubicMetre);
        }

        public static Energy operator *(SpecificEnergy left, Mass right)
        {
            return Energy.FromJoules(left.JoulesPerKilogram * right.Kilograms);
        }

        public static Speed operator /(SpecificEnergy left, Speed right)
        {
            return Speed.FromMetresPerSecond(left.JoulesPerKilogram / right.MetresPerSecond);
        }

        public static Acceleration operator /(SpecificEnergy left, Length right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.JoulesPerKilogram / right.Metres);
        }

        public static double operator /(SpecificEnergy left, SpecificEnergy right)
        {
            return left.JoulesPerKilogram / right.JoulesPerKilogram;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.SpecificEnergy"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator ==(SpecificEnergy left, SpecificEnergy right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.SpecificEnergy"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator !=(SpecificEnergy left, SpecificEnergy right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.SpecificEnergy"/> is less than another specified <see cref="T:Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator <(SpecificEnergy left, SpecificEnergy right)
        {
            return left.JoulesPerKilogram < right.JoulesPerKilogram;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.SpecificEnergy"/> is greater than another specified <see cref="T:Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator >(SpecificEnergy left, SpecificEnergy right)
        {
            return left.JoulesPerKilogram > right.JoulesPerKilogram;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.SpecificEnergy"/> is less than or equal to another specified <see cref="T:Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator <=(SpecificEnergy left, SpecificEnergy right)
        {
            return left.JoulesPerKilogram <= right.JoulesPerKilogram;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.SpecificEnergy"/> is greater than or equal to another specified <see cref="T:Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator >=(SpecificEnergy left, SpecificEnergy right)
        {
            return left.JoulesPerKilogram >= right.JoulesPerKilogram;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.SpecificEnergy"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.SpecificEnergy"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.SpecificEnergy"/> with <paramref name="left"/> and returns the result.</returns>
        public static SpecificEnergy operator *(double left, SpecificEnergy right)
        {
            return new SpecificEnergy(left * right.JoulesPerKilogram);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.SpecificEnergy"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.SpecificEnergy"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.SpecificEnergy"/> with <paramref name="right"/> and returns the result.</returns>
        public static SpecificEnergy operator *(SpecificEnergy left, double right)
        {
            return new SpecificEnergy(left.JoulesPerKilogram * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.SpecificEnergy"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.SpecificEnergy"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.SpecificEnergy"/> with <paramref name="right"/> and returns the result.</returns>
        public static SpecificEnergy operator /(SpecificEnergy left, double right)
        {
            return new SpecificEnergy(left.JoulesPerKilogram / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.SpecificEnergy"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.SpecificEnergy"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static SpecificEnergy operator +(SpecificEnergy left, SpecificEnergy right)
        {
            return new SpecificEnergy(left.JoulesPerKilogram + right.JoulesPerKilogram);
        }

        /// <summary>
        /// Subtracts an SpecificEnergy from another SpecificEnergy and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.SpecificEnergy"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.SpecificEnergy"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.SpecificEnergy"/> (the subtrahend).</param>
        public static SpecificEnergy operator -(SpecificEnergy left, SpecificEnergy right)
        {
            return new SpecificEnergy(left.JoulesPerKilogram - right.JoulesPerKilogram);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.SpecificEnergy"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.SpecificEnergy"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="SpecificEnergy">A <see cref="T:Gu.Units.SpecificEnergy"/></param>
        public static SpecificEnergy operator -(SpecificEnergy SpecificEnergy)
        {
            return new SpecificEnergy(-1 * SpecificEnergy.JoulesPerKilogram);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="SpecificEnergy"/>.
        /// </returns>
        /// <param name="SpecificEnergy">A <see cref="T:Gu.Units.SpecificEnergy"/></param>
        public static SpecificEnergy operator +(SpecificEnergy SpecificEnergy)
        {
            return SpecificEnergy;
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
            return this.ToString(format, formatProvider, SpecificEnergyUnit.JoulesPerKilogram);
        }

        public string ToString(string format, IFormatProvider formatProvider, SpecificEnergyUnit unit)
        {
            var quantity = unit.FromSiUnit(this.JoulesPerKilogram);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.SpecificEnergy"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.SpecificEnergy"/> object.
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.SpecificEnergy"/> object to compare to this instance.</param>
        public int CompareTo(SpecificEnergy quantity)
        {
            return this.JoulesPerKilogram.CompareTo(quantity.JoulesPerKilogram);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.SpecificEnergy"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same SpecificEnergy as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.SpecificEnergy"/> object to compare with this instance.</param>
        public bool Equals(SpecificEnergy other)
        {
            return this.JoulesPerKilogram.Equals(other.JoulesPerKilogram);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.SpecificEnergy"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same SpecificEnergy as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.SpecificEnergy"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(SpecificEnergy other, double tolerance)
        {
            return Math.Abs(this.JoulesPerKilogram - other.JoulesPerKilogram) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is SpecificEnergy && this.Equals((SpecificEnergy)obj);
        }

        public override int GetHashCode()
        {
            return this.JoulesPerKilogram.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "JoulesPerKilogram", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.JoulesPerKilogram);
        }
    }
}
