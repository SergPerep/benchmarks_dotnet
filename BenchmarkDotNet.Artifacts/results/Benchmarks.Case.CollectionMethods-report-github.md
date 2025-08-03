```

BenchmarkDotNet v0.15.2, Linux Ubuntu 24.04.2 LTS (Noble Numbat)
Intel Core i5-3210M CPU 2.50GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.118
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX


```
| Method            | Mean       | Error    | StdDev   | Median     |
|------------------ |-----------:|---------:|---------:|-----------:|
| WithExtMethods    | 1,029.6 μs | 11.66 μs | 10.34 μs | 1,028.5 μs |
| WithoutExtMethods |   934.5 μs | 18.22 μs | 44.35 μs |   913.7 μs |
