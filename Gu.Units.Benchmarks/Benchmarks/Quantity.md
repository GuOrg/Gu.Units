```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 ticks, Resolution=410.5296 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1637.0

Type=Quantity  Mode=Throughput  

```
               Method |    Median |    StdDev | Scaled | Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------------- |---------- |---------- |------- |------ |------ |------ |------------------- |
       DoubleMultiply | 0.0000 ns | 0.0050 ns |      ? |     - |     - |     - |               0,00 |
 LengthMultiplyLength | 0.0000 ns | 0.0000 ns |      ? |     - |     - |     - |               0,00 |
