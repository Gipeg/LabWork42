using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            videoElement.Source = new Uri("path_to_your_video_file", UriKind.Relative);
        }

        private void PlaySound1_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("sounds/shelchok-paltsami.mp3", UriKind.Relative));
            mediaPlayer.Play();
        }

        private void PlaySound2_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("sounds/tihiy-slabiy-shelchok.mp3", UriKind.Relative));
            mediaPlayer.Play();
        }
    }
}