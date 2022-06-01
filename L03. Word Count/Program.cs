namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var wordReader = new StreamReader(wordsFilePath);

            using (wordReader)
            {
                string[] words = wordReader.ReadLine().Split(" ");

                var textReader = new StreamReader(textFilePath);
                string line;
                var dict = new Dictionary<string, int>();

                using (textReader)
                {
                    while ((line = textReader.ReadLine()) != null)
                    {
                        foreach (var item in words)
                        {
                            if (line.ToLower().Contains(item.ToLower()))
                            {
                                if (!dict.ContainsKey(item))
                                {
                                    dict.Add(item, 1);
                                }
                                else
                                {
                                    dict[item]++;
                                }
                            }
                        }
                    }
                }
                var writer = new StreamWriter(outputFilePath);
                using (writer)
                {
                    foreach (var item in dict.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine(item.Key + " - " + item.Value);
                    }
                }

            }
        }

    }
}

