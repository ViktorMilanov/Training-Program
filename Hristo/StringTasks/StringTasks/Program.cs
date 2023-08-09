using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Въведете последователност от цели положителни числа, разделени с интервал:");
        string sequence = Console.ReadLine();

        int sum = CalculateSum(sequence);
        Console.WriteLine("Сумата на числата е: " + sum);
    }

    static int CalculateSum(string sequence)
    {
        int sum = 0;
        string[] numbers = sequence.Split(' ');

        foreach (string number in numbers)
        {
            if (int.TryParse(number, out int parsedNumber))
            {
                sum += parsedNumber;
            }
        }

        return sum;
    }
}
