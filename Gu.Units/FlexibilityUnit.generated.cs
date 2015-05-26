namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.FlexibilityUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable, DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{MetresPerNewton.symbol}")]
    public struct FlexibilityUnit : IUnit, IUnit<Flexibility>, IEquatable<FlexibilityUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.MetresPerNewton"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MetresPerNewton = new FlexibilityUnit(1.0, "m/N");

        /// <summary>
        /// The <see cref="T:Gu.Units.MillimetresPerNewton"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MillimetresPerNewton = new FlexibilityUnit(0.001, "mm/N");

        /// <summary>
        /// The <see cref="T:Gu.Units.MillimetresPerKilonewton"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MillimetresPerKilonewton = new FlexibilityUnit(1E-06, "mm/kN");

        /// <summary>
        /// The <see cref="T:Gu.Units.MicrometresPerKilonewton"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MicrometresPerKilonewton = new FlexibilityUnit(1E-09, "µm/kN");

        private readonly double conversionFactor;
        private readonly string symbol;

        public FlexibilityUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.MetresPerNewton"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public static Flexibility operator *(double left, FlexibilityUnit right)
        {
            return Flexibility.From(left, right);
        }

        public static bool operator ==(FlexibilityUnit left, FlexibilityUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FlexibilityUnit left, FlexibilityUnit right)
        {
            return !left.Equals(right);
        }

        public static FlexibilityUnit Parse(string text)
        {
            return Parser.ParseUnit<FlexibilityUnit>(text);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.MetresPerNewton"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from MetresPerNewton.
        /// </summary>
        /// <param name="value">The value in MetresPerNewton</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new TTQuantity(value, this)</returns>
        public Flexibility CreateQuantity(double value)
        {
            return new Flexibility(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Flexibility quantity)
        {
            return FromSiUnit(quantity.metresPerNewton);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(FlexibilityUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is FlexibilityUnit && Equals((FlexibilityUnit)obj);
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