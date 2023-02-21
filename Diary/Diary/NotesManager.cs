using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Diary
{
    public class NotesManager
    {
        public static List<Note> notes = new List<Note>();
        

        private static string fileName = "notes.json";

        public Note SelectedNote { get; set; }
        public NotesManager()
        {
            notes = new List<Note>();
        }

        public static List<Note> GetNotesForDate(DateTime date)
        {
            return notes.Where(n => n.Date == date).ToList();
        }
        public static void LoadNotes()
        {
            if (File.Exists(fileName))
            {
                notes = NoteSerializer.Deserialize <Note>(fileName);
            }
        }

        public static void SaveNotes()
        {
            NoteSerializer.Serialize(notes, fileName);
        }
        public void LoadSelectedNote()
        {
            MainWindow mainWindow = GetMainWindow();
            if (SelectedNote == null) return;
            mainWindow.NameTextBox.Text = SelectedNote.Title;
            mainWindow.DescriptionTextBox.Text = SelectedNote.Description;
        }
        public static MainWindow GetMainWindow()
        {
            MainWindow mainWindow = null;

            foreach (Window window in Application.Current.Windows)
            {
                Type type = typeof(MainWindow);
                if (window != null && window.DependencyObjectType.Name == type.Name)
                {
                    mainWindow = (MainWindow)window;
                    if (mainWindow != null)
                    {
                        break;
                    }
                }
            }
            return mainWindow;
        }

        public static void UpdateNotesListBox(DateTime currentDate)
        {
            MainWindow mainWindow = GetMainWindow();
            List<Note> notes = GetNotesForDate(currentDate);

            mainWindow.NotesListBox.Items.Clear();
            foreach (Note note in notes)
            {
                mainWindow.NotesListBox.Items.Add(note);
                
            }
        }


    }


}
