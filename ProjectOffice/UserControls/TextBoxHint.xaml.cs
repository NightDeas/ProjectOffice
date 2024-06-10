using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

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
    /// Логика взаимодействия для TextBoxHint.xaml
    /// </summary>
    public partial class TextBoxHint : UserControl
    {
        public TextBoxHint()
        {
            InitializeComponent();
        }

        private async void TextTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataBase.Entities.Context context = new DataBase.Entities.Context();
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                await Services.TaskService.LoadTask(Guid.Parse(Properties.Settings.Default.ProjectIdLastSelect));
                return;
            }
            var tasks = await context.Tasks
                .Include(x=> x.ExecutiveEmployeed)
                .Where(x => 
                x.ProjectId == Guid.Parse(Properties.Settings.Default.ProjectIdLastSelect) &&
                (x.ShortTitle.Contains((sender as TextBox).Text) ||
                x.FullTitle.Contains((sender as TextBox).Text) ||
                x.ExecutiveEmployeed.LastName.Contains((sender as TextBox).Text) ||
                x.ExecutiveEmployeed.FirstName.Contains((sender as TextBox).Text) ||
                x.ExecutiveEmployeed.MiddleName.Contains((sender as TextBox).Text)))
                .ToListAsync();
            await Services.TaskService.LoadTask(tasks);
        }
    }
}
