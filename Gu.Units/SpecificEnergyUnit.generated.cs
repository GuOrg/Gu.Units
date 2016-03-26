namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.SpecificEnergy"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(SpecificEnergyUnitTypeConverter))]
    public struct SpecificEnergyUnit : IUnit, IUnit<SpecificEnergy>, IEquatable<SpecificEnergyUnit>
    {
        /// <summary>
        /// The SpecificEnergyUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly SpecificEnergyUnit JoulesPerKilogram = new SpecificEnergyUnit(joulesPerKilogram => joulesPerKilogram, joulesPerKilogram => joulesPerKilogram, "J/kg");

        private readonly Func<double, double> toJoulesPerKilogram;
        private readonly Func<double, double> fromJoulesPerKilogram;
        internal readonly string symbol;

        public SpecificEnergyUnit(Func<double, double> toJoulesPerKilogram, Func<double, double> fromJoulesPerKilogram, string symbol)
        {
            this.toJoulesPerKilogram = toJoulesPerKilogram;
            this.fromJoulesPerKilogram = fromJoulesPerKilogram;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.SpecificEnergyUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.SpecificEnergyUnit"/>
        /// </summary>
        public SpecificEnergyUnit SiUnit => JoulesPerKilogram;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.SpecificEnergyUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => JoulesPerKilogram;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificEnergy"/> that is the result from the multiplication.</returns>
        public static SpecificEnergy operator *(double left, SpecificEnergyUnit right)
        {
            return SpecificEnergy.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SpecificEnergyUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergyUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergyUnit"/>.</param>
	    public static bool operator ==(SpecificEnergyUnit left, SpecificEnergyUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SpecificEnergyUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpecificEnergyUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpecificEnergyUnit"/>.</param>
        public static bool operator !=(SpecificEnergyUnit left, SpecificEnergyUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="SpecificEnergyUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="SpecificEnergyUnit"/></returns>
        public static SpecificEnergyUnit Parse(string text)
        {
            return UnitParser<SpecificEnergyUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpecificEnergyUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpecificEnergyUnit"/></param>
        /// <param name="result">The parsed <see cref="SpecificEnergyUnit"/></param>
        /// <returns>True if an instance of <see cref="SpecificEnergyUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out SpecificEnergyUnit value)
        {
            return UnitParser<SpecificEnergyUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to JoulesPerKilogram.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toJoulesPerKilogram(value);
        }

        /// <summary>
        /// Converts a value from joulesPerKilogram.
        /// </summary>
        /// <param name="joulesPerKilogram">The value in JoulesPerKilogram</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double joulesPerKilogram)
        {
            return this.fromJoulesPerKilogram(joulesPerKilogram);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new SpecificEnergy(<paramref name="value"/>, this)</returns>
        public SpecificEnergy CreateQuantity(double value)
        {
            return new SpecificEnergy(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in JoulesPerKilogram
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(SpecificEnergy quantity)
        {
            return FromSiUnit(quantity.joulesPerKilogram);
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
            SpecificEnergyUnit unit;
            var paddedFormat = UnitFormatCache<SpecificEnergyUnit>.GetOrCreate(format, out unit);
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
        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<SpecificEnergyUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.SpecificEnergyUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.SpecificEnergyUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same SpecificEnergyUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(SpecificEnergyUnit other)
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

            return obj is SpecificEnergyUnit && Equals((SpecificEnergyUnit)obj);
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