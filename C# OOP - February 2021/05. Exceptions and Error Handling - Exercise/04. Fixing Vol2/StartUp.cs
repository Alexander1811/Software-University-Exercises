using System;

namespace _04._Fixing_Vol2
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int num1, num2;
                byte result;

                num1 = 30;
                num2 = 60;

                result = Convert.ToByte(num1 * num2);

                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
                Console.ReadLine();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Byte varies from 0 to 255");
            }
        }
    }
}
