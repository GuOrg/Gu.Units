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
    /// A type for the quantity <see cref="Gu.Units.KinematicViscosity"/>.
    /// </summary>
    [TypeConverter(typeof(KinematicViscosityTypeConverter))]
    [Serializable]
    public partial struct KinematicViscosity : IQuantity<KinematicViscosityUnit>, IComparable<KinematicViscosity>, IEquatable<KinematicViscosity>, IXmlSerializable
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.KinematicViscosityUnit.SquareMetresPerSecond"/>
        /// </summary>
        public static readonly KinematicViscosity Zero = default(KinematicViscosity);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.KinematicViscosityUnit.SquareMetresPerSecond"/>.
        /// </summary>
        internal readonly double squareMetresPerSecond;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.KinematicViscosity"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.KinematicViscosityUnit"/>.</param>
        public KinematicViscosity(double value, KinematicViscosityUnit unit)
        {
            this.squareMetresPerSecond = unit.ToSiUnit(value);
        }

        private KinematicViscosity(double squareMetresPerSecond)
        {
            this.squareMetresPerSecond = squareMetresPerSecond;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.KinematicViscosityUnit.SquareMetresPerSecond"/>
        /// </summary>
        public double SiValue => this.squareMetresPerSecond;

        /// <summary>
        /// Gets the <see cref="Gu.Units.KinematicViscosityUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public KinematicViscosityUnit SiUnit => KinematicViscosityUnit.SquareMetresPerSecond;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => KinematicViscosityUnit.SquareMetresPerSecond;

        /// <summary>
        /// Gets the quantity in squareMetresPerSecond".
        /// </summary>
        public double SquareMetresPerSecond => this.squareMetresPerSecond;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="VolumetricFlow"/> that is the result from the multiplication.</returns>
        public static VolumetricFlow operator *(KinematicViscosity left, Length right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.squareMetresPerSecond * right.metres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the division.</returns>
        public static Speed operator /(KinematicViscosity left, Length right)
        {
            return Speed.FromMetresPerSecond(left.squareMetresPerSecond / right.metres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Area"/> that is the result from the multiplication.</returns>
        public static Area operator *(KinematicViscosity left, Time right)
        {
            return Area.FromSquareMetres(left.squareMetresPerSecond * right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificEnergy"/> that is the result from the division.</returns>
        public static SpecificEnergy operator /(KinematicViscosity left, Time right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.squareMetresPerSecond / right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Frequency"/> that is the result from the division.</returns>
        public static Frequency operator /(KinematicViscosity left, Area right)
        {
            return Frequency.FromHertz(left.squareMetresPerSecond / right.squareMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Flexibility"/> that is the result from the division.</returns>
        public static Flexibility operator /(KinematicViscosity left, Power right)
        {
            return Flexibility.FromMetresPerNewton(left.squareMetresPerSecond / right.watts);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the division.</returns>
        public static Length operator /(KinematicViscosity left, Speed right)
        {
            return Length.FromMetres(left.squareMetresPerSecond / right.metresPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificEnergy"/> that is the result from the multiplication.</returns>
        public static SpecificEnergy operator *(KinematicViscosity left, Frequency right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.squareMetresPerSecond * right.hertz);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Area"/> that is the result from the division.</returns>
        public static Area operator /(KinematicViscosity left, Frequency right)
        {
            return Area.FromSquareMetres(left.squareMetresPerSecond / right.hertz);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Power"/> that is the result from the multiplication.</returns>
        public static Power operator *(KinematicViscosity left, Stiffness right)
        {
            return Power.FromWatts(left.squareMetresPerSecond * right.newtonsPerMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Wavenumber"/> that is the result from the division.</returns>
        public static Wavenumber operator /(KinematicViscosity left, VolumetricFlow right)
        {
            return Wavenumber.FromReciprocalMetres(left.squareMetresPerSecond / right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the division.</returns>
        public static Time operator /(KinematicViscosity left, SpecificEnergy right)
        {
            return Time.FromSeconds(left.squareMetresPerSecond / right.joulesPerKilogram);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Power"/> that is the result from the division.</returns>
        public static Power operator /(KinematicViscosity left, Flexibility right)
        {
            return Power.FromWatts(left.squareMetresPerSecond / right.metresPerNewton);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Voltage"/> that is the result from the multiplication.</returns>
        public static Voltage operator *(KinematicViscosity left, MagneticFieldStrength right)
        {
            return Voltage.FromVolts(left.squareMetresPerSecond * right.teslas);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the multiplication.</returns>
        public static Speed operator *(KinematicViscosity left, Wavenumber right)
        {
            return Speed.FromMetresPerSecond(left.squareMetresPerSecond * right.reciprocalMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="VolumetricFlow"/> that is the result from the division.</returns>
        public static VolumetricFlow operator /(KinematicViscosity left, Wavenumber right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.squareMetresPerSecond / right.reciprocalMetres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the multiplication.</returns>
        public static MassFlow operator *(KinematicViscosity left, AreaDensity right)
        {
            return MassFlow.FromKilogramsPerSecond(left.squareMetresPerSecond * right.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(KinematicViscosity left, MassFlow right)
        {
            return Energy.FromJoules(left.squareMetresPerSecond * right.kilogramsPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(KinematicViscosity left, KinematicViscosity right)
        {
            return left.squareMetresPerSecond / right.squareMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.KinematicViscosity"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        public static bool operator ==(KinematicViscosity left, KinematicViscosity right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.KinematicViscosity"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        public static bool operator !=(KinematicViscosity left, KinematicViscosity right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.KinematicViscosity"/> is less than another specified <see cref="Gu.Units.KinematicViscosity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        public static bool operator <(KinematicViscosity left, KinematicViscosity right)
        {
            return left.squareMetresPerSecond < right.squareMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.KinematicViscosity"/> is greater than another specified <see cref="Gu.Units.KinematicViscosity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        public static bool operator >(KinematicViscosity left, KinematicViscosity right)
        {
            return left.squareMetresPerSecond > right.squareMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.KinematicViscosity"/> is less than or equal to another specified <see cref="Gu.Units.KinematicViscosity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        public static bool operator <=(KinematicViscosity left, KinematicViscosity right)
        {
            return left.squareMetresPerSecond <= right.squareMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.KinematicViscosity"/> is greater than or equal to another specified <see cref="Gu.Units.KinematicViscosity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        public static bool operator >=(KinematicViscosity left, KinematicViscosity right)
        {
            return left.squareMetresPerSecond >= right.squareMetresPerSecond;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.KinematicViscosity"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.KinematicViscosity"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.KinematicViscosity"/> and returns the result.</returns>
        public static KinematicViscosity operator *(double left, KinematicViscosity right)
        {
            return new KinematicViscosity(left * right.squareMetresPerSecond);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.KinematicViscosity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.KinematicViscosity"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.KinematicViscosity"/> with <paramref name="right"/> and returns the result.</returns>
        public static KinematicViscosity operator *(KinematicViscosity left, double right)
        {
            return new KinematicViscosity(left.squareMetresPerSecond * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.KinematicViscosity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.KinematicViscosity"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.KinematicViscosity"/> by <paramref name="right"/> and returns the result.</returns>
        public static KinematicViscosity operator /(KinematicViscosity left, double right)
        {
            return new KinematicViscosity(left.squareMetresPerSecond / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.KinematicViscosity"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.KinematicViscosity"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.KinematicViscosity"/>.</param>
        public static KinematicViscosity operator +(KinematicViscosity left, KinematicViscosity right)
        {
            return new KinematicViscosity(left.squareMetresPerSecond + right.squareMetresPerSecond);
        }

        /// <summary>
        /// Subtracts an KinematicViscosity from another KinematicViscosity and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.KinematicViscosity"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.KinematicViscosity"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.KinematicViscosity"/> (the subtrahend).</param>
        public static KinematicViscosity operator -(KinematicViscosity left, KinematicViscosity right)
        {
            return new KinematicViscosity(left.squareMetresPerSecond - right.squareMetresPerSecond);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.KinematicViscosity"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.KinematicViscosity"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="kinematicViscosity">An instance of <see cref="Gu.Units.KinematicViscosity"/></param>
        public static KinematicViscosity operator -(KinematicViscosity kinematicViscosity)
        {
            return new KinematicViscosity(-1 * kinematicViscosity.squareMetresPerSecond);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.KinematicViscosity"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="kinematicViscosity"/>.
        /// </returns>
        /// <param name="kinematicViscosity">An instance of <see cref="Gu.Units.KinematicViscosity"/></param>
        public static KinematicViscosity operator +(KinematicViscosity kinematicViscosity)
        {
            return kinematicViscosity;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.KinematicViscosity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.KinematicViscosity"/></param>
        /// <returns>The <see cref="Gu.Units.KinematicViscosity"/> parsed from <paramref name="text"/></returns>
        public static KinematicViscosity Parse(string text)
        {
            return QuantityParser.Parse<KinematicViscosityUnit, KinematicViscosity>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.KinematicViscosity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.KinematicViscosity"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.KinematicViscosity"/> parsed from <paramref name="text"/></returns>
        public static KinematicViscosity Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<KinematicViscosityUnit, KinematicViscosity>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.KinematicViscosity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.KinematicViscosity"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.KinematicViscosity"/> parsed from <paramref name="text"/></returns>
        public static KinematicViscosity Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<KinematicViscosityUnit, KinematicViscosity>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.KinematicViscosity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.KinematicViscosity"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.KinematicViscosity"/> parsed from <paramref name="text"/></returns>
        public static KinematicViscosity Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<KinematicViscosityUnit, KinematicViscosity>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.KinematicViscosity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.KinematicViscosity"/></param>
        /// <param name="result">The parsed <see cref="KinematicViscosity"/></param>
        /// <returns>True if an instance of <see cref="KinematicViscosity"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out KinematicViscosity result)
        {
            return QuantityParser.TryParse<KinematicViscosityUnit, KinematicViscosity>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.KinematicViscosity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.KinematicViscosity"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="KinematicViscosity"/></param>
        /// <returns>True if an instance of <see cref="KinematicViscosity"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out KinematicViscosity result)
        {
            return QuantityParser.TryParse<KinematicViscosityUnit, KinematicViscosity>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.KinematicViscosity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.KinematicViscosity"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="KinematicViscosity"/></param>
        /// <returns>True if an instance of <see cref="KinematicViscosity"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out KinematicViscosity result)
        {
            return QuantityParser.TryParse<KinematicViscosityUnit, KinematicViscosity>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.KinematicViscosity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.KinematicViscosity"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="KinematicViscosity"/></param>
        /// <returns>True if an instance of <see cref="KinematicViscosity"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out KinematicViscosity result)
        {
            return QuantityParser.TryParse<KinematicViscosityUnit, KinematicViscosity>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.KinematicViscosity"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.KinematicViscosity"/></returns>
        public static KinematicViscosity ReadFrom(XmlReader reader)
        {
            var v = default(KinematicViscosity);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.KinematicViscosity"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.KinematicViscosity"/></returns>
        public static KinematicViscosity From(double value, KinematicViscosityUnit unit)
        {
            return new KinematicViscosity(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.KinematicViscosity"/>.
        /// </summary>
        /// <param name="squareMetresPerSecond">The value in <see cref="Gu.Units.KinematicViscosityUnit.SquareMetresPerSecond"/></param>
        /// <returns>An instance of <see cref="Gu.Units.KinematicViscosity"/></returns>
        public static KinematicViscosity FromSquareMetresPerSecond(double squareMetresPerSecond)
        {
            return new KinematicViscosity(squareMetresPerSecond);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(KinematicViscosityUnit unit)
        {
            return unit.FromSiUnit(this.squareMetresPerSecond);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="KinematicViscosity"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="KinematicViscosity"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m²/s\"</param>
        /// <returns>The string representation of the <see cref="KinematicViscosity"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m²/s\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="KinematicViscosity"/></returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m²/s</param>
        /// <returns>The string representation of the <see cref="KinematicViscosity"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m²/s</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="KinematicViscosity"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(KinematicViscosityUnit unit)
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(KinematicViscosityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(KinematicViscosityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(KinematicViscosityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, KinematicViscosityUnit unit)
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, KinematicViscosityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, KinematicViscosityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, KinematicViscosityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<KinematicViscosityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.KinematicViscosity"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.KinematicViscosity"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.KinematicViscosity"/> object to compare to this instance.</param>
        public int CompareTo(KinematicViscosity quantity)
        {
            return this.squareMetresPerSecond.CompareTo(quantity.squareMetresPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.KinematicViscosity"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same KinematicViscosity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.KinematicViscosity"/> object to compare with this instance.</param>
        public bool Equals(KinematicViscosity other)
        {
            return this.squareMetresPerSecond.Equals(other.squareMetresPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.KinematicViscosity"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same KinematicViscosity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.KinematicViscosity"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(KinematicViscosity other, KinematicViscosity tolerance)
        {
            Ensure.GreaterThan(tolerance.squareMetresPerSecond, 0, nameof(tolerance));
            return Math.Abs(this.squareMetresPerSecond - other.squareMetresPerSecond) < tolerance.squareMetresPerSecond;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.KinematicViscosity"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.KinematicViscosity"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is KinematicViscosity other && this.Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.squareMetresPerSecond.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "squareMetresPerSecond", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.squareMetresPerSecond);
        }

        internal string ToString(QuantityFormat<KinematicViscosityUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
