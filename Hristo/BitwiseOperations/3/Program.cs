using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Въведете цяло положително число:");
        int number = int.Parse(Console.ReadLine());

        // Изчисляваме стойностите на битовете на позиции 3, 4 и 5
        int bit3 = (number >> 3) & 1;
        int bit4 = (number >> 4) & 1;
        int bit5 = (number >> 5) & 1;

        // Изчисляваме стойностите на битовете на позиции 24, 25 и 26
        int bit24 = (number >> 24) & 1;
        int bit25 = (number >> 25) & 1;
        int bit26 = (number >> 26) & 1;

        // Разменяме стойностите на битовете на позиции 3, 4 и 5 с битовете на позиции 24, 25 и 26
        number = (number & ~(1 << 3)) | (bit24 << 3);
        number = (number & ~(1 << 4)) | (bit25 << 4);
        number = (number & ~(1 << 5)) | (bit26 << 5);

        number = (number & ~(1 << 24)) | (bit3 << 24);
        number = (number & ~(1 << 25)) | (bit4 << 25);
        number = (number & ~(1 << 26)) | (bit5 << 26);

        Console.WriteLine($"Новото число след размяна на битовете е: {number}");
    }
}
