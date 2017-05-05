namespace Gu.Units.Generator.Tests.Scripts
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    public class DumpMissing
    {
        [Test]
        public void Run()
        {
            foreach (var overloads in Settings.Instance.Missing.Where(x => x.Parts.All(p => p.Power < 5))
                                                               .Where(x => x.Missing.Count > 1)
                                                               .OrderByDescending(x => x.Missing.Count))
            {
                Console.WriteLine($"{overloads.Parts} {overloads.Missing.Count}");
            }
        }
    }
}
