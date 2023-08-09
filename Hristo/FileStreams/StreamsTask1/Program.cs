using System;
using System.IO;

public class MergeFiles
{
    public static void Main(string[] args)
    {
        string firstInputFilePath = "./input1.txt";
        string secondInputFilePath = "./input2.txt";
        string outputFilePath = "./output.txt";

        MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        Console.WriteLine("Files merged successfully.");
    }
    public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
    {

        //exception handling
        string[] firstLines = File.ReadAllLines(firstInputFilePath);
        string[] secondLines = File.ReadAllLines(secondInputFilePath);

        int maxLength = Math.Max(firstLines.Length, secondLines.Length);

        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            for (int i = 0; i < maxLength; i++)
            {
                if (i < firstLines.Length)
                {
                    writer.WriteLine(firstLines[i]);
                }
                if (i < secondLines.Length)
                {
                    writer.WriteLine(secondLines[i]);
                }
            }
        }
    }
}
