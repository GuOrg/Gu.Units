namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Density"/>.
    /// </summary>
    [TypeConverter(typeof(DensityTypeConverter))]
    [Serializable]
    public partial struct Density : IQuantity<DensityUnit>, IComparable<Density>, IEquatable<Density>
    {
        public static readonly Density Zero = new Density();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.DensityUnit.KilogramsPerCubicMetre"/>.
        /// </summary>
        internal readonly double kilogramsPerCubicMetre;

        private Density(double kilogramsPerCubicMetre)
        {
            this.kilogramsPerCubicMetre = kilogramsPerCubicMetre;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Density"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.DensityUnit"/>.</param>
        public Density(double value, DensityUnit unit)
        {
            this.kilogramsPerCubicMetre = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.DensityUnit.KilogramsPerCubicMetre"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.kilogramsPerCubicMetre;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.DensityUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public DensityUnit SiUnit => DensityUnit.KilogramsPerCubicMetre;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => DensityUnit.KilogramsPerCubicMetre;

        /// <summary>
        /// The quantity in kilogramsPerCubicMetre".
        /// </summary>
        public double KilogramsPerCubicMetre
        {
            get
            {
                return this.kilogramsPerCubicMetre;
            }
        }

        /// <summary>
        /// The quantity in GramsPerCubicMillimetre
        /// </summary>
        public double GramsPerCubicMillimetre => this.kilogramsPerCubicMetre / 1000000;

        /// <summary>
        /// The quantity in GramsPerCubicCentimetre
        /// </summary>
        public double GramsPerCubicCentimetre => this.kilogramsPerCubicMetre / 1000;

        /// <summary>
        /// The quantity in MilligramsPerCubicMillimetre
        /// </summary>
        public double MilligramsPerCubicMillimetre => this.kilogramsPerCubicMetre / 1000;

        /// <summary>
        /// The quantity in GramsPerCubicMetre
        /// </summary>
        public double GramsPerCubicMetre => 1000 * this.kilogramsPerCubicMetre;

        /// <summary>
        /// The quantity in MilligramsPerCubicMetre
        /// </summary>
        public double MilligramsPerCubicMetre => 1000000 * this.kilogramsPerCubicMetre;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Density"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Density"/></param>
        /// <returns></returns>
		public static Density Parse(string text)
        {
            return QuantityParser.Parse<DensityUnit, Density>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Density"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Density"/></param>
        /// <returns></returns>
        public static Density Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<DensityUnit, Density>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Density"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Density"/></param>
        /// <returns></returns>
        public static Density Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<DensityUnit, Density>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Density"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Density"/></param>
        /// <returns></returns>
        public static Density Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<DensityUnit, Density>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Density"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Density"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out Density result)
        {
            return QuantityParser.TryParse<DensityUnit, Density>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Density"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Density"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out Density result)
        {
            return QuantityParser.TryParse<DensityUnit, Density>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Density"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Density"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out Density result)
        {
            return QuantityParser.TryParse<DensityUnit, Density>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Density"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Density"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Density result)
        {
            return QuantityParser.TryParse<DensityUnit, Density>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Density"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Density"/></returns>
        public static Density ReadFrom(XmlReader reader)
        {
            var v = new Density();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Density"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Density From(double value, DensityUnit unit)
        {
            return new Density(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Density"/>.
        /// </summary>
        /// <param name="kilogramsPerCubicMetre">The value in <see cref="Gu.Units.DensityUnit.KilogramsPerCubicMetre"/></param>
        public static Density FromKilogramsPerCubicMetre(double kilogramsPerCubicMetre)
        {
            return new Density(kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Density"/>.
        /// </summary>
        /// <param name="gramsPerCubicMillimetre">The value in g/mm³</param>
        public static Density FromGramsPerCubicMillimetre(double gramsPerCubicMillimetre)
        {
            return new Density(1000000 * gramsPerCubicMillimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Density"/>.
        /// </summary>
        /// <param name="gramsPerCubicCentimetre">The value in g/cm³</param>
        public static Density FromGramsPerCubicCentimetre(double gramsPerCubicCentimetre)
        {
            return new Density(1000 * gramsPerCubicCentimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Density"/>.
        /// </summary>
        /// <param name="milligramsPerCubicMillimetre">The value in mg/mm³</param>
        public static Density FromMilligramsPerCubicMillimetre(double milligramsPerCubicMillimetre)
        {
            return new Density(1000 * milligramsPerCubicMillimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Density"/>.
        /// </summary>
        /// <param name="gramsPerCubicMetre">The value in g/m³</param>
        public static Density FromGramsPerCubicMetre(double gramsPerCubicMetre)
        {
            return new Density(gramsPerCubicMetre / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Density"/>.
        /// </summary>
        /// <param name="milligramsPerCubicMetre">The value in mg/m³</param>
        public static Density FromMilligramsPerCubicMetre(double milligramsPerCubicMetre)
        {
            return new Density(milligramsPerCubicMetre / 1000000);
        }

        public static AreaDensity operator *(Density left, Length right)
        {
            return AreaDensity.FromKilogramsPerSquareMetre(left.kilogramsPerCubicMetre * right.metres);
        }

        public static Mass operator *(Density left, Volume right)
        {
            return Mass.FromKilograms(left.kilogramsPerCubicMetre * right.cubicMetres);
        }

        public static MassFlow operator *(Density left, VolumetricFlow right)
        {
            return MassFlow.FromKilogramsPerSecond(left.kilogramsPerCubicMetre * right.cubicMetresPerSecond);
        }

        public static Pressure operator *(Density left, SpecificEnergy right)
        {
            return Pressure.FromPascals(left.kilogramsPerCubicMetre * right.joulesPerKilogram);
        }

        public static AreaDensity operator /(Density left, Wavenumber right)
        {
            return AreaDensity.FromKilogramsPerSquareMetre(left.kilogramsPerCubicMetre / right.reciprocalMetres);
        }

        public static Wavenumber operator /(Density left, AreaDensity right)
        {
            return Wavenumber.FromReciprocalMetres(left.kilogramsPerCubicMetre / right.kilogramsPerSquareMetre);
        }

        public static SpecificVolume operator /(double left, Density right)
        {
            return SpecificVolume.FromCubicMetresPerKilogram(left / right.kilogramsPerCubicMetre);
        }

        public static double operator /(Density left, Density right)
        {
            return left.kilogramsPerCubicMetre / right.kilogramsPerCubicMetre;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Density"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Density"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Density"/>.</param>
        public static bool operator ==(Density left, Density right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Density"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Density"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Density"/>.</param>
        public static bool operator !=(Density left, Density right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Density"/> is less than another specified <see cref="Gu.Units.Density"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Density"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Density"/>.</param>
        public static bool operator <(Density left, Density right)
        {
            return left.kilogramsPerCubicMetre < right.kilogramsPerCubicMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Density"/> is greater than another specified <see cref="Gu.Units.Density"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Density"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Density"/>.</param>
        public static bool operator >(Density left, Density right)
        {
            return left.kilogramsPerCubicMetre > right.kilogramsPerCubicMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Density"/> is less than or equal to another specified <see cref="Gu.Units.Density"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Density"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Density"/>.</param>
        public static bool operator <=(Density left, Density right)
        {
            return left.kilogramsPerCubicMetre <= right.kilogramsPerCubicMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Density"/> is greater than or equal to another specified <see cref="Gu.Units.Density"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Density"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Density"/>.</param>
        public static bool operator >=(Density left, Density right)
        {
            return left.kilogramsPerCubicMetre >= right.kilogramsPerCubicMetre;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Density"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Density"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Density"/> with <paramref name="left"/> and returns the result.</returns>
        public static Density operator *(double left, Density right)
        {
            return new Density(left * right.kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Density"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Density"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Density"/> with <paramref name="right"/> and returns the result.</returns>
        public static Density operator *(Density left, double right)
        {
            return new Density(left.kilogramsPerCubicMetre * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Density"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Density"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Density"/> with <paramref name="right"/> and returns the result.</returns>
        public static Density operator /(Density left, double right)
        {
            return new Density(left.kilogramsPerCubicMetre / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Density"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Density"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Density"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Density"/>.</param>
        public static Density operator +(Density left, Density right)
        {
            return new Density(left.kilogramsPerCubicMetre + right.kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Subtracts an Density from another Density and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Density"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Density"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Density"/> (the subtrahend).</param>
        public static Density operator -(Density left, Density right)
        {
            return new Density(left.kilogramsPerCubicMetre - right.kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Density"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Density"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="density">An instance of <see cref="Gu.Units.Density"/></param>
        public static Density operator -(Density density)
        {
            return new Density(-1 * density.kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Density"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="density"/>.
        /// </returns>
        /// <param name="density">An instance of <see cref="Gu.Units.Density"/></param>
        public static Density operator +(Density density)
        {
            return density;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(DensityUnit unit)
        {
            return unit.FromSiUnit(this.kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Density"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Density"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kg/m³\"</param>
        /// <returns>The string representation of the <see cref="Density"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kg/m³\"</param>
        /// <returns>The string representation of the <see cref="Density"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex kg/m³</param>
        /// <returns>The string representation of the <see cref="Density"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex kg/m³</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Density"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(DensityUnit unit)
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(DensityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(DensityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(DensityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, DensityUnit unit)
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, DensityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, DensityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, DensityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<DensityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<DensityUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Density"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Density"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Density"/> object to compare to this instance.</param>
        public int CompareTo(Density quantity)
        {
            return this.kilogramsPerCubicMetre.CompareTo(quantity.kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Density"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Density as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Density"/> object to compare with this instance.</param>
        public bool Equals(Density other)
        {
            return this.kilogramsPerCubicMetre.Equals(other.kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Density"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Density as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Density"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Density other, Density tolerance)
        {
            Ensure.GreaterThan(tolerance.kilogramsPerCubicMetre, 0, nameof(tolerance));
            return Math.Abs(this.kilogramsPerCubicMetre - other.kilogramsPerCubicMetre) < tolerance.kilogramsPerCubicMetre;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Density && this.Equals((Density)obj);
        }

        public override int GetHashCode()
        {
            return this.kilogramsPerCubicMetre.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "kilogramsPerCubicMetre", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.kilogramsPerCubicMetre);
        }
    }
}