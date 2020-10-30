namespace Gu.Units.Generator.Tests.Views
{
    using System.Linq;
    using NUnit.Framework;

    public class PartConversionsVmTests
    {
        [Test]
        public void SetUnitToKilograms()
        {
            var settings = MockSettings.Create();
            using var vm = new PartConversionsVm();
            vm.SetUnit(settings.Kilograms);
            CollectionAssert.IsEmpty(vm.Conversions);
        }

        [Test]
        public void SetUnitToCubicMetres()
        {
            var settings = MockSettings.Create();
            using var vm = new PartConversionsVm();
            vm.SetUnit(settings.CubicMetres);
            var metresPart = new PowerPart(3, new IdentityConversion(settings.Metres));
            var metresConversion = PartConversion.Create(settings.CubicMetres, metresPart);
            var expected = new[]
            {
                new PartConversionVm(settings.CubicMetres, metresConversion),
            };

            Assert.AreEqual(expected[0].Conversion.Name, vm.Conversions.Single().Single().Conversion.Name);
        }

        [Test]
        public void SetUnitToMetresPerSecond()
        {
            Assert.Inconclusive();
            //// ReSharper disable once HeuristicUnreachableCode
            var settings = MockSettings.Create();
            using var vm = new PartConversionsVm();
            vm.SetUnit(settings.MetresPerSecond);
            CollectionAssert.IsEmpty(vm.Conversions);
        }
    }
}