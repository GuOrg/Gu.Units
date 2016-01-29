namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.LuminousFlux"/>.
    /// </summary>
    [TypeConverter(typeof(LuminousFluxTypeConverter))]
    [Serializable]
    public partial struct LuminousFlux : IQuantity<LuminousFluxUnit>, IComparable<LuminousFlux>, IEquatable<LuminousFlux>
    {
        public static readonly LuminousFlux Zero = new LuminousFlux();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.LuminousFluxUnit.Lumens"/>.
        /// </summary>
        internal readonly double lumens;

        private LuminousFlux(double lumens)
        {
            this.lumens = lumens;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.LuminousFlux"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.LuminousFluxUnit"/>.</param>
        public LuminousFlux(double value, LuminousFluxUnit unit)
        {
            this.lumens = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.LuminousFluxUnit.Lumens"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.lumens;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.LuminousFluxUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public LuminousFluxUnit SiUnit => LuminousFluxUnit.Lumens;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => LuminousFluxUnit.Lumens;

        /// <summary>
        /// The quantity in lumens".
        /// </summary>
        public double Lumens
        {
            get
            {
                return this.lumens;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LuminousFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LuminousFlux"/></param>
        /// <returns></returns>
		public static LuminousFlux Parse(string text)
        {
            return QuantityParser.Parse<LuminousFluxUnit, LuminousFlux>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LuminousFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LuminousFlux"/></param>
        /// <returns></returns>
        public static LuminousFlux Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<LuminousFluxUnit, LuminousFlux>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LuminousFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LuminousFlux"/></param>
        /// <returns></returns>
        public static LuminousFlux Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<LuminousFluxUnit, LuminousFlux>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LuminousFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LuminousFlux"/></param>
        /// <returns></returns>
        public static LuminousFlux Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<LuminousFluxUnit, LuminousFlux>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LuminousFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LuminousFlux"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out LuminousFlux result)
        {
            return QuantityParser.TryParse<LuminousFluxUnit, LuminousFlux>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LuminousFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LuminousFlux"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out LuminousFlux result)
        {
            return QuantityParser.TryParse<LuminousFluxUnit, LuminousFlux>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LuminousFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LuminousFlux"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out LuminousFlux result)
        {
            return QuantityParser.TryParse<LuminousFluxUnit, LuminousFlux>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LuminousFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LuminousFlux"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out LuminousFlux result)
        {
            return QuantityParser.TryParse<LuminousFluxUnit, LuminousFlux>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.LuminousFlux"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.LuminousFlux"/></returns>
        public static LuminousFlux ReadFrom(XmlReader reader)
        {
            var v = new LuminousFlux();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.LuminousFlux"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static LuminousFlux From(double value, LuminousFluxUnit unit)
        {
            return new LuminousFlux(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.LuminousFlux"/>.
        /// </summary>
        /// <param name="lumens">The value in <see cref="Gu.Units.LuminousFluxUnit.Lumens"/></param>
        public static LuminousFlux FromLumens(double lumens)
        {
            return new LuminousFlux(lumens);
        }

        public static SolidAngle operator /(LuminousFlux left, LuminousIntensity right)
        {
            return SolidAngle.FromSteradians(left.lumens / right.candelas);
        }

        public static LuminousIntensity operator /(LuminousFlux left, SolidAngle right)
        {
            return LuminousIntensity.FromCandelas(left.lumens / right.steradians);
        }

        public static Illuminance operator /(LuminousFlux left, Area right)
        {
            return Illuminance.FromLux(left.lumens / right.squareMetres);
        }

        public static Area operator /(LuminousFlux left, Illuminance right)
        {
            return Area.FromSquareMetres(left.lumens / right.lux);
        }

        public static double operator /(LuminousFlux left, LuminousFlux right)
        {
            return left.lumens / right.lumens;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LuminousFlux"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        public static bool operator ==(LuminousFlux left, LuminousFlux right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LuminousFlux"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        public static bool operator !=(LuminousFlux left, LuminousFlux right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.LuminousFlux"/> is less than another specified <see cref="Gu.Units.LuminousFlux"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        public static bool operator <(LuminousFlux left, LuminousFlux right)
        {
            return left.lumens < right.lumens;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.LuminousFlux"/> is greater than another specified <see cref="Gu.Units.LuminousFlux"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        public static bool operator >(LuminousFlux left, LuminousFlux right)
        {
            return left.lumens > right.lumens;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.LuminousFlux"/> is less than or equal to another specified <see cref="Gu.Units.LuminousFlux"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        public static bool operator <=(LuminousFlux left, LuminousFlux right)
        {
            return left.lumens <= right.lumens;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.LuminousFlux"/> is greater than or equal to another specified <see cref="Gu.Units.LuminousFlux"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        public static bool operator >=(LuminousFlux left, LuminousFlux right)
        {
            return left.lumens >= right.lumens;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.LuminousFlux"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.LuminousFlux"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.LuminousFlux"/> with <paramref name="left"/> and returns the result.</returns>
        public static LuminousFlux operator *(double left, LuminousFlux right)
        {
            return new LuminousFlux(left * right.lumens);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.LuminousFlux"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousFlux"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.LuminousFlux"/> with <paramref name="right"/> and returns the result.</returns>
        public static LuminousFlux operator *(LuminousFlux left, double right)
        {
            return new LuminousFlux(left.lumens * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.LuminousFlux"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousFlux"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.LuminousFlux"/> with <paramref name="right"/> and returns the result.</returns>
        public static LuminousFlux operator /(LuminousFlux left, double right)
        {
            return new LuminousFlux(left.lumens / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.LuminousFlux"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.LuminousFlux"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LuminousFlux"/>.</param>
        public static LuminousFlux operator +(LuminousFlux left, LuminousFlux right)
        {
            return new LuminousFlux(left.lumens + right.lumens);
        }

        /// <summary>
        /// Subtracts an LuminousFlux from another LuminousFlux and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.LuminousFlux"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.LuminousFlux"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.LuminousFlux"/> (the subtrahend).</param>
        public static LuminousFlux operator -(LuminousFlux left, LuminousFlux right)
        {
            return new LuminousFlux(left.lumens - right.lumens);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.LuminousFlux"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.LuminousFlux"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="luminousFlux">An instance of <see cref="Gu.Units.LuminousFlux"/></param>
        public static LuminousFlux operator -(LuminousFlux luminousFlux)
        {
            return new LuminousFlux(-1 * luminousFlux.lumens);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.LuminousFlux"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="luminousFlux"/>.
        /// </returns>
        /// <param name="luminousFlux">An instance of <see cref="Gu.Units.LuminousFlux"/></param>
        public static LuminousFlux operator +(LuminousFlux luminousFlux)
        {
            return luminousFlux;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(LuminousFluxUnit unit)
        {
            return unit.FromSiUnit(this.lumens);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="LuminousFlux"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="LuminousFlux"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 lm\"</param>
        /// <returns>The string representation of the <see cref="LuminousFlux"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 lm\"</param>
        /// <returns>The string representation of the <see cref="LuminousFlux"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex lm</param>
        /// <returns>The string representation of the <see cref="LuminousFlux"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex lm</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="LuminousFlux"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(LuminousFluxUnit unit)
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(LuminousFluxUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(LuminousFluxUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(LuminousFluxUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, LuminousFluxUnit unit)
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, LuminousFluxUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, LuminousFluxUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, LuminousFluxUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LuminousFluxUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<LuminousFluxUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.LuminousFlux"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.LuminousFlux"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.LuminousFlux"/> object to compare to this instance.</param>
        public int CompareTo(LuminousFlux quantity)
        {
            return this.lumens.CompareTo(quantity.lumens);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.LuminousFlux"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same LuminousFlux as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.LuminousFlux"/> object to compare with this instance.</param>
        public bool Equals(LuminousFlux other)
        {
            return this.lumens.Equals(other.lumens);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.LuminousFlux"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same LuminousFlux as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.LuminousFlux"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(LuminousFlux other, LuminousFlux tolerance)
        {
            Ensure.GreaterThan(tolerance.lumens, 0, nameof(tolerance));
            return Math.Abs(this.lumens - other.lumens) < tolerance.lumens;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is LuminousFlux && this.Equals((LuminousFlux)obj);
        }

        public override int GetHashCode()
        {
            return this.lumens.GetHashCode();
        }

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, 
        /// you should return null (Nothing in Visual Basic) from this method, and instead, 
        /// if specifying a custom schema is required, apply the <see cref="System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the
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
        /// <param name="reader">The <see cref="System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            // Hacking set readonly fields here, can't think of a cleaner workaround
            XmlExt.SetReadonlyField(ref this, "lumens", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.lumens);
        }
    }
}