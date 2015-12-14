namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Flexibility"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(FlexibilityUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{FlexibilityUnit.symbol}")]
    public struct FlexibilityUnit : IUnit, IUnit<Flexibility>, IEquatable<FlexibilityUnit>
    {
        /// <summary>
        /// The FlexibilityUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MetresPerNewton = new FlexibilityUnit(metresPerNewton => metresPerNewton, metresPerNewton => metresPerNewton, "m/N");

        /// <summary>
        /// The MillimetresPerNewton unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MillimetresPerNewton = new FlexibilityUnit(millimetresPerNewton => millimetresPerNewton / 1000, metresPerNewton => 1000 * metresPerNewton, "mm/N");

        /// <summary>
        /// The MillimetresPerKilonewton unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MillimetresPerKilonewton = new FlexibilityUnit(millimetresPerKilonewton => millimetresPerKilonewton / 1000000, metresPerNewton => 1000000 * metresPerNewton, "mm/kN");

        /// <summary>
        /// The MicrometresPerKilonewton unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MicrometresPerKilonewton = new FlexibilityUnit(micrometresPerKilonewton => micrometresPerKilonewton / 1000000000, metresPerNewton => 1000000000 * metresPerNewton, "µm/kN");

        private readonly Func<double, double> toMetresPerNewton;
        private readonly Func<double, double> fromMetresPerNewton;
        internal readonly string symbol;

        public FlexibilityUnit(Func<double, double> toMetresPerNewton, Func<double, double> fromMetresPerNewton, string symbol)
        {
            this.toMetresPerNewton = toMetresPerNewton;
            this.fromMetresPerNewton = fromMetresPerNewton;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.FlexibilityUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.FlexibilityUnit"/>
        /// </summary>
        public FlexibilityUnit SiUnit => MetresPerNewton;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.FlexibilityUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => MetresPerNewton;

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
            return UnitParser<FlexibilityUnit>.Parse(text);
        }

        public static bool TryParse(string text, out FlexibilityUnit value)
        {
            return UnitParser<FlexibilityUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to MetresPerNewton.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMetresPerNewton(value);
        }

        /// <summary>
        /// Converts a value from MetresPerNewton.
        /// </summary>
        /// <param name="value">The value in MetresPerNewton</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double metresPerNewton)
        {
            return this.fromMetresPerNewton(metresPerNewton);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Flexibility(value, this)</returns>
        public Flexibility CreateQuantity(double value)
        {
            return new Flexibility(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in FlexibilityUnit
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