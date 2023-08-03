using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Algorithms
{
    public class Sort
    {
        /// <summary>
        /// Sorts an array of integers using the Bubble Sort algorithm in ascending order.
        /// </summary>
        /// <param name="list">The array of integers to be sorted.</param>
        public void BubbleSort(params int[] list)
        {
            for(int i = 0; i < list.Length; i++)
            {
                for(int x = 0; x < list.Length - 1; x++)
                {
                    if (list[x] > list[x + 1])
                    {
                        int temp = list[x];
                        list[x] = list[x + 1];
                        list[x + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an array of doubles using the Bubble Sort algorithm in ascending order.
        /// </summary>
        /// <param name="list">The array of doubles to be sorted.</param>
        public void BubbleSort(params double[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int x = 0; x < list.Length - 1; x++)
                {
                    if (list[x] > list[x + 1])
                    {
                        double temp = list[x];
                        list[x] = list[x + 1];
                        list[x + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an array of strings using the Bubble Sort algorithm in lexicographical order (alphabetically).
        /// </summary>
        /// <param name="list">The array of strings to be sorted.</param>
        public void BubbleSort(params string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int x = 0; x < list.Length - 1; x++)
                {
                    if (string.Compare(list[x],list[x + 1]) > 0)
                    {
                        string temp = list[x];
                        list[x] = list[x + 1];
                        list[x + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an array of integers using the Quick Sort algorithm in ascending order.
        /// </summary>
        /// <param name="array">The array of integers to be sorted.</param>
        /// <returns>A new array containing the sorted integers.</returns>
        public int[] QuickSort(params int[] array)
        {
            if (array.Length <= 1)
                return array;

            int pivot = array[array.Length - 1];
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j] > pivot)
                {
                    right.Add(array[j]);
                }
                else
                {
                    left.Add(array[j]);
                }
            }

            int[] lesser = QuickSort(left.ToArray());
            int[] greater = QuickSort(right.ToArray());

            List<int> result = new List<int>(lesser);
            result.Add(pivot);
            result.AddRange(greater);

            return result.ToArray();

        }

        /// <summary>
        /// Sorts an array of integers using the Merge Sort algorithm in ascending order.
        /// </summary>
        /// <param name="list">The array of integers to be sorted.</param>
        /// <returns>A new array containing the sorted integers.</returns>
        public int[] MergeSort(params int[] list)
        {
            if(list.Length == 1)
            {
                return list;
            }
            int m = list.Length / 2;
            int[] left = new int[m];
            int[] right = new int[list.Length - m];
            for(int i = 0; i < left.Length; i++)
            {
                left[i] = list[i];
            }
            for (int i = 0; i < right.Length; i++)
            {
                right[i] = list[i + m];
            }
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
            
        }

        /// <summary>
        /// Merges two sorted arrays into a single sorted array.
        /// </summary>
        /// <param name="left">The first sorted array.</param>
        /// <param name="right">The second sorted array.</param>
        /// <returns>A new array containing the merged and sorted elements from both input arrays.</returns>
        public int[] Merge(int[] left, int[] right)
        {
            List<int> merge = new List<int>();
            int leftPointer = 0, rightPointer = 0;

            while (leftPointer < left.Length && rightPointer < right.Length)
            {
                if (left[leftPointer] < right[rightPointer])
                {
                    merge.Add(left[leftPointer]);
                    leftPointer++;
                }
                else
                {
                    merge.Add(right[rightPointer]);
                    rightPointer++;
                }
            }

            while (leftPointer < left.Length)
            {
                merge.Add(left[leftPointer]);
                leftPointer++;
            }

            while (rightPointer < right.Length)
            {
                merge.Add(right[rightPointer]);
                rightPointer++;
            }

            return merge.ToArray();
        }
    }
}
