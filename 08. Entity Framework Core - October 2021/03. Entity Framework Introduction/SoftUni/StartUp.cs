namespace SoftUni
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using SoftUni.Data;
    using SoftUni.Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            string result = string.Empty;
            //result = GetEmployeesFullInformation(context);
            //result = GetEmployeesWithSalaryOver50000(context);
            //result = GetEmployeesFromResearchAndDevelopment(context);
            //result = AddNewAddressToEmployee(context);
            //result = GetEmployeesInPeriod(context);
            //result = GetAddressesByTown(context);
            //result = GetEmployee147(context);
            //result = GetDepartmentsWithMoreThan5Employees(context);
            //result = GetLatestProjects(context);
            //result = IncreaseSalaries(context);
            //result = GetEmployeesByFirstNameStartingWithSa(context);
            //result = DeleteProjectById(context);
            //result = RemoveTown(context);

            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - {e.Salary:f2}");
            }

            return result.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(newAddress);

            Employee nakovEmployee = context
                .Employees
                .First(e => e.LastName == "Nakov");
            nakovEmployee.Address = newAddress;

            context.SaveChanges();

            StringBuilder result = new StringBuilder();

            var addresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .Take(10)
                .ToArray();

            foreach (var a in addresses)
            {
                result.AppendLine(a.AddressText);
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects.All(ep =>
                    ep.Project.StartDate.Year >= 2001 &&
                    ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Manager = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e
                        .EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture).Trim(),
                            EndDate = ep.Project.EndDate.HasValue
                                ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture).Trim()
                                : "not finished"
                        })
                        .ToArray()
                })
                .Take(10)
                .ToArray();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.Manager}");
                foreach (var p in e.Projects)
                {
                    result.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return result.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var addresses = context
                .Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .ToArray();

            foreach (var a in addresses)
            {
                result.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employee = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e
                        .EmployeesProjects
                        .OrderBy(ep => ep.Project.Name)
                        .Select(ep => new
                        {
                            ep.Project.Name
                        })
                        .ToArray()
                })
                .SingleOrDefault();

            result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var p in employee.Projects)
            {
                result.AppendLine(p.Name);
            }

            return result.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    Manager = $"{d.Manager.FirstName} {d.Manager.LastName}",
                    Employees = d
                        .Employees
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle
                        })
                        .ToArray()
                })
                .ToArray();

            foreach (var d in departments)
            {
                result.AppendLine($"{d.DepartmentName} - {d.Manager}");
                foreach (var e in d.Employees)
                {
                    result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return result.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture).Trim()
                })
                .ToArray();

            foreach (var p in projects)
            {
                result.AppendLine($"{p.Name}");
                result.AppendLine($"{p.Description}");
                result.AppendLine($"{p.StartDate}");
            }

            return result.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employeesToIncreaseSalary = context
                .Employees
                .Where(e => e.Department.Name == "Engineering"
                    || e.Department.Name == "Tool Design"
                    || e.Department.Name == "Marketing"
                    || e.Department.Name == "Information Services");

            foreach (var e in employeesToIncreaseSalary)
            {
                e.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employees = employeesToIncreaseSalary
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .ToArray();

            StringBuilder result = new StringBuilder();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return result.ToString().Trim();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToDelete = context
                .Projects
                .Single(p => p.ProjectId == 2);

            var employeesWorkingOnProjectToDelete = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == projectToDelete.ProjectId);

            context.EmployeesProjects.RemoveRange(employeesWorkingOnProjectToDelete);

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            StringBuilder result = new StringBuilder();

            var projects = context
                .Projects
                .Take(10)
                .Select(p => new { p.Name })
                .ToArray();

            foreach (var p in projects)
            {
                result.AppendLine(p.Name);
            }

            return result.ToString().Trim();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            string result = "{0} addresses in Seattle were deleted";

            var townToDelete = context
                .Towns
                .Single(t => t.Name == "Seattle");

            var addressesInTownToDelete = context
                .Addresses
                .Where(a => a.TownId == townToDelete.TownId);

            var employeesLivingInTown = context
                .Employees
                .Where(e => addressesInTownToDelete.Contains(e.Address));

            foreach (var e in employeesLivingInTown)
            {
                e.AddressId = null;
            }

            int addressesCount = addressesInTownToDelete.Count();

            context.Addresses.RemoveRange(addressesInTownToDelete);

            context.Towns.Remove(townToDelete);

            context.SaveChanges();

            return string.Format(result, addressesCount);
        }
    }
}
