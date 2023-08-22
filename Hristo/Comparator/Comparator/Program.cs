class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class AgeComparator : IComparer<Person>
{
    public int Compare(Person person1, Person person2)
    {
        return person1.Age.CompareTo(person2.Age);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IComparer<Person> ageComparator = new AgeComparator();
        PriorityQueue<Person> priorityQueue = new(ageComparator);

        priorityQueue.Enqueue(new Person("Alex", 25));
        priorityQueue.Enqueue(new Person("Bobi", 36));
        priorityQueue.Enqueue(new Person("Viktor", 5));
        priorityQueue.Enqueue(new Person("Hristo", 120));
        priorityQueue.Enqueue(new Person("Lucy", 20));

        while (priorityQueue.Count > 0)
        {
            Person person = priorityQueue.Dequeue();
            Console.WriteLine($"{person.Name} - Age: {person.Age}");
        }
    }
}

public class PriorityQueue<T>
{
    private List<T> list;
    private IComparer<T> comparer;

    public int Count => list.Count;

    public PriorityQueue(IComparer<T> comparer)
    {
        this.comparer = comparer;
        this.list = new List<T>();
    }

    public void Enqueue(T item)
    {
        list.Add(item);
        list.Sort(comparer);
    }

    public T Dequeue()
    {
        if (list.Count == 0)
            throw new InvalidOperationException("PriorityQueue is empty");

        T item = list[0];
        list.RemoveAt(0);
        return item;
    }
}
