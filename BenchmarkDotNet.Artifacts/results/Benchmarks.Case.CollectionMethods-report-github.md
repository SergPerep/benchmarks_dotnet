```

BenchmarkDotNet v0.15.2, Linux Ubuntu 24.04.2 LTS (Noble Numbat)
Intel Core i5-3210M CPU 2.50GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.118
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX


```
| Method            | Mean     | Error   | StdDev  |
|------------------ |---------:|--------:|--------:|
| WithExtMethods    | 819.7 μs | 4.58 μs | 3.82 μs |
| WithoutExtMethods | 732.9 μs | 4.93 μs | 4.37 μs |
