namespace Gu.Units.Tests.Sandbox
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    public class DumpMarkdown
    {
        [Test]
        public void DumpQuantityTypes()
        {
            var quantityTypes = typeof(Length).Assembly.GetTypes()
                                      .Where(x => x.GetInterface(nameof(IQuantity)) != null && x.IsValueType)
                                      .ToArray();
            foreach (var quantityType in quantityTypes)
            {
                Console.WriteLine($" - {quantityType.Name}");
            }
        }
    }
}
