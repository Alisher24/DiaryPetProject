using DiaryPetProject.Domain.Dto;
using DiaryPetProject.Domain.Dto.User;
using DiaryPetProject.Domain.Result;

namespace DiaryPetProject.Domain.Interfaces.Services;

/// <summary>
/// Service intended for authorization/registration
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// User registration
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<BaseResult<UserDto>> Register(RegisterUserDto dto);

    /// <summary>
    /// User authorization
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<BaseResult<TokenDto>> Login(LoginUserDto dto);
}
