using AutoMapper;
using Users.Core.DTOs;
using Users.Core.Entities;
using Users.Core.Repositories;
using Users.Core.ServiceContracts;

namespace Users.Core.Services;

public class UsersService : IUsersService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;   
        _mapper = mapper;
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        //Map Entity to DTO
        var user = _mapper.Map<ApplicationUser>(registerRequest);

        //Code for add in DB
        var createdUser = await _userRepository.AddUser(user);

        //Response
        return _mapper.Map<AuthenticationResponse>(createdUser) with { Token = "", Success = true };
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser login = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (login == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(login) with { Token = "" , Success = true};
    }
}
