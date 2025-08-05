```

BenchmarkDotNet v0.15.2, Linux Ubuntu 24.04.2 LTS (Noble Numbat)
Intel Core i5-3210M CPU 2.50GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.118
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX
  Job-CNUJVU : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX

InvocationCount=1  UnrollFactor=1  

```
| Method                    | Mean            | Error         | StdDev        |
|-------------------------- |----------------:|--------------:|--------------:|
| WithResort                | 3,745,282.12 μs | 23,668.768 μs | 20,981.746 μs |
| WithBinarySearchAndInsert |     5,204.01 μs |    102.536 μs |    225.069 μs |
| WithSortedSet             |        42.60 μs |      1.166 μs |      3.211 μs |
