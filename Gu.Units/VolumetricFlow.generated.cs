namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="T:Gu.Units.VolumetricFlow"/>.
    /// </summary>
    [Serializable]
    public partial struct VolumetricFlow : IComparable<VolumetricFlow>, IEquatable<VolumetricFlow>, IFormattable, IXmlSerializable, IQuantity<LengthUnit, I3, TimeUnit, INeg1>, IQuantity<VolumetricFlowUnit>
    {
        /// <summary>
        /// The quantity in <see cref="T:Gu.Units.CubicMetresPerSecond"/>.
        /// </summary>
        internal readonly double cubicMetresPerSecond;

        private VolumetricFlow(double cubicMetresPerSecond)
        {
            this.cubicMetresPerSecond = cubicMetresPerSecond;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="T:Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="T:Gu.Units.CubicMetresPerSecond"/>.</param>
        public VolumetricFlow(double value, VolumetricFlowUnit unit)
        {
            this.cubicMetresPerSecond = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in CubicMetresPerSecond
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.cubicMetresPerSecond;
            }
        }

        /// <summary>
        /// The quantity in cubicMetresPerSecond".
        /// </summary>
        public double CubicMetresPerSecond
        {
            get
            {
                return this.cubicMetresPerSecond;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="T:Gu.Units.VolumetricFlow"/> from its string representation
        /// </summary>
        /// <param name="s">The string representation of the <see cref="T:Gu.Units.VolumetricFlow"/></param>
        /// <returns></returns>
        public static VolumetricFlow Parse(string s)
        {
            return Parser.Parse<VolumetricFlowUnit, VolumetricFlow>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        public static VolumetricFlow Parse(string s, NumberStyles styles)
        {
            return Parser.Parse<VolumetricFlowUnit, VolumetricFlow>(s, From, styles, CultureInfo.CurrentCulture);
        }

        public static VolumetricFlow Parse(string s, NumberStyles styles, IFormatProvider provider)
        {
            return Parser.Parse<VolumetricFlowUnit, VolumetricFlow>(s, From, styles, provider);
        }

        public static bool TryParse(string s, out VolumetricFlow value)
        {
            return Parser.TryParse<VolumetricFlowUnit, VolumetricFlow>(s, From, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        public static bool TryParse(string s, NumberStyles styles, out VolumetricFlow value)
        {
            return Parser.TryParse<VolumetricFlowUnit, VolumetricFlow>(s, From, styles, CultureInfo.CurrentCulture, out  value);
        }

        public static bool TryParse(string s, NumberStyles styles, IFormatProvider provider, out VolumetricFlow value)
        {
            return Parser.TryParse<VolumetricFlowUnit, VolumetricFlow>(s, From, styles, provider, out value);
        }

        /// <summary>
        /// Reads an instance of <see cref="T:Gu.Units.VolumetricFlow"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="T:Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow ReadFrom(XmlReader reader)
        {
            var v = new VolumetricFlow();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static VolumetricFlow From(double value, VolumetricFlowUnit unit)
        {
            return new VolumetricFlow(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="T:Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="cubicMetresPerSecond">The value in <see cref="T:Gu.Units.CubicMetresPerSecond"/></param>
        public static VolumetricFlow FromCubicMetresPerSecond(double cubicMetresPerSecond)
        {
            return new VolumetricFlow(cubicMetresPerSecond);
        }


        public static Area operator /(VolumetricFlow left, Speed right)
        {
            return Area.FromSquareMetres(left.cubicMetresPerSecond / right.metresPerSecond);
        }

        public static Volume operator *(VolumetricFlow left, Time right)
        {
            return Volume.FromCubicMetres(left.cubicMetresPerSecond * right.seconds);
        }

        public static Speed operator /(VolumetricFlow left, Area right)
        {
            return Speed.FromMetresPerSecond(left.cubicMetresPerSecond / right.squareMetres);
        }

        public static Frequency operator /(VolumetricFlow left, Volume right)
        {
            return Frequency.FromHertz(left.cubicMetresPerSecond / right.cubicMetres);
        }

        public static double operator /(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond / right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.VolumetricFlow"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator ==(VolumetricFlow left, VolumetricFlow right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:Gu.Units.VolumetricFlow"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator !=(VolumetricFlow left, VolumetricFlow right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.VolumetricFlow"/> is less than another specified <see cref="T:Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator <(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond < right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.VolumetricFlow"/> is greater than another specified <see cref="T:Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator >(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond > right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.VolumetricFlow"/> is less than or equal to another specified <see cref="T:Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator <=(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond <= right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:Gu.Units.VolumetricFlow"/> is greater than or equal to another specified <see cref="T:Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator >=(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond >= right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.VolumetricFlow"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="T:Gu.Units.VolumetricFlow"/></param>
        /// <param name="left">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.VolumetricFlow"/> with <paramref name="left"/> and returns the result.</returns>
        public static VolumetricFlow operator *(double left, VolumetricFlow right)
        {
            return new VolumetricFlow(left * right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="T:Gu.Units.VolumetricFlow"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.VolumetricFlow"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="T:Gu.Units.VolumetricFlow"/> with <paramref name="right"/> and returns the result.</returns>
        public static VolumetricFlow operator *(VolumetricFlow left, double right)
        {
            return new VolumetricFlow(left.cubicMetresPerSecond * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="T:Gu.Units.VolumetricFlow"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="T:Gu.Units.VolumetricFlow"/></param>
        /// <param name="right">An instance of <seealso cref="T:System.Double"/></param>
        /// <returns>Divides an instance of <see cref="T:Gu.Units.VolumetricFlow"/> with <paramref name="right"/> and returns the result.</returns>
        public static VolumetricFlow operator /(VolumetricFlow left, double right)
        {
            return new VolumetricFlow(left.cubicMetresPerSecond / right);
        }

        /// <summary>
        /// Adds two specified <see cref="T:Gu.Units.VolumetricFlow"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.VolumetricFlow"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.VolumetricFlow"/>.</param>
        public static VolumetricFlow operator +(VolumetricFlow left, VolumetricFlow right)
        {
            return new VolumetricFlow(left.cubicMetresPerSecond + right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Subtracts an VolumetricFlow from another VolumetricFlow and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.VolumetricFlow"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="T:Gu.Units.VolumetricFlow"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="T:Gu.Units.VolumetricFlow"/> (the subtrahend).</param>
        public static VolumetricFlow operator -(VolumetricFlow left, VolumetricFlow right)
        {
            return new VolumetricFlow(left.cubicMetresPerSecond - right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns an <see cref="T:Gu.Units.VolumetricFlow"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Gu.Units.VolumetricFlow"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="volumetricFlow">An instance of <see cref="T:Gu.Units.VolumetricFlow"/></param>
        public static VolumetricFlow operator -(VolumetricFlow volumetricFlow)
        {
            return new VolumetricFlow(-1 * volumetricFlow.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="volumetricFlow"/>.
        /// </returns>
        /// <param name="volumetricFlow">An instance of <see cref="T:Gu.Units.VolumetricFlow"/></param>
        public static VolumetricFlow operator +(VolumetricFlow volumetricFlow)
        {
            return volumetricFlow;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(VolumetricFlowUnit unit)
        {
            return unit.FromSiUnit(this.cubicMetresPerSecond);
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
            return this.ToString(format, formatProvider, VolumetricFlowUnit.CubicMetresPerSecond);
        }

        public string ToString(VolumetricFlowUnit unit)
        {
            return this.ToString((string)null, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, VolumetricFlowUnit unit)
        {
            return this.ToString(format, (IFormatProvider)NumberFormatInfo.CurrentInfo, unit);
        }

        public string ToString(string format, IFormatProvider formatProvider, VolumetricFlowUnit unit)
        {
            var quantity = unit.FromSiUnit(this.cubicMetresPerSecond);
            return string.Format("{0}{1}", quantity.ToString(format, formatProvider), unit.Symbol);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:MathNet.Spatial.Units.VolumetricFlow"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="T:MathNet.Spatial.Units.VolumetricFlow"/> object.
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
        /// <param name="quantity">An instance of <see cref="T:MathNet.Spatial.Units.VolumetricFlow"/> object to compare to this instance.</param>
        public int CompareTo(VolumetricFlow quantity)
        {
            return this.cubicMetresPerSecond.CompareTo(quantity.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.VolumetricFlow"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same VolumetricFlow as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.VolumetricFlow"/> object to compare with this instance.</param>
        public bool Equals(VolumetricFlow other)
        {
            return this.cubicMetresPerSecond.Equals(other.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="T:Gu.Units.VolumetricFlow"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same VolumetricFlow as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="T:Gu.Units.VolumetricFlow"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal</param>
        public bool Equals(VolumetricFlow other, double tolerance)
        {
            return Math.Abs(this.cubicMetresPerSecond - other.cubicMetresPerSecond) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is VolumetricFlow && this.Equals((VolumetricFlow)obj);
        }

        public override int GetHashCode()
        {
            return this.cubicMetresPerSecond.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "cubicMetresPerSecond", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.cubicMetresPerSecond);
        }
    }
}