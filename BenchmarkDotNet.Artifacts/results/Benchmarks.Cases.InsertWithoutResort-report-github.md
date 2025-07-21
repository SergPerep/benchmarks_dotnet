```

BenchmarkDotNet v0.15.2, Linux Ubuntu 24.04.2 LTS (Noble Numbat)
Intel Core i5-3210M CPU 2.50GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.117
  [Host]     : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX
  DefaultJob : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX


```
| Method            | Mean        | Error      | StdDev     | Median      |
|------------------ |------------:|-----------:|-----------:|------------:|
| ListWithResort    | 4,105.08 ms | 111.963 ms | 310.248 ms | 4,022.20 ms |
| ListWithoutResort |    29.36 ms |   0.560 ms |   0.524 ms |    29.24 ms |
| WithSortedSet     | 2,685.27 ms | 113.483 ms | 323.773 ms | 2,580.69 ms |
