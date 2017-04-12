namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.MassFlow"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(MassFlowUnitTypeConverter))]
    public struct MassFlowUnit : IUnit, IUnit<MassFlow>, IEquatable<MassFlowUnit>
    {
        /// <summary>
        /// The KilogramsPerSecond unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly MassFlowUnit KilogramsPerSecond = new MassFlowUnit(kilogramsPerSecond => kilogramsPerSecond, kilogramsPerSecond => kilogramsPerSecond, "kg/s");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.MassFlowUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toKilogramsPerSecond;
        private readonly Func<double, double> fromKilogramsPerSecond;

        /// <summary>
        /// Initializes a new instance of the <see cref="MassFlowUnit"/> struct.
        /// </summary>
        /// <param name="toKilogramsPerSecond">The conversion to <see cref="KilogramsPerSecond"/></param>
        /// <param name="fromKilogramsPerSecond">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="KilogramsPerSecond"/></param>
        public MassFlowUnit(Func<double, double> toKilogramsPerSecond, Func<double, double> fromKilogramsPerSecond, string symbol)
        {
            this.toKilogramsPerSecond = toKilogramsPerSecond;
            this.fromKilogramsPerSecond = fromKilogramsPerSecond;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.MassFlowUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.MassFlowUnit"/>
        /// </summary>
        public MassFlowUnit SiUnit => KilogramsPerSecond;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => KilogramsPerSecond;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the multiplication.</returns>
        public static MassFlow operator *(double left, MassFlowUnit right)
        {
            return MassFlow.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MassFlowUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassFlowUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MassFlowUnit"/>.</param>
        public static bool operator ==(MassFlowUnit left, MassFlowUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MassFlowUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MassFlowUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MassFlowUnit"/>.</param>
        public static bool operator !=(MassFlowUnit left, MassFlowUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="MassFlowUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="MassFlowUnit"/></returns>
        public static MassFlowUnit Parse(string text)
        {
            return UnitParser<MassFlowUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlowUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlowUnit"/></param>
        /// <param name="result">The parsed <see cref="MassFlowUnit"/></param>
        /// <returns>True if an instance of <see cref="MassFlowUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out MassFlowUnit result)
        {
            return UnitParser<MassFlowUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to KilogramsPerSecond.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toKilogramsPerSecond(value);
        }

        /// <summary>
        /// Converts a value from kilogramsPerSecond.
        /// </summary>
        /// <param name="kilogramsPerSecond">The value in KilogramsPerSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double kilogramsPerSecond)
        {
            return this.fromKilogramsPerSecond(kilogramsPerSecond);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new MassFlow(<paramref name="value"/>, this)</returns>
        public MassFlow CreateQuantity(double value)
        {
            return new MassFlow(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in KilogramsPerSecond
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(MassFlow quantity)
        {
            return this.FromSiUnit(quantity.kilogramsPerSecond);
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
            MassFlowUnit unit;
            var paddedFormat = UnitFormatCache<MassFlowUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<MassFlowUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MassFlowUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.MassFlowUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MassFlowUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(MassFlowUnit other)
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

            return obj is MassFlowUnit && this.Equals((MassFlowUnit)obj);
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