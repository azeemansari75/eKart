using Users.Core.Entities;

namespace Users.Core.Repositories;

// Interface for user database operations
public interface IUserRepository
{
    Task<ApplicationUser?> AddUser(ApplicationUser user);

    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);

    Task<bool> DeleteUser(Guid userId);
}
