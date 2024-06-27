using System;
using System.Collections.Generic;

namespace DBFirstApproach.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public int? Salary { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
