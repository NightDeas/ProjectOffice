using Microsoft.Identity.Client;

using ProjectOffice.Entities;
using ProjectOffice.Models;
using ProjectOffice.Pages;
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


        public DetailedTaskInfo info { get; set; } = new();
        private bool _isCreate = true;
        //public Guid Id { get; set; }
        //public Guid ProjectId { get; set; }
        //public Employee Employee { get; set; }
        //public DateTime? EndActualTime { get; set; }
        //public DateTime? StartActualTime { get; set; }
        //public Task LastTask { get; set; }
        //public DateTime? DeadLine { get; set; }
        //public DateTime? CreatedTime { get; set; }
        //public string? ShortTitle { get; set; }
        //public string FullTitle { get; set; }
        //public int? StatusType { get; set; }
        //public string Description { get; set; }
        public Employee SelectedTask { get; set; }

        public Employee SelectedEmployee { get; set; }
        public List<Employee> ObserversEmployee { get; set; } = new();

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

        private List<Entities.Attachment> _attachments;




        public DetailedTaskControl()
        {
            InitializeComponent();
            DataContext = this;
            _isCreate = true;
            TaskService.OldDetailedTask = this;
          
        }

        public DetailedTaskControl(DetailedTaskInfo info) : this()
        {
            this.info = info;
            //info.Id = info.Id;
            //info.ProjectId = info.ProjectId;
            //info.Employee = info.Employee;
            //info.EndActualTime = info.EndActualTime;
            //info.StartActualTime = info.StartActualTime;
            //info.LastTask = info.LastTask;
            //info.DeadLine = info.DeadLine;
            //info.CreatedTime = info.CreatedTime;
            //info.ShortTitle = info.ShortTitle;
            //info.StatusType = info.StatusType;
            //info.Description = info.Description;
            //info.FullTitle = info.FullTitle;
            if (DateTime.Now > info.DeadLine)
                DeadLineDp.Foreground = new SolidColorBrush(Colors.Red);
            _isCreate = false;
        }

        private void CreateStatus()
        {
            TaskStatusGrid.Children.Clear();
            info.StatusType ??= 1;
            TaskStatusGrid.Children.Add(new TaskStatusControl((TaskStatusService.TaskStatus)info.StatusType));
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
            var task = await ApiService.GetTask(info.Id);
            if (task == null)
                throw new Exception("Не удалось найти задачу по id");
            await ApiService.DeleteTask(info.Id);
            TaskService.Reset(info.ProjectId);
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeesCb.ItemsSource = await ApiService.GetEmployees();
            TaskCb.ItemsSource = await ApiService.GetTasks();
            CreateStatus();
            DataStackPanel.Children.Add(new UserControls.ProgramAddControl());
            ObserversStackPanel.Children.Add(new UserControls.EmployeeAddControl());
            //EmployeesCb.SelectedItem = Employee;
            //var sdfsd = new Entities.DbContextProjectOffice().Employees.Any(x=> x.Id == Employee.Id);
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Действительно сохранить?", "Внимание", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes)
                return;
            Models.DTO.TaskModel task = new()
            {
                Id = info.Id,
                ProjectId = TaskService.ProjectId,
                FullTitle = info.FullTitle,
                ShortTitle = info.ShortTitle,
                FinishActualTime = info.EndActualTime,
                StartActualTime = info.StartActualTime,
                CreatedTime = DateTime.Now,
                StatusId = (int)info.StatusType,
                Deadline = info.DeadLine,
                Description = info.Description,
                ExecutiveEmployeedId = (EmployeesCb.SelectedItem as Employee).Id,
                PreviousTaskId = info.LastTask == null ? null : info.LastTask.Id,
            };
            if (_isCreate == true)
            {
                await ApiService.PostTask(task);
                MessageBox.Show("Сохранен");

            }
            else
            {
                await ApiService.PutTask(task);
                MessageBox.Show("Сохранен");
            }
            //TaskService.CloseDetailTask();
            TaskService.Reset(TaskService.ProjectId);

        }

        private void LoadAttachments()
        {
          
        }
        private void TaskStatusGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            info.StatusType = TaskStatusService.StatusNext((int)info.StatusType);
            CreateStatus((int)info.StatusType);
        }
    }
}
