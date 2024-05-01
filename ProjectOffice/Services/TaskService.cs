using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using ProjectOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectOffice.Services
{
    public static class TaskService
    {

        public static List<UIElement> LoadTask(Guid projectId)
        {
            List<UIElement> taskControls = new List<UIElement>();
            var tasks = App.context.Tasks
                .Where(x=> x.ProjectId == projectId)
                .ToList();

            foreach (var task in tasks)
            {
                //TaskInfo info = new TaskInfo(task.FullTitle, new EmployeeOfTask(task.Project.))
                //taskControls.Add(new UserControls.TaskControl())
            }

            return taskControls;
        }
    }
}
