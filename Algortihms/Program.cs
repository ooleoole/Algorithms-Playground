using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

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
            var chars = new List<char> {'f', 'q', 'g', 'a', 'b', 't', 'c', 'a', 'j', 'k'};
            var nums = new List<int> { 7, 12, 56, 1, 2, 3, 1, 1 };
            var prices = new List<int> { 27, 53, 07, 25, 33, 47, 02, 32, 43 };
            var rand = new Random(Guid.NewGuid().GetHashCode());
            var smallRand = new Random(10);
            var teest =new List<char>();
            teest.AddRange(chars);

            
            for (int i = 0; i < 100; i++)
            {
                nums.Add(rand.Next(Int32.MaxValue));
            }
            var bestTrade = alg.BestTradeFinder(prices);
            Console.WriteLine(bestTrade);
            
            var sw = new Stopwatch();
            sw.Start();
            var test = alg.MergeSort(chars);
            sw.Stop();
            //foreach (var num in test)
            //{
            //    Console.WriteLine(num);
            //}
            Console.WriteLine($"Eleapsed time = {sw.Elapsed}");
            var array = nums.ToArray();
            sw.Restart();
            alg.MergeSort_Recursive(array, 0, array.Length - 1);
            sw.Stop();
            Console.WriteLine($"Elepased time = {sw.Elapsed}");
            sw.Restart();
            var num2 = nums.OrderBy(x => x).ToList();
            num2.Count();
            //alg.SelectionSort(num2);

            sw.Stop();
            Console.WriteLine($"Elepased time = {sw.Elapsed}");

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
            var capacity = 150;
            var itemsCount = 40;
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
            var knapSackKey = alg.KnapSack(capacity, weight, value, itemsCount);
            sw.Stop();
            Console.WriteLine($"time: {sw.Elapsed} result: {knapSackKey}");

            sw.Restart();
            var knapSackREc = alg.KnapSackRec(capacity, weight, value, itemsCount);
            sw.Stop();
            Console.WriteLine($"time: {sw.Elapsed} result: {knapSackREc}");

            sw.Restart();
            var teset2 = alg.KnapSack(capacity, items, string.Empty, new Dictionary<string, List<Item>>());
            sw.Stop();
            Console.WriteLine($"time: {sw.Elapsed} result: {teset2.Sum(i => i.Value)}");
            var result = 0.0;
            sw.Restart();
            result = alg.Fib(40);
            sw.Stop();
            Console.WriteLine($"fib: {result} time: {sw.Elapsed}");

            sw.Restart();
            result = alg.Fib(40, new List<long>());
            sw.Stop();
            Console.WriteLine($"fib Cache: {result} time: {sw.Elapsed}");
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadLine();


            //public List<Item> KnapSack(int capacity, List<Item> items, List<Item> knapSack, Dictionary<long, List<Item>> cache)
            //{


            //    var itemsCopy = new List<Item>();
            //    var knapSackNoAdd = new List<Item>();
            //    var capacityNoAdd = capacity;

            //    if (!items.Any() || capacity == 0)
            //        return knapSack;
            //    if (items[items.Count - 1].Weight > capacity)
            //    {
            //        itemsCopy.AddRange(items);
            //        itemsCopy.RemoveAt(items.Count - 1);
            //        return KnapSack(capacity, itemsCopy, knapSack, cache);
            //    }

            //    knapSackNoAdd.AddRange(knapSack);
            //    knapSack.Add(items[items.Count - 1]);
            //    capacity -= items[items.Count - 1].Weight;
            //    itemsCopy.AddRange(items);
            //    itemsCopy.RemoveAt(items.Count - 1);


            //    var key = Hash(knapSack, knapSackNoAdd);
            //    if (cache.ContainsKey(key))
            //    {
            //        return cache[key];
            //    }
            //    var maxSackLeft = KnapSack(capacity, itemsCopy, knapSack, cache);
            //    var maxSackRight = KnapSack(capacityNoAdd, itemsCopy, knapSackNoAdd, cache);
            //    var maxSack = MaxKnapSack(maxSackLeft, maxSackRight);
            //    cache.Add(key, maxSack);


            //    return maxSack;

            //}

            //public List<Item> KnapSack(int capacity, List<Item> items, List<Item> knapSack, Dictionary<long, List<Item>> cache, int recCounter = 0)
            //{

            //    var knapSackNoAdd = new List<Item>();
            //    var capacityNoAdd = capacity;

            //    if (items.Count - recCounter == 0 || capacity == 0)
            //        return knapSack;
            //    if (items[items.Count - (1 + recCounter)].Weight > capacity)
            //    {

            //        return KnapSack(capacity, items, knapSack, cache, recCounter + 1);
            //    }

            //    knapSackNoAdd.AddRange(knapSack);
            //    knapSack.Add(items[items.Count - (1 + recCounter)]);
            //    capacity -= items[items.Count - (1 + recCounter)].Weight;



            //    var key = Hash(knapSack, knapSackNoAdd);
            //    if (cache.ContainsKey(key))
            //    {
            //        return cache[key];
            //    }
            //    var maxSackLeft = KnapSack(capacity, items, knapSack, cache, recCounter + 1);
            //    var maxSackRight = KnapSack(capacityNoAdd, items, knapSackNoAdd, cache, recCounter + 1);
            //    var maxSack = MaxKnapSack(maxSackLeft, maxSackRight);
            //    cache.Add(key, maxSack);


            //    return maxSack;

            //}
        }
    }
}


