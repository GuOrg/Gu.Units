#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Stiffness"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(StiffnessUnitTypeConverter))]
    public struct StiffnessUnit : IUnit, IUnit<Stiffness>, IEquatable<StiffnessUnit>
    {
        /// <summary>
        /// The NewtonsPerMetre unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly StiffnessUnit NewtonsPerMetre = new StiffnessUnit(newtonsPerMetre => newtonsPerMetre, newtonsPerMetre => newtonsPerMetre, "N/m");

        /// <summary>
        /// The NewtonsPerNanometre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly StiffnessUnit NewtonsPerNanometre = new StiffnessUnit(newtonsPerNanometre => 1000000000 * newtonsPerNanometre, newtonsPerMetre => newtonsPerMetre / 1000000000, "N/nm");

        /// <summary>
        /// The NewtonsPerMicrometre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly StiffnessUnit NewtonsPerMicrometre = new StiffnessUnit(newtonsPerMicrometre => 1000000 * newtonsPerMicrometre, newtonsPerMetre => newtonsPerMetre / 1000000, "N/μm");

        /// <summary>
        /// The NewtonsPerMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly StiffnessUnit NewtonsPerMillimetre = new StiffnessUnit(newtonsPerMillimetre => 1000 * newtonsPerMillimetre, newtonsPerMetre => newtonsPerMetre / 1000, "N/mm");

        /// <summary>
        /// The KilonewtonsPerNanometre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly StiffnessUnit KilonewtonsPerNanometre = new StiffnessUnit(kilonewtonsPerNanometre => 1000000000000 * kilonewtonsPerNanometre, newtonsPerMetre => newtonsPerMetre / 1000000000000, "kN/nm");

        /// <summary>
        /// The KilonewtonsPerMicrometre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly StiffnessUnit KilonewtonsPerMicrometre = new StiffnessUnit(kilonewtonsPerMicrometre => 1000000000 * kilonewtonsPerMicrometre, newtonsPerMetre => newtonsPerMetre / 1000000000, "kN/μm");

        /// <summary>
        /// The KilonewtonsPerMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly StiffnessUnit KilonewtonsPerMillimetre = new StiffnessUnit(kilonewtonsPerMillimetre => 1000000 * kilonewtonsPerMillimetre, newtonsPerMetre => newtonsPerMetre / 1000000, "kN/mm");

        /// <summary>
        /// The MeganewtonsPerNanometre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly StiffnessUnit MeganewtonsPerNanometre = new StiffnessUnit(meganewtonsPerNanometre => 1000000000000000 * meganewtonsPerNanometre, newtonsPerMetre => newtonsPerMetre / 1000000000000000, "MN/nm");

        /// <summary>
        /// The MeganewtonsPerMicrometre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly StiffnessUnit MeganewtonsPerMicrometre = new StiffnessUnit(meganewtonsPerMicrometre => 1000000000000 * meganewtonsPerMicrometre, newtonsPerMetre => newtonsPerMetre / 1000000000000, "MN/μm");

        /// <summary>
        /// The MeganewtonsPerMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly StiffnessUnit MeganewtonsPerMillimetre = new StiffnessUnit(meganewtonsPerMillimetre => 1000000000 * meganewtonsPerMillimetre, newtonsPerMetre => newtonsPerMetre / 1000000000, "MN/mm");

        /// <summary>
        /// The GiganewtonsPerMicrometre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly StiffnessUnit GiganewtonsPerMicrometre = new StiffnessUnit(giganewtonsPerMicrometre => 1000000000000000 * giganewtonsPerMicrometre, newtonsPerMetre => newtonsPerMetre / 1000000000000000, "GN/μm");

        /// <summary>
        /// The GiganewtonsPerMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly StiffnessUnit GiganewtonsPerMillimetre = new StiffnessUnit(giganewtonsPerMillimetre => 1000000000000 * giganewtonsPerMillimetre, newtonsPerMetre => newtonsPerMetre / 1000000000000, "GN/mm");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.StiffnessUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toNewtonsPerMetre;
        private readonly Func<double, double> fromNewtonsPerMetre;

        /// <summary>
        /// Initializes a new instance of the <see cref="StiffnessUnit"/> struct.
        /// </summary>
        /// <param name="toNewtonsPerMetre">The conversion to <see cref="NewtonsPerMetre"/></param>
        /// <param name="fromNewtonsPerMetre">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="NewtonsPerMetre"/></param>
        public StiffnessUnit(Func<double, double> toNewtonsPerMetre, Func<double, double> fromNewtonsPerMetre, string symbol)
        {
            this.toNewtonsPerMetre = toNewtonsPerMetre;
            this.fromNewtonsPerMetre = fromNewtonsPerMetre;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.StiffnessUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.StiffnessUnit"/>
        /// </summary>
        public StiffnessUnit SiUnit => NewtonsPerMetre;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => NewtonsPerMetre;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the multiplication.</returns>
        public static Stiffness operator *(double left, StiffnessUnit right)
        {
            return Stiffness.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.StiffnessUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.StiffnessUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.StiffnessUnit"/>.</param>
        public static bool operator ==(StiffnessUnit left, StiffnessUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.StiffnessUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.StiffnessUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.StiffnessUnit"/>.</param>
        public static bool operator !=(StiffnessUnit left, StiffnessUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="StiffnessUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="StiffnessUnit"/></returns>
        public static StiffnessUnit Parse(string text)
        {
            return UnitParser<StiffnessUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.StiffnessUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.StiffnessUnit"/></param>
        /// <param name="result">The parsed <see cref="StiffnessUnit"/></param>
        /// <returns>True if an instance of <see cref="StiffnessUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out StiffnessUnit result)
        {
            return UnitParser<StiffnessUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to NewtonsPerMetre.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toNewtonsPerMetre(value);
        }

        /// <summary>
        /// Converts a value from newtonsPerMetre.
        /// </summary>
        /// <param name="newtonsPerMetre">The value in NewtonsPerMetre</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double newtonsPerMetre)
        {
            return this.fromNewtonsPerMetre(newtonsPerMetre);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Stiffness(<paramref name="value"/>, this)</returns>
        public Stiffness CreateQuantity(double value)
        {
            return new Stiffness(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in NewtonsPerMetre
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Stiffness quantity)
        {
            return this.FromSiUnit(quantity.newtonsPerMetre);
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
            StiffnessUnit unit;
            var paddedFormat = UnitFormatCache<StiffnessUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<StiffnessUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.StiffnessUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.StiffnessUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same StiffnessUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(StiffnessUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is StiffnessUnit other && this.Equals(other);
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
