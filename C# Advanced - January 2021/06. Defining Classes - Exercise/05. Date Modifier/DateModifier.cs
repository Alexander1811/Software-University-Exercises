using System;
using System.Linq;

namespace _05._Data_Modifier
{
    public class DateModifier
    {
        private string firstDate;
        private string secondDate;
        
        public int CalculateDifference(string firstDate, string secondDate)
        {
            int[] firstDateArgs = firstDate.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            DateTime dateTime1 = new DateTime(firstDateArgs[0], firstDateArgs[1], firstDateArgs[2]);

            int[] secondDateArgs = secondDate.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            DateTime dateTime2 = new DateTime(secondDateArgs[0], secondDateArgs[1], secondDateArgs[2]);

            return Math.Abs((dateTime1 - dateTime2).Days);
        }
    }
}
