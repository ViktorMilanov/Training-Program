namespace StreamsTask6
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFilePath = "example.png";
            string partOneFilePath = "part-1.bin";
            string partTwoFilePath = "part-2.bin";
            string joinedFilePath = "example-joined.png";

            SplitMergeBinaryFile.SplitBinaryFile(sourceFilePath, partOneFilePath, partTwoFilePath);
            Console.WriteLine("File split completed.");

            SplitMergeBinaryFile.MergeBinaryFiles(partOneFilePath, partTwoFilePath, joinedFilePath);
            Console.WriteLine("File merge completed.");

            Console.WriteLine("Process completed.");
        }
    }

    public class SplitMergeBinaryFile
    {
        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            FileInfo fileInfo = new(sourceFilePath);
            long fileSize = fileInfo.Length;

            int partSize = (int)Math.Ceiling((double)fileSize / 2);

            using (FileStream sourceStream = new(sourceFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream partOneStream = new(partOneFilePath, FileMode.Create, FileAccess.Write))
            using (FileStream partTwoStream = new(partTwoFilePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[8192];
                int bytesRead;

                int totalBytesWritten = 0;
                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (totalBytesWritten + bytesRead <= partSize)
                    {
                        partOneStream.Write(buffer, 0, bytesRead);
                    }
                    else
                    {
                        int remainingBytes = partSize - totalBytesWritten;
                        partOneStream.Write(buffer, 0, remainingBytes);
                        partTwoStream.Write(buffer, remainingBytes, bytesRead - remainingBytes);
                    }

                    totalBytesWritten += bytesRead;
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream partOneStream = new(partOneFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream partTwoStream = new(partTwoFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream joinedStream = new(joinedFilePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[8192];
                int bytesRead;

                while ((bytesRead = partOneStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    joinedStream.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}