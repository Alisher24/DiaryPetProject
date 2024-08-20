using AutoMapper;
using DiaryPetProject.Domain.Dto.Report;
using DiaryPetProject.Domain.Entity;

namespace DiaryPetProject.Application.Mapping;

public class ReportMapping : Profile
{
    public ReportMapping()
    {
        CreateMap<Report, ReportDto>().ReverseMap();
    }
}
