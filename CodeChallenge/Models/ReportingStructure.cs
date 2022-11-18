using System;

namespace CodeChallenge.Models;

public class ReportingStructure
{
    public string ReportingStructureId { get; set; }

    public Employee Employee { get; set; }

    public int NumberOfReports { get; set; }
}

