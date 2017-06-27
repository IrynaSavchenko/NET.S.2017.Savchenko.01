using System;

namespace SortLogic
{
    /// <summary>
    /// Class to sort an integer array using different sorting algorithms
    /// </summary>
    public static class Sort
    {
        private const String nullAarrayError = "The array cannot be null.";
        private const String emptyArrayError = "The array cannot be empty.";

        /// <summary>
        /// Checks the array for being null or empty. If so, throws exceptions.
        /// Otherwise, invokes the recursive quicksort algorithm.
        /// </summary>
        /// <param name="array">Array to sort</param>
        public static void QuickSort(int[] array)
        {
            CheckInputArray(array);
            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Logic for the recursive quicksort algorithm
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="leftIndex">Start index of the array</param>
        /// <param name="rightIndex">End index of the array</param>
        private static void QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            int partitionIndex = GetPartitionIndex(array, leftIndex, rightIndex);

            if (leftIndex < partitionIndex - 1)
            {
                QuickSort(array, leftIndex, partitionIndex - 1);
            }
            if (rightIndex > partitionIndex)
            {
                QuickSort(array, partitionIndex, rightIndex);
            }
        }

        /// <summary>
        /// Divides the array into two parts so that the first part contains elements
        /// less than pivot, whereas the second part contains elements greater than pivot
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="leftIndex">Index to start from</param>
        /// <param name="rightIndex">Index to end with</param>
        /// <returns>Partition index</returns>
        private static int GetPartitionIndex(int[] array, int leftIndex, int rightIndex)
        {
            int pivot = array[leftIndex];

            while (leftIndex <= rightIndex)
            {
                while (array[leftIndex] < pivot)
                {
                    leftIndex++;
                }
                while (array[rightIndex] > pivot)
                {
                    rightIndex--;
                }
                if (leftIndex <= rightIndex)
                {
                    Swap(ref array[leftIndex], ref array[rightIndex]);
                    leftIndex++;
                    rightIndex--;
                }
            }
            return leftIndex;
        }

        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        /// <summary>
        /// Checks the array for being null or empty. If so, throws exceptions.
        /// Otherwise, invokes the recursive mergesort algorithm.
        /// </summary>
        /// <param name="array"></param>
        public static void MergeSort(int[] array)
        {
            CheckInputArray(array);
            MergeSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Logic for the recursive mergesort algorithm
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="leftIndex">Start index of the array</param>
        /// <param name="rightIndex">End index of the array</param>
        private static void MergeSort(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int middleIndex = (leftIndex / 2) + (rightIndex / 2);

                MergeSort(array, leftIndex, middleIndex);
                MergeSort(array, middleIndex + 1, rightIndex);

                Merge(array, leftIndex, middleIndex, rightIndex);
            }
        }

        /// <summary>
        /// Logic for merging two sorted parts
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="leftIndex">Start index of the array</param>
        /// <param name="middleIndex">Boundary index of two sorted parts</param>
        /// <param name="rightIndex">End index of the array</param>
        private static void Merge(int[] array, int leftIndex, int middleIndex, int rightIndex)
        {
            int left = leftIndex;
            int right = middleIndex + 1;
            int[] tmp = new int[(rightIndex - leftIndex) + 1];
            int tmpIndex = 0;

            while ((left <= middleIndex) && (right <= rightIndex))
            {
                if (array[left] < array[right])
                {
                    tmp[tmpIndex] = array[left];
                    left++;
                }
                else
                {
                    tmp[tmpIndex] = array[right];
                    right++;
                }
                tmpIndex++;
            }

            while (left <= middleIndex)
            {
                tmp[tmpIndex] = array[left];
                left++;
                tmpIndex++;
            }

            while (right <= rightIndex)
            {
                tmp[tmpIndex] = array[right];
                right++;
                tmpIndex++;
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                array[leftIndex + i] = tmp[i];
            }
        }

        private static void CheckInputArray(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nullAarrayError);
            }
            if (array.Length == 0)
            {
                throw new ArgumentException(emptyArrayError);
            }
        }
    }
}
