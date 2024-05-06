using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.Services
{
    public static class TaskStatusService
    {
        public enum TaskStatus
        {
            Fire = 1,
            Open,
            Work,
            ConditionallyCompleted,
            Closed,
            PostPoned
        }
        public static int StatusNext(int currentStatusType)
        {
            if (currentStatusType == (int)TaskStatus.PostPoned)
                return 1;
            else
                return currentStatusType + 1;
        }
    }
}
