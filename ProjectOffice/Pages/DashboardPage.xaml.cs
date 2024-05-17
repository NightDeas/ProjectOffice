using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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



using ProjectOffice.Services;
using LiveCharts.Definitions.Series;
using LiveCharts.Helpers;
using System.Collections.ObjectModel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Extensions;
using ProjectOffice.Models;
using ProjectOffice.UserControls;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectOffice.Pages
{
    /// <summary>
    /// Логика взаимодействия для DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        private Guid _projectId;
        
        private IEnumerable<ISeries> series;
        List<ProjectOffice.DataBase.Entities.Task> Tasks;
        public ViewModel Model { get; set; } = new();
        public DashBoardPageData Data { get; set; } = new();

        public DashboardPage()
        {
            InitializeComponent();
            LoadData();

            DataContext = this;
        }

        private async Task CreateDashBoard()
        {
            UserControls.DashBoardControl dashBoard = new(Tasks);
            dashBoard.SetValue(Grid.RowProperty, 2);
            DashBoardGrid.Children.Add(dashBoard);
        }

        private async Task CreatePieChart()
        {
            Dictionary<string, int> group = new();
            foreach (var task in Tasks)
            {
                if (!group.ContainsKey(task.Status.Name))
                {
                    group[task.Status.Name] = 0;
                }
                group[task.Status.Name]++;
            }
            List<ISeries> series = new List<ISeries>();
            foreach (var item in group)
            {
                series.Add(new PieSeries<int>
                {
                    Name = item.Key,
                    Values = new int[] { item.Value }
                });
            }
            PieChartControl pieChartControl = new UserControls.PieChartControl(new ViewModel()
            {
                Series = series
            });
            pieChartControl.SetValue(Grid.RowProperty, 1);
            ChartPieGrid.Children.Add(pieChartControl);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public DashboardPage(Guid ProjectId) : this()
        {
            _projectId = ProjectId;
        }

        private async Task LoadData()
        {
            Guid projectId = Guid.Parse(Properties.Settings.Default.ProjectIdLastSelect);
            Tasks = await ApiService.GetTasks(projectId);
            Data.CountEndTask = await ApiService.GetHistoryChangeStatusOnDay(projectId);
            //var groupedEntities = Tasks.GroupBy(e => e.StatusId).Select(g => g.Count());
            var groupedEndTaskEmployee = Tasks.GroupBy(e => e.ExecutiveEmployeedId).Select(g => g.Count());
            //List<int> counts = groupedEntities.ToList();
            await CreatePieChart();
            await CreateDashBoard();
            await CreateTopEmployee();
        }

        private async Task CreateTopEmployee()
        {
            var groupedEmployeeEndTask = Tasks.GroupBy(x => x.ExecutiveEmployeedId).Select(x => x.Count());
            SortedDictionary<string, int> countEndTask = new();
            foreach (var task in Tasks)
            {
                if (!countEndTask.ContainsKey(task.ExecutiveEmployeed.FullName))
                    countEndTask[task.ExecutiveEmployeed.FullName] = 0;
                countEndTask[task.ExecutiveEmployeed.FullName]++;
            }
            Data.TopEmployee = countEndTask.ToDictionary(x => x.Key, y => y.Value);
        }
    }
}
