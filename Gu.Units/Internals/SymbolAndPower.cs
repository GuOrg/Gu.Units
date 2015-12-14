namespace Gu.Units
{
    using System;

    [Serializable]
    internal struct SymbolAndPower : IEquatable<SymbolAndPower>
    {
        public readonly string Symbol;
        public readonly int Power;

        public SymbolAndPower(string symbol, int power)
        {
            Ensure.NotNullOrEmpty(symbol, nameof(symbol));
            Ensure.LessThan(power, 5, nameof(power));
            Ensure.GreaterThan(power, -5, nameof(power));
            // not sure about throwing here but I think it means something is wrong more often.
            Symbol = symbol;
            Power = power;
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
            if (Power == 1)
            {
                p = string.Empty;
            }
            else if (Power > 1)
            {
                p = new string(SuperScript.GetChar(Power), 1);
            }
            else
            {
                p = new string(new[] { '⁻', SuperScript.GetChar(-1 * Power) });
            }

            return $"{this.Symbol}{p}";
        }

        public bool Equals(SymbolAndPower other)
        {
            return string.Equals(Symbol, other.Symbol) && Power == other.Power;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is SymbolAndPower && Equals((SymbolAndPower)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Symbol.GetHashCode() * 397) ^ Power;
            }
        }
    }
}
