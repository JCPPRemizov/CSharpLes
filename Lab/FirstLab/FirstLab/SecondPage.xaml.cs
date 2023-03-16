using System.Windows.Controls;
using FirstLab.DataSetTableAdapters;

namespace FirstLab
{
    /// <summary>
    /// Логика взаимодействия для SecondPage.xaml
    /// </summary>
    public partial class SecondPage : Page
    {
        zavodTableAdapter zavodTableAdapter = new zavodTableAdapter();
        public SecondPage()
        {
            InitializeComponent();
            SecondDataGrid.ItemsSource = zavodTableAdapter.GetData();
        }
    }
}
