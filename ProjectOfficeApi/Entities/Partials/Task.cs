
using ProjectOfficeApi.Controllers;

namespace ProjectOfficeApi.Entities
{
    public partial class Task
    {
        public Task()
        {
        }

        public Task(TaskRequest request)
        {
            ProjectId = request.ProjectId;
            FullTitle = request.FullTitle;
            ShortTitle = request.ShortTitle;
            Description = request.Description;
            ExecutiveEmployeedId = request.ExecutiveEmployeedId;
            StatusId = request.StatusId;
            CreatedTime = request.CreatedTime;
            UpdatedTime = request.UpdatedTime;
            DeletedTime = request.DeletedTime;
            Deadline = request.Deadline;
            StartActualTime = request.StartActualTime;
            FinishActualTime = request.FinishActualTime;
            PreviousTaskId = request.PreviousTaskId;
            IsDelete = request.IsDelete;
        }
    }
}
