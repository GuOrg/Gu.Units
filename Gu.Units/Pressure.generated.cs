#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Pressure"/>.
    /// </summary>
    [TypeConverter(typeof(PressureTypeConverter))]
    [Serializable]
    public partial struct Pressure : IQuantity<PressureUnit>, IComparable<Pressure>, IEquatable<Pressure>, IXmlSerializable
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.PressureUnit.Pascals"/>
        /// </summary>
        public static readonly Pressure Zero = default(Pressure);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.PressureUnit.Pascals"/>.
        /// </summary>
        internal readonly double pascals;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Pressure"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.PressureUnit"/>.</param>
        public Pressure(double value, PressureUnit unit)
        {
            this.pascals = unit.ToSiUnit(value);
        }

        private Pressure(double pascals)
        {
            this.pascals = pascals;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.PressureUnit.Pascals"/>
        /// </summary>
        public double SiValue => this.pascals;

        /// <summary>
        /// Gets the <see cref="Gu.Units.PressureUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public PressureUnit SiUnit => PressureUnit.Pascals;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => PressureUnit.Pascals;

        /// <summary>
        /// Gets the quantity in pascals".
        /// </summary>
        public double Pascals => this.pascals;

        /// <summary>
        /// Gets the quantity in Bars
        /// </summary>
        public double Bars => this.pascals / 100000;

        /// <summary>
        /// Gets the quantity in Millibars
        /// </summary>
        public double Millibars => this.pascals / 100;

        /// <summary>
        /// Gets the quantity in Nanopascals
        /// </summary>
        public double Nanopascals => 1000000000 * this.pascals;

        /// <summary>
        /// Gets the quantity in Micropascals
        /// </summary>
        public double Micropascals => 1000000 * this.pascals;

        /// <summary>
        /// Gets the quantity in Millipascals
        /// </summary>
        public double Millipascals => 1000 * this.pascals;

        /// <summary>
        /// Gets the quantity in Kilopascals
        /// </summary>
        public double Kilopascals => this.pascals / 1000;

        /// <summary>
        /// Gets the quantity in Megapascals
        /// </summary>
        public double Megapascals => this.pascals / 1000000;

        /// <summary>
        /// Gets the quantity in Gigapascals
        /// </summary>
        public double Gigapascals => this.pascals / 1000000000;

        /// <summary>
        /// Gets the quantity in NewtonsPerSquareMillimetre
        /// </summary>
        public double NewtonsPerSquareMillimetre => this.pascals / 1000000;

        /// <summary>
        /// Gets the quantity in KilonewtonsPerSquareMillimetre
        /// </summary>
        public double KilonewtonsPerSquareMillimetre => this.pascals / 1000000000;

        /// <summary>
        /// Gets the quantity in NewtonsPerSquareMetre
        /// </summary>
        public double NewtonsPerSquareMetre => this.pascals;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the multiplication.</returns>
        public static Stiffness operator *(Pressure left, Length right)
        {
            return Stiffness.FromNewtonsPerMetre(left.pascals * right.metres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the multiplication.</returns>
        public static Force operator *(Pressure left, Area right)
        {
            return Force.FromNewtons(left.pascals * right.squareMetres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(Pressure left, Volume right)
        {
            return Energy.FromJoules(left.pascals * right.cubicMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificEnergy"/> that is the result from the division.</returns>
        public static SpecificEnergy operator /(Pressure left, Density right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.pascals / right.kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AreaDensity"/> that is the result from the division.</returns>
        public static AreaDensity operator /(Pressure left, Acceleration right)
        {
            return AreaDensity.FromKilogramsPerSquareMetre(left.pascals / right.metresPerSecondSquared);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Wavenumber"/> that is the result from the division.</returns>
        public static Wavenumber operator /(Pressure left, Stiffness right)
        {
            return Wavenumber.FromReciprocalMetres(left.pascals / right.newtonsPerMetre);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Power"/> that is the result from the multiplication.</returns>
        public static Power operator *(Pressure left, VolumetricFlow right)
        {
            return Power.FromWatts(left.pascals * right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Density"/> that is the result from the division.</returns>
        public static Density operator /(Pressure left, SpecificEnergy right)
        {
            return Density.FromKilogramsPerCubicMetre(left.pascals / right.joulesPerKilogram);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Wavenumber"/> that is the result from the multiplication.</returns>
        public static Wavenumber operator *(Pressure left, Flexibility right)
        {
            return Wavenumber.FromReciprocalMetres(left.pascals * right.metresPerNewton);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the division.</returns>
        public static Stiffness operator /(Pressure left, Wavenumber right)
        {
            return Stiffness.FromNewtonsPerMetre(left.pascals / right.reciprocalMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Acceleration"/> that is the result from the division.</returns>
        public static Acceleration operator /(Pressure left, AreaDensity right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.pascals / right.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificEnergy"/> that is the result from the multiplication.</returns>
        public static SpecificEnergy operator *(Pressure left, SpecificVolume right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.pascals * right.cubicMetresPerKilogram);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Pressure left, Pressure right)
        {
            return left.pascals / right.pascals;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Pressure"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Pressure"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Pressure"/>.</param>
        public static bool operator ==(Pressure left, Pressure right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Pressure"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Pressure"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Pressure"/>.</param>
        public static bool operator !=(Pressure left, Pressure right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Pressure"/> is less than another specified <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Pressure"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Pressure"/>.</param>
        public static bool operator <(Pressure left, Pressure right)
        {
            return left.pascals < right.pascals;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Pressure"/> is greater than another specified <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Pressure"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Pressure"/>.</param>
        public static bool operator >(Pressure left, Pressure right)
        {
            return left.pascals > right.pascals;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Pressure"/> is less than or equal to another specified <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Pressure"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Pressure"/>.</param>
        public static bool operator <=(Pressure left, Pressure right)
        {
            return left.pascals <= right.pascals;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Pressure"/> is greater than or equal to another specified <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Pressure"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Pressure"/>.</param>
        public static bool operator >=(Pressure left, Pressure right)
        {
            return left.pascals >= right.pascals;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Pressure"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Pressure"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Pressure"/> and returns the result.</returns>
        public static Pressure operator *(double left, Pressure right)
        {
            return new Pressure(left * right.pascals);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Pressure"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Pressure"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Pressure"/> with <paramref name="right"/> and returns the result.</returns>
        public static Pressure operator *(Pressure left, double right)
        {
            return new Pressure(left.pascals * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Pressure"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Pressure"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Pressure"/> by <paramref name="right"/> and returns the result.</returns>
        public static Pressure operator /(Pressure left, double right)
        {
            return new Pressure(left.pascals / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Pressure"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Pressure"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Pressure"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Pressure"/>.</param>
        public static Pressure operator +(Pressure left, Pressure right)
        {
            return new Pressure(left.pascals + right.pascals);
        }

        /// <summary>
        /// Subtracts an Pressure from another Pressure and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Pressure"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Pressure"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Pressure"/> (the subtrahend).</param>
        public static Pressure operator -(Pressure left, Pressure right)
        {
            return new Pressure(left.pascals - right.pascals);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Pressure"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Pressure"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="pressure">An instance of <see cref="Gu.Units.Pressure"/></param>
        public static Pressure operator -(Pressure pressure)
        {
            return new Pressure(-1 * pressure.pascals);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="pressure"/>.
        /// </returns>
        /// <param name="pressure">An instance of <see cref="Gu.Units.Pressure"/></param>
        public static Pressure operator +(Pressure pressure)
        {
            return pressure;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Pressure"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Pressure"/></param>
        /// <returns>The <see cref="Gu.Units.Pressure"/> parsed from <paramref name="text"/></returns>
        public static Pressure Parse(string text)
        {
            return QuantityParser.Parse<PressureUnit, Pressure>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Pressure"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Pressure"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Pressure"/> parsed from <paramref name="text"/></returns>
        public static Pressure Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<PressureUnit, Pressure>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Pressure"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Pressure"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Pressure"/> parsed from <paramref name="text"/></returns>
        public static Pressure Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<PressureUnit, Pressure>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Pressure"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Pressure"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Pressure"/> parsed from <paramref name="text"/></returns>
        public static Pressure Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<PressureUnit, Pressure>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Pressure"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Pressure"/></param>
        /// <param name="result">The parsed <see cref="Pressure"/></param>
        /// <returns>True if an instance of <see cref="Pressure"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Pressure result)
        {
            return QuantityParser.TryParse<PressureUnit, Pressure>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Pressure"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Pressure"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Pressure"/></param>
        /// <returns>True if an instance of <see cref="Pressure"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Pressure result)
        {
            return QuantityParser.TryParse<PressureUnit, Pressure>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Pressure"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Pressure"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Pressure"/></param>
        /// <returns>True if an instance of <see cref="Pressure"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Pressure result)
        {
            return QuantityParser.TryParse<PressureUnit, Pressure>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Pressure"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Pressure"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Pressure"/></param>
        /// <returns>True if an instance of <see cref="Pressure"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Pressure result)
        {
            return QuantityParser.TryParse<PressureUnit, Pressure>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Pressure"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure ReadFrom(XmlReader reader)
        {
            var v = default(Pressure);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure From(double value, PressureUnit unit)
        {
            return new Pressure(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="pascals">The value in <see cref="Gu.Units.PressureUnit.Pascals"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure FromPascals(double pascals)
        {
            return new Pressure(pascals);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="bars">The value in bar.</param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure FromBars(double bars)
        {
            return new Pressure(100000 * bars);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="millibars">The value in mbar.</param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure FromMillibars(double millibars)
        {
            return new Pressure(100 * millibars);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="nanopascals">The value in nPa.</param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure FromNanopascals(double nanopascals)
        {
            return new Pressure(nanopascals / 1000000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="micropascals">The value in μPa.</param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure FromMicropascals(double micropascals)
        {
            return new Pressure(micropascals / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="millipascals">The value in mPa.</param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure FromMillipascals(double millipascals)
        {
            return new Pressure(millipascals / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="kilopascals">The value in kPa.</param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure FromKilopascals(double kilopascals)
        {
            return new Pressure(1000 * kilopascals);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="megapascals">The value in MPa.</param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure FromMegapascals(double megapascals)
        {
            return new Pressure(1000000 * megapascals);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="gigapascals">The value in GPa.</param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure FromGigapascals(double gigapascals)
        {
            return new Pressure(1000000000 * gigapascals);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="newtonsPerSquareMillimetre">The value in N⋅mm⁻².</param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure FromNewtonsPerSquareMillimetre(double newtonsPerSquareMillimetre)
        {
            return new Pressure(1000000 * newtonsPerSquareMillimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="kilonewtonsPerSquareMillimetre">The value in kN⋅mm⁻².</param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure FromKilonewtonsPerSquareMillimetre(double kilonewtonsPerSquareMillimetre)
        {
            return new Pressure(1000000000 * kilonewtonsPerSquareMillimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Pressure"/>.
        /// </summary>
        /// <param name="newtonsPerSquareMetre">The value in N/m².</param>
        /// <returns>An instance of <see cref="Gu.Units.Pressure"/></returns>
        public static Pressure FromNewtonsPerSquareMetre(double newtonsPerSquareMetre)
        {
            return new Pressure(newtonsPerSquareMetre);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(PressureUnit unit)
        {
            return unit.FromSiUnit(this.pascals);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Pressure"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Pressure"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 Pa\"</param>
        /// <returns>The string representation of the <see cref="Pressure"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 Pa\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Pressure"/></returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex Pa</param>
        /// <returns>The string representation of the <see cref="Pressure"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex Pa</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="Pressure"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(PressureUnit unit)
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(PressureUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(PressureUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(PressureUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, PressureUnit unit)
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, PressureUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, PressureUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, PressureUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<PressureUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Pressure"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Pressure"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Pressure"/> object to compare to this instance.</param>
        public int CompareTo(Pressure quantity)
        {
            return this.pascals.CompareTo(quantity.pascals);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Pressure"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Pressure as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Pressure"/> object to compare with this instance.</param>
        public bool Equals(Pressure other)
        {
            return this.pascals.Equals(other.pascals);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Pressure"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Pressure as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Pressure"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Pressure other, Pressure tolerance)
        {
            Ensure.GreaterThan(tolerance.pascals, 0, nameof(tolerance));
            return Math.Abs(this.pascals - other.pascals) < tolerance.pascals;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Pressure"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Pressure"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is Pressure other && this.Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.pascals.GetHashCode();
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
            reader.MoveToContent();
            var attribute = reader.GetAttribute("Value");
            if (attribute is null)
            {
                throw new XmlException($"Could not find attribute named: Value");
            }

            this  = new Pressure(XmlConvert.ToDouble(attribute), PressureUnit.Pascals);
            reader.ReadStartElement();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartAttribute("Value");
            writer.WriteValue(this.pascals);
            writer.WriteEndAttribute();
        }

        internal string ToString(QuantityFormat<PressureUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
