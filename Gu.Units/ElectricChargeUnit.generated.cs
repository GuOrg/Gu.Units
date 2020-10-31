#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.ElectricCharge"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ElectricChargeUnitTypeConverter))]
    public struct ElectricChargeUnit : IUnit, IUnit<ElectricCharge>, IEquatable<ElectricChargeUnit>
    {
        /// <summary>
        /// The Coulombs unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Coulombs = new ElectricChargeUnit(coulombs => coulombs, coulombs => coulombs, "C");

        /// <summary>
        /// The Nanocoulombs unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Nanocoulombs = new ElectricChargeUnit(nanocoulombs => nanocoulombs / 1000000000, coulombs => 1000000000 * coulombs, "nC");

        /// <summary>
        /// The Microcoulombs unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Microcoulombs = new ElectricChargeUnit(microcoulombs => microcoulombs / 1000000, coulombs => 1000000 * coulombs, "μC");

        /// <summary>
        /// The Millicoulombs unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Millicoulombs = new ElectricChargeUnit(millicoulombs => millicoulombs / 1000, coulombs => 1000 * coulombs, "mC");

        /// <summary>
        /// The Kilocoulombs unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Kilocoulombs = new ElectricChargeUnit(kilocoulombs => 1000 * kilocoulombs, coulombs => coulombs / 1000, "kC");

        /// <summary>
        /// The Megacoulombs unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Megacoulombs = new ElectricChargeUnit(megacoulombs => 1000000 * megacoulombs, coulombs => coulombs / 1000000, "MC");

        /// <summary>
        /// The Gigacoulombs unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Gigacoulombs = new ElectricChargeUnit(gigacoulombs => 1000000000 * gigacoulombs, coulombs => coulombs / 1000000000, "GC");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.ElectricChargeUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toCoulombs;
        private readonly Func<double, double> fromCoulombs;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElectricChargeUnit"/> struct.
        /// </summary>
        /// <param name="toCoulombs">The conversion to <see cref="Coulombs"/></param>
        /// <param name="fromCoulombs">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Coulombs"/></param>
        public ElectricChargeUnit(Func<double, double> toCoulombs, Func<double, double> fromCoulombs, string symbol)
        {
            this.toCoulombs = toCoulombs;
            this.fromCoulombs = fromCoulombs;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.ElectricChargeUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.ElectricChargeUnit"/>
        /// </summary>
        public ElectricChargeUnit SiUnit => Coulombs;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Coulombs;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricCharge"/> that is the result from the multiplication.</returns>
        public static ElectricCharge operator *(double left, ElectricChargeUnit right)
        {
            return ElectricCharge.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ElectricChargeUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ElectricChargeUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ElectricChargeUnit"/>.</param>
        public static bool operator ==(ElectricChargeUnit left, ElectricChargeUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ElectricChargeUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ElectricChargeUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ElectricChargeUnit"/>.</param>
        public static bool operator !=(ElectricChargeUnit left, ElectricChargeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="ElectricChargeUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="ElectricChargeUnit"/></returns>
        public static ElectricChargeUnit Parse(string text)
        {
            return UnitParser<ElectricChargeUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricChargeUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricChargeUnit"/></param>
        /// <param name="result">The parsed <see cref="ElectricChargeUnit"/></param>
        /// <returns>True if an instance of <see cref="ElectricChargeUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out ElectricChargeUnit result)
        {
            return UnitParser<ElectricChargeUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Coulombs.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toCoulombs(value);
        }

        /// <summary>
        /// Converts a value from coulombs.
        /// </summary>
        /// <param name="coulombs">The value in Coulombs</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double coulombs)
        {
            return this.fromCoulombs(coulombs);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new ElectricCharge(<paramref name="value"/>, this)</returns>
        public ElectricCharge CreateQuantity(double value)
        {
            return new ElectricCharge(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Coulombs
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(ElectricCharge quantity)
        {
            return this.FromSiUnit(quantity.coulombs);
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
            ElectricChargeUnit unit;
            var paddedFormat = UnitFormatCache<ElectricChargeUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<ElectricChargeUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.ElectricChargeUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.ElectricChargeUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same ElectricChargeUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(ElectricChargeUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is ElectricChargeUnit other && this.Equals(other);
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
