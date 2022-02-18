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
		}
	}
}
