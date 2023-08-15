namespace StreamsTask4
{
    public class MergeFiles
    {
        public static void Main(string[] args)
        {
            try
            {
                string firstInputFilePath = "./input1.txt";
                string secondInputFilePath = "./input2.txt";
                string outputFilePath = "./output.txt";

                MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
                Console.WriteLine("Files merged successfully.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("One or both input files not found: " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IO error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            try
            {
                using (StreamReader firstReader = new StreamReader(firstInputFilePath))
                using (StreamReader secondReader = new StreamReader(secondInputFilePath))
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string firstLine, secondLine;

                    while ((firstLine = firstReader.ReadLine()) != null)
                    {
                        writer.WriteLine(firstLine);
                    }

                    while ((secondLine = secondReader.ReadLine()) != null)
                    {
                        writer.WriteLine(secondLine);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("One or both input files not found.", ex);
            }
            catch (IOException ex)
            {
                throw new IOException("An IO error occurred while merging files.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while merging files.", ex);
            }
        }
    }
}
