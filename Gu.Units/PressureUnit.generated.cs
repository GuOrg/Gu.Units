namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.PressureUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable, DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Pascals.symbol}")]
    public struct PressureUnit : IUnit, IUnit<Pressure>, IEquatable<PressureUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Pascals"/> unit
        /// Contains conversion logic to from and formatting.
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
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit nPa = Nanopascals;

        /// <summary>
        /// The <see cref="T:Gu.Units.Micropascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Micropascals = new PressureUnit(1E-06, "µPa");
        /// <summary>
        /// The <see cref="T:Gu.Units.Micropascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit µPa = Micropascals;

        /// <summary>
        /// The <see cref="T:Gu.Units.Millipascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Millipascals = new PressureUnit(0.001, "mPa");
        /// <summary>
        /// The <see cref="T:Gu.Units.Millipascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit mPa = Millipascals;

        /// <summary>
        /// The <see cref="T:Gu.Units.Kilopascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Kilopascals = new PressureUnit(1000, "kPa");
        /// <summary>
        /// The <see cref="T:Gu.Units.Kilopascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit kPa = Kilopascals;

        /// <summary>
        /// The <see cref="T:Gu.Units.Megapascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Megapascals = new PressureUnit(1000000, "MPa");
        /// <summary>
        /// The <see cref="T:Gu.Units.Megapascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit MPa = Megapascals;

        /// <summary>
        /// The <see cref="T:Gu.Units.Gigapascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Gigapascals = new PressureUnit(1000000000, "GPa");
        /// <summary>
        /// The <see cref="T:Gu.Units.Gigapascals"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit GPa = Gigapascals;

        /// <summary>
        /// The <see cref="T:Gu.Units.Bars"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Bars = new PressureUnit(100000, "bar");
        /// <summary>
        /// The <see cref="T:Gu.Units.Bars"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit bar = Bars;

        /// <summary>
        /// The <see cref="T:Gu.Units.Millibars"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Millibars = new PressureUnit(100, "mbar");
        /// <summary>
        /// The <see cref="T:Gu.Units.Millibars"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit mbar = Millibars;

        private readonly double conversionFactor;
        private readonly string symbol;

        public PressureUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Pascals"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public static Pressure operator *(double left, PressureUnit right)
        {
            return Pressure.From(left, right);
        }

        public static bool operator ==(PressureUnit left, PressureUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PressureUnit left, PressureUnit right)
        {
            return !left.Equals(right);
        }

        public static PressureUnit Parse(string text)
        {
            return Parser.ParseUnit<PressureUnit>(text);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Pascals"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Pascals.
        /// </summary>
        /// <param name="value">The value in Pascals</param>
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
        public Pressure CreateQuantity(double value)
        {
            return new Pressure(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Pressure quantity)
        {
            return FromSiUnit(quantity.pascals);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(PressureUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is PressureUnit && Equals((PressureUnit)obj);
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