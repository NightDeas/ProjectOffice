using ProjectOffice.Services;
using System;
using System.Collections.Generic;
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

namespace ProjectOffice.Pages
{
    /// <summary>
    /// Логика взаимодействия для TaskPage.xaml
    /// </summary>
    public partial class TaskPage : Page
    {
        Guid _projectId;

        public TaskPage()
        {
            InitializeComponent();
        }

        public TaskPage(Guid projectId) : this()
        {
            _projectId = projectId;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //if (_projectId == Guid.Empty)
            //    return;
            //var taskControls = TaskService.LoadTask(_projectId);
            //foreach (var task in taskControls)
            //{
            //    TaskListStackPanel.Children.Add(task);
            //}
        }

       
        private void ImageAddTask_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TaskService.LoadDetailTask(null);
        }
    }
}
