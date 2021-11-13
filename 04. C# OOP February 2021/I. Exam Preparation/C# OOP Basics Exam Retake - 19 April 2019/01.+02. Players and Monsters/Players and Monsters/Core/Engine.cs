namespace PlayersAndMonsters.Core
{
    using System;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private IManagerController managerController;
        private IReader reader;
        private IWriter writer;

        public Engine(IManagerController managerController, IReader reader, IWriter writer)
        {
            this.managerController = managerController;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            bool isFinished = false;
            do
            {
                try
                {
                    ProcessCommands();
                    isFinished = true;
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }

            } while (!isFinished);
        }

        private void ProcessCommands()
        {
            string input;
            while ((input = this.reader.ReadLine()) != "Exit")
            {
                string[] parts = input.Split();

                string command = parts[0];

                if (command == "AddPlayer")
                {
                    string type = parts[1];
                    string userName = parts[2];

                    this.writer.WriteLine(managerController.AddPlayer(type, userName));
                }
                if (command == "AddCard")
                {
                    string type = parts[1];
                    string cardName = parts[2];

                    this.writer.WriteLine(managerController.AddCard(type, cardName));
                }
                if (command == "AddPlayerCard")
                {
                    string playerName = parts[1];
                    string cardName = parts[2];

                    this.writer.WriteLine(managerController.AddPlayerCard(playerName, cardName));
                }
                if (command == "Fight")
                {
                    string attackerName = parts[1];
                    string enemyName = parts[2];

                    this.writer.WriteLine(managerController.Fight(attackerName, enemyName));
                }
                if (command == "Report")
                {
                    this.writer.WriteLine(managerController.Report());
                }
            }
        }
    }
}
