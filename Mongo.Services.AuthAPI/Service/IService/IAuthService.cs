using Mongo.Services.AuthAPI.Models.DTO;

namespace Mongo.Services.AuthAPI.Service.IService;

public interface IAuthService
{
    Task<string> Register(RegistrationRequestDto registerRequestDto);
    Task<LoginReposonseDto>  Login(LoginRequestDto loginRequestDto);
}   