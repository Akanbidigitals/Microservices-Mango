using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mongo.Services.AuthAPI.Models;
using Mongo.Services.AuthAPI.Models.DTO;
using Mongo.Services.AuthAPI.Service.IService;
using Mongo.Servives.AuthAPI.Data;

namespace Mongo.Services.AuthAPI.Controllers;

[Route("api/Auth")]
[ApiController]
public class AuthAPIController : Controller
{
    private readonly IAuthService _authService;
    protected ResponseDto _response;

    public AuthAPIController(IAuthService authService)
    {
      _authService = authService;
      _response = new ResponseDto();
    }
    
    [HttpPost("register")] 
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
    {
        var erroMessage = await _authService.Register(model);
        if (!string.IsNullOrEmpty(erroMessage))
        {
            _response.Message = erroMessage;
            _response.IsSuccess = false;    
            return BadRequest(_response);
        }
        return Ok(_response); 
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
    public async Task<IActionResult> Login([FromBody] RegistrationRequestDto model)
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
  
}