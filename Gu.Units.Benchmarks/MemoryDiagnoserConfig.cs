namespace Gu.Units.Benchmarks
{
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnostics.Windows;

    public class MemoryDiagnoserConfig : ManualConfig
    {
        public MemoryDiagnoserConfig()
        {
            this.Add(new MemoryDiagnoser());
        }
    }
}