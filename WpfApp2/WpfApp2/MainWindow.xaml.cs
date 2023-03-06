
using System.Windows;
using System.Windows.Controls;
using System;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Text;

namespace Pleer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isOpen = false;
        private bool isPlay, repeat = false;
        public MainWindow()
        {
            InitializeComponent();
            media.LoadedBehavior = MediaState.Manual;
            volumeSlider.Maximum = 1;
            volumeSlider.Minimum = 0;
            volumeSlider.Value = 0.5;
            
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            LoadMusic.Load();
            musicListBox.ItemsSource = LoadMusic.getMusicFilesName;
            if (musicListBox.Items.Count != 0)
            {
                isPlay= true;
                musicListBox.SelectedIndex = 0;
                media.Play();
            }
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }

        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Volume = volumeSlider.Value;
        }

        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
                if (media.NaturalDuration.HasTimeSpan)
                {
                    mediaSlider.Maximum = media.NaturalDuration.TimeSpan.Ticks;
                    mediaSlider.Value = 0;
                    if (isOpen == false)
                        sliderUpdate();
                    isOpen = true;
                }
        }
        private void UpdateSliderPosition(long position)
        {
            
            mediaSlider.Dispatcher.Invoke(() =>
            {
                if (isPlay)
                {
                    mediaSlider.Value = position;
                }
            });
        }
        private void sliderUpdate()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (getTime() != null && getRemTime() != null)
                    {
                        UpdateSliderPosition(getCurPos());
                        setTime(getTime());
                        setRemTime(getRemTime());
                        if (getTime() == getTotalTime())
                        {
                            changeMusic();
                        }
                    }
                }
            });
        }
        private long getCurPos()
        {
            return media.Dispatcher.Invoke(() =>

            {
                if (media.NaturalDuration.HasTimeSpan)
                {
                    return media.Position.Ticks;
                }
                else
                {
                    return 0;
                }
            });
        }

        private string getTime()
        {
            return media.Dispatcher.Invoke(() =>

            {
                if (media.NaturalDuration.HasTimeSpan)
                {
                    return media.Position.ToString(@"hh\:mm\:ss");
                }
                else
                {
                    return null;
                }
            });
        }

        private string getTotalTime()
        {
            return media.Dispatcher.Invoke(() =>

            {
                if (media.NaturalDuration.HasTimeSpan)
                {
                    return media.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss");
                }
                else
                {
                    return null;
                }
            });
        }
        private string getRemTime()
        {
            return media.Dispatcher.Invoke(() =>

            {
                if (media.NaturalDuration.HasTimeSpan)
                {
                    return (media.NaturalDuration.TimeSpan - media.Position).ToString(@"hh\:mm\:ss");
                }
                else
                {
                    return null;
                }
            });
        }

        private void setRemTime(string time)
        {
            media.Dispatcher.Invoke(() =>

            {
                if (media.NaturalDuration.HasTimeSpan)
                {
                    remTextBox.Text = time;
                }
            });
        }

        private void setTime(string CurTime)
        {
            media.Dispatcher.Invoke(() =>

            {
                if (media.NaturalDuration.HasTimeSpan)
                {
                    curSecBox.Text = CurTime;
                }
            });
        }

        private void changeMusic()
        {
            media.Dispatcher.Invoke(() =>
            {
                if (media.NaturalDuration.HasTimeSpan)
                {
                    if (repeat)
                    {
                        media.Stop();
                        media.Play();
                    }
                    else if (musicListBox.SelectedIndex+1 != musicListBox.Items.Count)
                    {
                        musicListBox.SelectedIndex++;
                    }
                    else
                    {
                        mediaSlider.Value = 0;
                        media.Pause();
                    }
                }
            });
        }

        private void musicListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            media.Source = new Uri(LoadMusic.getMusicFiles[musicListBox.SelectedIndex]);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (musicListBox.SelectedIndex >= 1){
                musicListBox.SelectedIndex--;
            }
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlay)
            {
                media.Pause();
                isPlay = false;
            }
            else
            {
                media.Play();
                isPlay = true;
            }
        }

        private void repeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (isOpen == true)
            {
                if (repeat == false)
                {
                    repeatButton.Background = Brushes.Gray;
                    repeat = true;
                }
                else 
                {
                    repeatButton.Background = Brushes.Transparent;
                    repeat = false; 
                }
            }
        }

        private void mediaSlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            media.Pause();
            isPlay = false;
        }

        private void mediaSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            media.Position = new TimeSpan(Convert.ToInt64(mediaSlider.Value));
            media.Play();
            isPlay = true;
        }

        private void randButton_Click(object sender, RoutedEventArgs e) {
            if (isOpen == true)
            {
                Random random = new Random();
                musicListBox.SelectedIndex = random.Next(0, musicListBox.Items.Count-1);
            }
        }

        private void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (musicListBox.SelectedIndex < musicListBox.Items.Count)
            {
                musicListBox.SelectedIndex++;
            }
        }
    }
}
