namespace Gu.Units.Generator.Tests
{
    using NUnit.Framework;

    public class SiUnitTests
    {
        [Test]
        public void TestNameTest()
        {
            SiUnit unit;
            unit = new SiUnit("Gu.Units", "Metres", "m")
                         {
                             Quantity = new Quantity("Gu.Units", "Length", null)
                         };
            unit.SubUnits.Add(new SubUnit("Gu.Units", "Centimetres", "cm", 1E-2));
            unit.SubUnits.Add(new SubUnit("Gu.Units", "Millimetres", "mm", 1E-3));
        }
    }
}
