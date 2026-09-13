namespace Users.Core.DTOs;

// Response sent to client after login or register
public record AuthenticationResponse(
    Guid UserId,
    string? Email,
    string? PersonName,
    string? Gender,
    string? Token,
    bool Success
    )
{
    // Default empty constructor
    public AuthenticationResponse() : this(default, default, default, default, default, default)
    {
    }
}
