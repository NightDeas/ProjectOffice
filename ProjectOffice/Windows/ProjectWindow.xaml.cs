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
using System.Windows.Shapes;

namespace ProjectOffice.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {

        DataBase.Entities.Project Project;
        public ProjectWindow()
        {
            InitializeComponent();
            DataContext = Project;
        }

        public ProjectWindow(DataBase.Entities.Project project)
        {
            InitializeComponent();
            this.Project = project;
            if (Project == null)
                Project = new();
            DataContext = Project;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TitleTb.Text))
            {
                MessageBox.Show("Требуется указать название проекта");
                return;
            }
            Entities.Context context = new Entities.Context();
            if (Project.Id == Guid.Empty)
            {
                context.Entry(Project).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                context.Entry(Project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            try
            {
                context.SaveChanges();
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при сохранении данных");
                return;
            }
            DataBase.Entities.Project project = new()
            {
                FullTitle = TitleTb.Text
            };
        }

    }
}
