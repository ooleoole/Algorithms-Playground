using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
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
        static int max(int a, int b) { return (a > b) ? a : b; }


        public int KnapSackRec(int W, int[] wt, int[] val, int n)
        {
            int i, w;
            var K = new int[n + 1, W + 1];

            // Build table K[][] in bottom up manner
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = max(val[i - 1] + K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, W];
        }
        public ICollection<Item> KnapSack(int capacity, List<Item> items, StringBuilder knapSack, int recCounter = 0)
        {
            var capacityNoAdd = capacity;

            if (items.Count - recCounter == 0 || capacity == 0)
            {
                var knapSackList = new List<Item>();

                var indices = knapSack.ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                knapSackList.AddRange(indices.Select(index => items[int.Parse(index)]));
                return knapSackList;
            }


            if (items[items.Count - (1 + recCounter)].Weight > capacity)
                return KnapSack(capacity, items, knapSack, recCounter + 1);


            var knapSackNoAdd = new StringBuilder();
            knapSackNoAdd.Append(knapSack.ToString(0, knapSack.Length));
            knapSack.Append(items.Count - (1 + recCounter) + ",");
            capacity -= items[items.Count - (1 + recCounter)].Weight;

            var maxSackLeft = KnapSack(capacity, items, knapSack, recCounter + 1);
            var maxSackRight = KnapSack(capacityNoAdd, items, knapSackNoAdd, recCounter + 1);

            var maxSack = MaxKnapSack(maxSackLeft, maxSackRight);
            return maxSack;

        }
        public ICollection<Item> KnapSackList(int capacity, Stack<Item> items, List<Item> knapSack)
        {

            if (items.Count == 0 || capacity == 0)
                return knapSack;
            do
            {
                if (items.Count == 0)
                    return knapSack;
                if (items.Peek().Weight > capacity)
                    items.Pop();
                else
                    break;
            } while (true);


            var knapSackNoAdd = new List<Item>(knapSack);



            var capacityNoAdd = capacity;
            capacity -= items.Peek().Weight;
            knapSack.Add(items.Pop());


            var newItems = new Stack<Item>(items);
            ICollection<Item> maxLeft;
            ICollection<Item> maxRight;
            ICollection<Item> maxSack;
            //if (newItems.Count != 0 || items.Count != 0)
            //{
            //    var lowerBoundNoAdd = KnapSackGreedy(capacityNoAdd, newItems);
            //    var upperBoundNoAdd = KnapSackPowerderd(capacityNoAdd, newItems);

            //    var lowerBound = KnapSackGreedy(capacity, items);
            //    var upperBound = KnapSackPowerderd(capacity, items);
            //    if (upperBound == lowerBound && upperBound >= upperBoundNoAdd)
            //        return KnapSackGreedyList(capacity, items);
            //    if (upperBound == lowerBound && upperBoundNoAdd == lowerBoundNoAdd)
            //    {
            //        maxLeft = KnapSackGreedyList(capacity, items);
            //        maxRight = KnapSackGreedyList(capacityNoAdd, newItems);
            //        maxSack = MaxKnapSack(maxLeft, maxRight);
            //        return maxSack;
            //    }

            //    if (upperBound == lowerBound)
            //    {
            //        maxLeft = KnapSackGreedyList(capacity, items);
            //        maxRight = KnapSackList(capacityNoAdd, newItems, knapSackNoAdd);
            //        maxSack = MaxKnapSack(maxLeft, maxRight);
            //        return maxSack;
            //    }
            //    if (upperBoundNoAdd == lowerBoundNoAdd)
            //    {
            //        maxLeft = KnapSackList(capacity, items, knapSack);
            //        maxRight = KnapSackGreedyList(capacityNoAdd, newItems);
            //        maxSack = MaxKnapSack(maxLeft, maxRight);
            //        return maxSack;
            //    }
            //}


            maxLeft = KnapSackList(capacity, items, knapSack);
            maxRight = KnapSackList(capacityNoAdd, newItems, knapSackNoAdd);
            maxSack = MaxKnapSack(maxLeft, maxRight);
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

        private ICollection<Item> MaxKnapSack(ICollection<Item> maxSackLeft, ICollection<Item> maxSackRight)
        {

            if (maxSackLeft.Count == 0 && maxSackRight.Count == 0)
                return maxSackLeft;
            if (maxSackLeft.Count == 0)
                return maxSackRight;
            if (maxSackRight.Count == 0)
                return maxSackLeft;

            return GetMax(maxSackLeft, maxSackRight);
        }

        private static ICollection<Item> GetMax(IEnumerable<Item> maxSackRight, IEnumerable<Item> maxSackLeft)
        {
            var sackRight = maxSackRight as Item[] ?? maxSackRight.ToArray();
            var sackLeft = maxSackLeft as Item[] ?? maxSackLeft.ToArray();
            var maxSack = sackRight.Sum(i => i.Value) > sackLeft.Sum(i => i.Value) ? sackRight : sackLeft;
            return maxSack;
        }

        public int KnapSackGreedy(int capacity, Stack<Item> items)
        {
            var itemsList = items.OrderByDescending(i => i.WeightValueRatio).ToList();
            var value = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var item = itemsList[i];
                if (item.Weight <= capacity)
                {
                    value += item.Value;
                    capacity -= item.Weight;
                    if (capacity == 0)
                        return value;

                }
            }

            return value;
        }
        public int KnapSackPowerderd(int capacity, Stack<Item> items, bool outsideRun = false)
        {
            if (outsideRun)
            {
                do
                {
                    if (items.Count == 0)
                        break;
                    if (items.Peek().Weight > capacity)
                        items.Pop();
                    else
                        break;
                } while (true);
            }

            var itemsList = items.OrderByDescending(i => i.WeightValueRatio).ToList();
            var value = 0;
            var looper = true;
            Item fractionItem;
            if (outsideRun)
            {
                var test = 0;
            }
            do
            {
                var item = itemsList.First();

                if (item.Weight <= capacity)
                {
                    itemsList.RemoveAt(0);
                    value += item.Value;
                    capacity -= item.Weight;
                    if (capacity == 0)
                        return value;
                    if (itemsList.Count == 0)
                    {
                        looper = false;

                    }
                }
                else
                {
                    looper = false;

                }

                fractionItem = item;
            } while (looper && itemsList.Count != 0);

            var valueFraction = (int)Math.Ceiling((double)fractionItem.Value / fractionItem.Weight);
            value += (valueFraction * capacity);



            return value;
        }

        public List<Item> KnapSackGreedyList(int capacity, Stack<Item> items)
        {
            var itemsList = items.OrderByDescending(i => i.WeightValueRatio).ToList();
            var knapSack = new List<Item>();

            for (var i = 0; i < items.Count; i++)
            {
                var item = itemsList[i];
                if (item.Weight <= capacity)
                {
                    knapSack.Add(item);
                    capacity -= item.Weight;
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

    public struct Item
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
