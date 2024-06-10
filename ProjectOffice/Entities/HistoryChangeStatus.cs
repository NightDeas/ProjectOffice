using System;
using System.Collections.Generic;

namespace ProjectOffice.Entities;

public partial class HistoryChangeStatus
{
    public int Id { get; set; }

    public Guid TaskId { get; set; }

    public int StatusId { get; set; }

    public DateTime ChangeTime { get; set; }

    public virtual TaskStatus Status { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
