using System;
using System.Collections.Generic;

namespace ProjectOffice.DataBase.Entities;

public partial class TaskObserveEmployee
{
    public int Id { get; set; }

    public Guid TaskId { get; set; }

    public Guid EmployeesId { get; set; }

    public virtual Employee Employees { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
