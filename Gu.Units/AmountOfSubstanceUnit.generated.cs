namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.AmountOfSubstance"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(AmountOfSubstanceUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{AmountOfSubstanceUnit.symbol}")]
    public struct AmountOfSubstanceUnit : IUnit, IUnit<AmountOfSubstance>, IEquatable<AmountOfSubstanceUnit>
    {
        /// <summary>
        /// The AmountOfSubstanceUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly AmountOfSubstanceUnit Moles = new AmountOfSubstanceUnit(moles => moles, moles => moles, "mol");

        private readonly Func<double, double> toMoles;
        private readonly Func<double, double> fromMoles;
        internal readonly string symbol;

        public AmountOfSubstanceUnit(Func<double, double> toMoles, Func<double, double> fromMoles, string symbol)
        {
            this.toMoles = toMoles;
            this.fromMoles = fromMoles;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.AmountOfSubstanceUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.AmountOfSubstanceUnit"/>
        /// </summary>
        public AmountOfSubstanceUnit SiUnit => Moles;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.AmountOfSubstanceUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Moles;

        public static AmountOfSubstance operator *(double left, AmountOfSubstanceUnit right)
        {
            return AmountOfSubstance.From(left, right);
        }

        public static bool operator ==(AmountOfSubstanceUnit left, AmountOfSubstanceUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AmountOfSubstanceUnit left, AmountOfSubstanceUnit right)
        {
            return !left.Equals(right);
        }

        public static AmountOfSubstanceUnit Parse(string text)
        {
            return UnitParser<AmountOfSubstanceUnit>.Parse(text);
        }

        public static bool TryParse(string text, out AmountOfSubstanceUnit value)
        {
            return UnitParser<AmountOfSubstanceUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Moles.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMoles(value);
        }

        /// <summary>
        /// Converts a value from Moles.
        /// </summary>
        /// <param name="value">The value in Moles</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double moles)
        {
            return this.fromMoles(moles);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new AmountOfSubstance(value, this)</returns>
        public AmountOfSubstance CreateQuantity(double value)
        {
            return new AmountOfSubstance(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in AmountOfSubstanceUnit
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(AmountOfSubstance quantity)
        {
            return FromSiUnit(quantity.moles);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(AmountOfSubstanceUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AmountOfSubstanceUnit && Equals((AmountOfSubstanceUnit)obj);
        }

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