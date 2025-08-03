// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Reflection;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Benchmarks.Case;
using Benchmarks.Cases;


// var caseOne = new ArrayAndList();
// caseOne.Setup();
// Debug.WriteLine(caseOne.TotalAmountArray());
// Debug.WriteLine(caseOne.TotalAmountList());

// foreach (var name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
// {
//     Console.WriteLine(name);  // Should show something like YourProject.Inputs.first_names.csv
// }

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
