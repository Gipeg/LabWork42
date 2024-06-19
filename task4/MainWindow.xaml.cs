using Microsoft.Win32;
using System.Windows;
using System.Windows.Threading;

namespace task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (mediaElement.Source != null && mediaElement.NaturalDuration.HasTimeSpan)
            {
                TimeLabel.Content = $"{mediaElement.Position.ToString(@"hh\:mm\:ss")} / {mediaElement.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss")}";
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement.Source != null)
            {
                mediaElement.Play();
                timer.Start();
            }
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
            timer.Stop();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            timer.Stop();
        }

        private void FileListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (FileListBox.SelectedItem != null)
            {
                mediaElement.Source = new Uri(FileListBox.SelectedItem.ToString(), UriKind.Absolute);
                mediaElement.Play();
                timer.Start();
            }
        }

        private void LoadFiles()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Media files (*.mp4, *.mp3)|*.mp4;*.mp3";
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    FileListBox.Items.Add(file);
                }
            }
        }
        private void LoadFilesButton_Click(object sender, RoutedEventArgs e)
        {
            LoadFiles();
        }
    }
}