using DiaryPetProject.Domain.Dto;
using DiaryPetProject.Domain.Dto.User;
using DiaryPetProject.Domain.Interfaces.Services;
using DiaryPetProject.Domain.Result;
using Microsoft.AspNetCore.Mvc;

namespace DiaryPetProject.Api.Controllers;

[ApiController]
public class AuthController(IAuthService authService) : Controller
{
    private readonly IAuthService _authService = authService;

    /// <summary>
    /// User registration
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<ActionResult<BaseResult<UserDto>>> Register([FromBody] RegisterUserDto dto)
    {
        var response = await _authService.Register(dto);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    /// <summary>
    /// User Authorization
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<ActionResult<BaseResult<TokenDto>>> Login([FromBody] LoginUserDto dto)
    {
        throw new NotImplementedException();
    }
}
