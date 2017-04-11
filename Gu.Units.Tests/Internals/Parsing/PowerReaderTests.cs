namespace Gu.Units.Tests.Internals.Parsing
{
    using System.Collections.Generic;
    using NUnit.Framework;

    public class PowerReaderTests
    {
        // ReSharper disable once UnusedMember.Local
        private const string Superscripts = "⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹"; // keeping this here for copy pasting
        private static readonly IReadOnlyList<SuccessCase<int>> HappyPaths = new[]
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

        private static readonly IReadOnlyList<ErrorCase<int>> ErrorSource = new[]
                                                                                {
                                                                                    ErrorCase.Create<int>("mm^--2", 0),
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
            int actual;
            var success = PowerReader.TryRead(data.Text, ref end, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(data.Expected, actual);
            Assert.AreEqual(data.ExpectedEnd, end);
        }
    }
}
