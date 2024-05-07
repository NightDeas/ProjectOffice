using ProjectOffice.Models.DTO;
using ProjectOffice.Services;

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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectOffice.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProgramAddControl.xaml
    /// </summary>
    public partial class ProgramAddControl : System.Windows.Controls.UserControl
    {
        public ProgramAddControl()
        {
            InitializeComponent();
        }

        private async void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            byte[] bytes = UTF8Encoding.UTF8.GetBytes(fileDialog.FileName);
            AttachmentModel model = new()
            {
                Photo = bytes,
                NamePhoto = System.IO.Path.GetFileName(fileDialog.FileName),
                SizeFile = new FileInfo(fileDialog.FileName).Length/1024/1024,
            };
            await ApiService.PostAttachment(model);
            TaskService.LoadAttachment(model);
        }
    }
}
