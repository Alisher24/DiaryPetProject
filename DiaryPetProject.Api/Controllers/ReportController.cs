using Asp.Versioning;
using DiaryPetProject.Domain.Dto.Report;
using DiaryPetProject.Domain.Interfaces.Services;
using DiaryPetProject.Domain.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiaryPetProject.Api.Controllers;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ReportController(IReportService reportService) : ControllerBase
{
    private readonly IReportService _reportService = reportService;


    /// <summary>
    /// Getting report
    /// </summary>
    /// <param name="id"></param>
    /// <remarks>
    /// Request for get report
    /// 
    ///     GET
    ///     {
    ///         "id": 1
    ///     }
    /// </remarks>
    [HttpGet("get/{id}")]
    public async Task<ActionResult<BaseResult<ReportDto>>> GetReport(long id)
    {
        var response = await _reportService.GetReportByIdAsync(id);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    /// <summary>
    /// Getting all user reports 
    /// </summary>
    /// <param name="userId"></param>
    /// <remarks>
    /// Request for get reports
    /// 
    ///     GET
    ///     {
    ///         "userId": 1
    ///     }
    /// </remarks>
    [HttpGet("get-all/{userId}")]
    public async Task<ActionResult<BaseResult<ReportDto>>> GetUserReports(long userId)
    {
        var response = await _reportService.GetReportsAsync(userId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    /// <summary>
    /// Deleting report
    /// </summary>
    /// <param name="id"></param>
    /// <remarks>
    /// Request to delete a report
    /// 
    ///     DELETE
    ///     {
    ///         "id": 1
    ///     }
    /// </remarks>
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<BaseResult<ReportDto>>> Delete(long id)
    {
        var response = await _reportService.DeleteReportAsync(id);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    /// <summary>
    /// Create a report
    /// </summary>
    /// <param name="dto"></param>
    /// <remarks>
    /// Request to create a report
    /// 
    ///     POST
    ///     {
    ///         "name": "Report Name",
    ///         "description": "Report description",
    ///         "userId": 1
    ///     }
    /// </remarks>
    [HttpPost("create")]
    public async Task<ActionResult<BaseResult<ReportDto>>> Create([FromBody] CreateReportDto dto)
    {
        var response = await _reportService.CreateReportAsync(dto);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    /// <summary>
    /// Create a report
    /// </summary>
    /// <param name="dto"></param>
    /// <remarks>
    /// Request to create a report
    /// 
    ///     PUT
    ///     {
    ///         "id": 1,
    ///         "name": "Report Name",
    ///         "description": "Report description"
    ///     }
    /// </remarks>
    [HttpPut("update")]
    public async Task<ActionResult<BaseResult<ReportDto>>> Update([FromBody] UpdateReportDto dto)
    {
        var response = await _reportService.UpdateReportAsync(dto);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }
}
