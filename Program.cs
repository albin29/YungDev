using Npgsql;
Console.WriteLine("Hello, World!");

string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=YungDev";

await using var db = NpgsqlDataSource.Create(dbUri);
Console.Clear();