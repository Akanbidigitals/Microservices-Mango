namespace Mongo.Services.AuthAPI.Models.DTO;

public class LoginReposonseDto
{
    public UserDTO User { get; set; }
    public string Token { get; set; } 
}