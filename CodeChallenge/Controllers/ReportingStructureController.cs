using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers;

[Route("api/reportingStructure")]
public class ReportingStructureController : Controller
{
    private readonly ILogger _logger;
    private readonly IEmployeeService _employeeService;

    public ReportingStructureController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
    {
        _logger = logger;
        _employeeService = employeeService;
    }

    [HttpGet("{id}", Name = "getReportByEmployeeId")]
    public IActionResult GetReportById(String id)
    {
        _logger.LogDebug($"Received direct report get request for '{id}'");

        var directReports = _employeeService.GetReportingStructureById(id);

        if (directReports == null)
            return NotFound();

        return Ok(directReports);
    }
}