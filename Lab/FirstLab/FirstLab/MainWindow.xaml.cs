
using System.Windows;
using System.Windows.Controls;

namespace FirstLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        readonly FirstPage firstPage = new FirstPage();
        readonly SecondPage secondPage = new SecondPage();
        public MainWindow()
        {
            InitializeComponent();
            PageFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            returnButton.IsEnabled= false;
            PageFrame.Content = new FirstPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                returnButton.IsEnabled = true;
                NextButton.IsEnabled = false;
                PageFrame.Content = secondPage;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            returnButton.IsEnabled = false;
            NextButton.IsEnabled = true;
            PageFrame.Content = firstPage;
        }
    }
}
