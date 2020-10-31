#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Energy"/>.
    /// </summary>
    [TypeConverter(typeof(EnergyTypeConverter))]
    [Serializable]
    public partial struct Energy : IQuantity<EnergyUnit>, IComparable<Energy>, IEquatable<Energy>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.EnergyUnit.Joules"/>
        /// </summary>
        public static readonly Energy Zero = default(Energy);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.EnergyUnit.Joules"/>.
        /// </summary>
        internal readonly double joules;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Energy"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.EnergyUnit"/>.</param>
        public Energy(double value, EnergyUnit unit)
        {
            this.joules = unit.ToSiUnit(value);
        }

        private Energy(double joules)
        {
            this.joules = joules;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.EnergyUnit.Joules"/>
        /// </summary>
        public double SiValue => this.joules;

        /// <summary>
        /// Gets the <see cref="Gu.Units.EnergyUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public EnergyUnit SiUnit => EnergyUnit.Joules;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => EnergyUnit.Joules;

        /// <summary>
        /// Gets the quantity in joules".
        /// </summary>
        public double Joules => this.joules;

        /// <summary>
        /// Gets the quantity in Nanojoules
        /// </summary>
        public double Nanojoules => 1000000000 * this.joules;

        /// <summary>
        /// Gets the quantity in Microjoules
        /// </summary>
        public double Microjoules => 1000000 * this.joules;

        /// <summary>
        /// Gets the quantity in Millijoules
        /// </summary>
        public double Millijoules => 1000 * this.joules;

        /// <summary>
        /// Gets the quantity in Kilojoules
        /// </summary>
        public double Kilojoules => this.joules / 1000;

        /// <summary>
        /// Gets the quantity in Megajoules
        /// </summary>
        public double Megajoules => this.joules / 1000000;

        /// <summary>
        /// Gets the quantity in Gigajoules
        /// </summary>
        public double Gigajoules => this.joules / 1000000000;

        /// <summary>
        /// Gets the quantity in KilowattHours
        /// </summary>
        public double KilowattHours => this.joules / 3600000;

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificEnergy"/> that is the result from the division.</returns>
        public static SpecificEnergy operator /(Energy left, Mass right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.joules / right.kilograms);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the division.</returns>
        public static Force operator /(Energy left, Length right)
        {
            return Force.FromNewtons(left.joules / right.metres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Power"/> that is the result from the division.</returns>
        public static Power operator /(Energy left, Time right)
        {
            return Power.FromWatts(left.joules / right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Torque"/> that is the result from the division.</returns>
        public static Torque operator /(Energy left, Angle right)
        {
            return Torque.FromNewtonMetres(left.joules / right.radians);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MagneticFlux"/> that is the result from the division.</returns>
        public static MagneticFlux operator /(Energy left, Current right)
        {
            return MagneticFlux.FromWebers(left.joules / right.amperes);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the division.</returns>
        public static Stiffness operator /(Energy left, Area right)
        {
            return Stiffness.FromNewtonsPerMetre(left.joules / right.squareMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Pressure"/> that is the result from the division.</returns>
        public static Pressure operator /(Energy left, Volume right)
        {
            return Pressure.FromPascals(left.joules / right.cubicMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the division.</returns>
        public static Length operator /(Energy left, Force right)
        {
            return Length.FromMetres(left.joules / right.newtons);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Volume"/> that is the result from the division.</returns>
        public static Volume operator /(Energy left, Pressure right)
        {
            return Volume.FromCubicMetres(left.joules / right.pascals);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the division.</returns>
        public static Time operator /(Energy left, Power right)
        {
            return Time.FromSeconds(left.joules / right.watts);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Momentum"/> that is the result from the division.</returns>
        public static Momentum operator /(Energy left, Speed right)
        {
            return Momentum.FromNewtonSecond(left.joules / right.metresPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Power"/> that is the result from the multiplication.</returns>
        public static Power operator *(Energy left, Frequency right)
        {
            return Power.FromWatts(left.joules * right.hertz);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Angle"/> that is the result from the division.</returns>
        public static Angle operator /(Energy left, Torque right)
        {
            return Angle.FromRadians(left.joules / right.newtonMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Area"/> that is the result from the division.</returns>
        public static Area operator /(Energy left, Stiffness right)
        {
            return Area.FromSquareMetres(left.joules / right.newtonsPerMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricCharge"/> that is the result from the division.</returns>
        public static ElectricCharge operator /(Energy left, Voltage right)
        {
            return ElectricCharge.FromCoulombs(left.joules / right.volts);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Mass"/> that is the result from the division.</returns>
        public static Mass operator /(Energy left, SpecificEnergy right)
        {
            return Mass.FromKilograms(left.joules / right.joulesPerKilogram);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Voltage"/> that is the result from the division.</returns>
        public static Voltage operator /(Energy left, ElectricCharge right)
        {
            return Voltage.FromVolts(left.joules / right.coulombs);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Area"/> that is the result from the multiplication.</returns>
        public static Area operator *(Energy left, Flexibility right)
        {
            return Area.FromSquareMetres(left.joules * right.metresPerNewton);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Current"/> that is the result from the division.</returns>
        public static Current operator /(Energy left, MagneticFlux right)
        {
            return Current.FromAmperes(left.joules / right.webers);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the division.</returns>
        public static Speed operator /(Energy left, Momentum right)
        {
            return Speed.FromMetresPerSecond(left.joules / right.newtonSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the multiplication.</returns>
        public static Force operator *(Energy left, Wavenumber right)
        {
            return Force.FromNewtons(left.joules * right.reciprocalMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="KinematicViscosity"/> that is the result from the division.</returns>
        public static KinematicViscosity operator /(Energy left, MassFlow right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.joules / right.kilogramsPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the division.</returns>
        public static MassFlow operator /(Energy left, KinematicViscosity right)
        {
            return MassFlow.FromKilogramsPerSecond(left.joules / right.squareMetresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Energy left, Energy right)
        {
            return left.joules / right.joules;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Energy"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Energy"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Energy"/>.</param>
        public static bool operator ==(Energy left, Energy right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Energy"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Energy"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Energy"/>.</param>
        public static bool operator !=(Energy left, Energy right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Energy"/> is less than another specified <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Energy"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Energy"/>.</param>
        public static bool operator <(Energy left, Energy right)
        {
            return left.joules < right.joules;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Energy"/> is greater than another specified <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Energy"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Energy"/>.</param>
        public static bool operator >(Energy left, Energy right)
        {
            return left.joules > right.joules;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Energy"/> is less than or equal to another specified <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Energy"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Energy"/>.</param>
        public static bool operator <=(Energy left, Energy right)
        {
            return left.joules <= right.joules;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Energy"/> is greater than or equal to another specified <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Energy"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Energy"/>.</param>
        public static bool operator >=(Energy left, Energy right)
        {
            return left.joules >= right.joules;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Energy"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Energy"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Energy"/> and returns the result.</returns>
        public static Energy operator *(double left, Energy right)
        {
            return new Energy(left * right.joules);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Energy"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Energy"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Energy"/> with <paramref name="right"/> and returns the result.</returns>
        public static Energy operator *(Energy left, double right)
        {
            return new Energy(left.joules * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Energy"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Energy"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Energy"/> by <paramref name="right"/> and returns the result.</returns>
        public static Energy operator /(Energy left, double right)
        {
            return new Energy(left.joules / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Energy"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Energy"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Energy"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Energy"/>.</param>
        public static Energy operator +(Energy left, Energy right)
        {
            return new Energy(left.joules + right.joules);
        }

        /// <summary>
        /// Subtracts an Energy from another Energy and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Energy"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Energy"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Energy"/> (the subtrahend).</param>
        public static Energy operator -(Energy left, Energy right)
        {
            return new Energy(left.joules - right.joules);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Energy"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Energy"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="energy">An instance of <see cref="Gu.Units.Energy"/></param>
        public static Energy operator -(Energy energy)
        {
            return new Energy(-1 * energy.joules);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="energy"/>.
        /// </returns>
        /// <param name="energy">An instance of <see cref="Gu.Units.Energy"/></param>
        public static Energy operator +(Energy energy)
        {
            return energy;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Energy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Energy"/></param>
        /// <returns>The <see cref="Gu.Units.Energy"/> parsed from <paramref name="text"/></returns>
        public static Energy Parse(string text)
        {
            return QuantityParser.Parse<EnergyUnit, Energy>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Energy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Energy"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Energy"/> parsed from <paramref name="text"/></returns>
        public static Energy Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<EnergyUnit, Energy>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Energy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Energy"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Energy"/> parsed from <paramref name="text"/></returns>
        public static Energy Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<EnergyUnit, Energy>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Energy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Energy"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Energy"/> parsed from <paramref name="text"/></returns>
        public static Energy Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<EnergyUnit, Energy>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Energy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Energy"/></param>
        /// <param name="result">The parsed <see cref="Energy"/></param>
        /// <returns>True if an instance of <see cref="Energy"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Energy result)
        {
            return QuantityParser.TryParse<EnergyUnit, Energy>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Energy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Energy"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Energy"/></param>
        /// <returns>True if an instance of <see cref="Energy"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Energy result)
        {
            return QuantityParser.TryParse<EnergyUnit, Energy>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Energy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Energy"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Energy"/></param>
        /// <returns>True if an instance of <see cref="Energy"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Energy result)
        {
            return QuantityParser.TryParse<EnergyUnit, Energy>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Energy"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Energy"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Energy"/></param>
        /// <returns>True if an instance of <see cref="Energy"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Energy result)
        {
            return QuantityParser.TryParse<EnergyUnit, Energy>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Energy"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Energy"/></returns>
        public static Energy ReadFrom(XmlReader reader)
        {
            var v = default(Energy);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Energy"/></returns>
        public static Energy From(double value, EnergyUnit unit)
        {
            return new Energy(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="joules">The value in <see cref="Gu.Units.EnergyUnit.Joules"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Energy"/></returns>
        public static Energy FromJoules(double joules)
        {
            return new Energy(joules);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="nanojoules">The value in nJ.</param>
        /// <returns>An instance of <see cref="Gu.Units.Energy"/></returns>
        public static Energy FromNanojoules(double nanojoules)
        {
            return new Energy(nanojoules / 1000000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="microjoules">The value in μJ.</param>
        /// <returns>An instance of <see cref="Gu.Units.Energy"/></returns>
        public static Energy FromMicrojoules(double microjoules)
        {
            return new Energy(microjoules / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="millijoules">The value in mJ.</param>
        /// <returns>An instance of <see cref="Gu.Units.Energy"/></returns>
        public static Energy FromMillijoules(double millijoules)
        {
            return new Energy(millijoules / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="kilojoules">The value in kJ.</param>
        /// <returns>An instance of <see cref="Gu.Units.Energy"/></returns>
        public static Energy FromKilojoules(double kilojoules)
        {
            return new Energy(1000 * kilojoules);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="megajoules">The value in MJ.</param>
        /// <returns>An instance of <see cref="Gu.Units.Energy"/></returns>
        public static Energy FromMegajoules(double megajoules)
        {
            return new Energy(1000000 * megajoules);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="gigajoules">The value in GJ.</param>
        /// <returns>An instance of <see cref="Gu.Units.Energy"/></returns>
        public static Energy FromGigajoules(double gigajoules)
        {
            return new Energy(1000000000 * gigajoules);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Energy"/>.
        /// </summary>
        /// <param name="kilowattHours">The value in kWh.</param>
        /// <returns>An instance of <see cref="Gu.Units.Energy"/></returns>
        public static Energy FromKilowattHours(double kilowattHours)
        {
            return new Energy(3600000 * kilowattHours);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(EnergyUnit unit)
        {
            return unit.FromSiUnit(this.joules);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Energy"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Energy"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 J\"</param>
        /// <returns>The string representation of the <see cref="Energy"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 J\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Energy"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex J</param>
        /// <returns>The string representation of the <see cref="Energy"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex J</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="Energy"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(EnergyUnit unit)
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(EnergyUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(EnergyUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(EnergyUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, EnergyUnit unit)
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, EnergyUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, EnergyUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, EnergyUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<EnergyUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Energy"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Energy"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Energy"/> object to compare to this instance.</param>
        public int CompareTo(Energy quantity)
        {
            return this.joules.CompareTo(quantity.joules);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Energy"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Energy as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Energy"/> object to compare with this instance.</param>
        public bool Equals(Energy other)
        {
            return this.joules.Equals(other.joules);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Energy"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Energy as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Energy"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Energy other, Energy tolerance)
        {
            Ensure.GreaterThan(tolerance.joules, 0, nameof(tolerance));
            return Math.Abs(this.joules - other.joules) < tolerance.joules;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Energy"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Energy"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Energy && this.Equals((Energy)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.joules.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "joules", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.joules);
        }

        internal string ToString(QuantityFormat<EnergyUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
