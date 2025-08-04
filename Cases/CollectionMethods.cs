using System.Reflection;
using BenchmarkDotNet.Attributes;
using Benchmarks.Model;

namespace Benchmarks.Case
{
    public class CollectionMethods
    {
        private Birth[] births;
        private List<string> names;
        private const int dataSetSize = 1_000_000;
        private Random random = new Random();
        [GlobalSetup]
        public void Setup()
        {
            CSVReader reader = new();
            IEnumerable<string> lines = reader.ReadEmbeddedCsv("first_names.csv").Split("\n");
            names = lines.TakeLast(lines.Count() - 1).ToList();

            while (names.Count < dataSetSize)
            {
                names.Add(names[random.Next(names.Count)]);
            }

            births = new Birth[dataSetSize];
            for (int i = 0; i < births.Length; i++)
            {
                births[i] = new Birth()
                {
                    name = GenRandomName(),
                    sex = GenRandomSex(),
                    date = GenRandomDate(1990, 2025)
                };
            }
        }
        [Benchmark]
        public List<string> WithExtMethods()
        {
            return births
                .Where(b => b.sex == Sex.Female && b.date.Year == 2024 && b.date.Month == 9)
                .Select(b => b.name)
                .Distinct()
                .OrderBy(name => name)
                .ToList();
        }
        [Benchmark]
        public List<string> WithoutExtMethods()
        {
            List<string> uniqueNames = new List<string>();
            HashSet<string> seen = new HashSet<string>();
            foreach (Birth b in births)
            {
                if (b.sex != Sex.Female || b.date.Year != 2024 || b.date.Month != 9)
                    continue;
                if (seen.Add(b.name)) uniqueNames.Add(b.name);
            }
            uniqueNames.Sort();
            return uniqueNames;
        }

        public Sex GenRandomSex()
        {
            var arr = Enum.GetValues(typeof(Sex));
            return (Sex)arr.GetValue(random.Next(arr.Length))!;
        }

        public string GenRandomName()
        {
            return names[random.Next(names.Count)];
        }

        public DateTime GenRandomDate(int maxYear, int minYear)
        {
            int randomYear = random.Next(maxYear, minYear + 1);
            int randomMonth = random.Next(1, 13);
            int totalDaysInMonth = DateTime.DaysInMonth(randomYear, randomMonth);
            int randomDay = random.Next(1, totalDaysInMonth + 1);
            return new DateTime(randomYear, randomMonth, randomDay);
        }
        public class Birth
        {
            public string name = "";
            public Sex sex;
            public DateTime date;
        }

        public enum Sex
        {
            Male,
            Female,
            Intersex
        }
    }
}