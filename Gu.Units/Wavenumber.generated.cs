#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Wavenumber"/>.
    /// </summary>
    [TypeConverter(typeof(WavenumberTypeConverter))]
    [Serializable]
    public partial struct Wavenumber : IQuantity<WavenumberUnit>, IComparable<Wavenumber>, IEquatable<Wavenumber>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.WavenumberUnit.ReciprocalMetres"/>
        /// </summary>
        public static readonly Wavenumber Zero = default(Wavenumber);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.WavenumberUnit.ReciprocalMetres"/>.
        /// </summary>
        internal readonly double reciprocalMetres;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wavenumber"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.WavenumberUnit"/>.</param>
        public Wavenumber(double value, WavenumberUnit unit)
        {
            this.reciprocalMetres = unit.ToSiUnit(value);
        }

        private Wavenumber(double reciprocalMetres)
        {
            this.reciprocalMetres = reciprocalMetres;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.WavenumberUnit.ReciprocalMetres"/>
        /// </summary>
        public double SiValue => this.reciprocalMetres;

        /// <summary>
        /// Gets the <see cref="Gu.Units.WavenumberUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public WavenumberUnit SiUnit => WavenumberUnit.ReciprocalMetres;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => WavenumberUnit.ReciprocalMetres;

        /// <summary>
        /// Gets the quantity in reciprocalMetres".
        /// </summary>
        public double ReciprocalMetres => this.reciprocalMetres;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the multiplication.</returns>
        public static Length operator *(Wavenumber left, Area right)
        {
            return Length.FromMetres(left.reciprocalMetres * right.squareMetres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Area"/> that is the result from the multiplication.</returns>
        public static Area operator *(Wavenumber left, Volume right)
        {
            return Area.FromSquareMetres(left.reciprocalMetres * right.cubicMetres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the multiplication.</returns>
        public static Stiffness operator *(Wavenumber left, Force right)
        {
            return Stiffness.FromNewtonsPerMetre(left.reciprocalMetres * right.newtons);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Flexibility"/> that is the result from the division.</returns>
        public static Flexibility operator /(Wavenumber left, Pressure right)
        {
            return Flexibility.FromMetresPerNewton(left.reciprocalMetres / right.pascals);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the multiplication.</returns>
        public static Force operator *(Wavenumber left, Energy right)
        {
            return Force.FromNewtons(left.reciprocalMetres * right.joules);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Frequency"/> that is the result from the multiplication.</returns>
        public static Frequency operator *(Wavenumber left, Speed right)
        {
            return Frequency.FromHertz(left.reciprocalMetres * right.metresPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Pressure"/> that is the result from the multiplication.</returns>
        public static Pressure operator *(Wavenumber left, Stiffness right)
        {
            return Pressure.FromPascals(left.reciprocalMetres * right.newtonsPerMetre);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="KinematicViscosity"/> that is the result from the multiplication.</returns>
        public static KinematicViscosity operator *(Wavenumber left, VolumetricFlow right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.reciprocalMetres * right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Conductivity"/> that is the result from the division.</returns>
        public static Conductivity operator /(Wavenumber left, Resistance right)
        {
            return Conductivity.FromSiemensPerMetre(left.reciprocalMetres / right.ohms);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Acceleration"/> that is the result from the multiplication.</returns>
        public static Acceleration operator *(Wavenumber left, SpecificEnergy right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.reciprocalMetres * right.joulesPerKilogram);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Pressure"/> that is the result from the division.</returns>
        public static Pressure operator /(Wavenumber left, Flexibility right)
        {
            return Pressure.FromPascals(left.reciprocalMetres / right.metresPerNewton);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Conductivity"/> that is the result from the multiplication.</returns>
        public static Conductivity operator *(Wavenumber left, ElectricalConductance right)
        {
            return Conductivity.FromSiemensPerMetre(left.reciprocalMetres * right.siemens);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the multiplication.</returns>
        public static MassFlow operator *(Wavenumber left, Momentum right)
        {
            return MassFlow.FromKilogramsPerSecond(left.reciprocalMetres * right.newtonSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Density"/> that is the result from the multiplication.</returns>
        public static Density operator *(Wavenumber left, AreaDensity right)
        {
            return Density.FromKilogramsPerCubicMetre(left.reciprocalMetres * right.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the multiplication.</returns>
        public static Speed operator *(Wavenumber left, KinematicViscosity right)
        {
            return Speed.FromMetresPerSecond(left.reciprocalMetres * right.squareMetresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Resistance"/> that is the result from the division.</returns>
        public static Resistance operator /(Wavenumber left, Conductivity right)
        {
            return Resistance.FromOhms(left.reciprocalMetres / right.siemensPerMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The Length that is the result from the division.</returns>
        public static Length operator /(double left, Wavenumber right)
        {
            return Length.FromMetres(left / right.reciprocalMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Wavenumber left, Wavenumber right)
        {
            return left.reciprocalMetres / right.reciprocalMetres;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Wavenumber"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static bool operator ==(Wavenumber left, Wavenumber right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Wavenumber"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static bool operator !=(Wavenumber left, Wavenumber right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Wavenumber"/> is less than another specified <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static bool operator <(Wavenumber left, Wavenumber right)
        {
            return left.reciprocalMetres < right.reciprocalMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Wavenumber"/> is greater than another specified <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static bool operator >(Wavenumber left, Wavenumber right)
        {
            return left.reciprocalMetres > right.reciprocalMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Wavenumber"/> is less than or equal to another specified <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static bool operator <=(Wavenumber left, Wavenumber right)
        {
            return left.reciprocalMetres <= right.reciprocalMetres;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Wavenumber"/> is greater than or equal to another specified <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static bool operator >=(Wavenumber left, Wavenumber right)
        {
            return left.reciprocalMetres >= right.reciprocalMetres;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Wavenumber"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Wavenumber"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Wavenumber"/> and returns the result.</returns>
        public static Wavenumber operator *(double left, Wavenumber right)
        {
            return new Wavenumber(left * right.reciprocalMetres);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Wavenumber"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Wavenumber"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Wavenumber"/> with <paramref name="right"/> and returns the result.</returns>
        public static Wavenumber operator *(Wavenumber left, double right)
        {
            return new Wavenumber(left.reciprocalMetres * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Wavenumber"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Wavenumber"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Wavenumber"/> by <paramref name="right"/> and returns the result.</returns>
        public static Wavenumber operator /(Wavenumber left, double right)
        {
            return new Wavenumber(left.reciprocalMetres / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Wavenumber"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Wavenumber"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Wavenumber"/>.</param>
        public static Wavenumber operator +(Wavenumber left, Wavenumber right)
        {
            return new Wavenumber(left.reciprocalMetres + right.reciprocalMetres);
        }

        /// <summary>
        /// Subtracts an Wavenumber from another Wavenumber and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Wavenumber"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Wavenumber"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Wavenumber"/> (the subtrahend).</param>
        public static Wavenumber operator -(Wavenumber left, Wavenumber right)
        {
            return new Wavenumber(left.reciprocalMetres - right.reciprocalMetres);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Wavenumber"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Wavenumber"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="wavenumber">An instance of <see cref="Gu.Units.Wavenumber"/></param>
        public static Wavenumber operator -(Wavenumber wavenumber)
        {
            return new Wavenumber(-1 * wavenumber.reciprocalMetres);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="wavenumber"/>.
        /// </returns>
        /// <param name="wavenumber">An instance of <see cref="Gu.Units.Wavenumber"/></param>
        public static Wavenumber operator +(Wavenumber wavenumber)
        {
            return wavenumber;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <returns>The <see cref="Gu.Units.Wavenumber"/> parsed from <paramref name="text"/></returns>
        public static Wavenumber Parse(string text)
        {
            return QuantityParser.Parse<WavenumberUnit, Wavenumber>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Wavenumber"/> parsed from <paramref name="text"/></returns>
        public static Wavenumber Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<WavenumberUnit, Wavenumber>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Wavenumber"/> parsed from <paramref name="text"/></returns>
        public static Wavenumber Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<WavenumberUnit, Wavenumber>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Wavenumber"/> parsed from <paramref name="text"/></returns>
        public static Wavenumber Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<WavenumberUnit, Wavenumber>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <param name="result">The parsed <see cref="Wavenumber"/></param>
        /// <returns>True if an instance of <see cref="Wavenumber"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Wavenumber result)
        {
            return QuantityParser.TryParse<WavenumberUnit, Wavenumber>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Wavenumber"/></param>
        /// <returns>True if an instance of <see cref="Wavenumber"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Wavenumber result)
        {
            return QuantityParser.TryParse<WavenumberUnit, Wavenumber>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Wavenumber"/></param>
        /// <returns>True if an instance of <see cref="Wavenumber"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Wavenumber result)
        {
            return QuantityParser.TryParse<WavenumberUnit, Wavenumber>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Wavenumber"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Wavenumber"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Wavenumber"/></param>
        /// <returns>True if an instance of <see cref="Wavenumber"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Wavenumber result)
        {
            return QuantityParser.TryParse<WavenumberUnit, Wavenumber>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Wavenumber"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Wavenumber"/></returns>
        public static Wavenumber ReadFrom(XmlReader reader)
        {
            var v = default(Wavenumber);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Wavenumber"/></returns>
        public static Wavenumber From(double value, WavenumberUnit unit)
        {
            return new Wavenumber(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Wavenumber"/>.
        /// </summary>
        /// <param name="reciprocalMetres">The value in <see cref="Gu.Units.WavenumberUnit.ReciprocalMetres"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Wavenumber"/></returns>
        public static Wavenumber FromReciprocalMetres(double reciprocalMetres)
        {
            return new Wavenumber(reciprocalMetres);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(WavenumberUnit unit)
        {
            return unit.FromSiUnit(this.reciprocalMetres);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Wavenumber"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Wavenumber"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m⁻¹\"</param>
        /// <returns>The string representation of the <see cref="Wavenumber"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m⁻¹\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Wavenumber"/></returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m⁻¹</param>
        /// <returns>The string representation of the <see cref="Wavenumber"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m⁻¹</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="Wavenumber"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(WavenumberUnit unit)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(WavenumberUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(WavenumberUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(WavenumberUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, WavenumberUnit unit)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, WavenumberUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, WavenumberUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, WavenumberUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<WavenumberUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Wavenumber"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Wavenumber"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Wavenumber"/> object to compare to this instance.</param>
        public int CompareTo(Wavenumber quantity)
        {
            return this.reciprocalMetres.CompareTo(quantity.reciprocalMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Wavenumber"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Wavenumber as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Wavenumber"/> object to compare with this instance.</param>
        public bool Equals(Wavenumber other)
        {
            return this.reciprocalMetres.Equals(other.reciprocalMetres);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Wavenumber"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Wavenumber as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Wavenumber"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Wavenumber other, Wavenumber tolerance)
        {
            Ensure.GreaterThan(tolerance.reciprocalMetres, 0, nameof(tolerance));
            return Math.Abs(this.reciprocalMetres - other.reciprocalMetres) < tolerance.reciprocalMetres;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Wavenumber"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Wavenumber"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is Wavenumber other && this.Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.reciprocalMetres.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "reciprocalMetres", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.reciprocalMetres);
        }

        internal string ToString(QuantityFormat<WavenumberUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
