using ProjectOffice.Entities;
using ProjectOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        public string Name;
        public string ShortName;
        public DateTime Date;
        public EmployeeOfTask Employee;

        public TaskControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public TaskControl(TaskInfo info) : this()
        {
            ShortName = info.ShortName;
            Date = info.Date;
            Employee = info.Employee;
            Name = info.Name;
        }
    }
}
