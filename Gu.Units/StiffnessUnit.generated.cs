namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.StiffnessUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{NewtonsPerMetre.symbol}")]
    public struct StiffnessUnit : IUnit, IUnit<Stiffness>, IEquatable<StiffnessUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.NewtonsPerMetre"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly StiffnessUnit NewtonsPerMetre = new StiffnessUnit(1.0, "N/m");

        private readonly double conversionFactor;
        private readonly string symbol;

        public StiffnessUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.NewtonsPerMetre"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public static Stiffness operator *(double left, StiffnessUnit right)
        {
            return Stiffness.From(left, right);
        }

        public static bool operator ==(StiffnessUnit left, StiffnessUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(StiffnessUnit left, StiffnessUnit right)
        {
            return !left.Equals(right);
        }

        public static StiffnessUnit Parse(string text)
        {
            return Parser.ParseUnit<StiffnessUnit>(text);
        }

        public static bool TryParse(string text, out StiffnessUnit value)
        {
            return Parser.TryParseUnit<StiffnessUnit>(text, out value);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.NewtonsPerMetre"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from NewtonsPerMetre.
        /// </summary>
        /// <param name="value">The value in NewtonsPerMetre</param>
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
        public Stiffness CreateQuantity(double value)
        {
            return new Stiffness(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Stiffness quantity)
        {
            return FromSiUnit(quantity.newtonsPerMetre);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(StiffnessUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is StiffnessUnit && Equals((StiffnessUnit)obj);
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