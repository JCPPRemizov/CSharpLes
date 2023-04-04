using Accounting.Pages;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Accounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly static NewNotesTypeWindow NewNotesTypeWindow = new NewNotesTypeWindow();
        public MainWindow()
        {
            InitializeComponent();
            NewNotesTypeWindow.mainWindow = this;
            SavedNotes.LoadNotes();
            datePicker.SelectedDate = DateTime.Today;
            LoadComboBox();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            SavedNotes.SaveNotes();
            Application.Current.Shutdown();
        }

        private void newTypeButton_Click(object sender, RoutedEventArgs e)
        {
            new NewNotesTypeWindow().Show();
        }

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFields())
            {
                Note.NotesList.Add(new Note(NameTextBox.Text, NoteTypeComboBox.SelectedItem.ToString(), Convert.ToInt32(MoneyTextBox.Text), (DateTime)datePicker.SelectedDate));
                UpdateDataGrid();
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFields() && NotesDataGrid.SelectedItem != null)
            {
                var dataView = NotesDataGrid.SelectedItem as Note;
                int index = Note.NotesList.IndexOf(dataView);
                Note.NotesList[index] = new Note(NameTextBox.Text, NoteTypeComboBox.SelectedItem.ToString(), Convert.ToInt32(MoneyTextBox.Text), (DateTime)datePicker.SelectedDate);
                UpdateDataGrid();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (NotesDataGrid.SelectedItem != null)
            {
                var dataView = NotesDataGrid.SelectedItem as Note;
                Note.NotesList.Remove(dataView);
                UpdateDataGrid();
            }
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void NotesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NotesDataGrid.SelectedItem != null)
            {
                UpdateFields();
            }
        }

        private void UpdateDataGrid()
        {
            NotesDataGrid.ItemsSource = Note.NotesList.Where(p => p.noteDate == datePicker.SelectedDate).ToList();
            int totalCost = 0;
            Note.NotesList.ForEach(p => totalCost += p._money);
            TotalMoneyBox.Text = totalCost.ToString();
        }

        private void UpdateFields()
        {
            var dataRowView = NotesDataGrid.SelectedItem as Note;
            if (dataRowView != null)
            {
                NameTextBox.Text = dataRowView.name;
                NoteTypeComboBox.SelectedIndex = NoteTypeComboBox.Items.IndexOf(dataRowView.noteType);
                MoneyTextBox.Text = dataRowView._money.ToString();

            }
        }

        private void LoadComboBox()
        {
            if (NoteType.notesTypesList.Count > 0)
            {
                NoteTypeComboBox.ItemsSource = NoteType.notesTypesList.ToArray();
            }
        }

        private bool CheckFields()
        {
            if (!string.IsNullOrEmpty(NameTextBox.Text) && !string.IsNullOrEmpty(MoneyTextBox.Text) && NoteTypeComboBox.SelectedItem != null)
            {
                if (RegisterChecker.CheckDigit(MoneyTextBox.Text))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Введите число в поле \"Деньги\"!", "Ошибка");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!");
                return false;
            }
        }

    }
}
