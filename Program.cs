using Microsoft.Win32;
using Npgsql;
using YungDev;
Console.WriteLine("Hello, World!");

string dbUri = "Host=localhost;Port=5455;Username=postgres;Password=postgres;Database=YungDev";

await using var db = NpgsqlDataSource.Create(dbUri);
Console.Clear();
await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS player CASCADE"))
{
    await cmd.ExecuteNonQueryAsync();
}


await using (var cmd = db.CreateCommand("DROP TABLE IF EXISTS player_stats CASCADE"))
{
    await cmd.ExecuteNonQueryAsync();
}



string player = @"create table if not exists player(
                id serial primary key,
                name text,
                password text
)";

await using (var cmd = db.CreateCommand(player))
{
    await cmd.ExecuteNonQueryAsync();
}


string playerStats = @"create table if not exists player_stats(
                       player_id integer references player(id),
                       current_day int,
                       programming_skill int,
                       math_skill int,
                       money int,
                       stamina int,
                       score int
)";

await using (var cmd = db.CreateCommand(playerStats))
{
    await cmd.ExecuteNonQueryAsync();
}

string highscore = @"CREATE TABLE IF NOT EXISTS highscores AS
                     SELECT
                     p.name AS player_name,
                     ps.current_day,
                     ps.score
                     FROM
                     player_stats ps
                     JOIN
                     player p ON ps.player_id = p.id;";

await using (var cmd = db.CreateCommand(highscore))
{
    await cmd.ExecuteNonQueryAsync();
}

/*
Menu menu = Menu.Main;


while (true)
{
    if (menu.Equals(Menu.Main))
    {
        Console.Clear();
        Console.WriteLine("=============================================");
        Console.WriteLine("              Welcome to YungDev");
        Console.WriteLine("=============================================");
        Console.WriteLine("Please choose from the options below:");
        Console.WriteLine("=============================================");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register");
        Console.WriteLine("3. Check Leaderbord");
        Console.WriteLine("4. Exit");
        Console.WriteLine("=============================================");
    }

    if (menu.Equals(Menu.Main))
    {
        string? input = Console.ReadLine();
        switch (input)
        {
            case "1":
                menu = Menu.Login;
                break;
            case "2":
                menu = Menu.Register;
                break;
            case "3":
                menu = Menu.Scoreboard;
                break;
            case "4":
                menu = Menu.Exit;
                break;
            default:
                Console.Clear();
                Console.WriteLine("You didn't pick a valid option.");
                Console.WriteLine("Please press enter to break!");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    }

    if (menu.Equals(Menu.Login))
    {
        Console.Clear();
        Console.WriteLine("Welcome to our login page.\n");
        Login.Page();
        menu = Menu.Main;
    }

    if (menu.Equals(Menu.Register))
    {
        Console.Clear();
        Console.WriteLine("Welcome to our register page.\n");
        Console.WriteLine("Do you want to: ");
        Console.WriteLine("1. Register");
        Console.WriteLine("2. Return to main page");
        switch (Console.ReadLine())
        {
            case "1":
                Register.Customer();
                break;
            case "2":
                menu = Menu.Main;
                break;
            default:
                Console.Clear();
                Console.WriteLine("You didn't pick a valid option.");
                Console.WriteLine("Please press enter to continue!");
                Console.ReadKey();
                break;
        }
    }

    if (menu.Equals(Menu.Scoreboard))
    {
        Scoreboard.DisplayScoreboard();
    }

        if (menu.Equals(Menu.Exit))
    {
        Console.Clear();
        Console.WriteLine("Thank you for shopping at WebShop1. Please come again!");
        break;
    }
}
*/