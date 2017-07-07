using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Algortihms
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sw = new Stopwatch();
            var alg = new AlgorithmLibrary();
            Console.WriteLine(alg.test(1));
            // alg.CountDown(100000);
            var chars = new List<char> { 'f', 'q', 'g', 'a', 'b', 't', 'c', 'a', 'j', 'k' };
            var nums = new List<int> { 7, 12, 56, 1, 2, 3, 1, 1 };
            var prices = new List<int> { 27, 53, 07, 25, 33, 47, 02, 32, 43 };
            var rand = new Random(Guid.NewGuid().GetHashCode());
            var smallRand = new Random(10);
            var teest = new List<char>();
            teest.AddRange(chars);


            for (int i = 0; i < 10000; i++)
            {
                nums.Add(rand.Next(Int32.MaxValue));
            }
            var bestTrade = alg.BestTradeFinder(prices);
            Console.WriteLine(bestTrade);

            var sw = new Stopwatch();
            sw.Start();
            var test = alg.MergeSort(nums);
            sw.Stop();
            //foreach (var num in test)
            //{
            //    Console.WriteLine(num);
            //}
            Console.WriteLine($"Eleapsed timeMYY = {sw.Elapsed}");
            var array = nums.ToArray();
            sw.Restart();
            alg.MergeSort_Recursive(array, 0, array.Length - 1);
            sw.Stop();
            Console.WriteLine($"Elepased timeREC = {sw.Elapsed}");
            sw.Restart();
            var num2 = nums.OrderBy(x => x).ToList();
            num2.Count();
            //alg.SelectionSort(num2);

            sw.Stop();
            Console.WriteLine($"Elepased timeORD  = {sw.Elapsed}");

            //foreach (var num in num2)
            //{
            //    Console.WriteLine(num);
            //}

            var fixedList = new List<Item>
            {
                new Item
                {
                    Value = 60,
                    Weight = 10
                },
                new Item
                {
                    Value = 100,
                    Weight = 20
                },
                new Item
                {
                    Value = 120,
                    Weight = 30
                }
            };
            int[] fixedValue = { 60, 100, 120 };
            int[] fixedWeight = { 10, 20, 30 };
            for (int p = 0; p < 30; p++)
            {
                var capacity = 40;
                var itemsCount = 35;
                var value = new int[itemsCount];
                var weight = new int[itemsCount];
                var items = new List<Item>();
                var items2 = new Item[itemsCount];
                for (int i = 0; i < itemsCount; i++)
                {
                    items.Add(new Item
                    {
                        Value = rand.Next(1, 50),
                        Weight = rand.Next(1, 50)

                    });
                }
                for (var i = 0; i < items.Count; i++)
                {
                    value[i] = items[i].Value;
                    weight[i] = items[i].Weight;
                }
                items.CopyTo(items2);
                var items3 = items2.ToList();
                sw.Start();
                var knapSackREc = alg.KnapSackRec(capacity, weight, value, itemsCount);
                sw.Stop();
                Console.WriteLine($"time: {sw.Elapsed} result: {knapSackREc}");


                sw.Restart();
                var knapSackKey = alg.KnapSack(capacity, weight, value, itemsCount);
                sw.Stop();
                Console.WriteLine($"time: {sw.Elapsed} result: {knapSackKey}");

                var items4 = new List<Item>(items);

                sw.Restart();
                var teset3 = alg.KnapSack(capacity, items, new StringBuilder());
                sw.Stop();
                Console.WriteLine($"time*: {sw.Elapsed} result: {teset3.Sum(i => i.Value)}");
                var stack = new Stack<Item>();
                items = items4.OrderByDescending(i => i.Weight).ToList();
                foreach (var item in items)
                {
                    stack.Push(item);
                }
                var stack2 = new Stack<Item>(stack);
                sw.Restart();
                var teset2 = alg.KnapSackList(capacity, stack, new List<Item>());
                sw.Stop();
                Console.WriteLine($"time*l: {sw.Elapsed} result: {teset2.Sum(i => i.Value)}");
                var valuePowerderd = alg.KnapSackPowerderd(capacity, stack2, true);
                Console.WriteLine($"time*power:  result: {valuePowerderd}");
                var greedyValue = alg.KnapSackGreedy(capacity, stack2);
                Console.WriteLine($"time*greed:  result: {greedyValue}");
                var gredyList = alg.KnapSackGreedyList(capacity, stack2);
                Console.WriteLine($"time*greedList:  result: {gredyList.Sum(i => i.Value)}");
                //sw.Restart();
                //var result = alg.Fib(40);
                //sw.Stop();
                //Console.WriteLine($"fib: {result} time: {sw.Elapsed}");

                //sw.Restart();
                //var resultd = alg.Fib(10000, new List<Int64>());
                //sw.Stop();
                //Console.WriteLine($"fib Cache: {resultd} time: {sw.Elapsed}");
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadLine();


        }
    }
}


