using Mongo.Services.AuthAPI.Models.DTO;

namespace Mongo.Services.AuthAPI.Service.IService;

public interface IAuthService
{
    Task<ResponseDto> Register(RegistrationRequestDto registerRequestDto);
    Task<LoginReposonseDto>  Login(LoginRequestDto loginRequestDto);
    Task<bool>AssignRole(string email, string roleName);
    
    Task<string>RemoveUserFromRoleAsync(string email, string roleName);
}   