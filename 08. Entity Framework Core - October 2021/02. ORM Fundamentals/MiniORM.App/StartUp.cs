namespace MiniORM.App
{
    using System.Linq;

    using MiniORM.App.Data;
    using MiniORM.App.Data.Entities;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=PC\SQLEXPRESS;Database=MiniORM;Integrated Security=True";

            SoftUniDbContext context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "John",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            Employee employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
