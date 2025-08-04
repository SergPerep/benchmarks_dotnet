```

BenchmarkDotNet v0.15.2, Linux Ubuntu 24.04.2 LTS (Noble Numbat)
Intel Core i5-3210M CPU 2.50GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.118
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX


```
| Method           | Mean     | Error     | StdDev    |
|----------------- |---------:|----------:|----------:|
| TotalAmountArray | 7.033 ms | 0.0704 ms | 0.0588 ms |
| TotalAmountList  | 7.607 ms | 0.0642 ms | 0.0600 ms |
