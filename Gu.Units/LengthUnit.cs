//namespace Gu.Units
//{
//    using System;

//    [Serializable]
//    public struct LengthUnit : IUnit
//    {
//        private readonly double _conversionFactor;
//        private readonly string _symbol;

//        public LengthUnit(double conversionFactor, string symbol)
//        {
//            this._conversionFactor = conversionFactor;
//            _symbol = symbol;
//        }

//        public static readonly LengthUnit Metres = new LengthUnit(1.0, "m");
//        public static readonly LengthUnit m = Metres;
//        public static readonly LengthUnit Millimetres = new LengthUnit(1E-3, "mm");
//        public static readonly LengthUnit mm = Millimetres;
//        public static readonly LengthUnit Centimetres = new LengthUnit(1E-2, "cm");
//        public static readonly LengthUnit cm = Centimetres;

//        public string Symbol
//        {
//            get
//            {
//                return _symbol;
//            }
//        }

//        public static Length operator *(double left, LengthUnit right)
//        {
//            return Length.From(left, right);
//        }

//        /// <summary>
//        /// Converts a value in <see cref="T:Gu.Units.Millimetres"/> value to <see cref="T:Gu.Units.Metres"/>.
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns>The converted value</returns>
//        public double ToSiUnit(double value)
//        {
//            return _conversionFactor * value;
//        }

//        public override string ToString()
//        {
//            return string.Format("1{0} == {1}{2}", this._symbol, this.ToSiUnit(1), Metres.Symbol);
//        }
//    }
//}
