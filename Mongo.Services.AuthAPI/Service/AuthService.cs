using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mongo.Services.AuthAPI.Models;
using Mongo.Services.AuthAPI.Models.DTO;
using Mongo.Services.AuthAPI.Service.IService;
using Mongo.Servives.AuthAPI.Data;

namespace Mongo.Services.AuthAPI.Service;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IJwtTokenGenerator  _jwtTokenGenerator;

    public AuthService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,IJwtTokenGenerator jwtTokenGenerator)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<string> Register(RegistrationRequestDto registerRequestDto)
    {
        ApplicationUser user = new()
        {
            Email = registerRequestDto.Email,
            UserName = registerRequestDto.Email,
            Name = registerRequestDto.Name,
            PhoneNumber = registerRequestDto.PhoneNumber,
            NormalizedEmail = registerRequestDto.Email.ToUpper(),
        };
        try
        {
            var result = await _userManager.CreateAsync(user, registerRequestDto.Password);
            if (result.Succeeded)
            {
                var userToReturn = _dbContext.ApplicationUsers.First(x => x.Email == registerRequestDto.Email);
                UserDTO userDto = new()
                {
                    Name = userToReturn.Name,
                     Email = userToReturn.Email,
                     PhoneNumber = userToReturn.PhoneNumber,
                     ID = userToReturn.Id,

                };
                return $"{userDto.Name} registered successfully";
            }
            return result.Errors.First().Description;
        }
        catch (Exception ex)
        {
            
        }

        return "Error Encountered";
    }

    public async Task<LoginReposonseDto> Login(LoginRequestDto loginRequestDto)
    {
        var user =  _dbContext.ApplicationUsers.FirstOrDefault(x => x.UserName.ToLower()  == loginRequestDto.UserName.ToLower());
        bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
        if (user == null || isValid == false)
        {
            return new LoginReposonseDto()
            {
                User = null,
                Token = ""
            };
        }
        //if user was found , we generate jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);
        UserDTO userdto = new()
        {
            Email = user.Email,
            ID = user.Id,
            Name = user.Name,
            PhoneNumber = user.PhoneNumber,
        };

        LoginReposonseDto loginReposonseDto = new()
        {
            User = userdto,
            Token = token
        };
        return loginReposonseDto;
    }

    public async Task<bool> AssignRole(string email, string roleName)
    {
        var user =  _dbContext.ApplicationUsers.FirstOrDefault(x => x.Email.ToLower()  == email.ToLower());
        if (user != null)
        {
            if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
            }
            await _userManager.AddToRoleAsync(user, roleName);
            return true;
        }

        return false;
    }
}