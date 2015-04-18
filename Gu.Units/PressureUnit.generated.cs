namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.PressureUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct PressureUnit : IUnit, IUnit<Pressure>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Pascals"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Pascals = new PressureUnit(1.0, "Pa");
        /// <summary>
        /// The <see cref="T:Gu.Units.Pascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Pa = Pascals;

        /// <summary>
        /// The <see cref="T:Gu.Units.Nanopascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Nanopascals = new PressureUnit(1E-09, "nPa");
        /// <summary>
        /// The <see cref="T:Gu.Units.Nanopascals"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit nPa = Nanopascals;

        /// <summary>
        /// The <see cref="T:Gu.Units.Micropascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Micropascals = new PressureUnit(1E-06, "µPa");
        /// <summary>
        /// The <see cref="T:Gu.Units.Micropascals"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit µPa = Micropascals;

        /// <summary>
        /// The <see cref="T:Gu.Units.Millipascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Millipascals = new PressureUnit(0.001, "mPa");
        /// <summary>
        /// The <see cref="T:Gu.Units.Millipascals"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit mPa = Millipascals;

        /// <summary>
        /// The <see cref="T:Gu.Units.Kilopascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Kilopascals = new PressureUnit(1000, "kPa");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kilopascals"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit kPa = Kilopascals;

        /// <summary>
        /// The <see cref="T:Gu.Units.Megapascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Megapascals = new PressureUnit(1000000, "MPa");
        /// <summary>
        /// The <see cref="T:Gu.Units.Megapascals"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit MPa = Megapascals;

        /// <summary>
        /// The <see cref="T:Gu.Units.Gigapascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Gigapascals = new PressureUnit(1000000000, "GPa");
        /// <summary>
        /// The <see cref="T:Gu.Units.Gigapascals"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit GPa = Gigapascals;

        /// <summary>
        /// The <see cref="T:Gu.Units.Bars"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Bars = new PressureUnit(100000, "bar");
        /// <summary>
        /// The <see cref="T:Gu.Units.Bars"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit bar = Bars;

        /// <summary>
        /// The <see cref="T:Gu.Units.Millibars"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Millibars = new PressureUnit(100, "mbar");
        /// <summary>
        /// The <see cref="T:Gu.Units.Millibars"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit mbar = Millibars;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public PressureUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Pascals"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Pressure operator *(double left, PressureUnit right)
        {
            return Pressure.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Pascals"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Pascals.
        /// </summary>
        /// <param name="value">The value in Pascals</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public Pressure CreateQuantity(double value)
        {
            return new Pressure(value, this);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Pascals.Symbol);
        }
    }
}