using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для TaskStatusControl.xaml
    /// </summary>
    public partial class TaskStatusControl : UserControl
    {
        public enum TaskStatus
        {
            Fire,
            Open,
            Work,
            ConditionallyCompleted,
            Closed,
            PostPoned
        }
        public TaskStatusControl()
        {
            InitializeComponent();
        }

        public TaskStatusControl(TaskStatus status) : this()
        {
            var stat = App.TaskStatus.FirstOrDefault(x => x.Type == (int)status);
            if (stat == null)
                throw new Exception("Не найден статус задачи в БД");
            border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(stat.ColorHex));
            content.Content = stat.Name;
        }
    }
}
