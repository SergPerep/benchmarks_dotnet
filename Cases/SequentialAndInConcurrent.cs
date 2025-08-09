using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Benchmarks.Model;

namespace Benchmarks.Cases
{

    public class SequentialAndConcurrent
    {
        private int n = 10;
        private Food[] foods = [];
        [GlobalSetup]
        public void GlobalSetup()
        {
            foods = new Food[n];
        }

        public async Task postFoodItemAsync(Food foodItem)
        {
            await Task.Delay(200);
        }

        [Benchmark]
        public async Task<int> Sequential()
        {
            foreach (Food foodItem in foods)
                await postFoodItemAsync(foodItem);
            return foods.Count();
        }
        [Benchmark]
        public async Task<int> Concurrent()
        {
            Task[] tasks = foods.Select(f => postFoodItemAsync(f)).ToArray();
            await Task.WhenAll(tasks);
            return tasks.Count();
        }

        public class Food
        {
            public string name = "";
            public int protein;
            public int carbs;
            public int fat;
        }
    }
}