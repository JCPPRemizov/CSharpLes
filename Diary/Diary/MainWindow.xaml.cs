using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotesManager notesManager;


        public List<Note> Notes = new List<Note>();

        public MainWindow()
        {
            InitializeComponent();
            DeleteButton.IsEnabled= false;
            EditButton.IsEnabled= false;
            notesManager = new NotesManager();
            NotesManager.LoadNotes();
            DatePicker.SelectedDate = DateTime.Today;
            NotesManager.UpdateNotesListBox((DateTime)DatePicker.SelectedDate);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            NotesManager.UpdateNotesListBox((DateTime)DatePicker.SelectedDate);
        }

        private void NotesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                notesManager.SelectedNote = (Note)e.AddedItems[0];
                notesManager.LoadSelectedNote();
            }
            DeleteButton.IsEnabled= true;
            EditButton.IsEnabled= true;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Length == 0 && DescriptionTextBox.Text.Length == 0)
            {
                MessageBox.Show("Введите название и описание заметки");
            }
            else {
                Note newNote = new Note() { Date = DatePicker.SelectedDate.Value, Description = DescriptionTextBox.Text, Title = NameTextBox.Text };
                NotesManager.notes.Add(newNote);
                // Обновляем список заметок в ListBox'е
                NotesManager.UpdateNotesListBox((DateTime)DatePicker.SelectedDate);

                // Выбираем только что созданную заметку
                NotesListBox.SelectedItem = newNote.Title;

                // Фокусируемся на TextBox'е с названием заметки для редактирования
                NameTextBox.Focus();

                NotesManager.SaveNotes();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            NotesManager.notes.Remove(notesManager.SelectedNote);
            NotesManager.UpdateNotesListBox((DateTime)DatePicker.SelectedDate);
            NotesManager.SaveNotes();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Length > 0 && DescriptionTextBox.Text.Length > 0) 
            {
                NotesManager.notes.Find(p => p == notesManager.SelectedNote).Title = NameTextBox.Text;
                NotesManager.notes.Find(p => p == notesManager.SelectedNote).Description = DescriptionTextBox.Text;
            }
            NotesManager.UpdateNotesListBox((DateTime)DatePicker.SelectedDate);
            NotesManager.SaveNotes();
        }

    }
}

