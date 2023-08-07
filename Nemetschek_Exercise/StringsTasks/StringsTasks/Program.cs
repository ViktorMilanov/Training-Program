
static void SumOfNumbers(string stringNumber)
{
    string[] array = stringNumber.Split(' ');
    int sum = 0;
    for (int i = 0; i < array.Length; i++)
    {
        sum += int.Parse(array[i]);
    }
    Console.WriteLine(sum);
}

Console.WriteLine("Please enter number:");
SumOfNumbers(Console.ReadLine());
