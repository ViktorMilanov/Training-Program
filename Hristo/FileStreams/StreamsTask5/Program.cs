namespace StreamsTask5
{
    public class ExtractBytes
    {
        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            string[] byteStrings = File.ReadAllLines(bytesFilePath);
            byte[] bytesToExtract = byteStrings.Select(byteString => byte.Parse(byteString)).ToArray();
            byte[] inputFileBytes = File.ReadAllBytes(binaryFilePath);

            using (FileStream outputFileStream = new(outputPath, FileMode.Create))
            {
                foreach (byte byteToExtract in bytesToExtract)
                {
                    foreach (byte inputByte in inputFileBytes)
                    {
                        if (inputByte == byteToExtract)
                        {
                            outputFileStream.WriteByte(inputByte);
                        }
                    }
                }
            }
            Console.WriteLine("Extraction completed successfully.");
        }

        public static void Main()
        {
            string binaryFilePath = "./example.png";
            string bytesFilePath = "./bytes.txt";
            string outputPath = "./output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }
    }
}
