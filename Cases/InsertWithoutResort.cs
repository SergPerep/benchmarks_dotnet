using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Cases
{
    public class InsertWithoutResort
    {
        private static Random _random = new();
        public List<string> foodList = [];
        // [Params([1_000_000, 100_000, 10_000, 1_000])]
        public int n = 1_000_000;
        private List<string> _original_data = [];
        private const string itemToAdd = "Almonds";
        public SortedSet<string> foodSortedSet = [];

        [GlobalSetup]
        public void GlobalSetup()
        {
            for (int i = 0; i < n; i++)
            {
                _original_data.Add(GenerateString(10));
            }
            _original_data.Sort();
        }
        [IterationSetup]
        public void IterationSetup()
        {
            foodList = [.. _original_data];
        }

        [IterationCleanup]
        public void IterationCleanup()
        {
            foodList.Clear();
            foodSortedSet.Clear();
        }

        [IterationSetup(Target = nameof(WithSortedSet))]
        public void IterationSetupWithSortedSet()
        {
            foodSortedSet = [.. _original_data]; 
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _original_data.Clear();
        }

        [Benchmark]
        public List<string> WithResort()
        {
            foodList.Add(itemToAdd);
            foodList.Sort();
            return foodList;
        }
        [Benchmark]
        public List<string> WithBinarySearchAndInsert()
        {
            int index = foodList.BinarySearch(itemToAdd);
            if (index < 0)
            {
                index = ~index;
                foodList.Insert(index, itemToAdd);
            }
            return foodList;
        }
        [Benchmark]
        public SortedSet<string> WithSortedSet()
        {
            foodSortedSet.Add(itemToAdd);
            return foodSortedSet;
        }

        public static string GenerateString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[_random.Next(chars.Length)]);
            }

            return sb.ToString();
        }
    }
}