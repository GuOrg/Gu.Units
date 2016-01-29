namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Momentum"/>.
    /// </summary>
    [TypeConverter(typeof(MomentumTypeConverter))]
    [Serializable]
    public partial struct Momentum : IQuantity<MomentumUnit>, IComparable<Momentum>, IEquatable<Momentum>
    {
        public static readonly Momentum Zero = new Momentum();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.MomentumUnit.NewtonSecond"/>.
        /// </summary>
        internal readonly double newtonSecond;

        private Momentum(double newtonSecond)
        {
            this.newtonSecond = newtonSecond;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.MomentumUnit"/>.</param>
        public Momentum(double value, MomentumUnit unit)
        {
            this.newtonSecond = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.MomentumUnit.NewtonSecond"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.newtonSecond;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.MomentumUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public MomentumUnit SiUnit => MomentumUnit.NewtonSecond;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => MomentumUnit.NewtonSecond;

        /// <summary>
        /// The quantity in newtonSecond".
        /// </summary>
        public double NewtonSecond
        {
            get
            {
                return this.newtonSecond;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <returns></returns>
		public static Momentum Parse(string text)
        {
            return QuantityParser.Parse<MomentumUnit, Momentum>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <returns></returns>
        public static Momentum Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<MomentumUnit, Momentum>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <returns></returns>
        public static Momentum Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<MomentumUnit, Momentum>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <returns></returns>
        public static Momentum Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<MomentumUnit, Momentum>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out Momentum result)
        {
            return QuantityParser.TryParse<MomentumUnit, Momentum>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out Momentum result)
        {
            return QuantityParser.TryParse<MomentumUnit, Momentum>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out Momentum result)
        {
            return QuantityParser.TryParse<MomentumUnit, Momentum>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Momentum result)
        {
            return QuantityParser.TryParse<MomentumUnit, Momentum>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Momentum"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Momentum"/></returns>
        public static Momentum ReadFrom(XmlReader reader)
        {
            var v = new Momentum();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Momentum From(double value, MomentumUnit unit)
        {
            return new Momentum(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <param name="newtonSecond">The value in <see cref="Gu.Units.MomentumUnit.NewtonSecond"/></param>
        public static Momentum FromNewtonSecond(double newtonSecond)
        {
            return new Momentum(newtonSecond);
        }

        public static Speed operator /(Momentum left, Mass right)
        {
            return Speed.FromMetresPerSecond(left.newtonSecond / right.kilograms);
        }

        public static MassFlow operator /(Momentum left, Length right)
        {
            return MassFlow.FromKilogramsPerSecond(left.newtonSecond / right.metres);
        }

        public static Force operator /(Momentum left, Time right)
        {
            return Force.FromNewtons(left.newtonSecond / right.seconds);
        }

        public static Time operator /(Momentum left, Force right)
        {
            return Time.FromSeconds(left.newtonSecond / right.newtons);
        }

        public static Energy operator *(Momentum left, Speed right)
        {
            return Energy.FromJoules(left.newtonSecond * right.metresPerSecond);
        }

        public static Mass operator /(Momentum left, Speed right)
        {
            return Mass.FromKilograms(left.newtonSecond / right.metresPerSecond);
        }

        public static Force operator *(Momentum left, Frequency right)
        {
            return Force.FromNewtons(left.newtonSecond * right.hertz);
        }

        public static Power operator *(Momentum left, Acceleration right)
        {
            return Power.FromWatts(left.newtonSecond * right.metresPerSecondSquared);
        }

        public static AreaDensity operator /(Momentum left, VolumetricFlow right)
        {
            return AreaDensity.FromKilogramsPerSquareMetre(left.newtonSecond / right.cubicMetresPerSecond);
        }

        public static MassFlow operator *(Momentum left, Wavenumber right)
        {
            return MassFlow.FromKilogramsPerSecond(left.newtonSecond * right.reciprocalMetres);
        }

        public static VolumetricFlow operator /(Momentum left, AreaDensity right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.newtonSecond / right.kilogramsPerSquareMetre);
        }

        public static Length operator /(Momentum left, MassFlow right)
        {
            return Length.FromMetres(left.newtonSecond / right.kilogramsPerSecond);
        }

        public static double operator /(Momentum left, Momentum right)
        {
            return left.newtonSecond / right.newtonSecond;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Momentum"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static bool operator ==(Momentum left, Momentum right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Momentum"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static bool operator !=(Momentum left, Momentum right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Momentum"/> is less than another specified <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static bool operator <(Momentum left, Momentum right)
        {
            return left.newtonSecond < right.newtonSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Momentum"/> is greater than another specified <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static bool operator >(Momentum left, Momentum right)
        {
            return left.newtonSecond > right.newtonSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Momentum"/> is less than or equal to another specified <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static bool operator <=(Momentum left, Momentum right)
        {
            return left.newtonSecond <= right.newtonSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Momentum"/> is greater than or equal to another specified <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static bool operator >=(Momentum left, Momentum right)
        {
            return left.newtonSecond >= right.newtonSecond;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Momentum"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Momentum"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Momentum"/> with <paramref name="left"/> and returns the result.</returns>
        public static Momentum operator *(double left, Momentum right)
        {
            return new Momentum(left * right.newtonSecond);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Momentum"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Momentum"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Momentum"/> with <paramref name="right"/> and returns the result.</returns>
        public static Momentum operator *(Momentum left, double right)
        {
            return new Momentum(left.newtonSecond * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Momentum"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Momentum"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Momentum"/> with <paramref name="right"/> and returns the result.</returns>
        public static Momentum operator /(Momentum left, double right)
        {
            return new Momentum(left.newtonSecond / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Momentum"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Momentum"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static Momentum operator +(Momentum left, Momentum right)
        {
            return new Momentum(left.newtonSecond + right.newtonSecond);
        }

        /// <summary>
        /// Subtracts an Momentum from another Momentum and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Momentum"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Momentum"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Momentum"/> (the subtrahend).</param>
        public static Momentum operator -(Momentum left, Momentum right)
        {
            return new Momentum(left.newtonSecond - right.newtonSecond);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Momentum"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Momentum"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="momentum">An instance of <see cref="Gu.Units.Momentum"/></param>
        public static Momentum operator -(Momentum momentum)
        {
            return new Momentum(-1 * momentum.newtonSecond);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="momentum"/>.
        /// </returns>
        /// <param name="momentum">An instance of <see cref="Gu.Units.Momentum"/></param>
        public static Momentum operator +(Momentum momentum)
        {
            return momentum;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(MomentumUnit unit)
        {
            return unit.FromSiUnit(this.newtonSecond);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Momentum"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Momentum"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N⋅s\"</param>
        /// <returns>The string representation of the <see cref="Momentum"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N⋅s\"</param>
        /// <returns>The string representation of the <see cref="Momentum"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex N⋅s</param>
        /// <returns>The string representation of the <see cref="Momentum"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex N⋅s</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Momentum"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(MomentumUnit unit)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(MomentumUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(MomentumUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(MomentumUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, MomentumUnit unit)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, MomentumUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, MomentumUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, MomentumUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<MomentumUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Momentum"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Momentum"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Momentum"/> object to compare to this instance.</param>
        public int CompareTo(Momentum quantity)
        {
            return this.newtonSecond.CompareTo(quantity.newtonSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Momentum"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Momentum as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Momentum"/> object to compare with this instance.</param>
        public bool Equals(Momentum other)
        {
            return this.newtonSecond.Equals(other.newtonSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Momentum"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Momentum as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Momentum"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Momentum other, Momentum tolerance)
        {
            Ensure.GreaterThan(tolerance.newtonSecond, 0, nameof(tolerance));
            return Math.Abs(this.newtonSecond - other.newtonSecond) < tolerance.newtonSecond;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Momentum && this.Equals((Momentum)obj);
        }

        public override int GetHashCode()
        {
            return this.newtonSecond.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "newtonSecond", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.newtonSecond);
        }
    }
}