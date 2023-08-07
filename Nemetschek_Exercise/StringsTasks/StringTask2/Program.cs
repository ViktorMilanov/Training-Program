using System.Text;

static void ReverseString(StringBuilder stringToReverse, int lenght)
{
    for (int i = 0; i < stringToReverse.Length; i++)
    {
        char c = stringToReverse[0];
        for (int j = 1; j < lenght; j++)
        {
            stringToReverse[j - 1] = stringToReverse[j];
        }
        stringToReverse[lenght - 1] = c;
        lenght--;
    }
    Console.WriteLine(stringToReverse.ToString());
}
Console.WriteLine("Please enter string:");
string toReplaceStr = Console.ReadLine();
StringBuilder toReplace = new StringBuilder(toReplaceStr);
ReverseString(toReplace, toReplace.Length);