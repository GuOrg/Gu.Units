namespace Gu.Units.Tests.Internals.Parsing
{
    using NUnit.Framework;

    // ⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹
    public class PowerReaderTests
    {
        private static readonly SuccessCase<int>[] HappyPaths =
        {
            SuccessCase.Create("mm", 2, 1, 2),
            SuccessCase.Create("mm^2", 2, 2, 4),
            SuccessCase.Create("mm^-2", 2, -2, 5),
            SuccessCase.Create("mm⁰", 2, 0, 3),
            SuccessCase.Create("mm²", 2, 2, 3),
            SuccessCase.Create("mm⁺²", 2, 2, 4),
            SuccessCase.Create("mm⁺¹²", 2, 12, 5),
            SuccessCase.Create("mm¹²", 2, 12, 4),
            SuccessCase.Create("mm⁻¹²", 2, -12, 5),
            SuccessCase.Create("mm", 2, 1, 2),
        };

        [TestCaseSource(nameof(HappyPaths))]
        public void ReadSuccess(SuccessCase<int> data)
        {
            var end = data.Start;
            var actual = PowerReader.Read(data.Text, ref end);
            Assert.AreEqual(data.Expected, actual);
            Assert.AreEqual(data.ExpectedEnd, end);
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void TryReadSuccess(SuccessCase<int> data)
        {
            var end = data.Start;
            Assert.AreEqual(true, PowerReader.TryRead(data.Text, ref end, out var actual));
            Assert.AreEqual(data.Expected, actual);
            Assert.AreEqual(data.ExpectedEnd, end);
        }
    }
}
