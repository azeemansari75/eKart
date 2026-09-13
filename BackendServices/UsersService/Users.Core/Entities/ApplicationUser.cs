namespace Users.Core.Entities;

// User model for database table "Users"
public class ApplicationUser
{
    public Guid UserId { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? PersonName { get; set; }

    public string? Gender { get; set; }
}
