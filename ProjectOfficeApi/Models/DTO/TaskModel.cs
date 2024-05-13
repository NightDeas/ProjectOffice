using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.Models.DTO
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }

        public string FullTitle { get; set; }

        public string ShortTitle { get; set; }

        public string Description { get; set; }

        public Guid ExecutiveEmployeedId { get; set; }

        public int StatusId { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public DateTime? DeletedTime { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime? StartActualTime { get; set; }

        public DateTime? FinishActualTime { get; set; }

        public Guid? PreviousTaskId { get; set; }
        public bool IsDelete { get; set; }
    }
}
