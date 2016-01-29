namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Volume"/>.
    /// </summary>
    [TypeConverter(typeof(VolumeTypeConverter))]
    [Serializable]
    public partial struct Volume : IQuantity<VolumeUnit>, IComparable<Volume>, IEquatable<Volume>
    {
        public static readonly Volume Zero = new Volume();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.VolumeUnit.CubicMetres"/>.
        /// </summary>
        internal readonly double cubicMetres;

        private Volume(double cubicMetres)
        {
            this.cubicMetres = cubicMetres;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.VolumeUnit"/>.</param>
        public Volume(double value, VolumeUnit unit)
        {
            this.cubicMetres = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.VolumeUnit.CubicMetres"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.cubicMetres;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.VolumeUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public VolumeUnit SiUnit => VolumeUnit.CubicMetres;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => VolumeUnit.CubicMetres;

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
        /// The quantity in Litres
        /// </summary>
        public double Litres => 1000 * this.cubicMetres;

        /// <summary>
        /// The quantity in Millilitres
        /// </summary>
        public double Millilitres => 1000000 * this.cubicMetres;

        /// <summary>
        /// The quantity in Centilitres
        /// </summary>
        public double Centilitres => 100000 * this.cubicMetres;

        /// <summary>
        /// The quantity in Decilitres
        /// </summary>
        public double Decilitres => 10000 * this.cubicMetres;

        /// <summary>
        /// The quantity in CubicCentimetres
        /// </summary>
        public double CubicCentimetres => 1000000 * this.cubicMetres;

        /// <summary>
        /// The quantity in CubicMillimetres
        /// </summary>
        public double CubicMillimetres => 1000000000 * this.cubicMetres;

        /// <summary>
        /// The quantity in CubicInches
        /// </summary>
        public double CubicInches => this.cubicMetres / 1.6387064E-05;

        /// <summary>
        /// The quantity in CubicDecimetres
        /// </summary>
        public double CubicDecimetres => 1000 * this.cubicMetres;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <returns></returns>
		public static Volume Parse(string text)
        {
            return QuantityParser.Parse<VolumeUnit, Volume>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <returns></returns>
        public static Volume Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<VolumeUnit, Volume>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <returns></returns>
        public static Volume Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<VolumeUnit, Volume>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <returns></returns>
        public static Volume Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<VolumeUnit, Volume>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out Volume result)
        {
            return QuantityParser.TryParse<VolumeUnit, Volume>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out Volume result)
        {
            return QuantityParser.TryParse<VolumeUnit, Volume>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out Volume result)
        {
            return QuantityParser.TryParse<VolumeUnit, Volume>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Volume result)
        {
            return QuantityParser.TryParse<VolumeUnit, Volume>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Volume"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Volume"/></returns>
        public static Volume ReadFrom(XmlReader reader)
        {
            var v = new Volume();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Volume From(double value, VolumeUnit unit)
        {
            return new Volume(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicMetres">The value in <see cref="Gu.Units.VolumeUnit.CubicMetres"/></param>
        public static Volume FromCubicMetres(double cubicMetres)
        {
            return new Volume(cubicMetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="litres">The value in L</param>
        public static Volume FromLitres(double litres)
        {
            return new Volume(litres / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="millilitres">The value in ml</param>
        public static Volume FromMillilitres(double millilitres)
        {
            return new Volume(millilitres / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="centilitres">The value in cl</param>
        public static Volume FromCentilitres(double centilitres)
        {
            return new Volume(centilitres / 100000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="decilitres">The value in dl</param>
        public static Volume FromDecilitres(double decilitres)
        {
            return new Volume(decilitres / 10000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicCentimetres">The value in cm³</param>
        public static Volume FromCubicCentimetres(double cubicCentimetres)
        {
            return new Volume(cubicCentimetres / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicMillimetres">The value in mm³</param>
        public static Volume FromCubicMillimetres(double cubicMillimetres)
        {
            return new Volume(cubicMillimetres / 1000000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicInches">The value in in³</param>
        public static Volume FromCubicInches(double cubicInches)
        {
            return new Volume(1.6387064E-05 * cubicInches);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicDecimetres">The value in dm³</param>
        public static Volume FromCubicDecimetres(double cubicDecimetres)
        {
            return new Volume(cubicDecimetres / 1000);
        }

        public static SpecificVolume operator /(Volume left, Mass right)
        {
            return SpecificVolume.FromCubicMetresPerKilogram(left.cubicMetres / right.kilograms);
        }

        public static Area operator /(Volume left, Length right)
        {
            return Area.FromSquareMetres(left.cubicMetres / right.metres);
        }

        public static VolumetricFlow operator /(Volume left, Time right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.cubicMetres / right.seconds);
        }

        public static Length operator /(Volume left, Area right)
        {
            return Length.FromMetres(left.cubicMetres / right.squareMetres);
        }

        public static Energy operator *(Volume left, Pressure right)
        {
            return Energy.FromJoules(left.cubicMetres * right.pascals);
        }

        public static Mass operator *(Volume left, Density right)
        {
            return Mass.FromKilograms(left.cubicMetres * right.kilogramsPerCubicMetre);
        }

        public static VolumetricFlow operator *(Volume left, Frequency right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.cubicMetres * right.hertz);
        }

        public static Time operator /(Volume left, VolumetricFlow right)
        {
            return Time.FromSeconds(left.cubicMetres / right.cubicMetresPerSecond);
        }

        public static Area operator *(Volume left, Wavenumber right)
        {
            return Area.FromSquareMetres(left.cubicMetres * right.reciprocalMetres);
        }

        public static Mass operator /(Volume left, SpecificVolume right)
        {
            return Mass.FromKilograms(left.cubicMetres / right.cubicMetresPerKilogram);
        }

        public static double operator /(Volume left, Volume right)
        {
            return left.cubicMetres / right.cubicMetres;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Volume"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Volume"/>.</param>
        public static bool operator ==(Volume left, Volume right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Volume"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Volume"/>.</param>
        public static bool operator !=(Volume left, Volume right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Volume"/> is less than another specified <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Volume"/>.</param>
        public static bool operator <(Volume left, Volume right)
        {
            return left.cubicMetres < right.cubicMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Volume"/> is greater than another specified <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Volume"/>.</param>
        public static bool operator >(Volume left, Volume right)
        {
            return left.cubicMetres > right.cubicMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Volume"/> is less than or equal to another specified <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Volume"/>.</param>
        public static bool operator <=(Volume left, Volume right)
        {
            return left.cubicMetres <= right.cubicMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Volume"/> is greater than or equal to another specified <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Volume"/>.</param>
        public static bool operator >=(Volume left, Volume right)
        {
            return left.cubicMetres >= right.cubicMetres;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Volume"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Volume"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Volume"/> with <paramref name="left"/> and returns the result.</returns>
        public static Volume operator *(double left, Volume right)
        {
            return new Volume(left * right.cubicMetres);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Volume"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Volume"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Volume"/> with <paramref name="right"/> and returns the result.</returns>
        public static Volume operator *(Volume left, double right)
        {
            return new Volume(left.cubicMetres * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Volume"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Volume"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Volume"/> with <paramref name="right"/> and returns the result.</returns>
        public static Volume operator /(Volume left, double right)
        {
            return new Volume(left.cubicMetres / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Volume"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Volume"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Volume"/>.</param>
        public static Volume operator +(Volume left, Volume right)
        {
            return new Volume(left.cubicMetres + right.cubicMetres);
        }

        /// <summary>
        /// Subtracts an Volume from another Volume and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Volume"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Volume"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Volume"/> (the subtrahend).</param>
        public static Volume operator -(Volume left, Volume right)
        {
            return new Volume(left.cubicMetres - right.cubicMetres);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Volume"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Volume"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="volume">An instance of <see cref="Gu.Units.Volume"/></param>
        public static Volume operator -(Volume volume)
        {
            return new Volume(-1 * volume.cubicMetres);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="volume"/>.
        /// </returns>
        /// <param name="volume">An instance of <see cref="Gu.Units.Volume"/></param>
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

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Volume"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Volume"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m³\"</param>
        /// <returns>The string representation of the <see cref="Volume"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m³\"</param>
        /// <returns>The string representation of the <see cref="Volume"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m³</param>
        /// <returns>The string representation of the <see cref="Volume"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m³</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Volume"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(VolumeUnit unit)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(VolumeUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(VolumeUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(VolumeUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, VolumeUnit unit)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, VolumeUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, VolumeUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, VolumeUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<VolumeUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Volume"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Volume"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Volume"/> object to compare to this instance.</param>
        public int CompareTo(Volume quantity)
        {
            return this.cubicMetres.CompareTo(quantity.cubicMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Volume"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Volume as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Volume"/> object to compare with this instance.</param>
        public bool Equals(Volume other)
        {
            return this.cubicMetres.Equals(other.cubicMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Volume"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Volume as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Volume"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Volume other, Volume tolerance)
        {
            Ensure.GreaterThan(tolerance.cubicMetres, 0, nameof(tolerance));
            return Math.Abs(this.cubicMetres - other.cubicMetres) < tolerance.cubicMetres;
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
            XmlExt.SetReadonlyField(ref this, "cubicMetres", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.cubicMetres);
        }
    }
}