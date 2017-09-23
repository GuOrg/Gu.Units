``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 7 SP1 (6.1.7601)
Processor=Intel Xeon CPU E5-2637 v4 3.50GHzIntel Xeon CPU E5-2637 v4 3.50GHz, ProcessorCount=16
Frequency=3410097 Hz, Resolution=293.2468 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2114.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2114.0


```
 |                     Method |     Mean |    Error |   StdDev | Scaled | ScaledSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
 |--------------------------- |---------:|---------:|---------:|-------:|---------:|-------:|-------:|-------:|----------:|
 |               StringConcat | 618.7 ns | 13.56 ns | 39.77 ns |   1.00 |     0.00 | 0.0391 |      - |      - |     248 B |
 |    ToStringCompositeFormat | 641.8 ns | 12.89 ns | 34.41 ns |   1.04 |     0.09 | 0.0381 | 0.0153 | 0.0010 |     245 B |
 | ToStringFormatValueAndUnit | 679.0 ns | 13.71 ns | 34.89 ns |   1.10 |     0.09 | 0.0410 | 0.0162 | 0.0010 |     261 B |
