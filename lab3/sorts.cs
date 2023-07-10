using System;
using System.Collections.Generic;

public static class ArrayExtensions
{
    public enum SortOrder
    {
        Ascending,
        Descending
    }
    
    
   private static void Swap<T>(T[] array, int i, int j)
    {
        T temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
   
    private static void BubbleSort<T>(T[] array, SortOrder sortOrder, IComparer<T>? comparer)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (sortOrder == SortOrder.Ascending
                        ? comparer?.Compare(array[j], array[j + 1]) > 0
                        : comparer?.Compare(array[j], array[j + 1]) < 0)
                {
                    Swap(array, j, j + 1);
                }
            }
        }
    }

    private static void InsertionSort<T>(T[] array, SortOrder sortOrder, IComparer<T>? comparer)
    {
        for (int i = 1; i < array.Length; i++)
        {
            T key = array[i];
            int j = i - 1;

            while (j >= 0 && (sortOrder == SortOrder.Ascending
                       ? comparer?.Compare(array[j], key) > 0
                       : comparer?.Compare(array[j], key) < 0))
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
        }
    }

    private static void SelectionSort<T>(T[] array, SortOrder sortOrder, IComparer<T>? comparer)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (sortOrder == SortOrder.Ascending
                        ? comparer?.Compare(array[j], array[minIndex]) < 0
                        : comparer?.Compare(array[j], array[minIndex]) > 0)
                {
                    minIndex = j;
                }
            }

            Swap(array, minIndex, i);
        }
    }

    private static int Partition<T>(T[] array, int low, int high, SortOrder sortOrder, IComparer<T>? comparer)
    {
        T pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (sortOrder == SortOrder.Ascending
                    ? comparer?.Compare(array[j], pivot) < 0
                    : comparer?.Compare(array[j], pivot) > 0)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);

        return i + 1;
    }

    private static void QuickSort<T>(T[] array, int low, int high, SortOrder sortOrder, IComparer<T>? comparer)
    {
        if (low < high)
        {
            int partitionIndex = Partition(array, low, high, sortOrder, comparer);
            QuickSort(array, low, partitionIndex - 1, sortOrder, comparer);
            QuickSort(array, partitionIndex + 1, high, sortOrder, comparer);
        }
    }

    private static void Merge<T>(T[] array, int left, int mid, int right, SortOrder sortOrder, IComparer<T>? comparer)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        T[] leftArray = new T[n1];
        T[] rightArray = new T[n2];

        Array.Copy(array, left, leftArray, 0, n1);
        Array.Copy(array, mid + 1, rightArray, 0, n2);

        int i = 0, j = 0;
        int k = left;

        while (i < n1 && j < n2)
        {
            if (sortOrder == SortOrder.Ascending
                    ? comparer?.Compare(leftArray[i], rightArray[j]) <= 0
                    : comparer?.Compare(leftArray[i], rightArray[j]) >= 0)
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < n2)
        {
array[k] = rightArray[j];
            j++;
            k++;
        }
    }

    private static void MergeSort<T>(T[] array, int left, int right, SortOrder sortOrder, IComparer<T>? comparer)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(array, left, mid, sortOrder, comparer);
            MergeSort(array, mid + 1, right, sortOrder, comparer);
            Merge(array, left, mid, right, sortOrder, comparer);
        }
    }

    private static void Heapify<T>(T[] array, int n, int i, SortOrder sortOrder, IComparer<T>? comparer)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && (sortOrder == SortOrder.Ascending
                   ? comparer?.Compare(array[left], array[largest]) > 0
                   : comparer?.Compare(array[left], array[largest]) < 0))
        {
            largest = left;
        }

        if (right < n && (sortOrder == SortOrder.Ascending
                   ? comparer?.Compare(array[right], array[largest]) > 0
                   : comparer?.Compare(array[right], array[largest]) < 0))
        {
            largest = right;
        }

        if (largest != i)
        {
            Swap(array, i, largest);
            Heapify(array, n, largest, sortOrder, comparer);
        }
    }

    private static void HeapSort<T>(T[] array, SortOrder sortOrder, IComparer<T>? comparer)
    {
        int n = array.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(array, n, i, sortOrder, comparer);
        }

        for (int i = n - 1; i > 0; i--)
        {
            Swap(array, 0, i);
            Heapify(array, i, 0, sortOrder, comparer);
        }
    }

  


    public enum SortingAlgorithm
    {
        BubbleSort,
        InsertionSort,
        SelectionSort,
        HeapSort,
        QuickSort,
        MergeSort
    }

    public static T[] Sort<T>(this T[] array, SortOrder sortOrder, SortingAlgorithm sortingAlgorithm)
    {
        return Sort(array, sortOrder, sortingAlgorithm, Comparer<T>.Default);
    }

    public static T[] Sort<T>(this T[] array, SortOrder sortOrder, SortingAlgorithm sortingAlgorithm, IComparer<T> comparer)
    {
        switch (sortingAlgorithm)
        {
            case SortingAlgorithm.BubbleSort:
                BubbleSort(array, sortOrder, comparer);
                break;
            case SortingAlgorithm.InsertionSort:
                InsertionSort(array, sortOrder, comparer);
                break;
            case SortingAlgorithm.SelectionSort:
                SelectionSort(array, sortOrder, comparer);
                break;
            case SortingAlgorithm.QuickSort:
                QuickSort(array, 0, array.Length - 1, sortOrder, comparer);
                break;
            case SortingAlgorithm.MergeSort:
                MergeSort(array, 0, array.Length - 1, sortOrder, comparer);
                break;
            case SortingAlgorithm.HeapSort:
                HeapSort(array, sortOrder, comparer);
                break;
            default:
                throw new ArgumentException("Invalid sorting algorithm");
        }

        return array;
    }

    public static T[] Sort<T>(this T[] array, SortOrder sortOrder, SortingAlgorithm sortingAlgorithm, Comparer<T> comparer)
    {
        switch (sortingAlgorithm)
        {
            case SortingAlgorithm.BubbleSort:
                BubbleSort(array, sortOrder, comparer);
                break;
            case SortingAlgorithm.InsertionSort:
                InsertionSort(array, sortOrder, comparer);
                break;
            case SortingAlgorithm.SelectionSort:
                SelectionSort(array, sortOrder, comparer);
                break;
            case SortingAlgorithm.QuickSort:
                QuickSort(array, 0, array.Length - 1, sortOrder, comparer);
                break;
            case SortingAlgorithm.MergeSort:
                MergeSort(array, 0, array.Length - 1, sortOrder, comparer);
                break;
            case SortingAlgorithm.HeapSort:
                HeapSort(array, sortOrder, comparer);
                break;
            default:
                throw new ArgumentException("Invalid sorting algorithm");
        }
        return array;
    }

    public static T[] Sort<T>(this T[] array, SortOrder sortOrder, SortingAlgorithm sortingAlgorithm, Comparison<T> comparison)
    {
        if (comparison == null)
            throw new ArgumentNullException(nameof(comparison));

        return Sort(array, sortOrder, sortingAlgorithm, Comparer<T>.Create(comparison));
    }

}