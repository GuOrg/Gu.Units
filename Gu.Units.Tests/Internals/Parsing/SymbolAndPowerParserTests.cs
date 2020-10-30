namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using NUnit.Framework;

    // ⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹
    public class SymbolAndPowerParserTests
    {
        private static readonly SuccessCase<SymbolAndPower>[] HappyPaths =
        {
            SuccessCase.Create("m", 0, new SymbolAndPower("m", 1), 1),
            SuccessCase.Create(" m", 1, new SymbolAndPower("m", 1), 2),
            SuccessCase.Create("m^1", 0, new SymbolAndPower("m", 1), 3),
            SuccessCase.Create(" m ^ 1", 1, new SymbolAndPower("m", 1), 6),
            SuccessCase.Create("m⁻¹", 0, new SymbolAndPower("m", -1), 3),
            SuccessCase.Create("m^-1", 0, new SymbolAndPower("m", -1), 4),
            SuccessCase.Create("m¹", 0, new SymbolAndPower("m", 1), 2),
            SuccessCase.Create("m^2", 0, new SymbolAndPower("m", 2), 3),
            SuccessCase.Create("m^-2", 0, new SymbolAndPower("m", -2), 4),
            SuccessCase.Create("m²", 0, new SymbolAndPower("m", 2), 2),
            SuccessCase.Create("m⁻²", 0, new SymbolAndPower("m", -2), 3),
            SuccessCase.Create("m¹", 0, new SymbolAndPower("m", 1), 2),
            SuccessCase.Create("m³", 0, new SymbolAndPower("m", 3), 2),
            SuccessCase.Create("°", 0, new SymbolAndPower("°", 1), 1),
        };

        private static readonly SuccessCase<SymbolAndPower>[] Errors =
        {
            ErrorCase.Create<SymbolAndPower>("m¹²", 0),
            ErrorCase.Create<SymbolAndPower>("m⁻¹²", 0),
            ErrorCase.Create<SymbolAndPower>("m⁻⁻2", 0),
            ErrorCase.Create<SymbolAndPower>("m^12", 0),
            ErrorCase.Create<SymbolAndPower>("m^-12", 0),
            ErrorCase.Create<SymbolAndPower>("m^--2", 0),
            ////ErrorData.Create<SymbolAndPower>("m-", 0),
        };

        [TestCaseSource(nameof(HappyPaths))]
        public void ParseSuccess(ISuccessData data)
        {
            var pos = data.Start;
            var actual = SymbolAndPowerReader.Read(data.Text, ref pos);
            Assert.AreEqual(data.Expected, actual);
            Assert.AreEqual(data.ExpectedEnd, pos);
        }

        [TestCaseSource(nameof(Errors))]
        public void ParseError(IErrorCase @case)
        {
            var pos = @case.Start;
            Assert.Throws<FormatException>(() => SymbolAndPowerReader.Read(@case.Text, ref pos));
            Assert.AreEqual(@case.ExpectedEnd, pos);
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void TryParseSuccess(ISuccessData data)
        {
            var pos = data.Start;
            Assert.AreEqual(true, SymbolAndPowerReader.TryRead(data.Text, ref pos, out SymbolAndPower actual));
            Assert.AreEqual(data.Expected, actual);
            Assert.AreEqual(data.ExpectedEnd, pos);
        }

        [TestCaseSource(nameof(Errors))]
        public void TryParseError(IErrorCase @case)
        {
            var pos = @case.Start;
            Assert.AreEqual(false, SymbolAndPowerReader.TryRead(@case.Text, ref pos, out SymbolAndPower sap));
            Assert.AreEqual(default(SymbolAndPower), sap);
            Assert.AreEqual(@case.ExpectedEnd, pos);
        }
    }
}