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
        private Visibility visibilityHint;

        public Visibility VisibilityHint
        {
            get { return visibilityHint; }
            set { visibilityHint = value; }
        }

        public TextBoxHint()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0)
                VisibilityHint = Visibility.Visible;
            else
                VisibilityHint = Visibility.Collapsed;

        }
    }
}
