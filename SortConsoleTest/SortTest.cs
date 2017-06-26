using SortLogic;
using System;

namespace SortConsoleTest
{
    class TestSort
    {
        private const String quickSortName = "Quick Sort";
        private const String mergeSortName = "Merge Sort";
        private const int errorIndicator = -1;

        static void Main(string[] args)
        {
            int size = GetArraySizeFromConsole();
            if (size == errorIndicator)
            {
                Console.Read();
                return;
            }
            int[] array = GetArrayFromConsole(size);

            Console.WriteLine("The initial array is:");
            PrintArrayToConsole(array);

            PerformSort(array, Sort.QuickSort, quickSortName);
            PerformSort(array, Sort.MergeSort, mergeSortName);

            Console.ReadLine();
        }

        private static void PerformSort(int[] array, Action<int[]> method, String nameOfSort)
        {
            int[] arrayForSort = new int[array.Length];
            Array.Copy(array, arrayForSort, array.Length);

            try
            {
                method(arrayForSort);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{nameOfSort} Exception: {e.Message}");
                return;
            }

            Console.WriteLine($"The array sorted with {nameOfSort} is:");
            PrintArrayToConsole(arrayForSort);
        }

        private static int GetArraySizeFromConsole()
        {
            Console.Write("Input the array size: ");
            String line = Console.ReadLine();
            if (!int.TryParse(line, out int size) || size < 0)
            {
                Console.WriteLine("Wrong size format.");
                return errorIndicator;
            }
            return size;
        }

        private static int[] GetArrayFromConsole(int size)
        {
            Console.WriteLine("Input the array elements.");
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                String str = Console.ReadLine();
                int value;
                while (!int.TryParse(str, out value))
                {
                    Console.WriteLine("Wrong integer format. Try again.");
                    str = Console.ReadLine();
                }
                array[i] = value;
            }
            return array;
        }

        private static void PrintArrayToConsole(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
    }
}
