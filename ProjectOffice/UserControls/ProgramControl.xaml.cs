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
    /// Логика взаимодействия для ProgramControl.xaml
    /// </summary>
    public partial class ProgramControl : UserControl
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Size { get; set; }
        public ProgramControl(string Name, double size, int id) : this()
        {
            Title = Name;
            Size = size;
            Id = id;
        }

        public ProgramControl()
        {
            InitializeComponent();
            DataContext = this;
        }


        private async void ShowImageMI_Click(object sender, RoutedEventArgs e)
        {
            var photo = await ApiService.GetAttachment(Id);
            Windows.ShowImage showImage = new(photo.Photo);
            showImage.ShowDialog();
        }

        private void DeleteImageMI_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement parent = VisualTreeHelper.GetParent(this) as FrameworkElement;
            if (parent != null && parent is StackPanel stackPanel)
            {
                stackPanel.Children.Remove(this);
            }
        }
    }
}
