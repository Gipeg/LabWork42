using Microsoft.Win32;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.IO;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> imagePaths = new List<string>();
        private int currentImageIndex = 0;
        private Timer timer;

        public MainWindow()
        {
            InitializeComponent();
            LoadImages();
            StartCarousel();
        }

        private void LoadImages()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.png)|*.jpg;*.png";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                imagePaths.AddRange(openFileDialog.FileNames);
            }
        }

        private void StartCarousel()
        {
            if (imagePaths.Count > 0)
            {
                timer = new Timer(300);
                timer.Elapsed += OnTimedEvent;
                timer.AutoReset = true;
                timer.Enabled = true;
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (imagePaths.Count > 0)
                {
                    currentImageIndex = (currentImageIndex + 1) % imagePaths.Count;
                    carouselImage.Source = new BitmapImage(new Uri(imagePaths[currentImageIndex]));
                }
            });
        }
    }
}