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

            Assert.True(map.TryGet(1, out string actualString));
            Assert.AreEqual("1", actualString);

            Assert.True(map.TryGet("1", out int actualInt));
            Assert.AreEqual(1, actualInt);
        }

        [Test]
        public void TryGetFail()
        {
            var map = new Map<int, string>();
            map.TryAdd(1, "1");
            map.TryAdd(2, "2");

            Assert.False(map.TryGet(3, out string actualString));
            Assert.AreEqual(null, actualString);

            Assert.False(map.TryGet("3", out int actualInt));
            Assert.AreEqual(0, actualInt);
        }
    }
}
