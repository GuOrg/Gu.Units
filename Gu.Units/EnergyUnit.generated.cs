namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.EnergyUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct EnergyUnit : IUnit
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Joules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Joules = new EnergyUnit(1.0, "J");
        /// <summary>
        /// The <see cref="T:Gu.Units.Joules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit J = Joules;

        /// <summary>
        /// The <see cref="T:Gu.Units.Nanojoules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Nanojoules = new EnergyUnit(1E-09, "nJ");
        /// <summary>
        /// The <see cref="T:Gu.Units.Nanojoules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit nJ = Nanojoules;

        /// <summary>
        /// The <see cref="T:Gu.Units.Microjoules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Microjoules = new EnergyUnit(1E-06, "µJ");
        /// <summary>
        /// The <see cref="T:Gu.Units.Microjoules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit µJ = Microjoules;

        /// <summary>
        /// The <see cref="T:Gu.Units.Millijoules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Millijoules = new EnergyUnit(0.001, "mJ");
        /// <summary>
        /// The <see cref="T:Gu.Units.Millijoules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit mJ = Millijoules;

        /// <summary>
        /// The <see cref="T:Gu.Units.Kilojoules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Kilojoules = new EnergyUnit(1000, "kJ");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kilojoules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit kJ = Kilojoules;

        /// <summary>
        /// The <see cref="T:Gu.Units.Megajoules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Megajoules = new EnergyUnit(1000000, "MJ");
        /// <summary>
        /// The <see cref="T:Gu.Units.Megajoules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit MJ = Megajoules;

        /// <summary>
        /// The <see cref="T:Gu.Units.Gigajoules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Gigajoules = new EnergyUnit(1000000000, "GJ");
        /// <summary>
        /// The <see cref="T:Gu.Units.Gigajoules"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit GJ = Gigajoules;

        /// <summary>
        /// The <see cref="T:Gu.Units.KilowattHours"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit KilowattHours = new EnergyUnit(3600000, "kWh");
        /// <summary>
        /// The <see cref="T:Gu.Units.KilowattHours"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit kWh = KilowattHours;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public EnergyUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Joules"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Energy operator *(double left, EnergyUnit right)
        {
            return Energy.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Joules"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Joules.
        /// </summary>
        /// <param name="value">The value in Joules</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Joules.Symbol);
        }
    }
}