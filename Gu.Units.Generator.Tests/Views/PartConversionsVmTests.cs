namespace Gu.Units.Generator.Tests.Views
{
    using System.Linq;
    using NUnit.Framework;

    public static class PartConversionsVmTests
    {
        [Test]
        public static void SetUnitToKilograms()
        {
            using var settings = MockSettings.Create();
            using var vm = new PartConversionsVm();
            vm.SetUnit(settings.Kilograms);
            CollectionAssert.IsEmpty(vm.Conversions);
        }

        [Test]
        public static void SetUnitToCubicMetres()
        {
            using var settings = MockSettings.Create();
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
        public static void SetUnitToMetresPerSecond()
        {
            Assert.Inconclusive();
            //// ReSharper disable once HeuristicUnreachableCode
            using var settings = MockSettings.Create();
            using var vm = new PartConversionsVm();
            vm.SetUnit(settings.MetresPerSecond);
            CollectionAssert.IsEmpty(vm.Conversions);
        }
    }
}