using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для DashBoardControl.xaml
    /// </summary>
    public partial class DashBoardControl : UserControl
    {
        Dictionary<DateTime, int> CountTask = new Dictionary<DateTime, int>();
        public string[] MonthInDashboard { get; set; }
        private string[] Month = new[] { "Янв", "Фев", "Март", "Апр", "Май", "Июнь", "Июль", "Авг", "Сент", "Окт", "Нояб", "Дек" };
        private DateTime StartDate { get; set; }
        public DashBoardControl(Dictionary<DateTime, int> countTask) : this()
        {
            CountTask = countTask;
            MonthInDashboard = new string[12];
        }

        public DashBoardControl(List<ProjectOffice.DataBase.Entities.Task> tasks) : this()
        {
            Fill(tasks);
        }
        public DashBoardControl()
        {
            InitializeComponent();
            DataContext = this;
            MonthInDashboard = new string[13];
        }

        private Dictionary<DateTime, int> CreateDictionary(List<ProjectOffice.DataBase.Entities.Task> tasks)
        {
            Dictionary<DateTime, int> result = new();
            foreach (var task in tasks)
            {
                if (!result.ContainsKey((DateTime)task.FinishActualTime))
                {
                    result[(DateTime)task.FinishActualTime] = 0;
                }
                result[(DateTime)task.FinishActualTime]++;
            }
            return result;
        }
        private void Fill(List<ProjectOffice.DataBase.Entities.Task> tasks)
        {
            var dictionary = CreateDictionary(tasks);
            int numberTask = 0;
            FillMonth();
            for (int i = 0; i < dashboard.ColumnDefinitions.Count; i++)
            {
                // y = 0 - шапка(указаны месяцы)
                for (int y = 1; y < dashboard.RowDefinitions.Count; y++)
                {
                    var result = dictionary.FirstOrDefault(x => x.Key == StartDate.Date);
                    UserControls.DashBoardDayControl control = new(StartDate, result.Value);
                    control.SetValue(Grid.ColumnProperty, i);
                    control.SetValue(Grid.RowProperty, y);
                    dashboard.Children.Add(control);
                    StartDate = StartDate.AddDays(1);
                }
            }
        }

        private void FillMonth()
        {
            DateTime date = DateTime.Now;
            int selectMonth = date.Month - 1;
            StartDate = date.AddYears(-1);
            for (int i = 0; i < MonthInDashboard.Length; i++)
            {
                MonthInDashboard[i] = Month[selectMonth++];
                if (selectMonth >= 12)
                    selectMonth = 0;
            }
        }

      
    }
}
