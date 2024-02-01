using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


/*


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
*/