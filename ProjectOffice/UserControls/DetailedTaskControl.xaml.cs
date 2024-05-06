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

using Task = ProjectOffice.Entities.Task;

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
        public Task LastTask { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? ShortTitle { get; set; }
        public string FullTitle { get; set; }
        public int? StatusType { get; set; }
        public string Description { get; set; }
        public Employee SelectedTask { get; set; }

        public Employee SelectedEmployee { get; set; }

        private List<Employee> _employees;

        public List<Employee> EmployeeList
        {
            get { return _employees; }
            set { _employees = value; }
        }

        private List<Entities.Task> _tasks;

        public List<Entities.Task> TaskList
        {
            get { return _tasks; }
            set { _tasks = value; }
        }




        public DetailedTaskControl()
        {
            InitializeComponent();
            DataContext = this;
          
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
            FullTitle = info.FullTitle;
            if (DateTime.Now > DeadLine)
                DeadLineDp.Foreground = new SolidColorBrush(Colors.Red);
            CreateStatus();
        }

        private void CreateStatus()
        {
            TaskStatusGrid.Children.Clear();
            StatusType ??= 1;
            TaskStatusGrid.Children.Add(new TaskStatusControl((TaskStatusService.TaskStatus)StatusType));
        }

        private void CreateStatus(int StatusType)
        {
            TaskStatusGrid.Children.Clear();
            TaskStatusGrid.Children.Add(new TaskStatusControl((TaskStatusService.TaskStatus)StatusType));
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
            TaskService.CloseDetailTask();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeesCb.ItemsSource = await ApiService.GetEmployees();
            TaskCb.ItemsSource = await ApiService.GetTasks();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedEmployee == null)
                return;

            MessageBoxResult result = MessageBox.Show("Действительно сохранить?", "Внимание", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes)
                return;
            Task task = new Entities.Task()
            {
                FullTitle = this.FullTitle,
                FinishActualTime = EndActualTime,
                StartActualTime = StartActualTime,
                Deadline = DeadLine,
                Description = this.Description,
                ExecutiveEmployeed = SelectedEmployee,
                InversePreviousTask = LastTask,
            };
            TaskService.CloseDetailTask();

        }

        private void TaskStatusGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StatusType = TaskStatusService.StatusNext((int)StatusType);
            CreateStatus((int)StatusType);
        }
    }
}
