namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Wavenumber"/>.
    /// </summary>
    [TypeConverter(typeof(WavenumberTypeConverter))]
    [Serializable]
    public partial struct Wavenumber : IQuantity<WavenumberUnit>, IComparable<Wavenumber>, IEquatable<Wavenumber>
    {
        public static readonly Wavenumber Zero = new Wavenumber();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.WavenumberUnit.ReciprocalMetres"/>.
        /// </summary>
        internal readonly double reciprocalMetres;

        private Wavenumber(double reciprocalMetres)
        {
            this.reciprocalMetres = reciprocalMetres;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.WavenumberUnit"/>.</param>
        public Wavenumber(double value, WavenumberUnit unit)
        {
            this.reciprocalMetres = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.WavenumberUnit.ReciprocalMetres"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.reciprocalMetres;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.WavenumberUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public WavenumberUnit SiUnit => WavenumberUnit.ReciprocalMetres;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => WavenumberUnit.ReciprocalMetres;

        /// <summary>
        /// The quantity in reciprocalMetres".
        /// </summary>
        public double ReciprocalMetres
        {
            get
            {
                return this.reciprocalMetres;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <returns></returns>
		public static Wavenumber Parse(string text)
        {
            return QuantityParser.Parse<WavenumberUnit, Wavenumber>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <returns></returns>
        public static Wavenumber Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<WavenumberUnit, Wavenumber>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <returns></returns>
        public static Wavenumber Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<WavenumberUnit, Wavenumber>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <returns></returns>
        public static Wavenumber Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<WavenumberUnit, Wavenumber>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out Wavenumber result)
        {
            return QuantityParser.TryParse<WavenumberUnit, Wavenumber>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out Wavenumber result)
        {
            return QuantityParser.TryParse<WavenumberUnit, Wavenumber>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out Wavenumber result)
        {
            return QuantityParser.TryParse<WavenumberUnit, Wavenumber>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Wavenumber result)
        {
            return QuantityParser.TryParse<WavenumberUnit, Wavenumber>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Wavenumber"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Wavenumber"/></returns>
        public static Wavenumber ReadFrom(XmlReader reader)
        {
            var v = new Wavenumber();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Wavenumber From(double value, WavenumberUnit unit)
        {
            return new Wavenumber(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <param name="reciprocalMetres">The value in <see cref="Gu.Units.WavenumberUnit.ReciprocalMetres"/></param>
        public static Wavenumber FromReciprocalMetres(double reciprocalMetres)
        {
            return new Wavenumber(reciprocalMetres);
        }

        public static Length operator *(Wavenumber left, Area right)
        {
            return Length.FromMetres(left.reciprocalMetres * right.squareMetres);
        }

        public static Area operator *(Wavenumber left, Volume right)
        {
            return Area.FromSquareMetres(left.reciprocalMetres * right.cubicMetres);
        }

        public static Stiffness operator *(Wavenumber left, Force right)
        {
            return Stiffness.FromNewtonsPerMetre(left.reciprocalMetres * right.newtons);
        }

        public static Flexibility operator /(Wavenumber left, Pressure right)
        {
            return Flexibility.FromMetresPerNewton(left.reciprocalMetres / right.pascals);
        }

        public static Force operator *(Wavenumber left, Energy right)
        {
            return Force.FromNewtons(left.reciprocalMetres * right.joules);
        }

        public static Frequency operator *(Wavenumber left, Speed right)
        {
            return Frequency.FromHertz(left.reciprocalMetres * right.metresPerSecond);
        }

        public static Pressure operator *(Wavenumber left, Stiffness right)
        {
            return Pressure.FromPascals(left.reciprocalMetres * right.newtonsPerMetre);
        }

        public static KinematicViscosity operator *(Wavenumber left, VolumetricFlow right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.reciprocalMetres * right.cubicMetresPerSecond);
        }

        public static Acceleration operator *(Wavenumber left, SpecificEnergy right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.reciprocalMetres * right.joulesPerKilogram);
        }

        public static Pressure operator /(Wavenumber left, Flexibility right)
        {
            return Pressure.FromPascals(left.reciprocalMetres / right.metresPerNewton);
        }

        public static MassFlow operator *(Wavenumber left, Momentum right)
        {
            return MassFlow.FromKilogramsPerSecond(left.reciprocalMetres * right.newtonSecond);
        }

        public static Density operator *(Wavenumber left, AreaDensity right)
        {
            return Density.FromKilogramsPerCubicMetre(left.reciprocalMetres * right.kilogramsPerSquareMetre);
        }

        public static Speed operator *(Wavenumber left, KinematicViscosity right)
        {
            return Speed.FromMetresPerSecond(left.reciprocalMetres * right.squareMetresPerSecond);
        }

        public static Length operator /(double left, Wavenumber right)
        {
            return Length.FromMetres(left / right.reciprocalMetres);
        }

        public static double operator /(Wavenumber left, Wavenumber right)
        {
            return left.reciprocalMetres / right.reciprocalMetres;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Wavenumber"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static bool operator ==(Wavenumber left, Wavenumber right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Wavenumber"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static bool operator !=(Wavenumber left, Wavenumber right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Wavenumber"/> is less than another specified <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static bool operator <(Wavenumber left, Wavenumber right)
        {
            return left.reciprocalMetres < right.reciprocalMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Wavenumber"/> is greater than another specified <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static bool operator >(Wavenumber left, Wavenumber right)
        {
            return left.reciprocalMetres > right.reciprocalMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Wavenumber"/> is less than or equal to another specified <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static bool operator <=(Wavenumber left, Wavenumber right)
        {
            return left.reciprocalMetres <= right.reciprocalMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Wavenumber"/> is greater than or equal to another specified <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static bool operator >=(Wavenumber left, Wavenumber right)
        {
            return left.reciprocalMetres >= right.reciprocalMetres;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Wavenumber"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Wavenumber"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Wavenumber"/> with <paramref name="left"/> and returns the result.</returns>
        public static Wavenumber operator *(double left, Wavenumber right)
        {
            return new Wavenumber(left * right.reciprocalMetres);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Wavenumber"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Wavenumber"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Wavenumber"/> with <paramref name="right"/> and returns the result.</returns>
        public static Wavenumber operator *(Wavenumber left, double right)
        {
            return new Wavenumber(left.reciprocalMetres * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Wavenumber"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Wavenumber"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Wavenumber"/> with <paramref name="right"/> and returns the result.</returns>
        public static Wavenumber operator /(Wavenumber left, double right)
        {
            return new Wavenumber(left.reciprocalMetres / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Wavenumber"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Wavenumber"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static Wavenumber operator +(Wavenumber left, Wavenumber right)
        {
            return new Wavenumber(left.reciprocalMetres + right.reciprocalMetres);
        }

        /// <summary>
        /// Subtracts an Wavenumber from another Wavenumber and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Wavenumber"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Wavenumber"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Wavenumber"/> (the subtrahend).</param>
        public static Wavenumber operator -(Wavenumber left, Wavenumber right)
        {
            return new Wavenumber(left.reciprocalMetres - right.reciprocalMetres);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Wavenumber"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Wavenumber"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="wavenumber">An instance of <see cref="Gu.Units.Wavenumber"/></param>
        public static Wavenumber operator -(Wavenumber wavenumber)
        {
            return new Wavenumber(-1 * wavenumber.reciprocalMetres);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="wavenumber"/>.
        /// </returns>
        /// <param name="wavenumber">An instance of <see cref="Gu.Units.Wavenumber"/></param>
        public static Wavenumber operator +(Wavenumber wavenumber)
        {
            return wavenumber;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(WavenumberUnit unit)
        {
            return unit.FromSiUnit(this.reciprocalMetres);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Wavenumber"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Wavenumber"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m⁻¹\"</param>
        /// <returns>The string representation of the <see cref="Wavenumber"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m⁻¹\"</param>
        /// <returns>The string representation of the <see cref="Wavenumber"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m⁻¹</param>
        /// <returns>The string representation of the <see cref="Wavenumber"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m⁻¹</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Wavenumber"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(WavenumberUnit unit)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(WavenumberUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(WavenumberUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(WavenumberUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, WavenumberUnit unit)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, WavenumberUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, WavenumberUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, WavenumberUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<WavenumberUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Wavenumber"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Wavenumber"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Wavenumber"/> object to compare to this instance.</param>
        public int CompareTo(Wavenumber quantity)
        {
            return this.reciprocalMetres.CompareTo(quantity.reciprocalMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Wavenumber"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Wavenumber as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Wavenumber"/> object to compare with this instance.</param>
        public bool Equals(Wavenumber other)
        {
            return this.reciprocalMetres.Equals(other.reciprocalMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Wavenumber"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Wavenumber as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Wavenumber"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Wavenumber other, Wavenumber tolerance)
        {
            Ensure.GreaterThan(tolerance.reciprocalMetres, 0, nameof(tolerance));
            return Math.Abs(this.reciprocalMetres - other.reciprocalMetres) < tolerance.reciprocalMetres;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Wavenumber && this.Equals((Wavenumber)obj);
        }

        public override int GetHashCode()
        {
            return this.reciprocalMetres.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "reciprocalMetres", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.reciprocalMetres);
        }
    }
}