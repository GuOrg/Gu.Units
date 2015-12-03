namespace Gu.Units.Tests.Internals.Parsing
{
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class SymbolAndPowerParserSetTests
    {
        [TestCaseSource(nameof(HappyPaths))]
        public void TryReadSuccess(ISuccessData data)
        {
            var pos = data.Start;
            IReadOnlyList<SymbolAndPower> actual;
            var success = SymbolAndPowerReader.TryRead(data.Text, ref pos, out actual);
            //Console.WriteLine("expected: {0}", data.ToString(data.Tokens));
            //Console.WriteLine("actual:   {0}", data.ToString(actual));
            Assert.AreEqual(true, success);
            Assert.AreEqual(data.ExpectedEnd, pos);
            CollectionAssert.AreEqual((IEnumerable)data.Expected, actual);
        }

        [TestCaseSource(nameof(Errors))]
        public void TryTokenizeError(IErrorData data)
        {
            var pos = data.Start;
            IReadOnlyList<SymbolAndPower> actual;
            var success = SymbolAndPowerReader.TryRead(data.Text, ref pos, out actual);
            Assert.AreEqual(false, success);
            Assert.AreEqual(data.Start, pos);
            CollectionAssert.AreEqual(null, actual);
        }

        private const string Superscripts = "⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";

        internal static readonly IReadOnlyList<SuccessData<IReadOnlyList<SymbolAndPower>>> HappyPaths = new[]
        {
            SuccessData.Create("m", new SymbolAndPower("m", 1)),
            SuccessData.Create(" m ", new SymbolAndPower("m", 1)),
            SuccessData.Create("m^2", new SymbolAndPower("m", 2)),
            SuccessData.Create(" m ^ 2", new SymbolAndPower("m", 2)),
            SuccessData.Create(" m ^ -2", new SymbolAndPower("m", -2)),
            SuccessData.Create("m^1/s^2", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2)),
            SuccessData.Create("m¹/s²", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2)),
            SuccessData.Create("m⁺¹/s²", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2)),
            SuccessData.Create("m⁺¹/s²*g", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2), new SymbolAndPower("g", -1)),
            SuccessData.Create("m¹⋅s⁻²", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2)),
            SuccessData.Create("m⁻¹⋅s⁻²", new SymbolAndPower("m", -1), new SymbolAndPower("s", -2)),
        };

        internal static readonly IReadOnlyList<SuccessData<IReadOnlyList<SymbolAndPower>>> Errors = new[]
        {
            ErrorData.CreateForSymbol("m⁻¹/s⁻²"),
            ErrorData.CreateForSymbol("m⁻⁻¹"),
            ErrorData.CreateForSymbol("m⁺⁻¹"),
            ErrorData.CreateForSymbol("m+⁻¹"),
            ErrorData.CreateForSymbol("m^¹/s⁻²"),
        };
    }
}
