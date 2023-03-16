using FirstLab.DataSetTableAdapters;
using System.Windows.Controls;

namespace FirstLab
{
    /// <summary>
    /// Логика взаимодействия для FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Page   
    {
        specializationsTableAdapter specializationsTableAdapter = new specializationsTableAdapter();
        public FirstPage()
        {
            InitializeComponent();
            FirstDataGrid.ItemsSource = specializationsTableAdapter.GetData();
        }
    }
}
