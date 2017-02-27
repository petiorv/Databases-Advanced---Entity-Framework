using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Minions_Names
{
    class MinionNames
    {
        public static SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MinionsDB;Integrated Security=True");
        static void Main()
        {
            try
            {
                Connection.Open();

                var allMinionNames = GetAllMinionNames();

                bool isFirst = true;
                int first = 0;
                int last = allMinionNames.Count - 1;
                for (int i = 0; i < allMinionNames.Count; i++)
                {
                    if (isFirst)
                    {
                        Console.WriteLine(allMinionNames[first++]);
                    }
                    else
                    {
                        Console.WriteLine(allMinionNames[last--]);
                    }

                    isFirst = !isFirst;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            finally
            {
                Connection.Close();
            }
        }

        public static List<string> GetAllMinionNames()
        {
            var resultList = new List<string>();
            string getAllMinionNames = "SELECT Name FROM Minions";
            SqlCommand getAllMinionNamesCmd = new SqlCommand(getAllMinionNames, Connection);
            SqlDataReader reader = getAllMinionNamesCmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    resultList.Add(reader["Name"].ToString());
                }
            }

            return resultList;
        }
    }
}
