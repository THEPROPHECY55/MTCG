using Npgsql;
using System;

namespace MTCG.Database;

public class DbConnection
{
    private string connectionString;
    
    public DbConnection()
    {
        connectionString = "Host=localhost;Port=5432;Database=mtcgdb;Username=myuser;Password=test";
    }
    
    public void TestConnection()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection to PostgreSQL database succesful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
            }
        }
    }
}
