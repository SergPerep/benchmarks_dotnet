```

BenchmarkDotNet v0.15.2, Linux Ubuntu 24.04.2 LTS (Noble Numbat)
Intel Core i5-3210M CPU 2.50GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.117
  [Host]     : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX
  DefaultJob : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX


```
| Method                 | Mean        | Error     | StdDev    |
|----------------------- |------------:|----------:|----------:|
| ConcatViaOperator      | 1,357.09 μs | 15.793 μs | 13.188 μs |
| ConcatViaStringBuilder |    33.39 μs |  0.623 μs |  0.612 μs |
