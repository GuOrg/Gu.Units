namespace Gu.Units.Tests
{
    using System;
    using NUnit.Framework;

    public class SymbolAndPowerTests
    {
        private const string Superscripts = "⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";

        internal static readonly Sign[] Signs = { Sign.Positive, Sign.Negative };

        [TestCase("m", "m", 1)]
        [TestCase(" m", "m", 1)]
        [TestCase("m^1", "m", 1)]
        [TestCase(" m ^ 1", "m", 1)]
        [TestCase("m⁻¹", "m", -1)]
        [TestCase("m^-1", "m", -1)]
        [TestCase("m¹", "m", 1)]
        [TestCase("m^2", "m", 2)]
        [TestCase("m^-2", "m", -2)]
        [TestCase("m²", "m", 2)]
        [TestCase("m¹", "m", 1)]
        [TestCase("m³", "m", 3)]
        [TestCase("m⁹", "m", 9)]
        [TestCase("kg⁹", "kg", 9)]
        [TestCase("°", "°", 1)]
        public void SimpleSymbol(string s, string symbol, int power)
        {
            foreach (var si in Signs)
            {
                Sign sign = si;
                int pos = 0;
                SymbolAndPower sap;
                if (power < 0 && sign == Sign.Negative)
                {
                    Assert.Throws<FormatException>(() => SymbolAndPower.Read(s, ref pos, ref sign));
                    return;
                }
                sap = SymbolAndPower.Read(s, ref pos, ref sign);
                Assert.AreEqual(symbol, sap.Symbol);
                if (si == Sign.Negative)
                {
                    Assert.AreEqual(-1 * power, sap.Power);
                }
                else
                {
                    Assert.AreEqual(power, sap.Power);
                }
            }
        }
    }
}