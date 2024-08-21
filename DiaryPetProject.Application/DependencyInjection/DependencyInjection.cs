using DiaryPetProject.Application.Mapping;
using DiaryPetProject.Application.Services;
using DiaryPetProject.Application.Validations;
using DiaryPetProject.Application.Validations.FluentValidations.Report;
using DiaryPetProject.Domain.Dto.Report;
using DiaryPetProject.Domain.Interfaces.Services;
using DiaryPetProject.Domain.Interfaces.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DiaryPetProject.Application.DependencyInjection;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ReportMapping));

        InitServices(services);
    }

    public static void InitServices(this IServiceCollection services)
    {
        services.AddScoped<IReportValidator, ReportValidator>();
        services.AddScoped<IValidator<CreateReportDto>, CreateReportValidator>();
        services.AddScoped<IValidator<UpdateReportDto>, UpdateReportValidator>();

        services.AddScoped<IReportService, ReportService>();
    }
}
