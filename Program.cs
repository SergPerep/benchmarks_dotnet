// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Reflection;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Benchmarks.Case;
using Benchmarks.Cases;


// var caseOne = new InsertWithoutResort();
// caseOne.Setup();
// Debug.WriteLine("ListWithResort: " + caseOne.ListWithResort().Count);
// caseOne.GlobalCleanup();
// caseOne.Setup();
// Debug.WriteLine("ListWithoutResort: " + caseOne.ListWithoutResort().Count);
// caseOne.GlobalCleanup();
// caseOne.Setup();
// caseOne.SortedSetSetup();
// Debug.WriteLine("WithSortedSet: " + caseOne.WithSortedSet().Count);

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
