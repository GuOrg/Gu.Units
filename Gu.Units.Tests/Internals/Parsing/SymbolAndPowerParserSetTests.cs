namespace Gu.Units.Tests.Internals.Parsing
{
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class SymbolAndPowerParserSetTests
    {
        // ReSharper disable once UnusedMember.Local
        private const string Superscripts = "⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";

        private static readonly IReadOnlyList<SuccessCase<IReadOnlyList<SymbolAndPower>>> HappyPaths = new[]
                                                                                                            {
                                                                                                                SuccessCase.Create("m", new SymbolAndPower("m", 1)),
                                                                                                                SuccessCase.Create(" m ", new SymbolAndPower("m", 1)),
                                                                                                                SuccessCase.Create("m^2", new SymbolAndPower("m", 2)),
                                                                                                                SuccessCase.Create(" m ^ 2", new SymbolAndPower("m", 2)),
                                                                                                                SuccessCase.Create(" m ^ -2", new SymbolAndPower("m", -2)),
                                                                                                                SuccessCase.Create("m^1/s^2", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2)),
                                                                                                                SuccessCase.Create("m¹/s²", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2)),
                                                                                                                SuccessCase.Create("m⁺¹/s²", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2)),
                                                                                                                SuccessCase.Create("m⁺¹/s²*g", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2), new SymbolAndPower("g", -1)),
                                                                                                                SuccessCase.Create("m¹⋅s⁻²", new SymbolAndPower("m", 1), new SymbolAndPower("s", -2)),
                                                                                                                SuccessCase.Create("m⁻¹⋅s⁻²", new SymbolAndPower("m", -1), new SymbolAndPower("s", -2)),
                                                                                                            };

        private static readonly IReadOnlyList<SuccessCase<IReadOnlyList<SymbolAndPower>>> Errors = new[]
                                                                                                        {
                                                                                                            ErrorCase.CreateForSymbol("m⁻¹/s⁻²"),
                                                                                                            ErrorCase.CreateForSymbol("m⁻⁻¹"),
                                                                                                            ErrorCase.CreateForSymbol("m⁺⁻¹"),
                                                                                                            ErrorCase.CreateForSymbol("m+⁻¹"),
                                                                                                            ErrorCase.CreateForSymbol("m^¹/s⁻²"),
                                                                                                        };

        [TestCaseSource(nameof(HappyPaths))]
        public void TryReadSuccess(ISuccessData data)
        {
            var pos = data.Start;
            IReadOnlyList<SymbolAndPower> actual;
            var success = SymbolAndPowerReader.TryRead(data.Text, ref pos, out actual);
            ////Console.WriteLine("expected: {0}", data.ToString(data.Tokens));
            ////Console.WriteLine("actual:   {0}", data.ToString(actual));
            Assert.AreEqual(true, success);
            Assert.AreEqual(data.ExpectedEnd, pos);
            CollectionAssert.AreEqual((IEnumerable)data.Expected, actual);
        }

        [TestCaseSource(nameof(Errors))]
        public void TryTokenizeError(IErrorCase @case)
        {
            var pos = @case.Start;
            IReadOnlyList<SymbolAndPower> actual;
            var success = SymbolAndPowerReader.TryRead(@case.Text, ref pos, out actual);
            Assert.AreEqual(false, success);
            Assert.AreEqual(@case.Start, pos);
            CollectionAssert.AreEqual(null, actual);
        }
    }
}
