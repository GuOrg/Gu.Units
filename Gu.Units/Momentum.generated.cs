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
    /// A type for the quantity <see cref="Gu.Units.Momentum"/>.
    /// </summary>
    [TypeConverter(typeof(MomentumTypeConverter))]
    [Serializable]
    public partial struct Momentum : IQuantity<MomentumUnit>, IComparable<Momentum>, IEquatable<Momentum>, IXmlSerializable
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.MomentumUnit.NewtonSecond"/>
        /// </summary>
        public static readonly Momentum Zero = default(Momentum);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.MomentumUnit.NewtonSecond"/>.
        /// </summary>
        internal readonly double newtonSecond;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Momentum"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.MomentumUnit"/>.</param>
        public Momentum(double value, MomentumUnit unit)
        {
            this.newtonSecond = unit.ToSiUnit(value);
        }

        private Momentum(double newtonSecond)
        {
            this.newtonSecond = newtonSecond;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.MomentumUnit.NewtonSecond"/>
        /// </summary>
        public double SiValue => this.newtonSecond;

        /// <summary>
        /// Gets the <see cref="Gu.Units.MomentumUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public MomentumUnit SiUnit => MomentumUnit.NewtonSecond;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => MomentumUnit.NewtonSecond;

        /// <summary>
        /// Gets the quantity in newtonSecond".
        /// </summary>
        public double NewtonSecond => this.newtonSecond;

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the division.</returns>
        public static Speed operator /(Momentum left, Mass right)
        {
            return Speed.FromMetresPerSecond(left.newtonSecond / right.kilograms);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the division.</returns>
        public static MassFlow operator /(Momentum left, Length right)
        {
            return MassFlow.FromKilogramsPerSecond(left.newtonSecond / right.metres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the division.</returns>
        public static Force operator /(Momentum left, Time right)
        {
            return Force.FromNewtons(left.newtonSecond / right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the division.</returns>
        public static Time operator /(Momentum left, Force right)
        {
            return Time.FromSeconds(left.newtonSecond / right.newtons);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(Momentum left, Speed right)
        {
            return Energy.FromJoules(left.newtonSecond * right.metresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Mass"/> that is the result from the division.</returns>
        public static Mass operator /(Momentum left, Speed right)
        {
            return Mass.FromKilograms(left.newtonSecond / right.metresPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the multiplication.</returns>
        public static Force operator *(Momentum left, Frequency right)
        {
            return Force.FromNewtons(left.newtonSecond * right.hertz);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Power"/> that is the result from the multiplication.</returns>
        public static Power operator *(Momentum left, Acceleration right)
        {
            return Power.FromWatts(left.newtonSecond * right.metresPerSecondSquared);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AreaDensity"/> that is the result from the division.</returns>
        public static AreaDensity operator /(Momentum left, VolumetricFlow right)
        {
            return AreaDensity.FromKilogramsPerSquareMetre(left.newtonSecond / right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the multiplication.</returns>
        public static MassFlow operator *(Momentum left, Wavenumber right)
        {
            return MassFlow.FromKilogramsPerSecond(left.newtonSecond * right.reciprocalMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="VolumetricFlow"/> that is the result from the division.</returns>
        public static VolumetricFlow operator /(Momentum left, AreaDensity right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.newtonSecond / right.kilogramsPerSquareMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the division.</returns>
        public static Length operator /(Momentum left, MassFlow right)
        {
            return Length.FromMetres(left.newtonSecond / right.kilogramsPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Momentum left, Momentum right)
        {
            return left.newtonSecond / right.newtonSecond;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Momentum"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static bool operator ==(Momentum left, Momentum right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Momentum"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static bool operator !=(Momentum left, Momentum right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Momentum"/> is less than another specified <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static bool operator <(Momentum left, Momentum right)
        {
            return left.newtonSecond < right.newtonSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Momentum"/> is greater than another specified <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static bool operator >(Momentum left, Momentum right)
        {
            return left.newtonSecond > right.newtonSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Momentum"/> is less than or equal to another specified <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static bool operator <=(Momentum left, Momentum right)
        {
            return left.newtonSecond <= right.newtonSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Momentum"/> is greater than or equal to another specified <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static bool operator >=(Momentum left, Momentum right)
        {
            return left.newtonSecond >= right.newtonSecond;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Momentum"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Momentum"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Momentum"/> and returns the result.</returns>
        public static Momentum operator *(double left, Momentum right)
        {
            return new Momentum(left * right.newtonSecond);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Momentum"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Momentum"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Momentum"/> with <paramref name="right"/> and returns the result.</returns>
        public static Momentum operator *(Momentum left, double right)
        {
            return new Momentum(left.newtonSecond * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Momentum"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Momentum"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Momentum"/> by <paramref name="right"/> and returns the result.</returns>
        public static Momentum operator /(Momentum left, double right)
        {
            return new Momentum(left.newtonSecond / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Momentum"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Momentum"/> whose quantity is the sum of the quantities of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Momentum"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Momentum"/>.</param>
        public static Momentum operator +(Momentum left, Momentum right)
        {
            return new Momentum(left.newtonSecond + right.newtonSecond);
        }

        /// <summary>
        /// Subtracts an Momentum from another Momentum and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Momentum"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Momentum"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Momentum"/> (the subtrahend).</param>
        public static Momentum operator -(Momentum left, Momentum right)
        {
            return new Momentum(left.newtonSecond - right.newtonSecond);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Momentum"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Momentum"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="momentum">An instance of <see cref="Gu.Units.Momentum"/></param>
        public static Momentum operator -(Momentum momentum)
        {
            return new Momentum(-1 * momentum.newtonSecond);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="momentum"/>.
        /// </returns>
        /// <param name="momentum">An instance of <see cref="Gu.Units.Momentum"/></param>
        public static Momentum operator +(Momentum momentum)
        {
            return momentum;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <returns>The <see cref="Gu.Units.Momentum"/> parsed from <paramref name="text"/></returns>
        public static Momentum Parse(string text)
        {
            return QuantityParser.Parse<MomentumUnit, Momentum>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Momentum"/> parsed from <paramref name="text"/></returns>
        public static Momentum Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<MomentumUnit, Momentum>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Momentum"/> parsed from <paramref name="text"/></returns>
        public static Momentum Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<MomentumUnit, Momentum>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Momentum"/> parsed from <paramref name="text"/></returns>
        public static Momentum Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<MomentumUnit, Momentum>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <param name="result">The parsed <see cref="Momentum"/></param>
        /// <returns>True if an instance of <see cref="Momentum"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Momentum result)
        {
            return QuantityParser.TryParse<MomentumUnit, Momentum>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Momentum"/></param>
        /// <returns>True if an instance of <see cref="Momentum"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Momentum result)
        {
            return QuantityParser.TryParse<MomentumUnit, Momentum>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Momentum"/></param>
        /// <returns>True if an instance of <see cref="Momentum"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Momentum result)
        {
            return QuantityParser.TryParse<MomentumUnit, Momentum>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Momentum"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Momentum"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Momentum"/></param>
        /// <returns>True if an instance of <see cref="Momentum"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Momentum result)
        {
            return QuantityParser.TryParse<MomentumUnit, Momentum>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Momentum"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Momentum"/></returns>
        public static Momentum ReadFrom(XmlReader reader)
        {
            var v = default(Momentum);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Momentum"/></returns>
        public static Momentum From(double value, MomentumUnit unit)
        {
            return new Momentum(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Momentum"/>.
        /// </summary>
        /// <param name="newtonSecond">The value in <see cref="Gu.Units.MomentumUnit.NewtonSecond"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Momentum"/></returns>
        public static Momentum FromNewtonSecond(double newtonSecond)
        {
            return new Momentum(newtonSecond);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(MomentumUnit unit)
        {
            return unit.FromSiUnit(this.newtonSecond);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Momentum"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Momentum"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N⋅s\"</param>
        /// <returns>The string representation of the <see cref="Momentum"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N⋅s\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Momentum"/></returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex N⋅s</param>
        /// <returns>The string representation of the <see cref="Momentum"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider?)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex N⋅s</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="Momentum"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MomentumUnit unit)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MomentumUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MomentumUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MomentumUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MomentumUnit unit)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MomentumUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MomentumUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, MomentumUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MomentumUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Momentum"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Momentum"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Momentum"/> object to compare to this instance.</param>
        public int CompareTo(Momentum quantity)
        {
            return this.newtonSecond.CompareTo(quantity.newtonSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Momentum"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Momentum as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Momentum"/> object to compare with this instance.</param>
        public bool Equals(Momentum other)
        {
            return this.newtonSecond.Equals(other.newtonSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Momentum"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Momentum as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Momentum"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Momentum other, Momentum tolerance)
        {
            Ensure.GreaterThan(tolerance.newtonSecond, 0, nameof(tolerance));
            return Math.Abs(this.newtonSecond - other.newtonSecond) < tolerance.newtonSecond;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Momentum"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Momentum"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is Momentum other && this.Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.newtonSecond.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "newtonSecond", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.newtonSecond);
        }

        internal string ToString(QuantityFormat<MomentumUnit> format, IFormatProvider? formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
