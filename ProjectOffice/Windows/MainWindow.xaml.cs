using ProjectOffice.Properties;
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
            await Services.MenuSerivce.LoadProjects(this);
            await Services.MenuSerivce.AutoSelectProject(this);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.MainWindow.FrameMain.Navigate(new Pages.DashboardPage(Guid.Parse(Properties.Settings.Default.ProjectIdLastSelect)));
        }
    }
}