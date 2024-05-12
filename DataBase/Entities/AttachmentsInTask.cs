using System;
using System.Collections.Generic;

namespace ProjectOffice.DataBase.Entities;

public partial class AttachmentsInTask
{
    public int Id { get; set; }

    public Guid TaskId { get; set; }

    public int AttachmentId { get; set; }

    public virtual Attachment Attachment { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
