using System;
using Npgsql;

namespace YungDev
{
    public class Scoreboard
    {
        private static string connectionString = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=YungDev";

        public static void DisplayScoreboard()
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string selectQuery = "SELECT * FROM scoreboard";

            using var command = new NpgsqlCommand(selectQuery, connection);

            using var reader = command.ExecuteReader();

            Console.WriteLine("Name\t\tScore\tDate");
            Console.WriteLine("--------------------------------");

                while (reader.Read())
                {
                    string name = reader["Name"].ToString();
                    int score = Convert.ToInt32(reader["Score"]);
                    DateTime date = Convert.ToDateTime(reader["Date"]);

                    Console.WriteLine($"{name}\t\t{score}\t{date.ToShortDateString()}");
                }
                Console.Clear();
            
            
        }
    }
}
