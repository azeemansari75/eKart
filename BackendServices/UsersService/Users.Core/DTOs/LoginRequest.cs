namespace Users.Core.DTOs;

// Request body for user login
public record LoginRequest(string? Email, string? Password);
