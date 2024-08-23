using AutoMapper;
using DiaryPetProject.Application.Resources;
using DiaryPetProject.Domain.Dto;
using DiaryPetProject.Domain.Dto.User;
using DiaryPetProject.Domain.Entity;
using DiaryPetProject.Domain.Enum;
using DiaryPetProject.Domain.Interfaces.Repositories;
using DiaryPetProject.Domain.Interfaces.Services;
using DiaryPetProject.Domain.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;

namespace DiaryPetProject.Application.Services;

public class AuthService(IBaseRepository<User> userRepository, 
    ILogger<AuthService> logger, IMapper mapper) 
    : IAuthService
{
    private readonly IBaseRepository<User> _userRepository = userRepository;
    private readonly ILogger<AuthService> _logger = logger;
    private readonly IMapper _mapper = mapper;

    public Task<BaseResult<TokenDto>> Login(LoginUserDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResult<UserDto>> Register(RegisterUserDto dto)
    {
        if (dto.Password != dto.PasswordConfirm)
        {
            return new BaseResult<UserDto>()
            {
                ErrorMessage = ErrorMessage.PasswordNotEqualsPasswordConfirm,
                ErrorCode = (int)ErrorCodes.PasswordNotEqualsPasswordConfirm,
            };
        }

        try
        {
            var user = await _userRepository.GetAll()
                .FirstOrDefaultAsync(x => x.Login == dto.Login);
            if (user != null)
            {
                return new BaseResult<UserDto>()
                {
                    ErrorMessage = ErrorMessage.UserAlreadyExists,
                    ErrorCode = (int)ErrorCodes.UserAlreadyExists,
                };
            }
            var hashUserPassword = HashPassword(dto.Password);
            user = new User()
            {
                Login = dto.Login,
                Password = hashUserPassword
            };
            await _userRepository.CreateAsync(user);
            return new BaseResult<UserDto>()
            {
                Data = _mapper.Map<UserDto>(user)
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new BaseResult<UserDto>()
            {
                ErrorMessage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCodes.InternalServerError
            };
        }
    }

    private string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return BitConverter.ToString(bytes);
    }
}
