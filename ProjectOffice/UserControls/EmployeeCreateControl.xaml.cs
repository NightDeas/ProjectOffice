using ProjectOffice.Pages;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectOffice.UserControls
{
    /// <summary>
    /// Логика взаимодействия для EmployeeCreateControl.xaml
    /// </summary>
    public partial class EmployeeCreateControl : UserControl
    {

        public EmployeeCreateControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void DeleteEmployeeMI_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement parent = VisualTreeHelper.GetParent(this) as FrameworkElement;
            if (parent != null && parent is StackPanel stackpanel)
            {
                stackpanel.Children.Remove(this);
            }
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeesCb.ItemsSource = await ApiService.GetEmployees();
        }

        private void EmployeesCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedItem == null)
                return;
            if (TaskService.OldDetailedTask.ObserversEmployee.Any(x => x.Id == (EmployeesCb.SelectedItem as ProjectOffice.DataBase.Entities.Employee).Id) == true)
                (sender as ComboBox).SelectedItem = null;
            else
                TaskService.OldDetailedTask.ObserversEmployee.Add(EmployeesCb.SelectedItem as ProjectOffice.DataBase.Entities.Employee);
        }

        private void EmployeesCb_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }
    }
}
