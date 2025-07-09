
using Microsoft.AspNetCore.Mvc;

using Mongo.Services.AuthAPI.Models.DTO;
using Mongo.Services.AuthAPI.Service.IService;


using ResponseDto = Mongo.Services.AuthAPI.Models.DTO.ResponseDto;

namespace Mongo.Services.AuthAPI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthAPIController : Controller
{
    private readonly IAuthService _authService;
    
    private ResponseDto _response;

    public AuthAPIController(IAuthService authService)
    {
      _authService = authService;
      _response = new ResponseDto();
    }
    
    [HttpPost("register")] 
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
    {
        var result = await _authService.Register(model);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
    {
        var loginReposonse = await _authService.Login(model);
        if (loginReposonse.User == null)
        {
            _response.Message = "User or password is incorrect";
            _response.IsSuccess = false;
            return BadRequest(_response);
        }
        _response.Result =  loginReposonse;
        return Ok(_response);
    }
    [HttpPost("assignRole")]
    public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
    {
        var assignSuccessful = await _authService.AssignRole(model.Email,model.Role);
        if (!assignSuccessful)
        {
            _response.Message = "Error Encountered";
            _response.IsSuccess = false;
            return BadRequest(_response);
        }
        _response.Result =  assignSuccessful;
        return Ok(_response);
    }

    [HttpPost("removeRole")]
    public async Task<IActionResult> RemoveRole(string email, string roleName)
    {
        var result = await _authService.RemoveUserFromRoleAsync(email, roleName);
        return Ok(result) ;
    }
    
    
  
}