namespace Gu.Units.Json.Tests
{
    using System.Globalization;
    using Newtonsoft.Json;
    using NUnit.Framework;

    public static class SerializationTests
    {
        [Test]
        public static void ToJsonDegrees()
        {
            var dummyClass = new DummyClass { Angle = Angle.FromDegrees(1.23) };
            var settings = CreateSettings(AngleJsonConverter.Degrees, "sv-SE");
            var actual = JsonConvert.SerializeObject(dummyClass, settings);
            Assert.AreEqual("{\"Angle\":\"1,23�\"}", actual);
        }

        [Test]
        public static void ToJsonRadians()
        {
            var dummyClass = new DummyClass { Angle = Angle.FromRadians(1.23) };
            var settings = CreateSettings(AngleJsonConverter.Radians, "en-US");
            var actual = JsonConvert.SerializeObject(dummyClass, settings);
            Assert.AreEqual("{\"Angle\":\"1.23\u00A0rad\"}", actual);
        }

        [TestCase("{\"Angle\":\"1,23�\"}", "sv-SE")]
        [TestCase("{\"Angle\":\"1.23�\"}", "en-US")]
        public static void FromJsonDefault(string json, string culture)
        {
            var settings = CreateSettings(AngleJsonConverter.Default, culture);
            var actual = JsonConvert.DeserializeObject<DummyClass>(json, settings);
            Assert.AreEqual(Angle.FromDegrees(1.23), actual.Angle);
        }

        [TestCase("{\"Angle\":\"1,23�\"}", "sv-SE")]
        [TestCase("{\"Angle\":\"1.23�\"}", "en-US")]
        public static void FromJsonDegrees(string json, string culture)
        {
            var settings = CreateSettings(AngleJsonConverter.Degrees, culture);
            var actual = JsonConvert.DeserializeObject<DummyClass>(json, settings);
            Assert.AreEqual(Angle.FromDegrees(1.23), actual.Angle);
        }

        [TestCase("{\"Angle\":\"1,23�\"}", "sv-SE")]
        [TestCase("{\"Angle\":\"1.23�\"}", "en-US")]
        public static void FromJsonRadians(string json, string culture)
        {
            // yes radians converter can read degrees it only outputs radians
            var settings = CreateSettings(AngleJsonConverter.Default, culture);
            var actual = JsonConvert.DeserializeObject<DummyClass>(json, settings);
            Assert.AreEqual(Angle.FromDegrees(1.23), actual.Angle);
        }

        private static JsonSerializerSettings CreateSettings(AngleJsonConverter converter, string culture)
        {
            return new JsonSerializerSettings
            {
                Converters = new JsonConverter[] { converter },
                Culture = CultureInfo.GetCultureInfo(culture),
            };
        }
    }
}
