``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 7 SP1 (6.1.7601)
Processor=Intel Xeon CPU E5-2637 v4 3.50GHz, ProcessorCount=8
Frequency=3410107 Hz, Resolution=293.2459 ns, Timer=TSC
  [Host]     : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.6.1649.1
  DefaultJob : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.6.1649.1


```
 |                     Method |     Mean |     Error |   StdDev |   Median | Scaled | ScaledSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
 |--------------------------- |---------:|----------:|---------:|---------:|-------:|---------:|-------:|-------:|-------:|----------:|
 |               StringConcat | 425.8 ns | 27.944 ns | 82.39 ns | 386.1 ns |   1.00 |     0.00 | 0.0334 |      - |      - |     176 B |
 |    ToStringCompositeFormat | 558.2 ns | 30.391 ns | 89.61 ns | 510.3 ns |   1.36 |     0.33 | 0.0253 | 0.0072 | 0.0005 |     135 B |
 | ToStringFormatValueAndUnit | 426.3 ns |  8.539 ns | 17.63 ns | 418.7 ns |   1.04 |     0.19 | 0.0267 | 0.0076 | 0.0005 |     143 B |
