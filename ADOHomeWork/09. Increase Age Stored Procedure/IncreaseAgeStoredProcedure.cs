namespace _09.Increase_Age_Stored_Procedure
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class IncreaseAgeStoredProcedure
    {
        public static SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MinionsDB;Integrated Security=True");
        static void Main()
        {
            try
            {
                string minionId = Console.ReadLine();

                Connection.Open();
                string increaseAgeStoredProcedure = "EXEC dbo.usp_GetOlder @minionId";
                SqlCommand increaseAgeStoredProcedureCmd =
                    new SqlCommand(increaseAgeStoredProcedure, Connection);
                increaseAgeStoredProcedureCmd.Parameters.AddWithValue("@minionId", minionId);
                SqlDataReader reader = increaseAgeStoredProcedureCmd.ExecuteReader();

                using (reader)
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                        return;
                    }
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
    }
}

