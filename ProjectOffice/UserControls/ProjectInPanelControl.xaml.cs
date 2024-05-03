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
    /// Логика взаимодействия для ProjectInPanelControl.xaml
    /// </summary>
    public partial class ProjectInPanelControl : UserControl
    {

        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        private string _minName;


        public string MinName
        {
            get { return _minName; }
            set { _minName = value; }
        }


        public ProjectInPanelControl(string Name) : this()
        {
            FullName = Name;
            string[] strings = Name.Split(" ");
            if (strings.Length == 1)
                MinName = strings[0].ToCharArray()[0].ToString().ToUpper();
            if (strings.Length >= 2)
                MinName = (strings[0].ToCharArray()[0].ToString() + strings[1].ToCharArray()[0].ToString()).ToUpper();

        }

        public ProjectInPanelControl()
        {
            InitializeComponent();
            DataContext = this;
            contentLb.Style = (Style)Resources["default"];
        }

        private void Control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (sender as ProjectInPanelControl).contentLb.Style = (Style)this.Resources["selectProject"];
            MenuSerivce.SetStyleSelectProject(sender as ProjectInPanelControl);
            MenuSerivce.SaveSelectProject(sender as ProjectInPanelControl);
            //App.mainWindow.FrameMain.Navigate(new Pages.TaskPage((Guid)(sender as ProjectInPanelControl).Tag));
            App.mainWindow.FrameMain.Navigate(TaskService.TaskPage);
            TaskService.LoadTask((Guid)(sender as ProjectInPanelControl).Tag);
        }
    }
}
