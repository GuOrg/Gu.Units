namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.CurrentUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable, DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Amperes.symbol}")]
    public struct CurrentUnit : IUnit, IUnit<Current>, IEquatable<CurrentUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Amperes"/> unit
        /// Contains conversion logic to from and formatting.
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
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit mA = Milliamperes;

        /// <summary>
        /// The <see cref="T:Gu.Units.Kiloamperes"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Kiloamperes = new CurrentUnit(1000, "kA");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kiloamperes"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit kA = Kiloamperes;

        /// <summary>
        /// The <see cref="T:Gu.Units.Megaamperes"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Megaamperes = new CurrentUnit(1000000, "MA");
        /// <summary>
        /// The <see cref="T:Gu.Units.Megaamperes"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit MA = Megaamperes;

        /// <summary>
        /// The <see cref="T:Gu.Units.Microamperes"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit Microamperes = new CurrentUnit(1E-06, "µA");
        /// <summary>
        /// The <see cref="T:Gu.Units.Microamperes"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CurrentUnit µA = Microamperes;

        private readonly double conversionFactor;
        private readonly string symbol;

        public CurrentUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Amperes"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
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

        public static CurrentUnit Parse(string text)
        {
            return Parser.ParseUnit<CurrentUnit>(text);
        }

        public static bool TryParse(string text, out CurrentUnit value)
        {
            return Parser.TryParseUnit<CurrentUnit>(text, out value);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Amperes"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Amperes.
        /// </summary>
        /// <param name="value">The value in Amperes</param>
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
        public Current CreateQuantity(double value)
        {
            return new Current(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Current quantity)
        {
            return FromSiUnit(quantity.amperes);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(CurrentUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is CurrentUnit && Equals((CurrentUnit)obj);
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