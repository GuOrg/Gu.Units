namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.PowerUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(PowerUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Watts.symbol}")]
    public struct PowerUnit : IUnit, IUnit<Power>, IEquatable<PowerUnit>
    {
        /// <summary>
        /// The Watts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PowerUnit Watts = new PowerUnit(1.0, "W");

        /// <summary>
        /// The Watts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PowerUnit W = Watts;

        /// <summary>
        /// The Nanowatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PowerUnit Nanowatts = new PowerUnit(1E-09, "nW");

        /// <summary>
        /// The Nanowatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PowerUnit nW = Nanowatts;

        /// <summary>
        /// The Microwatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PowerUnit Microwatts = new PowerUnit(1E-06, "µW");

        /// <summary>
        /// The Microwatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PowerUnit µW = Microwatts;

        /// <summary>
        /// The Milliwatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PowerUnit Milliwatts = new PowerUnit(0.001, "mW");

        /// <summary>
        /// The Milliwatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PowerUnit mW = Milliwatts;

        /// <summary>
        /// The Kilowatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PowerUnit Kilowatts = new PowerUnit(1000, "kW");

        /// <summary>
        /// The Kilowatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PowerUnit kW = Kilowatts;

        /// <summary>
        /// The Megawatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PowerUnit Megawatts = new PowerUnit(1000000, "MW");

        /// <summary>
        /// The Megawatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PowerUnit MW = Megawatts;

        /// <summary>
        /// The Gigawatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PowerUnit Gigawatts = new PowerUnit(1000000000, "GW");

        /// <summary>
        /// The Gigawatts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly PowerUnit GW = Gigawatts;

        private readonly double conversionFactor;
        private readonly string symbol;

        public PowerUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.PowerUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.PowerUnit"/>
        /// </summary>
        public PowerUnit SiUnit => PowerUnit.Watts;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.PowerUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => PowerUnit.Watts;

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
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Watts.
        /// </summary>
        /// <param name="value">The value in Watts</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
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
        /// Gets the scalar value of <paramref name="quantity"/> in Watts
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