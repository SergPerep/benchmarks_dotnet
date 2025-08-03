using System.Diagnostics;
using System.Text;
using BenchmarkDotNet.Attributes;
using Benchmarks.Model;

namespace Benchmarks.Cases
{
    public class StringConcats
    {
        private List<Food> foods = new();
        [GlobalSetup]
        public void Setup()
        {
            int targetCount = 300;
            CSVReader reader = new();

            while (true)
            {
                int index = -1;
                foreach (var line in reader.ReadEmbeddedCsv("string_concats.csv").Split("\n"))
                {
                    index++;
                    if (index == 0) continue;
                    var columns = line.Split(','); // simple CSV parse
                    foods.Add(new Food() { name = columns[0], protein = int.Parse(columns[1]), carbs = int.Parse(columns[2]), fat = int.Parse(columns[3]) });
                    if (foods.Count >= targetCount)
                    {
                        goto ENDOFLOOPS;
                    }
                }
            }
        ENDOFLOOPS:
            Debug.WriteLine("Count: " + foods.Count);

        }

        private void FeedBack(int index)
        {
            if (index % 100 == 0) Debug.WriteLine(index);
        }
        [Benchmark]
        public string ConcatViaOperator()
        {
            string insertQueries = "";
            int index = 0;
            foreach (Food foodItem in foods)
            {
                insertQueries += $"\nINSERT INTO foods (name, protein, carbs, fat) VALUES ('{foodItem.name}', {foodItem.protein}, {foodItem.carbs}, {foodItem.fat});";
                FeedBack(index);
                index++;
            }
            return insertQueries;
        }
        [Benchmark]
        public string ConcatViaStringBuilder()
        {
            StringBuilder sb = new("");
            int index = 0;
            foreach (Food foodItem in foods)
            {
                sb.Append($"\nINSERT INTO foods (name, protein, carbs, fat) VALUES ('{foodItem.name}', {foodItem.protein}, {foodItem.carbs}, {foodItem.fat});");
                FeedBack(index);
                index++;
            }

            return sb.ToString();
        }
    }

    public class Food
    {
        public string name = "";
        public int protein;
        public int carbs;
        public int fat;
    }
}