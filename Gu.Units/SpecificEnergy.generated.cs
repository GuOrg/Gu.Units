namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.SpecificEnergy"/>.
    /// </summary>
    [TypeConverter(typeof(SpecificEnergyTypeConverter))]
    [Serializable]
    public partial struct SpecificEnergy : IQuantity<SpecificEnergyUnit>, IComparable<SpecificEnergy>, IEquatable<SpecificEnergy>
    {
        public static readonly SpecificEnergy Zero = new SpecificEnergy();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.SpecificEnergyUnit.JoulesPerKilogram"/>.
        /// </summary>
        internal readonly double joulesPerKilogram;

        private SpecificEnergy(double joulesPerKilogram)
        {
            this.joulesPerKilogram = joulesPerKilogram;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.SpecificEnergyUnit"/>.</param>
        public SpecificEnergy(double value, SpecificEnergyUnit unit)
        {
            this.joulesPerKilogram = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.SpecificEnergyUnit.JoulesPerKilogram"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.joulesPerKilogram;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.SpecificEnergyUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public SpecificEnergyUnit SiUnit => SpecificEnergyUnit.JoulesPerKilogram;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => SpecificEnergyUnit.JoulesPerKilogram;

        /// <summary>
        /// The quantity in joulesPerKilogram".
        /// </summary>
        public double JoulesPerKilogram
        {
            get
            {
                return this.joulesPerKilogram;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificEnergy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <returns></returns>
		public static SpecificEnergy Parse(string text)
        {
            return QuantityParser.Parse<SpecificEnergyUnit, SpecificEnergy>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificEnergy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <returns></returns>
        public static SpecificEnergy Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<SpecificEnergyUnit, SpecificEnergy>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificEnergy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <returns></returns>
        public static SpecificEnergy Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<SpecificEnergyUnit, SpecificEnergy>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificEnergy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <returns></returns>
        public static SpecificEnergy Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<SpecificEnergyUnit, SpecificEnergy>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificEnergy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out SpecificEnergy result)
        {
            return QuantityParser.TryParse<SpecificEnergyUnit, SpecificEnergy>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificEnergy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out SpecificEnergy result)
        {
            return QuantityParser.TryParse<SpecificEnergyUnit, SpecificEnergy>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificEnergy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out SpecificEnergy result)
        {
            return QuantityParser.TryParse<SpecificEnergyUnit, SpecificEnergy>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificEnergy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out SpecificEnergy result)
        {
            return QuantityParser.TryParse<SpecificEnergyUnit, SpecificEnergy>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.SpecificEnergy"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.SpecificEnergy"/></returns>
        public static SpecificEnergy ReadFrom(XmlReader reader)
        {
            var v = new SpecificEnergy();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static SpecificEnergy From(double value, SpecificEnergyUnit unit)
        {
            return new SpecificEnergy(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <param name="joulesPerKilogram">The value in <see cref="Gu.Units.SpecificEnergyUnit.JoulesPerKilogram"/></param>
        public static SpecificEnergy FromJoulesPerKilogram(double joulesPerKilogram)
        {
            return new SpecificEnergy(joulesPerKilogram);
        }

        public static Energy operator *(SpecificEnergy left, Mass right)
        {
            return Energy.FromJoules(left.joulesPerKilogram * right.kilograms);
        }

        public static Acceleration operator /(SpecificEnergy left, Length right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.joulesPerKilogram / right.metres);
        }

        public static KinematicViscosity operator *(SpecificEnergy left, Time right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.joulesPerKilogram * right.seconds);
        }

        public static SpecificVolume operator /(SpecificEnergy left, Pressure right)
        {
            return SpecificVolume.FromCubicMetresPerKilogram(left.joulesPerKilogram / right.pascals);
        }

        public static Pressure operator *(SpecificEnergy left, Density right)
        {
            return Pressure.FromPascals(left.joulesPerKilogram * right.kilogramsPerCubicMetre);
        }

        public static Speed operator /(SpecificEnergy left, Speed right)
        {
            return Speed.FromMetresPerSecond(left.joulesPerKilogram / right.metresPerSecond);
        }

        public static KinematicViscosity operator /(SpecificEnergy left, Frequency right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.joulesPerKilogram / right.hertz);
        }

        public static Length operator /(SpecificEnergy left, Acceleration right)
        {
            return Length.FromMetres(left.joulesPerKilogram / right.metresPerSecondSquared);
        }

        public static Acceleration operator *(SpecificEnergy left, Wavenumber right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.joulesPerKilogram * right.reciprocalMetres);
        }

        public static Stiffness operator *(SpecificEnergy left, AreaDensity right)
        {
            return Stiffness.FromNewtonsPerMetre(left.joulesPerKilogram * right.kilogramsPerSquareMetre);
        }

        public static Pressure operator /(SpecificEnergy left, SpecificVolume right)
        {
            return Pressure.FromPascals(left.joulesPerKilogram / right.cubicMetresPerKilogram);
        }

        public static Power operator *(SpecificEnergy left, MassFlow right)
        {
            return Power.FromWatts(left.joulesPerKilogram * right.kilogramsPerSecond);
        }

        public static Frequency operator /(SpecificEnergy left, KinematicViscosity right)
        {
            return Frequency.FromHertz(left.joulesPerKilogram / right.squareMetresPerSecond);
        }

        public static double operator /(SpecificEnergy left, SpecificEnergy right)
        {
            return left.joulesPerKilogram / right.joulesPerKilogram;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SpecificEnergy"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator ==(SpecificEnergy left, SpecificEnergy right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SpecificEnergy"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator !=(SpecificEnergy left, SpecificEnergy right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.SpecificEnergy"/> is less than another specified <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator <(SpecificEnergy left, SpecificEnergy right)
        {
            return left.joulesPerKilogram < right.joulesPerKilogram;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.SpecificEnergy"/> is greater than another specified <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator >(SpecificEnergy left, SpecificEnergy right)
        {
            return left.joulesPerKilogram > right.joulesPerKilogram;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.SpecificEnergy"/> is less than or equal to another specified <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator <=(SpecificEnergy left, SpecificEnergy right)
        {
            return left.joulesPerKilogram <= right.joulesPerKilogram;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.SpecificEnergy"/> is greater than or equal to another specified <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static bool operator >=(SpecificEnergy left, SpecificEnergy right)
        {
            return left.joulesPerKilogram >= right.joulesPerKilogram;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.SpecificEnergy"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.SpecificEnergy"/> with <paramref name="left"/> and returns the result.</returns>
        public static SpecificEnergy operator *(double left, SpecificEnergy right)
        {
            return new SpecificEnergy(left * right.joulesPerKilogram);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.SpecificEnergy"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.SpecificEnergy"/> with <paramref name="right"/> and returns the result.</returns>
        public static SpecificEnergy operator *(SpecificEnergy left, double right)
        {
            return new SpecificEnergy(left.joulesPerKilogram * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.SpecificEnergy"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.SpecificEnergy"/> with <paramref name="right"/> and returns the result.</returns>
        public static SpecificEnergy operator /(SpecificEnergy left, double right)
        {
            return new SpecificEnergy(left.joulesPerKilogram / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.SpecificEnergy"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.SpecificEnergy"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/>.</param>
        public static SpecificEnergy operator +(SpecificEnergy left, SpecificEnergy right)
        {
            return new SpecificEnergy(left.joulesPerKilogram + right.joulesPerKilogram);
        }

        /// <summary>
        /// Subtracts an SpecificEnergy from another SpecificEnergy and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.SpecificEnergy"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergy"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergy"/> (the subtrahend).</param>
        public static SpecificEnergy operator -(SpecificEnergy left, SpecificEnergy right)
        {
            return new SpecificEnergy(left.joulesPerKilogram - right.joulesPerKilogram);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.SpecificEnergy"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.SpecificEnergy"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="specificEnergy">An instance of <see cref="Gu.Units.SpecificEnergy"/></param>
        public static SpecificEnergy operator -(SpecificEnergy specificEnergy)
        {
            return new SpecificEnergy(-1 * specificEnergy.joulesPerKilogram);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.SpecificEnergy"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="specificEnergy"/>.
        /// </returns>
        /// <param name="specificEnergy">An instance of <see cref="Gu.Units.SpecificEnergy"/></param>
        public static SpecificEnergy operator +(SpecificEnergy specificEnergy)
        {
            return specificEnergy;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(SpecificEnergyUnit unit)
        {
            return unit.FromSiUnit(this.joulesPerKilogram);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="SpecificEnergy"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="SpecificEnergy"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 J/kg\"</param>
        /// <returns>The string representation of the <see cref="SpecificEnergy"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 J/kg\"</param>
        /// <returns>The string representation of the <see cref="SpecificEnergy"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex J/kg</param>
        /// <returns>The string representation of the <see cref="SpecificEnergy"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex J/kg</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="SpecificEnergy"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(SpecificEnergyUnit unit)
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(SpecificEnergyUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(SpecificEnergyUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(SpecificEnergyUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, SpecificEnergyUnit unit)
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, SpecificEnergyUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, SpecificEnergyUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, SpecificEnergyUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<SpecificEnergyUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<SpecificEnergyUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.SpecificEnergy"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.SpecificEnergy"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.SpecificEnergy"/> object to compare to this instance.</param>
        public int CompareTo(SpecificEnergy quantity)
        {
            return this.joulesPerKilogram.CompareTo(quantity.joulesPerKilogram);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.SpecificEnergy"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same SpecificEnergy as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.SpecificEnergy"/> object to compare with this instance.</param>
        public bool Equals(SpecificEnergy other)
        {
            return this.joulesPerKilogram.Equals(other.joulesPerKilogram);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.SpecificEnergy"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same SpecificEnergy as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.SpecificEnergy"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(SpecificEnergy other, SpecificEnergy tolerance)
        {
            Ensure.GreaterThan(tolerance.joulesPerKilogram, 0, nameof(tolerance));
            return Math.Abs(this.joulesPerKilogram - other.joulesPerKilogram) < tolerance.joulesPerKilogram;
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
            return this.joulesPerKilogram.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "joulesPerKilogram", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.joulesPerKilogram);
        }
    }
}