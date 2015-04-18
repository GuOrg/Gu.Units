namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.VolumetricFlowUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct VolumetricFlowUnit : IUnit, IUnit<VolumetricFlow>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.CubicMetresPerSecond"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly VolumetricFlowUnit CubicMetresPerSecond = new VolumetricFlowUnit(1.0, "m³ / s");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public VolumetricFlowUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.CubicMetresPerSecond"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static VolumetricFlow operator *(double left, VolumetricFlowUnit right)
        {
            return VolumetricFlow.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.CubicMetresPerSecond"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from CubicMetresPerSecond.
        /// </summary>
        /// <param name="value">The value in CubicMetresPerSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public VolumetricFlow CreateQuantity(double value)
        {
            return new VolumetricFlow(value, this);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), CubicMetresPerSecond.Symbol);
        }
    }
}