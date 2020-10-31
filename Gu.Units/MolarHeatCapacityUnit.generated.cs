namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.MolarHeatCapacity"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(MolarHeatCapacityUnitTypeConverter))]
    public struct MolarHeatCapacityUnit : IUnit, IUnit<MolarHeatCapacity>, IEquatable<MolarHeatCapacityUnit>
    {
        /// <summary>
        /// The JoulesPerKelvinMole unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly MolarHeatCapacityUnit JoulesPerKelvinMole = new MolarHeatCapacityUnit(joulesPerKelvinMole => joulesPerKelvinMole, joulesPerKelvinMole => joulesPerKelvinMole, "J/K⋅mol");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.MolarHeatCapacityUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toJoulesPerKelvinMole;
        private readonly Func<double, double> fromJoulesPerKelvinMole;

        /// <summary>
        /// Initializes a new instance of the <see cref="MolarHeatCapacityUnit"/> struct.
        /// </summary>
        /// <param name="toJoulesPerKelvinMole">The conversion to <see cref="JoulesPerKelvinMole"/></param>
        /// <param name="fromJoulesPerKelvinMole">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="JoulesPerKelvinMole"/></param>
        public MolarHeatCapacityUnit(Func<double, double> toJoulesPerKelvinMole, Func<double, double> fromJoulesPerKelvinMole, string symbol)
        {
            this.toJoulesPerKelvinMole = toJoulesPerKelvinMole;
            this.fromJoulesPerKelvinMole = fromJoulesPerKelvinMole;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.MolarHeatCapacityUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.MolarHeatCapacityUnit"/>
        /// </summary>
        public MolarHeatCapacityUnit SiUnit => JoulesPerKelvinMole;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => JoulesPerKelvinMole;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MolarHeatCapacity"/> that is the result from the multiplication.</returns>
        public static MolarHeatCapacity operator *(double left, MolarHeatCapacityUnit right)
        {
            return MolarHeatCapacity.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MolarHeatCapacityUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MolarHeatCapacityUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MolarHeatCapacityUnit"/>.</param>
        public static bool operator ==(MolarHeatCapacityUnit left, MolarHeatCapacityUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MolarHeatCapacityUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MolarHeatCapacityUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MolarHeatCapacityUnit"/>.</param>
        public static bool operator !=(MolarHeatCapacityUnit left, MolarHeatCapacityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="MolarHeatCapacityUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="MolarHeatCapacityUnit"/></returns>
        public static MolarHeatCapacityUnit Parse(string text)
        {
            return UnitParser<MolarHeatCapacityUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarHeatCapacityUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarHeatCapacityUnit"/></param>
        /// <param name="result">The parsed <see cref="MolarHeatCapacityUnit"/></param>
        /// <returns>True if an instance of <see cref="MolarHeatCapacityUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out MolarHeatCapacityUnit result)
        {
            return UnitParser<MolarHeatCapacityUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to JoulesPerKelvinMole.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toJoulesPerKelvinMole(value);
        }

        /// <summary>
        /// Converts a value from joulesPerKelvinMole.
        /// </summary>
        /// <param name="joulesPerKelvinMole">The value in JoulesPerKelvinMole</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double joulesPerKelvinMole)
        {
            return this.fromJoulesPerKelvinMole(joulesPerKelvinMole);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new MolarHeatCapacity(<paramref name="value"/>, this)</returns>
        public MolarHeatCapacity CreateQuantity(double value)
        {
            return new MolarHeatCapacity(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in JoulesPerKelvinMole
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(MolarHeatCapacity quantity)
        {
            return this.FromSiUnit(quantity.joulesPerKelvinMole);
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
            MolarHeatCapacityUnit unit;
            var paddedFormat = UnitFormatCache<MolarHeatCapacityUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<MolarHeatCapacityUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MolarHeatCapacityUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.MolarHeatCapacityUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MolarHeatCapacityUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(MolarHeatCapacityUnit other)
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

            return obj is MolarHeatCapacityUnit && this.Equals((MolarHeatCapacityUnit)obj);
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
