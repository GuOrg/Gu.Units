namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.VolumetricFlow"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(VolumetricFlowUnitTypeConverter))]
    public struct VolumetricFlowUnit : IUnit, IUnit<VolumetricFlow>, IEquatable<VolumetricFlowUnit>
    {
        /// <summary>
        /// The VolumetricFlowUnit unit
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

        private readonly Func<double, double> toCubicMetresPerSecond;
        private readonly Func<double, double> fromCubicMetresPerSecond;
        internal readonly string symbol;

        public VolumetricFlowUnit(Func<double, double> toCubicMetresPerSecond, Func<double, double> fromCubicMetresPerSecond, string symbol)
        {
            this.toCubicMetresPerSecond = toCubicMetresPerSecond;
            this.fromCubicMetresPerSecond = fromCubicMetresPerSecond;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.VolumetricFlowUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.VolumetricFlowUnit"/>
        /// </summary>
        public VolumetricFlowUnit SiUnit => CubicMetresPerSecond;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.VolumetricFlowUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => CubicMetresPerSecond;

        public static VolumetricFlow operator *(double left, VolumetricFlowUnit right)
        {
            return VolumetricFlow.From(left, right);
        }

        public static bool operator ==(VolumetricFlowUnit left, VolumetricFlowUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(VolumetricFlowUnit left, VolumetricFlowUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="VolumetricFlowUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="VolumetricFlowUnit"/></returns>
        public static VolumetricFlowUnit Parse(string text)
        {
            return UnitParser<VolumetricFlowUnit>.Parse(text);
        }

        public static bool TryParse(string text, out VolumetricFlowUnit value)
        {
            return UnitParser<VolumetricFlowUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to CubicMetresPerSecond.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toCubicMetresPerSecond(value);
        }

        /// <summary>
        /// Converts a value from cubicMetresPerSecond.
        /// </summary>
        /// <param name="CubicMetresPerSecond">The value in CubicMetresPerSecond</param>
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
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(VolumetricFlow quantity)
        {
            return FromSiUnit(quantity.cubicMetresPerSecond);
        }

        public override string ToString()
        {
            return this.symbol;
        }

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

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<VolumetricFlowUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(VolumetricFlowUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is VolumetricFlowUnit && Equals((VolumetricFlowUnit)obj);
        }

        /// <summary>
        /// Returns the hashcode for this <see cref="LengthUnit"/>
        /// </summary>
        /// <returns></returns>
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