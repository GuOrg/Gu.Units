namespace Gu.Units
{
    using System;

    [Serializable]
    internal struct SymbolAndPower : IEquatable<SymbolAndPower>
    {
        internal readonly string Symbol;
        internal readonly int Power;

        private static readonly StringComparer OrdinalComparer = StringComparer.Ordinal;

        internal SymbolAndPower(string symbol, int power)
        {
            if (string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentNullException(nameof(symbol));
            }

            if (power < -5 || power > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(power), power, "Unhandled power.");
            }

            this.Symbol = symbol;
            this.Power = power;
        }

        public static bool operator ==(SymbolAndPower left, SymbolAndPower right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SymbolAndPower left, SymbolAndPower right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            string p;
            if (this.Power == 1)
            {
                p = string.Empty;
            }
            else if (this.Power > 1)
            {
                p = new string(SuperScript.GetChar(this.Power), 1);
            }
            else
            {
                p = new string(new[] { '⁻', SuperScript.GetChar(-1 * this.Power) });
            }

            return $"{this.Symbol}{p}";
        }

        public bool Equals(SymbolAndPower other)
        {
            return OrdinalComparer.Equals(this.Symbol, other.Symbol) && this.Power == other.Power;
        }

        public override bool Equals(object? obj)
        {
            return obj is SymbolAndPower symbolAndPower && this.Equals(symbolAndPower);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (OrdinalComparer.GetHashCode(this.Symbol) * 397) ^ this.Power;
            }
        }
    }
}
