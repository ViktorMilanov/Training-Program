string input1FilePath = @"..\..\..\Files\input1.txt";
string input2FilePath = @"..\..\..\Files\input2.txt";
string outputFilePath = @"..\..\..\Files\output.txt";

MergeTextFiles(input1FilePath, input2FilePath, outputFilePath);

void MergeTextFiles(string input1FilePath, string input2FilePath, string outputFilePath)
{
    string[] input1 = File.ReadAllLines(input1FilePath);
    string[] input2 = File.ReadAllLines(input2FilePath); ;
    using (StreamWriter writer = new StreamWriter(outputFilePath, true))
    {
        if (input1.Length >= input2.Length)
        {
            for (int i = 0; i < input1.Length; i++)
            {
                writer.WriteLine(input1[i]);
                if(input2.Length - 1 >= i)
                {
                    writer.WriteLine(input2[i]);
                }
            }
        }
        else
        {
            for (int i = 0; i < input2.Length; i++)
            {
                if (input1.Length - 1 >= i)
                {
                    writer.WriteLine(input1[i]);
                }
                writer.WriteLine(input2[i]);
            }
        }
    }
}