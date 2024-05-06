using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.Models
{
    public class DetailedTaskInfo
    {
        public Guid Id { get; set; }
        public string? Employee { get; set; }
        public DateTime? EndActualTime { get; set; }
        public DateTime? StartActualTime { get; set; }
        public Entities.Task LastTask { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? ShortTitle { get; set; }
        public string? FullTitle { get; set; }
        public int? StatusType { get; set; }
        public string Description { get; set; }
    }
}
