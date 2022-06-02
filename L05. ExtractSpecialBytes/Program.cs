namespace ExtractSpecialBytes
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            var sb = new StringBuilder();

            using (var readerBit = new StreamReader(bytesFilePath))
            {
                while (!readerBit.EndOfStream)
                {
                    sb.Append(readerBit.ReadLine() + " ");
                }
            }

            var bytes = sb.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(byte.Parse);

            using (FileStream reader = new FileStream(binaryFilePath, FileMode.Open))
            {

                byte[] buff = new byte[reader.Length];
                reader.Read(buff, 0, buff.Length);

                using(FileStream write = new FileStream(outputPath, FileMode.OpenOrCreate))
                {
                    foreach (byte item in buff)
                    {
                        if (bytes.Contains(item))
                        {
                            write.WriteByte(item);
                        }
                    }
                }
            }
        }
    }
}
