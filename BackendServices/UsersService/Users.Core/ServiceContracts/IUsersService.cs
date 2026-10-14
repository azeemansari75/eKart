using Users.Core.DTOs;

namespace Users.Core.ServiceContracts;

public interface IUsersService
{
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);

    Task<bool> Delete(Guid guid);

}
