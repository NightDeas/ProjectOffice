using Microsoft.EntityFrameworkCore;

using ProjectOffice.Entities;
using ProjectOffice.Models;
using ProjectOffice.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;

namespace ProjectOffice.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        public new string Title { get; set; }
        public string ShortName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public EmployeeOfTask Employee { get; set; }
        public int StatusId { get; set; }

        public TaskControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public TaskControl(TaskInfo info) : this()
        {
            ShortName = info.ShortName;
            Date = info.Date;
            Employee = info.Employee;
            Title = info.Name;
            StatusId = info.StatusId;
            CreateStatus();
        }

        private void CreateStatus()
        {
            UserControls.TaskStatusControl taskStatusControl = new((TaskStatusService.TaskStatus)StatusId);
            taskStatusControl.SetValue(Grid.ColumnProperty, 1);
            MainGrid.Children.Add(taskStatusControl);
        }


        private async void Control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var task = await ApiService.GetTask((Guid)(sender as TaskControl).Tag);
            DetailedTaskInfo detailedTaskInfo = new DetailedTaskInfo()
            {
                Id = task.Id,
                ProjectId = task.ProjectId,
                DeadLine = task.Deadline,
                CreatedTime = task.CreatedTime,
                Employee = task.ExecutiveEmployeed,
                EndActualTime = task.FinishActualTime,
                LastTask = task.PreviousTask == null ? null : task.PreviousTask,
                ShortTitle = task.ShortTitle,
                FullTitle = task.FullTitle,
                StartActualTime = task.StartActualTime,
                StatusType = (int)task.Status.Type,
                Description = task.Description
            };

            //BorderMain.Background = new SolidColorBrush(Colors.Aquamarine);
            //ImageNext.Visibility = Visibility.Hidden;
            
            TaskService.LoadDetailTask(detailedTaskInfo);
            TaskService.SetStyleSelectTask(this);
        }
    }
}
