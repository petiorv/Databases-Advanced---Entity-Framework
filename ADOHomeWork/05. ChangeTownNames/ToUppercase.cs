using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ChangeTownNames
{
    class ToUppercase
    {
        public static SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MinionsDB;Integrated Security=True");
        static void Main()
        {
            Connection.Open();

            string countryName = Console.ReadLine();
            string getTownsForCountry = "SELECT Name FROM Towns WHERE Country = @countryName";
            SqlCommand getTownsForCountryCmd = new SqlCommand(getTownsForCountry, Connection);
            getTownsForCountryCmd.Parameters.AddWithValue("@countryName", countryName);
            SqlDataReader reader = getTownsForCountryCmd.ExecuteReader();

            List<string> townNames = new List<string>();
            using (reader)
            {
                while (reader.Read())
                {
                    townNames.Add(reader.GetString(0));
                }

                if (townNames.Count == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    Connection.Close();
                    return;
                }
            }

            string updateTownNames = $"UPDATE Towns SET Name = UPPER(Name) WHERE Country = @countryName";
            SqlCommand updateTownNamesCmd = new SqlCommand(updateTownNames, Connection);
            updateTownNamesCmd.Parameters.AddWithValue("@countryName", countryName);
            updateTownNamesCmd.ExecuteNonQuery();

            Console.WriteLine($"{townNames.Count} town names were affected.");
            Console.WriteLine($"[{string.Join(", ", townNames.Select(x => x.ToUpper()).ToList())}]");

            Connection.Close();
        }
    }
}
