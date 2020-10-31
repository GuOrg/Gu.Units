#nullable enable
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
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.VolumeUnit.CubicMetres"/>
        /// </summary>
        public static readonly Volume Zero = default(Volume);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.VolumeUnit.CubicMetres"/>.
        /// </summary>
        internal readonly double cubicMetres;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Volume"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.VolumeUnit"/>.</param>
        public Volume(double value, VolumeUnit unit)
        {
            this.cubicMetres = unit.ToSiUnit(value);
        }

        private Volume(double cubicMetres)
        {
            this.cubicMetres = cubicMetres;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.VolumeUnit.CubicMetres"/>
        /// </summary>
        public double SiValue => this.cubicMetres;

        /// <summary>
        /// Gets the <see cref="Gu.Units.VolumeUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public VolumeUnit SiUnit => VolumeUnit.CubicMetres;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => VolumeUnit.CubicMetres;

        /// <summary>
        /// Gets the quantity in cubicMetres".
        /// </summary>
        public double CubicMetres => this.cubicMetres;

        /// <summary>
        /// Gets the quantity in Litres
        /// </summary>
        public double Litres => 1000 * this.cubicMetres;

        /// <summary>
        /// Gets the quantity in Millilitres
        /// </summary>
        public double Millilitres => 1000000 * this.cubicMetres;

        /// <summary>
        /// Gets the quantity in Centilitres
        /// </summary>
        public double Centilitres => 100000 * this.cubicMetres;

        /// <summary>
        /// Gets the quantity in Decilitres
        /// </summary>
        public double Decilitres => 10000 * this.cubicMetres;

        /// <summary>
        /// Gets the quantity in CubicCentimetres
        /// </summary>
        public double CubicCentimetres => 1000000 * this.cubicMetres;

        /// <summary>
        /// Gets the quantity in CubicMillimetres
        /// </summary>
        public double CubicMillimetres => 1000000000 * this.cubicMetres;

        /// <summary>
        /// Gets the quantity in CubicInches
        /// </summary>
        public double CubicInches => this.cubicMetres / 1.6387064E-05;

        /// <summary>
        /// Gets the quantity in CubicDecimetres
        /// </summary>
        public double CubicDecimetres => 1000 * this.cubicMetres;

        /// <summary>
        /// Gets the quantity in CubicFeet
        /// </summary>
        public double CubicFeet => this.cubicMetres / 0.028316846592;

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificVolume"/> that is the result from the division.</returns>
        public static SpecificVolume operator /(Volume left, Mass right)
        {
            return SpecificVolume.FromCubicMetresPerKilogram(left.cubicMetres / right.kilograms);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Area"/> that is the result from the division.</returns>
        public static Area operator /(Volume left, Length right)
        {
            return Area.FromSquareMetres(left.cubicMetres / right.metres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="VolumetricFlow"/> that is the result from the division.</returns>
        public static VolumetricFlow operator /(Volume left, Time right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.cubicMetres / right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the division.</returns>
        public static Length operator /(Volume left, Area right)
        {
            return Length.FromMetres(left.cubicMetres / right.squareMetres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(Volume left, Pressure right)
        {
            return Energy.FromJoules(left.cubicMetres * right.pascals);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Mass"/> that is the result from the multiplication.</returns>
        public static Mass operator *(Volume left, Density right)
        {
            return Mass.FromKilograms(left.cubicMetres * right.kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="VolumetricFlow"/> that is the result from the multiplication.</returns>
        public static VolumetricFlow operator *(Volume left, Frequency right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.cubicMetres * right.hertz);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the division.</returns>
        public static Time operator /(Volume left, VolumetricFlow right)
        {
            return Time.FromSeconds(left.cubicMetres / right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Area"/> that is the result from the multiplication.</returns>
        public static Area operator *(Volume left, Wavenumber right)
        {
            return Area.FromSquareMetres(left.cubicMetres * right.reciprocalMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Mass"/> that is the result from the division.</returns>
        public static Mass operator /(Volume left, SpecificVolume right)
        {
            return Mass.FromKilograms(left.cubicMetres / right.cubicMetresPerKilogram);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Volume left, Volume right)
        {
            return left.cubicMetres / right.cubicMetres;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Volume"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Volume"/>.</param>
        public static bool operator ==(Volume left, Volume right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Volume"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Volume"/>.</param>
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
        /// <param name="left">The left instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Volume"/>.</param>
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
        /// <param name="left">The left instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Volume"/>.</param>
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
        /// <param name="left">The left instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Volume"/>.</param>
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
        /// <param name="left">The left instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Volume"/>.</param>
        public static bool operator >=(Volume left, Volume right)
        {
            return left.cubicMetres >= right.cubicMetres;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Volume"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Volume"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Volume"/> and returns the result.</returns>
        public static Volume operator *(double left, Volume right)
        {
            return new Volume(left * right.cubicMetres);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Volume"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Volume"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Volume"/> with <paramref name="right"/> and returns the result.</returns>
        public static Volume operator *(Volume left, double right)
        {
            return new Volume(left.cubicMetres * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Volume"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Volume"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Volume"/> by <paramref name="right"/> and returns the result.</returns>
        public static Volume operator /(Volume left, double right)
        {
            return new Volume(left.cubicMetres / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Volume"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Volume"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Volume"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Volume"/>.</param>
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
        /// <param name="left">The left instance of <see cref="Gu.Units.Volume"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Volume"/> (the subtrahend).</param>
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
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <returns>The <see cref="Gu.Units.Volume"/> parsed from <paramref name="text"/></returns>
        public static Volume Parse(string text)
        {
            return QuantityParser.Parse<VolumeUnit, Volume>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Volume"/> parsed from <paramref name="text"/></returns>
        public static Volume Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<VolumeUnit, Volume>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Volume"/> parsed from <paramref name="text"/></returns>
        public static Volume Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<VolumeUnit, Volume>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Volume"/> parsed from <paramref name="text"/></returns>
        public static Volume Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<VolumeUnit, Volume>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <param name="result">The parsed <see cref="Volume"/></param>
        /// <returns>True if an instance of <see cref="Volume"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Volume result)
        {
            return QuantityParser.TryParse<VolumeUnit, Volume>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Volume"/></param>
        /// <returns>True if an instance of <see cref="Volume"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Volume result)
        {
            return QuantityParser.TryParse<VolumeUnit, Volume>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Volume"/></param>
        /// <returns>True if an instance of <see cref="Volume"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Volume result)
        {
            return QuantityParser.TryParse<VolumeUnit, Volume>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Volume"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Volume"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Volume"/></param>
        /// <returns>True if an instance of <see cref="Volume"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Volume result)
        {
            return QuantityParser.TryParse<VolumeUnit, Volume>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Volume"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Volume"/></returns>
        public static Volume ReadFrom(XmlReader reader)
        {
            var v = default(Volume);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Volume"/></returns>
        public static Volume From(double value, VolumeUnit unit)
        {
            return new Volume(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicMetres">The value in <see cref="Gu.Units.VolumeUnit.CubicMetres"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Volume"/></returns>
        public static Volume FromCubicMetres(double cubicMetres)
        {
            return new Volume(cubicMetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="litres">The value in L.</param>
        /// <returns>An instance of <see cref="Gu.Units.Volume"/></returns>
        public static Volume FromLitres(double litres)
        {
            return new Volume(litres / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="millilitres">The value in ml.</param>
        /// <returns>An instance of <see cref="Gu.Units.Volume"/></returns>
        public static Volume FromMillilitres(double millilitres)
        {
            return new Volume(millilitres / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="centilitres">The value in cl.</param>
        /// <returns>An instance of <see cref="Gu.Units.Volume"/></returns>
        public static Volume FromCentilitres(double centilitres)
        {
            return new Volume(centilitres / 100000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="decilitres">The value in dl.</param>
        /// <returns>An instance of <see cref="Gu.Units.Volume"/></returns>
        public static Volume FromDecilitres(double decilitres)
        {
            return new Volume(decilitres / 10000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicCentimetres">The value in cm³.</param>
        /// <returns>An instance of <see cref="Gu.Units.Volume"/></returns>
        public static Volume FromCubicCentimetres(double cubicCentimetres)
        {
            return new Volume(cubicCentimetres / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicMillimetres">The value in mm³.</param>
        /// <returns>An instance of <see cref="Gu.Units.Volume"/></returns>
        public static Volume FromCubicMillimetres(double cubicMillimetres)
        {
            return new Volume(cubicMillimetres / 1000000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicInches">The value in in³.</param>
        /// <returns>An instance of <see cref="Gu.Units.Volume"/></returns>
        public static Volume FromCubicInches(double cubicInches)
        {
            return new Volume(1.6387064E-05 * cubicInches);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicDecimetres">The value in dm³.</param>
        /// <returns>An instance of <see cref="Gu.Units.Volume"/></returns>
        public static Volume FromCubicDecimetres(double cubicDecimetres)
        {
            return new Volume(cubicDecimetres / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Volume"/>.
        /// </summary>
        /// <param name="cubicFeet">The value in ft³.</param>
        /// <returns>An instance of <see cref="Gu.Units.Volume"/></returns>
        public static Volume FromCubicFeet(double cubicFeet)
        {
            return new Volume(0.028316846592 * cubicFeet);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
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
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Volume"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m³\"</param>
        /// <returns>The string representation of the <see cref="Volume"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m³\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Volume"/></returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m³</param>
        /// <returns>The string representation of the <see cref="Volume"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m³</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="Volume"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(VolumeUnit unit)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(VolumeUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(VolumeUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(VolumeUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, VolumeUnit unit)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, VolumeUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, VolumeUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, VolumeUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumeUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Volume"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Volume"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantities of this instance and <paramref name="quantity"/>.
        /// Value
        /// Description
        /// A negative integer
        /// This instance is smaller than <paramref name="quantity"/>.
        /// Zero
        /// This instance is equal to <paramref name="quantity"/>.
        /// A positive integer
        /// This instance is larger than <paramref name="quantity"/>.
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

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Volume"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Volume"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is Volume other && this.Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
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
        public XmlSchema? GetSchema() => null;

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

        internal string ToString(QuantityFormat<VolumeUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
