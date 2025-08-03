```

BenchmarkDotNet v0.15.2, Linux Ubuntu 24.04.2 LTS (Noble Numbat)
Intel Core i5-3210M CPU 2.50GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.117
  [Host]     : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX
  DefaultJob : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX


```
| Method              | Mean      | Error     | StdDev    |
|-------------------- |----------:|----------:|----------:|
| IterateCollection   | 10.094 ms | 0.1109 ms | 0.0983 ms |
| SearchViaDictionary |  3.185 ms | 0.0553 ms | 0.0517 ms |
