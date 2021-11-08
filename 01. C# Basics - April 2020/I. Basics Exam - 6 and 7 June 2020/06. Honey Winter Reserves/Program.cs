using System;

namespace P06_HoneyWinterReserves
{
	class Program
	{
		static void Main(string[] args)
		{
			double neededHoney = double.Parse(Console.ReadLine());
			string command = "";
			double totalHoney = 0;

			while (command != "Winter has come")
			{
				command = Console.ReadLine();
				if (command == "Winter has come")
				{
					break;
				}

				string name = command;
				double totalPerBee = 0;
				for (int months = 0; months < 6; months++)
				{
					double producedHoney = double.Parse(Console.ReadLine());

					totalPerBee += producedHoney;
					totalHoney += producedHoney;
				}
				if (totalPerBee < 0)
				{
					Console.WriteLine($"{name} was banished for gluttony");
				}

				if (totalHoney >= neededHoney)
				{
					Console.WriteLine($"Well done! Honey surplus {totalHoney - neededHoney:F2}.");

					break;
				}
			}

			if (totalHoney < neededHoney)
			{
				Console.WriteLine($"Hard Winter! Honey needed {neededHoney - totalHoney:F2}.");
			}

			//My alterntive bad version; the moment the 6 months pahve passed and the honey is enough it should automatcally result in "well done" without "winterr has come command" 
			//double neededHoney = double.Parse(Console.ReadLine());
			//string command = "";
			//double totalHoney = 0;

			//while (command != "Winter has come")
			//{
			//	command = Console.ReadLine();
			//	if (command == "Winter has come")
			//	{
			//		break;
			//	}
			//	string name = command;
			//  double currentTotalHoney = 0;
			//	for (int months = 0; months < 6; months++)
			//	{
			//		double producedHoney = double.Parse(Console.ReadLine());
			//		currentTotalHoney += producedHoney;
			//		totalHoney += producedHoney;
			//	}
			//	if (currentTotalHoney < 0)
			//	{
			//		Console.WriteLine($"{name} was banished for gluttony");
			//		currentTotalHoney = 0;
			//	}
			//}
			//if (totalHoney >= neededHoney)
			//{
			//	Console.WriteLine($"Well done! Honey surplus {totalHoney - neededHoney}.");
			//}
			//else if (totalHoney < neededHoney)
			//{
			//	Console.WriteLine($"Hard Winter! Honey needed {totalHoney - neededHoney}.");
			//}
		}
	}
}
