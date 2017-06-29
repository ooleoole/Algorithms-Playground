using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algortihms
{
    public class AlgorithmLibrary
    {

        public List<T> MergeSort<T>(List<T> numbers) where T : IComparable
        {
            if (numbers.Count <= 1)
                return numbers;

            var middle = numbers.Count / 2;
            var left = GetLeft(numbers, middle);
            var right = GetRight(numbers, middle);
            return MergeAndSort(MergeSort(left), MergeSort(right));


        }

        public int Fib(int num)
        {
            if (num <= 2)
                return 1;
            return Fib(num - 1) + Fib(num - 2);

        }

        public long Fib(int num, List<long> cache)
        {
            if (!cache.Any())
                InitCache(cache);
            if (cache.Count > num)
                return cache[num];
            var fibNum = Fib(num - 1, cache) + Fib(num - 2, cache);
            cache.Add(fibNum);
            return fibNum;
        }

        public long FibIterative(int num)
        {
            long low = 0;
            long high = 1;
            for (int i = 0; i < num; i++)
            {
                var oldHigh = high;
                high += low;
                low = oldHigh;
            }
            return low;
        }
        private void InitCache(List<long> cache)
        {
            cache.Add(0);
            cache.Add(1);
            cache.Add(1);
        }

        private static List<T> GetRight<T>(List<T> numbers, int middle)
        {
            var right = new List<T>();
            for (int i = middle; i < numbers.Count; i++)
            {
                right.Add(numbers[i]);
            }
            return right;
        }

        private static List<T> GetLeft<T>(List<T> numbers, int middle)
        {
            var left = new List<T>();
            for (int i = 0; i < middle; i++)
            {
                left.Add(numbers[i]);
            }

            return left;
        }

        private List<T> MergeAndSort<T>(List<T> left, List<T> right) where T : IComparable
        {
            var temp = new List<T>();

            while (left.Any() && right.Any())
            {

                if (left.First().CompareTo(right.First()) < 0)
                {
                    temp.Add(left.First());
                    left.RemoveAt(0);
                }
                else
                {
                    temp.Add(right.First());
                    right.RemoveAt(0);
                }
            }

            if (left.Any())
            {
                temp.AddRange(left);
            }
            else if (right.Any())
            {
                temp.AddRange(right);
            }

            return temp;
        }

        public void SelectionSort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int key = i;

                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[j] < input[key])
                    {
                        key = j;
                    }
                }
                //Swap
                int temp = input[i];
                input[i] = input[key];
                input[key] = temp;
            }
        }

        public long test(Int64 num)
        {
            if (num == 4)
                return num;

            num++;


            return test(num) * test(num);

        }

        public void CountDown(int startNumber)
        {
            if (startNumber > 0)
            {
                Console.WriteLine(startNumber + ", ");
                CountDown(startNumber - 1);

            }


        }

        public static void DoMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[1000008];
            int i, leftEnd, numElements, tmpPos;

            leftEnd = (mid - 1);
            tmpPos = left;
            numElements = (right - left + 1);

            while ((left <= leftEnd) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmpPos++] = numbers[left++];
                else
                    temp[tmpPos++] = numbers[mid++];
            }

            while (left <= leftEnd)
                temp[tmpPos++] = numbers[left++];

            while (mid <= right)
                temp[tmpPos++] = numbers[mid++];

            for (i = 0; i < numElements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        public void MergeSort_Recursive(int[] numbers, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort_Recursive(numbers, left, mid);
                MergeSort_Recursive(numbers, (mid + 1), right);

                DoMerge(numbers, left, (mid + 1), right);
            }
        }

        public int BestTradeFinder(List<int> prices)
        {
            if (prices.Count == 1)
                return 0;

            var middle = prices.Count / 2;
            var left = GetLeft(prices, middle);
            var right = GetRight(prices, middle);

            var case3 = right.Max() - left.Min();
            return Max(BestTradeFinder(left), BestTradeFinder(right), case3);

        }

        private int Max(params int[] cases)
        {
            return cases.Max();

        }
        static int Max(int a, int b) { return (a > b) ? a : b; }


        public int KnapSackRec(int W, int[] wt, int[] val, int n)
        {


            if (n == 0 || W == 0)
                return 0;


            if (wt[n - 1] > W)
                return KnapSackRec(W, wt, val, n - 1);

            return Max(val[n - 1] + KnapSackRec(W - wt[n - 1], wt, val, n - 1),
                KnapSackRec(W, wt, val, n - 1));
        }
        public List<Item> KnapSack(int capacity, List<Item> items, string knapSack, Dictionary<string, List<Item>> cache, int recCounter = 0)
        {
            var capacityNoAdd = capacity;

            if (items.Count - recCounter == 0 || capacity == 0)
            {
                var knapSackList = new List<Item>();
                var indices = knapSack.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var index in indices)
                {
                    knapSackList.Add(items[int.Parse(index)]);
                }
                return knapSackList;
            }


            if (items[items.Count - (1 + recCounter)].Weight > capacity)
                return KnapSack(capacity, items, knapSack, cache, recCounter + 1);


            var knapSackNoAdd = knapSack;
            knapSack += items.Count - (1 + recCounter) + ",";
            capacity -= items[items.Count - (1 + recCounter)].Weight;





            var maxSackLeft = KnapSack(capacity, items, knapSack, cache, recCounter + 1);
            var maxSackRight = KnapSack(capacityNoAdd, items, knapSackNoAdd, cache, recCounter + 1);
            var key = Hash(maxSackLeft, maxSackRight);
            var key2 = Hash(maxSackRight, maxSackLeft);
            if (key == key2)
                return maxSackLeft;

            if (cache.ContainsKey(key))
                return cache[key];

            var maxSack = MaxKnapSack(maxSackLeft, maxSackRight);
            cache.Add(key, maxSack);
            cache.Add(key2, maxSack);

            return maxSack;

        }



        private string Hash(params List<Item>[] obj)
        {
            var sb = new StringBuilder();
            foreach (var o in obj)
                foreach (var item in o)
                {

                    sb.Append(item.GetHashCode());
                }

            return sb.ToString();
        }

        private List<Item> MaxKnapSack(List<Item> maxSackLeft, List<Item> maxSackRight)
        {

            if (!maxSackLeft.Any() && !maxSackRight.Any())
                return maxSackLeft;
            if (!maxSackLeft.Any())
                return maxSackRight;
            if (!maxSackRight.Any())
                return maxSackLeft;

            return GetMax(maxSackLeft, maxSackRight);
        }

        private static List<Item> GetMax(List<Item> maxSackRight, List<Item> maxSackLeft)
        {
            var maxSack = maxSackRight.Sum(i => i.Value) > maxSackLeft.Sum(i => i.Value) ? maxSackRight : maxSackLeft;
            return maxSack;
        }

        public List<Item> KnapSackGeedy(int capacity, List<Item> items, List<Item> knapSack)
        {
            items = items.OrderByDescending(i => i.WeightValueRatio).ToList();
            for (var i = 0; i < items.Count; i++)
            {
                var item = items[i];
                if (item.Weight <= capacity)
                {
                    knapSack.Add(item);
                    capacity -= item.Weight;
                    items.RemoveAt(i);
                    if (capacity == 0)
                        return knapSack;

                }
            }
            return knapSack;
        }
        public int KnapSack(int capacity, int[] weight, int[] value, int itemsCount)
        {
            int[,] K = new int[itemsCount + 1, capacity + 1];

            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= capacity; ++w)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (weight[i - 1] <= w)
                        K[i, w] = Math.Max(value[i - 1] + K[i - 1, w - weight[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[itemsCount, capacity];
        }

        private List<Item> GetRight(List<Item> items, int middle)
        {
            var left = new List<Item>();
            for (int i = 0; i < middle; i++)
            {
                left.Add(items[i]);
            }

            return left;
        }

        private List<Item> GetLeft(List<Item> items, int middle)
        {
            var right = new List<Item>();
            for (int i = middle; i < items.Count; i++)
            {
                right.Add(items[i]);
            }
            return right;
        }
    }

    public class Item
    {
        public int Weight { get; set; }
        public int Value { get; set; }
        public float WeightValueRatio => (float)Value / Weight;


        public override string ToString()
        {
            return $"Weight: {Weight} Value: {Value} WeightValueRatio: {WeightValueRatio}";
        }
    }
}
