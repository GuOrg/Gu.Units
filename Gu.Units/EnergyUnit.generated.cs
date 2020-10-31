namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Energy"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(EnergyUnitTypeConverter))]
    public struct EnergyUnit : IUnit, IUnit<Energy>, IEquatable<EnergyUnit>
    {
        /// <summary>
        /// The Joules unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly EnergyUnit Joules = new EnergyUnit(joules => joules, joules => joules, "J");

        /// <summary>
        /// The Nanojoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Nanojoules = new EnergyUnit(nanojoules => nanojoules / 1000000000, joules => 1000000000 * joules, "nJ");

        /// <summary>
        /// The Microjoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Microjoules = new EnergyUnit(microjoules => microjoules / 1000000, joules => 1000000 * joules, "μJ");

        /// <summary>
        /// The Millijoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Millijoules = new EnergyUnit(millijoules => millijoules / 1000, joules => 1000 * joules, "mJ");

        /// <summary>
        /// The Kilojoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Kilojoules = new EnergyUnit(kilojoules => 1000 * kilojoules, joules => joules / 1000, "kJ");

        /// <summary>
        /// The Megajoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Megajoules = new EnergyUnit(megajoules => 1000000 * megajoules, joules => joules / 1000000, "MJ");

        /// <summary>
        /// The Gigajoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Gigajoules = new EnergyUnit(gigajoules => 1000000000 * gigajoules, joules => joules / 1000000000, "GJ");

        /// <summary>
        /// The KilowattHours unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit KilowattHours = new EnergyUnit(kilowattHours => 3600000 * kilowattHours, joules => joules / 3600000, "kWh");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.EnergyUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toJoules;
        private readonly Func<double, double> fromJoules;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyUnit"/> struct.
        /// </summary>
        /// <param name="toJoules">The conversion to <see cref="Joules"/></param>
        /// <param name="fromJoules">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Joules"/></param>
        public EnergyUnit(Func<double, double> toJoules, Func<double, double> fromJoules, string symbol)
        {
            this.toJoules = toJoules;
            this.fromJoules = fromJoules;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.EnergyUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.EnergyUnit"/>
        /// </summary>
        public EnergyUnit SiUnit => Joules;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Joules;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(double left, EnergyUnit right)
        {
            return Energy.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.EnergyUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.EnergyUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.EnergyUnit"/>.</param>
        public static bool operator ==(EnergyUnit left, EnergyUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.EnergyUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.EnergyUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.EnergyUnit"/>.</param>
        public static bool operator !=(EnergyUnit left, EnergyUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="EnergyUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="EnergyUnit"/></returns>
        public static EnergyUnit Parse(string text)
        {
            return UnitParser<EnergyUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.EnergyUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.EnergyUnit"/></param>
        /// <param name="result">The parsed <see cref="EnergyUnit"/></param>
        /// <returns>True if an instance of <see cref="EnergyUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out EnergyUnit result)
        {
            return UnitParser<EnergyUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Joules.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toJoules(value);
        }

        /// <summary>
        /// Converts a value from joules.
        /// </summary>
        /// <param name="joules">The value in Joules</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double joules)
        {
            return this.fromJoules(joules);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Energy(<paramref name="value"/>, this)</returns>
        public Energy CreateQuantity(double value)
        {
            return new Energy(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Joules
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Energy quantity)
        {
            return this.FromSiUnit(quantity.joules);
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
            EnergyUnit unit;
            var paddedFormat = UnitFormatCache<EnergyUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<EnergyUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.EnergyUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.EnergyUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same EnergyUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(EnergyUnit other)
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

            return obj is EnergyUnit && this.Equals((EnergyUnit)obj);
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
