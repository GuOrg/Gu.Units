```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 ticks, Resolution=410.5296 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1637.0

Type=Format  Mode=Throughput  

```
                     Method |      Median |     StdDev | Scaled |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------------------- |------------ |----------- |------- |------- |------ |------ |------------------- |
               StringConcat | 480.8956 ns | 13.7286 ns |   1.00 | 752,89 |     - |     - |              70,65 |
    ToStringCompositeFormat | 542.9231 ns |  6.6969 ns |   1.13 | 409,11 | 18,72 |     - |              54,81 |
 ToStringFormatValueAndUnit | 558.2269 ns | 13.2628 ns |   1.16 | 457,00 | 20,00 |     - |              62,00 |
