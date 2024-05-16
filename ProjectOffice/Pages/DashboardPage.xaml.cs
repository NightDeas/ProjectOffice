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

using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using LiveCharts.SeriesAlgorithms;
using LiveCharts.Defaults;
using LiveCharts.Definitions;
using LiveCharts.Maps;
using LiveCharts.Dtos;


using ProjectOffice.Services;
using LiveCharts.Definitions.Series;
using LiveCharts.Helpers;
using System.Collections.ObjectModel;

namespace ProjectOffice.Pages
{
    /// <summary>
    /// Логика взаимодействия для DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        public SeriesCollection Series { get; set; }
        private Guid _projectId;
        private int countEndTask = 0;

        public int CountEndTask { get => countEndTask; set => countEndTask = value; }
        public DashboardPage()
        {
            InitializeComponent();
            LoadData();
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
            SeriesCollection series = new SeriesCollection
                {
                    new PieSeries
                    {
                        Values = new ChartValues<int>{1,2,2,2}
                    },
                };
            Series = series;    
        }
    }
}
