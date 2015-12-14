namespace Gu.Units.Generator.Tests.Views
{
    using System.Linq;
    using NUnit.Framework;

    public class PrefixConversionsVmTests
    {
        [Test]
        public void SetBaseUnitToMetres()
        {
            var settings = MockSettings.Create();
            var vm = new PrefixConversionsVm(settings);
            CollectionAssert.IsEmpty(vm.Prefixes);

            vm.SetBaseUnit(settings.Metres);
            var expected = new[]
            {
                PrefixConversionVm.Create(settings.Metres, settings.Micro),
                PrefixConversionVm.Create(settings.Metres, settings.Milli),
                PrefixConversionVm.Create( settings.Metres, settings.Kilo),
            };

            CollectionAssert.AreEqual(expected, vm.Prefixes.Single(), PrefixConversionVmComparer.Default);

            vm.SetBaseUnit(null);
            CollectionAssert.IsEmpty(vm.Prefixes);
        }

        [Test]
        public void SetBaseUnitToKilograms()
        {
            var settings = MockSettings.Create();
            var vm = new PrefixConversionsVm(settings);
            CollectionAssert.IsEmpty(vm.Prefixes);

            vm.SetBaseUnit(settings.Kilograms);
            var expected = new[]
            {
                PrefixConversionVm.Create(settings.Grams, settings.Micro),
                PrefixConversionVm.Create(settings.Grams, settings.Milli),
            };

            CollectionAssert.AreEqual(expected, vm.Prefixes.Single(), PrefixConversionVmComparer.Default);
            vm.SetBaseUnit(null);
            CollectionAssert.IsEmpty(vm.Prefixes);
        }
    }
}
