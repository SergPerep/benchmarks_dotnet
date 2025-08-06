```

BenchmarkDotNet v0.15.2, Linux Ubuntu 24.04.2 LTS (Noble Numbat)
Intel Core i5-3210M CPU 2.50GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.118
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX
  Job-CNUJVU : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX

InvocationCount=1  UnrollFactor=1  

```
| Method                    | Mean         | Error      | StdDev     | Median       |
|-------------------------- |-------------:|-----------:|-----------:|-------------:|
| WithResort                | 3,881.417 ms | 24.0758 ms | 22.5205 ms | 3,871.134 ms |
| WithBinarySearchAndInsert |     5.207 ms |  0.1038 ms |  0.2385 ms |     5.115 ms |
