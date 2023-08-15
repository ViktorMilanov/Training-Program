﻿class ParallelMergeSort
{
    static void Merge(int[] arr, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] leftArr = new int[n1];
        int[] rightArr = new int[n2];

        Array.Copy(arr, left, leftArr, 0, n1);
        Array.Copy(arr, middle + 1, rightArr, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (leftArr[i] <= rightArr[j])
            {
                arr[k] = leftArr[i];
                i++;
            }
            else
            {
                arr[k] = rightArr[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            arr[k] = leftArr[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            arr[k] = rightArr[j];
            j++;
            k++;
        }
    }

    static async Task MergeSortAsync(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;

            Task leftTask = MergeSortAsync(arr, left, middle);
            Task rightTask = MergeSortAsync(arr, middle + 1, right);

            await Task.WhenAll(leftTask, rightTask);

            Merge(arr, left, middle, right);
        }
    }

    static async Task Main(string[] args)
    {
        int[] array = { 12, 11, 13, 5, 6, 7 };

        Console.WriteLine("Original array: " + string.Join(", ", array));

        await MergeSortAsync(array, 0, array.Length - 1);

        Console.WriteLine("Sorted array: " + string.Join(", ", array));
    }
}
