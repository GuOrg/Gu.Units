namespace Gu.Units.Generator.Tests
{
    using System.Linq;
    using NUnit.Framework;

    public class UnitPartsTests
    {
        private MockSettings _settings;
        [SetUp]
        public void SetUp()
        {
            _settings = new MockSettings();
        }

        [Test]
        public void Multiply()
        {
            var up1 = new UnitParts(_settings.Metres, new UnitAndPower(_settings.Metres, 1));
            var up2 = new UnitParts(_settings.Seconds, new UnitAndPower(_settings.Seconds, -1));
            var prod = up1 * up2;
            Assert.AreEqual(2, prod.Count);
            Assert.AreEqual(1, prod.Single(x=>x.Unit ==_settings.Metres).Power);
            Assert.AreEqual(-1, prod.Single(x => x.Unit == _settings.Seconds).Power);
        }

        [Test]
        public void MultiplyMetresMetres()
        {
            var up1 = new UnitParts(_settings.Metres, new UnitAndPower(_settings.Metres, 1));
            var up2 = new UnitParts(_settings.Metres, new UnitAndPower(_settings.Metres, 1));
            var prod = up1 * up2;
            Assert.AreEqual(1, prod.Count);
            Assert.AreEqual(2, prod.Single(x => x.Unit == _settings.Metres).Power);
        }

        [Test]
        public void DivideMetresSeconds()
        {
            var up1 = new UnitParts(_settings.Metres, new UnitAndPower(_settings.Metres, 1));
            var up2 = new UnitParts(_settings.Seconds, new UnitAndPower(_settings.Seconds, 1));
            var prod = up1 / up2;
            Assert.AreEqual(2, prod.Count);
            Assert.AreEqual(1, prod.Single(x => x.Unit == _settings.Metres).Power);
            Assert.AreEqual(-1, prod.Single(x => x.Unit == _settings.Seconds).Power);
        }

        [Test]
        public void DivideMetresMetres()
        {
            var up1 = new UnitParts(_settings.Metres, new UnitAndPower(_settings.Metres, 1));
            var up2 = new UnitParts(_settings.Metres, new UnitAndPower(_settings.Metres, 1));
            var prod = up1 / up2;
            Assert.AreEqual(0, prod.Count);
        }

        [Test]
        public void FlattenFarads()
        {
            var farads = new UnitParts(null, new UnitAndPower(_settings.Coloumbs, 1), new UnitAndPower(_settings.Volts, -1));
            var ups = farads.Flattened.ToArray();
            Assert.AreEqual(4, ups.Length);
            Assert.AreEqual(-1, ups.Single(x => x.Unit == _settings.Kilograms).Power);
            Assert.AreEqual(-2, ups.Single(x => x.Unit == _settings.Metres).Power);
            Assert.AreEqual(4, ups.Single(x => x.Unit == _settings.Seconds).Power);
            Assert.AreEqual(2, ups.Single(x => x.Unit == _settings.Amperes).Power);
        }
    }
}
