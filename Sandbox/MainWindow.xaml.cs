
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;


namespace Sandbox
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var bitmap = new Bitmap(Image.FromFile("dev.png", false));
            var redMask = ExtractMask(bitmap, (o) => Color.FromArgb(255-o.R,o.R, 0, 0));
            var greenMask = ExtractMask(bitmap, (o) => Color.FromArgb(255-o.G,0, o.G, 0));
            var blueMask = ExtractMask(bitmap, (o) => Color.FromArgb(Color.Transparent.A, Color.Transparent.R, Color.Transparent.G, Color.Transparent.B));
            Origin.Source = Convert(bitmap);
            RedMask.Source = Convert(redMask);
            GreenMask.Source = Convert(greenMask);
            BlueMask.Source = Convert(blueMask);
        }

        private Bitmap ExtractMask(Bitmap bitmap, Func<Color,Color> getColorFromPixel)
        {
            var originHeight = bitmap.Height;
            var originWidth = bitmap.Width;
            var mask = new Bitmap(originWidth,originHeight);
            mask.MakeTransparent(Color.Transparent);
            for (var i = 0; i < originWidth; i++)
            {
                for (var j = 0; j < originHeight; j++)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    mask.SetPixel(i,j,getColorFromPixel(pixel));
                }
            }

            return mask;
        }
        public BitmapImage Convert(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }
    }
}
