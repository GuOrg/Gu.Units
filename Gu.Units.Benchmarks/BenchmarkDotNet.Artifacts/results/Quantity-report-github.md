``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 7 SP1 (6.1.7601)
Processor=Intel Xeon CPU E5-2637 v4 3.50GHzIntel Xeon CPU E5-2637 v4 3.50GHz, ProcessorCount=16
Frequency=3410097 Hz, Resolution=293.2468 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2114.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2114.0


```
 |               Method |      Mean |     Error |    StdDev |    Median | Scaled | ScaledSD | Allocated |
 |--------------------- |----------:|----------:|----------:|----------:|-------:|---------:|----------:|
 |       DoubleMultiply | 0.0373 ns | 0.0245 ns | 0.0717 ns | 0.0000 ns |      ? |        ? |       0 B |
 | LengthMultiplyLength | 1.6398 ns | 0.0705 ns | 0.1845 ns | 1.6207 ns |      ? |        ? |       0 B |
