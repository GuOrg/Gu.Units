namespace Gu.Units.Generator.Tests.Descriptors
{
    using System.Linq;
    using NUnit.Framework;

    public class UnitPartsTests
    {
        private MockSettings _settings;
        [SetUp]
        public void SetUp()
        {
            this._settings = new MockSettings();
        }

        [Test]
        public void Multiply()
        {
            var up1 = new UnitParts(this._settings.Metres, new UnitAndPower(this._settings.Metres, 1));
            var up2 = new UnitParts(this._settings.Seconds, new UnitAndPower(this._settings.Seconds, -1));
            var prod = up1 * up2;
            Assert.AreEqual(2, prod.Count);
            Assert.AreEqual(1, prod.Single(x=>x.Unit ==this._settings.Metres).Power);
            Assert.AreEqual(-1, prod.Single(x => x.Unit == this._settings.Seconds).Power);
        }

        [Test]
        public void MultiplyMetresMetres()
        {
            var up1 = new UnitParts(this._settings.Metres, new UnitAndPower(this._settings.Metres, 1));
            var up2 = new UnitParts(this._settings.Metres, new UnitAndPower(this._settings.Metres, 1));
            var prod = up1 * up2;
            Assert.AreEqual(1, prod.Count);
            Assert.AreEqual(2, prod.Single(x => x.Unit == this._settings.Metres).Power);
        }

        [Test]
        public void DivideMetresSeconds()
        {
            var up1 = new UnitParts(this._settings.Metres, new UnitAndPower(this._settings.Metres, 1));
            var up2 = new UnitParts(this._settings.Seconds, new UnitAndPower(this._settings.Seconds, 1));
            var prod = up1 / up2;
            Assert.AreEqual(2, prod.Count);
            Assert.AreEqual(1, prod.Single(x => x.Unit == this._settings.Metres).Power);
            Assert.AreEqual(-1, prod.Single(x => x.Unit == this._settings.Seconds).Power);
        }

        [Test]
        public void DivideMetresMetres()
        {
            var up1 = new UnitParts(this._settings.Metres, new UnitAndPower(this._settings.Metres, 1));
            var up2 = new UnitParts(this._settings.Metres, new UnitAndPower(this._settings.Metres, 1));
            var prod = up1 / up2;
            Assert.AreEqual(0, prod.Count);
        }

        [Test]
        public void FlattenFarads()
        {
            var farads = new UnitParts(null, new UnitAndPower(this._settings.Coloumbs, 1), new UnitAndPower(this._settings.Volts, -1));
            var ups = farads.Flattened.ToArray();
            Assert.AreEqual(4, ups.Length);
            Assert.AreEqual(-1, ups.Single(x => x.Unit == this._settings.Kilograms).Power);
            Assert.AreEqual(-2, ups.Single(x => x.Unit == this._settings.Metres).Power);
            Assert.AreEqual(4, ups.Single(x => x.Unit == this._settings.Seconds).Power);
            Assert.AreEqual(2, ups.Single(x => x.Unit == this._settings.Amperes).Power);
        }
    }
}
