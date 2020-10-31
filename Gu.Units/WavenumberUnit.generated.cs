#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Wavenumber"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(WavenumberUnitTypeConverter))]
    public struct WavenumberUnit : IUnit, IUnit<Wavenumber>, IEquatable<WavenumberUnit>
    {
        /// <summary>
        /// The ReciprocalMetres unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly WavenumberUnit ReciprocalMetres = new WavenumberUnit(reciprocalMetres => reciprocalMetres, reciprocalMetres => reciprocalMetres, "m⁻¹");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.WavenumberUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toReciprocalMetres;
        private readonly Func<double, double> fromReciprocalMetres;

        /// <summary>
        /// Initializes a new instance of the <see cref="WavenumberUnit"/> struct.
        /// </summary>
        /// <param name="toReciprocalMetres">The conversion to <see cref="ReciprocalMetres"/></param>
        /// <param name="fromReciprocalMetres">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="ReciprocalMetres"/></param>
        public WavenumberUnit(Func<double, double> toReciprocalMetres, Func<double, double> fromReciprocalMetres, string symbol)
        {
            this.toReciprocalMetres = toReciprocalMetres;
            this.fromReciprocalMetres = fromReciprocalMetres;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.WavenumberUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.WavenumberUnit"/>
        /// </summary>
        public WavenumberUnit SiUnit => ReciprocalMetres;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => ReciprocalMetres;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Wavenumber"/> that is the result from the multiplication.</returns>
        public static Wavenumber operator *(double left, WavenumberUnit right)
        {
            return Wavenumber.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.WavenumberUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.WavenumberUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.WavenumberUnit"/>.</param>
        public static bool operator ==(WavenumberUnit left, WavenumberUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.WavenumberUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.WavenumberUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.WavenumberUnit"/>.</param>
        public static bool operator !=(WavenumberUnit left, WavenumberUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="WavenumberUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="WavenumberUnit"/></returns>
        public static WavenumberUnit Parse(string text)
        {
            return UnitParser<WavenumberUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.WavenumberUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.WavenumberUnit"/></param>
        /// <param name="result">The parsed <see cref="WavenumberUnit"/></param>
        /// <returns>True if an instance of <see cref="WavenumberUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out WavenumberUnit result)
        {
            return UnitParser<WavenumberUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to ReciprocalMetres.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toReciprocalMetres(value);
        }

        /// <summary>
        /// Converts a value from reciprocalMetres.
        /// </summary>
        /// <param name="reciprocalMetres">The value in ReciprocalMetres</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double reciprocalMetres)
        {
            return this.fromReciprocalMetres(reciprocalMetres);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Wavenumber(<paramref name="value"/>, this)</returns>
        public Wavenumber CreateQuantity(double value)
        {
            return new Wavenumber(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in ReciprocalMetres
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Wavenumber quantity)
        {
            return this.FromSiUnit(quantity.reciprocalMetres);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.symbol;
        }

        /// <summary>
        /// Converts the unit value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="format">The format to use when converting</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string format)
        {
            WavenumberUnit unit;
            var paddedFormat = UnitFormatCache<WavenumberUnit>.GetOrCreate(format, out unit);
            if (unit != this)
            {
                return format;
            }

            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Converts the unit value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(SymbolFormat symbolFormat)
        {
            var paddedFormat = UnitFormatCache<WavenumberUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.WavenumberUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.WavenumberUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same WavenumberUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(WavenumberUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is WavenumberUnit other && this.Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            if (this.symbol is null)
            {
                return 0; // Needed due to default constructor
            }

            return this.symbol.GetHashCode();
        }
    }
}
