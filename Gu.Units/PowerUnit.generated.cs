namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Power"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(PowerUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{PowerUnit.symbol}")]
    public struct PowerUnit : IUnit, IUnit<Power>, IEquatable<PowerUnit>
    {
        /// <summary>
        /// The PowerUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly PowerUnit Watts = new PowerUnit(watts => watts, watts => watts, "W");

        /// <summary>
        /// The Nanowatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Nanowatts = new PowerUnit(nanowatts => nanowatts / 1000000000, watts => 1000000000 * watts, "nW");

        /// <summary>
        /// The Microwatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Microwatts = new PowerUnit(microwatts => microwatts / 1000000, watts => 1000000 * watts, "µW");

        /// <summary>
        /// The Milliwatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Milliwatts = new PowerUnit(milliwatts => milliwatts / 1000, watts => 1000 * watts, "mW");

        /// <summary>
        /// The Kilowatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Kilowatts = new PowerUnit(kilowatts => 1000 * kilowatts, watts => watts / 1000, "kW");

        /// <summary>
        /// The Megawatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Megawatts = new PowerUnit(megawatts => 1000000 * megawatts, watts => watts / 1000000, "MW");

        /// <summary>
        /// The Gigawatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Gigawatts = new PowerUnit(gigawatts => 1000000000 * gigawatts, watts => watts / 1000000000, "GW");

        private readonly Func<double, double> toWatts;
        private readonly Func<double, double> fromWatts;
        internal readonly string symbol;

        public PowerUnit(Func<double, double> toWatts, Func<double, double> fromWatts, string symbol)
        {
            this.toWatts = toWatts;
            this.fromWatts = fromWatts;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.PowerUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.PowerUnit"/>
        /// </summary>
        public PowerUnit SiUnit => Watts;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.PowerUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Watts;

        public static Power operator *(double left, PowerUnit right)
        {
            return Power.From(left, right);
        }

        public static bool operator ==(PowerUnit left, PowerUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PowerUnit left, PowerUnit right)
        {
            return !left.Equals(right);
        }

        public static PowerUnit Parse(string text)
        {
            return UnitParser<PowerUnit>.Parse(text);
        }

        public static bool TryParse(string text, out PowerUnit value)
        {
            return UnitParser<PowerUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Watts.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toWatts(value);
        }

        /// <summary>
        /// Converts a value from Watts.
        /// </summary>
        /// <param name="value">The value in Watts</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double watts)
        {
            return this.fromWatts(watts);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Power(value, this)</returns>
        public Power CreateQuantity(double value)
        {
            return new Power(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in PowerUnit
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Power quantity)
        {
            return FromSiUnit(quantity.watts);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(PowerUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is PowerUnit && Equals((PowerUnit)obj);
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