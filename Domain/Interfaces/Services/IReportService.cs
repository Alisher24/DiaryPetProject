using DiaryPetProject.Domain.Dto;
using DiaryPetProject.Domain.Result;

namespace DiaryPetProject.Domain.Interfaces.Services;

/// <summary>
/// Service responsible for working with the domain part of the report (Report)
/// </summary>
public interface IReportService
{
    /// <summary>
    /// Receives all user reports
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<CollectionResult<ReportDto>> GetReportsAsync(long userId);
}
