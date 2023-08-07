static int CountOfRepeats(string exprecion, string substring)
{
    exprecion = exprecion.ToLower();
    substring = substring.ToLower();
    int count = 0;
    int textLength = exprecion.Length;
    int searchLength = substring.Length;

    for (int i = 0; i <= textLength - searchLength; i++)
    {
        bool found = true;
        for (int j = 0; j < searchLength; j++)
        {
            if (exprecion[i + j] != substring[j])
            {
                found = false;
                break;
            }
        }

        if (found)
        {
            count++;
        }
    }

    return count;
}
Console.WriteLine(CountOfRepeats("We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.", "in"));