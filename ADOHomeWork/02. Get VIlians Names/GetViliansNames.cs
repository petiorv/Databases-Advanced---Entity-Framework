namespace _02.Get_VIlians_Names
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class GetViliansNames
    {
        public static SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MinionsDB;Integrated Security=True");
        static void Main()
        {
            string query = @"SELECT v.Name, COUNT(mv.MinionId) as c FROM Villains as V
                             JOIN MinionsVillains as mv 
                             ON v.Id = mv.MinionId
                             GROUP BY v.Name
                             HAVING COUNT(MinionId) > 3
                             ORDER BY c DESC";
            SqlCommand cmd = new SqlCommand(query, Connection);
            Connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]}");
                }        
            }
        }
    }
}
