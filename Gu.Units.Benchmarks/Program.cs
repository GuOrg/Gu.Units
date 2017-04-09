// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedParameter.Local
// ReSharper disable PossibleNullReferenceException
namespace Gu.Units.Benchmarks
{
    using System.Collections.Generic;
    using System.IO;
    using BenchmarkDotNet.Reports;
    using BenchmarkDotNet.Running;

    public class Program
    {
        private static readonly string DesinationDirectory = System.IO.Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Benchmarks");

        public static void Main()
        {
            foreach (var summary in RunSingle<Format>())
            {
                CopyResult(summary.Title);
            }
        }

        private static IEnumerable<Summary> RunAll()
        {
            ClearAllResults();
            var switcher = new BenchmarkSwitcher(typeof(Program).Assembly);
            var summaries = switcher.Run(new[] { "*" });
            return summaries;
        }

        private static IEnumerable<Summary> RunSingle<T>()
        {
            var summaries = new[] { BenchmarkRunner.Run<T>() };
            return summaries;
        }

        private static void CopyResult(string name)
        {
#if DEBUG
#else
            var sourceFileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "BenchmarkDotNet.Artifacts", "results", name + "-report-github.md");
            System.IO.Directory.CreateDirectory(DesinationDirectory);
            var destinationFileName = System.IO.Path.Combine(DesinationDirectory, name + ".md");
            File.Copy(sourceFileName, destinationFileName, true);
#endif
        }

        private static void ClearAllResults()
        {
            if (Directory.Exists(DesinationDirectory))
            {
                foreach (var resultFile in Directory.EnumerateFiles(DesinationDirectory, "*.md"))
                {
                    File.Delete(resultFile);
                }
            }
        }
    }
}
