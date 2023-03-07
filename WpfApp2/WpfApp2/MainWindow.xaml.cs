
using System.Windows;
using System.Windows.Controls;
using System;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Text;
using System.Linq;

namespace Pleer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bool isOpen = false;
        private static bool isPlay, repeat, mixed = false;
        private static Random rng = new Random();
        public MainWindow()
        {
            InitializeComponent();
            media.LoadedBehavior = MediaState.Manual;
            volumeSlider.Maximum = 1;
            volumeSlider.Minimum = 0;
            volumeSlider.Value = 0.5;
            
        }

        #region WindowLogic
        
        private void Window_Closed(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion


        #region ButtonLogic
        private void openFolderButton_Click(object sender, RoutedEventArgs e)
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

        private void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (musicListBox.SelectedIndex < musicListBox.Items.Count)
            {
                musicListBox.SelectedIndex++;
            }
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
                playIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Play;
            }
            else
            {
                media.Play();
                isPlay = true;
                playIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Pause;
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

        private void randButton_Click(object sender, RoutedEventArgs e)
        {
            if (isOpen)
            {
                if (mixed == false)
                {

                    musicListBox.ItemsSource = LoadMusic.getMusicFilesName.OrderBy(a => rng.Next());
                    randButton.Background = Brushes.Gray;
                    mixed = true;
                }
                else
                {
                    randButton.Background = Brushes.Transparent;
                    musicListBox.ItemsSource = LoadMusic.getMusicFilesName;
                    mixed = false;
                }
            }
        }

        #endregion


        #region SliderLogic
        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Volume = volumeSlider.Value;
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
        
        private void SliderUpdateStream()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (GetCurrentTime() != null && GetRemainingTime() != null)
                    {
                        UpdateSliderPosition(GetCurrentSliderPos());
                        SetCurrentTime(GetCurrentTime());
                        SetRemainingTime(GetRemainingTime());
                        if (GetCurrentTime() == GetTotalTime())
                        {
                            ChangeMusic();
                        }
                    }
                }
            });
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
        
        private long GetCurrentSliderPos()
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

        private string GetCurrentTime()
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

        private string GetTotalTime()
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

        private string GetRemainingTime()
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

        private void ChangeMusic()
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

        private void SetRemainingTime(string time)
        {
            media.Dispatcher.Invoke(() =>

            {
                if (media.NaturalDuration.HasTimeSpan)
                {
                    remainingTextBox.Text = time;
                }
            });
        }

        private void SetCurrentTime(string CurTime)
        {
            media.Dispatcher.Invoke(() =>

            {
                if (media.NaturalDuration.HasTimeSpan)
                {
                    currentTimeBox.Text = CurTime;
                }
            });
        }

        #endregion


        #region MediaLogic
        
        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
                if (media.NaturalDuration.HasTimeSpan)
                {
                    mediaSlider.Maximum = media.NaturalDuration.TimeSpan.Ticks;
                    mediaSlider.Value = 0;
                    if (isOpen == false)
                        SliderUpdateStream();
                    isOpen = true;
                }
        }

        #endregion


        #region MusicListBoxLogic
        
        private void musicListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (musicListBox.SelectedIndex != -1)
                media.Source = new Uri(LoadMusic.getMusicFiles.Find(p => p.Contains(musicListBox.SelectedItem.ToString())));
            else
            {
                media.Stop();
            }
        }

        #endregion


        
    }
}
