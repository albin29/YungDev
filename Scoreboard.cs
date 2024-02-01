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

            string selectQuery = "SELECT * FROM scoreboard";

            using var command = new NpgsqlCommand(selectQuery, connection);

            using var reader = command.ExecuteReader();

            Console.WriteLine("Name\t\t\tScore\tDate");
            Console.WriteLine("-----------------------------------------");

            while (reader.Read())
            {
                
                string name = reader["Name"].ToString();
                int score = Convert.ToInt32(reader["Score"]);
                DateTime date = Convert.ToDateTime(reader["Date"]);

                Console.WriteLine($"{name}\t\t{score}\t{date.ToShortDateString()}");
            }
            
        }

public static void TopThree()
{
    using var connection = new NpgsqlConnection(connectionString);
    connection.Open();

    string query = "SELECT Name, Score, Date FROM scoreboard ORDER BY Score DESC LIMIT 3";

    using var command = new NpgsqlCommand(query, connection);

    using var reader = command.ExecuteReader();

    List<string> results = new List<string>();

    while (reader.Read())
    {
        string name = reader["Name"].ToString();
        int score = Convert.ToInt32(reader["Score"]);
        DateTime date = Convert.ToDateTime(reader["Date"]);

        string result = $"{name}\t\t{score}\t{date.ToShortDateString()}";
        results.Add(result);
    }

    // Now, you can iterate through the results and print them out
    foreach (var result in results)
    {
        Console.WriteLine(result);
    }
}

    }
}
