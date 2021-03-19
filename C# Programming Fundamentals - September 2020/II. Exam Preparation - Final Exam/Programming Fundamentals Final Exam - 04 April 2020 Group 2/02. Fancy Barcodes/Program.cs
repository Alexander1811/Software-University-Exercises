using System;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex barcodeRegex = new Regex(@"^(@#+)(?<barcode>[A-Z]{1}[A-Za-z0-9]{4,}[A-Z]{1})(@#+)$");
            Regex digitRegex = new Regex(@"\d");

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match barcode = barcodeRegex.Match(input);

                if (barcode.Success)
                {
                    string name = barcode.Groups["barcode"].Value;
                    MatchCollection digits = digitRegex.Matches(name);
                    string productGroup = "";

                    foreach (Match digit in digits)
                    {
                        if (digit.Success)
                        {
                            productGroup += digit;
                        }
                    }
                    if (productGroup.Length == 0)
                    {
                        productGroup = "00";
                    }
                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}