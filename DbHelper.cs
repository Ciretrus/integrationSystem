using Npgsql;

public static class DbHelper
{
    // Замени данные на свои (server, port, database, userId, password)
    private static string connString = "Host=localhost;Username=postgres;Password=1234;Database=postgres";

    public static NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connString);
    }
}