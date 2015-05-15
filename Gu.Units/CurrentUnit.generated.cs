namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.CurrentUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct CurrentUnit : IUnit, IUnit<Current>, IEquatable<CurrentUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Amperes"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Amperes = new CurrentUnit(1.0, "A");
        /// <summary>
        /// The <see cref="T:Gu.Units.Amperes"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit A = Amperes;

        /// <summary>
        /// The <see cref="T:Gu.Units.Milliamperes"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Milliamperes = new CurrentUnit(0.001, "mA");
        /// <summary>
        /// The <see cref="T:Gu.Units.Milliamperes"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit mA = Milliamperes;

        /// <summary>
        /// The <see cref="T:Gu.Units.Kiloamperes"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Kiloamperes = new CurrentUnit(1000, "kA");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kiloamperes"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit kA = Kiloamperes;

        /// <summary>
        /// The <see cref="T:Gu.Units.Megaamperes"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Megaamperes = new CurrentUnit(1000000, "MA");
        /// <summary>
        /// The <see cref="T:Gu.Units.Megaamperes"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit MA = Megaamperes;

        /// <summary>
        /// The <see cref="T:Gu.Units.Microamperes"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Microamperes = new CurrentUnit(1E-06, "µA");
        /// <summary>
        /// The <see cref="T:Gu.Units.Microamperes"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit µA = Microamperes;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public CurrentUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Amperes"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Current operator *(double left, CurrentUnit right)
        {
            return Current.From(left, right);
        }

        public static bool operator ==(CurrentUnit left, CurrentUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CurrentUnit left, CurrentUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Amperes"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Amperes.
        /// </summary>
        /// <param name="value">The value in Amperes</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new TTQuantity(value, this)</returns>
        public Current CreateQuantity(double value)
        {
            return new Current(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(Current quantity)
        {
            return FromSiUnit(quantity.amperes);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Amperes.Symbol);
        }

        public bool Equals(CurrentUnit other)
        {
            return _symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is CurrentUnit && Equals((CurrentUnit)obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
    }
}