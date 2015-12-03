namespace Gu.Units.Tests.Internals.Helpers
{
    using NUnit.Framework;

    public class MapTests
    {
        [Test]
        public void TryGetSuccess()
        {
            var map = new Map<int, string>();
            map.TryAdd(1, "1");
            map.TryAdd(2, "2");

            string actualString;
            Assert.True(map.TryGet(1, out actualString));
            Assert.AreEqual("1", actualString);

            int actualInt;
            Assert.True(map.TryGet("1", out actualInt));
            Assert.AreEqual(1, actualInt);
        }

        [Test]
        public void TryGetFail()
        {
            var map = new Map<int, string>();
            map.TryAdd(1, "1");
            map.TryAdd(2, "2");

            string actualString;
            Assert.False(map.TryGet(3, out actualString));
            Assert.AreEqual(null, actualString);

            int actualInt;
            Assert.False(map.TryGet("3", out actualInt));
            Assert.AreEqual(0, actualInt);
        }
    }
}
