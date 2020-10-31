#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Conductivity"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ConductivityUnitTypeConverter))]
    public struct ConductivityUnit : IUnit, IUnit<Conductivity>, IEquatable<ConductivityUnit>
    {
        /// <summary>
        /// The SiemensPerMetre unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly ConductivityUnit SiemensPerMetre = new ConductivityUnit(siemensPerMetre => siemensPerMetre, siemensPerMetre => siemensPerMetre, "S/m");

        /// <summary>
        /// The SiemensPerCentimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ConductivityUnit SiemensPerCentimetre = new ConductivityUnit(siemensPerCentimetre => 100 * siemensPerCentimetre, siemensPerMetre => siemensPerMetre / 100, "S/cm");

        /// <summary>
        /// The SiemensPerMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ConductivityUnit SiemensPerMillimetre = new ConductivityUnit(siemensPerMillimetre => 1000 * siemensPerMillimetre, siemensPerMetre => siemensPerMetre / 1000, "S/mm");

        /// <summary>
        /// The NanosiemensPerMetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ConductivityUnit NanosiemensPerMetre = new ConductivityUnit(nanosiemensPerMetre => nanosiemensPerMetre / 1000000000, siemensPerMetre => 1000000000 * siemensPerMetre, "nS/m");

        /// <summary>
        /// The NanosiemensPerMicrometre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ConductivityUnit NanosiemensPerMicrometre = new ConductivityUnit(nanosiemensPerMicrometre => nanosiemensPerMicrometre / 1000, siemensPerMetre => 1000 * siemensPerMetre, "nS/μm");

        /// <summary>
        /// The NanosiemensPerMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ConductivityUnit NanosiemensPerMillimetre = new ConductivityUnit(nanosiemensPerMillimetre => nanosiemensPerMillimetre / 1000000, siemensPerMetre => 1000000 * siemensPerMetre, "nS/mm");

        /// <summary>
        /// The NanosiemensPerCentimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ConductivityUnit NanosiemensPerCentimetre = new ConductivityUnit(nanosiemensPerCentimetre => nanosiemensPerCentimetre / 10000000, siemensPerMetre => 10000000 * siemensPerMetre, "nS/cm");

        /// <summary>
        /// The MicrosiemensPerMetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ConductivityUnit MicrosiemensPerMetre = new ConductivityUnit(microsiemensPerMetre => microsiemensPerMetre / 1000000, siemensPerMetre => 1000000 * siemensPerMetre, "μS/m");

        /// <summary>
        /// The MicrosiemensPerMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ConductivityUnit MicrosiemensPerMillimetre = new ConductivityUnit(microsiemensPerMillimetre => microsiemensPerMillimetre / 1000, siemensPerMetre => 1000 * siemensPerMetre, "μS/mm");

        /// <summary>
        /// The MicrosiemensPerCentimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ConductivityUnit MicrosiemensPerCentimetre = new ConductivityUnit(microsiemensPerCentimetre => microsiemensPerCentimetre / 10000, siemensPerMetre => 10000 * siemensPerMetre, "μS/cm");

        /// <summary>
        /// The MillisiemensPerMetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ConductivityUnit MillisiemensPerMetre = new ConductivityUnit(millisiemensPerMetre => millisiemensPerMetre / 1000, siemensPerMetre => 1000 * siemensPerMetre, "mS/m");

        /// <summary>
        /// The MillisiemensPerMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ConductivityUnit MillisiemensPerMillimetre = new ConductivityUnit(millisiemensPerMillimetre => millisiemensPerMillimetre, siemensPerMetre => siemensPerMetre, "mS/mm");

        /// <summary>
        /// The MillisiemensPerCentimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ConductivityUnit MillisiemensPerCentimetre = new ConductivityUnit(millisiemensPerCentimetre => millisiemensPerCentimetre / 10, siemensPerMetre => 10 * siemensPerMetre, "mS/cm");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.ConductivityUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toSiemensPerMetre;
        private readonly Func<double, double> fromSiemensPerMetre;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConductivityUnit"/> struct.
        /// </summary>
        /// <param name="toSiemensPerMetre">The conversion to <see cref="SiemensPerMetre"/></param>
        /// <param name="fromSiemensPerMetre">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="SiemensPerMetre"/></param>
        public ConductivityUnit(Func<double, double> toSiemensPerMetre, Func<double, double> fromSiemensPerMetre, string symbol)
        {
            this.toSiemensPerMetre = toSiemensPerMetre;
            this.fromSiemensPerMetre = fromSiemensPerMetre;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.ConductivityUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.ConductivityUnit"/>
        /// </summary>
        public ConductivityUnit SiUnit => SiemensPerMetre;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => SiemensPerMetre;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Conductivity"/> that is the result from the multiplication.</returns>
        public static Conductivity operator *(double left, ConductivityUnit right)
        {
            return Conductivity.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ConductivityUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ConductivityUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ConductivityUnit"/>.</param>
        public static bool operator ==(ConductivityUnit left, ConductivityUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ConductivityUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ConductivityUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ConductivityUnit"/>.</param>
        public static bool operator !=(ConductivityUnit left, ConductivityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="ConductivityUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="ConductivityUnit"/></returns>
        public static ConductivityUnit Parse(string text)
        {
            return UnitParser<ConductivityUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ConductivityUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ConductivityUnit"/></param>
        /// <param name="result">The parsed <see cref="ConductivityUnit"/></param>
        /// <returns>True if an instance of <see cref="ConductivityUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out ConductivityUnit result)
        {
            return UnitParser<ConductivityUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to SiemensPerMetre.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toSiemensPerMetre(value);
        }

        /// <summary>
        /// Converts a value from siemensPerMetre.
        /// </summary>
        /// <param name="siemensPerMetre">The value in SiemensPerMetre</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double siemensPerMetre)
        {
            return this.fromSiemensPerMetre(siemensPerMetre);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Conductivity(<paramref name="value"/>, this)</returns>
        public Conductivity CreateQuantity(double value)
        {
            return new Conductivity(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in SiemensPerMetre
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Conductivity quantity)
        {
            return this.FromSiUnit(quantity.siemensPerMetre);
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
            ConductivityUnit unit;
            var paddedFormat = UnitFormatCache<ConductivityUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<ConductivityUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.ConductivityUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.ConductivityUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same ConductivityUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(ConductivityUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is ConductivityUnit other && this.Equals(other);
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
