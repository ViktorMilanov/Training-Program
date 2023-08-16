namespace MergeSortExtension
{
    public static class ListExtensions
    {
        public static List<T> MergeSort<T>(this List<T> list) where T : IComparable<T>
        {
            if (list.Count <= 1)
                return list;

            int middle = list.Count / 2;
            List<T> left = list.GetRange(0, middle);
            List<T> right = list.GetRange(middle, list.Count - middle);

            left = left.MergeSort();
            right = right.MergeSort();

            return Merge(left, right);
        }

        private static List<T> Merge<T>(List<T> left, List<T> right) where T : IComparable<T>
        {
            List<T> merged = new();
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                {
                    merged.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    merged.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            while (leftIndex < left.Count)
            {
                merged.Add(left[leftIndex]);
                leftIndex++;
            }

            while (rightIndex < right.Count)
            {
                merged.Add(right[rightIndex]);
                rightIndex++;
            }

            return merged;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new() { 12, 5, 8, 3, 1, 7, 10, 2 };
            Console.WriteLine(string.Join(", ", numbers));

            List<int> sortedNumbers = numbers.MergeSort();
            Console.WriteLine(string.Join(", ", sortedNumbers));
        }
    }
}
