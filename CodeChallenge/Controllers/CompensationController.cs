using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers;

[Route("api/compensation")]
public class CompensationController : Controller
{
    private readonly ILogger _logger;
    private readonly ICompensationService _compensationService;

    public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
    {
        _logger = logger;
        _compensationService = compensationService;
    }

    [HttpPost]
    public IActionResult CreateCompensation([FromBody] Compensation compensation)
    {
        _logger.LogDebug($"Received compensation create request for employeeId: '{compensation.Employee.EmployeeId}'");

        _compensationService.Create(compensation);

        return CreatedAtRoute("getCompensationById", new { id = compensation.Employee.EmployeeId }, compensation);
    }

    [HttpGet("compensation/{id}", Name = "getCompensationById")]
    public IActionResult GetCompensationById(string id)
    {
        _logger.LogDebug($"Received compensation get request for '{id}'");

        Compensation compensation = _compensationService.GetById(id);

        if (compensation == null)
            return NotFound();

        return Ok(compensation);
    }
}

