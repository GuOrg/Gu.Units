namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.VolumetricFlowUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(VolumetricFlowUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{CubicMetresPerSecond.symbol}")]
    public struct VolumetricFlowUnit : IUnit, IUnit<VolumetricFlow>, IEquatable<VolumetricFlowUnit>
    {
        /// <summary>
        /// The CubicMetresPerSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit CubicMetresPerSecond = new VolumetricFlowUnit(1.0, "m³/s");

        private readonly double conversionFactor;
        private readonly string symbol;

        public VolumetricFlowUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.VolumetricFlowUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.VolumetricFlowUnit"/>
        /// </summary>
        public VolumetricFlowUnit SiUnit => VolumetricFlowUnit.CubicMetresPerSecond;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.VolumetricFlowUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => VolumetricFlowUnit.CubicMetresPerSecond;

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
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from CubicMetresPerSecond.
        /// </summary>
        /// <param name="value">The value in CubicMetresPerSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new VolumetricFlow(value, this)</returns>
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