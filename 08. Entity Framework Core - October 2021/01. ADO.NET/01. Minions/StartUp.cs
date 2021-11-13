namespace P01_Minions
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main(string[] args)
        {
            //await CreateDatabase("MinionsDB");

            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
            await connection.OpenAsync();

            //Problem 01
            //await PopulateMinionsDB(connection);

            //Problem 02
            //await PrintVillainNamesWithMoreThan3Minions(connection);

            //Problem 03
            //await PrintMinionsNamesWithVillainIdAsync(connection);

            //Problem 04
            //await AddMinionAsync(connection);

            //Problem 05
            //await ChangeTownNamesCasingAsync(connection);

            //Problem 06
            //await RemoveVillainAsync(connection);

            //Problem 07
            //await PrintAllMinionNamesAsync(connection);

            //Problem 08
            //await IncreaseMinionAgeAndCapitalizeName(connection);

            //Problem 09
            //await IncreaseMinionAgeAndCapitalizeNameProcedure(connection);
        }

        private static async Task CreateDatabaseAsync(string databaseName)
        {
            SqlConnection connection = new SqlConnection(Configuration.ConnectionStringMaster);

            await connection.OpenAsync();

            bool alreadyExists = false;

            using (SqlCommand checkDbCommand = new SqlCommand(string.Format(Queries.CheckIfDatabaseExists, databaseName), connection))
            {
                alreadyExists = checkDbCommand.ExecuteScalar() != null;
            }

            if (!alreadyExists)
            {
                SqlCommand createDbCommand = new SqlCommand(string.Format(Queries.CreateDatabase, databaseName), connection);

                await createDbCommand.ExecuteNonQueryAsync();

                Console.WriteLine("Database {0} was created.", databaseName);
            }
            else
            {
                Console.WriteLine("Database {0} has already been created.", databaseName);
            }
        }

        private static async Task PopulateMinionsDBAsync(SqlConnection connection)
        {
            await using (connection)
            {
                foreach (string create in Queries.MinionsDbCreateTables)
                {
                    SqlCommand createTableCommand = new SqlCommand(create, connection);

                    await createTableCommand.ExecuteNonQueryAsync();
                }

                foreach (string insert in Queries.MinionsDbInsertValues)
                {
                    SqlCommand insertValuesCommand = new SqlCommand(insert, connection);

                    await insertValuesCommand.ExecuteNonQueryAsync();
                }

                Console.WriteLine("Database MinionsDB was populated with data.");
            }
        }

        private static async Task PrintVillainNamesWithMoreThan3MinionsAsync(SqlConnection connection)
        {
            SqlCommand getVillainsCommand = new SqlCommand(Queries.VillainsGetWithMoreThan3Minions, connection);

            SqlDataReader villainsReader = await getVillainsCommand.ExecuteReaderAsync();

            await using (villainsReader)
            {
                while (await villainsReader.ReadAsync())
                {
                    string villainName = villainsReader.GetString(0);
                    int minionsCount = villainsReader.GetInt32(1);

                    Console.WriteLine($"{villainName} - {minionsCount}");
                }
            }
        }

        private static async Task PrintMinionsNamesWithVillainIdAsync(SqlConnection connection)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlCommand getVillainNameCommand = new SqlCommand(Queries.VillainGetNameById, connection);
            getVillainNameCommand.Parameters.AddWithValue("@id", villainId);

            object villainNameObject = await getVillainNameCommand.ExecuteScalarAsync();

            if (villainNameObject == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return;
            }

            string villainName = (string)villainNameObject;

            SqlCommand getMinionsInfoCommand = new SqlCommand(Queries.MinionsGetInfoByVillainsId, connection);
            getMinionsInfoCommand.Parameters.AddWithValue("@id", villainId);

            SqlDataReader minionsInfo = await getMinionsInfoCommand.ExecuteReaderAsync();

            await using (minionsInfo)
            {
                Console.WriteLine($"Villain: {villainName}");
                if (!minionsInfo.HasRows)
                {
                    Console.WriteLine("(no minions)");
                }
                else
                {
                    while (await minionsInfo.ReadAsync())
                    {
                        long rowNumber = minionsInfo.GetInt64(0);
                        string minionName = minionsInfo.GetString(1);
                        int minionAge = minionsInfo.GetInt32(2);

                        Console.WriteLine($"{rowNumber}. {minionName} {minionAge}");
                    }
                }
            }
        }

        private static async Task AddMinionAsync(SqlConnection connection)
        {
            Console.WriteLine("Enter minion info: ");
            string[] minionInfo = Console
                .ReadLine()?
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];

            Console.WriteLine("Enter villain info: ");
            string villainName = Console
                .ReadLine()?
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

            SqlCommand getTownIdCommand = new SqlCommand(Queries.TownsGetIdByName, connection);
            getTownIdCommand.Parameters.AddWithValue("@townName", townName);

            object townIdObject = await getTownIdCommand.ExecuteScalarAsync();

            if (townIdObject == null)
            {
                SqlCommand insertTownCommand = new SqlCommand(Queries.TownsInsertWithName, connection);
                insertTownCommand.Parameters.AddWithValue("@townName", townName);

                int rowsAffectedT = await insertTownCommand.ExecuteNonQueryAsync();
                if (rowsAffectedT == 0)
                {
                    Console.WriteLine("Problem occured while inserting new town into the database MinionsDB! Please try again later!");
                    return;
                }

                townIdObject = await getTownIdCommand.ExecuteScalarAsync();
                Console.WriteLine($"Town {townName} was added to the database.");
            }

            int townId = (int)townIdObject;

            SqlCommand getVillainIdCommand = new SqlCommand(Queries.VillainsGetIdByName, connection);
            getVillainIdCommand.Parameters.AddWithValue("@name", villainName);

            object villainIdObject = await getVillainIdCommand.ExecuteScalarAsync();

            if (villainIdObject == null)
            {
                SqlCommand insertVillainCommand = new SqlCommand(Queries.VillainsInsertWithName, connection);
                insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);

                int rowsAffectedV = await insertVillainCommand.ExecuteNonQueryAsync();
                if (rowsAffectedV == 0)
                {
                    Console.WriteLine("Problem occured while inserting new villain into the database MinionsDB! Please try again later!");
                    return;
                }

                villainIdObject = await getVillainIdCommand.ExecuteScalarAsync();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            int villainId = (int)villainIdObject;

            SqlCommand insertMinionCommand = new SqlCommand(Queries.MinionsInsertWithNameAgeTownId, connection);
            insertMinionCommand.Parameters.AddWithValue("@name", minionName);
            insertMinionCommand.Parameters.AddWithValue("@age", minionAge);
            insertMinionCommand.Parameters.AddWithValue("@townId", townId);

            int rowsAffectedM = await insertMinionCommand.ExecuteNonQueryAsync();
            if (rowsAffectedM == 0)
            {
                Console.WriteLine("Problem occured while inserting new minion into the database MinionsDB! Please try again later!");
                return;
            }

            SqlCommand getMinionIdCommand = new SqlCommand(Queries.MinionsGetIdByName, connection);
            getMinionIdCommand.Parameters.AddWithValue("@name", minionName);

            int minionId = (int)await getMinionIdCommand.ExecuteScalarAsync();

            SqlCommand insertMinionVillainCommand = new SqlCommand(Queries.MinionsVilliansInsertPair, connection);
            insertMinionVillainCommand.Parameters.AddWithValue("@villainId", villainId);
            insertMinionVillainCommand.Parameters.AddWithValue("@minionId", minionId);

            int rowsAffectedMV = await insertMinionVillainCommand.ExecuteNonQueryAsync();
            if (rowsAffectedMV == 0)
            {
                Console.WriteLine("Problem occured while inserting new minion under the control of the given villain! Please try again later!");
                return;
            }

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static async Task ChangeTownNamesCasingAsync(SqlConnection connection)
        {
            string countryName = Console.ReadLine();

            SqlCommand updateNamesCommand = new SqlCommand(Queries.TownsUpdateNamesToUpperByCountryName, connection);
            updateNamesCommand.Parameters.AddWithValue("@countryName", countryName);

            int rowsAffected = await updateNamesCommand.ExecuteNonQueryAsync();

            if (rowsAffected == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            SqlCommand getTownNamesCommand = new SqlCommand(Queries.TownsGetNamesByCountryName, connection);
            getTownNamesCommand.Parameters.AddWithValue("@countryName", countryName);

            SqlDataReader townNames = await getTownNamesCommand.ExecuteReaderAsync();

            List<string> updatedTownNames = new List<string>();

            await using (townNames)
            {
                while (await townNames.ReadAsync())
                {
                    updatedTownNames.Add(townNames.GetString(0));
                }
            }

            Console.WriteLine($"{updatedTownNames.Count} town names were affected.");
            Console.WriteLine($"[{string.Join(", ", updatedTownNames)}]");
        }

        private static async Task RemoveVillainAsync(SqlConnection connection)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlCommand getVillainNameCommand = new SqlCommand(Queries.VillainGetNameById, connection);
            getVillainNameCommand.Parameters.AddWithValue("@id", villainId);

            object villainNameObject = await getVillainNameCommand.ExecuteScalarAsync();

            if (villainNameObject == null)
            {
                Console.WriteLine($"No such villain was found.");
                return;
            }

            string villainName = (string)villainNameObject;

            SqlCommand deleteVillainFromMappingTableCommand = new SqlCommand(Queries.MinionsVillainsDeletePairByVillianId, connection);
            deleteVillainFromMappingTableCommand.Parameters.AddWithValue("@villainId", villainId);

            int rowsAffected = await deleteVillainFromMappingTableCommand.ExecuteNonQueryAsync();

            SqlCommand deleteVillainCommand = new SqlCommand(Queries.VillainsDeleteById, connection);
            deleteVillainCommand.Parameters.AddWithValue("@villainId", villainId);

            await deleteVillainCommand.ExecuteNonQueryAsync();

            Console.WriteLine($"{villainName} was deleted.");
            Console.WriteLine($"{rowsAffected} minions were released.");
        }

        private static async Task PrintAllMinionNamesAsync(SqlConnection connection)
        {
            List<string> sortedMinionNames = new List<string>();

            SqlCommand getMinionNamesCommand = new SqlCommand(Queries.MinionsGetNames, connection);

            SqlDataReader minionNamesReader = await getMinionNamesCommand.ExecuteReaderAsync();

            await using (minionNamesReader)
            {
                while (await minionNamesReader.ReadAsync())
                {
                    sortedMinionNames.Add(minionNamesReader.GetString(0));
                }
            }

            sortedMinionNames = SortArrayZigZag(sortedMinionNames);
            
            Console.WriteLine(string.Join(Environment.NewLine, sortedMinionNames));
        }

        public static List<string> SortArrayZigZag(List<string> names)
        {
            List<string> result = new List<string>();

            for (int i = 0; names.Any(); i++)
            {
                if (i % 2 == 0)
                {
                    result.Add(names[0]);
                    names.RemoveAt(0);
                }
                else
                {
                    result.Add(names[names.Count - 1]);
                    names.RemoveAt(names.Count - 1);
                }
            }

            return result;
        }

        private static async Task IncreaseMinionAgeAndCapitalizeName(SqlConnection connection)
        {
            List<string> minionsNamesAges = new List<string>();

            int[] minionIds = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SqlCommand updateMinionNameAgeCommand = new SqlCommand(Queries.MinionsUpdateNameToUpperAndIncreaseAgeById, connection);

            foreach (int minionId in minionIds)
            {
                SqlParameter minionIdParameter = new SqlParameter("@id", minionId);

                updateMinionNameAgeCommand.Parameters.Add(minionIdParameter);
                await updateMinionNameAgeCommand.ExecuteNonQueryAsync();
                updateMinionNameAgeCommand.Parameters.Remove(minionIdParameter);
            }

            SqlCommand getMinionsNamesAgesCommand = new SqlCommand(Queries.MinionsGetNamesAges, connection);

            SqlDataReader minionsNamesAgesReader = await getMinionsNamesAgesCommand.ExecuteReaderAsync();

            await using (minionsNamesAgesReader)
            {
                while (await minionsNamesAgesReader.ReadAsync())
                {
                    minionsNamesAges.Add($"{minionsNamesAgesReader.GetString(0)} {minionsNamesAgesReader.GetInt32(1)}");
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, minionsNamesAges));
        }

        private static async Task IncreaseMinionAgeAndCapitalizeNameProcedure(SqlConnection connection)
        {
            string minionNameAge = string.Empty;

            int minionId = int.Parse(Console.ReadLine());

            SqlCommand createProcedureGetOlder = new SqlCommand(Queries.CreateProcedureGetOlder, connection);

            await createProcedureGetOlder.ExecuteNonQueryAsync();

            SqlCommand executeProcedureGetOlder = new SqlCommand(Queries.ExecuteProcedureUspGetOlder, connection);
            executeProcedureGetOlder.Parameters.AddWithValue("@id", minionId);

            await executeProcedureGetOlder.ExecuteNonQueryAsync();

            SqlCommand getMinionNameCommand = new SqlCommand(Queries.MinionsGetNameAgeById, connection);
            getMinionNameCommand.Parameters.AddWithValue("@id", minionId);

            SqlDataReader minionNameAgeReader = await getMinionNameCommand.ExecuteReaderAsync();

            await using (minionNameAgeReader)
            {
                while (await minionNameAgeReader.ReadAsync())
                {
                    minionNameAge = $"{minionNameAgeReader.GetString(0)} - {minionNameAgeReader.GetInt32(1)} years old";
                }
            }

            Console.WriteLine(minionNameAge);
        }
    }
}