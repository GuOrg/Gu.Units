```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 ticks, Resolution=410.5296 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1637.0

Type=Parse  Mode=Throughput  

```
      Method |      Median |     StdDev | Scaled |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
------------ |------------ |----------- |------- |------- |------ |------ |------------------- |
  DobleParse | 127.7810 ns |  2.7419 ns |   1.00 |      - |     - |     - |               0,01 |
 LengthParse | 384.4855 ns | 10.0394 ns |   3.01 | 218,00 |     - |     - |              20,20 |
