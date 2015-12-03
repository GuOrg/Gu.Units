namespace Gu.Units.Tests
{
    using System.Reflection;

    using Gu.Units.Tests.Sources;

    using NUnit.Framework;

    public class UnitTests
    {
        [TestCaseSource(typeof(UnitsProvider))]
        public void Roundtrip(IUnit unit)
        {
            var s = unit.ToString();
            var parseMethod = unit.GetType().GetMethod("Parse", BindingFlags.Static | BindingFlags.Public);
            var roundtripped = (IUnit)parseMethod.Invoke(null, new object[] { s });
            Assert.AreEqual(unit, roundtripped);
        }
    }
}
