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
        public static Entities.DbContextProjectOffice context = new Entities.DbContextProjectOffice();
        public static MainWindow mainWindow;
        public static List<Entities.TaskStatus> TaskStatus = context.TaskStatuses.ToList();
        //public static Pages.TaskPage TaskPage = new();
    }

}
