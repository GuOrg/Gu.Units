namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.Energy"/>.
    /// </summary>
    [Serializable]
    public partial struct Energy : IComparable<Energy>, IEquatable<Energy>, IFormattable, IXmlSerializable, IQuantity<MassUnit, I1, LengthUnit, I2, TimeUnit, INeg2>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.Joules"/>.
        /// </summary>
        public readonly double Joules;

        private Energy(double joules)
        {
            Joules = joules;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.Joules"/>.</param>
        public Energy(double value, EnergyUnit unit)
        {
            Joules = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in Joules
        /// </summary>
        public double SiValue
        {
            get
            {
                return Joules;
            }
        }

        /// <summary>
        /// The quantity in nanojoules
        /// </summary>
        public double Nanojoules
        {
            get
            {
                return EnergyUnit.Nanojoules.FromSiUnit(Joules);
            }
        }

        /// <summary>
        /// The quantity in microjoules
        /// </summary>
        public double Microjoules
        {
            get
            {
                return EnergyUnit.Microjoules.FromSiUnit(Joules);
            }
        }

        /// <summary>
        /// The quantity in millijoules
        /// </summary>
        public double Millijoules
        {
            get
            {
                return EnergyUnit.Millijoules.FromSiUnit(Joules);
            }
        }

        /// <summary>
        /// The quantity in kilojoules
        /// </summary>
        public double Kilojoules
        {
            get
            {
                return EnergyUnit.Kilojoules.FromSiUnit(Joules);
            }
        }

        /// <summary>
        /// The quantity in megajoules
        /// </summary>
        public double Megajoules
        {
            get
            {
                return EnergyUnit.Megajoules.FromSiUnit(Joules);
            }
        }

        /// <summary>
        /// The quantity in gigajoules
        /// </summary>
        public double Gigajoules
        {
            get
            {
                return EnergyUnit.Gigajoules.FromSiUnit(Joules);
            }
        }

        /// <summary>
        /// The quantity in kilowattHours
        /// </summary>
        public double KilowattHours
        {
            get
            {
                return EnergyUnit.KilowattHours.FromSiUnit(Joules);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.Energy"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.Energy"/></param>
        /// <returns></returns>
        public static Energy Parse(string s)
        {
            return Parser.Parse<EnergyUnit, Energy>(s, From);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.Energy"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.Energy"/></returns>
        public static Energy ReadFrom(XmlReader reader)
        {
            var v = new Energy();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Energy From(double value, EnergyUnit unit)
        {
            return new Energy(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="joules">The value in <see cref="T:Gu.Units.Joules"/></param>
        public static Energy FromJoules(double joules)
        {
            return new Energy(joules);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="nanojoules">The value in nJ</param>
        public static Energy FromNanojoules(double nanojoules)
        {
            return From(nanojoules, EnergyUnit.Nanojoules);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="microjoules">The value in µJ</param>
        public static Energy FromMicrojoules(double microjoules)
        {
            return From(microjoules, EnergyUnit.Microjoules);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="millijoules">The value in mJ</param>
        public static Energy FromMillijoules(double millijoules)
        {
            return From(millijoules, EnergyUnit.Millijoules);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="kilojoules">The value in kJ</param>
        public static Energy FromKilojoules(double kilojoules)
        {
            return From(kilojoules, EnergyUnit.Kilojoules);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="megajoules">The value in MJ</param>
        public static Energy FromMegajoules(double megajoules)
        {
            return From(megajoules, EnergyUnit.Megajoules);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="gigajoules">The value in GJ</param>
        public static Energy FromGigajoules(double gigajoules)
        {
            return From(gigajoules, EnergyUnit.Gigajoules);
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="kilowattHours">The value in kWh</param>
        public static Energy FromKilowattHours(double kilowattHours)
        {
            return From(kilowattHours, EnergyUnit.KilowattHours);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Energy"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Energy"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Energy"/>.</param>
        public static bool operator ==(Energy left, Energy right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.Energy"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Energy"/>.</param>
        /// <param name="right">A <see cref="T:Gu.Units.Energy"/>.</param>
        public static bool operator !=(Energy left, Energy right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Energy"/> is less than another specified <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Energy"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Energy"/>.</param>
        public static bool operator <(Energy left, Energy right)
        {
            return left.Joules < right.Joules;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Energy"/> is greater than another specified <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Energy"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Energy"/>.</param>
        public static bool operator >(Energy left, Energy right)
        {
            return left.Joules > right.Joules;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Energy"/> is less than or equal to another specified <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Energy"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Energy"/>.</param>
        public static bool operator <=(Energy left, Energy right)
        {
            return left.Joules <= right.Joules;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.Energy"/> is greater than or equal to another specified <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An <see cref="T:Gu.Units.Energy"/>.</param>
        /// <param name="right">An <see cref="T:Gu.Units.Energy"/>.</param>
        public static bool operator >=(Energy left, Energy right)
        {
            return left.Joules >= right.Joules;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Energy"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.Energy"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Energy"/> with <paramref name="left"/> and returns the result.</returns>
        public static Energy operator *(double left, Energy right)
        {
            return new Energy(left * right.Joules);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.Energy"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Energy"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.Energy"/> with <paramref name="right"/> and returns the result.</returns>
        public static Energy operator *(Energy left, double right)
        {
            return new Energy(left.Joules * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.Energy"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.Energy"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.Energy"/> with <paramref name="right"/> and returns the result.</returns>
        public static Energy operator /(Energy left, double right)
        {
            return new Energy(left.Joules / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.Energy"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Energy"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Energy"/>.</param>
        /// <param name="right">A TimeSpan.</param>
        public static Energy operator +(Energy left, Energy right)
        {
            return new Energy(left.Joules + right.Joules);
        }

        /// <summary>
        /// Subtracts an Energy from another Energy and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Energy"/> that is the difference
        /// </returns>
        /// <param name="left">A <see cref="T:Gu.Units.Energy"/> (the minuend).</param>
        /// <param name="right">A <see cref="T:Gu.Units.Energy"/> (the subtrahend).</param>
        public static Energy operator -(Energy left, Energy right)
        {
            return new Energy(left.Joules - right.Joules);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.Energy"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.Energy"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="Energy">A <see cref="T:Gu.Units.Energy"/></param>
        public static Energy operator -(Energy Energy)
        {
            return new Energy(-1 * Energy.Joules);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.Energy"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="Energy"/>.
        /// </returns>
        /// <param name="Energy">A <see cref="T:Gu.Units.Energy"/></param>
        public static Energy operator +(Energy Energy)
        {
            return Energy;
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
            return this.ToString(format, formatProvider, EnergyUnit.Joules);
        }

        public string ToString(string format, IFormatProvider formatProvider, EnergyUnit unit)
        {
            var quantity = unit.FromSiUnit(this.Joules);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.Energy"/> object and returns an integer that indicates whether this <see cref="instance"/> is shorter than, equal to, or longer than the <see cref="T:MathNet.Spatial.Units.Energy"/> object.
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
        /// <param name="quantity">A <see cref="T:MathNet.Spatial.Units.Energy"/> object to compare to this instance.</param>
        public int CompareTo(Energy quantity)
        {
            return this.Joules.CompareTo(quantity.Joules);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Energy"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Energy as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Energy"/> object to compare with this instance.</param>
        public bool Equals(Energy other)
        {
            return this.Joules.Equals(other.Joules);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.Energy"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Energy as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An <see cref="T:Gu.Units.Energy"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(Energy other, double tolerance)
        {
            return Math.Abs(this.Joules - other.Joules) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Energy && this.Equals((Energy)obj);
        }

        public override int GetHashCode()
        {
            return this.Joules.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, x => x.Joules, XmlConvert.ToDouble(XmlExt.ReadAttributeOrElementOrDefault(e, "Value")));
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.Joules);
        }
    }
}
