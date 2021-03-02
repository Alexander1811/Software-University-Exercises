using System;

namespace _10._Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int nights = int.Parse(Console.ReadLine());
            nights--;
            string type = Convert.ToString(Console.ReadLine());
            string rating = Convert.ToString(Console.ReadLine());

            double discount = 0;

            //вид помещение           по - малко от 10 дни    между 10 и 15 дни       повече от 15 дни
            //room for one person     не ползва намаление     не ползва намаление     не ползва намаление
            //apartment               30 % от крайната цена   35 % от крайната цена   50 % от крайната цена
            //president apartment     10 % от крайната цена   15 % от крайната цена   20 % от крайната цена

            if (type == "room for one person")
            {
                double pricePerNight = 18;
                discount = pricePerNight * nights;
            }
            else if (type == "apartment")
            {
                double pricePerNight = 25;
                if (nights < 10)
                {
                    discount = (pricePerNight * nights) * 0.7;
                }
                else if (nights >= 10 && nights <= 15)
                {
                    discount = (pricePerNight * nights) * 0.65;
                }
                else if (nights > 15)
                {
                    discount = (pricePerNight * nights) * 0.5;
                }
            }
            else if (type == "president apartment")
            {
                double pricePerNight = 35;
                if (nights < 10)
                {
                    discount = (pricePerNight * nights) * 0.9;
                }
                else if (nights >= 10 && nights <= 15)
                {
                    discount = (pricePerNight * nights) * 0.85;
                }
                else if (nights > 15)
                {
                    discount = (pricePerNight * nights) * 0.8;
                }
            }


            if (rating == "positive")
            {
                discount *= 1.25;
            }
            else if (rating == "negative")
            {
                discount *= 0.9;
            }

            Console.WriteLine($"{discount:f2}");
        }
    }
}
