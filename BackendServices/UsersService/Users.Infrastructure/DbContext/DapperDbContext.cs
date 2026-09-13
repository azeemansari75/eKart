using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Users.Infrastructure.DbContext;

// Database context for Dapper using PostgreSQL
public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;

        // Read connection string from appsettings.json
        _connectionString = _configuration.GetConnectionString("PostgresConnection")!;
    }

    // Creates a new database connection
    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
}