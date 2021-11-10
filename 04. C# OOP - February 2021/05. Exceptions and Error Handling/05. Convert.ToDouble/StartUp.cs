namespace P05_ConvertToDouble
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            try
            {
                double convertedNumber = Convert.ToDouble(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
