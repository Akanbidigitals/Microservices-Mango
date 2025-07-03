using Mango.Web.Models;
using Mongo.Web.Model;

namespace Mango.Web.Service.IService;

public interface IAuthService
{
    Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
    Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
    Task<ResponseDto?> AssignRoleAsync( RegistrationRequestDto registrationRequestDto);
}