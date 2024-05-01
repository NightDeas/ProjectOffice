using System;
using System.Collections.Generic;

namespace ProjectOffice.Entities;

public partial class Attachment
{
    public int Id { get; set; }

    public string? Link { get; set; }

    public byte[]? Photo { get; set; }

    public virtual ICollection<AttachmentsInTask> AttachmentsInTasks { get; set; } = new List<AttachmentsInTask>();
}
