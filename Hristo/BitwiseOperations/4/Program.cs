using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Въведете цяло положително число:");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Въведете стартова позиция p:");
        int p = int.Parse(Console.ReadLine());

        Console.WriteLine("Въведете стартова позиция q:");
        int q = int.Parse(Console.ReadLine());

        Console.WriteLine("Въведете брой битове k:");
        int k = int.Parse(Console.ReadLine());

        // Изчисляваме стойностите на битовете на позиции {p, p+1, ..., p+k-1}
        int maskP = 0;
        for (int i = p; i < p + k; i++)
        {
            int bit = (number >> i) & 1;
            maskP |= bit << (i - p);
        }

        // Изчисляваме стойностите на битовете на позиции {q, q+1, ..., q+k-1}
        int maskQ = 0;
        for (int i = q; i < q + k; i++)
        {
            int bit = (number >> i) & 1;
            maskQ |= bit << (i - q);
        }

        // Разменяме битовете на позиции {p, p+1, ..., p+k-1} с битовете на позиции {q, q+1, ..., q+k-1}
        number &= ~(maskP << p);
        number |= maskQ << p;

        number &= ~(maskQ << q);
        number |= maskP << q;

        Console.WriteLine($"Новото число след размяна на битовете е: {number}");
    }
}
