namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();

            XmlSerializer serializer = GetSerializer("Projects", typeof(ImportProjectDto[]));

            using StringReader reader = new StringReader(xmlString);

            var importProjects = (ImportProjectDto[]) serializer.Deserialize(reader);

            var mappedProjects = new List<Project>();
            foreach (var p in importProjects)
            {
                if (!IsValid(p))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidProjectOpenDate = DateTime.TryParseExact(p.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime projectOpenDate);
                if (!isValidProjectOpenDate)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? projectDueDate = null;
                if (!string.IsNullOrWhiteSpace(p.DueDate))
                {
                    bool isValidProjectDueDate = DateTime.TryParseExact(p.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime projectDueDateValue);

                    if (!isValidProjectDueDate)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    projectDueDate = projectDueDateValue;
                }

                Project project = new Project()
                {
                    Name = p.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };

                var mappedTasks = new List<Task>();
                foreach (var t in p.Tasks)
                {
                    if (!IsValid(t))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isValidTaskOpenDate = DateTime.TryParseExact(t.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);
                    if (!isValidTaskOpenDate)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isValidTaskDueDate = DateTime.TryParseExact(t.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);
                    if (!isValidTaskOpenDate)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < projectOpenDate)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (projectDueDate != null && taskDueDate > projectDueDate)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task()
                    {
                        Name = t.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType) t.ExecutionType,
                        LabelType = (LabelType) t.LabelType
                    };

                    mappedTasks.Add(task);
                }

                project.Tasks = mappedTasks;

                mappedProjects.Add(project);

                result.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(mappedProjects);

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();

            var importEmployees = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var mappedEmployees = new List<Employee>();
            foreach (var e in importEmployees)
            {
                if (!IsValid(e))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee()
                {
                    Username = e.Username,
                    Email = e.Email,
                    Phone = e.Phone
                };

                var mappedEmployeeTasks = new List<EmployeeTask>();
                foreach (var taskId in e.Tasks.Distinct())
                {
                    Task task = context.Tasks
                        .Find(taskId);

                    if (task == null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask()
                    {
                        Employee = employee,
                        Task = task
                    };

                    mappedEmployeeTasks.Add(employeeTask);
                }

                employee.EmployeesTasks = mappedEmployeeTasks;

                mappedEmployees.Add(employee);

                result.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(mappedEmployees);
            
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static XmlSerializer GetSerializer(string rootName, Type dtoType)
        {
            return new XmlSerializer(dtoType, new XmlRootAttribute(rootName));
        }
    }
}