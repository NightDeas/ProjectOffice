using System;
using System.Collections.Generic;

namespace ProjectOfficeApi.Entities;

public partial class MessagesInTask
{
    public int Id { get; set; }

    public int MessageId { get; set; }

    public Guid TaskId { get; set; }

    public virtual Message Message { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
