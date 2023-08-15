class Program
{
    static void Main(string[] args)
    {
        SortedSet<int> priorityQueue = new()
        {
            6,
            5,
            2,
            8,
            3,
            4,
            1,
            10,
            7,
            9
        };

        priorityQueue.Remove(priorityQueue.Max);
        priorityQueue.Remove(priorityQueue.Min);
        priorityQueue.Reverse();

        foreach (int element in priorityQueue)
        {
            Console.WriteLine(element);
        }
    }
}
