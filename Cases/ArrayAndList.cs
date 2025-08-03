using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Cases
{
    public class ArrayAndList
    {
        public int dataSetSize = 1_000_000;
        public Random random = new Random();
        public string letters = "ABCDEFGHIGKLMNOPQRSTUVWXWZ";
        public string numbers = "0123456789";

        public Transaction[] transactionArray;
        public List<Transaction> transactionList;
        [GlobalSetup]
        public void Setup()
        {
            transactionArray = new Transaction[dataSetSize];
            for (int i = 0; i < transactionArray.Length; i++)
            {
                transactionArray[i] = new Transaction()
                {
                    accountNumber = GenAccountNumber(),
                    date = GenRandomDate(2024, 2025),
                    amount = random.Next(1, 600)
                };
            }
            transactionList = new(transactionArray);
        }
        [Benchmark]
        public int TotalAmountArray()
        {
            return transactionArray.Aggregate(0, (total, tr) => total + tr.amount);
        }
        [Benchmark]
        public int TotalAmountList()
        {
            return transactionList.Aggregate(0, (total, tr) => total + tr.amount);
        }

        public string GenAccountNumber()
        {
            StringBuilder sb = new();
            sb
            .Append(GenRandomChar(letters))
            .Append(GenRandomChar(letters))
            .Append(GenRandomChar(numbers))
            .Append(GenRandomChar(numbers));

            for (int i = 0; i < 4; i++)
            {
                sb.Append(GenRandomChar(letters));
            }

            for (int i = 0; i < 10; i++)
            {
                sb.Append(GenRandomChar(numbers));
            }

            return sb.ToString();
        }

        public char GenRandomChar(string s)
        {
            return s[random.Next(s.Length)];
        }

        public DateTime GenRandomDate(int maxYear, int minYear)
        {
            int randomYear = random.Next(maxYear, minYear + 1);
            int randomMonth = random.Next(1, 13);
            int totalDaysInMonth = DateTime.DaysInMonth(randomYear, randomMonth);
            int randomDay = random.Next(1, totalDaysInMonth + 1);
            return new DateTime(randomYear, randomMonth, randomDay);
        }

        public class Transaction
        {
            public string accountNumber;
            public DateTime date;
            public int amount;
        }
    }
}