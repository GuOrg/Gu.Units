namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.AreaDensity"/>.
    /// </summary>
    // [TypeConverter(typeof(AreaDensityTypeConverter))]
    [Serializable]
    public partial struct AreaDensity : IQuantity<AreaDensityUnit>, IComparable<AreaDensity>, IEquatable<AreaDensity>
    {
        public static readonly AreaDensity Zero = new AreaDensity();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AreaDensityUnit.KilogramsPerSquareMetre"/>.
        /// </summary>
        internal readonly double kilogramsPerSquareMetre;

        private AreaDensity(double kilogramsPerSquareMetre)
        {
            this.kilogramsPerSquareMetre = kilogramsPerSquareMetre;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.AreaDensity"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.AreaDensityUnit"/>.</param>
        public AreaDensity(double value, AreaDensityUnit unit)
        {
            this.kilogramsPerSquareMetre = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.AreaDensityUnit.KilogramsPerSquareMetre"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.kilogramsPerSquareMetre;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.AreaDensityUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public AreaDensityUnit SiUnit => AreaDensityUnit.KilogramsPerSquareMetre;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => AreaDensityUnit.KilogramsPerSquareMetre;

        /// <summary>
        /// The quantity in kilogramsPerSquareMetre".
        /// </summary>
        public double KilogramsPerSquareMetre
        {
            get
            {
                return this.kilogramsPerSquareMetre;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AreaDensity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AreaDensity"/></param>
        /// <returns></returns>
		public static AreaDensity Parse(string text)
        {
            return QuantityParser.Parse<AreaDensityUnit, AreaDensity>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AreaDensity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AreaDensity"/></param>
        /// <returns></returns>
        public static AreaDensity Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<AreaDensityUnit, AreaDensity>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AreaDensity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AreaDensity"/></param>
        /// <returns></returns>
        public static AreaDensity Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<AreaDensityUnit, AreaDensity>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AreaDensity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AreaDensity"/></param>
        /// <returns></returns>
        public static AreaDensity Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<AreaDensityUnit, AreaDensity>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AreaDensity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AreaDensity"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out AreaDensity result)
        {
            return QuantityParser.TryParse<AreaDensityUnit, AreaDensity>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AreaDensity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AreaDensity"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out AreaDensity result)
        {
            return QuantityParser.TryParse<AreaDensityUnit, AreaDensity>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AreaDensity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AreaDensity"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out AreaDensity result)
        {
            return QuantityParser.TryParse<AreaDensityUnit, AreaDensity>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AreaDensity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AreaDensity"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out AreaDensity result)
        {
            return QuantityParser.TryParse<AreaDensityUnit, AreaDensity>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.AreaDensity"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.AreaDensity"/></returns>
        public static AreaDensity ReadFrom(XmlReader reader)
        {
            var v = new AreaDensity();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AreaDensity"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static AreaDensity From(double value, AreaDensityUnit unit)
        {
            return new AreaDensity(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.AreaDensity"/>.
        /// </summary>
        /// <param name="kilogramsPerSquareMetre">The value in <see cref="Gu.Units.AreaDensityUnit.KilogramsPerSquareMetre"/></param>
        public static AreaDensity FromKilogramsPerSquareMetre(double kilogramsPerSquareMetre)
        {
            return new AreaDensity(kilogramsPerSquareMetre);
        }

        public static Density operator /(AreaDensity left, Length right)
        {
            return Density.FromKilogramsPerCubicMetre(left.kilogramsPerSquareMetre / right.metres);
        }

        public static Mass operator *(AreaDensity left, Area right)
        {
            return Mass.FromKilograms(left.kilogramsPerSquareMetre * right.squareMetres);
        }

        public static Length operator /(AreaDensity left, Density right)
        {
            return Length.FromMetres(left.kilogramsPerSquareMetre / right.kilogramsPerCubicMetre);
        }

        public static Pressure operator *(AreaDensity left, Acceleration right)
        {
            return Pressure.FromPascals(left.kilogramsPerSquareMetre * right.metresPerSecondSquared);
        }

        public static Momentum operator *(AreaDensity left, VolumetricFlow right)
        {
            return Momentum.FromNewtonSecond(left.kilogramsPerSquareMetre * right.cubicMetresPerSecond);
        }

        public static Stiffness operator *(AreaDensity left, SpecificEnergy right)
        {
            return Stiffness.FromNewtonsPerMetre(left.kilogramsPerSquareMetre * right.joulesPerKilogram);
        }

        public static Density operator *(AreaDensity left, Wavenumber right)
        {
            return Density.FromKilogramsPerCubicMetre(left.kilogramsPerSquareMetre * right.reciprocalMetres);
        }

        public static Length operator *(AreaDensity left, SpecificVolume right)
        {
            return Length.FromMetres(left.kilogramsPerSquareMetre * right.cubicMetresPerKilogram);
        }

        public static MassFlow operator *(AreaDensity left, KinematicViscosity right)
        {
            return MassFlow.FromKilogramsPerSecond(left.kilogramsPerSquareMetre * right.squareMetresPerSecond);
        }

        public static double operator /(AreaDensity left, AreaDensity right)
        {
            return left.kilogramsPerSquareMetre / right.kilogramsPerSquareMetre;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AreaDensity"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        public static bool operator ==(AreaDensity left, AreaDensity right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AreaDensity"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        public static bool operator !=(AreaDensity left, AreaDensity right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AreaDensity"/> is less than another specified <see cref="Gu.Units.AreaDensity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        public static bool operator <(AreaDensity left, AreaDensity right)
        {
            return left.kilogramsPerSquareMetre < right.kilogramsPerSquareMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AreaDensity"/> is greater than another specified <see cref="Gu.Units.AreaDensity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        public static bool operator >(AreaDensity left, AreaDensity right)
        {
            return left.kilogramsPerSquareMetre > right.kilogramsPerSquareMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AreaDensity"/> is less than or equal to another specified <see cref="Gu.Units.AreaDensity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        public static bool operator <=(AreaDensity left, AreaDensity right)
        {
            return left.kilogramsPerSquareMetre <= right.kilogramsPerSquareMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.AreaDensity"/> is greater than or equal to another specified <see cref="Gu.Units.AreaDensity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        public static bool operator >=(AreaDensity left, AreaDensity right)
        {
            return left.kilogramsPerSquareMetre >= right.kilogramsPerSquareMetre;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AreaDensity"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.AreaDensity"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.AreaDensity"/> with <paramref name="left"/> and returns the result.</returns>
        public static AreaDensity operator *(double left, AreaDensity right)
        {
            return new AreaDensity(left * right.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.AreaDensity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.AreaDensity"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.AreaDensity"/> with <paramref name="right"/> and returns the result.</returns>
        public static AreaDensity operator *(AreaDensity left, double right)
        {
            return new AreaDensity(left.kilogramsPerSquareMetre * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.AreaDensity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.AreaDensity"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.AreaDensity"/> with <paramref name="right"/> and returns the result.</returns>
        public static AreaDensity operator /(AreaDensity left, double right)
        {
            return new AreaDensity(left.kilogramsPerSquareMetre / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.AreaDensity"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AreaDensity"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AreaDensity"/>.</param>
        public static AreaDensity operator +(AreaDensity left, AreaDensity right)
        {
            return new AreaDensity(left.kilogramsPerSquareMetre + right.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Subtracts an AreaDensity from another AreaDensity and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AreaDensity"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AreaDensity"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AreaDensity"/> (the subtrahend).</param>
        public static AreaDensity operator -(AreaDensity left, AreaDensity right)
        {
            return new AreaDensity(left.kilogramsPerSquareMetre - right.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.AreaDensity"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.AreaDensity"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="areaDensity">An instance of <see cref="Gu.Units.AreaDensity"/></param>
        public static AreaDensity operator -(AreaDensity areaDensity)
        {
            return new AreaDensity(-1 * areaDensity.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.AreaDensity"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="areaDensity"/>.
        /// </returns>
        /// <param name="areaDensity">An instance of <see cref="Gu.Units.AreaDensity"/></param>
        public static AreaDensity operator +(AreaDensity areaDensity)
        {
            return areaDensity;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(AreaDensityUnit unit)
        {
            return unit.FromSiUnit(this.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="AreaDensity"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="AreaDensity"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kg/m²\"</param>
        /// <returns>The string representation of the <see cref="AreaDensity"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kg/m²\"</param>
        /// <returns>The string representation of the <see cref="AreaDensity"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex kg/m²</param>
        /// <returns>The string representation of the <see cref="AreaDensity"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex kg/m²</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="AreaDensity"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AreaDensityUnit unit)
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(AreaDensityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(AreaDensityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(AreaDensityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AreaDensityUnit unit)
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AreaDensityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, AreaDensityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, AreaDensityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaDensityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<AreaDensityUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.AreaDensity"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.AreaDensity"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.AreaDensity"/> object to compare to this instance.</param>
        public int CompareTo(AreaDensity quantity)
        {
            return this.kilogramsPerSquareMetre.CompareTo(quantity.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AreaDensity"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AreaDensity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.AreaDensity"/> object to compare with this instance.</param>
        public bool Equals(AreaDensity other)
        {
            return this.kilogramsPerSquareMetre.Equals(other.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AreaDensity"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AreaDensity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.AreaDensity"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(AreaDensity other, AreaDensity tolerance)
        {
            Ensure.GreaterThan(tolerance.kilogramsPerSquareMetre, 0, nameof(tolerance));
            return Math.Abs(this.kilogramsPerSquareMetre - other.kilogramsPerSquareMetre) < tolerance.kilogramsPerSquareMetre;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AreaDensity && this.Equals((AreaDensity)obj);
        }

        public override int GetHashCode()
        {
            return this.kilogramsPerSquareMetre.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "kilogramsPerSquareMetre", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.kilogramsPerSquareMetre);
        }
    }
}