using Dapper;
using Users.Core.Entities;
using Users.Core.Repositories;
using Users.Infrastructure.DbContext;

namespace Users.Infrastructure.Implementations;

// Repository implementation for user database operations using Dapper
public class UserRepository : IUserRepository
{
    private readonly DapperDbContext _dbContext;

    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Insert new user into database
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        if (user.UserId == Guid.Empty)
        {
            user.UserId = Guid.NewGuid();
        }

        const string query = """
            INSERT INTO public."Users" ("UserId", "Email", "PasswordHash", "PersonName", "Gender")
            VALUES (@UserId, @Email, @PasswordHash, @PersonName, @Gender);
            """;

        using var connection = _dbContext.CreateConnection();
        var rowsAffected = await connection.ExecuteAsync(query, user);

        if (rowsAffected > 0)
        {
            return user;
        }

        return null;
    }

    // Get user by email and password
    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        const string query = """
            SELECT * FROM public."Users"
            WHERE "Email" = @Email AND "PasswordHash" = @Password;
            """;

        using var connection = _dbContext.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { Email = email, Password = password });
    }

    // Delete user by UserId
    public async Task<bool> DeleteUser(Guid userId)
    {
        const string query = """
            DELETE FROM public."Users"
            WHERE "UserId" = @UserId;
            """;

        using var connection = _dbContext.CreateConnection();
        var rowsAffected = await connection.ExecuteAsync(query, new { UserId = userId });

        return rowsAffected > 0;
    }
}
