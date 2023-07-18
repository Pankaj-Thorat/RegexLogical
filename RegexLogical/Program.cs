using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main()
    {
        string sourceFilePath = @"C:\MyData\TestFile.txt";

        // 1. Find the directory name
        string directoryName = Path.GetDirectoryName(sourceFilePath);
        Console.WriteLine("Directory Name: " + directoryName);

        // 2. Determine if the file exists
        bool fileExists = File.Exists(sourceFilePath);
        Console.WriteLine("File Exists: " + fileExists);

        if (fileExists)
        {
            // 3. Find the file extension
            string fileExtension = Path.GetExtension(sourceFilePath);
            Console.WriteLine("File Extension: " + fileExtension);

            // 4. Find the file length in bytes
            long fileLength = new FileInfo(sourceFilePath).Length;
            Console.WriteLine("File Length (bytes): " + fileLength);

            // 5. Serialize and deserialize data in binary format
            var data = new { Name = "John Doe", Age = 30 };

            // Serialize data to binary format
            byte[] serializedData;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, data);
                serializedData = memoryStream.ToArray();
            }

            // Deserialize data from binary format
            object deserializedData;
            using (MemoryStream memoryStream = new MemoryStream(serializedData))
            {
                deserializedData = binaryFormatter.Deserialize(memoryStream);
            }

            // Display deserialized data
            Console.WriteLine("Deserialized Data:");
            Console.WriteLine("Name: " + ((dynamic)deserializedData).Name);
            Console.WriteLine("Age: " + ((dynamic)deserializedData).Age);
        }
    }
}