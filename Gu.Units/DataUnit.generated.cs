namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Data"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(DataUnitTypeConverter))]
    public struct DataUnit : IUnit, IUnit<Data>, IEquatable<DataUnit>
    {
        /// <summary>
        /// The Bits unit
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

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.DataUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toBits;
        private readonly Func<double, double> fromBits;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataUnit"/> struct.
        /// </summary>
        /// <param name="toBits">The conversion to <see cref="Bits"/></param>
        /// <param name="fromBits">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Bits"/></param>
        public DataUnit(Func<double, double> toBits, Func<double, double> fromBits, string symbol)
        {
            this.toBits = toBits;
            this.fromBits = fromBits;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.DataUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.DataUnit"/>
        /// </summary>
        public DataUnit SiUnit => Bits;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Bits;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Data"/> that is the result from the multiplication.</returns>
        public static Data operator *(double left, DataUnit right)
        {
            return Data.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.DataUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.DataUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.DataUnit"/>.</param>
        public static bool operator ==(DataUnit left, DataUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.DataUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.DataUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.DataUnit"/>.</param>
        public static bool operator !=(DataUnit left, DataUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="DataUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="DataUnit"/></returns>
        public static DataUnit Parse(string text)
        {
            return UnitParser<DataUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.DataUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.DataUnit"/></param>
        /// <param name="result">The parsed <see cref="DataUnit"/></param>
        /// <returns>True if an instance of <see cref="DataUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out DataUnit result)
        {
            return UnitParser<DataUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Bits.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toBits(value);
        }

        /// <summary>
        /// Converts a value from bits.
        /// </summary>
        /// <param name="bits">The value in Bits</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double bits)
        {
            return this.fromBits(bits);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Data(<paramref name="value"/>, this)</returns>
        public Data CreateQuantity(double value)
        {
            return new Data(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Bits
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Data quantity)
        {
            return this.FromSiUnit(quantity.bits);
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
            DataUnit unit;
            var paddedFormat = UnitFormatCache<DataUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<DataUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.DataUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.DataUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same DataUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(DataUnit other)
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

            return obj is DataUnit && this.Equals((DataUnit)obj);
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