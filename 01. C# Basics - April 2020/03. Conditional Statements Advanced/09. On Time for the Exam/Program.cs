using System;

namespace P09_OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHours = int.Parse(Console.ReadLine()); 
            int examMinutes = int.Parse(Console.ReadLine()); 
            int arrivalHours = int.Parse(Console.ReadLine()); 
            int arrivalMinutes = int.Parse(Console.ReadLine()); 

            int minutesExam = examHours * 60 + examMinutes;
            int minutesArrival = arrivalHours * 60 + arrivalMinutes;

            int differenceInMinutes = Math.Abs(minutesExam - minutesArrival);
            int hoursDifference = differenceInMinutes / 60;
            int minutesDifference = differenceInMinutes % 60;

            if (minutesExam - 30 <= minutesArrival && minutesArrival <= minutesExam)
            {
                Console.WriteLine("On time");

                if (minutesArrival != minutesExam)
                {
                    if (differenceInMinutes < 60)
                    {
                        if (minutesDifference < 10)
                        {
                            Console.WriteLine($"{minutesDifference} minutes before the start");
                        }
                        else
                        {
                            Console.WriteLine($"{minutesDifference} minutes before the start");
                        }
                    }
                    else
                    {
                        if (minutesDifference < 10)
                        {
                            Console.WriteLine($"{hoursDifference}:0{minutesDifference} hours before the start");
                        }
                        else
                        {
                            Console.WriteLine($"{hoursDifference}:{minutesDifference} hours before the start");
                        }
                    }
                }
            }
            else if (minutesArrival < minutesExam - 30)
            {
                Console.WriteLine("Early");

                if (differenceInMinutes < 60)
                {
                    if (minutesDifference < 10)
                    {
                        Console.WriteLine($"{minutesDifference} minutes before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{minutesDifference} minutes before the start");
                    }
                }
                else
                {
                    if (minutesDifference < 10)
                    {
                        Console.WriteLine($"{hoursDifference}:0{minutesDifference} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hoursDifference}:{minutesDifference} hours before the start");
                    }
                }
            }
            else if (minutesExam < minutesArrival)
            {
                Console.WriteLine("Late");

                if (differenceInMinutes < 60)
                {
                    if (minutesDifference < 10)
                    {
                        Console.WriteLine($"{minutesDifference} minutes after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{minutesDifference} minutes after the start");
                    }
                }
                else
                {
                    if (minutesDifference < 10)
                    {
                        Console.WriteLine($"{hoursDifference}:0{minutesDifference} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hoursDifference}:{minutesDifference} hours after the start");
                    }
                }
            }
        }
    }
}
