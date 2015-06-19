namespace Gu.Units.Tests.Sources
{
    using System.Collections.Generic;

    public class TokenSource : List<TokenSource.TokenData>
    {
        private const string Superscripts = "⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";
        public TokenSource()
        {
            Add(new TokenData("m", new SymbolAndPower("m", 1)));
            Add(new TokenData(" m ", new SymbolAndPower("m", 1)));
            Add(new TokenData("m^2", new SymbolAndPower("m", 2)));
            Add(new TokenData(" m ^ 2", new SymbolAndPower("m", 2)));
            Add(new TokenData(" m ^ -2", new SymbolAndPower("m", -2)));
            Add(new TokenData("m^1/s^2", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2)));
            Add(new TokenData("m¹/s²", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2)));
            Add(new TokenData("m⁺¹/s²", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2)));
            Add(new TokenData("m⁺¹/s²*g", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2), new SymbolAndPower("g", -1)));
            Add(new TokenData("m¹⋅s⁻²", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2)));
            Add(new TokenData("m⁻¹⋅s⁻²", new SymbolAndPower("m", -1), new SymbolAndPower("s", -2)));
            Add(new TokenData("m⁻¹/s⁻²", null));
            Add(new TokenData("m⁻⁻¹/s⁻²", null));
            Add(new TokenData("m⁺⁻¹/s⁻²", null));
            Add(new TokenData("m+⁻¹/s⁻²", null));
            Add(new TokenData("m^¹/s⁻²", null));
        }

        public class TokenData
        {
            public readonly string Text;
            public readonly IReadOnlyList<SymbolAndPower> Tokens;

            public TokenData(string text, params SymbolAndPower[] tokens)
            {
                Text = text;
                Tokens = tokens;
            }

            public override string ToString()
            {
                var tokens = "Exception";
                if (Tokens != null)
                {
                    tokens = ToString(Tokens);
                }
                return string.Format("Text: {0}, Tokens: {1}", Text, Tokens);
            }

            public string ToString(IEnumerable<SymbolAndPower> tokens)
            {
                return string.Join(", ", tokens);
            }
        }
    }
}