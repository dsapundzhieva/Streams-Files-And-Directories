namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);

            using (reader)
            {
                using (var writer = new StreamWriter(outputFilePath))
                {
                    string line;
                    int linesNum = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{linesNum}. {line}");
                        linesNum++;
                    }
                }
            }
        }
    }
}
