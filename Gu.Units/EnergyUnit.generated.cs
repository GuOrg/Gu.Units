namespace Gu.Units
{
    using System;

    [Serializable]
    public struct EnergyUnit : IUnit
    {
        public static readonly EnergyUnit Joules = new EnergyUnit(1.0, "J");
        public static readonly EnergyUnit J = Joules;

        public static readonly EnergyUnit Nanojoules = new EnergyUnit(1E-09, "nJ");
        public static readonly EnergyUnit nJ = Nanojoules;

        public static readonly EnergyUnit Microjoules = new EnergyUnit(1E-06, "µJ");
        public static readonly EnergyUnit µJ = Microjoules;

        public static readonly EnergyUnit Millijoules = new EnergyUnit(0.001, "mJ");
        public static readonly EnergyUnit mJ = Millijoules;

        public static readonly EnergyUnit Kilojoules = new EnergyUnit(1000, "kJ");
        public static readonly EnergyUnit kJ = Kilojoules;

        public static readonly EnergyUnit Megajoules = new EnergyUnit(1000000, "MJ");
        public static readonly EnergyUnit MJ = Megajoules;

        public static readonly EnergyUnit Gigajoules = new EnergyUnit(1000000000, "GJ");
        public static readonly EnergyUnit GJ = Gigajoules;

        public static readonly EnergyUnit KilowattHours = new EnergyUnit(3600000, "kWh");
        public static readonly EnergyUnit kWh = KilowattHours;


        private readonly double _conversionFactor;
        private readonly string _symbol;

        public EnergyUnit(double conversionFactor, string symbol)
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

        public static Energy operator *(double left, EnergyUnit right)
        {
            return Energy.From(left, right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Energy "/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Joules "/>.
        /// </summary>
        /// <param name="value"></param>
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
