using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Въведете число n:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Въведете позиция p:");
        int p = int.Parse(Console.ReadLine());

        int mask = 1 << p;
        int bitValue = (n & mask) >> p;

        Console.WriteLine($"Стойността на бита на позиция {p} от числото {n} е: {bitValue}");
    }
}
