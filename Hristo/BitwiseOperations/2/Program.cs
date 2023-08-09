using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Въведете число n:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Въведете позиция p:");
        int p = int.Parse(Console.ReadLine());

        Console.WriteLine("Въведете стойност v (0 или 1):");
        int v = int.Parse(Console.ReadLine());

        int mask = 1 << p;

        if (v == 1)
        {
            n |= mask;
        }
        else if (v == 0)
        {
            n &= ~mask;
        }

        Console.WriteLine($"Новата стойност на числото n е: {n}");
    }
}
