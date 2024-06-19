using Microsoft.Win32;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            inkCanvas.DefaultDrawingAttributes.Color = Colors.Black;
            inkCanvas.DefaultDrawingAttributes.Width = 2;
            inkCanvas.DefaultDrawingAttributes.Height = 2;
        }

        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.png)|*.jpg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                inkCanvas.Background = new ImageBrush(bitmap);
            }
        }

        private void ColorComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (inkCanvas != null)
            {
                string colorName = (ColorComboBox.SelectedItem as System.Windows.Controls.ComboBoxItem).Content.ToString();
                inkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorName);
            }
        }

        private void PenSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (inkCanvas != null)
            {
                inkCanvas.DefaultDrawingAttributes.Width = e.NewValue;
                inkCanvas.DefaultDrawingAttributes.Height = e.NewValue;
            }
        }
    }
}
