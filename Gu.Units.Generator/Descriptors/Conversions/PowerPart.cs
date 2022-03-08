namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PowerPart
    {
        public PowerPart(int power, IFactorConversion conversion)
        {
            this.Power = power;
            this.Conversion = conversion;
        }

        public int Power { get; }

        public IFactorConversion Conversion { get; }

        public string FirstName
        {
            get
            {
                var isLength = IsLength(this.Conversion);
                return CreateName(this.Power, this.Conversion.Name, isLength);
            }
        }

        public object LastName
        {
            get
            {
                var trimmedS = this.Conversion.Name.TrimEnd('s');
                var isLength = IsLength(this.Conversion);
                return CreateName(this.Power, trimmedS, isLength);
            }
        }

        public string Symbol
        {
            get
            {
                if (SymbolAndPowerReader.TryRead(this.Conversion.Symbol, out var symbolAndPowers))
                {
                    return symbolAndPowers.Select(x => new SymbolAndPower(x.Symbol, x.Power * this.Power)).AsSymbol();
                }

                return "Error";
            }
        }

        public double Factor => Math.Pow(this.Conversion.Factor, this.Power);

        internal IReadOnlyList<SymbolAndPower> AsSymbolAndPowers()
        {
            if (SymbolAndPowerReader.TryRead(this.Conversion.Symbol, out var symbolAndPowers))
            {
                return symbolAndPowers.Select(x => new SymbolAndPower(x.Symbol, x.Power * this.Power)).ToList();
            }

            throw new InvalidOperationException();
        }

        private static string CreateName(int power, string name, bool isLength)
        {
            name = name.TrimStart('@');
            power = Math.Abs(power);
            if (isLength)
            {
                return power switch
                {
                    1 => name,
                    2 => $"Square{name}",
                    3 => $"Cubic{name}",
                    _ => throw new ArgumentOutOfRangeException(nameof(power), power, "Not handling this kind of power!"),
                };
            }

            return power switch
            {
                1 => name,
                2 => $"{name}Squared",
                3 => $"{name}Cubed",
                _ => throw new ArgumentOutOfRangeException(nameof(power), power, "Not handling this kind of power!"),
            };
        }

        private static bool IsLength(IConversion conversion)
        {
            return conversion.Unit.QuantityName == "Length";
        }
    }
}
