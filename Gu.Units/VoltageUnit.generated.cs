namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Voltage"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(VoltageUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{VoltageUnit.symbol}")]
    public struct VoltageUnit : IUnit, IUnit<Voltage>, IEquatable<VoltageUnit>
    {
        /// <summary>
        /// The VoltageUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly VoltageUnit Volts = new VoltageUnit(volts => volts, volts => volts, "V");

        /// <summary>
        /// The Millivolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit Millivolts = new VoltageUnit(millivolts => millivolts / 1000, volts => 1000 * volts, "mV");

        /// <summary>
        /// The Kilovolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit Kilovolts = new VoltageUnit(kilovolts => 1000 * kilovolts, volts => volts / 1000, "kV");

        /// <summary>
        /// The Megavolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit Megavolts = new VoltageUnit(megavolts => 1000000 * megavolts, volts => volts / 1000000, "MV");

        /// <summary>
        /// The Microvolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit Microvolts = new VoltageUnit(microvolts => microvolts / 1000000, volts => 1000000 * volts, "µV");

        /// <summary>
        /// The Nanovolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit Nanovolts = new VoltageUnit(nanovolts => nanovolts / 1000000000, volts => 1000000000 * volts, "nV");

        /// <summary>
        /// The Gigavolts unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VoltageUnit Gigavolts = new VoltageUnit(gigavolts => 1000000000 * gigavolts, volts => volts / 1000000000, "GV");

        private readonly Func<double, double> toVolts;
        private readonly Func<double, double> fromVolts;
        internal readonly string symbol;

        public VoltageUnit(Func<double, double> toVolts, Func<double, double> fromVolts, string symbol)
        {
            this.toVolts = toVolts;
            this.fromVolts = fromVolts;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.VoltageUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.VoltageUnit"/>
        /// </summary>
        public VoltageUnit SiUnit => Volts;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.VoltageUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Volts;

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
            return this.toVolts(value);
        }

        /// <summary>
        /// Converts a value from Volts.
        /// </summary>
        /// <param name="value">The value in Volts</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double volts)
        {
            return this.fromVolts(volts);
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
        /// Gets the scalar value of <paramref name="quantity"/> in VoltageUnit
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