namespace Gu.Units.Tests.Internals.Parsing
{
    using NUnit.Framework;

    public class SkipperTests
    {
        [TestCase("abc", "abc", 0, 3)]
        [TestCase("abc", "a", 0, 1)]
        [TestCase(" abc", "a", 1, 2)]
        [TestCase(" abc", "ab", 1, 3)]
        [TestCase(" abc", "abc", 1, 4)]
        public void TrySkipSuccess(string text, string toSkip, int pos, int expectedPos)
        {
            var success = Skipper.TrySkip(text, ref pos, toSkip);
            Assert.AreEqual(true, success);
            Assert.AreEqual(expectedPos, pos);
        }

        [TestCase("abc", null, 0)]
        [TestCase(" abc", "", 1)]
        [TestCase("abc", "b", 0)]
        [TestCase("abc", "bc", 0)]
        public void TrySkipError(string text, string toSkip, int pos)
        {
            var expectedPos = pos;
            var success = Skipper.TrySkip(text, ref pos, toSkip);
            Assert.AreEqual(false, success);
            Assert.AreEqual(expectedPos, pos);
        }
    }
}
