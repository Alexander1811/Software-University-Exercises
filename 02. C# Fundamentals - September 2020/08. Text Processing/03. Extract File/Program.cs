using System;
using System.Linq;

namespace P03_ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            char separator = (char)92; 
            
            string[] address = Console.ReadLine().Split(separator).ToArray();

            string[] location = address[address.Length - 1].Split(".").ToArray();

            string fileName = location[0];
            string fileExtension = location[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
