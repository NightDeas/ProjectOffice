using System;
using System.Collections.Generic;

namespace ProjectOffice.Entities;

public partial class Employee
{
    public Guid Id { get; set; }

    public string Position { get; set; } = null!;

    public string? FirfstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? Email { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public DateTime CreatedTimeStamp { get; set; }

    public DateTime? UpdateTimeStamp { get; set; }

    public DateTime? DeletedTimeStamp { get; set; }

    public DateTime? LastEnterTimeStamp { get; set; }

    public virtual ICollection<TaskObserveEmployee> TaskObserveEmployees { get; set; } = new List<TaskObserveEmployee>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
