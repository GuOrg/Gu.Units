``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 7 SP1 (6.1.7601)
Processor=Intel Xeon CPU E5-2637 v4 3.50GHzIntel Xeon CPU E5-2637 v4 3.50GHz, ProcessorCount=16
Frequency=3410097 Hz, Resolution=293.2468 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2114.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2114.0


```
 |      Method |      Mean |    Error |    StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
 |------------ |----------:|---------:|----------:|-------:|---------:|-------:|----------:|
 |  DobleParse |  85.57 ns | 1.749 ns |  5.128 ns |   1.00 |     0.00 |      - |       0 B |
 | LengthParse | 306.89 ns | 6.903 ns | 20.028 ns |   3.60 |     0.32 | 0.0148 |      96 B |
