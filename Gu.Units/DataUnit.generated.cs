namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Data"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(DataUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{DataUnit.symbol}")]
    public struct DataUnit : IUnit, IUnit<Data>, IEquatable<DataUnit>
    {
        /// <summary>
        /// The DataUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly DataUnit Bits = new DataUnit(bits => bits, bits => bits, "bit");

        /// <summary>
        /// The Byte unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DataUnit Byte = new DataUnit(@byte => 8 * @byte, bits => bits / 8, "B");

        /// <summary>
        /// The Kilobyte unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DataUnit Kilobyte = new DataUnit(kilobyte => 8000 * kilobyte, bits => bits / 8000, "kB");

        /// <summary>
        /// The Megabyte unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DataUnit Megabyte = new DataUnit(megabyte => 8000000 * megabyte, bits => bits / 8000000, "MB");

        /// <summary>
        /// The Gigabyte unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DataUnit Gigabyte = new DataUnit(gigabyte => 8000000000 * gigabyte, bits => bits / 8000000000, "GB");

        /// <summary>
        /// The Terabyte unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DataUnit Terabyte = new DataUnit(terabyte => 8000000000000 * terabyte, bits => bits / 8000000000000, "TB");

        /// <summary>
        /// The Megabits unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DataUnit Megabits = new DataUnit(megabits => 1000000 * megabits, bits => bits / 1000000, "Mbit");

        /// <summary>
        /// The Gigabits unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DataUnit Gigabits = new DataUnit(gigabits => 1000000000 * gigabits, bits => bits / 1000000000, "Gbit");

        /// <summary>
        /// The Kilobits unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DataUnit Kilobits = new DataUnit(kilobits => 1000 * kilobits, bits => bits / 1000, "kbit");

        private readonly Func<double, double> toBits;
        private readonly Func<double, double> fromBits;
        internal readonly string symbol;

        public DataUnit(Func<double, double> toBits, Func<double, double> fromBits, string symbol)
        {
            this.toBits = toBits;
            this.fromBits = fromBits;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.DataUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.DataUnit"/>
        /// </summary>
        public DataUnit SiUnit => Bits;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.DataUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Bits;

        public static Data operator *(double left, DataUnit right)
        {
            return Data.From(left, right);
        }

        public static bool operator ==(DataUnit left, DataUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DataUnit left, DataUnit right)
        {
            return !left.Equals(right);
        }

        public static DataUnit Parse(string text)
        {
            return UnitParser<DataUnit>.Parse(text);
        }

        public static bool TryParse(string text, out DataUnit value)
        {
            return UnitParser<DataUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Bits.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toBits(value);
        }

        /// <summary>
        /// Converts a value from Bits.
        /// </summary>
        /// <param name="value">The value in Bits</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double bits)
        {
            return this.fromBits(bits);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Data(value, this)</returns>
        public Data CreateQuantity(double value)
        {
            return new Data(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in DataUnit
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Data quantity)
        {
            return FromSiUnit(quantity.bits);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(DataUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is DataUnit && Equals((DataUnit)obj);
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