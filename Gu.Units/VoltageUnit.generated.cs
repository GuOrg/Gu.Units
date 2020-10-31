namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Voltage"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(VoltageUnitTypeConverter))]
    public struct VoltageUnit : IUnit, IUnit<Voltage>, IEquatable<VoltageUnit>
    {
        /// <summary>
        /// The Volts unit
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
        public static readonly VoltageUnit Microvolts = new VoltageUnit(microvolts => microvolts / 1000000, volts => 1000000 * volts, "μV");

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

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.VoltageUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toVolts;
        private readonly Func<double, double> fromVolts;

        /// <summary>
        /// Initializes a new instance of the <see cref="VoltageUnit"/> struct.
        /// </summary>
        /// <param name="toVolts">The conversion to <see cref="Volts"/></param>
        /// <param name="fromVolts">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Volts"/></param>
        public VoltageUnit(Func<double, double> toVolts, Func<double, double> fromVolts, string symbol)
        {
            this.toVolts = toVolts;
            this.fromVolts = fromVolts;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.VoltageUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.VoltageUnit"/>
        /// </summary>
        public VoltageUnit SiUnit => Volts;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Volts;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Voltage"/> that is the result from the multiplication.</returns>
        public static Voltage operator *(double left, VoltageUnit right)
        {
            return Voltage.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.VoltageUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.VoltageUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.VoltageUnit"/>.</param>
        public static bool operator ==(VoltageUnit left, VoltageUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.VoltageUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.VoltageUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.VoltageUnit"/>.</param>
        public static bool operator !=(VoltageUnit left, VoltageUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="VoltageUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="VoltageUnit"/></returns>
        public static VoltageUnit Parse(string text)
        {
            return UnitParser<VoltageUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.VoltageUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.VoltageUnit"/></param>
        /// <param name="result">The parsed <see cref="VoltageUnit"/></param>
        /// <returns>True if an instance of <see cref="VoltageUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out VoltageUnit result)
        {
            return UnitParser<VoltageUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Volts.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toVolts(value);
        }

        /// <summary>
        /// Converts a value from volts.
        /// </summary>
        /// <param name="volts">The value in Volts</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double volts)
        {
            return this.fromVolts(volts);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Voltage(<paramref name="value"/>, this)</returns>
        public Voltage CreateQuantity(double value)
        {
            return new Voltage(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Volts
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Voltage quantity)
        {
            return this.FromSiUnit(quantity.volts);
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
            VoltageUnit unit;
            var paddedFormat = UnitFormatCache<VoltageUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<VoltageUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.VoltageUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.VoltageUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same VoltageUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(VoltageUnit other)
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

            return obj is VoltageUnit && this.Equals((VoltageUnit)obj);
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
