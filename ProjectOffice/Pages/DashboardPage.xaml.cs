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

namespace ProjectOffice.Pages
{
    /// <summary>
    /// Логика взаимодействия для DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        private Guid _projectId;
        private int countEndTask = 0;
        private IEnumerable<ISeries> series;

        public ViewModel Model { get; set; } = new();
        public int CountEndTask { get => countEndTask; set => countEndTask = value; }
        public DashboardPage()
        {
            InitializeComponent();
            LoadData();
            CreatePieChart();
            DataContext = this;
        }

        private async void CreatePieChart()
        {
            var tasks = await ApiService.GetTasks(Guid.Parse(Properties.Settings.Default.ProjectIdLastSelect));
            Dictionary<string, int> group = new();
            foreach (var task in tasks)
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
                    Values = new int[] { item.Value}
                });
            }
            PieChartControl pieChartControl = new UserControls.PieChartControl(new ViewModel()
            {
                Series = series
            });
            pieChartControl.SetValue(Grid.RowProperty, 1);
            ChartPieGrid.Children.Add(pieChartControl);
        }

        public DashboardPage(Guid ProjectId) : this()
        {
            _projectId = ProjectId;
        }

        private async void LoadData()
        {
            CountEndTask = await ApiService.GetHistoryChangeStatusOnDay();
            List<ProjectOffice.DataBase.Entities.Task> tasks = await ApiService.GetTasks(_projectId);
            var groupedEntities = tasks.GroupBy(e => e.StatusId).Select(g => g.Count());
            List<int> counts = groupedEntities.ToList();
        }
    }
}
