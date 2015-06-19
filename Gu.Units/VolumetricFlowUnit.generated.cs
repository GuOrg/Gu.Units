namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.VolumetricFlowUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable, DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{CubicMetresPerSecond.symbol}")]
    public struct VolumetricFlowUnit : IUnit, IUnit<VolumetricFlow>, IEquatable<VolumetricFlowUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.CubicMetresPerSecond"/> unit
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
        /// The symbol for <see cref="T:Gu.Units.CubicMetresPerSecond"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

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
            return Parser.ParseUnit<VolumetricFlowUnit>(text);
        }

        public static bool TryParse(string text, out VolumetricFlowUnit value)
        {
            return Parser.TryParseUnit<VolumetricFlowUnit>(text, out value);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.CubicMetresPerSecond"/>.
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
        /// <returns>new TTQuantity(value, this)</returns>
        public VolumetricFlow CreateQuantity(double value)
        {
            return new VolumetricFlow(value, this);
        }

        /// <summary>
        /// Gets the scalar value
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