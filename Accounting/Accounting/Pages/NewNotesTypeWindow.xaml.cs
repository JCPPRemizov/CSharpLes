using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Accounting.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewNotesTypeWindow.xaml
    /// </summary>
    public partial class NewNotesTypeWindow : Window
    {
        public static MainWindow mainWindow;
        public NewNotesTypeWindow()
        {
            InitializeComponent();
        }

        private void AddTypeButton_Click(object sender, RoutedEventArgs e)
        {
            NoteType.notesTypesList.Add(NameTextBox.Text);
            mainWindow.NoteTypeComboBox.ItemsSource = NoteType.notesTypesList.ToArray();
            MessageBox.Show("Успешно!");
            NameTextBox.Text = "";
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
