using BenchmarkDotNet.Attributes;
using Benchmarks.Model;

namespace Benchmarks.Cases
{

    public class DictionariesForSearch
    {
        private static Random random = new();
        private static string[] names;
        private Birth[] births;
        private static Dictionary<int, List<Birth>> birthsByYear = new();
        private int selectedYear;
        private Sex selectedSex;

        private const int dataSetSize = 1_000_000;
        [GlobalSetup]
        public void Setup()
        {
            CSVReader reader = new();
            IEnumerable<string> lines = reader.ReadEmbeddedCsv("first_names.csv").Split("\n");
            names = lines.TakeLast(lines.Count() - 1).ToArray();

            births = new Birth[dataSetSize];
            for (int i = 0; i < births.Length; i++)
            {
                births[i] = new Birth()
                {
                    name = GenRandomName(),
                    sex = GenRandomSex(),
                    date = GenRandomDate(2020, 2025)
                };
            }

            foreach (Birth birth in births)
            {
                if (birthsByYear.TryGetValue(birth.date.Year, out List<Birth> birthsOfSelectedYear))
                {
                    birthsOfSelectedYear.Add(birth);
                }
                else
                {
                    birthsByYear[birth.date.Year] = new List<Birth>() { birth };
                }
            }

            selectedYear = birthsByYear.Keys.ToArray()[random.Next(birthsByYear.Keys.Count)];
            selectedSex = GenRandomSex();
        }
        [Benchmark]
        public Birth[] IterateCollection()
        {
            return births.Where(b => b.sex == selectedSex && b.date.Year == selectedYear && b.date.Month == 9).ToArray();
        }
        [Benchmark]
        public Birth[] SearchViaDictionary()
        {
            return birthsByYear[selectedYear].Where(b => b.sex == selectedSex && b.date.Month == 9).ToArray();
        }

        public Sex GenRandomSex()
        {
            var arr = Enum.GetValues(typeof(Sex));
            return (Sex)arr.GetValue(random.Next(arr.Length))!;
        }

        public string GenRandomName()
        {
            return names[random.Next(names.Length)];
        }

        public DateTime GenRandomDate(int maxYear, int minYear)
        {
            int randomYear = random.Next(maxYear, minYear + 1);
            int randomMonth = random.Next(1, 13);
            int totalDaysInMonth = DateTime.DaysInMonth(randomYear, randomMonth);
            int randomDay = random.Next(1, totalDaysInMonth + 1);
            return new DateTime(randomYear, randomMonth, randomDay);
        }
    }

    public class Birth
    {
        public Sex sex;
        public string name = "";
        public DateTime date;
    }

    public enum Sex
    {
        Male,
        Female
    }
}