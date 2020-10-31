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
    /// A type for the quantity <see cref="Gu.Units.VolumetricFlow"/>.
    /// </summary>
    [TypeConverter(typeof(VolumetricFlowTypeConverter))]
    [Serializable]
    public partial struct VolumetricFlow : IQuantity<VolumetricFlowUnit>, IComparable<VolumetricFlow>, IEquatable<VolumetricFlow>, IXmlSerializable
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.VolumetricFlowUnit.CubicMetresPerSecond"/>
        /// </summary>
        public static readonly VolumetricFlow Zero = default(VolumetricFlow);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.VolumetricFlowUnit.CubicMetresPerSecond"/>.
        /// </summary>
        internal readonly double cubicMetresPerSecond;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.VolumetricFlow"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.VolumetricFlowUnit"/>.</param>
        public VolumetricFlow(double value, VolumetricFlowUnit unit)
        {
            this.cubicMetresPerSecond = unit.ToSiUnit(value);
        }

        private VolumetricFlow(double cubicMetresPerSecond)
        {
            this.cubicMetresPerSecond = cubicMetresPerSecond;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.VolumetricFlowUnit.CubicMetresPerSecond"/>
        /// </summary>
        public double SiValue => this.cubicMetresPerSecond;

        /// <summary>
        /// Gets the <see cref="Gu.Units.VolumetricFlowUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public VolumetricFlowUnit SiUnit => VolumetricFlowUnit.CubicMetresPerSecond;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => VolumetricFlowUnit.CubicMetresPerSecond;

        /// <summary>
        /// Gets the quantity in cubicMetresPerSecond".
        /// </summary>
        public double CubicMetresPerSecond => this.cubicMetresPerSecond;

        /// <summary>
        /// Gets the quantity in CubicMetresPerMinute
        /// </summary>
        public double CubicMetresPerMinute => 60 * this.cubicMetresPerSecond;

        /// <summary>
        /// Gets the quantity in CubicMetresPerHour
        /// </summary>
        public double CubicMetresPerHour => 3600 * this.cubicMetresPerSecond;

        /// <summary>
        /// Gets the quantity in LitresPerSecond
        /// </summary>
        public double LitresPerSecond => 1000 * this.cubicMetresPerSecond;

        /// <summary>
        /// Gets the quantity in LitresPerHour
        /// </summary>
        public double LitresPerHour => 3600000 * this.cubicMetresPerSecond;

        /// <summary>
        /// Gets the quantity in LitresPerMinute
        /// </summary>
        public double LitresPerMinute => 60000 * this.cubicMetresPerSecond;

        /// <summary>
        /// Gets the quantity in MillilitresPerSecond
        /// </summary>
        public double MillilitresPerSecond => 1000000 * this.cubicMetresPerSecond;

        /// <summary>
        /// Gets the quantity in MillilitresPerHour
        /// </summary>
        public double MillilitresPerHour => 3600000000 * this.cubicMetresPerSecond;

        /// <summary>
        /// Gets the quantity in MillilitresPerMinute
        /// </summary>
        public double MillilitresPerMinute => 60000000 * this.cubicMetresPerSecond;

        /// <summary>
        /// Gets the quantity in CentilitresPerSecond
        /// </summary>
        public double CentilitresPerSecond => 100000 * this.cubicMetresPerSecond;

        /// <summary>
        /// Gets the quantity in CentilitresPerHour
        /// </summary>
        public double CentilitresPerHour => 360000000 * this.cubicMetresPerSecond;

        /// <summary>
        /// Gets the quantity in CentilitresPerMinute
        /// </summary>
        public double CentilitresPerMinute => 6000000 * this.cubicMetresPerSecond;

        /// <summary>
        /// Gets the quantity in CubicFeetPerHour
        /// </summary>
        public double CubicFeetPerHour => this.cubicMetresPerSecond / 7.86579072E-06;

        /// <summary>
        /// Gets the quantity in CubicFeetPerSecond
        /// </summary>
        public double CubicFeetPerSecond => this.cubicMetresPerSecond / 0.028316846592;

        /// <summary>
        /// Gets the quantity in CubicFeetPerMinute
        /// </summary>
        public double CubicFeetPerMinute => this.cubicMetresPerSecond / 0.0004719474432;

        /// <summary>
        /// Gets the quantity in CubicFeetPerDay
        /// </summary>
        public double CubicFeetPerDay => this.cubicMetresPerSecond / 3.2774128E-07;

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="KinematicViscosity"/> that is the result from the division.</returns>
        public static KinematicViscosity operator /(VolumetricFlow left, Length right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.cubicMetresPerSecond / right.metres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Volume"/> that is the result from the multiplication.</returns>
        public static Volume operator *(VolumetricFlow left, Time right)
        {
            return Volume.FromCubicMetres(left.cubicMetresPerSecond * right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the division.</returns>
        public static Speed operator /(VolumetricFlow left, Area right)
        {
            return Speed.FromMetresPerSecond(left.cubicMetresPerSecond / right.squareMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Frequency"/> that is the result from the division.</returns>
        public static Frequency operator /(VolumetricFlow left, Volume right)
        {
            return Frequency.FromHertz(left.cubicMetresPerSecond / right.cubicMetres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Power"/> that is the result from the multiplication.</returns>
        public static Power operator *(VolumetricFlow left, Pressure right)
        {
            return Power.FromWatts(left.cubicMetresPerSecond * right.pascals);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the multiplication.</returns>
        public static MassFlow operator *(VolumetricFlow left, Density right)
        {
            return MassFlow.FromKilogramsPerSecond(left.cubicMetresPerSecond * right.kilogramsPerCubicMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Area"/> that is the result from the division.</returns>
        public static Area operator /(VolumetricFlow left, Speed right)
        {
            return Area.FromSquareMetres(left.cubicMetresPerSecond / right.metresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Volume"/> that is the result from the division.</returns>
        public static Volume operator /(VolumetricFlow left, Frequency right)
        {
            return Volume.FromCubicMetres(left.cubicMetresPerSecond / right.hertz);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="KinematicViscosity"/> that is the result from the multiplication.</returns>
        public static KinematicViscosity operator *(VolumetricFlow left, Wavenumber right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.cubicMetresPerSecond * right.reciprocalMetres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Momentum"/> that is the result from the multiplication.</returns>
        public static Momentum operator *(VolumetricFlow left, AreaDensity right)
        {
            return Momentum.FromNewtonSecond(left.cubicMetresPerSecond * right.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the division.</returns>
        public static MassFlow operator /(VolumetricFlow left, SpecificVolume right)
        {
            return MassFlow.FromKilogramsPerSecond(left.cubicMetresPerSecond / right.cubicMetresPerKilogram);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificVolume"/> that is the result from the division.</returns>
        public static SpecificVolume operator /(VolumetricFlow left, MassFlow right)
        {
            return SpecificVolume.FromCubicMetresPerKilogram(left.cubicMetresPerSecond / right.kilogramsPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the division.</returns>
        public static Length operator /(VolumetricFlow left, KinematicViscosity right)
        {
            return Length.FromMetres(left.cubicMetresPerSecond / right.squareMetresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond / right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.VolumetricFlow"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator ==(VolumetricFlow left, VolumetricFlow right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.VolumetricFlow"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator !=(VolumetricFlow left, VolumetricFlow right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.VolumetricFlow"/> is less than another specified <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator <(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond < right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.VolumetricFlow"/> is greater than another specified <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator >(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond > right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.VolumetricFlow"/> is less than or equal to another specified <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator <=(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond <= right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.VolumetricFlow"/> is greater than or equal to another specified <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static bool operator >=(VolumetricFlow left, VolumetricFlow right)
        {
            return left.cubicMetresPerSecond >= right.cubicMetresPerSecond;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.VolumetricFlow"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.VolumetricFlow"/> and returns the result.</returns>
        public static VolumetricFlow operator *(double left, VolumetricFlow right)
        {
            return new VolumetricFlow(left * right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.VolumetricFlow"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.VolumetricFlow"/> with <paramref name="right"/> and returns the result.</returns>
        public static VolumetricFlow operator *(VolumetricFlow left, double right)
        {
            return new VolumetricFlow(left.cubicMetresPerSecond * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.VolumetricFlow"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.VolumetricFlow"/> by <paramref name="right"/> and returns the result.</returns>
        public static VolumetricFlow operator /(VolumetricFlow left, double right)
        {
            return new VolumetricFlow(left.cubicMetresPerSecond / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.VolumetricFlow"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.VolumetricFlow"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.VolumetricFlow"/>.</param>
        public static VolumetricFlow operator +(VolumetricFlow left, VolumetricFlow right)
        {
            return new VolumetricFlow(left.cubicMetresPerSecond + right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Subtracts an VolumetricFlow from another VolumetricFlow and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.VolumetricFlow"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.VolumetricFlow"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.VolumetricFlow"/> (the subtrahend).</param>
        public static VolumetricFlow operator -(VolumetricFlow left, VolumetricFlow right)
        {
            return new VolumetricFlow(left.cubicMetresPerSecond - right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.VolumetricFlow"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.VolumetricFlow"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="volumetricFlow">An instance of <see cref="Gu.Units.VolumetricFlow"/></param>
        public static VolumetricFlow operator -(VolumetricFlow volumetricFlow)
        {
            return new VolumetricFlow(-1 * volumetricFlow.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="volumetricFlow"/>.
        /// </returns>
        /// <param name="volumetricFlow">An instance of <see cref="Gu.Units.VolumetricFlow"/></param>
        public static VolumetricFlow operator +(VolumetricFlow volumetricFlow)
        {
            return volumetricFlow;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.VolumetricFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <returns>The <see cref="Gu.Units.VolumetricFlow"/> parsed from <paramref name="text"/></returns>
        public static VolumetricFlow Parse(string text)
        {
            return QuantityParser.Parse<VolumetricFlowUnit, VolumetricFlow>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.VolumetricFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.VolumetricFlow"/> parsed from <paramref name="text"/></returns>
        public static VolumetricFlow Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<VolumetricFlowUnit, VolumetricFlow>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.VolumetricFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.VolumetricFlow"/> parsed from <paramref name="text"/></returns>
        public static VolumetricFlow Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<VolumetricFlowUnit, VolumetricFlow>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.VolumetricFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.VolumetricFlow"/> parsed from <paramref name="text"/></returns>
        public static VolumetricFlow Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<VolumetricFlowUnit, VolumetricFlow>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.VolumetricFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <param name="result">The parsed <see cref="VolumetricFlow"/></param>
        /// <returns>True if an instance of <see cref="VolumetricFlow"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out VolumetricFlow result)
        {
            return QuantityParser.TryParse<VolumetricFlowUnit, VolumetricFlow>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.VolumetricFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="VolumetricFlow"/></param>
        /// <returns>True if an instance of <see cref="VolumetricFlow"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out VolumetricFlow result)
        {
            return QuantityParser.TryParse<VolumetricFlowUnit, VolumetricFlow>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.VolumetricFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="VolumetricFlow"/></param>
        /// <returns>True if an instance of <see cref="VolumetricFlow"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out VolumetricFlow result)
        {
            return QuantityParser.TryParse<VolumetricFlowUnit, VolumetricFlow>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.VolumetricFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.VolumetricFlow"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="VolumetricFlow"/></param>
        /// <returns>True if an instance of <see cref="VolumetricFlow"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out VolumetricFlow result)
        {
            return QuantityParser.TryParse<VolumetricFlowUnit, VolumetricFlow>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.VolumetricFlow"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow ReadFrom(XmlReader reader)
        {
            var v = default(VolumetricFlow);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow From(double value, VolumetricFlowUnit unit)
        {
            return new VolumetricFlow(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="cubicMetresPerSecond">The value in <see cref="Gu.Units.VolumetricFlowUnit.CubicMetresPerSecond"/></param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromCubicMetresPerSecond(double cubicMetresPerSecond)
        {
            return new VolumetricFlow(cubicMetresPerSecond);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="cubicMetresPerMinute">The value in m³/min.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromCubicMetresPerMinute(double cubicMetresPerMinute)
        {
            return new VolumetricFlow(cubicMetresPerMinute / 60);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="cubicMetresPerHour">The value in m³/h.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromCubicMetresPerHour(double cubicMetresPerHour)
        {
            return new VolumetricFlow(cubicMetresPerHour / 3600);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="litresPerSecond">The value in L/s.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromLitresPerSecond(double litresPerSecond)
        {
            return new VolumetricFlow(litresPerSecond / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="litresPerHour">The value in L/h.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromLitresPerHour(double litresPerHour)
        {
            return new VolumetricFlow(litresPerHour / 3600000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="litresPerMinute">The value in L/min.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromLitresPerMinute(double litresPerMinute)
        {
            return new VolumetricFlow(litresPerMinute / 60000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="millilitresPerSecond">The value in ml/s.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromMillilitresPerSecond(double millilitresPerSecond)
        {
            return new VolumetricFlow(millilitresPerSecond / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="millilitresPerHour">The value in ml/h.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromMillilitresPerHour(double millilitresPerHour)
        {
            return new VolumetricFlow(millilitresPerHour / 3600000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="millilitresPerMinute">The value in ml/min.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromMillilitresPerMinute(double millilitresPerMinute)
        {
            return new VolumetricFlow(millilitresPerMinute / 60000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="centilitresPerSecond">The value in cl/s.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromCentilitresPerSecond(double centilitresPerSecond)
        {
            return new VolumetricFlow(centilitresPerSecond / 100000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="centilitresPerHour">The value in cl/h.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromCentilitresPerHour(double centilitresPerHour)
        {
            return new VolumetricFlow(centilitresPerHour / 360000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="centilitresPerMinute">The value in cl/min.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromCentilitresPerMinute(double centilitresPerMinute)
        {
            return new VolumetricFlow(centilitresPerMinute / 6000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="cubicFeetPerHour">The value in ft³/h.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromCubicFeetPerHour(double cubicFeetPerHour)
        {
            return new VolumetricFlow(7.86579072E-06 * cubicFeetPerHour);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="cubicFeetPerSecond">The value in ft³/s.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromCubicFeetPerSecond(double cubicFeetPerSecond)
        {
            return new VolumetricFlow(0.028316846592 * cubicFeetPerSecond);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="cubicFeetPerMinute">The value in ft³/min.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromCubicFeetPerMinute(double cubicFeetPerMinute)
        {
            return new VolumetricFlow(0.0004719474432 * cubicFeetPerMinute);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.VolumetricFlow"/>.
        /// </summary>
        /// <param name="cubicFeetPerDay">The value in ft³/d.</param>
        /// <returns>An instance of <see cref="Gu.Units.VolumetricFlow"/></returns>
        public static VolumetricFlow FromCubicFeetPerDay(double cubicFeetPerDay)
        {
            return new VolumetricFlow(3.2774128E-07 * cubicFeetPerDay);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(VolumetricFlowUnit unit)
        {
            return unit.FromSiUnit(this.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="VolumetricFlow"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="VolumetricFlow"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m³/s\"</param>
        /// <returns>The string representation of the <see cref="VolumetricFlow"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m³/s\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="VolumetricFlow"/></returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex m³/s</param>
        /// <returns>The string representation of the <see cref="VolumetricFlow"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex m³/s</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="VolumetricFlow"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(VolumetricFlowUnit unit)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(VolumetricFlowUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(VolumetricFlowUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(VolumetricFlowUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, VolumetricFlowUnit unit)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, VolumetricFlowUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, VolumetricFlowUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, VolumetricFlowUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<VolumetricFlowUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.VolumetricFlow"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.VolumetricFlow"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.VolumetricFlow"/> object to compare to this instance.</param>
        public int CompareTo(VolumetricFlow quantity)
        {
            return this.cubicMetresPerSecond.CompareTo(quantity.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.VolumetricFlow"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same VolumetricFlow as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.VolumetricFlow"/> object to compare with this instance.</param>
        public bool Equals(VolumetricFlow other)
        {
            return this.cubicMetresPerSecond.Equals(other.cubicMetresPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.VolumetricFlow"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same VolumetricFlow as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.VolumetricFlow"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(VolumetricFlow other, VolumetricFlow tolerance)
        {
            Ensure.GreaterThan(tolerance.cubicMetresPerSecond, 0, nameof(tolerance));
            return Math.Abs(this.cubicMetresPerSecond - other.cubicMetresPerSecond) < tolerance.cubicMetresPerSecond;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.VolumetricFlow"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.VolumetricFlow"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is VolumetricFlow other && this.Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.cubicMetresPerSecond.GetHashCode();
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

            this  = new VolumetricFlow(XmlConvert.ToDouble(attribute), VolumetricFlowUnit.CubicMetresPerSecond);
            reader.ReadStartElement();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartAttribute("Value");
            writer.WriteValue(this.cubicMetresPerSecond);
            writer.WriteEndAttribute();
        }

        internal string ToString(QuantityFormat<VolumetricFlowUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
