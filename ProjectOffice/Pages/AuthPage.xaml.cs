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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {

        public AuthPage()
        {
            InitializeComponent();
            App.MainWindow.MainGrid.ColumnDefinitions[0].Width = new GridLength(0);
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text) || string.IsNullOrEmpty(PasswordPb.Password))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            var user = await ApiLibrary.Api.GetUserAsync(LoginTb.Text, PasswordPb.Password);
            if (user == null)
            {
                MessageBox.Show("Неправильный логин или пароль");
                return;
            }
            App.MainWindow.MainGrid.ColumnDefinitions[0].Width = new GridLength(50);
            App.MainWindow.FrameMain.Navigate(new Pages.TaskPage(Guid.Parse(Properties.Settings.Default.ProjectIdLastSelect)));
            await Services.MenuSerivce.LoadProjects(App.MainWindow);
            await Services.MenuSerivce.AutoSelectProject(App.MainWindow);
        }
    }
}
