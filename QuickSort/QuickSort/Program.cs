using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating an unsorted array of numbers
            int[] unsorted = { 99, 55, 66, 22, 33, 11, 44, 77, 88 };
            QuickSort(unsorted, 0, unsorted.Length - 1);

            for (int i = 0; i < unsorted.Length - 1; i++)
            {
                Console.Write(unsorted[i] + " ");
            }
            Console.ReadLine();
        }

        public static int Partition(int[] array, int start, int end)
        {
            int pivot = array[end];

            int PartitionIndex = start;

            for (int i = start; i < end; i++)
            {
                if (array[i] <= pivot)
                {
                    //swap if element is less than pivot
                    int temp = array[i];
                    array[i] = array[PartitionIndex];
                    array[PartitionIndex] = temp;
                    PartitionIndex++;
                }
            }
            int SwapValue = array[PartitionIndex];
            array[PartitionIndex] = array[end];
            array[end] = SwapValue;
            return PartitionIndex;
        }

        public static void QuickSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                //make call to partition
                int PartitionIndex = Partition(array, start, end);
                QuickSort(array, start, PartitionIndex - 1);
                QuickSort(array, PartitionIndex + 1, end);
            }
        }
    }
}
