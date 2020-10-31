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
    /// A type for the quantity <see cref="Gu.Units.Stiffness"/>.
    /// </summary>
    [TypeConverter(typeof(StiffnessTypeConverter))]
    [Serializable]
    public partial struct Stiffness : IQuantity<StiffnessUnit>, IComparable<Stiffness>, IEquatable<Stiffness>, IXmlSerializable
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.StiffnessUnit.NewtonsPerMetre"/>
        /// </summary>
        public static readonly Stiffness Zero = default(Stiffness);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.StiffnessUnit.NewtonsPerMetre"/>.
        /// </summary>
        internal readonly double newtonsPerMetre;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Stiffness"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.StiffnessUnit"/>.</param>
        public Stiffness(double value, StiffnessUnit unit)
        {
            this.newtonsPerMetre = unit.ToSiUnit(value);
        }

        private Stiffness(double newtonsPerMetre)
        {
            this.newtonsPerMetre = newtonsPerMetre;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.StiffnessUnit.NewtonsPerMetre"/>
        /// </summary>
        public double SiValue => this.newtonsPerMetre;

        /// <summary>
        /// Gets the <see cref="Gu.Units.StiffnessUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public StiffnessUnit SiUnit => StiffnessUnit.NewtonsPerMetre;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => StiffnessUnit.NewtonsPerMetre;

        /// <summary>
        /// Gets the quantity in newtonsPerMetre".
        /// </summary>
        public double NewtonsPerMetre => this.newtonsPerMetre;

        /// <summary>
        /// Gets the quantity in NewtonsPerNanometre
        /// </summary>
        public double NewtonsPerNanometre => this.newtonsPerMetre / 1000000000;

        /// <summary>
        /// Gets the quantity in NewtonsPerMicrometre
        /// </summary>
        public double NewtonsPerMicrometre => this.newtonsPerMetre / 1000000;

        /// <summary>
        /// Gets the quantity in NewtonsPerMillimetre
        /// </summary>
        public double NewtonsPerMillimetre => this.newtonsPerMetre / 1000;

        /// <summary>
        /// Gets the quantity in KilonewtonsPerNanometre
        /// </summary>
        public double KilonewtonsPerNanometre => this.newtonsPerMetre / 1000000000000;

        /// <summary>
        /// Gets the quantity in KilonewtonsPerMicrometre
        /// </summary>
        public double KilonewtonsPerMicrometre => this.newtonsPerMetre / 1000000000;

        /// <summary>
        /// Gets the quantity in KilonewtonsPerMillimetre
        /// </summary>
        public double KilonewtonsPerMillimetre => this.newtonsPerMetre / 1000000;

        /// <summary>
        /// Gets the quantity in MeganewtonsPerNanometre
        /// </summary>
        public double MeganewtonsPerNanometre => this.newtonsPerMetre / 1000000000000000;

        /// <summary>
        /// Gets the quantity in MeganewtonsPerMicrometre
        /// </summary>
        public double MeganewtonsPerMicrometre => this.newtonsPerMetre / 1000000000000;

        /// <summary>
        /// Gets the quantity in MeganewtonsPerMillimetre
        /// </summary>
        public double MeganewtonsPerMillimetre => this.newtonsPerMetre / 1000000000;

        /// <summary>
        /// Gets the quantity in GiganewtonsPerMicrometre
        /// </summary>
        public double GiganewtonsPerMicrometre => this.newtonsPerMetre / 1000000000000000;

        /// <summary>
        /// Gets the quantity in GiganewtonsPerMillimetre
        /// </summary>
        public double GiganewtonsPerMillimetre => this.newtonsPerMetre / 1000000000000;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the multiplication.</returns>
        public static Force operator *(Stiffness left, Length right)
        {
            return Force.FromNewtons(left.newtonsPerMetre * right.metres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Pressure"/> that is the result from the division.</returns>
        public static Pressure operator /(Stiffness left, Length right)
        {
            return Pressure.FromPascals(left.newtonsPerMetre / right.metres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the multiplication.</returns>
        public static MassFlow operator *(Stiffness left, Time right)
        {
            return MassFlow.FromKilogramsPerSecond(left.newtonsPerMetre * right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MagneticFieldStrength"/> that is the result from the division.</returns>
        public static MagneticFieldStrength operator /(Stiffness left, Current right)
        {
            return MagneticFieldStrength.FromTeslas(left.newtonsPerMetre / right.amperes);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(Stiffness left, Area right)
        {
            return Energy.FromJoules(left.newtonsPerMetre * right.squareMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Wavenumber"/> that is the result from the division.</returns>
        public static Wavenumber operator /(Stiffness left, Force right)
        {
            return Wavenumber.FromReciprocalMetres(left.newtonsPerMetre / right.newtons);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the division.</returns>
        public static Length operator /(Stiffness left, Pressure right)
        {
            return Length.FromMetres(left.newtonsPerMetre / right.pascals);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the division.</returns>
        public static MassFlow operator /(Stiffness left, Frequency right)
        {
            return MassFlow.FromKilogramsPerSecond(left.newtonsPerMetre / right.hertz);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AreaDensity"/> that is the result from the division.</returns>
        public static AreaDensity operator /(Stiffness left, SpecificEnergy right)
        {
            return AreaDensity.FromKilogramsPerSquareMetre(left.newtonsPerMetre / right.joulesPerKilogram);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ForcePerUnitless"/> that is the result from the multiplication.</returns>
        public static ForcePerUnitless operator *(Stiffness left, LengthPerUnitless right)
        {
            return ForcePerUnitless.FromNewtonsPerUnitless(left.newtonsPerMetre * right.metresPerUnitless);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Current"/> that is the result from the division.</returns>
        public static Current operator /(Stiffness left, MagneticFieldStrength right)
        {
            return Current.FromAmperes(left.newtonsPerMetre / right.teslas);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Pressure"/> that is the result from the multiplication.</returns>
        public static Pressure operator *(Stiffness left, Wavenumber right)
        {
            return Pressure.FromPascals(left.newtonsPerMetre * right.reciprocalMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the division.</returns>
        public static Force operator /(Stiffness left, Wavenumber right)
        {
            return Force.FromNewtons(left.newtonsPerMetre / right.reciprocalMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificEnergy"/> that is the result from the division.</returns>
        public static SpecificEnergy operator /(Stiffness left, AreaDensity right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.newtonsPerMetre / right.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Frequency"/> that is the result from the division.</returns>
        public static Frequency operator /(Stiffness left, MassFlow right)
        {
            return Frequency.FromHertz(left.newtonsPerMetre / right.kilogramsPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Power"/> that is the result from the multiplication.</returns>
        public static Power operator *(Stiffness left, KinematicViscosity right)
        {
            return Power.FromWatts(left.newtonsPerMetre * right.squareMetresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The Flexibility that is the result from the division.</returns>
        public static Flexibility operator /(double left, Stiffness right)
        {
            return Flexibility.FromMetresPerNewton(left / right.newtonsPerMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre / right.newtonsPerMetre;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Stiffness"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static bool operator ==(Stiffness left, Stiffness right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Stiffness"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static bool operator !=(Stiffness left, Stiffness right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Stiffness"/> is less than another specified <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static bool operator <(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre < right.newtonsPerMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Stiffness"/> is greater than another specified <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static bool operator >(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre > right.newtonsPerMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Stiffness"/> is less than or equal to another specified <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static bool operator <=(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre <= right.newtonsPerMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Stiffness"/> is greater than or equal to another specified <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static bool operator >=(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre >= right.newtonsPerMetre;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Stiffness"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Stiffness"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Stiffness"/> and returns the result.</returns>
        public static Stiffness operator *(double left, Stiffness right)
        {
            return new Stiffness(left * right.newtonsPerMetre);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Stiffness"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Stiffness"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Stiffness"/> with <paramref name="right"/> and returns the result.</returns>
        public static Stiffness operator *(Stiffness left, double right)
        {
            return new Stiffness(left.newtonsPerMetre * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Stiffness"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Stiffness"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Stiffness"/> by <paramref name="right"/> and returns the result.</returns>
        public static Stiffness operator /(Stiffness left, double right)
        {
            return new Stiffness(left.newtonsPerMetre / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Stiffness"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Stiffness"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static Stiffness operator +(Stiffness left, Stiffness right)
        {
            return new Stiffness(left.newtonsPerMetre + right.newtonsPerMetre);
        }

        /// <summary>
        /// Subtracts an Stiffness from another Stiffness and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Stiffness"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Stiffness"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Stiffness"/> (the subtrahend).</param>
        public static Stiffness operator -(Stiffness left, Stiffness right)
        {
            return new Stiffness(left.newtonsPerMetre - right.newtonsPerMetre);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Stiffness"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Stiffness"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="stiffness">An instance of <see cref="Gu.Units.Stiffness"/></param>
        public static Stiffness operator -(Stiffness stiffness)
        {
            return new Stiffness(-1 * stiffness.newtonsPerMetre);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="stiffness"/>.
        /// </returns>
        /// <param name="stiffness">An instance of <see cref="Gu.Units.Stiffness"/></param>
        public static Stiffness operator +(Stiffness stiffness)
        {
            return stiffness;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <returns>The <see cref="Gu.Units.Stiffness"/> parsed from <paramref name="text"/></returns>
        public static Stiffness Parse(string text)
        {
            return QuantityParser.Parse<StiffnessUnit, Stiffness>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Stiffness"/> parsed from <paramref name="text"/></returns>
        public static Stiffness Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<StiffnessUnit, Stiffness>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Stiffness"/> parsed from <paramref name="text"/></returns>
        public static Stiffness Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<StiffnessUnit, Stiffness>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Stiffness"/> parsed from <paramref name="text"/></returns>
        public static Stiffness Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<StiffnessUnit, Stiffness>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <param name="result">The parsed <see cref="Stiffness"/></param>
        /// <returns>True if an instance of <see cref="Stiffness"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Stiffness result)
        {
            return QuantityParser.TryParse<StiffnessUnit, Stiffness>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Stiffness"/></param>
        /// <returns>True if an instance of <see cref="Stiffness"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Stiffness result)
        {
            return QuantityParser.TryParse<StiffnessUnit, Stiffness>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Stiffness"/></param>
        /// <returns>True if an instance of <see cref="Stiffness"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Stiffness result)
        {
            return QuantityParser.TryParse<StiffnessUnit, Stiffness>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Stiffness"/></param>
        /// <returns>True if an instance of <see cref="Stiffness"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Stiffness result)
        {
            return QuantityParser.TryParse<StiffnessUnit, Stiffness>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Stiffness"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness ReadFrom(XmlReader reader)
        {
            var v = default(Stiffness);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness From(double value, StiffnessUnit unit)
        {
            return new Stiffness(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="newtonsPerMetre">The value in <see cref="Gu.Units.StiffnessUnit.NewtonsPerMetre"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness FromNewtonsPerMetre(double newtonsPerMetre)
        {
            return new Stiffness(newtonsPerMetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="newtonsPerNanometre">The value in N/nm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness FromNewtonsPerNanometre(double newtonsPerNanometre)
        {
            return new Stiffness(1000000000 * newtonsPerNanometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="newtonsPerMicrometre">The value in N/μm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness FromNewtonsPerMicrometre(double newtonsPerMicrometre)
        {
            return new Stiffness(1000000 * newtonsPerMicrometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="newtonsPerMillimetre">The value in N/mm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness FromNewtonsPerMillimetre(double newtonsPerMillimetre)
        {
            return new Stiffness(1000 * newtonsPerMillimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="kilonewtonsPerNanometre">The value in kN/nm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness FromKilonewtonsPerNanometre(double kilonewtonsPerNanometre)
        {
            return new Stiffness(1000000000000 * kilonewtonsPerNanometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="kilonewtonsPerMicrometre">The value in kN/μm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness FromKilonewtonsPerMicrometre(double kilonewtonsPerMicrometre)
        {
            return new Stiffness(1000000000 * kilonewtonsPerMicrometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="kilonewtonsPerMillimetre">The value in kN/mm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness FromKilonewtonsPerMillimetre(double kilonewtonsPerMillimetre)
        {
            return new Stiffness(1000000 * kilonewtonsPerMillimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="meganewtonsPerNanometre">The value in MN/nm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness FromMeganewtonsPerNanometre(double meganewtonsPerNanometre)
        {
            return new Stiffness(1000000000000000 * meganewtonsPerNanometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="meganewtonsPerMicrometre">The value in MN/μm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness FromMeganewtonsPerMicrometre(double meganewtonsPerMicrometre)
        {
            return new Stiffness(1000000000000 * meganewtonsPerMicrometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="meganewtonsPerMillimetre">The value in MN/mm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness FromMeganewtonsPerMillimetre(double meganewtonsPerMillimetre)
        {
            return new Stiffness(1000000000 * meganewtonsPerMillimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="giganewtonsPerMicrometre">The value in GN/μm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness FromGiganewtonsPerMicrometre(double giganewtonsPerMicrometre)
        {
            return new Stiffness(1000000000000000 * giganewtonsPerMicrometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="giganewtonsPerMillimetre">The value in GN/mm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness FromGiganewtonsPerMillimetre(double giganewtonsPerMillimetre)
        {
            return new Stiffness(1000000000000 * giganewtonsPerMillimetre);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(StiffnessUnit unit)
        {
            return unit.FromSiUnit(this.newtonsPerMetre);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Stiffness"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Stiffness"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N/m\"</param>
        /// <returns>The string representation of the <see cref="Stiffness"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N/m\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Stiffness"/></returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex N/m</param>
        /// <returns>The string representation of the <see cref="Stiffness"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex N/m</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="Stiffness"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(StiffnessUnit unit)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(StiffnessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(StiffnessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(StiffnessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, StiffnessUnit unit)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, StiffnessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, StiffnessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, StiffnessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Stiffness"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Stiffness"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Stiffness"/> object to compare to this instance.</param>
        public int CompareTo(Stiffness quantity)
        {
            return this.newtonsPerMetre.CompareTo(quantity.newtonsPerMetre);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Stiffness"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Stiffness as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Stiffness"/> object to compare with this instance.</param>
        public bool Equals(Stiffness other)
        {
            return this.newtonsPerMetre.Equals(other.newtonsPerMetre);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Stiffness"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Stiffness as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Stiffness"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Stiffness other, Stiffness tolerance)
        {
            Ensure.GreaterThan(tolerance.newtonsPerMetre, 0, nameof(tolerance));
            return Math.Abs(this.newtonsPerMetre - other.newtonsPerMetre) < tolerance.newtonsPerMetre;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Stiffness"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Stiffness"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is Stiffness other && this.Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.newtonsPerMetre.GetHashCode();
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

            this  = new Stiffness(XmlConvert.ToDouble(attribute), StiffnessUnit.NewtonsPerMetre);
            reader.ReadStartElement();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartAttribute("Value");
            writer.WriteValue(this.newtonsPerMetre);
            writer.WriteEndAttribute();
        }

        internal string ToString(QuantityFormat<StiffnessUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
