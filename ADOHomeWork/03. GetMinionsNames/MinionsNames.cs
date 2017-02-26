using System.Data.SqlClient;

namespace _03.GetMinionsNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class MinionsNames
    {
        public static SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MinionsDB;Integrated Security=True");
        static void Main()
        {
            int id = int.Parse(Console.ReadLine());
            string query = $@"SELECT v.Name, m.Name, m.Age FROM Villains as v
                              JOIN MinionsVillains as mv 
                              ON v.Id = mv.VillainId
                              JOIN Minions as m
                              ON m.Id = mv.MinionId
                              WHERE v.Id = @id";
             
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@id", id);
            Connection.Open();
            int cnt = 1;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                    return;
                }
                reader.Read();
                Console.WriteLine($"Villain: {reader[0]}");
                
            }
            Connection.Close();
            cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@id", id);
            Connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine("(No minions)");
                    return;;
                }
                while (reader.Read())
                {
                    Console.WriteLine($"{cnt++}. {reader[1]} {reader[2]}");
                }
            }
            Connection.Close();
        }
    }
}
