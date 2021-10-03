using System;
using System.IO;
using System.IO.Compression;

namespace _06._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {

            using ZipArchive zipFile = ZipFile.Open(@"../../../zipFile.zip", ZipArchiveMode.Update);
            ZipArchiveEntry zipArchiveEntry = zipFile.CreateEntryFromFile("copyMe.png", "copyMeEntry.png");

            zipFile.ExtractToDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }
    }
}
