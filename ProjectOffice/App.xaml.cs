using ProjectOffice.DataBase.Entities;
using ProjectOffice.Services;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Media;

namespace ProjectOffice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow MainWindow;
        public static User User;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            MainWindow = new MainWindow();
            MainWindow.FrameMain.Navigate(new Pages.AuthPage());
            MainWindow.ShowDialog();
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show($"Ошибка: {e.Exception.Message}", "Критическая ошибка");
        }
    }

}
