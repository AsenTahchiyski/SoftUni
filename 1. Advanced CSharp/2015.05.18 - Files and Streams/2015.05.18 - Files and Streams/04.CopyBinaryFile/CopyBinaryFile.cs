using System;
using System.IO;
class CopyBinaryFile
{
    static void Main()
    {
        using (FileStream source = new FileStream("image.jpg", FileMode.Open))
        {
            using (FileStream destination = new FileStream("image_copy.jpg", FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                while (true)
                {
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    destination.Write(buffer, 0, readBytes);
                }
            }
        }
        Console.WriteLine("Copying done, please check your /bin/Debug folder.");
    }
}
