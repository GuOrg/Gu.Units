namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.SpecificVolume"/>.
    /// </summary>
    [TypeConverter(typeof(SpecificVolumeTypeConverter))]
    [Serializable]
    public partial struct SpecificVolume : IQuantity<SpecificVolumeUnit>, IComparable<SpecificVolume>, IEquatable<SpecificVolume>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.SpecificVolumeUnit.CubicMetresPerKilogram"/>
        /// </summary>
        public static readonly SpecificVolume Zero = default(SpecificVolume);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.SpecificVolumeUnit.CubicMetresPerKilogram"/>.
        /// </summary>
        internal readonly double cubicMetresPerKilogram;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.SpecificVolume"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.SpecificVolumeUnit"/>.</param>
        public SpecificVolume(double value, SpecificVolumeUnit unit)
        {
            this.cubicMetresPerKilogram = unit.ToSiUnit(value);
        }

        private SpecificVolume(double cubicMetresPerKilogram)
        {
            this.cubicMetresPerKilogram = cubicMetresPerKilogram;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.SpecificVolumeUnit.CubicMetresPerKilogram"/>
        /// </summary>
        public double SiValue => this.cubicMetresPerKilogram;

        /// <summary>
        /// Gets the <see cref="Gu.Units.SpecificVolumeUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public SpecificVolumeUnit SiUnit => SpecificVolumeUnit.CubicMetresPerKilogram;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => SpecificVolumeUnit.CubicMetresPerKilogram;

        /// <summary>
        /// Gets the quantity in cubicMetresPerKilogram".
        /// </summary>
        public double CubicMetresPerKilogram => this.cubicMetresPerKilogram;

        /// <summary>
        /// Gets the quantity in CubicMetresPerGram
        /// </summary>
        public double CubicMetresPerGram => this.cubicMetresPerKilogram / 1000;

        /// <summary>
        /// Gets the quantity in CubicCentimetresPerGram
        /// </summary>
        public double CubicCentimetresPerGram => 1000 * this.cubicMetresPerKilogram;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Volume"/> that is the result from the multiplication.</returns>
        public static Volume operator *(SpecificVolume left, Mass right)
        {
            return Volume.FromCubicMetres(left.cubicMetresPerKilogram * right.kilograms);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificEnergy"/> that is the result from the multiplication.</returns>
        public static SpecificEnergy operator *(SpecificVolume left, Pressure right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.cubicMetresPerKilogram * right.pascals);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the multiplication.</returns>
        public static Length operator *(SpecificVolume left, AreaDensity right)
        {
            return Length.FromMetres(left.cubicMetresPerKilogram * right.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="VolumetricFlow"/> that is the result from the multiplication.</returns>
        public static VolumetricFlow operator *(SpecificVolume left, MassFlow right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.cubicMetresPerKilogram * right.kilogramsPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The Density that is the result from the division.</returns>
        public static Density operator /(double left, SpecificVolume right)
        {
            return Density.FromKilogramsPerCubicMetre(left / right.cubicMetresPerKilogram);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(SpecificVolume left, SpecificVolume right)
        {
            return left.cubicMetresPerKilogram / right.cubicMetresPerKilogram;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SpecificVolume"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        public static bool operator ==(SpecificVolume left, SpecificVolume right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SpecificVolume"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        public static bool operator !=(SpecificVolume left, SpecificVolume right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.SpecificVolume"/> is less than another specified <see cref="Gu.Units.SpecificVolume"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        public static bool operator <(SpecificVolume left, SpecificVolume right)
        {
            return left.cubicMetresPerKilogram < right.cubicMetresPerKilogram;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.SpecificVolume"/> is greater than another specified <see cref="Gu.Units.SpecificVolume"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        public static bool operator >(SpecificVolume left, SpecificVolume right)
        {
            return left.cubicMetresPerKilogram > right.cubicMetresPerKilogram;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.SpecificVolume"/> is less than or equal to another specified <see cref="Gu.Units.SpecificVolume"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        public static bool operator <=(SpecificVolume left, SpecificVolume right)
        {
            return left.cubicMetresPerKilogram <= right.cubicMetresPerKilogram;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.SpecificVolume"/> is greater than or equal to another specified <see cref="Gu.Units.SpecificVolume"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        public static bool operator >=(SpecificVolume left, SpecificVolume right)
        {
            return left.cubicMetresPerKilogram >= right.cubicMetresPerKilogram;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.SpecificVolume"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.SpecificVolume"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.SpecificVolume"/> and returns the result.</returns>
        public static SpecificVolume operator *(double left, SpecificVolume right)
        {
            return new SpecificVolume(left * right.cubicMetresPerKilogram);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.SpecificVolume"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.SpecificVolume"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.SpecificVolume"/> with <paramref name="right"/> and returns the result.</returns>
        public static SpecificVolume operator *(SpecificVolume left, double right)
        {
            return new SpecificVolume(left.cubicMetresPerKilogram * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.SpecificVolume"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.SpecificVolume"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.SpecificVolume"/> by <paramref name="right"/> and returns the result.</returns>
        public static SpecificVolume operator /(SpecificVolume left, double right)
        {
            return new SpecificVolume(left.cubicMetresPerKilogram / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.SpecificVolume"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.SpecificVolume"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.SpecificVolume"/>.</param>
        public static SpecificVolume operator +(SpecificVolume left, SpecificVolume right)
        {
            return new SpecificVolume(left.cubicMetresPerKilogram + right.cubicMetresPerKilogram);
        }

        /// <summary>
        /// Subtracts an SpecificVolume from another SpecificVolume and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.SpecificVolume"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.SpecificVolume"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.SpecificVolume"/> (the subtrahend).</param>
        public static SpecificVolume operator -(SpecificVolume left, SpecificVolume right)
        {
            return new SpecificVolume(left.cubicMetresPerKilogram - right.cubicMetresPerKilogram);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.SpecificVolume"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.SpecificVolume"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="specificVolume">An instance of <see cref="Gu.Units.SpecificVolume"/></param>
        public static SpecificVolume operator -(SpecificVolume specificVolume)
        {
            return new SpecificVolume(-1 * specificVolume.cubicMetresPerKilogram);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.SpecificVolume"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="specificVolume"/>.
        /// </returns>
        /// <param name="specificVolume">An instance of <see cref="Gu.Units.SpecificVolume"/></param>
        public static SpecificVolume operator +(SpecificVolume specificVolume)
        {
            return specificVolume;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificVolume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificVolume"/></param>
        /// <returns>The <see cref="Gu.Units.SpecificVolume"/> parsed from <paramref name="text"/></returns>
        public static SpecificVolume Parse(string text)
        {
            return QuantityParser.Parse<SpecificVolumeUnit, SpecificVolume>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificVolume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificVolume"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.SpecificVolume"/> parsed from <paramref name="text"/></returns>
        public static SpecificVolume Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<SpecificVolumeUnit, SpecificVolume>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificVolume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificVolume"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.SpecificVolume"/> parsed from <paramref name="text"/></returns>
        public static SpecificVolume Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<SpecificVolumeUnit, SpecificVolume>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificVolume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificVolume"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.SpecificVolume"/> parsed from <paramref name="text"/></returns>
        public static SpecificVolume Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<SpecificVolumeUnit, SpecificVolume>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificVolume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificVolume"/></param>
        /// <param name="result">The parsed <see cref="SpecificVolume"/></param>
        /// <returns>True if an instance of <see cref="SpecificVolume"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out SpecificVolume result)
        {
            return QuantityParser.TryParse<SpecificVolumeUnit, SpecificVolume>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificVolume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificVolume"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="SpecificVolume"/></param>
        /// <returns>True if an instance of <see cref="SpecificVolume"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out SpecificVolume result)
        {
            return QuantityParser.TryParse<SpecificVolumeUnit, SpecificVolume>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificVolume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificVolume"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="SpecificVolume"/></param>
        /// <returns>True if an instance of <see cref="SpecificVolume"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out SpecificVolume result)
        {
            return QuantityParser.TryParse<SpecificVolumeUnit, SpecificVolume>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificVolume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificVolume"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="SpecificVolume"/></param>
        /// <returns>True if an instance of <see cref="SpecificVolume"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out SpecificVolume result)
        {
            return QuantityParser.TryParse<SpecificVolumeUnit, SpecificVolume>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.SpecificVolume"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.SpecificVolume"/></returns>
        public static SpecificVolume ReadFrom(XmlReader reader)
        {
            var v = default(SpecificVolume);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.SpecificVolume"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.SpecificVolume"/></returns>
        public static SpecificVolume From(double value, SpecificVolumeUnit unit)
        {
            return new SpecificVolume(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.SpecificVolume"/>.
        /// </summary>
        /// <param name="cubicMetresPerKilogram">The value in <see cref="Gu.Units.SpecificVolumeUnit.CubicMetresPerKilogram"/></param>
        /// <returns>An instance of <see cref="Gu.Units.SpecificVolume"/></returns>
        public static SpecificVolume FromCubicMetresPerKilogram(double cubicMetresPerKilogram)
        {
            return new SpecificVolume(cubicMetresPerKilogram);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.SpecificVolume"/>.
        /// </summary>
        /// <param name="cubicMetresPerGram">The value in m³/g.</param>
        /// <returns>An instance of <see cref="Gu.Units.SpecificVolume"/></returns>
        public static SpecificVolume FromCubicMetresPerGram(double cubicMetresPerGram)
        {
            return new SpecificVolume(1000 * cubicMetresPerGram);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.SpecificVolume"/>.
        /// </summary>
        /// <param name="cubicCentimetresPerGram">The value in cm³/g.</param>
        /// <returns>An instance of <see cref="Gu.Units.SpecificVolume"/></returns>
        public static SpecificVolume FromCubicCentimetresPerGram(double cubicCentimetresPerGram)
        {
            return new SpecificVolume(cubicCentimetresPerGram / 1000);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(SpecificVolumeUnit unit)
        {
            return unit.FromSiUnit(this.cubicMetresPerKilogram);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="SpecificVolume"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="SpecificVolume"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m³/kg\"</param>
        /// <returns>The string representation of the <see cref="SpecificVolume"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m³/kg\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="SpecificVolume"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m³/kg</param>
        /// <returns>The string representation of the <see cref="SpecificVolume"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m³/kg</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the <see cref="SpecificVolume"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(SpecificVolumeUnit unit)
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(SpecificVolumeUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(SpecificVolumeUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(SpecificVolumeUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, SpecificVolumeUnit unit)
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, SpecificVolumeUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, SpecificVolumeUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, SpecificVolumeUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<SpecificVolumeUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.SpecificVolume"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.SpecificVolume"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantitys of this instance and <paramref name="quantity"/>.
        /// Value
        /// Description
        /// A negative integer
        /// This instance is smaller than <paramref name="quantity"/>.
        /// Zero
        /// This instance is equal to <paramref name="quantity"/>.
        /// A positive integer
        /// This instance is larger than <paramref name="quantity"/>.
        /// </returns>
        /// <param name="quantity">An instance of <see cref="Gu.Units.SpecificVolume"/> object to compare to this instance.</param>
        public int CompareTo(SpecificVolume quantity)
        {
            return this.cubicMetresPerKilogram.CompareTo(quantity.cubicMetresPerKilogram);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.SpecificVolume"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same SpecificVolume as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.SpecificVolume"/> object to compare with this instance.</param>
        public bool Equals(SpecificVolume other)
        {
            return this.cubicMetresPerKilogram.Equals(other.cubicMetresPerKilogram);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.SpecificVolume"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same SpecificVolume as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.SpecificVolume"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(SpecificVolume other, SpecificVolume tolerance)
        {
            Ensure.GreaterThan(tolerance.cubicMetresPerKilogram, 0, nameof(tolerance));
            return Math.Abs(this.cubicMetresPerKilogram - other.cubicMetresPerKilogram) < tolerance.cubicMetresPerKilogram;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.SpecificVolume"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.SpecificVolume"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is SpecificVolume && this.Equals((SpecificVolume)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.cubicMetresPerKilogram.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "cubicMetresPerKilogram", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.cubicMetresPerKilogram);
        }

        internal string ToString(QuantityFormat<SpecificVolumeUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
