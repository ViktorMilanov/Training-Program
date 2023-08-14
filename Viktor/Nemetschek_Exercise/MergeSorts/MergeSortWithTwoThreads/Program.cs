int[] arr = { 8, 4, 2, 6, 10, 1, 3, 5, 7, 9 };

Thread t = new Thread(() => MergeSort(arr, 0, arr.Length - 1));
t.Start();
t.Join();

foreach (var num in arr)
{
    Console.Write(num + " ");
}

static void MergeSort(int[] arr, int left, int right)
{
    if (left < right)
    {
        int mid = (left + right) / 2;

        Thread leftThread = new Thread(() => MergeSort(arr, left, mid));
        Thread rightThread = new Thread(() => MergeSort(arr, mid + 1, right));

        leftThread.Start();
        rightThread.Start();

        leftThread.Join();
        rightThread.Join();

        Merge(arr, left, mid, right);
    }
}

static void Merge(int[] arr, int left, int mid, int right)
{
    int n1 = mid - left + 1;
    int n2 = right - mid;

    int[] leftArray = new int[n1];
    int[] rightArray = new int[n2];

    for (int i = 0; i < n1; i++)
        leftArray[i] = arr[left + i];
    for (int j = 0; j < n2; j++)
        rightArray[j] = arr[mid + 1 + j];

    int k = left;
    int l = 0, r = 0;

    while (l < n1 && r < n2)
    {
        if (leftArray[l] <= rightArray[r])
        {
            arr[k] = leftArray[l];
            l++;
        }
        else
        {
            arr[k] = rightArray[r];
            r++;
        }
        k++;
    }

    while (l < n1)
    {
        arr[k] = leftArray[l];
        l++;
        k++;
    }

    while (r < n2)
    {
        arr[k] = rightArray[r];
        r++;
        k++;
    }
}

