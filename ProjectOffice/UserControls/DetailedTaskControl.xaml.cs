using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using ProjectOffice.DataBase.Entities;
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
        public ProjectOffice.DataBase.Entities.Employee SelectedTask { get; set; }

        public ProjectOffice.DataBase.Entities.Employee SelectedEmployee { get; set; }
        public List<ProjectOffice.DataBase.Entities.Employee> ObserversEmployee { get; set; } = new();

        private List<ProjectOffice.DataBase.Entities.Employee> _employees;

        public List<ProjectOffice.DataBase.Entities.Employee> EmployeeList
        {
            get { return _employees; }
            set { _employees = value; }
        }

        private List<ProjectOffice.DataBase.Entities.Task> _tasks;

        public List<ProjectOffice.DataBase.Entities.Task> TaskList
        {
            get { return _tasks; }
            set { _tasks = value; }
        }

        private List<ProjectOffice.DataBase.Entities.Attachment> _attachments;




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
                throw new Exception("Не удалось найти задачу по Id");
            await ApiService.DeleteTask(info.Id);
            TaskService.Reset(info.ProjectId);
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataStackPanel.Children.Clear();
            ObserversStackPanel.Children.Clear();
            EmployeesCb.ItemsSource = await ApiService.GetEmployees();
            TaskCb.ItemsSource = await ApiService.GetTasks();
            CreateStatus();
            DataStackPanel.Children.Add(new UserControls.ProgramAddControl());
            ObserversStackPanel.Children.Add(new UserControls.EmployeeAddControl());
            GetObservers();
            //EmployeesCb.SelectedItem = Employee;
            //var sdfsd = new Entities.DbContextProjectOffice().Employees.Any(x=> x.Id == Employee.Id);
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (info.DeadLine == DateTime.MinValue ||
                info.EndActualTime == DateTime.MinValue ||
                info.StartActualTime == DateTime.MinValue ||
                string.IsNullOrEmpty(info.Description) ||
                string.IsNullOrEmpty(info.FullTitle) ||
                string.IsNullOrEmpty(info.ShortTitle))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (info.StartActualTime > info.EndActualTime)
            {
                MessageBox.Show("Дата начала не может быть больше даты завершения");
            }
            if ((EmployeesCb.SelectedItem as ProjectOffice.DataBase.Entities.Employee) == null)
            {
                MessageBox.Show("Не выбран сотрудник");
                return;
            }



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
                ExecutiveEmployeedId = (EmployeesCb.SelectedItem as ProjectOffice.DataBase.Entities.Employee).Id,
                PreviousTaskId = info.LastTask == null ? null : info.LastTask.Id,
            };
            if (_isCreate == true)
            {
                await ApiService.PostTask(task);
                AddObservers();
                //AddPrograms();
                MessageBox.Show("Сохранен");
            }
            else
            {
                await ApiService.PutTask(task);
                await ApiService.PostHistoryChangeStatus(new HistoryChangeStatus()
                {
                    TaskId = task.Id,
                    StatusId = task.StatusId
                });
                MessageBox.Show("Сохранен");
            }
            //TaskService.CloseDetailTask();
            TaskService.Reset(TaskService.ProjectId);

        }

        private async void AddPrograms()
        {
            int[] programs = GetPrograms();
            List<AttachmentsInTask> attachments = new List<AttachmentsInTask>();
            foreach (var programId in programs)
            {
                await ApiService.PostAttachmentInTask(new AttachmentsInTask()
                {
                    TaskId = info.Id,
                    AttachmentId = programId
                });
            }
        }

        private int[] GetPrograms()
        {
            byte size = (byte)this.DataStackPanel.Children.Count;
            int[] programs = new int[size];
            for (int i = 0; i < size; i++)
            {
                programs[i] = (this.ObserversStackPanel.Children[i] as UserControls.ProgramControl).Id;
            }
            return programs;
        }

        private async void AddObservers()
        {
            var observersCb = GetComboBoxObserver();
            foreach (var observer in observersCb)
            {
                Employee employee = (observer.SelectedItem as ProjectOffice.DataBase.Entities.Employee);
                if (!TaskService.OldDetailedTask.ObserversEmployee.Any(x => x.Id == employee.Id))
                    //TaskService.OldDetailedTask.ObserversEmployee.Add(employee);
                    await ApiService.PostTaskObserveEmployee(new TaskObserveEmployee()
                    {
                        TaskId = info.Id,
                        EmployeesId = employee.Id
                    });
            }
        }

        private async void GetObservers()
        {
            Context context = new();
            var observers = await context.TaskObserveEmployees.Where(x => x.TaskId == info.Id).ToListAsync();
            foreach (var observer in observers)
            {
                var control = new UserControls.EmployeeAddControl(observer.EmployeesId);
                ObserversStackPanel.Children.Add(control);
            }
        }

        private List<System.Windows.Controls.ComboBox> GetComboBoxObserver()
        {
            int size = this.ObserversStackPanel.Children.Count - 1;
            List<System.Windows.Controls.ComboBox> comboBoxes = new List<System.Windows.Controls.ComboBox>();
            for (int i = 1; i < size; i++)
            {
                if (this.ObserversStackPanel.Children[i] is UserControls.EmployeeCreateControl control)
                    comboBoxes.Add(control.EmployeesCb);
            }
            return comboBoxes;
        }

        private void TaskStatusGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            info.StatusType = TaskStatusService.StatusNext((int)info.StatusType);
            CreateStatus((int)info.StatusType);
        }
    }
}
