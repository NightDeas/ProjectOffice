using Microsoft.Identity.Client;

using ProjectOffice.Entities;
using ProjectOffice.Models;
using ProjectOffice.Services;
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
        public Guid Id { get; set; }
        public string? Employee { get; set; }
        public DateTime? EndActualTime { get; set; }
        public DateTime? StartActualTime { get; set; }
        public string? LastTask { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? ShortTitle { get; set; }
        public int? StatusType { get; set; }
        public string Description { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public List<Entities.Task> TaskList { get; set; }
        public DetailedTaskControl()
        {
            InitializeComponent();
            DataContext = this;
          
        }

        private async System.Threading.Tasks.Task LoadData()
        {
            EmployeeList = await ApiService.GetEmployees();
            TaskList = await ApiService.GetTasks();
        }

        public DetailedTaskControl(DetailedTaskInfo info) : this()
        {
            Id = info.Id;
            Employee = info.Employee;
            EndActualTime = info.EndActualTime;
            StartActualTime = info.StartActualTime;
            LastTask = info.LastTask;
            DeadLine = info.DeadLine;
            CreatedTime = info.CreatedTime;
            ShortTitle = info.ShortTitle;
            StatusType = info.StatusType;
            Description = info.Description;
            if (DateTime.Now > DeadLine)
                DeadLineTb.Foreground = new SolidColorBrush(Colors.Red);
            CreateStatus();
        }

        private void CreateStatus()
        {
            TaskStatusGrid.Children.Clear();
            TaskStatusGrid.Children.Add(new TaskStatusControl((TaskStatusControl.TaskStatus)StatusType));
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Действительно удалить?", "Внимание", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes)
                return;
            //var task = App.context.Tasks.FirstOrDefault(x => x.Id == Id);
            var task = await ApiService.GetTask(Id);
            if (task == null)
                throw new Exception("Не удалось найти задачу по id");
            await ApiService.DeleteTask(Id);
            //try
            //{
            //    App.context.SaveChanges();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Не удалось сохранить");
            //}
        }
    }
}
