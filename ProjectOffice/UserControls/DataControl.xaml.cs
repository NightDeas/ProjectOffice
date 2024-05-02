using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для DataControl.xaml
    /// </summary>
    public partial class DataControl : UserControl
    {
        public string Name;
        public double Size;
        public DataControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public DataControl(string name, double size)
        {
            Name = name;
            Size = size;
        }
    }
}
