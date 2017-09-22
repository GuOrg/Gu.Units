[assembly: BenchmarkDotNet.Attributes.Config(typeof(Gu.Units.Benchmarks.MemoryDiagnoserConfig))]
namespace Gu.Units.Benchmarks
{
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;

    public class MemoryDiagnoserConfig : ManualConfig
    {
        public MemoryDiagnoserConfig()
        {
            this.Add(new MemoryDiagnoser());
        }
    }
}