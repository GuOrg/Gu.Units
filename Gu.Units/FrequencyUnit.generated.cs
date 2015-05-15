namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.FrequencyUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct FrequencyUnit : IUnit, IUnit<Frequency>, IEquatable<FrequencyUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Hertz"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Hertz = new FrequencyUnit(1.0, "Hz");
        /// <summary>
        /// The <see cref="T:Gu.Units.Hertz"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Hz = Hertz;

        /// <summary>
        /// The <see cref="T:Gu.Units.Millihertz"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Millihertz = new FrequencyUnit(0.001, "mHz");
        /// <summary>
        /// The <see cref="T:Gu.Units.Millihertz"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit mHz = Millihertz;

        /// <summary>
        /// The <see cref="T:Gu.Units.Kilohertz"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Kilohertz = new FrequencyUnit(1000, "kHz");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kilohertz"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit kHz = Kilohertz;

        /// <summary>
        /// The <see cref="T:Gu.Units.Megahertz"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Megahertz = new FrequencyUnit(1000000, "MHz");
        /// <summary>
        /// The <see cref="T:Gu.Units.Megahertz"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit MHz = Megahertz;

        /// <summary>
        /// The <see cref="T:Gu.Units.Gigahertz"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Gigahertz = new FrequencyUnit(1000000000, "GHz");
        /// <summary>
        /// The <see cref="T:Gu.Units.Gigahertz"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit GHz = Gigahertz;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public FrequencyUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Hertz"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static Frequency operator *(double left, FrequencyUnit right)
        {
            return Frequency.From(left, right);
        }

        public static bool operator ==(FrequencyUnit left, FrequencyUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FrequencyUnit left, FrequencyUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Hertz"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Hertz.
        /// </summary>
        /// <param name="value">The value in Hertz</param>
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
        public Frequency CreateQuantity(double value)
        {
            return new Frequency(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(Frequency quantity)
        {
            return FromSiUnit(quantity.hertz);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Hertz.Symbol);
        }

        public bool Equals(FrequencyUnit other)
        {
            return _symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is FrequencyUnit && Equals((FrequencyUnit)obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
    }
}