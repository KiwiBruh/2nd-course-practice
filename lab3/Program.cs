using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] numbers = { 5, 2, 8, 1, 9 };

        // Сортировка в порядке возрастания с использованием стандартного правила сравнения
        Console.WriteLine("Сортировка в порядке возрастания с использованием стандартного правила сравнения:");
        var sortedNumbers1 = numbers.Sort(ArrayExtensions.SortOrder.Ascending, ArrayExtensions.SortingAlgorithm.MergeSort);
        PrintArray(sortedNumbers1);

        // Сортировка в порядке убывания с использованием стандартного правила сравнения
        Console.WriteLine("Сортировка в порядке убывания с использованием стандартного правила сравнения:");
        var sortedNumbers2 = numbers.Sort(ArrayExtensions.SortOrder.Descending, ArrayExtensions.SortingAlgorithm.InsertionSort);
        PrintArray(sortedNumbers2);

        // Сортировка в порядке возрастания с использованием пользовательского правила сравнения (IComparer<T>)
        Console.WriteLine("Сортировка в порядке возрастания с использованием пользовательского правила сравнения (IComparer<T>):");
        var sortedNumbers3 = numbers.Sort(ArrayExtensions.SortOrder.Ascending, ArrayExtensions.SortingAlgorithm.SelectionSort,
            Comparer<int>.Create((x, y) => x.CompareTo(y)));
        PrintArray(sortedNumbers3);

        // Сортировка в порядке убывания с использованием пользовательского правила сравнения (Comparer<T>)
        Console.WriteLine("Сортировка в порядке убывания с использованием пользовательского правила сравнения (Comparer<T>):");
        var sortedNumbers4 = numbers.Sort(ArrayExtensions.SortOrder.Descending, ArrayExtensions.SortingAlgorithm.HeapSort,
            Comparer<int>.Default);
        PrintArray(sortedNumbers4);

        // Сортировка в порядке возрастания с использованием пользовательского правила сравнения (Comparison<T>)
        Console.WriteLine("Сортировка в порядке возрастания с использованием пользовательского правила сравнения (Comparison<T>):");
        var sortedNumbers5 = numbers.Sort(ArrayExtensions.SortOrder.Ascending, ArrayExtensions.SortingAlgorithm.QuickSort,
            (x, y) => x.CompareTo(y));
        PrintArray(sortedNumbers5);
    }

    private static void PrintArray<T>(T[] array)
    {
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}