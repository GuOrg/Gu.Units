namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.ForcePerUnitless"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ForcePerUnitlessUnitTypeConverter))]
    public struct ForcePerUnitlessUnit : IUnit, IUnit<ForcePerUnitless>, IEquatable<ForcePerUnitlessUnit>
    {
        /// <summary>
        /// The NewtonsPerUnitless unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly ForcePerUnitlessUnit NewtonsPerUnitless = new ForcePerUnitlessUnit(newtonsPerUnitless => newtonsPerUnitless, newtonsPerUnitless => newtonsPerUnitless, "N/ul");

        /// <summary>
        /// The NewtonsPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForcePerUnitlessUnit NewtonsPerPercent = new ForcePerUnitlessUnit(newtonsPerPercent => 100 * newtonsPerPercent, newtonsPerUnitless => newtonsPerUnitless / 100, "N/%");

        /// <summary>
        /// The KilonewtonsPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForcePerUnitlessUnit KilonewtonsPerPercent = new ForcePerUnitlessUnit(kilonewtonsPerPercent => 100000 * kilonewtonsPerPercent, newtonsPerUnitless => newtonsPerUnitless / 100000, "kN/%");

        /// <summary>
        /// The MeganewtonsPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForcePerUnitlessUnit MeganewtonsPerPercent = new ForcePerUnitlessUnit(meganewtonsPerPercent => 100000000 * meganewtonsPerPercent, newtonsPerUnitless => newtonsPerUnitless / 100000000, "MN/%");

        /// <summary>
        /// The GiganewtonsPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForcePerUnitlessUnit GiganewtonsPerPercent = new ForcePerUnitlessUnit(giganewtonsPerPercent => 100000000000 * giganewtonsPerPercent, newtonsPerUnitless => newtonsPerUnitless / 100000000000, "GN/%");

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.ForcePerUnitlessUnit"/>.
        /// </summary>
        internal readonly string symbol;

        private readonly Func<double, double> toNewtonsPerUnitless;
        private readonly Func<double, double> fromNewtonsPerUnitless;

        /// <summary>
        /// Initializes a new instance of the <see cref="ForcePerUnitlessUnit"/> struct.
        /// </summary>
        /// <param name="toNewtonsPerUnitless">The conversion to <see cref="NewtonsPerUnitless"/></param>
        /// <param name="fromNewtonsPerUnitless">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="NewtonsPerUnitless"/></param>
        public ForcePerUnitlessUnit(Func<double, double> toNewtonsPerUnitless, Func<double, double> fromNewtonsPerUnitless, string symbol)
        {
            this.toNewtonsPerUnitless = toNewtonsPerUnitless;
            this.fromNewtonsPerUnitless = fromNewtonsPerUnitless;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.ForcePerUnitlessUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.ForcePerUnitlessUnit"/>
        /// </summary>
        public ForcePerUnitlessUnit SiUnit => NewtonsPerUnitless;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => NewtonsPerUnitless;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ForcePerUnitless"/> that is the result from the multiplication.</returns>
        public static ForcePerUnitless operator *(double left, ForcePerUnitlessUnit right)
        {
            return ForcePerUnitless.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ForcePerUnitlessUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ForcePerUnitlessUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ForcePerUnitlessUnit"/>.</param>
        public static bool operator ==(ForcePerUnitlessUnit left, ForcePerUnitlessUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ForcePerUnitlessUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ForcePerUnitlessUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ForcePerUnitlessUnit"/>.</param>
        public static bool operator !=(ForcePerUnitlessUnit left, ForcePerUnitlessUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="ForcePerUnitlessUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="ForcePerUnitlessUnit"/></returns>
        public static ForcePerUnitlessUnit Parse(string text)
        {
            return UnitParser<ForcePerUnitlessUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ForcePerUnitlessUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ForcePerUnitlessUnit"/></param>
        /// <param name="result">The parsed <see cref="ForcePerUnitlessUnit"/></param>
        /// <returns>True if an instance of <see cref="ForcePerUnitlessUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out ForcePerUnitlessUnit result)
        {
            return UnitParser<ForcePerUnitlessUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to NewtonsPerUnitless.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toNewtonsPerUnitless(value);
        }

        /// <summary>
        /// Converts a value from newtonsPerUnitless.
        /// </summary>
        /// <param name="newtonsPerUnitless">The value in NewtonsPerUnitless</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double newtonsPerUnitless)
        {
            return this.fromNewtonsPerUnitless(newtonsPerUnitless);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new ForcePerUnitless(<paramref name="value"/>, this)</returns>
        public ForcePerUnitless CreateQuantity(double value)
        {
            return new ForcePerUnitless(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in NewtonsPerUnitless
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(ForcePerUnitless quantity)
        {
            return this.FromSiUnit(quantity.newtonsPerUnitless);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.symbol;
        }

        /// <summary>
        /// Converts the unit value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="format">The format to use when convereting</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string format)
        {
            ForcePerUnitlessUnit unit;
            var paddedFormat = UnitFormatCache<ForcePerUnitlessUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<ForcePerUnitlessUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.ForcePerUnitlessUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.ForcePerUnitlessUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same ForcePerUnitlessUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(ForcePerUnitlessUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ForcePerUnitlessUnit && this.Equals((ForcePerUnitlessUnit)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            if (this.symbol == null)
            {
                return 0; // Needed due to default ctor
            }

            return this.symbol.GetHashCode();
        }
    }
}