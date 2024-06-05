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
    /// Логика взаимодействия для DashBoardDayControl.xaml
    /// </summary>
    public partial class DashBoardDayControl : UserControl
    {
        public DateTime Date { get; set; }

        public string Color {
            get
            {
                if (CountTask == 0)
                    return "#b6bdff";
                if (this.CountTask >= 1 && CountTask <= 2)
                    return "#919cff";
                if (this.CountTask >= 3 && CountTask <= 5)
                    return "#6d7cff";
                if (this.CountTask >= 6 && CountTask <= 8)
                    return "#485bff";
                if (this.CountTask >= 9)
                    return "#243aff";
                return "#b6bdff";
            }
        
        }

        public int CountTask { get => _countTask; set => _countTask = value; }

        private int _countTask;

        public DashBoardDayControl()
        {
            InitializeComponent();
            this.Tag = Date;
            DataContext = this;
        }

        public DashBoardDayControl(DateTime date, int countTask) : this()
        {
            Date = date;
            CountTask = countTask;

        }
    }
}
