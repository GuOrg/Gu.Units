namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.VolumeUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct VolumeUnit : IUnit, IUnit<Volume>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.CubicMetres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit CubicMetres = new VolumeUnit(1.0, "m³");

        /// <summary>
        /// The <see cref="T:Gu.Units.Litres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit Litres = new VolumeUnit(0.0010000000000000002, "L");
        /// <summary>
        /// The <see cref="T:Gu.Units.Litres"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit L = Litres;

        /// <summary>
        /// The <see cref="T:Gu.Units.CubicCentimetres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit CubicCentimetres = new VolumeUnit(1.0000000000000002E-06, "cm³");

        /// <summary>
        /// The <see cref="T:Gu.Units.CubicMillimetres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit CubicMillimetres = new VolumeUnit(1E-09, "mm³");

        /// <summary>
        /// The <see cref="T:Gu.Units.CubicInches"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit CubicInches = new VolumeUnit(1.6387064E-05, "in³");

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public VolumeUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.CubicMetres"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Volume operator *(double left, VolumeUnit right)
        {
            return Volume.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.CubicMetres"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from CubicMetres.
        /// </summary>
        /// <param name="value">The value in CubicMetres</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public Volume Create(double value)
        {
            return new Volume(value, this);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), CubicMetres.Symbol);
        }
    }
}