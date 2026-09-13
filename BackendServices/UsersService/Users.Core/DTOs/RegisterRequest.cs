namespace Users.Core.DTOs;

// Request body for registering a new user
public record RegisterRequest(
    string? Email, 
    string? Password, 
    string? PersonName, 
    GenderOptions Gender
);
