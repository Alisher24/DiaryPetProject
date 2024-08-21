using DiaryPetProject.Domain.Dto.Report;
using DiaryPetProject.Domain.Interfaces.Services;
using DiaryPetProject.Domain.Result;
using Microsoft.AspNetCore.Mvc;

namespace DiaryPetProject.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ReportController(IReportService reportService) : ControllerBase
{
    private readonly IReportService _reportService = reportService;

    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResult<ReportDto>>> GetReport(long id)
    {
        var response = await _reportService.GetReportByIdAsync(id);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    } 
}
