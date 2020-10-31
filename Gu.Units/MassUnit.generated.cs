#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Mass"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(MassUnitTypeConverter))]
    public struct MassUnit : IUnit, IUnit<Mass>, IEquatable<MassUnit>
    {
        /// <summary>
        /// The Kilograms unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly MassUnit Kilograms = new MassUnit(kilograms => kilograms, kilograms => kilograms, "kg");

        /// <summary>
        /// The Grams unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit Grams = new MassUnit(grams => grams / 1000, kilograms => 1000 * kilograms, "g");

        /// <summary>
        /// The Milligrams unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit Milligrams = new MassUnit(milligrams => milligrams / 1000000, kilograms => 1000000 * kilograms, "mg");

        /// <summary>
        /// The Micrograms unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit Micrograms = new MassUnit(micrograms => micrograms / 1000000000, kilograms => 1000000000 * kilograms, "μg");

        /// <summary>
        /// The AvoirdupoisPounds unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit AvoirdupoisPounds = new MassUnit(avoirdupoisPounds => 0.45359237 * avoirdupoisPounds, kilograms => kilograms / 0.45359237, "lb");

        /// <summary>
        /// The AvoirdupoisOunces unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit AvoirdupoisOunces = new MassUnit(avoirdupoisOunces => 0.028349523125 * avoirdupoisOunces, kilograms => kilograms / 0.028349523125, "oz");

        /// <summary>
        /// The TroyOunces unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit TroyOunces = new MassUnit(troyOunces => 0.0311034768 * troyOunces, kilograms => kilograms / 0.0311034768, "troy");

        /// <summary>
        /// The TroyGrains unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit TroyGrains = new MassUnit(troyGrains => 6.479891E-05 * troyGrains, kilograms => kilograms / 6.479891E-05, "gr");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.MassUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toKilograms;
        private readonly Func<double, double> fromKilograms;

        /// <summary>
        /// Initializes a new instance of the <see cref="MassUnit"/> struct.
        /// </summary>
        /// <param name="toKilograms">The conversion to <see cref="Kilograms"/></param>
        /// <param name="fromKilograms">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Kilograms"/></param>
        public MassUnit(Func<double, double> toKilograms, Func<double, double> fromKilograms, string symbol)
        {
            this.toKilograms = toKilograms;
            this.fromKilograms = fromKilograms;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.MassUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.MassUnit"/>
        /// </summary>
        public MassUnit SiUnit => Kilograms;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Kilograms;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Mass"/> that is the result from the multiplication.</returns>
        public static Mass operator *(double left, MassUnit right)
        {
            return Mass.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MassUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MassUnit"/>.</param>
        public static bool operator ==(MassUnit left, MassUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MassUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MassUnit"/>.</param>
        public static bool operator !=(MassUnit left, MassUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="MassUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="MassUnit"/></returns>
        public static MassUnit Parse(string text)
        {
            return UnitParser<MassUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassUnit"/></param>
        /// <param name="result">The parsed <see cref="MassUnit"/></param>
        /// <returns>True if an instance of <see cref="MassUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out MassUnit result)
        {
            return UnitParser<MassUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Kilograms.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toKilograms(value);
        }

        /// <summary>
        /// Converts a value from kilograms.
        /// </summary>
        /// <param name="kilograms">The value in Kilograms</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double kilograms)
        {
            return this.fromKilograms(kilograms);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Mass(<paramref name="value"/>, this)</returns>
        public Mass CreateQuantity(double value)
        {
            return new Mass(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Kilograms
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Mass quantity)
        {
            return this.FromSiUnit(quantity.kilograms);
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
            MassUnit unit;
            var paddedFormat = UnitFormatCache<MassUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<MassUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MassUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.MassUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MassUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(MassUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is MassUnit other && this.Equals(other);
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
