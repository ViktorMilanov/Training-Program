namespace StreamsTask7
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = "./TestFolder";
            string outputFilePath = "./output.txt";

            FolderSize.GetFolderSize(folderPath, outputFilePath);
            Console.WriteLine("Folder size calculation completed.");
        }
    }

    public class FolderSize
    {
        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            long totalSizeBytes = CalculateFolderSize(folderPath);

            double totalSizeKilobytes = totalSizeBytes / 1024.0;

            string outputText = $"{totalSizeKilobytes:F9} KB";

            File.WriteAllText(outputFilePath, outputText);
        }

        private static long CalculateFolderSize(string folderPath)
        {
            long totalSize = 0;

            foreach (string filePath in Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories))
            {
                FileInfo fileInfo = new(filePath);
                totalSize += fileInfo.Length;
            }

            return totalSize;
        }
    }
}