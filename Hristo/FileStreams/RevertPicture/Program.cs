namespace InvertImageColors
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputImagePath = "./input.png";
            string outputImagePath = "./output.png";

            InvertImageColors(inputImagePath, outputImagePath);

            Console.WriteLine("Image colors inverted successfully.");
        }

        static void InvertImageColors(string inputImagePath, string outputImagePath)
        {
            using (Image<Rgba32> inputImage = Image.Load<Rgba32>(inputImagePath))
            {
                using (Image<Rgba32> invertedImage = new(inputImage.Width, inputImage.Height))
                {
                    for (int y = 0; y < inputImage.Height; y++)
                    {
                        for (int x = 0; x < inputImage.Width; x++)
                        {
                            Rgba32 originalColor = inputImage[x, y];
                            Rgba32 invertedColor = new((byte)(255 - originalColor.R), (byte)(255 - originalColor.G), (byte)(255 - originalColor.B), originalColor.A);
                            invertedImage[x, y] = invertedColor;
                        }
                    }

                    invertedImage.Save(outputImagePath);
                }
            }
        }
    }
}
