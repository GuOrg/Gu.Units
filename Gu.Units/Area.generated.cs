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
    /// A type for the quantity <see cref="Gu.Units.Area"/>.
    /// </summary>
    [TypeConverter(typeof(AreaTypeConverter))]
    [Serializable]
    public partial struct Area : IQuantity<AreaUnit>, IComparable<Area>, IEquatable<Area>, IXmlSerializable
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.AreaUnit.SquareMetres"/>
        /// </summary>
        public static readonly Area Zero = default(Area);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.AreaUnit.SquareMetres"/>.
        /// </summary>
        internal readonly double squareMetres;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Area"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.AreaUnit"/>.</param>
        public Area(double value, AreaUnit unit)
        {
            this.squareMetres = unit.ToSiUnit(value);
        }

        private Area(double squareMetres)
        {
            this.squareMetres = squareMetres;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.AreaUnit.SquareMetres"/>
        /// </summary>
        public double SiValue => this.squareMetres;

        /// <summary>
        /// Gets the <see cref="Gu.Units.AreaUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public AreaUnit SiUnit => AreaUnit.SquareMetres;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => AreaUnit.SquareMetres;

        /// <summary>
        /// Gets the quantity in squareMetres".
        /// </summary>
        public double SquareMetres => this.squareMetres;

        /// <summary>
        /// Gets the quantity in Hectares
        /// </summary>
        public double Hectares => this.squareMetres / 10000;

        /// <summary>
        /// Gets the quantity in SquareMillimetres
        /// </summary>
        public double SquareMillimetres => 1000000 * this.squareMetres;

        /// <summary>
        /// Gets the quantity in SquareCentimetres
        /// </summary>
        public double SquareCentimetres => 10000 * this.squareMetres;

        /// <summary>
        /// Gets the quantity in SquareDecimetres
        /// </summary>
        public double SquareDecimetres => 100 * this.squareMetres;

        /// <summary>
        /// Gets the quantity in SquareKilometres
        /// </summary>
        public double SquareKilometres => this.squareMetres / 1000000;

        /// <summary>
        /// Gets the quantity in SquareMile
        /// </summary>
        public double SquareMile => this.squareMetres / 2589988.110336;

        /// <summary>
        /// Gets the quantity in SquareYards
        /// </summary>
        public double SquareYards => this.squareMetres / 0.83612736;

        /// <summary>
        /// Gets the quantity in SquareInches
        /// </summary>
        public double SquareInches => this.squareMetres / 0.00064516;

        /// <summary>
        /// Gets the quantity in SquareFeet
        /// </summary>
        public double SquareFeet => this.squareMetres / 0.09290304;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Volume"/> that is the result from the multiplication.</returns>
        public static Volume operator *(Area left, Length right)
        {
            return Volume.FromCubicMetres(left.squareMetres * right.metres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the division.</returns>
        public static Length operator /(Area left, Length right)
        {
            return Length.FromMetres(left.squareMetres / right.metres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="KinematicViscosity"/> that is the result from the division.</returns>
        public static KinematicViscosity operator /(Area left, Time right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.squareMetres / right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Wavenumber"/> that is the result from the division.</returns>
        public static Wavenumber operator /(Area left, Volume right)
        {
            return Wavenumber.FromReciprocalMetres(left.squareMetres / right.cubicMetres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the multiplication.</returns>
        public static Force operator *(Area left, Pressure right)
        {
            return Force.FromNewtons(left.squareMetres * right.pascals);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Flexibility"/> that is the result from the division.</returns>
        public static Flexibility operator /(Area left, Energy right)
        {
            return Flexibility.FromMetresPerNewton(left.squareMetres / right.joules);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="VolumetricFlow"/> that is the result from the multiplication.</returns>
        public static VolumetricFlow operator *(Area left, Speed right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.squareMetres * right.metresPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="KinematicViscosity"/> that is the result from the multiplication.</returns>
        public static KinematicViscosity operator *(Area left, Frequency right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.squareMetres * right.hertz);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(Area left, Stiffness right)
        {
            return Energy.FromJoules(left.squareMetres * right.newtonsPerMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the division.</returns>
        public static Energy operator /(Area left, Flexibility right)
        {
            return Energy.FromJoules(left.squareMetres / right.metresPerNewton);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="LuminousFlux"/> that is the result from the multiplication.</returns>
        public static LuminousFlux operator *(Area left, Illuminance right)
        {
            return LuminousFlux.FromLumens(left.squareMetres * right.lux);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MagneticFlux"/> that is the result from the multiplication.</returns>
        public static MagneticFlux operator *(Area left, MagneticFieldStrength right)
        {
            return MagneticFlux.FromWebers(left.squareMetres * right.teslas);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the multiplication.</returns>
        public static Length operator *(Area left, Wavenumber right)
        {
            return Length.FromMetres(left.squareMetres * right.reciprocalMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Volume"/> that is the result from the division.</returns>
        public static Volume operator /(Area left, Wavenumber right)
        {
            return Volume.FromCubicMetres(left.squareMetres / right.reciprocalMetres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Mass"/> that is the result from the multiplication.</returns>
        public static Mass operator *(Area left, AreaDensity right)
        {
            return Mass.FromKilograms(left.squareMetres * right.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the division.</returns>
        public static Time operator /(Area left, KinematicViscosity right)
        {
            return Time.FromSeconds(left.squareMetres / right.squareMetresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Area left, Area right)
        {
            return left.squareMetres / right.squareMetres;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Area"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Area"/>.</param>
        public static bool operator ==(Area left, Area right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Area"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Area"/>.</param>
        public static bool operator !=(Area left, Area right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Area"/> is less than another specified <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Area"/>.</param>
        public static bool operator <(Area left, Area right)
        {
            return left.squareMetres < right.squareMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Area"/> is greater than another specified <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Area"/>.</param>
        public static bool operator >(Area left, Area right)
        {
            return left.squareMetres > right.squareMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Area"/> is less than or equal to another specified <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Area"/>.</param>
        public static bool operator <=(Area left, Area right)
        {
            return left.squareMetres <= right.squareMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Area"/> is greater than or equal to another specified <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Area"/>.</param>
        public static bool operator >=(Area left, Area right)
        {
            return left.squareMetres >= right.squareMetres;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Area"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Area"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Area"/> and returns the result.</returns>
        public static Area operator *(double left, Area right)
        {
            return new Area(left * right.squareMetres);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Area"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Area"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Area"/> with <paramref name="right"/> and returns the result.</returns>
        public static Area operator *(Area left, double right)
        {
            return new Area(left.squareMetres * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Area"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Area"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Area"/> by <paramref name="right"/> and returns the result.</returns>
        public static Area operator /(Area left, double right)
        {
            return new Area(left.squareMetres / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Area"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Area"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Area"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Area"/>.</param>
        public static Area operator +(Area left, Area right)
        {
            return new Area(left.squareMetres + right.squareMetres);
        }

        /// <summary>
        /// Subtracts an Area from another Area and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Area"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Area"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Area"/> (the subtrahend).</param>
        public static Area operator -(Area left, Area right)
        {
            return new Area(left.squareMetres - right.squareMetres);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Area"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Area"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="area">An instance of <see cref="Gu.Units.Area"/></param>
        public static Area operator -(Area area)
        {
            return new Area(-1 * area.squareMetres);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="area"/>.
        /// </returns>
        /// <param name="area">An instance of <see cref="Gu.Units.Area"/></param>
        public static Area operator +(Area area)
        {
            return area;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Area"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Area"/></param>
        /// <returns>The <see cref="Gu.Units.Area"/> parsed from <paramref name="text"/></returns>
        public static Area Parse(string text)
        {
            return QuantityParser.Parse<AreaUnit, Area>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Area"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Area"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Area"/> parsed from <paramref name="text"/></returns>
        public static Area Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<AreaUnit, Area>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Area"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Area"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Area"/> parsed from <paramref name="text"/></returns>
        public static Area Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<AreaUnit, Area>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Area"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Area"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Area"/> parsed from <paramref name="text"/></returns>
        public static Area Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<AreaUnit, Area>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Area"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Area"/></param>
        /// <param name="result">The parsed <see cref="Area"/></param>
        /// <returns>True if an instance of <see cref="Area"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Area result)
        {
            return QuantityParser.TryParse<AreaUnit, Area>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Area"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Area"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Area"/></param>
        /// <returns>True if an instance of <see cref="Area"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Area result)
        {
            return QuantityParser.TryParse<AreaUnit, Area>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Area"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Area"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Area"/></param>
        /// <returns>True if an instance of <see cref="Area"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Area result)
        {
            return QuantityParser.TryParse<AreaUnit, Area>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Area"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Area"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Area"/></param>
        /// <returns>True if an instance of <see cref="Area"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Area result)
        {
            return QuantityParser.TryParse<AreaUnit, Area>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Area"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Area"/></returns>
        public static Area ReadFrom(XmlReader reader)
        {
            var v = default(Area);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Area"/></returns>
        public static Area From(double value, AreaUnit unit)
        {
            return new Area(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareMetres">The value in <see cref="Gu.Units.AreaUnit.SquareMetres"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Area"/></returns>
        public static Area FromSquareMetres(double squareMetres)
        {
            return new Area(squareMetres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="hectares">The value in ha.</param>
        /// <returns>An instance of <see cref="Gu.Units.Area"/></returns>
        public static Area FromHectares(double hectares)
        {
            return new Area(10000 * hectares);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareMillimetres">The value in mm².</param>
        /// <returns>An instance of <see cref="Gu.Units.Area"/></returns>
        public static Area FromSquareMillimetres(double squareMillimetres)
        {
            return new Area(squareMillimetres / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareCentimetres">The value in cm².</param>
        /// <returns>An instance of <see cref="Gu.Units.Area"/></returns>
        public static Area FromSquareCentimetres(double squareCentimetres)
        {
            return new Area(squareCentimetres / 10000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareDecimetres">The value in dm².</param>
        /// <returns>An instance of <see cref="Gu.Units.Area"/></returns>
        public static Area FromSquareDecimetres(double squareDecimetres)
        {
            return new Area(squareDecimetres / 100);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareKilometres">The value in km².</param>
        /// <returns>An instance of <see cref="Gu.Units.Area"/></returns>
        public static Area FromSquareKilometres(double squareKilometres)
        {
            return new Area(1000000 * squareKilometres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareMile">The value in mi².</param>
        /// <returns>An instance of <see cref="Gu.Units.Area"/></returns>
        public static Area FromSquareMile(double squareMile)
        {
            return new Area(2589988.110336 * squareMile);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareYards">The value in yd².</param>
        /// <returns>An instance of <see cref="Gu.Units.Area"/></returns>
        public static Area FromSquareYards(double squareYards)
        {
            return new Area(0.83612736 * squareYards);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareInches">The value in in².</param>
        /// <returns>An instance of <see cref="Gu.Units.Area"/></returns>
        public static Area FromSquareInches(double squareInches)
        {
            return new Area(0.00064516 * squareInches);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Area"/>.
        /// </summary>
        /// <param name="squareFeet">The value in ft².</param>
        /// <returns>An instance of <see cref="Gu.Units.Area"/></returns>
        public static Area FromSquareFeet(double squareFeet)
        {
            return new Area(0.09290304 * squareFeet);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(AreaUnit unit)
        {
            return unit.FromSiUnit(this.squareMetres);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Area"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Area"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m²\"</param>
        /// <returns>The string representation of the <see cref="Area"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m²\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Area"/></returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m²</param>
        /// <returns>The string representation of the <see cref="Area"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m²</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="Area"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(AreaUnit unit)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(AreaUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(AreaUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(AreaUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, AreaUnit unit)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, AreaUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, AreaUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, AreaUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<AreaUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Area"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Area"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Area"/> object to compare to this instance.</param>
        public int CompareTo(Area quantity)
        {
            return this.squareMetres.CompareTo(quantity.squareMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Area"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Area as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Area"/> object to compare with this instance.</param>
        public bool Equals(Area other)
        {
            return this.squareMetres.Equals(other.squareMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Area"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Area as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Area"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Area other, Area tolerance)
        {
            Ensure.GreaterThan(tolerance.squareMetres, 0, nameof(tolerance));
            return Math.Abs(this.squareMetres - other.squareMetres) < tolerance.squareMetres;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Area"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Area"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is Area other && this.Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.squareMetres.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "squareMetres", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.squareMetres);
        }

        internal string ToString(QuantityFormat<AreaUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
