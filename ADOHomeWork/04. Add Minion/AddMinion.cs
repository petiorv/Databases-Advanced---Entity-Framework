

namespace _04.Add_Minion
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class AddMinion
    {
        public static SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MinionsDB;Integrated Security=True");
        static void Main()
        {
            try
            {
                string[] minionInfo = Console.ReadLine().Split(':')[1].Trim().Split(' ');
                string newMinionName = minionInfo[0];
                int newMinionAge = int.Parse(minionInfo[1]);
                string newMinionTown = minionInfo[2];
                string villainName = Console.ReadLine().Split(':')[1].Trim();

                Connection.Open();

                string townIdFromDb = GetTownIdByName(newMinionTown);
                if (string.IsNullOrEmpty(townIdFromDb))
                {
                    if (InsertTown(newMinionTown) > 0)
                    {
                        Console.WriteLine($"Town {newMinionTown} was added to the database.");
                        townIdFromDb = GetTownIdByName(newMinionTown);
                    }
                }

                string villainIdFromDb = GetVillainIdByName(villainName);
                if (string.IsNullOrEmpty(villainIdFromDb))
                {
                    if (InsertVillain(villainName) > 0)
                    {
                        Console.WriteLine($"Villain {villainName} was added to the database.");
                        villainIdFromDb = GetVillainIdByName(villainName);
                    }
                }

                if (InsertMinion(newMinionName, newMinionAge, int.Parse(townIdFromDb)) > 0)
                {
                    if (InsertVillainMinion(villainName, newMinionName) > 0)
                    {
                        Console.WriteLine($"Successfully added {newMinionName} to be minion of {villainName}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        public static int InsertVillainMinion(string villainName, string minionName)
        {
            string villainId = GetVillainIdByName(villainName);
            string minionId = GetMinionIdByName(minionName);

            if (string.IsNullOrEmpty(villainId) || string.IsNullOrEmpty(minionId))
            {
                return 0;
            }

            string insertMinionsVillain = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
            SqlCommand insertMinionsVillainCmd = new SqlCommand(insertMinionsVillain, Connection);
            insertMinionsVillainCmd.Parameters.AddWithValue("@minionId", minionId);
            insertMinionsVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            return insertMinionsVillainCmd.ExecuteNonQuery();
        }

        public static string GetMinionIdByName(string minionName)
        {
            string getMinionId = "SELECT TOP 1 Id FROM Minions WHERE Name = @minionName";
            SqlCommand getMinionIdCmd = new SqlCommand(getMinionId, Connection);
            getMinionIdCmd.Parameters.AddWithValue("@minionName", minionName);

            object result = getMinionIdCmd.ExecuteScalar();

            if (result == null)
            {
                return null;
            }

            return result.ToString();
        }

        public static int InsertVillain(string villainName)
        {
            string insertVillain = "INSERT INTO Villains (Name, EvilnessFactor) VALUES(@villainName, 'evil')";
            SqlCommand insertVillainCmd = new SqlCommand(insertVillain, Connection);
            insertVillainCmd.Parameters.AddWithValue("@villainName", villainName);
            return insertVillainCmd.ExecuteNonQuery();
        }

        public static string GetVillainIdByName(string villainName)
        {
            string getVillain = "SELECT TOP 1 Id FROM Villains WHERE Name = @villainName";
            SqlCommand getVillainCmd = new SqlCommand(getVillain, Connection);
            getVillainCmd.Parameters.AddWithValue("@villainName", villainName);

            object result = getVillainCmd.ExecuteScalar();

            if (result == null)
            {
                return null;
            }

            return result.ToString();
        }

        public static int InsertTown(string newMinionTown)
        {
            string insertTown = "INSERT INTO Towns (Name) VALUES(@newTownName)";
            SqlCommand insertTownCmd = new SqlCommand(insertTown, Connection);
            insertTownCmd.Parameters.AddWithValue("@newTownName", newMinionTown);
            return insertTownCmd.ExecuteNonQuery();
        }

        public static string GetTownIdByName(string townName)
        {
            string getTownByName = "SELECT TOP 1 Id FROM Towns WHERE Name = @targetTownName";
            SqlCommand getTownByNameCmd = new SqlCommand(getTownByName, Connection);
            getTownByNameCmd.Parameters.AddWithValue("@targetTownName", townName);

            object result = getTownByNameCmd.ExecuteScalar();

            if (result == null)
            {
                return null;
            }

            return result.ToString();
        }

        public static int InsertMinion(string name, int age, int townId)
        {
            string insertTown = "INSERT INTO Minions (Name, Age, TownId) VALUES(@name, @age, @townId)";
            SqlCommand insertTownCmd = new SqlCommand(insertTown, Connection);
            insertTownCmd.Parameters.AddWithValue("@name", name);
            insertTownCmd.Parameters.AddWithValue("@age", age);
            insertTownCmd.Parameters.AddWithValue("@townId", townId);
            return insertTownCmd.ExecuteNonQuery();
        }
    }
}

