namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.VolumetricFlow"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(VolumetricFlowUnitTypeConverter))]
    public struct VolumetricFlowUnit : IUnit, IUnit<VolumetricFlow>, IEquatable<VolumetricFlowUnit>
    {
        /// <summary>
        /// The CubicMetresPerSecond unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit CubicMetresPerSecond = new VolumetricFlowUnit(cubicMetresPerSecond => cubicMetresPerSecond, cubicMetresPerSecond => cubicMetresPerSecond, "m³/s");

        /// <summary>
        /// The CubicMetresPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit CubicMetresPerMinute = new VolumetricFlowUnit(cubicMetresPerMinute => cubicMetresPerMinute / 60, cubicMetresPerSecond => 60 * cubicMetresPerSecond, "m³/min");

        /// <summary>
        /// The CubicMetresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit CubicMetresPerHour = new VolumetricFlowUnit(cubicMetresPerHour => cubicMetresPerHour / 3600, cubicMetresPerSecond => 3600 * cubicMetresPerSecond, "m³/h");

        /// <summary>
        /// The LitresPerSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit LitresPerSecond = new VolumetricFlowUnit(litresPerSecond => litresPerSecond / 1000, cubicMetresPerSecond => 1000 * cubicMetresPerSecond, "L/s");

        /// <summary>
        /// The LitresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit LitresPerHour = new VolumetricFlowUnit(litresPerHour => litresPerHour / 3600000, cubicMetresPerSecond => 3600000 * cubicMetresPerSecond, "L/h");

        /// <summary>
        /// The LitresPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit LitresPerMinute = new VolumetricFlowUnit(litresPerMinute => litresPerMinute / 60000, cubicMetresPerSecond => 60000 * cubicMetresPerSecond, "L/min");

        /// <summary>
        /// The MillilitresPerSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit MillilitresPerSecond = new VolumetricFlowUnit(millilitresPerSecond => millilitresPerSecond / 1000000, cubicMetresPerSecond => 1000000 * cubicMetresPerSecond, "ml/s");

        /// <summary>
        /// The MillilitresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit MillilitresPerHour = new VolumetricFlowUnit(millilitresPerHour => millilitresPerHour / 3600000000, cubicMetresPerSecond => 3600000000 * cubicMetresPerSecond, "ml/h");

        /// <summary>
        /// The MillilitresPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit MillilitresPerMinute = new VolumetricFlowUnit(millilitresPerMinute => millilitresPerMinute / 60000000, cubicMetresPerSecond => 60000000 * cubicMetresPerSecond, "ml/min");

        /// <summary>
        /// The CentilitresPerSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit CentilitresPerSecond = new VolumetricFlowUnit(centilitresPerSecond => centilitresPerSecond / 100000, cubicMetresPerSecond => 100000 * cubicMetresPerSecond, "cl/s");

        /// <summary>
        /// The CentilitresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit CentilitresPerHour = new VolumetricFlowUnit(centilitresPerHour => centilitresPerHour / 360000000, cubicMetresPerSecond => 360000000 * cubicMetresPerSecond, "cl/h");

        /// <summary>
        /// The CentilitresPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit CentilitresPerMinute = new VolumetricFlowUnit(centilitresPerMinute => centilitresPerMinute / 6000000, cubicMetresPerSecond => 6000000 * cubicMetresPerSecond, "cl/min");

        /// <summary>
        /// The CubicFeetPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit CubicFeetPerHour = new VolumetricFlowUnit(cubicFeetPerHour => 7.86579072E-06 * cubicFeetPerHour, cubicMetresPerSecond => cubicMetresPerSecond / 7.86579072E-06, "ft³/h");

        /// <summary>
        /// The CubicFeetPerSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit CubicFeetPerSecond = new VolumetricFlowUnit(cubicFeetPerSecond => 0.028316846592 * cubicFeetPerSecond, cubicMetresPerSecond => cubicMetresPerSecond / 0.028316846592, "ft³/s");

        /// <summary>
        /// The CubicFeetPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit CubicFeetPerMinute = new VolumetricFlowUnit(cubicFeetPerMinute => 0.0004719474432 * cubicFeetPerMinute, cubicMetresPerSecond => cubicMetresPerSecond / 0.0004719474432, "ft³/min");

        /// <summary>
        /// The CubicFeetPerDay unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit CubicFeetPerDay = new VolumetricFlowUnit(cubicFeetPerDay => 3.2774128E-07 * cubicFeetPerDay, cubicMetresPerSecond => cubicMetresPerSecond / 3.2774128E-07, "ft³/d");

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.VolumetricFlowUnit"/>.
        /// </summary>
        internal readonly string symbol;

        private readonly Func<double, double> toCubicMetresPerSecond;
        private readonly Func<double, double> fromCubicMetresPerSecond;

        /// <summary>
        /// Initializes a new instance of the <see cref="VolumetricFlowUnit"/> struct.
        /// </summary>
        /// <param name="toCubicMetresPerSecond">The conversion to <see cref="CubicMetresPerSecond"/></param>
        /// <param name="fromCubicMetresPerSecond">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="CubicMetresPerSecond"/></param>
        public VolumetricFlowUnit(Func<double, double> toCubicMetresPerSecond, Func<double, double> fromCubicMetresPerSecond, string symbol)
        {
            this.toCubicMetresPerSecond = toCubicMetresPerSecond;
            this.fromCubicMetresPerSecond = fromCubicMetresPerSecond;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.VolumetricFlowUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.VolumetricFlowUnit"/>
        /// </summary>
        public VolumetricFlowUnit SiUnit => CubicMetresPerSecond;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => CubicMetresPerSecond;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="VolumetricFlow"/> that is the result from the multiplication.</returns>
        public static VolumetricFlow operator *(double left, VolumetricFlowUnit right)
        {
            return VolumetricFlow.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.VolumetricFlowUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.VolumetricFlowUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.VolumetricFlowUnit"/>.</param>
        public static bool operator ==(VolumetricFlowUnit left, VolumetricFlowUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.VolumetricFlowUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.VolumetricFlowUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.VolumetricFlowUnit"/>.</param>
        public static bool operator !=(VolumetricFlowUnit left, VolumetricFlowUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="VolumetricFlowUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="VolumetricFlowUnit"/></returns>
        public static VolumetricFlowUnit Parse(string text)
        {
            return UnitParser<VolumetricFlowUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.VolumetricFlowUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.VolumetricFlowUnit"/></param>
        /// <param name="result">The parsed <see cref="VolumetricFlowUnit"/></param>
        /// <returns>True if an instance of <see cref="VolumetricFlowUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out VolumetricFlowUnit result)
        {
            return UnitParser<VolumetricFlowUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to CubicMetresPerSecond.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toCubicMetresPerSecond(value);
        }

        /// <summary>
        /// Converts a value from cubicMetresPerSecond.
        /// </summary>
        /// <param name="cubicMetresPerSecond">The value in CubicMetresPerSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double cubicMetresPerSecond)
        {
            return this.fromCubicMetresPerSecond(cubicMetresPerSecond);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new VolumetricFlow(<paramref name="value"/>, this)</returns>
        public VolumetricFlow CreateQuantity(double value)
        {
            return new VolumetricFlow(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in CubicMetresPerSecond
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(VolumetricFlow quantity)
        {
            return this.FromSiUnit(quantity.cubicMetresPerSecond);
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
            VolumetricFlowUnit unit;
            var paddedFormat = UnitFormatCache<VolumetricFlowUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<VolumetricFlowUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.VolumetricFlowUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.VolumetricFlowUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same VolumetricFlowUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(VolumetricFlowUnit other)
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

            return obj is VolumetricFlowUnit && this.Equals((VolumetricFlowUnit)obj);
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