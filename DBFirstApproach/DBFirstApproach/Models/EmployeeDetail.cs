using System;
using System.Collections.Generic;

namespace DBFirstApproach.Models;

public partial class EmployeeDetail
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public int? Salary { get; set; }

    public string DepartmentName { get; set; } = null!;
}
