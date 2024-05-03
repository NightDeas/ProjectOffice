using Microsoft.Identity.Client;

using ProjectOffice.Entities;
using ProjectOffice.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
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

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectOffice.UserControls
{
    /// <summary>
    /// Логика взаимодействия для DetailedTaskControl.xaml
    /// </summary>
    public partial class DetailedTaskControl : UserControl
    {
        public string? Employee { get; set; }
        public DateTime? EndActualTime { get; set; }
        public DateTime? StartActualTime { get; set; }
        public string? LastTask { get; set; }
        public DateTime? DeadLine { get;set; }
        public DateTime? CreatedTime { get;set; }
        public string? ShortTitle { get; set; }
        public int? StatusType { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public DetailedTaskControl()
        {
            InitializeComponent();
            DataContext = this;
            EmployeeList = App.context.Employees.ToList();
        }

        public DetailedTaskControl(DetailedTaskInfo info) : this()
        {
            Employee = info.Employee;
            EndActualTime = info.EndActualTime;
            StartActualTime = info.StartActualTime;
            LastTask = info.LastTask;
            DeadLine = info.DeadLine;
            CreatedTime = info.CreatedTime;
            ShortTitle = info.ShortTitle;
            StatusType = info.StatusType;
            CreateStatus();
        }

        private void CreateStatus()
        {
            TaskStatusGrid.Children.Clear();
            TaskStatusGrid.Children.Add(new TaskStatusControl((TaskStatusControl.TaskStatus)StatusType));
        }
    }
}
