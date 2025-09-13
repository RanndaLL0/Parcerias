using Npgsql;

public class DbConnectionFactory
{
    private string connectionString { get; set; }

    public DbConnectionFactory(string conn)
    {
        connectionString = conn;
    }

    public NpgsqlConnection GetDbConnection()
    {
        return new NpgsqlConnection(connectionString);
    }

}