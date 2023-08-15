using SortMethodWithExtensionMethods;

int[] arr = { 8, 4, 2, 6, 10, 1, 3, 5, 7, 9 };

arr.MergeSort(0, arr.Length - 1);

foreach (var num in arr)
{
    Console.Write(num + " ");
}


