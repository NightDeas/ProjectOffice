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
            UserControls.TaskStatusControl taskStatusControl = new((TaskStatusControl.TaskStatus)StatusId);
            taskStatusControl.SetValue(Grid.ColumnProperty, 1);
            MainGrid.Children.Add(taskStatusControl);
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TaskService.TaskPage.TaskListStackPanel.SetValue(Grid.ColumnSpanProperty, 1);
        }
    }
}
