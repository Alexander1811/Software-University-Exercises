using System;
using System.IO.Compression;

namespace P06_ZipAndExtract
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
