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

namespace ProjectOffice.UserControls
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddControl.xaml
    /// </summary>
    public partial class EmployeeAddControl : UserControl
    {
        public EmployeeAddControl()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TaskService.OldDetailedTask.ObserversStackPanel.Children.Add(new EmployeeCreateControl());
        }
    }
}
