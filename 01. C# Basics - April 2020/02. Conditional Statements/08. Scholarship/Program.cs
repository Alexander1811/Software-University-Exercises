using System;

namespace P08_Scholarship
{ 
	class Program
    {
        static void Main(string[] args)
        {
			double income = double.Parse(Console.ReadLine());
			double average = double.Parse(Console.ReadLine());
			double minimumWage = double.Parse(Console.ReadLine());

			bool possibleGradesScholarship = average >= 5.5;
			bool possibleSocialScholarship = income < minimumWage && average > 4.5;

			int gradesScholarship = Convert.ToInt32(Math.Floor(average * 25));
			int socialScholarship = Convert.ToInt32(Math.Floor(0.35 * minimumWage));

			if (!possibleGradesScholarship && !possibleSocialScholarship)
			{
				Console.WriteLine("You cannot get a scholarship!");
			}
			else if (possibleGradesScholarship && !possibleSocialScholarship)
			{
				Console.WriteLine($"You get a scholarship for excellent results {gradesScholarship} BGN");
			}
			else if (!possibleGradesScholarship && possibleSocialScholarship)
			{
				Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
			}
			else if (possibleGradesScholarship && possibleSocialScholarship)
			{
				if (gradesScholarship >= socialScholarship)
				{
					Console.WriteLine($"You get a scholarship for excellent results {gradesScholarship} BGN");
				}
				else
				{
					Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
				}
			}
        }
    }
}