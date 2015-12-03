namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.VoltageUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(VoltageUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Volts.symbol}")]
    public struct VoltageUnit : IUnit, IUnit<Voltage>, IEquatable<VoltageUnit>
    {
        /// <summary>
        /// The Volts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit Volts = new VoltageUnit(1.0, "V");

        /// <summary>
        /// The Volts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly VoltageUnit V = Volts;

        /// <summary>
        /// The Millivolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly VoltageUnit Millivolts = new VoltageUnit(0.001, "mV");

        /// <summary>
        /// The Millivolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly VoltageUnit mV = Millivolts;

        /// <summary>
        /// The Kilovolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly VoltageUnit Kilovolts = new VoltageUnit(1000, "kV");

        /// <summary>
        /// The Kilovolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly VoltageUnit kV = Kilovolts;

        /// <summary>
        /// The Megavolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly VoltageUnit Megavolts = new VoltageUnit(1000000, "MV");

        /// <summary>
        /// The Megavolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly VoltageUnit MV = Megavolts;

        /// <summary>
        /// The Microvolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly VoltageUnit Microvolts = new VoltageUnit(1E-06, "µV");

        /// <summary>
        /// The Microvolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly VoltageUnit µV = Microvolts;

        private readonly double conversionFactor;
        private readonly string symbol;

        public VoltageUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.VoltageUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.VoltageUnit"/>
        /// </summary>
        public VoltageUnit SiUnit => VoltageUnit.Volts;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.VoltageUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => VoltageUnit.Volts;

        public static Voltage operator *(double left, VoltageUnit right)
        {
            return Voltage.From(left, right);
        }

        public static bool operator ==(VoltageUnit left, VoltageUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(VoltageUnit left, VoltageUnit right)
        {
            return !left.Equals(right);
        }

        public static VoltageUnit Parse(string text)
        {
            return UnitParser<VoltageUnit>.Parse(text);
        }

        public static bool TryParse(string text, out VoltageUnit value)
        {
            return UnitParser<VoltageUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Volts.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Volts.
        /// </summary>
        /// <param name="value">The value in Volts</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Voltage(value, this)</returns>
        public Voltage CreateQuantity(double value)
        {
            return new Voltage(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Volts
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Voltage quantity)
        {
            return FromSiUnit(quantity.volts);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(VoltageUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is VoltageUnit && Equals((VoltageUnit)obj);
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