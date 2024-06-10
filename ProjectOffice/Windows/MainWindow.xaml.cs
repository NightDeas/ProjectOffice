using ProjectOffice.Properties;
using ProjectOffice.Services;

using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace ProjectOffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string _versionApp;

        public string VersionApp
        {
            get { return _versionApp; }
            set { _versionApp = value;
                var sdfdds = _versionApp.Split('.');
                int number = 1 + int.Parse(sdfdds[sdfdds.Length - 1]);
                sdfdds[^1] = number.ToString();
                string version = string.Join(".", sdfdds);
                ProjectOffice.Properties.Settings.Default.versionApp = version;
                Settings.Default.Save();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            VersionApp = ProjectOffice.Properties.Settings.Default.versionApp;
            DataContext = this;
            App.MainWindow = this;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.MainWindow.FrameMain.Navigate(new Pages.DashboardPage(Guid.Parse(Properties.Settings.Default.ProjectIdLastSelect)));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var a =(sender as MenuItem).DataContext;
        }

        private async void ContextEdit_Click(object sender, RoutedEventArgs e)
        {
            var project = (sender as MenuItem).DataContext as UserControls.ProjectInPanelControl;
            Guid guid = Guid.Parse(project.Tag.ToString());
            var findProject = await ApiService.GetProject(guid);
            Windows.ProjectWindow projectWindow = new(findProject);
            projectWindow.ShowDialog();
            //Windows.ProjectWindow project = Services.ApiService.GetProject()
            //project.ShowDialog();
        }

        private void AddProject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Windows.ProjectWindow project = new();
            project.ShowDialog();
        }
    }
}