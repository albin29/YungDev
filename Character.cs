using Npgsql;
namespace YungDev;

public class Character
{
    private readonly NpgsqlDataSource _db;

    public Character(NpgsqlDataSource db) 
    {
        _db = db;

    }




}
