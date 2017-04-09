```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Xeon(R) CPU X5687 3.60GHz, ProcessorCount=8
Frequency=3515820 ticks, Resolution=284.4287 ns, Timer=ACPI
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1590.0

Type=Format  Mode=Throughput  

```
                     Method |      Median |     StdDev | Scaled |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------------------- |------------ |----------- |------- |------- |------ |------ |------------------- |
               StringConcat | 387.9399 ns |  4.0302 ns |   1.00 | 271,66 |     - |     - |              67,65 |
    ToStringCompositeFormat | 433.3079 ns | 12.8307 ns |   1.12 | 167,00 | 34,00 | 17,00 |              54,88 |
 ToStringFormatValueAndUnit | 467.0089 ns |  9.1889 ns |   1.20 | 188,09 | 34,70 | 17,35 |              59,31 |
