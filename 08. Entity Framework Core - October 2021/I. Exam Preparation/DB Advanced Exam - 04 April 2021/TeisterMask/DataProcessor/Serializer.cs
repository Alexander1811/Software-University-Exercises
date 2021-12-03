namespace TeisterMask.DataProcessor
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;

    using Formatting = Newtonsoft.Json.Formatting;
    using TeisterMask.DataProcessor.ExportDto;
    using System.IO;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder result = new StringBuilder();

            var projects = context.Projects
                .Where(p => p.Tasks.Any());

            var exportProjects = projects
                .ToArray()
                .Select(p => new ExportProjectWithTasksDto
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate != null ? "Yes" : "No",
                    Tasks = p.Tasks
                        .ToArray()
                        .OrderBy(t => t.Name)
                        .Select(t => new ExportTaskDto
                        {
                            Name = t.Name,
                            Label = t.LabelType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            XmlSerializer serializer = GetSerializer("Projects", typeof(ExportProjectWithTasksDto[]));
            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, exportProjects, GetSerializerNamespaces());
            }

            return result.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date));

            var exportEmployees = employees
                .ToArray()
                .Select(e => new
                {
                    e.Username,
                    Tasks = e.EmployeesTasks.Select(et => et.Task)
                        .Where(t => t.OpenDate >= date)
                        .OrderByDescending(t => t.DueDate)
                        .ThenBy(t => t.Name)
                        .Select(t => new
                        {
                            TaskName = t.Name,
                            OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = t.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = t.LabelType.ToString(),
                            ExecutionType = t.ExecutionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Count())
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            JsonSerializerSettings settings = GetSerializerSettings();

            var result = JsonConvert.SerializeObject(exportEmployees, settings);

            return result.TrimEnd();
        }
        private static XmlSerializer GetSerializer(string rootName, Type dtoType)
        {
            return new XmlSerializer(dtoType, new XmlRootAttribute(rootName));
        }

        private static XmlSerializerNamespaces GetSerializerNamespaces()
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            return namespaces;
        }

        private static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }
    }
}