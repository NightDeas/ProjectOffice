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

using LiveCharts;
using LiveCharts.Wpf;

namespace ProjectOffice.Pages
{
    /// <summary>
    /// Логика взаимодействия для DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        SeriesCollection SeriesViews { get; set; }
        public DashboardPage()
        {
            InitializeComponent();
            LiveCharts.SeriesCollection seriesViews = new LiveCharts.SeriesCollection() {
                new LineSeries
                {
                    Values = new LiveCharts.ChartValues<double>{1,3,4}
                },
                new ColumnSeries
                {
                    Values = new LiveCharts.ChartValues<double>{1,3,3,3,3,3}
                }
            };
            SeriesViews = seriesViews;
        }
    }
}
