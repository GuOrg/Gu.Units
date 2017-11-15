namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Length"/>.
    /// </summary>
    [TypeConverter(typeof(LengthTypeConverter))]
    [Serializable]
    public partial struct Length : IQuantity<LengthUnit>, IComparable<Length>, IEquatable<Length>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.LengthUnit.Metres"/>
        /// </summary>
        public static readonly Length Zero = default(Length);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.LengthUnit.Metres"/>.
        /// </summary>
        internal readonly double metres;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Length"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.LengthUnit"/>.</param>
        public Length(double value, LengthUnit unit)
        {
            this.metres = unit.ToSiUnit(value);
        }

        private Length(double metres)
        {
            this.metres = metres;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.LengthUnit.Metres"/>
        /// </summary>
        public double SiValue => this.metres;

        /// <summary>
        /// Gets the <see cref="Gu.Units.LengthUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public LengthUnit SiUnit => LengthUnit.Metres;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => LengthUnit.Metres;

        /// <summary>
        /// Gets the quantity in metres".
        /// </summary>
        public double Metres => this.metres;

        /// <summary>
        /// Gets the quantity in Inches
        /// </summary>
        public double Inches => this.metres / 0.0254;

        /// <summary>
        /// Gets the quantity in Miles
        /// </summary>
        public double Miles => this.metres / 1609.344;

        /// <summary>
        /// Gets the quantity in Yards
        /// </summary>
        public double Yards => this.metres / 0.9144;

        /// <summary>
        /// Gets the quantity in NauticalMiles
        /// </summary>
        public double NauticalMiles => this.metres / 1852;

        /// <summary>
        /// Gets the quantity in Feet
        /// </summary>
        public double Feet => this.metres / 0.3048;

        /// <summary>
        /// Gets the quantity in Nanometres
        /// </summary>
        public double Nanometres => 1000000000 * this.metres;

        /// <summary>
        /// Gets the quantity in Micrometres
        /// </summary>
        public double Micrometres => 1000000 * this.metres;

        /// <summary>
        /// Gets the quantity in Millimetres
        /// </summary>
        public double Millimetres => 1000 * this.metres;

        /// <summary>
        /// Gets the quantity in Centimetres
        /// </summary>
        public double Centimetres => 100 * this.metres;

        /// <summary>
        /// Gets the quantity in Decimetres
        /// </summary>
        public double Decimetres => 10 * this.metres;

        /// <summary>
        /// Gets the quantity in Kilometres
        /// </summary>
        public double Kilometres => this.metres / 1000;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Area"/> that is the result from the multiplication.</returns>
        public static Area operator *(Length left, Length right)
        {
            return Area.FromSquareMetres(left.metres * right.metres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the division.</returns>
        public static Speed operator /(Length left, Time right)
        {
            return Speed.FromMetresPerSecond(left.metres / right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="LengthPerUnitless"/> that is the result from the division.</returns>
        public static LengthPerUnitless operator /(Length left, Unitless right)
        {
            return LengthPerUnitless.FromMetresPerUnitless(left.metres / right.scalar);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Volume"/> that is the result from the multiplication.</returns>
        public static Volume operator *(Length left, Area right)
        {
            return Volume.FromCubicMetres(left.metres * right.squareMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Wavenumber"/> that is the result from the division.</returns>
        public static Wavenumber operator /(Length left, Area right)
        {
            return Wavenumber.FromReciprocalMetres(left.metres / right.squareMetres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(Length left, Force right)
        {
            return Energy.FromJoules(left.metres * right.newtons);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Flexibility"/> that is the result from the division.</returns>
        public static Flexibility operator /(Length left, Force right)
        {
            return Flexibility.FromMetresPerNewton(left.metres / right.newtons);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the multiplication.</returns>
        public static Stiffness operator *(Length left, Pressure right)
        {
            return Stiffness.FromNewtonsPerMetre(left.metres * right.pascals);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AreaDensity"/> that is the result from the multiplication.</returns>
        public static AreaDensity operator *(Length left, Density right)
        {
            return AreaDensity.FromKilogramsPerSquareMetre(left.metres * right.kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="KinematicViscosity"/> that is the result from the multiplication.</returns>
        public static KinematicViscosity operator *(Length left, Speed right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.metres * right.metresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the division.</returns>
        public static Time operator /(Length left, Speed right)
        {
            return Time.FromSeconds(left.metres / right.metresPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the multiplication.</returns>
        public static Speed operator *(Length left, Frequency right)
        {
            return Speed.FromMetresPerSecond(left.metres * right.hertz);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificEnergy"/> that is the result from the multiplication.</returns>
        public static SpecificEnergy operator *(Length left, Acceleration right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.metres * right.metresPerSecondSquared);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the multiplication.</returns>
        public static Force operator *(Length left, Stiffness right)
        {
            return Force.FromNewtons(left.metres * right.newtonsPerMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the division.</returns>
        public static Force operator /(Length left, Flexibility right)
        {
            return Force.FromNewtons(left.metres / right.metresPerNewton);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Unitless"/> that is the result from the division.</returns>
        public static Unitless operator /(Length left, LengthPerUnitless right)
        {
            return Unitless.FromScalar(left.metres / right.metresPerUnitless);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificVolume"/> that is the result from the division.</returns>
        public static SpecificVolume operator /(Length left, AreaDensity right)
        {
            return SpecificVolume.FromCubicMetresPerKilogram(left.metres / right.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AreaDensity"/> that is the result from the division.</returns>
        public static AreaDensity operator /(Length left, SpecificVolume right)
        {
            return AreaDensity.FromKilogramsPerSquareMetre(left.metres / right.cubicMetresPerKilogram);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Momentum"/> that is the result from the multiplication.</returns>
        public static Momentum operator *(Length left, MassFlow right)
        {
            return Momentum.FromNewtonSecond(left.metres * right.kilogramsPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="VolumetricFlow"/> that is the result from the multiplication.</returns>
        public static VolumetricFlow operator *(Length left, KinematicViscosity right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.metres * right.squareMetresPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricalConductance"/> that is the result from the multiplication.</returns>
        public static ElectricalConductance operator *(Length left, Conductivity right)
        {
            return ElectricalConductance.FromSiemens(left.metres * right.siemensPerMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The Wavenumber that is the result from the division.</returns>
        public static Wavenumber operator /(double left, Length right)
        {
            return Wavenumber.FromReciprocalMetres(left / right.metres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Length left, Length right)
        {
            return left.metres / right.metres;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Length"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Length"/>.</param>
        public static bool operator ==(Length left, Length right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Length"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Length"/>.</param>
        public static bool operator !=(Length left, Length right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Length"/> is less than another specified <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Length"/>.</param>
        public static bool operator <(Length left, Length right)
        {
            return left.metres < right.metres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Length"/> is greater than another specified <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Length"/>.</param>
        public static bool operator >(Length left, Length right)
        {
            return left.metres > right.metres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Length"/> is less than or equal to another specified <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Length"/>.</param>
        public static bool operator <=(Length left, Length right)
        {
            return left.metres <= right.metres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Length"/> is greater than or equal to another specified <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Length"/>.</param>
        public static bool operator >=(Length left, Length right)
        {
            return left.metres >= right.metres;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Length"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Length"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Length"/> and returns the result.</returns>
        public static Length operator *(double left, Length right)
        {
            return new Length(left * right.metres);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Length"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Length"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Length"/> with <paramref name="right"/> and returns the result.</returns>
        public static Length operator *(Length left, double right)
        {
            return new Length(left.metres * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Length"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Length"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Length"/> by <paramref name="right"/> and returns the result.</returns>
        public static Length operator /(Length left, double right)
        {
            return new Length(left.metres / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Length"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Length"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Length"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Length"/>.</param>
        public static Length operator +(Length left, Length right)
        {
            return new Length(left.metres + right.metres);
        }

        /// <summary>
        /// Subtracts an Length from another Length and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Length"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Length"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Length"/> (the subtrahend).</param>
        public static Length operator -(Length left, Length right)
        {
            return new Length(left.metres - right.metres);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Length"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Length"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="length">An instance of <see cref="Gu.Units.Length"/></param>
        public static Length operator -(Length length)
        {
            return new Length(-1 * length.metres);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="length"/>.
        /// </returns>
        /// <param name="length">An instance of <see cref="Gu.Units.Length"/></param>
        public static Length operator +(Length length)
        {
            return length;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <returns>The <see cref="Gu.Units.Length"/> parsed from <paramref name="text"/></returns>
        public static Length Parse(string text)
        {
            return QuantityParser.Parse<LengthUnit, Length>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Length"/> parsed from <paramref name="text"/></returns>
        public static Length Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<LengthUnit, Length>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Length"/> parsed from <paramref name="text"/></returns>
        public static Length Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<LengthUnit, Length>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Length"/> parsed from <paramref name="text"/></returns>
        public static Length Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<LengthUnit, Length>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="result">The parsed <see cref="Length"/></param>
        /// <returns>True if an instance of <see cref="Length"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Length result)
        {
            return QuantityParser.TryParse<LengthUnit, Length>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Length"/></param>
        /// <returns>True if an instance of <see cref="Length"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Length result)
        {
            return QuantityParser.TryParse<LengthUnit, Length>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Length"/></param>
        /// <returns>True if an instance of <see cref="Length"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Length result)
        {
            return QuantityParser.TryParse<LengthUnit, Length>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Length"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Length"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Length"/></param>
        /// <returns>True if an instance of <see cref="Length"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Length result)
        {
            return QuantityParser.TryParse<LengthUnit, Length>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Length"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length ReadFrom(XmlReader reader)
        {
            var v = default(Length);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length From(double value, LengthUnit unit)
        {
            return new Length(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="metres">The value in <see cref="Gu.Units.LengthUnit.Metres"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length FromMetres(double metres)
        {
            return new Length(metres);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="inches">The value in in.</param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length FromInches(double inches)
        {
            return new Length(0.0254 * inches);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="miles">The value in mi.</param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length FromMiles(double miles)
        {
            return new Length(1609.344 * miles);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="yards">The value in yd.</param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length FromYards(double yards)
        {
            return new Length(0.9144 * yards);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="nauticalMiles">The value in nmi.</param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length FromNauticalMiles(double nauticalMiles)
        {
            return new Length(1852 * nauticalMiles);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="feet">The value in ft.</param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length FromFeet(double feet)
        {
            return new Length(0.3048 * feet);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="nanometres">The value in nm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length FromNanometres(double nanometres)
        {
            return new Length(nanometres / 1000000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="micrometres">The value in μm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length FromMicrometres(double micrometres)
        {
            return new Length(micrometres / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="millimetres">The value in mm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length FromMillimetres(double millimetres)
        {
            return new Length(millimetres / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="centimetres">The value in cm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length FromCentimetres(double centimetres)
        {
            return new Length(centimetres / 100);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="decimetres">The value in dm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length FromDecimetres(double decimetres)
        {
            return new Length(decimetres / 10);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Length"/>.
        /// </summary>
        /// <param name="kilometres">The value in km.</param>
        /// <returns>An instance of <see cref="Gu.Units.Length"/></returns>
        public static Length FromKilometres(double kilometres)
        {
            return new Length(1000 * kilometres);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(LengthUnit unit)
        {
            return unit.FromSiUnit(this.metres);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m\"</param>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m</param>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the <see cref="Length"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(LengthUnit unit)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(LengthUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(LengthUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(LengthUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, LengthUnit unit)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, LengthUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, LengthUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, LengthUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<LengthUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Length"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Length"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Length"/> object to compare to this instance.</param>
        public int CompareTo(Length quantity)
        {
            return this.metres.CompareTo(quantity.metres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Length"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Length as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Length"/> object to compare with this instance.</param>
        public bool Equals(Length other)
        {
            return this.metres.Equals(other.metres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Length"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Length as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Length"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Length other, Length tolerance)
        {
            Ensure.GreaterThan(tolerance.metres, 0, nameof(tolerance));
            return Math.Abs(this.metres - other.metres) < tolerance.metres;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Length"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Length"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Length && this.Equals((Length)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.metres.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "metres", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.metres);
        }

        internal string ToString(QuantityFormat<LengthUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}