using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyList = new Dictionary<string, List<string>>();
            List<string> employeeIDList = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" -> ").ToArray();

                string companyName = command[0];
                string employeeID = command[1];

                if (!companyList.ContainsKey(companyName)) 
                {
                    employeeIDList = new List<string>();
                    employeeIDList.Add(employeeID);
                    companyList[companyName] = employeeIDList;
                }
                else if (companyList.ContainsKey(companyName)) 
                {
                    if (!companyList[companyName].Contains(employeeID)) 
                    {
                        companyList[companyName].Add(employeeID);
                    }
                }
            }

            Dictionary<string, List<string>> orderedCompanyList = SortList(companyList);

            PrintList(orderedCompanyList);
        }

        private static Dictionary<string, List<string>> SortList(Dictionary<string, List<string>> companyList)
        {
            return companyList
                .OrderBy(a => a.Key)
                .ToDictionary(a => a.Key, b => b.Value);
        }

        private static void PrintList(Dictionary<string, List<string>> orderedCompanyList)
        {
            foreach (KeyValuePair<string, List<string>> keyValuePair in orderedCompanyList)
            {
                string companyName = keyValuePair.Key;

                Console.WriteLine($"{companyName}");

                foreach (string employeeID in keyValuePair.Value)
                {
                    Console.WriteLine($"-- {employeeID}");
                }
            }
        }
    }
}
