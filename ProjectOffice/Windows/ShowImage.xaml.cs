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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectOffice.Windows
{
    /// <summary>
    /// Логика взаимодействия для ShowImage.xaml
    /// </summary>
    public partial class ShowImage : Window
    {
        public ShowImage(byte[] bytesPhoto)
        {
            InitializeComponent();
            BytesPhoto = bytesPhoto;
            LoadImageFromBinaryData();
        }

        public byte[] BytesPhoto { get; }

        public void LoadImageFromBinaryData()
        {
            using MemoryStream stream = new(BytesPhoto);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = null;
            image.StreamSource = stream;
            image.EndInit();
            image.Freeze();
            //var image = (BitmapSource)new ImageSourceConverter().ConvertFrom(BytesPhoto);

            img.Source = image;
        }
    }
}
