namespace Gu.Units
{
    using System;

    [Serializable]
    public struct VolumeUnit : IUnit
    {
        public static readonly VolumeUnit CubicMetres = new VolumeUnit(1.0, "m³");

        public static readonly VolumeUnit Litres = new VolumeUnit(0.001, "L");
        public static readonly VolumeUnit L = Litres;

        public static readonly VolumeUnit CubicCentimetres = new VolumeUnit(1E-06, "cm³");

        public static readonly VolumeUnit CubicMillimetres = new VolumeUnit(1E-09, "mm³");


        private readonly double _conversionFactor;
        private readonly string _symbol;

        public VolumeUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

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
        /// Converts a value to <see cref="T:Gu.Units.Volume "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.CubicMetres "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), CubicMetres.Symbol);
        }
    }
}
