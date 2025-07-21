// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Benchmarks.Cases;

// var benchmarkCase = new InsertWithoutResort();
// benchmarkCase.Setup();
// benchmarkCase.WithSortedSet();
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
