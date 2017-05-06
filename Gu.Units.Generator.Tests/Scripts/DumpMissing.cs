namespace Gu.Units.Generator.Tests.Scripts
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using NUnit.Framework;

    public class DumpMissing
    {
        //// ReSharper disable UnusedMember.Local
        private const string Superscripts = "⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";
        private const char MultiplyDot = '⋅';
        //// ReSharper restore UnusedMember.Local

        [Test]
        public void Run()
        {
            Settings.InnerInstance = null;
            var settings = Settings.FromResource;
            foreach (var overloads in settings.Missing
                .Where(x => x.Parts.All(p => p.Power < 5 && p.Power > -5))
                .OrderByDescending(x => x.Missing.Count)
                .Take(100))
            {
                Console.WriteLine($"{overloads.Missing.Count}: {overloads.Parts}");
            }
        }

        [Explicit]
        [Test]
        public async Task SiDerivedUnitsFromWikipedia()
        {
            using (var client = new WebClient())
            {
                var text = await client
                    .DownloadStringTaskAsync(
                        @"https://en.wikipedia.org/w/api.php?action=parse&page=SI_derived_unit&section=1&prop=wikitext&format=json&contentmodel=json")
                    .ConfigureAwait(continueOnCapturedContext: false);
                var lines = text
                    .Replace("\\n| align = \\\"center\\\"", string.Empty)
                    .Replace("| align=\\\"center\\\" | ", "| |")
                    .Replace("\\u22c5", "⋅")
                    .Replace("<sup>2</sup>", "²")
                    .Replace("<sup>3</sup>", "³")
                    .Replace("<sup>&minus;1</sup>", "⁻¹")
                    .Replace("<sup>&minus;2</sup>", "⁻²")
                    .Replace("<sup>&minus;3</sup>", "⁻³")
                    .Split(new[] { "-\\n" }, StringSplitOptions.None);
                foreach (var line in lines.Where(l => l.StartsWith("| '''")))
                {
                    var clean = line.Replace("| '''[[", "| ")
                        .Replace("]]'''|", " |")
                        .Replace("| '''", "| ")
                        .Replace("\'\'\'\\n|", " |")
                        .Replace("| [[", "| ")
                        .Replace("]]|", " |")
                        .Replace("\\n|", " |");
                    Console.WriteLine(clean);
                }
            }
        }
    }
}
