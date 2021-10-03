﻿using System;
using System.Linq;
using _01._Logger.Appenders;
using _01._Logger.Core.Factories;
using _01._Logger.Core.IO;
using _01._Logger.Enums;
using _01._Logger.Layouts;
using _01._Logger.Loggers;

namespace _01._Logger.Core
{
    class Engine : IEngine
    {
        private readonly IAppenderFactory appenderFactory;
        private readonly ILayoutFactory layoutFactory;
        private readonly IReader reader;
        private readonly IWriter writer;

        private ILogger logger;

        public Engine(IAppenderFactory appenderFactory, ILayoutFactory layoutFactory, IReader reader, IWriter writer)
        {
            this.appenderFactory = appenderFactory;
            this.layoutFactory = layoutFactory;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int n = int.Parse(this.reader.ReadLine());

            IAppender[] appenders = this.ReadAppenders(appenderFactory, layoutFactory, n);

            this.logger = new Logger(appenders);

            string input;
            while ((input = this.reader.ReadLine()) != "END")
            {
                string[] parts = input.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(parts[0], true);
                string date = parts[1];
                string message = parts[2];

                ProcessCommand(reportLevel, date, message);
            }

            this.writer.WriteLine(logger.ToString());
        }

        private void ProcessCommand(ReportLevel reportLevel, string date, string message)
        {
            if (reportLevel == ReportLevel.Info)
            {
                this.logger.Info(date, message);
            }
            else if (reportLevel == ReportLevel.Warning)
            {
                this.logger.Warning(date, message);
            }
            else if (reportLevel == ReportLevel.Error)
            {
                this.logger.Error(date, message);
            }
            else if (reportLevel == ReportLevel.Critical)
            {
                this.logger.Critical(date, message);
            }
            else if (reportLevel == ReportLevel.Fatal)
            {
                this.logger.Fatal(date, message);
            }
        }

        private IAppender[] ReadAppenders(IAppenderFactory appenderFactory, ILayoutFactory layoutFactory, int n)
        {
            IAppender[] appenders = new IAppender[n];

            for (int i = 0; i < n; i++)
            {
                string[] appenderParts = this.reader.ReadLine().Split();

                string appenderType = appenderParts[0];
                string layoutType = appenderParts[1];
                ReportLevel reportLevel = appenderParts.Length == 3
                    ? Enum.Parse<ReportLevel>(appenderParts[2], true)
                    : ReportLevel.Info;

                try
                {
                    ILayout layout = this.layoutFactory.CreateLayout(layoutType);

                    IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout, reportLevel);

                    appenders[i] = appender;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return appenders;
        }
    }
}
