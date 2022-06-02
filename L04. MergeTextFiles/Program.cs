namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var firstInputReader = new StreamReader(firstInputFilePath);
            List<string> first = new List<string>();
            List<string> second = new List<string>();

            using (firstInputReader)
            {
                string firstLine;
                while ((firstLine = firstInputReader.ReadLine()) != null)
                {  
                   first.Add(firstLine);
                }

                var secondInputReader = new StreamReader(secondInputFilePath);
                
                using (secondInputReader)
                {
                    string secondLine;
                    while ((secondLine = secondInputReader.ReadLine()) != null)
                    {
                        second.Add(secondLine);
                    }
                }

                var writer = new StreamWriter(outputFilePath);
                using (writer)
                {
                    if (first.Count > second.Count)
                    {
                        for (int i = 0; i < first.Count; i++)
                        {
                            writer.WriteLine(first[i]);

                            if (i < second.Count)
                            {
                                writer.WriteLine(second[i]);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < second.Count; i++)
                        {
                            if (i < first.Count)
                            {
                                writer.WriteLine(first[i]);
                            }
                            writer.WriteLine(second[i]);
                        }
                    }
                }
            }
        }
    }
}