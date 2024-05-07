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
    /// Логика взаимодействия для ProgramControl.xaml
    /// </summary>
    public partial class ProgramControl : UserControl
    {

        public string Title { get; set; }
        public double Size { get; set; }
        public ProgramControl(string Name, double size) : this()
        {
            Title = Name;
            Size = size;
        }

        public ProgramControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
