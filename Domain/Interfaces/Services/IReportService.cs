using DiaryPetProject.Domain.Dto.Report;
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

    /// <summary>
    /// Getting a report by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<BaseResult<ReportDto>> GetReportByIdAsync(long id);

    /// <summary>
    /// Creating new report
    /// </summary>
    /// <returns></returns>
    Task<BaseResult<ReportDto>> CreateReportAsync(CreateReportDto dto);

    /// <summary>
    /// Deleting a report by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<BaseResult<ReportDto>> DeleteReportAsync(long id);

    /// <summary>
    /// Updating report
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<BaseResult<ReportDto>> UpdateReportAsync(UpdateReportDto dto);
}
