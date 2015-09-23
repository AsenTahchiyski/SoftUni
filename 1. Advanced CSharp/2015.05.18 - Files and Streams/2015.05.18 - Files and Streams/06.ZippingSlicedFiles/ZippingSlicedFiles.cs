// Kamigawa
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ZippingSlicedFiles
{
    class ZippingSlicedFiles
    {
        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                byte[] buffer = new byte[4096];
                var allData = new List<byte>();
                while (true)
                {
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }

                    for (int i = 0; i < readBytes; i++)
                    {
                        allData.Add(buffer[i]);
                    }
                }

                int partSize = allData.Count / parts;
                int leftOver = allData.Count - partSize * parts;
                for (int i = 0; i < parts; i++)
                {
                    var newFile = destinationDirectory + "part-" + i + ".zip";
                    using (var copy = new FileStream(newFile, FileMode.Create))
                    {
                        using (var zip = new GZipStream(copy, CompressionMode.Compress))
                        {
                            if (i == parts - 1)
                            {
                                zip.Write(allData.ToArray(), i * partSize, partSize + leftOver);
                            }
                            else
                            {
                                zip.Write(allData.ToArray(), i * partSize, partSize);
                            }
                        }
                    }
                }
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            var allData = new List<byte>();
            for (int i = 0; i < files.Count; i++)
            {
                var sourceFile = files[i];
                using (var source = new FileStream(sourceFile, FileMode.Open))
                {
                    using (var zip = new GZipStream(source, CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = zip.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }

                            for (int j = 0; j < readBytes; j++)
                            {
                                allData.Add(buffer[j]);
                            }
                        }
                    }
                }
            }

            using (var copy = new FileStream(destinationDirectory, FileMode.Create))
            {
                copy.Write(allData.ToArray(), 0, allData.Count);
            }
        }
        static void Main(string[] args)
        {
            string sourceFile = "../../ZippingSlicedFiles.cs";
            string destinationDirectory = "../../";
            int parts = 5;
            Slice(sourceFile, destinationDirectory, parts);
            Assemble(new List<string>()
            {
                "../../part-0.zip",
                "../../part-1.zip",
                "../../part-2.zip",
                "../../part-3.zip",
                "../../part-4.zip",
            }, "../../Constructed.txt");

            Console.WriteLine("DONE");
        }
    }
}

// mine
//using System;
//using System.Linq;
//using System.Collections.Generic;
//using System.IO;
//using System.IO.Compression;
//using System.Text;
//class ZippingSlicedFiles
//{
//    static string ext;
//    static void Main()
//    {
//        // slice file
//        Console.Write("Please enter number of slices: ");
//        int parts = int.Parse(Console.ReadLine());
//        Slice("hubble.jpg", @"\..", parts);
//        Console.WriteLine("Slicing done.");
//        // assemble files
//        List<string> files = new List<string>();
//        string destinationDirectory = Directory.GetCurrentDirectory();
//        string[] allFiles = Directory.GetFiles(destinationDirectory);
//        for (int i = 0; i < allFiles.Length; i++)
//        {
//            if (allFiles[i].Contains("Part-") && allFiles[i].Contains(".gz"))
//            {
//                files.Add(allFiles[i]);
//            }
//        }
//        Assemble(files, destinationDirectory);
//        Console.WriteLine("Original file assembled.");
//    }
//    static void Slice(string sourceFile, string destinationDirectory, int parts)
//    {
//        byte[] buffer = new byte[4096];
//        long fileSize = new FileInfo(sourceFile).Length;
//        string extension = new FileInfo(sourceFile).Extension;
//        ext = extension;
//        int pieceSize = (int)Math.Ceiling((decimal)fileSize / parts);
//        using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
//        {
//            for (int part = 0; part < parts; part++)
//            {
//                string destinationFileName = string.Format("Part-{0}", (part + 1).ToString("D3")) + ".gz";
//                using (FileStream writer = new FileStream(destinationFileName, FileMode.Append))
//                {
//                    long currentPieceSize = 0;
//                    while (currentPieceSize < pieceSize)
//                    {
//                        // read piece
//                        int bytesRead = reader.Read(buffer, 0, buffer.Length);
//                        if (bytesRead == 0) break;
//                        // write piece
//                        buffer = ZipSlices(buffer); // <- zip parts
//                        writer.Write(buffer, 0, buffer.Length);
//                        currentPieceSize += bytesRead;
//                    }
//                }
//            }
//        }
//    }
//    static byte[] ZipSlices(byte[] buffer)
//    {
//        using (MemoryStream dataIn = new MemoryStream())
//        {
//            using (GZipStream gzip = new GZipStream(dataIn, CompressionMode.Compress, true))
//            {
//                gzip.Write(buffer, 0, buffer.Length);
//            }
//            return dataIn.ToArray();
//        }
//    }
//    private static void Assemble(List<string> files, string destinationDirectory)
//    {
//        var allData = new List<byte>();
//        for (int i = 0; i < files.Count; i++)
//        {
//            var sourceFile = files[i];
//            using (var source = new FileStream(sourceFile, FileMode.Open))
//            {
//                using (var zip = new GZipStream(source, CompressionMode.Decompress))
//                {
//                    byte[] buffer = new byte[4096];
//                    while (true)
//                    {
//                        int readBytes = zip.Read(buffer, 0, buffer.Length);
//                        if (readBytes == 0)
//                        {
//                            break;
//                        }
//                        for (int j = 0; j < readBytes; j++)
//                        {
//                            allData.Add(buffer[j]);
//                        }
//                    }
//                }
//            }
//            using (var copy = new FileStream("Assembled" + ext, FileMode.Append))
//            {
//                copy.Write(allData.ToArray(), 0, allData.Count);
//            }
//        }
//    }
//}
