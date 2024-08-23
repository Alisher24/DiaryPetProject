using AutoMapper;
using DiaryPetProject.Domain.Dto.User;
using DiaryPetProject.Domain.Entity;

namespace DiaryPetProject.Application.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
