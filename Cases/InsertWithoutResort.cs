using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Cases
{
    public class InsertWithoutResort
    {
        private static Random _random = new Random();
        private List<string> _originalData = new List<string>();

        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < 1000000; i++)
            {
                _originalData.Add(GenerateString(10));
            }
            _originalData.Sort();
        }
        [Benchmark]
        public List<string> ListWithResort()
        {
            List<string> foods = new(_originalData);
            foods.Add("Almonds");
            foods.Sort();
            return foods;
        }
        [Benchmark]
        public List<string> ListWithoutResort()
        {
            List<string> foods = new(_originalData);
            string item = "Almonds";
            int index = foods.BinarySearch(item);
            if (index < 0)
            {
                index = ~index;
                foods.Insert(index, item);
            }
        
            return foods;
        }
        [Benchmark]
        public SortedSet<string> WithSortedSet()
        {
            SortedSet<string> foods = new(_originalData);
            string item = "Almonds";
            foods.Add(item);
            return foods;
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