using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Algorithms
{
    public class Sort
    {
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
        public void QuickSort(params int[] array)
        {

        }
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
