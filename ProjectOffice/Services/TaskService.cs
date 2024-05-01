using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using ProjectOffice.Entities;
using ProjectOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectOffice.Services
{
    public static class TaskService
    {

        public static List<UIElement> LoadTask(Guid projectId)
        {
            List<UIElement> taskControls = new List<UIElement>();
            var tasks = App.context.Tasks
                .Where(x => x.ProjectId == projectId)
                .Include(x => x.ExecutiveEmployeed)
            .ToList();

            foreach (var task in tasks)
            {
                TaskInfo info = new TaskInfo()
                {
                    Name = task.FullTitle,
                    Employee = new EmployeeOfTask(task.ExecutiveEmployeed.FullName, task.ExecutiveEmployeed.ShortName),
                    Date = task.Deadline ?? DateTime.MinValue,
                    ShortName = task.ShortTitle,
                    StatusId = task.StatusId,
                };
                taskControls.Add(new UserControls.TaskControl(info));
            }
            return taskControls;
        }
    }
}
